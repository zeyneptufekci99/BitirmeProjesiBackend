using MediatR;
using Microsoft.EntityFrameworkCore;
using BitirmeProjesiBackend.Application.CQRS.Queries;
using BitirmeProjesiBackend.Application.Dtos;
using BitirmeProjesiBackend.Data.Context;

namespace BitirmeProjesiBackend.Application.CQRS.QueryHandlers
{
    public class GetCommentByIdQueryHandler : IRequestHandler<GetCommentByIdQuery, CommentDto?>
    {
        private readonly Context _context;

        public GetCommentByIdQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<CommentDto?> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Comments.AsNoTracking().Select(x => new CommentDto
            {
                Id = x.Id,
                Content = x.Content,
                UserId=x.UserId,
                EventId=x.EventId,
                Date=x.Date,

            }).SingleOrDefaultAsync(x => x.Id == request.Id);

            return result;
        }
    }
}
