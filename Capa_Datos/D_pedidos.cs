﻿/**
 * Este es la clase capa datos de pedido
 * @author Grupo F
 * @version   1.1
 * @return El mensaje usado para el saludo
 * Created on July 5, 2023, 4:24 AM
*/
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
using System.Data.Common;
using System.Runtime.InteropServices;

namespace Capa_Datos
{
    public class D_pedidos
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);

        /**public DataTable Listado_pe()
        {
            SqlCommand cmd = new SqlCommand("listado_pedido", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }*/

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
                cmd.Parameters.AddWithValue("@descripcion", oPE.descripcion);
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

        //Carga de Metodo de pago
        public DataTable CargarMPagoCMB()
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("select id_Mpago, nombre from B_MetodoPago", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DataRow fila = dt.NewRow();
            fila["nombre"] = "Eliga un metodo de pago";
            dt.Rows.InsertAt(fila, 0);
            cn.Close();
            return dt;
        }

        //Obetener informacion del usuario logeado
        public List<E_usuario> ObtenerRegistrosInicioSesion(int cedula)
        {
            List<E_usuario> registros = new List<E_usuario>();

            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString))
            {
                cn.Open();
                using (SqlCommand command = new SqlCommand("select cedula, nombre, telefono, direccion, rol from B_usuario where cedula=@cedula", cn))
                {
                    command.Parameters.AddWithValue("@cedula", cedula);
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
                                rol = reader["rol"].ToString(),
                            };
                            registros.Add(registro);
                        }
                    }
                }
                cn.Close();
            }

            return registros;
        }

        //Eliminar pedido
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

        //Mostrar tabla pedido
        public DataTable Tablas_seguimiento(int USER)
        {
            cn.Open();
            String consulta = "SELECT B_pedidos.id_pedido, B_pedidos.Mpago, B_pedidos.fecha_pedido, B_pedidos.precioTotal from B_pedidos where B_pedidos.id_cedula = @Id_cedula";
            SqlCommand comando = new SqlCommand(consulta, cn);
            comando.Parameters.AddWithValue("@Id_cedula", USER);
            SqlDataAdapter adaptador = new SqlDataAdapter(comando);
            //comando.ExecuteNonQuery();
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            cn.Close();
            return dt;
        }

        //Buscar pedido
        public DataTable BuscarPedido(int codigo)
        {
            cn.Open();
            String consulta = "SELECT B_pedidos.id_pedido, B_pedidos.Mpago, B_pedidos.fecha_pedido, B_pedidos.precioTotal from B_pedidos where B_pedidos.id_pedido = @Id_pedido";
            SqlCommand comando = new SqlCommand(consulta, cn);
            comando.Parameters.AddWithValue("@Id_pedido", codigo);
            SqlDataAdapter adaptador = new SqlDataAdapter(comando);
            //comando.ExecuteNonQuery();
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            cn.Close() ;
            return dt;
        }

        //Mostrar tabla cotizacion
        public DataTable Tablas_seguimientoCoti(int USER)
        {
            cn.Open();
            String consulta = "SELECT COTI.id_cotizacion, COTI.estado, COTI.fecha_cotizacion, COTI.fecha_aceptacion, COTI.precioTotal from B_cotizaciones as COTI where COTI.id_Cedula = @Id_cedula";
            SqlCommand comando = new SqlCommand(consulta, cn);
            comando.Parameters.AddWithValue("@Id_cedula", USER);
            SqlDataAdapter adaptador = new SqlDataAdapter(comando);
            //comando.ExecuteNonQuery();
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            cn.Close();
            return dt;
        }

        //buscar cotizacion
        public DataTable BuscarCotizacion(int codigo)
        {
            cn.Open();
            String consulta = "SELECT COTI.id_cotizacion, COTI.estado, COTI.fecha_cotizacion, COTI.fecha_aceptacion, COTI.precioTotal from B_cotizaciones as COTI where COTI.id_cotizacion = @Id_cotizacion";
            SqlCommand comando = new SqlCommand(consulta, cn);
            comando.Parameters.AddWithValue("@Id_cotizacion", codigo);
            SqlDataAdapter adaptador = new SqlDataAdapter(comando);
            //comando.ExecuteNonQuery();
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            cn.Close();
            return dt;
        }

        //Eliminar totizacion
        public String Eliminar_cotizacion(int codigo)
        {
            String Rpa = "";
            try
            {
                SqlCommand cmd = new SqlCommand("Eliminar_cotizacion", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nid_cotizacion", codigo);
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
