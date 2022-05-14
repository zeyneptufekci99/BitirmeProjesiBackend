using MediatR;
using Microsoft.EntityFrameworkCore;
using BitirmeProjesiBackend.Application.CQRS.Commands;
using BitirmeProjesiBackend.Data.Context;

namespace BitirmeProjesiBackend.Application.CQRS.CommandHandlers
{
    public class RemoveEventCommandHandler : IRequestHandler<RemoveEventCommand>
    {
        private readonly Context _context;

        public RemoveEventCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(RemoveEventCommand request, CancellationToken cancellationToken)
        {
            var removedEvent = await _context.Events.SingleOrDefaultAsync(x => x.Id == request.Id);
            if(removedEvent != null)
            {
                _context.Events.Remove(removedEvent);
                await _context.SaveChangesAsync();

            }
            return Unit.Value;
        }
    }
}
