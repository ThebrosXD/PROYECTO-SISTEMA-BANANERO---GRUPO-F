using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidad;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Capa_Datos
{
    public class D_cotizaciones
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);

        public DataTable Listado_CO()
        {
            SqlCommand cmd = new SqlCommand("listado_cotizaciones", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cn.Close();
            return dt;
        }

        public DataTable CargarProductosCMB_CO()
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("select id_producto, nombre, estado, descripcion, fecha_vencimiento, valor from B_productos", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            DataRow fila = dt.NewRow();
            fila["nombre"] = "Eliga un producto";
            dt.Rows.InsertAt(fila, 0);
            cn.Close();
            return dt;
        }

        public String Registrar_cotizacion(String accion, E_cotizaciones oCO)
        {
            String Rpa = "";
            try
            {
                SqlCommand cmd = new SqlCommand("Registrar_cotizacion", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_cotizacion", oCO.id_cotizacion);
                cmd.Parameters.AddWithValue("@id_cedula", oCO.id_cedula);
                cmd.Parameters.AddWithValue("@id_producto", oCO.id_producto);
                cmd.Parameters.AddWithValue("@precioUni", oCO.precioUNI);
                cmd.Parameters.AddWithValue("@precioTotal", oCO.precioTOTAL);
                cmd.Parameters.AddWithValue("@estado", oCO.estado);
                cmd.Parameters.AddWithValue("@fecha_cotizacion", oCO.fecha_cotizacion);
                cmd.Parameters.AddWithValue("@fecha_aceptacion", oCO.fecha_aceptacion);
                cmd.Parameters.AddWithValue("@comentarios", oCO.comentarios);
                cmd.Parameters.Add("@accion", SqlDbType.VarChar, 100).Value = accion;
                cmd.Parameters["@accion"].Direction = ParameterDirection.InputOutput;
                cn.Open();
                cmd.ExecuteNonQuery();
                accion = cmd.Parameters["@accion"].Value.ToString();
                cn.Close();
                return accion;
            }
            catch (Exception ex)
            {
                Rpa = ex.Message;
            }
            finally
            {
                if (cn.State == ConnectionState.Open) cn.Close();
            }
            return Rpa;
        }

        public DataTable CargarProductosCMB()
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("select id_producto, nombre, estado, descripcion, fecha_vencimiento, valor from B_productos", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            DataRow fila = dt.NewRow();
            fila["nombre"] = "Eliga un producto";
            dt.Rows.InsertAt(fila, 0);
            cn.Close();
            return dt;
        }
        public List<E_usuario> ObtenerRegistrosInicioSesion()
        {
            List<E_usuario> registros = new List<E_usuario>();

            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString))
            {
                cn.Open();
                using (SqlCommand command = new SqlCommand("select cedula, nombre, telefono, direccion from B_usuario", cn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            E_usuario registro = new E_usuario
                            {
                                cedula = Convert.ToInt32(reader["cedula"]),
                                nombre = reader["nombre"].ToString(),
                                telefono = Convert.ToInt32(reader["telefono"]),
                                direccion = reader["direccion"].ToString(),
                            };
                            registros.Add(registro);
                        }
                    }
                }
                cn.Close();
            }
            return registros;
        }
    }
}
