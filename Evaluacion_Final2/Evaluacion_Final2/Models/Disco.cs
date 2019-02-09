using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Evaluacion_Final2.Models
{
    public class Disco
    {
        [Key]
        public int idDisco { get; set; }
        public string Nombre { get; set; }
        public string Capacidad { get; set; }
        public string Tipo { get; set; }
    }
}
