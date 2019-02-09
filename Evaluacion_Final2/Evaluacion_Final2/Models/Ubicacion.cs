using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Evaluacion_Final2.Models
{
    public class Ubicacion
    {
        [Key]
        public int idUbicacion { get; set; }
        public string Detalle { get; set; }
        public Disco Disco { get; set; }
        public int idDisco { get; set; }
        public Informacion Informacion { get; set; }
        public int idInformacion { get; set; }
    }
}
