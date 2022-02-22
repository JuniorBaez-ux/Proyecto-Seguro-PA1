using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Seguro_PA1.Entidades
{
    public class Reclamos
    {
        [Key]
        public int ReclamoId { get; set; }
        public string Motivos { get; set; }
        public string Prestaciones { get; set; }
        public string Alegaciones { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
        public int ClienteId { get; set; }

        [ForeignKey("ClienteId")]
        public virtual Clientes ClienteReclamo { get; set; }
    }
}
