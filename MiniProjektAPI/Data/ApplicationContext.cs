using Microsoft.EntityFrameworkCore;
using MiniProjektAPI.Model;


namespace MiniProjektAPI.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Person>Persons { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<InterestLinks> InterestLinks { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
    }
}


