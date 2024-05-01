using Application.Common;
using Domain;
using MediatR;
using OneOf;

namespace Application.Confessions.Command.Create;

public record CreateConfessionCommand(string Title, string Message) : IRequest<OneOf<Confession, CustomError>>;
