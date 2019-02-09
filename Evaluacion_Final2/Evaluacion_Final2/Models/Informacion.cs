using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Evaluacion_Final2.Models
{
    public class Informacion
    {
        [Key]
        public int idInformacion { get; set; }
        public string Ubicacion { get; set; }
        public string Detalle { get; set; }
        public string Tamaño { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }

    }
}
