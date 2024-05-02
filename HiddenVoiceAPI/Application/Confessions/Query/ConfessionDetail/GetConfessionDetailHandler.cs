using Application.Common;
using Application.Common.DTO;
using Application.Confessions.Common;
using Application.Services.Repositories;
using Domain;
using MediatR;
using OneOf;
using System.Net;

namespace Application.Confessions.Query.ConfessionDetail;
public class GetConfessionDetailHandler(IConfessionRepository _confessionRepository, IReplyRepository _replyRepository) : IRequestHandler<GetConfessionDetailQuery, OneOf<ConfessionWithReplies, CustomError>>
{
    public async Task<OneOf<ConfessionWithReplies, CustomError>> Handle(GetConfessionDetailQuery request, CancellationToken cancellationToken)
    {
        List<ReplyResponse> replies = new List<ReplyResponse>();
        var confession = await _confessionRepository.GetByIdAsync(request.id);
        if (confession == Confession.Empty) return new CustomError((int)HttpStatusCode.NotFound, "Confession with given id does not exist.");
        var repliesOfConfession = await _replyRepository.GetRepliesByConfessionId(confession.Id);
        replies = repliesOfConfession.Select(r => new ReplyResponse(r.Id, r.Message, r.Upvotes, r.Downvotes, r.ConfessionId, r.ParentReply)).ToList();
        var confessionResponse = new ConfessionWithReplies(confession.Id, confession.Title, confession.Message, confession.Upvotes, confession.DownVotes, confession.CreatedAt, confession.ModifiedAt, replies);
        return confessionResponse;
    }
}
