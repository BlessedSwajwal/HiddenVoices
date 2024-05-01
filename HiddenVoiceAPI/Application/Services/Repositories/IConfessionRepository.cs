using Domain;

namespace Application.Services.Repositories;
public interface IConfessionRepository
{
    Task Add(Confession confession);
    Task<List<Confession>> GetPaged(int offest, int count);
}
