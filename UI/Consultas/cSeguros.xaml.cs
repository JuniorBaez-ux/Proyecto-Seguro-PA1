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
    /// Interaction logic for cSeguros.xaml
    /// </summary>
    public partial class cSeguros : Window
    {
        public cSeguros()
        {
            InitializeComponent();
        }

        private void BuscarIDButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Seguros>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0:
                        try
                        {
                            if (Desde_DataPicker.SelectedDate != null)
                                listado = SegurosBLL.GetList(
                                    c => c.FechaRegistro.Date >= Desde_DataPicker.SelectedDate &&
                                    c.FechaRegistro.Date <= Hasta_DataPicker.SelectedDate &&
                                    c.ClientesSeguro.Nombre.ToLower().Contains(CriterioTextBox.Text.ToLower())
                                );
                            else
                                listado = SegurosBLL.GetList(e => e.ClientesSeguro.Nombre.ToLower().Contains(CriterioTextBox.Text.ToLower()));
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
                                listado = SegurosBLL.GetList(
                                    c => c.FechaRegistro.Date >= Desde_DataPicker.SelectedDate &&
                                    c.FechaRegistro.Date <= Hasta_DataPicker.SelectedDate &&
                                    c.VehiculosSeguro.Matricula.ToLower().Contains(CriterioTextBox.Text.ToLower())
                                );
                            else
                                listado = SegurosBLL.GetList(d => d.VehiculosSeguro.Matricula.ToLower().Contains(CriterioTextBox.Text.ToLower()));
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
                                listado = SegurosBLL.GetList(
                                    c => c.FechaRegistro.Date >= Desde_DataPicker.SelectedDate &&
                                    c.FechaRegistro.Date <= Hasta_DataPicker.SelectedDate &&
                                    c.VehiculosSeguro.Marca.ToLower().Contains(CriterioTextBox.Text.ToLower())
                                );
                            else
                                listado = SegurosBLL.GetList(d => d.VehiculosSeguro.Marca.ToLower().Contains(CriterioTextBox.Text.ToLower()));
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
                                listado = SegurosBLL.GetList(
                                    c => c.FechaRegistro.Date >= Desde_DataPicker.SelectedDate &&
                                    c.FechaRegistro.Date <= Hasta_DataPicker.SelectedDate &&
                                    c.VehiculosSeguro.AnioVehiculo == Utilidades.ToInt(CriterioTextBox.Text)
                                );
                            else
                                listado = SegurosBLL.GetList(d => d.VehiculosSeguro.AnioVehiculo == Utilidades.ToInt(CriterioTextBox.Text));
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
                    listado = SegurosBLL.GetList(e => e.FechaRegistro.Date >= Desde_DataPicker.SelectedDate);

                if (Hasta_DataPicker.SelectedDate != null)
                    listado = SegurosBLL.GetList(e => e.FechaRegistro.Date <= Hasta_DataPicker.SelectedDate);

                if (Desde_DataPicker.SelectedDate == null && Hasta_DataPicker.SelectedDate == null)
                    listado = SegurosBLL.GetList(c => true);

            }

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }
    }
}
