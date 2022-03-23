using Microsoft.EntityFrameworkCore;

namespace CreditaNelas.Models
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("workstation id=CreditaNelas.mssql.somee.com;packet size=4096;user id=liperodrigues_SQLLogin_1;pwd=pkk2eqdtbu;data source=CreditaNelas.mssql.somee.com;persist security info=False;initial catalog=CreditaNelas");
        }

        public DbSet<Usuarios> Usuario { get; set; }
        public DbSet<Postagens> Postagem { get; set; }
    }

}
