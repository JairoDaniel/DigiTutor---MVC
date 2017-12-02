using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigiTutor.Models
{
    public class Reporte
    {
        public int id_reporte { get; set; }
        public int id_administrador { get; set; }
        public int top_n { get; set; }
        public int id_universidad { get; set; }
        public int id_pais { get; set; }
        public DateTime fecha { get; set; }
    }
}