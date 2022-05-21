using MediatR;
using Microsoft.EntityFrameworkCore;
using BitirmeProjesiBackend.Application.CQRS.Queries;
using BitirmeProjesiBackend.Application.Dtos;
using BitirmeProjesiBackend.Data.Context;

namespace BitirmeProjesiBackend.Application.CQRS.QueryHandlers
{
    public class GetCommentListQueryHandler : IRequestHandler<GetCommentListQuery, List<CommentDto>>
    {
        private readonly Context _context;

        public GetCommentListQueryHandler(Context context)
        {
            _context = context;
        }
        public async Task<List<CommentDto>> Handle(GetCommentListQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Comments.Join(_context.Users, comment => comment.UserId, user => user.Id, (comment, user) => new { user, comment })
               .Select(x => new CommentDto { Id = x.comment.Id, Date = x.comment.Date, EventId = x.comment.EventId, UserId = x.comment.UserId, Content = x.comment.Content, Username = x.user.Username }).ToListAsync();

            return result;
        }
    }
}