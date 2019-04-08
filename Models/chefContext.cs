using Microsoft.EntityFrameworkCore;
 
namespace chefsstuffs.Models
{
    public class chefContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public chefContext(DbContextOptions<chefContext> options) : base(options) { }
            public DbSet<Chef> chef {get;set;}
            public DbSet<Dish> dish {get;set;}
        
    }
}
