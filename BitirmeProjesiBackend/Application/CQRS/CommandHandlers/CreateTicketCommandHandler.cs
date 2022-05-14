using MediatR;
using BitirmeProjesiBackend.Application.CQRS.Commands;
using BitirmeProjesiBackend.Data.Context;
using BitirmeProjesiBackend.Data.Entities;

namespace BitirmeProjesiBackend.Application.CQRS.CommandHandlers
{
    public class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand>
    {
        private readonly Context _context;

        public CreateTicketCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
        {
            var createdTicket = new Ticket();
            createdTicket.Numara = request.Numara;
            createdTicket.EventId = request.EventId;
            createdTicket.UserId = request.UserId;


            await _context.Tickets.AddAsync(createdTicket);
            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
