using DigiTutor.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;
using DigiTutor.Constants;

namespace DigiTutor.Controllers
{
    [RoutePrefix("estudiante")]
    public class EstudianteController : ApiController
    {
        [Route("obtenerEstudiantes")]
        [HttpGet]
        public IHttpActionResult getEstudiantes()
        {
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

        }

        [Route("ingresarEstudiante")]
        [HttpPost]
        public void register(Estudiante pEstudiante)
        {
            using (SqlConnection connection = DBConnection.getConnection())
            {

                SqlCommand command = new SqlCommand("dbo.agregar_estudiante", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@id_estud", SqlDbType.BigInt).Value = Convert.ToInt64(pEstudiante.id_estudiante);
                command.Parameters.AddWithValue("@nombre", SqlDbType.VarChar).Value = pEstudiante.nombre;
                command.Parameters.AddWithValue("@apellidos", SqlDbType.VarChar).Value = pEstudiante.apellidos;
                command.Parameters.AddWithValue("@nombre_pais", SqlDbType.VarChar).Value = pEstudiante.nombre_pais;
                command.Parameters.AddWithValue("@nombre_universidad", SqlDbType.VarChar).Value = pEstudiante.nombre_universidad; 
                command.Parameters.AddWithValue("@email1", SqlDbType.VarChar).Value = pEstudiante.email1;
                command.Parameters.AddWithValue("@email2", SqlDbType.VarChar).Value = pEstudiante.email2;
                command.Parameters.AddWithValue("@telefono_fijo", SqlDbType.Int).Value = Convert.ToInt32(pEstudiante.telefono_fijo);
                command.Parameters.AddWithValue("@telefono_celular", SqlDbType.Int).Value = Convert.ToInt32(pEstudiante.telefono_celular);
                command.Parameters.AddWithValue("@foto", SqlDbType.VarChar).Value = "";
                command.Parameters.AddWithValue("@clave", SqlDbType.VarChar).Value = pEstudiante.clave;
                command.Parameters.AddWithValue("@descripcion", SqlDbType.VarChar).Value = pEstudiante.descripcion;

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

        private Estudiante leerJson(Estudiante estudiante, SqlDataReader reader){
            try
            {
                estudiante.id_estudiante = reader.GetInt32(0);
            }
            catch (System.Data.SqlTypes.SqlNullValueException ex)
            {
                estudiante.id_estudiante = 0;
            }
            try
            {
                estudiante.nombre = reader.GetString(1);
            }
            catch (System.Data.SqlTypes.SqlNullValueException ex)
            {
                estudiante.nombre = null;
            }
            try
            {
                estudiante.apellidos = reader.GetString(2);
            }
            catch (System.Data.SqlTypes.SqlNullValueException ex)
            {
                estudiante.apellidos = null;
            }
            try
            {
                estudiante.id_pais = reader.GetInt32(3);
            }
            catch (System.Data.SqlTypes.SqlNullValueException ex)
            {
                estudiante.id_pais = 0;
            }
            try
            {
                estudiante.id_universidad = reader.GetInt32(4);
            }
            catch (System.Data.SqlTypes.SqlNullValueException ex)
            {
                estudiante.id_universidad = 0;
            }
            try
            {
                estudiante.email1 = reader.GetString(5);
            }
            catch (System.Data.SqlTypes.SqlNullValueException ex)
            {
                estudiante.email1 = null;
            }
            try
            {
                estudiante.email2 = reader.GetString(6);
            }
            catch (System.Data.SqlTypes.SqlNullValueException ex)
            {
                estudiante.email2 = null;
            }
            try
            {
                estudiante.telefono_fijo = reader.GetInt32(7);
            }
            catch (System.Data.SqlTypes.SqlNullValueException ex)
            {
                estudiante.telefono_fijo = 0;
            }
            try
            {
                estudiante.telefono_celular = reader.GetInt32(8);
            }
            catch (System.Data.SqlTypes.SqlNullValueException ex)
            {
                estudiante.telefono_celular = 0;
            }
            /*try
            {
                estudiante.foto = reader.GetByte(9);
            }
            catch (System.Data.SqlTypes.SqlNullValueException ex)
            {
                estudiante.foto = reader.GetByte(9);
            }*/
            try
            {
                estudiante.clave = reader.GetString(10);

            }
            catch (System.Data.SqlTypes.SqlNullValueException ex)
            {
                estudiante.clave = null;
            }
            try
            {
                estudiante.descripcion = reader.GetString(11);
            }
            catch (System.Data.SqlTypes.SqlNullValueException ex)
            {
                estudiante.descripcion = null;
            }
            try
            {
                estudiante.reputacion = reader.GetInt32(12);
            }
            catch (System.Data.SqlTypes.SqlNullValueException ex)
            {
                estudiante.reputacion = 0;
            }
            try
            {
                estudiante.apoyos = reader.GetInt32(13);
            }
            catch (System.Data.SqlTypes.SqlNullValueException ex)
            {
                estudiante.apoyos = 0;
            }
            try
            {
                estudiante.fecha_registro = reader.GetDateTime(14);
            }
            catch (System.Data.SqlTypes.SqlNullValueException ex)
            {
                estudiante.fecha_registro = DateTime.Today;
            }
            return estudiante;
        }
    }
}