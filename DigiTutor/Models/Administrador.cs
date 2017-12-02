using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigiTutor.Models
{
    public class Administrador
    {
        public int id_unico { get; set; }
        public int id_administrador { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string email { get; set; }
        public string clave { get; set; }
        public DateTime fecha_registro { get; set; }

    }
}