using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Seguro_PA1.Entidades
{
    public class Clientes
    {   
        [Key]
        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Identificacion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public bool Activo { get; set; } = true;
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
    }
}
