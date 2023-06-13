namespace KPO4.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        public Guid HotelId { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime LeavingTime { get; set; }

    }
}
