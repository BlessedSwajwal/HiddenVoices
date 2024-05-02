using Domain;

namespace Application.Services.Repositories;
public interface IReplyRepository
{
    Task CreateComment(Reply comment);
    Task<List<Reply>> GetRepliesByConfessionId(Guid confessionId);
}
