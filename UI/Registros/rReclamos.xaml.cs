using Proyecto_Seguro_PA1.BLL;
using Proyecto_Seguro_PA1.Entidades;
using Proyecto_Seguro_PA1.UI.Consultas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Interaction logic for rReclamos.xaml
    /// </summary>
    public partial class rReclamos : Window
    {
        private Reclamos reclamo = new Reclamos();
        public rReclamos()
        {
            InitializeComponent();
            this.DataContext = reclamo;
        }

        private void Limpiar()
        {
            this.reclamo = new Reclamos();
            this.DataContext = reclamo;
        }

        private bool Validar()
        {
            bool esValido = true;

            if (NombreTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Falta el Cliente", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                BuscarCliente.Focus();
            }

            if (MotivosReclamacionTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Falta el Motivo de la reclamación", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                MotivosReclamacionTextBox.Focus();
            }

            if (PretensionesClienteTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Falta la Pretension del solicitante", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                PretensionesClienteTextBox.Focus();
            }

            if (AlegacionesEmpresaTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Falta la Alegación de la empresa", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                AlegacionesEmpresaTextBox.Focus();
            }

            return esValido;
        }

        private void BuscarIDButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            var paso = ReclamosBLL.Guardar(reclamo);

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
            if (ReclamosBLL.Desactivar(Utilidades.ToInt(IdTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Registro eliminado!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No fue posible eliminar", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void BuscarCliente_Click(object sender, RoutedEventArgs e)
        {
            cBusquedaDeCliente cCliente = new cBusquedaDeCliente();
            cCliente.ShowDialog();

            if (Utilidades.ClienteSelect == true)
            {
                var Tipo = ClientesBLL.Buscar(Utilidades.clienteAux.ClienteId);
                reclamo.ClienteId = Tipo.ClienteId;
                NombreTextBox.Text = Tipo.Nombre;
                IdentificacionTextBox.Text = Tipo.Identificacion;
                TelefonoTextBox.Text = Tipo.Telefono;
                DireccionTextBox.Text = Tipo.Direccion;
            }
        }
    }
}
