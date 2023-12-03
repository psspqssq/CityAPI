using CityAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace CityAPI.Context
{
    class CycleDB : DbContext
    {
        public CycleDB(DbContextOptions<CycleDB> options)
            : base(options)
        {
        }
        public DbSet<Cycle> Cycles => Set<Cycle>();
        public DbSet<Node> Nodes => Set<Node>();
    }
}
