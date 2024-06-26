﻿using Application.Services.Repositories;
using Domain;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
internal class ConfessionRepository(ApplicationDbContext _dbContext) : IConfessionRepository
{
    public async Task Add(Confession confession)
    {
        await _dbContext.Confessions.AddAsync(confession);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Confession> GetByIdAsync(Guid id)
    {
        var confession = await _dbContext.Confessions.FirstOrDefaultAsync(c => c.Id == id);
        if (confession is null) return Confession.Empty;
        return confession;
    }

    public async Task<List<Confession>> GetPaged(int offest, int count)
    {
        var confessions = _dbContext.Confessions.OrderByDescending(con => con.Upvotes).Skip(offest * 10).Take(count);
        return await confessions.ToListAsync();
    }
}
