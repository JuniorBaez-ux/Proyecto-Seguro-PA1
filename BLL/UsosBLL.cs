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
    public class UsosBLL
    {
        public static Usos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Usos Usos;

            try
            {
                Usos = contexto.Usos.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return Usos;
        }

        public static List<Usos> GetUsos()
        {
            List<Usos> lista = new List<Usos>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Usos.ToList();
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

        public static List<Usos> GetList(Expression<Func<Usos, bool>> criterio)
        {
            List<Usos> lista = new List<Usos>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Usos.Where(criterio).ToList();
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
