using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigiTutor.Models
{
    public class Publicacion
    {
        public int id_publicacion { get; set; }
        public int id_estudiante { get; set; }
        public string titulo { get; set; }
        public DateTime fecha{ get; set; }
        public string descripcion { get; set; }
        public char tipo { get; set; }
    }
}