using Microsoft.EntityFrameworkCore;

namespace ClassLibrary.Data;

public class DataInitializer {

    private readonly BlixtHackDbContext _context;

    public DataInitializer(BlixtHackDbContext context) {
        _context = context;
    }
    
    public void MigrateAndSeed() {
        _context.Database.Migrate();
    }
}