using Proyecto_Seguro_PA1.BLL;
using Proyecto_Seguro_PA1.Entidades;
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

namespace Proyecto_Seguro_PA1.UI.Consultas
{
    /// <summary>
    /// Interaction logic for cBusquedaDeCliente.xaml
    /// </summary>
    public partial class cBusquedaDeCliente : Window
    {
        public cBusquedaDeCliente()
        {
            InitializeComponent();
        }

        private void AceptarButton_Click(object sender, RoutedEventArgs e)
        {
            if (DatosDataGrid.SelectedItem != null)
            {
                Utilidades.clienteAux = (Clientes)DatosDataGrid.SelectedItem;
                Utilidades.ClienteSelect = true;
                Close();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un Cliente", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BuscarIDButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Clientes>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0:
                        try
                        {
                            if (Desde_DataPicker.SelectedDate != null)
                                listado = ClientesBLL.GetList(
                                    c => c.FechaRegistro.Date >= Desde_DataPicker.SelectedDate &&
                                    c.FechaRegistro.Date <= Hasta_DataPicker.SelectedDate &&
                                    c.ClienteId == Utilidades.ToInt(CriterioTextBox.Text)
                                );
                            else
                                listado = ClientesBLL.GetList(e => e.ClienteId == Utilidades.ToInt(CriterioTextBox.Text));
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Debes ingresar un Critero valido.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                        break;
                    case 1:
                        try
                        {
                            if (Desde_DataPicker.SelectedDate != null)
                                listado = ClientesBLL.GetList(
                                    c => c.FechaRegistro.Date >= Desde_DataPicker.SelectedDate &&
                                    c.FechaRegistro.Date <= Hasta_DataPicker.SelectedDate &&
                                    c.Nombre.ToLower().Contains(CriterioTextBox.Text.ToLower())
                                );
                            else
                                listado = ClientesBLL.GetList(d => d.Nombre.ToLower().Contains(CriterioTextBox.Text.ToLower()));
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Debes ingresar un Critero valido.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                        break;
                    case 2:
                        try
                        {
                            if (Desde_DataPicker.SelectedDate != null)
                                listado = ClientesBLL.GetList(
                                    c => c.FechaRegistro.Date >= Desde_DataPicker.SelectedDate &&
                                    c.FechaRegistro.Date <= Hasta_DataPicker.SelectedDate &&
                                    c.Identificacion.ToLower().Contains(CriterioTextBox.Text.ToLower())
                                );
                            else
                                listado = ClientesBLL.GetList(d => d.Identificacion.ToLower().Contains(CriterioTextBox.Text.ToLower()));
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Debes ingresar un Critero valido.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                        break;
                    case 3:
                        try
                        {
                            if (Desde_DataPicker.SelectedDate != null)
                                listado = ClientesBLL.GetList(
                                    c => c.FechaRegistro.Date >= Desde_DataPicker.SelectedDate &&
                                    c.FechaRegistro.Date <= Hasta_DataPicker.SelectedDate &&
                                    c.Telefono.ToLower().Contains(CriterioTextBox.Text.ToLower())
                                );
                            else
                                listado = ClientesBLL.GetList(d => d.Telefono.ToLower().Contains(CriterioTextBox.Text.ToLower()));
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Debes ingresar un Critero valido.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                        break;
                    case 4:
                        try
                        {
                            if (Desde_DataPicker.SelectedDate != null)
                                listado = ClientesBLL.GetList(
                                    c => c.FechaRegistro.Date >= Desde_DataPicker.SelectedDate &&
                                    c.FechaRegistro.Date <= Hasta_DataPicker.SelectedDate &&
                                    c.Email.ToLower().Contains(CriterioTextBox.Text.ToLower())
                                );
                            else
                                listado = ClientesBLL.GetList(d => d.Email.ToLower().Contains(CriterioTextBox.Text.ToLower()));
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Debes ingresar un Critero valido.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                        break;

                }
            }
            else
            {
                if (Desde_DataPicker.SelectedDate != null)
                    listado = ClientesBLL.GetList(e => e.FechaRegistro.Date >= Desde_DataPicker.SelectedDate);

                if (Hasta_DataPicker.SelectedDate != null)
                    listado = ClientesBLL.GetList(e => e.FechaRegistro.Date <= Hasta_DataPicker.SelectedDate);

                if (Desde_DataPicker.SelectedDate == null && Hasta_DataPicker.SelectedDate == null)
                    listado = ClientesBLL.GetList(c => true);

            }

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }
    }
}
