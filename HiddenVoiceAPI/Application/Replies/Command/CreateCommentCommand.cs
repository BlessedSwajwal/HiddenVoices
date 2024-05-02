using Application.Common;
using Domain;
using MediatR;
using OneOf;

namespace Application.Replies.Command;
public record CreateCommentCommand(Guid confessionId, string reply, Guid? parentReply) : IRequest<OneOf<Reply, CustomError>>;
