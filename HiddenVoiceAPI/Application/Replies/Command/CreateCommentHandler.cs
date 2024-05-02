using Application.Common;
using Application.Services.Repositories;
using Domain;
using MediatR;
using OneOf;

namespace Application.Replies.Command;
public class CreateCommentHandler(IReplyRepository _replyRepository) : IRequestHandler<CreateCommentCommand, OneOf<Reply, CustomError>>
{
    public async Task<OneOf<Reply, CustomError>> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = Reply.Create(request.reply, request.confessionId, request.parentReply);
        await _replyRepository.CreateComment(comment);
        return comment;
    }
}
