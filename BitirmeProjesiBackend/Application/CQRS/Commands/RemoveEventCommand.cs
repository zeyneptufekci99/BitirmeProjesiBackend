using MediatR;

namespace BitirmeProjesiBackend.Application.CQRS.Commands
{
    public class RemoveEventCommand:IRequest
    {
        public int Id { get; set; }
        public RemoveEventCommand(int id)
        {
            Id = id;
        }

        

    }
}
