using MediatR;
using BitirmeProjesiBackend.Application.Dtos;

namespace BitirmeProjesiBackend.Application.CQRS.Queries
{
    public class GetCommentListQuery:IRequest<List<CommentDto>>
    {
    }
}
