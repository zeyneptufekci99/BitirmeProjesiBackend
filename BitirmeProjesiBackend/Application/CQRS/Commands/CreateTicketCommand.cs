using MediatR;

namespace BitirmeProjesiBackend.Application.CQRS.Commands
{
    public class CreateTicketCommand : IRequest
    {
        public string Numara { get; set; } = String.Empty;
        public int? EventId { get; set; }
        public int? UserId { get; set; }
    }
}
