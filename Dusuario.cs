using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidadaa;
using System.Configuration;

namespace Capa_Datoss
{
  public class Dusuario
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);
        public DataTable conexion(Eusuarios obje)
        {
            SqlCommand cmd = new SqlCommand("SP_listar_usuario", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@usuario", obje.Nom_usuario);
            cmd.Parameters.AddWithValue("@contraseña ", obje.Contraseña);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            da.Fill(data);
            return data;

        }

        public DataTable Listar_Usuario()
        {
            SqlDataReader resultado;
            DataTable tabla = new DataTable();
            SqlConnection con = new SqlConnection();

            try
            {
                con = Conexion.GetInstancia().CreaConexion();
                SqlCommand cmd = new SqlCommand("SP_listar_USUARIOS", con);
                cmd.CommandType = CommandType.StoredProcedure;


                con.Open();
                resultado = cmd.ExecuteReader();
                tabla.Load(resultado);
                return tabla;
            }
            catch (Exception ex)
            {
                con = null;
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open) con.Close();
            }

        }
    }
}
