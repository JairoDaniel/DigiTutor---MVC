using DigiTutor.Constants;
using DigiTutor.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace DigiTutor.Controllers
{
    [RoutePrefix("administrador")]
    public class AdministradorController : ApiController
    {
        [Route("ingresarAdministrador")]
        [HttpPost]
        public void register(Administrador pAdministrador)
        {
            using (SqlConnection connection = DBConnection.getConnection())
            {

                SqlCommand command = new SqlCommand("dbo.agregar_administrador", connection);
                command.CommandType = CommandType.StoredProcedure;
                
                command.Parameters.AddWithValue("@id_admin", SqlDbType.BigInt).Value = Convert.ToInt64(pAdministrador.id_administrador);
                command.Parameters.AddWithValue("@nombre", SqlDbType.VarChar).Value = pAdministrador.nombre;
                command.Parameters.AddWithValue("@apellidos", SqlDbType.VarChar).Value = pAdministrador.apellidos;
                command.Parameters.AddWithValue("@email", SqlDbType.VarChar).Value = pAdministrador.email;
                command.Parameters.AddWithValue("@clave", SqlDbType.VarChar).Value = pAdministrador.clave;

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