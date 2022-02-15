using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_Seguro_PA1.Entidades
{
    public class Seguros
    {
        [Key]
        public int SeguroId { get; set; }
        public string NCF { get; set; } = "B0100001007";
        public string Cliente { get; set; }
        public string Nombre { get; set; }
        public string Identificacion { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Vehiculo { get; set; }
        public string SColor { get; set; }
        public string SMatricula { get; set; }
        public int SCantidadPasajeros { get; set; }
        public double SPrecio { get; set; }
        public string SChasis { get; set; }
        public int SCilindros { get; set; }
        public string SUsoVehiculo { get; set; }

    }
}
