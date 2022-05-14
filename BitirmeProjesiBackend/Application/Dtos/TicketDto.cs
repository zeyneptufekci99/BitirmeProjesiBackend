namespace BitirmeProjesiBackend.Application.Dtos
{
    public class TicketDto
    {
        public int Id { get; set; }
        public string Numara { get; set; } = String.Empty;
        public int? EventId { get; set; }
        public int? UserId { get; set; }
    }
}
