﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proyecto_Seguro_PA1.DAL;
using Proyecto_Seguro_PA1.Entidades;

namespace Proyecto_Seguro_PA1.BLL
{
    public class VehiculosBLL
    {
        public static bool Guardar(Vehiculos vehiculo)
        {
            if (!Existe(vehiculo.VehiculoId))
            {
                return Insertar(vehiculo);
            }
            else
            {
                return Modificar(vehiculo);
            }
        }

        private static bool Insertar(Vehiculos vehiculo)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Vehiculos.Add(vehiculo);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static bool Modificar(Vehiculos vehiculo)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(vehiculo).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var vehiculo = contexto.Vehiculos.Find(id);

                if (vehiculo != null)
                {
                    contexto.Vehiculos.Remove(vehiculo);
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static Vehiculos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Vehiculos vehiculos;

            try
            {
                vehiculos = contexto.Vehiculos.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return vehiculos;
        }

        public static List<Vehiculos> GetList(Expression<Func<Vehiculos, bool>> criterio)
        {
            List<Vehiculos> lista = new List<Vehiculos>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Vehiculos.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;
            try
            {
                encontrado = contexto.Vehiculos.Any(t => t.VehiculoId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado;
        }


        public static List<Vehiculos> GetVehiculos()
        {
            List<Vehiculos> lista = new List<Vehiculos>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Vehiculos.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }
    }
}
