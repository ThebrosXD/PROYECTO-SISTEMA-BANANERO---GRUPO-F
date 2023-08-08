using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Capa_Entidad;
using System.Configuration;
using System.Collections;

namespace Capa_Datos
{
    public class D_pedidos
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);

        public DataTable Listado_pe()
        {
            SqlCommand cmd = new SqlCommand("listado_pedido", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        //Registrar pedido
        public String Registrar_pedido(String accion, E_pedidos oPE)
        {
            String Rpa = "";
            try {
                SqlCommand cmd = new SqlCommand("registrar_pedido", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_pedido", oPE.Id_pe);
                cmd.Parameters.AddWithValue("@nid_cedula", oPE.Cedula_pe);
                cmd.Parameters.AddWithValue("@nid_producto", oPE.Producto_pe);
                cmd.Parameters.AddWithValue("@Mpago", oPE.Mpago_pe);
                cmd.Parameters.AddWithValue("@fecha_pedido", oPE.Fecha_pe);
                cmd.Parameters.AddWithValue("@estado", oPE.Estado);
                cmd.Parameters.AddWithValue("@precioUni", oPE.PrecioUNI_pe);
                cmd.Parameters.AddWithValue("@precioTotal", oPE.PrecioTOT_pe);
                cmd.Parameters.AddWithValue("@descripcion",oPE.descripcion);
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

        //Carga de Productos
        public DataTable CargarProductosCMB()
        {
            SqlCommand cmd = new SqlCommand("select id_producto, nombre, valor from B_productos", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        //Carga de Metodo de pago
        public DataTable CargarMPagoCMB()
        {
            SqlCommand cmd = new SqlCommand("select id_Mpago, nombre from B_MetodoPago", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        //Obetener informacion del usuario logeado
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
            }

            return registros;
        }

        //eliminar pedido
        public String Eliminar_pedido(int pedido)
        {
            String Rpa = "";
            try
            {
                SqlCommand cmd = new SqlCommand("Eliminar_pedido", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nid_pedido", pedido);
                cn.Open();

                Rpa = cmd.ExecuteNonQuery() == 1 ? "OK" : "Nose pudo eliminar los datos";
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
    }
}
