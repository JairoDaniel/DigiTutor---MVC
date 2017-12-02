using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigiTutor.Models
{
    public class EstudianteHabilidad
    {
        public int id_estudiante { get; set; }
        public int id_habilidad { get; set; }
        public int apoyos_recibidos { get; set; }
    }
}