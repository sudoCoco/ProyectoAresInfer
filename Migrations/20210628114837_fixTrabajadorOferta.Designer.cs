﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProyectoAresInfer;

namespace ProyectoAresInfer.Migrations
{
    [DbContext(typeof(AgenciaColocacionContext))]
    [Migration("20210628114837_fixTrabajadorOferta")]
    partial class fixTrabajadorOferta
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.7");

            modelBuilder.Entity("ProyectoAresInfer.Agencia", b =>
                {
                    b.Property<int>("AgenciaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CodigoAgencia")
                        .HasMaxLength(10)
                        .HasColumnType("INTEGER");

                    b.HasKey("AgenciaId");

                    b.ToTable("Agencias");
                });

            modelBuilder.Entity("ProyectoAresInfer.Colocacion", b =>
                {
                    b.Property<int>("ColocacionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("FechaColocacion")
                        .HasColumnType("DATE");

                    b.Property<int>("OfertaTrabajadorId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TipoContrato")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("TEXT");

                    b.HasKey("ColocacionId");

                    b.HasIndex("OfertaTrabajadorId")
                        .IsUnique();

                    b.ToTable("Colocaciones");
                });

            modelBuilder.Entity("ProyectoAresInfer.Empresa", b =>
                {
                    b.Property<int>("EmpresaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CifEmpresa")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("TEXT");

                    b.Property<string>("RazonSocial")
                        .IsRequired()
                        .HasMaxLength(55)
                        .HasColumnType("TEXT");

                    b.HasKey("EmpresaId");

                    b.ToTable("Empresas");
                });

            modelBuilder.Entity("ProyectoAresInfer.Oferta", b =>
                {
                    b.Property<int>("OfertaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasColumnType("varchar");

                    b.Property<int>("EmpresaId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("FechaOferta")
                        .HasColumnType("DATE");

                    b.Property<int>("Puesto")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.HasKey("OfertaId");

                    b.HasIndex("EmpresaId");

                    b.ToTable("Ofertas");
                });

            modelBuilder.Entity("ProyectoAresInfer.OfertaTrabajador", b =>
                {
                    b.Property<int>("OfertaTrabajadorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("FechaOfertaEnviada")
                        .HasColumnType("DATE");

                    b.Property<int>("OfertaId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TrabajadorId")
                        .HasColumnType("INTEGER");

                    b.HasKey("OfertaTrabajadorId");

                    b.HasIndex("OfertaId");

                    b.HasIndex("TrabajadorId");

                    b.ToTable("OfertaTrabajadores");
                });

            modelBuilder.Entity("ProyectoAresInfer.Trabajador", b =>
                {
                    b.Property<int>("TrabajadorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Apellido1")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("Apellido2")
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<char>("Discapacidad")
                        .HasColumnType("TEXT");

                    b.Property<string>("Dni")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasMaxLength(8)
                        .HasColumnType("DATE");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("DATE");

                    b.Property<char>("Inmigrante")
                        .HasColumnType("TEXT");

                    b.Property<string>("NivelFormativo")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("TEXT");

                    b.Property<char>("Prestacion")
                        .HasColumnType("TEXT");

                    b.Property<char>("Sexo")
                        .HasColumnType("TEXT");

                    b.HasKey("TrabajadorId");

                    b.ToTable("Trabajadores");
                });

            modelBuilder.Entity("ProyectoAresInfer.Colocacion", b =>
                {
                    b.HasOne("ProyectoAresInfer.OfertaTrabajador", "OfertaTrabajador")
                        .WithOne("Colocacion")
                        .HasForeignKey("ProyectoAresInfer.Colocacion", "OfertaTrabajadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OfertaTrabajador");
                });

            modelBuilder.Entity("ProyectoAresInfer.Oferta", b =>
                {
                    b.HasOne("ProyectoAresInfer.Empresa", "Empresa")
                        .WithMany("Ofertas")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("ProyectoAresInfer.OfertaTrabajador", b =>
                {
                    b.HasOne("ProyectoAresInfer.Oferta", "Oferta")
                        .WithMany("OfertaTrabajadores")
                        .HasForeignKey("OfertaId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.HasOne("ProyectoAresInfer.Trabajador", "Trabajador")
                        .WithMany("OfertaTrabajadores")
                        .HasForeignKey("TrabajadorId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("Oferta");

                    b.Navigation("Trabajador");
                });

            modelBuilder.Entity("ProyectoAresInfer.Empresa", b =>
                {
                    b.Navigation("Ofertas");
                });

            modelBuilder.Entity("ProyectoAresInfer.Oferta", b =>
                {
                    b.Navigation("OfertaTrabajadores");
                });

            modelBuilder.Entity("ProyectoAresInfer.OfertaTrabajador", b =>
                {
                    b.Navigation("Colocacion");
                });

            modelBuilder.Entity("ProyectoAresInfer.Trabajador", b =>
                {
                    b.Navigation("OfertaTrabajadores");
                });
#pragma warning restore 612, 618
        }
    }
}
