using Library;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repository.EntityConfig
{
    public class TelefoneEntityConfig : IEntityTypeConfiguration<Telefone>
    {
        public void Configure(EntityTypeBuilder<Telefone> builder)
        {
            builder.ToTable("telefone");

            builder.HasKey(x => x.TelefoneId);

            builder.Property(x => x.TelefoneId)
                    .HasColumnName("telefoneid")
                    .ValueGeneratedOnAdd();

            builder.Property(x => x.PessoaId)
                    .HasColumnName("pessoaid")
                    .IsRequired();

            builder.Property(x => x.Numero)
                    .HasColumnName("numero")
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .IsRequired();

            builder.HasOne(x => x.Pessoa)
                    .WithMany(x => x.Telefone)
                    .HasForeignKey(x => x.PessoaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("telefone_pessoaid_fkey");
        }
    }
}
