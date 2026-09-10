using ClassLibrary.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary.Data;

public class BlixtHackDbContext : DbContext {
    public DbSet<Category> Categories { get; set; }
    public DbSet<Topic> Topics { get; set; }
    public DbSet<TopicResponse> TopicsResponses { get; set; }
    
    public BlixtHackDbContext() {
    }

    public BlixtHackDbContext(DbContextOptions<BlixtHackDbContext> options) : base(options) {
    }
}