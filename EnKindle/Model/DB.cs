using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EnKindle.Model
{
    public class DB : DbContext
    {

        // HEY! ADD THESE CONTRUCTORS!
        public DB() { }
        public DB(DbContextOptions<DB> options) : base(options) { }

        // HEY! CREATE A DB FOR EACH EXISTING MODEL(S)
        //public DbSet<Greetings> Friends { get; set; }
        //public DbSet<Greetings> Frenemies { get; set; }
        //public DbSet<Greetings> Enemies { get; set; }
        public DbSet<Greetings> Greetings { get; set; }



    }
}
