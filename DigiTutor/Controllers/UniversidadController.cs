using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using DigiTutor.Models;
using System.Data.SqlClient;
using DigiTutor.Constants;
using System.Data;

namespace DigiTutor.Controllers
{
    [RoutePrefix("universidad")]
    public class UniversidadController : ApiController
    {
        [Route("obtenerUniversidades")]
        [HttpGet]
        public IHttpActionResult getEstudiantes()
        {
            List<Universidad> Us = new List<Universidad>();
            using (SqlConnection connection = DBConnection.getConnection())
            {


                SqlCommand command = new SqlCommand("dbo.get_universidades", connection);
                command.CommandType = CommandType.StoredProcedure;
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Universidad puniversidad = new Universidad();
                        puniversidad.nombre = reader.GetString(0);
                        puniversidad.id_universidad = 0;

                        Us.Add(puniversidad);
                    }
                    return Json(Us);
                }
                catch (SqlException ex)
                {
                    return Json(ex);
                }
                finally { connection.Close(); }

            }

        }

        [Route("ingresarUniversidad")]
        [HttpPost]
        public void register(Universidad pUniversidad)
        {
            using (SqlConnection connection = DBConnection.getConnection())
            {

                SqlCommand command = new SqlCommand("dbo.agregar_universidad", connection);
                command.CommandType = CommandType.StoredProcedure;
                
                command.Parameters.AddWithValue("@nombre", SqlDbType.VarChar).Value = pUniversidad.nombre;

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex);
                }
                finally { connection.Close(); }
            }
        }
    }
}