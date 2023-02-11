using IlhadasLendasAPI.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IlhadasLendasAPI.Infrastructure.Configurations.Base
{
    public class ConfigurationUploadFormBase<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : UploadIFormFileBase
    {
        protected string tableName;

        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.ToTable(tableName);

            builder.HasKey(x => x.Id);

            builder.Property(p => p.Status)
                   .IsRequired()
                   .HasMaxLength(50)
                   .HasColumnName("Status")
                   .HasColumnType("varchar(50)")
                   .HasDefaultValue(1);

            builder.Property(x => x.NomeArquivoBanco)
                   .HasColumnName("NomeArquivoBanco")
                   .HasMaxLength(50)
                   .HasDefaultValueSql("NEWID()");

            builder.Property(p => p.TamanhoEmBytes)
                   .HasMaxLength(100)
                   .HasColumnName("TamanhoEmBytes")
                   .HasColumnType("varchar(100)");

            builder.Property(p => p.ContentType)
                   .HasMaxLength(100)
                   .HasColumnName("ContentType")
                   .HasColumnType("varchar(100)");

            builder.Property(p => p.ExtensaoArquivo)
                   .HasMaxLength(100)
                   .HasColumnName("ExtensaoArquivo")
                   .HasColumnType("varchar(100)");

            builder.Property(p => p.NomeArquivoOriginal)
                   .HasMaxLength(300)
                   .HasColumnName("NomeArquivoOriginal")
                   .HasColumnType("varchar(300)");

            builder.Property(p => p.CaminhoRelativo)
                   .HasMaxLength(300)
                   .HasColumnName("CaminhoRelativo")
                   .HasColumnType("varchar(300)");

            builder.Property(p => p.CaminhoAbsoluto)
                   .HasMaxLength(300)
                   .HasColumnName("CaminhoAbsoluto")
                   .HasColumnType("varchar(300)");

            builder.Property(p => p.CaminhoFisico)
                   .HasMaxLength(300)
                   .HasColumnName("CaminhoFisico")
                   .HasColumnType("varchar(300)");
        }
    }
}