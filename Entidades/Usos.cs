using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Seguro_PA1.Entidades
{
    public class Usos
    {
        [Key]
        public int UsoId { get; set; }
        public string Descripcion { get; set; }

    }
}
