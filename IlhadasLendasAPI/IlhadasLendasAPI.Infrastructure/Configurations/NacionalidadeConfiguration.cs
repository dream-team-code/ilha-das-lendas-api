using IlhadasLendasAPI.Domain.Entities;
using IlhadasLendasAPI.Infrastructure.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IlhadasLendasAPI.Infrastructure.Configurations
{
    public class NacionalidadeConfiguration : ConfigurationBase<Nacionalidade>
    {
        public override void Configure(EntityTypeBuilder<Nacionalidade> builder)
        {
            tableName = "Nacionaldiades";

            base.Configure(builder);

            builder.Property(p => p.Nome)
                    .IsRequired()
                    .HasColumnName("Nome")
                    .HasMaxLength(300)
                    .HasColumnType("varchar(300)");
        }
    }
}