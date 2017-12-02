using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigiTutor.Models
{
    public class PublicacionTutoria
    {
        public int id_publicacion { get; set; }
        public int costo { get; set; }
        public DateTime fecha { get; set; }
        public int asistentes { get; set; }
        public string lugar { get; set; }
    }
}