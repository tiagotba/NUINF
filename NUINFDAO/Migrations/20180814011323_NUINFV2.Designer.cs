﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NUINFDAO.CONTEXTOS;

namespace NUINFDAO.Migrations
{
    [DbContext(typeof(BD_Nuinf_Context))]
    [Migration("20180814011323_NUINFV2")]
    partial class NUINFV2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NUINFDOMINIO.Pessoa", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("cpf")
                        .IsRequired()
                        .HasColumnName("CPF_PESSOA");

                    b.Property<DateTime>("dataNascimento")
                        .HasColumnName("DT_NASCIMENTO");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnName("EMAIL_PESSOA")
                        .HasMaxLength(100);

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnName("NOM_PESSOA")
                        .HasMaxLength(500);

                    b.HasKey("id");

                    b.ToTable("TB_PESSOA","BD_Nuinf_Context");
                });

            modelBuilder.Entity("NUINFDOMINIO.Telefone", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("Pessoaid");

                    b.Property<string>("ddd")
                        .IsRequired()
                        .HasColumnName("DDD_TEL_PESSOA")
                        .HasMaxLength(5);

                    b.Property<string>("numeros")
                        .IsRequired()
                        .HasColumnName("DDD_FONE_PESSOA")
                        .HasMaxLength(30);

                    b.HasKey("id");

                    b.HasIndex("Pessoaid");

                    b.ToTable("TB_TELEFONE","BD_Nuinf_Context");
                });

            modelBuilder.Entity("NUINFDOMINIO.Telefone", b =>
                {
                    b.HasOne("NUINFDOMINIO.Pessoa", "Pessoa")
                        .WithMany("telefones")
                        .HasForeignKey("Pessoaid");
                });
#pragma warning restore 612, 618
        }
    }
}
