
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUINFDOMINIO;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUINFDAO.DOMINIOMAP
{
    public class PessoaMap : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.HasKey(p=>p.id);
            builder.Property(p => p.nome).HasColumnName("NOM_PESSOA").HasMaxLength(500).IsRequired();
            builder.Property(p => p.dataNascimento).HasColumnName("DT_NASCIMENTO").HasColumnType("Date").IsRequired();
            builder.Property(p => p.cpf).HasColumnName("CPF_PESSOA").IsRequired();
            builder.Property(p => p.email).HasColumnName("EMAIL_PESSOA").HasMaxLength(100);
            builder.HasMany(p => p.telefones);
            builder.ToTable("TB_PESSOA", "BD_Nuinf");

        }
    }
}
