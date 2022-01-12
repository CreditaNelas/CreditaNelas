using Microsoft.EntityFrameworkCore;

namespace CreditaNelas.Models
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=****;Initial Catalog=*****;Persist Security Info=False;User ID=*****;Password=*****;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        public DbSet<Usuarios> Usuario { get; set; }
        public DbSet<Postagens> Postagem { get; set; }
    }

}
