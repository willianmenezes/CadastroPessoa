using Library;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repository.EntityConfig
{
    public class PessoaEntityConfig : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable("pessoa");

            builder.HasKey(x => x.PessoaId);

            builder.Property(x => x.PessoaId)
                    .HasColumnName("pessoaid")
                    .ValueGeneratedOnAdd();

            builder.Property(x => x.Nome)
                    .HasColumnName("nome")
                    .IsUnicode(false)
                    .HasMaxLength(200)
                    .IsRequired();

            builder.Property(x => x.DataNascimento)
                    .HasColumnName("datanascimento")
                    .IsRequired();
        }
    }
}
