using IlhadasLendasAPI.Domain.Entities;
using IlhadasLendasAPI.Infrastructure.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IlhadasLendasAPI.Infrastructure.Configurations
{
    public class RoleConfiguration : ConfigurationBase<Role>
    {
        public override void Configure(EntityTypeBuilder<Role> builder)
        {
            tableName = "Roles";

            base.Configure(builder);

            builder.Property(p => p.Nome)
                    .IsRequired()
                    .HasColumnName("Nome")
                    .HasMaxLength(300)
                    .HasColumnType("varchar(300)");

            builder.Property(p => p.Descricao)
                    .IsRequired()
                    .HasColumnName("Descricao")
                    .HasMaxLength(500)
                    .HasColumnType("varchar(500)");
        }
    }
}