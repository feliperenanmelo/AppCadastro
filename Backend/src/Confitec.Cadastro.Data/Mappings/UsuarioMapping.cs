using Confitec.Cadastro.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Confitec.Cadastro.Data.Mappings
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.Property(u => u.Id).ValueGeneratedOnAdd();

            builder.Property(u => u.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(u => u.Sobrenome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(u => u.Email)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(u => u.DataNascimento)
               .IsRequired()
               .HasColumnType("Date");

            builder.Property(u => u.Escolaridade)
            .IsRequired();

            builder.ToTable("Usuarios");
        }
    }   
}
