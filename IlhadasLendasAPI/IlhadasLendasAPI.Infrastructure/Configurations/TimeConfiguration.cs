using IlhadasLendasAPI.Domain.Entities;
using IlhadasLendasAPI.Infrastructure.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IlhadasLendasAPI.Infrastructure.Configurations
{
    public class TimeConfiguration : ConfigurationUploadB64Base<Time>
    {
        public override void Configure(EntityTypeBuilder<Time> builder)
        {
            tableName = "Times";

            base.Configure(builder);

            builder.Property(p => p.Nome)
                    .IsRequired()
                    .HasColumnName("Nome")
                    .HasMaxLength(300)
                    .HasColumnType("varchar(300)");

            builder.Property(p => p.Media)
                   .IsRequired()
                   .HasMaxLength(10000)
                   .HasColumnName("Media")
                   .HasColumnType("int");
        }
    }
}