using Proyecto_Seguro_PA1.BLL;
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
    /// Interaction logic for rPagos.xaml
    /// </summary>
    public partial class rPagos : Window
    {
        public rPagos()
        {
            InitializeComponent();
        }

        private void RegistrarPagoButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BuscarIDButton_Click(object sender, RoutedEventArgs e)
        {
            cBusquedaDeSeguro cSegruo = new cBusquedaDeSeguro();
            cSegruo.ShowDialog();

            if (Utilidades.ClienteSelect == true)
            {
                var Tipo = SegurosBLL.Buscar(Utilidades.SeguroAux.SeguroId);
                var seguro = Tipo;
                this.DataContext = seguro;
                seguro.ClienteId = Tipo.ClienteId;
                seguro.VehiculoId = Tipo.VehiculoId;

                var cliente = ClientesBLL.Buscar(seguro.ClienteId);
                var vehiculo = VehiculosBLL.Buscar(seguro.VehiculoId);


                NombreTextBox.Text = cliente.Nombre;
                TelefonoTextBox.Text = cliente.Telefono;
                DireccionTextBox.Text = cliente.Direccion;
                IdentificacionTextBox.Text = cliente.Identificacion;

                ColorTextBox.Text = vehiculo.Color;
                MatriculaTextBox.Text = vehiculo.Matricula;
                PrecioTextBox.Text = vehiculo.Precio.ToString();
                ChasisTextBox.Text = vehiculo.Chasis;

            }
        }
    }
}
