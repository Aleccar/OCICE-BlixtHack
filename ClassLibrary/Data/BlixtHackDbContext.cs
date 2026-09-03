using Microsoft.EntityFrameworkCore;
using OCICE_BlixtHack.Models;
using Thread = System.Threading.Thread;

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