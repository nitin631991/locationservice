using Microsoft.EntityFrameworkCore;
using LocationService.Models;

namespace LocationService.Data
{

    public class AppDbContext:DbContext
    {
            protected override void OnConfiguring
       (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "LocationDb");
        }
             public DbSet<Location> Locations {get;set;}
    }
}