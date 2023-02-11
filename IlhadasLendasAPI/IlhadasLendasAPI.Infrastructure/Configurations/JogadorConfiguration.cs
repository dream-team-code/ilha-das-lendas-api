using IlhadasLendasAPI.Domain.Entities;
using IlhadasLendasAPI.Infrastructure.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IlhadasLendasAPI.Infrastructure.Configurations
{
    public class JogadorConfiguration : ConfigurationUploadB64Base<Jogador>
    {
        public override void Configure(EntityTypeBuilder<Jogador> builder)
        {
            tableName = "Jogadores";

            base.Configure(builder);

            builder.Property(p => p.Nome)
                    .IsRequired()
                    .HasColumnName("Nome")
                    .HasMaxLength(300)
                    .HasColumnType("varchar(300)");

            builder.Property(p => p.Nick)
                    .IsRequired()
                    .HasColumnName("Nick")
                    .HasMaxLength(300)
                    .HasColumnType("varchar(300)");

            builder.Property(p => p.Pontuacao)
                   .IsRequired()
                   .HasMaxLength(10000)
                   .HasColumnName("Pontuacao")
                   .HasColumnType("int");

            builder.Property(p => p.UltimaPontuacao)
                   .IsRequired()
                   .HasMaxLength(10000)
                   .HasColumnName("UltimaPontuacao")
                   .HasColumnType("int");

            builder.Property(p => p.MVP)
                   .IsRequired()
                   .HasMaxLength(10000)
                   .HasColumnName("MVP")
                   .HasColumnType("int");

            builder.Property(p => p.Bagre)
                   .IsRequired()
                   .HasMaxLength(10000)
                   .HasColumnName("Bagre")
                   .HasColumnType("int");

            builder.Property(p => p.CategoriaJogador)
                   .IsRequired()
                   .HasMaxLength(50)
                   .HasColumnName("CategoriaJogador")
                   .HasColumnType("varchar(50)")
                   .HasDefaultValue("Academy");
        }
    }
}