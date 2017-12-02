using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using DigiTutor.Constants;
using DigiTutor.Models;
using System.Data.SqlClient;
using System.Data;

namespace DigiTutor.Controllers
{
    [RoutePrefix("reporte")]
    public class ReporteController : ApiController
    {
       /* [Route("generarReporte")]
        [HttpGet]
        public IHttpActionResult getReporte()
        {
            //Nombre, apellidos, telefonomovil, correo1 y 2, u, seguidores, publi, reputacion, habilidades, nota
            //E, E, E, E,E,E,X,X,E, EH

            List<Estudiante> estudiantes = new List<Estudiante>();
            using (SqlConnection connection = DBConnection.getConnection())
            {


                SqlCommand command = new SqlCommand("dbo.get_estudiantes", connection);
                command.CommandType = CommandType.StoredProcedure;
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Estudiante estudiante = new Estudiante();

                        estudiantes.Add(leerJson(estudiante, reader));
                    }
                    return Json(estudiantes);
                }
                catch (SqlException ex)
                {
                    return Json(ex);
                }
                finally { connection.Close(); }

            }

        }*/
    }
}