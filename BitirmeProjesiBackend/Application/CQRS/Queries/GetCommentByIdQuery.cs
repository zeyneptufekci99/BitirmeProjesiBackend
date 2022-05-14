using MediatR;
using BitirmeProjesiBackend.Application.Dtos;

namespace BitirmeProjesiBackend.Application.CQRS.Queries
{
    public class GetCommentByIdQuery:IRequest<CommentDto?>
    {
        public int Id { get; set; }

        public GetCommentByIdQuery(int id)
        {
            Id = id;
        }
    }
}