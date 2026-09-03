using Microsoft.EntityFrameworkCore;

namespace ClassLibrary.Data;

public class BlixtHackDbContext : DbContext {
    public DbSet<Category> Categories { get; set; }
    public DbSet<Thread> Threads { get; set; }
    public DbSet<ThreadResponse> ThreadResponses { get; set; }
    
    public BlixtHackDbContext() {
    }

    public BlixtHackDbContext(DbContextOptions<BlixtHackDbContext> options) : base(options) {
    }
}