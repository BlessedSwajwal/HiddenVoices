using Application.Services.Repositories;
using Domain;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class ReplyRepository(ApplicationDbContext _dbContext) : IReplyRepository
{
    public async Task CreateComment(Reply comment)
    {
        await _dbContext.Replies.AddAsync(comment);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<Reply>> GetRepliesByConfessionId(Guid confessionId)
    {
        var replies = await _dbContext.Replies.Where(r => r.ConfessionId == confessionId).ToListAsync();
        return replies;
    }
}
