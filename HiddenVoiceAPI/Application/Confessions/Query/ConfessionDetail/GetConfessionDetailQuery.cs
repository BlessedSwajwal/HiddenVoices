using Application.Common;
using Application.Confessions.Common;
using MediatR;
using OneOf;

namespace Application.Confessions.Query.ConfessionDetail;
public record GetConfessionDetailQuery(Guid id) : IRequest<OneOf<ConfessionWithReplies, CustomError>>;
