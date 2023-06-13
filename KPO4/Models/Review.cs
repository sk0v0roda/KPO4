namespace KPO4.Models
{
    public class Review
    {
        public Guid Id { get; set; }
        public Guid HotelId { get; set; }
        public String Text { get; set; }
        public double rating { get; set; }
    }
}
