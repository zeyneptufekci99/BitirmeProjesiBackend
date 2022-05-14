using MediatR;

namespace BitirmeProjesiBackend.Application.CQRS.Commands
{
    public class RemoveTicketCommand : IRequest
    {
        public int Id { get; set; }
        public RemoveTicketCommand(int id)
        {
            Id = id;
        }
    }
}
