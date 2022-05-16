using MediatR;
using Microsoft.EntityFrameworkCore;
using BitirmeProjesiBackend.Application.CQRS.Commands;
using BitirmeProjesiBackend.Data.Context;

namespace BitirmeProjesiBackend.Application.CQRS.CommandHandlers
{
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand>
    {
        private readonly Context _context;

        public UpdateEventCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var updatedEvent = await _context.Events.SingleOrDefaultAsync(x => x.Id == request.Id);
            if (updatedEvent != null)
            {
                updatedEvent.Name = request.Name;
                updatedEvent.Explanation = request.Explanation;
                updatedEvent.Director = request.Director;
                updatedEvent.Point = request.Point;
                updatedEvent.StartDate = request.StartDate;
                updatedEvent.EndDate = request.EndDate;
                updatedEvent.ImageUrl = request.ImageUrl;
                updatedEvent.Latitude = request.Latitude;
                updatedEvent.Quota = request.Quota;
                updatedEvent.Longitude = request.Longitude;
                updatedEvent.Type = request.Type;
               
                await _context.SaveChangesAsync();
            }

            return Unit.Value;
        }
    }
}
