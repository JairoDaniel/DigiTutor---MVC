using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigiTutor.Models
{
    public class PublicacionPuntos
    {
        public int id_publicacion { get; set; }
        public int puntos_positivos { get; set; }
        public int puntos_negativos { get; set; }
    }
}