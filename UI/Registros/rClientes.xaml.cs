using Proyecto_Seguro_PA1.BLL;
using Proyecto_Seguro_PA1.Entidades;
using Proyecto_Seguro_PA1.UI.Consultas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Proyecto_Seguro_PA1.UI.Registros
{
    /// <summary>
    /// Interaction logic for rClientes.xaml
    /// </summary>
    public partial class rClientes : Window
    {
        private Clientes cliente = new Clientes();
        public rClientes()
        {
            InitializeComponent();
            this.DataContext = cliente;
            
        }
        private void Limpiar()
        {
            this.cliente = new Clientes();
            this.DataContext = cliente;
        }

        private bool Validar()
        {
            bool esValido = true;

            if (NombreTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Falta el Nombre", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                NombreTextBox.Focus();
            }

            if (DireccionTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Falta la Direccion", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (TelefonoTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Falta el Telefono", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if (EmailTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Falta el Email", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            bool IsValidEmail(string email)
            {
                try
                {
                    var addr = new MailAddress(email);
                    return addr.Address == email;
                }
                catch
                {
                    return false;
                }
            }

            if (EmailTextBox.Text.Length != 0)
            {
                if (IsValidEmail(EmailTextBox.Text) == true)
                {
                    esValido = true;
                }
                else
                {
                    esValido = false;
                    MessageBox.Show("Debe ingresar un campo Email valido", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    EmailTextBox.Focus();
                }
            } 

            if (IdentificacionTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Falta la Identificacion", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if (ClientesBLL.ExisteIdentificacion(IdentificacionTextBox.Text) == true)
            {
                if (ClientesBLL.Existe(Utilidades.ToInt(IdTextBox.Text)) == true)
                {
                    return true;
                }
                esValido = false;

                MessageBox.Show("Ya existe un Cliente con esta Identificacion!", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                IdentificacionTextBox.Focus();
            }
            if (ClientesBLL.ExisteTelefono(TelefonoTextBox.Text) == true)
            {
                if (ClientesBLL.Existe(Utilidades.ToInt(IdTextBox.Text)) == true)
                {
                    return true;
                }
                esValido = false;

                MessageBox.Show("Ya existe un Cliente con este Telefono!", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                TelefonoTextBox.Focus();
            }

            return esValido;
        }
        private void BuscarIDButton_Click(object sender, RoutedEventArgs e)
        {
            cBusquedaDeCliente cCliente = new cBusquedaDeCliente();
            cCliente.ShowDialog();

            if (Utilidades.ClienteSelect == true)
            {
                var Tipo = ClientesBLL.Buscar(Utilidades.clienteAux.ClienteId);
                this.cliente = Tipo;
                this.DataContext = cliente;

            }
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            var paso = ClientesBLL.Guardar(cliente);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Transaccione exitosa!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Transaccion Fallida", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (ClientesBLL.Desactivar(Utilidades.ToInt(IdTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Registro eliminado!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No fue posible eliminar", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
