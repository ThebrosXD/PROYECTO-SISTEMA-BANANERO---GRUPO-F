/**
 * Este es la clase capa datos de cotizaciones
 * @author Grupo F
 * @version   1.1
 * @return El mensaje usado para el saludo
 * Created on July 5, 2023, 4:24 AM
*/
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
    /// <summary>
    /// Clase que proporciona el acceso a datos relacionados con las cotizaciones.
    /// </summary>
    public class D_cotizaciones
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);
        /// <summary>
        /// Obtiene un listado de cotizaciones.
        /// </summary>
        /// <returns>Un objeto DataTable con los datos de las cotizaciones.</returns>

        public DataTable Listado_CO()
        {
            SqlCommand cmd = new SqlCommand("listado_cotizaciones", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cn.Close();
            return dt;
        }


        /// <summary>
        /// Carga los productos disponibles en un ComboBox para su selección en una cotización.
        /// </summary>
        /// <returns>Un objeto DataTable con los datos de los productos para el ComboBox.</returns>
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

        /// <summary>
        /// Registra una nueva cotización en la base de datos.
        /// </summary>
        /// <param name="accion">La acción a realizar (insertar, actualizar).</param>
        /// <param name="oCO">La entidad E_cotizaciones con los datos de la cotización.</param>
        /// <returns>Un mensaje indicando el resultado del registro.</returns>
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

        /// <summary>
        /// Carga los productos disponibles en un ComboBox para su selección en diferentes operaciones.
        /// </summary>
        /// <returns>Un objeto DataTable con los datos de los productos para el ComboBox.</returns>
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

        /// <summary>
        /// Obtiene registros de usuarios que han iniciado sesión en la aplicación.
        /// </summary>
        /// <returns>Una lista de entidades E_usuario con los datos de los usuarios.</returns>
        public List<E_usuario> ObtenerRegistrosInicioSesion(int usuario)
        {
            List<E_usuario> registros = new List<E_usuario>();

            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString))
            {
                cn.Open();
                using (SqlCommand command = new SqlCommand("select cedula, nombre, telefono, direccion from B_usuario where cedula=@cedula", cn))
                {
                    command.Parameters.AddWithValue("@cedula", usuario);
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
