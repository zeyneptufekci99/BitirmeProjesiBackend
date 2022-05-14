namespace BitirmeProjesiBackend.Data.Entities
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Numara { get; set; }=String.Empty;
        public int? EventId { get; set; }
        public Event? Event { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
    }
}
