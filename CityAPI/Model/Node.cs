using CityAPI.Class;
namespace CityAPI.Model

{
    public class Node
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public DateTime? Date { get; set; }
        public ICollection<Node>? RelatedNodes { get; set; }
    }
}
