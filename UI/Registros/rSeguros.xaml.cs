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
    /// Interaction logic for rSeguros.xaml
    /// </summary>
    public partial class rSeguros : Window
    {
        private Seguros seguro = new Seguros();
        public rSeguros()
        {
            InitializeComponent();
            this.DataContext = seguro;
            NCFTextBox.Text = seguro.NCF;
        }

        private void Limpiar()
        {
            this.seguro = new Seguros();
            this.DataContext = seguro;
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
            /* if (!Validar())
                 return;*/

            var paso = SegurosBLL.Guardar(seguro);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Transaccion exitosa!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Transaccion Fallida", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (SegurosBLL.Eliminar(Utilidades.ToInt(IdTextBox.Text)))
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
                seguro.ClienteId = Tipo.ClienteId;
                NombreTextBox.Text = Tipo.Nombre;
                IdentificacionTextBox.Text = Tipo.Identificacion;
                DireccionTextBox.Text = Tipo.Direccion;
                TelefonoTextBox.Text = Tipo.Telefono;

            }
        }

        private void BuscarVehiculoButton_Click(object sender, RoutedEventArgs e)
        {
            cBusquedaDeVehiculos cVehiculos = new cBusquedaDeVehiculos();
            cVehiculos.ShowDialog();

          /*  Utilidades.ClienteSelect = false;*/

            if (Utilidades.ClienteSelect == true)
            {
                var Tipo = VehiculosBLL.Buscar(Utilidades.vehiculoAux.VehiculoId);
                seguro.VehiculoId = Tipo.VehiculoId;
                ColorTextBox.Text = Tipo.Color;
                MatriculaTextBox.Text = Tipo.Matricula;
                PasajerosTextBox.Text = Tipo.CantidadPasajeros.ToString();
                ChasisTextBox.Text = Tipo.Chasis;
                CilindrosTextBox.Text = Tipo.Cilindros.ToString();
                PrecioTextBox.Text = Tipo.Precio.ToString();
                TipoUsoTextBox.Text = UsosBLL.Buscar(Tipo.UsoId).Descripcion;
            }
        }
    }
}
