using Microsoft.EntityFrameworkCore;
using Proyecto_Seguro_PA1.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Seguro_PA1.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Vehiculos> Vehiculos { get; set; }
        public DbSet<Seguros> Seguros { get; set; }
        public DbSet<Usos> Usos { get; set; }
        public DbSet<Reclamos> Reclamos { get; set; }
        public DbSet<Pagos> Pagos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = DATA\DataBase.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usos>().HasData(new Usos
            {
                UsoId = 1,
                Descripcion = "Privado"
            });

            modelBuilder.Entity<Usos>().HasData(new Usos
            {
                UsoId = 2,
                Descripcion = "Publico"
            });
        }
    }
}
