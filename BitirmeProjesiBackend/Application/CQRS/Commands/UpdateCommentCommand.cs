using MediatR;

namespace BitirmeProjesiBackend.Application.CQRS.Commands
{
    public class UpdateCommentCommand : IRequest
    {
        public int Id { get; set; }
        public string Content { get; set; } = String.Empty;
        public int UserId { get; set; }
        public int EventId { get; set; }
        public DateTime Date { get; set; }
    }
}


