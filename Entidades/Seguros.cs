using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_Seguro_PA1.Entidades
{
    public class Seguros
    {
        [Key]
        public int SeguroId { get; set; }
        public string NCF { get; set; } = "B0100001007";
        public string Nombre { get; set; }
        public string Matricula { get; set; }
        public string Marca { get; set; }
        public string Anio { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
        public int ClienteId { get; set; }
        public int VehiculoId { get; set; }
        public bool Activo { get; set; } = true;
        public decimal Precio { get; set; }

        [ForeignKey("ClienteId")]
        public virtual Clientes ClientesSeguro { get; set; }

        [ForeignKey("VehiculoId")]
        public virtual Vehiculos VehiculosSeguro { get; set; }

    }
}
