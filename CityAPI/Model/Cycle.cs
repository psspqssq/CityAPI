using CityAPI.Class;
namespace CityAPI.Model

{
    public class Cycle
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsComplete { get; set; }
        public DateTime? Date { get; set; }
        public ICollection<CityRoute>? Routes { get; set; }
    }
}
