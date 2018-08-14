using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUINFDOMINIO;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUINFDAO.DOMINIOMAP
{
    public class TelefoneMap : IEntityTypeConfiguration<Telefone>
    {
        public void Configure(EntityTypeBuilder<Telefone> builder)
        {
            builder.HasKey(t => t.id);
            builder.Property(t => t.ddd).HasColumnName("DDD_TEL_PESSOA").HasMaxLength(5).IsRequired();
            builder.Property(t => t.numeros).HasColumnName("DDD_FONE_PESSOA").HasMaxLength(30).IsRequired();
            builder.HasOne(t => t.Pessoa).WithMany(p => p.telefones);
            builder.ToTable("TB_TELEFONE", "BD_Nuinf_Context");
        }
    }
}
