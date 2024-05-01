using Application.Common;
using Application.Confessions.Common;
using Application.Services.Repositories;
using Domain;
using MediatR;
using OneOf;
using System.Net;

namespace Application.Confessions.Query.ConfessionDetail;
public class GetConfessionDetailHandler(IConfessionRepository _confessionRepository) : IRequestHandler<GetConfessionDetailQuery, OneOf<ConfessionResponse, CustomError>>
{
    public async Task<OneOf<ConfessionResponse, CustomError>> Handle(GetConfessionDetailQuery request, CancellationToken cancellationToken)
    {
        var confession = await _confessionRepository.GetByIdAsync(request.id);
        if (confession == Confession.Empty) return new CustomError((int)HttpStatusCode.NotFound, "Confession with given id does not exist.");
        var confessionResponse = new ConfessionResponse(confession.Id, confession.Title, confession.Message, confession.Upvotes, confession.DownVotes, confession.CreatedAt, confession.ModifiedAt);
        return confessionResponse;
    }
}
