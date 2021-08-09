using Confitec.Cadastro.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Confitec.Cadastro.Data.Context
{
    public class ConfitecDbContext : DbContext
    {
        public ConfitecDbContext(DbContextOptions<ConfitecDbContext> options) : base(options)
        { }

        public DbSet<Usuario> Usuarios { get; set; }       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ConfitecDbContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }
    }
}
