using Application.Common;
using Application.Services.Repositories;
using Domain;
using MediatR;
using OneOf;

namespace Application.Confessions.Command.Create;
public class CreateConfessionCommandHandler(IConfessionRepository _confesstionRepository) : IRequestHandler<CreateConfessionCommand, OneOf<Confession, CustomError>>
{
    public async Task<OneOf<Confession, CustomError>> Handle(CreateConfessionCommand request, CancellationToken cancellationToken)
    {
        var confession = Confession.Create(request.Title, request.Message);
        await _confesstionRepository.Add(confession);
        return confession;
    }
}
