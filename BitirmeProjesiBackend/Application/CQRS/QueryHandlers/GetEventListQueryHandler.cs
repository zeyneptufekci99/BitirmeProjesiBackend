using MediatR;
using Microsoft.EntityFrameworkCore;
using BitirmeProjesiBackend.Application.CQRS.Queries;
using BitirmeProjesiBackend.Application.Dtos;
using BitirmeProjesiBackend.Data.Context;

namespace BitirmeProjesiBackend.Application.CQRS.QueryHandlers
{
    public class GetEventListQueryHandler : IRequestHandler<GetEventListQuery, List<EventDto>>
    {
        private readonly Context _context;

        public GetEventListQueryHandler(Context context)
        {
            _context = context;
        }
        public async Task<List<EventDto>> Handle(GetEventListQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Events.AsNoTracking().Select(x => new EventDto
            {
                Id = x.Id,
                Name = x.Name,
                ImageUrl = x.ImageUrl,
                Explanation = x.Explanation,
                Type= x.Type,
                Director = x.Director,
                Point = x.Point,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                Quota = x.Quota,
                Longitude = x.Longitude,
                Latitude = x.Latitude,
                Donated = x.Donated,

            }).ToListAsync();

            return result;



        }
    }
}
