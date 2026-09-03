using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ClassLibrary.Data;

public class BlixtHackContextFactory : IDesignTimeDbContextFactory<BlixtHackDbContext> {
    public BlixtHackDbContext CreateDbContext(string[] args) {
        var config = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).Build();
        var options = new DbContextOptionsBuilder<BlixtHackDbContext>()
            .UseSqlServer(config.GetConnectionString("DefaultConnection"))
            .Options;

        return new BlixtHackDbContext();
    }
}