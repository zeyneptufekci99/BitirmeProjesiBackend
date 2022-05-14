using MediatR;
using BitirmeProjesiBackend.Application.CQRS.Commands;
using BitirmeProjesiBackend.Data.Context;
using BitirmeProjesiBackend.Data.Entities;

namespace BitirmeProjesiBackend.Application.CQRS.CommandHandlers
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand>
    {
        private readonly Context _context;

        public CreateCommentCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var createdComment=new Comment();
            createdComment.Content=request.Content;
            createdComment.UserId=request.UserId;
            createdComment.EventId=request.EventId;
            createdComment.Date=request.Date;

            await _context.Comments.AddAsync(createdComment);
            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
