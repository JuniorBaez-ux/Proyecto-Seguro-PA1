using Microsoft.EntityFrameworkCore;
using Proyecto_Seguro_PA1.DAL;
using Proyecto_Seguro_PA1.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Seguro_PA1.BLL
{
    public class ReclamosBLL
    {
        public static bool Guardar(Reclamos reclamo)
        {
            if (!Existe(reclamo.ReclamoId))
            {
                return Insertar(reclamo);
            }
            else
            {
                return Modificar(reclamo);
            }
        }

        private static bool Insertar(Reclamos reclamo)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Reclamos.Add(reclamo);
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

        public static bool Modificar(Reclamos reclamo)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(reclamo).State = EntityState.Modified;
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
                var reclamo = contexto.Reclamos.Find(id);

                if (reclamo != null)
                {
                    contexto.Reclamos.Remove(reclamo);
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

        /*public static Reclamos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Reclamos Reclamos;

            try
            {
                Reclamos = contexto.Reclamos.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return Reclamos;
        }*/


        public static Reclamos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Reclamos reclamo;

            try
            {
                reclamo = contexto.Reclamos.Find(id);

                if (reclamo.Activo == false)
                {
                    return null;
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

            return reclamo;
        }

        public static List<Reclamos> GetList(Expression<Func<Reclamos, bool>> criterio)
        {
            List<Reclamos> lista = new List<Reclamos>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Reclamos.Where(criterio).Where(c => c.Activo == true).ToList();
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
                encontrado = contexto.Reclamos.Any(t => t.ReclamoId == id);
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

        public static List<Reclamos> GetReclamos()
        {
            List<Reclamos> lista = new List<Reclamos>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Reclamos.Where(c => c.Activo == true).ToList();
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

        public static bool Desactivar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var reclamo = contexto.Reclamos.Find(id);

                if (reclamo != null)
                {
                    reclamo.Activo = false;
                    Modificar(reclamo);
                    paso = reclamo.Activo == false;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
    }
}
