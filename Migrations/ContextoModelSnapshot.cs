﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proyecto_Seguro_PA1.DAL;

namespace Proyecto_Seguro_PA1.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("Proyecto_Seguro_PA1.Entidades.Clientes", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Activo")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("TEXT");

                    b.Property<string>("Identificacion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ClienteId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Proyecto_Seguro_PA1.Entidades.Reclamos", b =>
                {
                    b.Property<int>("ReclamoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Activo")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Alegaciones")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ClienteId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("TEXT");

                    b.Property<string>("Identificacion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Motivos")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Prestaciones")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ReclamoId");

                    b.HasIndex("ClienteId");

                    b.ToTable("Reclamos");
                });

            modelBuilder.Entity("Proyecto_Seguro_PA1.Entidades.Seguros", b =>
                {
                    b.Property<int>("SeguroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Activo")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Anio")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ClienteId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("TEXT");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Matricula")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NCF")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("VehiculoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("SeguroId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("VehiculoId");

                    b.ToTable("Seguros");
                });

            modelBuilder.Entity("Proyecto_Seguro_PA1.Entidades.Usos", b =>
                {
                    b.Property<int>("UsoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("UsoId");

                    b.ToTable("Usos");

                    b.HasData(
                        new
                        {
                            UsoId = 1,
                            Descripcion = "Privado"
                        },
                        new
                        {
                            UsoId = 2,
                            Descripcion = "Publico"
                        });
                });

            modelBuilder.Entity("Proyecto_Seguro_PA1.Entidades.Vehiculos", b =>
                {
                    b.Property<int>("VehiculoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Activo")
                        .HasColumnType("INTEGER");

                    b.Property<int>("AnioVehiculo")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CantidadPasajeros")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Chasis")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Cilindros")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClienteId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("TEXT");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Matricula")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Precio")
                        .HasColumnType("REAL");

                    b.Property<string>("Propietario")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TipoVehiculo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("UsoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("VehiculoId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("UsoId");

                    b.ToTable("Vehiculos");
                });

            modelBuilder.Entity("Proyecto_Seguro_PA1.Entidades.Reclamos", b =>
                {
                    b.HasOne("Proyecto_Seguro_PA1.Entidades.Clientes", "ClientesReclamo")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClientesReclamo");
                });

            modelBuilder.Entity("Proyecto_Seguro_PA1.Entidades.Seguros", b =>
                {
                    b.HasOne("Proyecto_Seguro_PA1.Entidades.Clientes", "ClientesSeguro")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proyecto_Seguro_PA1.Entidades.Vehiculos", "VehiculosSeguro")
                        .WithMany()
                        .HasForeignKey("VehiculoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClientesSeguro");

                    b.Navigation("VehiculosSeguro");
                });

            modelBuilder.Entity("Proyecto_Seguro_PA1.Entidades.Vehiculos", b =>
                {
                    b.HasOne("Proyecto_Seguro_PA1.Entidades.Clientes", "Clientes")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proyecto_Seguro_PA1.Entidades.Usos", "Usos")
                        .WithMany()
                        .HasForeignKey("UsoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clientes");

                    b.Navigation("Usos");
                });
#pragma warning restore 612, 618
        }
    }
}
