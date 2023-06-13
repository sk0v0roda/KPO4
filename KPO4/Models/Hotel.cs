using System.ComponentModel.DataAnnotations.Schema;

namespace KPO4.Models
{
    public class Hotel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public double Price { get; set; }
        public double Rating { get; set; }
        public int NumberOfRatings { get; set; }
        [NotMapped]
        public List<String> Advantages { get; set; }
    }
}
