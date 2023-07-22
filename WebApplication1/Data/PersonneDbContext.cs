using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class PersonneDbContext : DbContext
    {

        public PersonneDbContext(DbContextOptions<PersonneDbContext> options)
       : base(options) 
        {
            
        }
        public DbSet<Personne> Personnes { get; set; }
    }
}
