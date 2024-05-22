using Microsoft.EntityFrameworkCore;

namespace kriptoProTask
{
    public class ModelContext: DbContext
    {
       public DbSet<Model> Models { get; set; }
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=kriptoProdb;Username=postgres;Port=5432;password=02190");
        }


    }
}
