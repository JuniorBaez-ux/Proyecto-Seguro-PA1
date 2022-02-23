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
    public class PagosBLL
    {
        public static bool Guardar(Pagos pago)
        {
            if (!Existe(pago.PagoId))
            {
                return Insertar(pago);
            }
            else
            {
                return Modificar(pago);
            }
        }

        private static bool Insertar(Pagos pago)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Pagos.Add(pago);
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

        public static bool Modificar(Pagos pago)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(pago).State = EntityState.Modified;
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
                var pago = contexto.Pagos.Find(id);

                if (pago != null)
                {
                    contexto.Pagos.Remove(pago);
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

        public static Pagos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Pagos Pagos;

            try
            {
                Pagos = contexto.Pagos.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return Pagos;
        }


        /*public static Pagos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Pagos pago;

            try
            {
                pago = contexto.Pagos.Find(id);

                if (pago.Activo == false)
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

            return pago;
        }*/

        public static List<Pagos> GetList(Expression<Func<Pagos, bool>> criterio)
        {
            List<Pagos> lista = new List<Pagos>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Pagos.Where(criterio).ToList();
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
                encontrado = contexto.Pagos.Any(t => t.PagoId == id);
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

        public static List<Pagos> GetPagos()
        {
            List<Pagos> lista = new List<Pagos>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Pagos.ToList();
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

        /*public static bool Desactivar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var pago = contexto.Pagos.Find(id);

                if (pago != null)
                {
                    pago.Activo = false;
                    Modificar(pago);
                    paso = pago.Activo == false;
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
        }*/
    }
}
