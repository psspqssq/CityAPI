using Microsoft.EntityFrameworkCore;
using CityAPI.Model;
using CityAPI.Context;
using DijkstraAlgorithm;
using System.Text.Json;
using CityAPI.Class;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<CycleDB>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

app.MapGet("/cycles", async (CycleDB db) =>
    await db.Cycles.Include(b=> b.Routes).ThenInclude(b=>b.movementArray).ToListAsync());

/*
app.MapGet("/cycles/complete", async (CycleDB db) =>
    await db.Cycles.Where(t => t.IsComplete).ToListAsync());
*/

app.MapGet("/cycleitems/{id}", async (int id, CycleDB db) =>
    await db.Cycles.FindAsync(id)
        is Cycle cycle
            ? Results.Ok(cycle)
            : Results.NotFound());

app.MapGet("/dijkstra/{from}/{to}", async (int from, int to, CycleDB db) =>
{
    var graph = new Dijkstra();
    var results = graph.ShortestPath(from, to);
    string returnObject = "";
    List<CityRoute> routeResults = new List<CityRoute>();
    var currentCycle = db.Cycles.Include(b => b.Routes).OrderBy(n => n.Id).Last();
    if(currentCycle.Routes == null)
    {
        currentCycle.Routes = new List<CityRoute>();
    }
    results.ForEach(async n =>
    {
        CityRoute route = new CityRoute()
        {
            From = n.From.Value.ToString(),
            To = n.To.Value.ToString(),
            approximateTravelTime = n.Weight
        };
        routeResults.Add(route);
        currentCycle.Routes.Add(route);
    });
    await db.SaveChangesAsync();
    return JsonSerializer.Serialize<IEnumerable<CityRoute>>(routeResults);
});

app.MapPost("/cycleitems", async (Cycle cycle, CycleDB db) =>
{
    db.Cycles.Add(cycle);
    await db.SaveChangesAsync();

    return Results.Created($"/cycleitems/{cycle.Id}", cycle);
});


app.MapPut("/cycleitems/{id}", async (int id, Cycle inputCycle, CycleDB db) =>
{
    var cycle = await db.Cycles.FindAsync(id);

    if (cycle is null) return Results.NotFound();

    cycle.Name = inputCycle.Name;
    cycle.IsComplete = inputCycle.IsComplete;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/cycleitems/{id}", async (int id, CycleDB db) =>
{
    if (await db.Cycles.FindAsync(id) is Cycle cycle)
    {
        db.Cycles.Remove(cycle);
        await db.SaveChangesAsync();
        return Results.NoContent();
    }

    return Results.NotFound();
});


app.MapGet("/nodes", async (CycleDB db) =>
    await db.Nodes
    .Where(b=>b.Name=="A")
    .Include(b=>b.RelatedNodes)
    .ThenInclude(b => b.RelatedNodes)
    .ThenInclude(b => b.RelatedNodes)
    .ThenInclude(b => b.RelatedNodes)
    .ThenInclude(b => b.RelatedNodes)
    .ToListAsync());

app.MapPost("/nodes", async (Node node, CycleDB db) =>
{
    db.Nodes.Add(node);
    await db.SaveChangesAsync();
    return Results.Created($"/node/{node.Id}", node);
});


app.Run();

