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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Proyecto_Seguro_PA1.UI.Registros;
using Proyecto_Seguro_PA1.UI.Consultas;
using Proyecto_Seguro_PA1.BLL;

namespace Proyecto_Seguro_PA1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }

        private void Registro_Click(object sender, RoutedEventArgs e)
        {
            rClientes rClientes = new rClientes();
            rClientes.Show();
        }

        private void Consultas_Click(object sender, RoutedEventArgs e)
        {
            cClientes cClientes = new cClientes();
            cClientes.Show(); 
        }

        private void Registro_vehiculos_Click(object sender, RoutedEventArgs e)
        {
            rVehiculos rVehiculos = new rVehiculos();
            rVehiculos.Show();
        }

        private void Consulta_vehiculos_Click(object sender, RoutedEventArgs e)
        {
            cVehiculos cVehiculos = new cVehiculos();
            cVehiculos.Show();
        }

        private void Registro_Seguros_Click(object sender, RoutedEventArgs e)
        {
            rSeguros rSeguros = new rSeguros();
            rSeguros.Show();
        }

        private void Consulta_Seguros_Click(object sender, RoutedEventArgs e)
        {
            cSeguros cSeguros = new cSeguros();
            cSeguros.Show();
        }

        private void Registro_Reclamos_Click(object sender, RoutedEventArgs e)
        {
            rReclamos rReclamos = new rReclamos();
            rReclamos.Show();
        }

        private void Consulta_Reclamos_Click(object sender, RoutedEventArgs e)
        {
            cReclamos cReclamos = new cReclamos();
            cReclamos.Show();
        }

        private void Registro_Pagos_Click(object sender, RoutedEventArgs e)
        {
            rPagos rPagos = new rPagos();
            rPagos.Show();
        }

        //inicio del listView
        private void ListViewMenu_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (ListViewMenu.SelectedIndex == -1) { return; }

            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "HacerPago":
                    rPagos rPagos = new rPagos();
                    rPagos.Show();
                    ListViewMenu.SelectedIndex = -1;
                    break;
                case "RegistrarSeguro":
                    rSeguros rSeguros = new rSeguros();
                    rSeguros.Show();
                    ListViewMenu.SelectedIndex = -1;
                    break;
                case "HacerReclamos":
                    rReclamos rReclamos = new rReclamos();
                    rReclamos.Show();
                    ListViewMenu.SelectedIndex = -1;
                    break;
                case "RegistrarCliente":
                    rClientes rClientes = new rClientes();
                    rClientes.Show();
                    ListViewMenu.SelectedIndex = -1;
                    break;
                case "RegistrarVehiculo":
                    rVehiculos rVehiculos = new rVehiculos();
                    rVehiculos.Show();
                    ListViewMenu.SelectedIndex = -1;
                    break;
            }
        }
    }
}
