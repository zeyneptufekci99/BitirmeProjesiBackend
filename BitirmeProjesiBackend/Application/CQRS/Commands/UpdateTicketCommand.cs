using MediatR;

namespace BitirmeProjesiBackend.Application.CQRS.Commands
{
    public class UpdateTicketCommand : IRequest
    {
        public int Id { get; set; }
        public string Numara { get; set; } = String.Empty;
        public int? EventId { get; set; }
        public int? UserId { get; set; }
    }
}
