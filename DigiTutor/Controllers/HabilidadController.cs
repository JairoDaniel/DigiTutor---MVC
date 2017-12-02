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
    [RoutePrefix("habilidades")]
    public class HabilidadController : ApiController
    {
        [Route("obtenerHabilidades")]
        [HttpGet]
        public IHttpActionResult getEstudiantes()
        {
            List<Habilidad> Hs = new List<Habilidad>();
            using (SqlConnection connection = DBConnection.getConnection())
            {


                SqlCommand command = new SqlCommand("dbo.get_habilidades", connection);
                command.CommandType = CommandType.StoredProcedure;
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Habilidad phabilidad = new Habilidad();
                        phabilidad.nombre = reader.GetString(0);
                        phabilidad.id_habilidad = 0;

                        Hs.Add(phabilidad);
                    }
                    return Json(Hs);
                }
                catch (SqlException ex)
                {
                    return Json(ex);
                }
                finally { connection.Close(); }

            }

        }
        [Route("ingresarHabilidad")]
        [HttpPost]
        public void register(Habilidad pHabilidad)
        {
            using (SqlConnection connection = DBConnection.getConnection())
            {

                SqlCommand command = new SqlCommand("dbo.agregar_habilidad", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@nombre", SqlDbType.VarChar).Value = pHabilidad.nombre;

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