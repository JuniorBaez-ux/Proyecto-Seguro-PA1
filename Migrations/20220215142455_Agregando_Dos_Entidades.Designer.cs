﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proyecto_Seguro_PA1.DAL;

namespace Proyecto_Seguro_PA1.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20220215142455_Agregando_Dos_Entidades")]
    partial class Agregando_Dos_Entidades
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("Proyecto_Seguro_PA1.Entidades.Clientes", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
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

            modelBuilder.Entity("Proyecto_Seguro_PA1.Entidades.Seguros", b =>
                {
                    b.Property<int>("SeguroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cliente")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Identificacion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NCF")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("SCantidadPasajeros")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SChasis")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("SCilindros")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SColor")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SMatricula")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("SPrecio")
                        .HasColumnType("REAL");

                    b.Property<string>("SUsoVehiculo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Vehiculo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("SeguroId");

                    b.ToTable("Seguros");
                });

            modelBuilder.Entity("Proyecto_Seguro_PA1.Entidades.Vehiculos", b =>
                {
                    b.Property<int>("VehiculoId")
                        .ValueGeneratedOnAdd()
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

                    b.Property<string>("Color")
                        .IsRequired()
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

                    b.Property<string>("UsoVehiculo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("VehiculoId");

                    b.ToTable("Vehiculos");
                });
#pragma warning restore 612, 618
        }
    }
}