using Application.Common;
using Application.Confessions.Common;
using Application.Services.Repositories;
using MediatR;
using OneOf;

namespace Application.Confessions.Query.GetPagedConfessions;
public class GetPagedConfessionsHandler(IConfessionRepository _confessionRepository) : IRequestHandler<GetPagedConfessionsQuery, OneOf<List<ConfessionResponse>, CustomError>>
{
    public async Task<OneOf<List<ConfessionResponse>, CustomError>> Handle(GetPagedConfessionsQuery request, CancellationToken cancellationToken)
    {
        var confessionsResponse = new List<ConfessionResponse>();
        var results = await _confessionRepository.GetPaged(request.offset, request.count);

        foreach (var result in results)
        {
            var item = new ConfessionResponse(result.Id, result.Title, result.Message, result.Upvotes, result.DownVotes, result.CreatedAt, result.ModifiedAt);

            confessionsResponse.Add(item);
        }

        return confessionsResponse;
    }
}
