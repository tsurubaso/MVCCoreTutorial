using Microsoft.EntityFrameworkCore;

namespace MVCCoreTutorial.Models.Domain
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) 
        {
        
        
        }

        public DbSet<Person> Persons { get; set; }








    }
}
