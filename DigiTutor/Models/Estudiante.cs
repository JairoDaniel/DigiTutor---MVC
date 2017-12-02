using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigiTutor.Models
{
    public class Estudiante
    {
        public int id_estudiante { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public int id_pais { get; set; }
        public int id_universidad { get; set; }
        public string email1 { get; set; }
        public string email2 { get; set; }
        public int telefono_fijo { get; set; }
        public int telefono_celular { get; set; }
        public string foto { get; set; }
        public string clave { get; set; }
        public string descripcion { get; set; }
        public int reputacion { get; set; }
        public int apoyos { get; set; }
        public string nombre_universidad { get; set; }
        public string nombre_pais { get; set; }
        public DateTime fecha_registro { get; set; }
    }
}