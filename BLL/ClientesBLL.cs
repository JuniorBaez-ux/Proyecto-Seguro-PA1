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
    public class ClientesBLL
    {
        public static bool Guardar(Clientes cliente)
        {
            if (!Existe(cliente.ClienteId))
            {
                return Insertar(cliente);
            }
            else
            {
                return Modificar(cliente);
            }
        }

        private static bool Insertar(Clientes cliente)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Clientes.Add(cliente);
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

        public static bool Modificar(Clientes cliente)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(cliente).State = EntityState.Modified;
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
                var cliente = contexto.Clientes.Find(id);

                if (cliente != null)
                {
                    contexto.Clientes.Remove(cliente);
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

        /*public static Clientes Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Clientes clientes;

            try
            {
                clientes = contexto.Clientes.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return clientes;
        }*/


        public static Clientes Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Clientes cliente;

            try
            {
                cliente = contexto.Clientes.Find(id);

                if (cliente.Activo == false)
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

            return cliente;
        }

        public static List<Clientes> GetList(Expression<Func<Clientes, bool>> criterio)
        {
            List<Clientes> lista = new List<Clientes>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Clientes.Where(criterio).Where(c => c.Activo == true).ToList();
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
                encontrado = contexto.Clientes.Any(t => t.ClienteId == id);
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

        public static bool ExisteIdentificacion(string identificacion)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;
            try
            {
                encontrado = contexto.Clientes.Any(r => r.Identificacion == identificacion);
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

        public static bool ExisteTelefono(string telefono)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;
            try
            {
                encontrado = contexto.Clientes.Any(r => r.Telefono == telefono);
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

        public static List<Clientes> GetClientes()
        {
            List<Clientes> lista = new List<Clientes>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Clientes.Where(c => c.Activo == true).ToList();
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
                var cliente = contexto.Clientes.Find(id);

                if (cliente != null)
                {

                    List<Vehiculos> listaVehiculos = VehiculosBLL.GetVehiculos();

                    foreach (var vehiculoBuscado in listaVehiculos)
                    {
                        var clienteBuscado = ClientesBLL.Buscar(vehiculoBuscado.ClienteId);

                        if(clienteBuscado.ClienteId == cliente.ClienteId)
                        {
                            vehiculoBuscado.Activo = false;
                            VehiculosBLL.Modificar(vehiculoBuscado);
                        }
                        
                    }

                    List<Reclamos> listaReclamos = ReclamosBLL.GetReclamos();

                    foreach (var reclamoBuscado in listaReclamos)
                    {
                        var clienteBuscado = ClientesBLL.Buscar(reclamoBuscado.ClienteId);

                        if (clienteBuscado.ClienteId == cliente.ClienteId)
                        {
                            reclamoBuscado.Activo = false;
                            ReclamosBLL.Modificar(reclamoBuscado);
                        }

                    }

                    List<Seguros> listaSeguros = SegurosBLL.GetSeguros();

                    foreach (var seguroBuscado in listaSeguros)
                    {
                        var clienteBuscado = ClientesBLL.Buscar(seguroBuscado.ClienteId);

                        if (clienteBuscado.ClienteId == cliente.ClienteId)
                        {
                            seguroBuscado.Activo = false;
                            SegurosBLL.Modificar(seguroBuscado);
                        }

                    }

                    cliente.Activo = false;
                    Modificar(cliente);
                    paso = cliente.Activo == false;
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
