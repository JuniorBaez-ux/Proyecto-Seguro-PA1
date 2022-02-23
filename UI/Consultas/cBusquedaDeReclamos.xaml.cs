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
    /// Interaction logic for cBusquedaDeReclamos.xaml
    /// </summary>
    public partial class cBusquedaDeReclamos : Window
    {
        public cBusquedaDeReclamos()
        {
            InitializeComponent();
        }

        private void AceptarButton_Click(object sender, RoutedEventArgs e)
        {
            if (DatosDataGrid.SelectedItem != null)
            {
                Utilidades.ReclamoAux = (Reclamos)DatosDataGrid.SelectedItem;
                Utilidades.ClienteSelect = true;
                Close();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un Reclamo", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BuscarIDButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Reclamos>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0:
                        try
                        {
                            if (Desde_DataPicker.SelectedDate != null)
                                listado = ReclamosBLL.GetList(
                                    c => c.FechaRegistro.Date >= Desde_DataPicker.SelectedDate &&
                                    c.FechaRegistro.Date <= Hasta_DataPicker.SelectedDate &&
                                    c.ClientesReclamo.Nombre.ToLower().Contains(CriterioTextBox.Text.ToLower())
                                );
                            else
                                listado = ReclamosBLL.GetList(e => e.ClientesReclamo.Nombre.ToLower().Contains(CriterioTextBox.Text.ToLower()));
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
                                listado = ReclamosBLL.GetList(
                                    c => c.FechaRegistro.Date >= Desde_DataPicker.SelectedDate &&
                                    c.FechaRegistro.Date <= Hasta_DataPicker.SelectedDate &&
                                    c.ClientesReclamo.Identificacion.ToLower().Contains(CriterioTextBox.Text.ToLower())
                                );
                            else
                                listado = ReclamosBLL.GetList(d => d.ClientesReclamo.Identificacion.ToLower().Contains(CriterioTextBox.Text.ToLower()));
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
                                listado = ReclamosBLL.GetList(
                                    c => c.FechaRegistro.Date >= Desde_DataPicker.SelectedDate &&
                                    c.FechaRegistro.Date <= Hasta_DataPicker.SelectedDate &&
                                    c.ClientesReclamo.Telefono.ToLower().Contains(CriterioTextBox.Text.ToLower())
                                );
                            else
                                listado = ReclamosBLL.GetList(d => d.ClientesReclamo.Telefono.ToLower().Contains(CriterioTextBox.Text.ToLower()));
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
                                listado = ReclamosBLL.GetList(
                                    c => c.FechaRegistro.Date >= Desde_DataPicker.SelectedDate &&
                                    c.FechaRegistro.Date <= Hasta_DataPicker.SelectedDate &&
                                    c.Motivos.ToLower().Contains(CriterioTextBox.Text.ToLower())
                                );
                            else
                                listado = ReclamosBLL.GetList(d => d.Motivos.ToLower().Contains(CriterioTextBox.Text.ToLower()));
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
                                listado = ReclamosBLL.GetList(
                                    c => c.FechaRegistro.Date >= Desde_DataPicker.SelectedDate &&
                                    c.FechaRegistro.Date <= Hasta_DataPicker.SelectedDate &&
                                    c.Prestaciones.ToLower().Contains(CriterioTextBox.Text.ToLower())
                                );
                            else
                                listado = ReclamosBLL.GetList(d => d.Prestaciones.ToLower().Contains(CriterioTextBox.Text.ToLower()));
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Debes ingresar un Critero valido.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                        break;
                    case 5:
                        try
                        {
                            if (Desde_DataPicker.SelectedDate != null)
                                listado = ReclamosBLL.GetList(
                                    c => c.FechaRegistro.Date >= Desde_DataPicker.SelectedDate &&
                                    c.FechaRegistro.Date <= Hasta_DataPicker.SelectedDate &&
                                    c.Alegaciones.ToLower().Contains(CriterioTextBox.Text.ToLower())
                                );
                            else
                                listado = ReclamosBLL.GetList(d => d.Alegaciones.ToLower().Contains(CriterioTextBox.Text.ToLower()));
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
                    listado = ReclamosBLL.GetList(e => e.FechaRegistro.Date >= Desde_DataPicker.SelectedDate);

                if (Hasta_DataPicker.SelectedDate != null)
                    listado = ReclamosBLL.GetList(e => e.FechaRegistro.Date <= Hasta_DataPicker.SelectedDate);

                if (Desde_DataPicker.SelectedDate == null && Hasta_DataPicker.SelectedDate == null)
                    listado = ReclamosBLL.GetList(c => true);

            }

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }
    }
}
