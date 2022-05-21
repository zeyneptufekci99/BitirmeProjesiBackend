namespace BitirmeProjesiBackend.Application.Dtos
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Content { get; set; } = String.Empty;
        public int UserId { get; set; }
        public int EventId { get; set; }
        public DateTime Date { get; set; }
        public string Username { get; set; } = String.Empty;
    }
}
