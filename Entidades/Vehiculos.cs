using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_Seguro_PA1.Entidades
{
    public class Vehiculos
    {
        [Key]
        public int VehiculoId { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string TipoVehiculo { get; set; }
        public int AnioVehiculo { get; set; }
        public string Color { get; set; }
        public string Matricula { get; set; }
        public int CantidadPasajeros { get; set; }
        public double Precio { get; set; }
        public string Chasis { get; set; }
        public int Cilindros { get; set; }
        public string UsoVehiculo { get; set; }
        public string Propietario { get; set; }

    }
}
