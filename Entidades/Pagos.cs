using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Seguro_PA1.Entidades
{
    public class Pagos
    {
        [Key]
        public int PagoId { get; set; }
        public string FechaLimite { get; set; }
        public string Estado { get; set; }
        public decimal Monto { get; set; }
        public string FechaPago { get; set; }
        public int SeguroId { get; set; }

        [ForeignKey("SeguroId")]
        public virtual Seguros Seguros { get; set; }
    }
}
