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
    /// Interaction logic for rVehiculos.xaml
    /// </summary>
    public partial class rVehiculos : Window
    {
        private Usos uso = new Usos();
        private Vehiculos vehiculo = new Vehiculos();

        public rVehiculos()
        {
            InitializeComponent();
            this.DataContext = vehiculo;

            UsoComboBox.ItemsSource = UsosBLL.GetUsos();
            UsoComboBox.SelectedValuePath = "UsoId";
            UsoComboBox.DisplayMemberPath = "Descripcion";
        }

        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = uso;
        }

        private void Limpiar()
        {
            this.vehiculo = new Vehiculos();
            this.DataContext = vehiculo;
        }


        private void BuscarIDButton_Click(object sender, RoutedEventArgs e)
        {
           cBusquedaDeVehiculos cVehiculo = new cBusquedaDeVehiculos();
            cVehiculo.ShowDialog();

            if (Utilidades.ClienteSelect == true)
            {
                var Tipo = VehiculosBLL.Buscar(Utilidades.vehiculoAux.VehiculoId);
                this.vehiculo = Tipo;
                this.DataContext = vehiculo;

            }
        }

        private bool Validar()
        {
            bool esValido = true;

            if (MarcaTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Falta la marca", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                MarcaTextBox.Focus();
            }

            if (ModeloTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Falta el modelo", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                ModeloTextBox.Focus();
            }

            if (TipoTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Falta el tipo", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                TipoTextBox.Focus();
            }

            if (YearTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Falta el año", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                YearTextBox.Focus();
            }

            if (ColorTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Falta el color", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                ColorTextBox.Focus();
            }

            if (MatriculaTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Falta el modelo", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                MatriculaTextBox.Focus();
            }

            if (PasajerosTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Falta el numero de pasajeros", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                PasajerosTextBox.Focus();
            }

            if (PrecioTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Falta el precio", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                PrecioTextBox.Focus();
            }

            if (ChasisTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Falta el chasis", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                ChasisTextBox.Focus();
            }


            if (CilindrosTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Falta el numero de cilindros", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                CilindrosTextBox.Focus();
            }

            if (UsoComboBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Falta el Uso", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                UsoComboBox.Focus();
            }

            if (ClienteTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Falta el propietario", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                ClienteTextBox.Focus();
            }

            return esValido;
        }


        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            var paso = VehiculosBLL.Guardar(vehiculo);

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

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (VehiculosBLL.Eliminar(Utilidades.ToInt(IdTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Registro eliminado!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No fue posible eliminar", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void BuscarClienteButton_Click(object sender, RoutedEventArgs e)
        {
            cBusquedaDeCliente cCliente = new cBusquedaDeCliente();
            cCliente.ShowDialog();

            if (Utilidades.ClienteSelect == true)
            {
                var Tipo = ClientesBLL.Buscar(Utilidades.clienteAux.ClienteId);
                ClienteTextBox.Text = Tipo.Nombre;
                vehiculo.Propietario = Tipo.Nombre;
                vehiculo.ClienteId = Tipo.ClienteId;
            }
        }
    }
}
