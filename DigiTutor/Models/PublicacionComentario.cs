using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigiTutor.Models
{
    public class PublicacionComentario
    {
        public int id_publicacion { get; set; }
        public int id_estudiante { get; set; }
        public string comentario { get; set; }
    }
}