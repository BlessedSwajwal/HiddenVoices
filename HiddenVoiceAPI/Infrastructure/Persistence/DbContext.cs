using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions contextOptions) : base(contextOptions) { }

    public DbSet<Confession> Confessions { get; set; }
    public DbSet<Reply> Replies { get; set; }
}
