using System;
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
    public class SegurosBLL
    {
        public static bool Guardar(Seguros seguro)
        {
            if (!Existe(seguro.SeguroId))
            {
                return Insertar(seguro);
            }
            else
            {
                return Modificar(seguro);
            }
        }

        private static bool Insertar(Seguros seguro)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Seguros.Add(seguro);
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

        public static bool Modificar(Seguros seguro)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(seguro).State = EntityState.Modified;
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
                var seguro = contexto.Seguros.Find(id);

                if (seguro != null)
                {
                    contexto.Seguros.Remove(seguro);
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

        /*public static Seguros Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Seguros Seguros;

            try
            {
                Seguros = contexto.Seguros.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return Seguros;
        }*/

        public static Seguros Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Seguros seguro;

            try
            {
                seguro = contexto.Seguros.Find(id);

                if (seguro.Activo == false)
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

            return seguro;
        }

        public static List<Seguros> GetList(Expression<Func<Seguros, bool>> criterio)
        {
            List<Seguros> lista = new List<Seguros>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Seguros.Where(criterio).Where(c => c.Activo == true).ToList();
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
                encontrado = contexto.Seguros.Any(t => t.SeguroId == id);
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


        public static List<Seguros> GetSeguros()
        {
            List<Seguros> lista = new List<Seguros>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Seguros.Where(c => c.Activo == true).ToList();
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
                var seguro = contexto.Seguros.Find(id);

                if (seguro != null)
                {
                    seguro.Activo = false;
                    Modificar(seguro);
                    paso = seguro.Activo == false;
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
