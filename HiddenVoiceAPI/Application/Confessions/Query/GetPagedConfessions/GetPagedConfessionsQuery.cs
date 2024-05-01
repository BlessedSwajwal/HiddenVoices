using Application.Common;
using Application.Confessions.Common;
using MediatR;
using OneOf;

namespace Application.Confessions.Query.GetPagedConfessions;
public record GetPagedConfessionsQuery(int offset, int count) : IRequest<OneOf<List<ConfessionResponse>, CustomError>>;
