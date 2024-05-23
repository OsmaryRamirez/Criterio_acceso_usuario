using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Capa_Entidadaa;


namespace Capa_Datoss
{
   public class Dmedico
    {

        public DataTable ListarMedicos(string valor)
        {
            SqlDataReader resultado;
            DataTable tabla = new DataTable();
            SqlConnection con = new SqlConnection();

            try
            {
                con = Conexion.GetInstancia().CreaConexion();
                SqlCommand cmd = new SqlCommand("SP_listar_medico", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@valor", SqlDbType.VarChar).Value = valor;
                con.Open();
                resultado = cmd.ExecuteReader();
                tabla.Load(resultado);
                return tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open) con.Close();
            }
        }

        public DataTable BuscarMedico(string valor)
        {
            SqlDataReader resultado;
            DataTable tabla = new DataTable();
            SqlConnection con = new SqlConnection();

            try
            {
                con = Conexion.GetInstancia().CreaConexion();
                SqlCommand cmd = new SqlCommand("buscar_medico", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Valor", SqlDbType.VarChar).Value = valor;
                con.Open();
                resultado = cmd.ExecuteReader();
                tabla.Load(resultado);
                return tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open) con.Close();
            }


        }
        public string GuardarMedico(int opcion, Emedico datos)
        {
            string respuesta = "";
            SqlConnection con = new SqlConnection();
            try
            {
                con = Conexion.GetInstancia().CreaConexion();
                SqlCommand cmd = new SqlCommand("SP_insertar_Medico", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@opcion", SqlDbType.Int).Value = opcion;
                cmd.Parameters.Add("@Codigo_med", SqlDbType.Int).Value = datos.Codigo_med;
                cmd.Parameters.Add("@ID_usuario", SqlDbType.Int).Value = datos.ID_usuario;
                cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = datos.Nombre;
                cmd.Parameters.Add("@Apellido", SqlDbType.VarChar).Value = datos.Apellido;
                cmd.Parameters.Add("@Cedula", SqlDbType.VarChar).Value = datos.Cedula;
                cmd.Parameters.Add("@ESpecialidad", SqlDbType.VarChar).Value = datos.Especialidad;
                cmd.Parameters.Add("@Telefono", SqlDbType.VarChar).Value = datos.Telefono;
                cmd.Parameters.Add("@Correo", SqlDbType.VarChar).Value = datos.Correo;



                con.Open();
                respuesta = cmd.ExecuteNonQuery() == 1 ? "Ok" : "No se ejecutó correctamente";
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            finally
            {
                if (con.State == ConnectionState.Open) con.Close();
            }
            return respuesta;
        }


    }
}
