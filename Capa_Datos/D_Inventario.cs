﻿/**
 * Este es la clase capa datos de inventario    
 * @author Grupo F
 * @version   1.1
 * @return El mensaje usado para el saludo
 * Created on July 5, 2023, 4:24 AM
*/
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Capa_Entidad;

namespace Capa_Datos
{
    public class D_Inventario
    {
        SqlConnection cn = new SqlConnection("Server=DESKTOP-R2245IH;Database=DBBanano;Integrated Security=true");
        /// <summary>
        /// Clase que proporciona el acceso a datos relacionados con el inventario de productos.
        /// </summary>

        public DataTable Listado_inventario()
        {
            string consulta = "select *from B_productos order by id_producto";
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, cn);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            return dt;
        }

        /// <summary>
        /// Registra un nuevo producto en el inventario.
        /// </summary>
        /// <param name="EP">La entidad E_productos con los datos del producto a registrar.</param>}
        public String Registrar_Inventario(E_productos EP)
        {
            String rpa = "";
            try
            {
                string consulta = "INSERT INTO B_productos (Id_producto, Nombre, Descripcion, valor, estado, fecha_adquisicion, fecha_vencimiento, UnidadxCaja, Lote, cantidadStock, proveedor, ubicacion) " +
                                          "VALUES (@Id_producto, @Nombre, @Descripcion, @Valor_Producto, @Estado_Producto, @Fecha_Adquision, @Fecha_Caducidad, @UnidadxCaja, @Lote, @Cantidad_Stock, @Proveedor, @Ubicacion_Producto)";

                SqlCommand comando = new SqlCommand(consulta, cn);
                comando.Parameters.AddWithValue("@Id_producto", EP.IdProducto);
                comando.Parameters.AddWithValue("@Fecha_Adquision", EP.FechaAdquisicion);
                comando.Parameters.AddWithValue("@Nombre", EP.Nombre);
                comando.Parameters.AddWithValue("@Descripcion", EP.Descripcion);
                comando.Parameters.AddWithValue("@UnidadxCaja", EP.UnidadxCaja);
                comando.Parameters.AddWithValue("@Lote", EP.Lote);
                comando.Parameters.AddWithValue("@Cantidad_Stock", EP.CantidadStock);
                comando.Parameters.AddWithValue("@Ubicacion_Producto", EP.Ubicacion);
                comando.Parameters.AddWithValue("@Valor_Producto", EP.Valor);
                comando.Parameters.AddWithValue("@Proveedor", EP.Proveedor);
                comando.Parameters.AddWithValue("@Fecha_Caducidad", EP.FechaVencimiento);
                comando.Parameters.AddWithValue("@Estado_Producto", EP.Estado);
                cn.Open();
                comando.ExecuteNonQuery();
                return "Registro con exito!";
            }
            catch (Exception ex)
            {
                rpa = ex.Message;
            }
            finally 
            {
                if (cn.State == ConnectionState.Open) cn.Close(); ; 
            }
            return rpa;
        }

        /// <summary>
        /// Modifica los datos de un producto en el inventario.
        /// </summary>
        /// <param name="EP">La entidad E_productos con los nuevos datos del producto.</param>
        /// <returns>Un mensaje indicando el resultado de la modificación.</returns>
        public String Modificar_Inventario(E_productos EP)
        {
            String rpa = "";
            try
            {
                string consulta = "UPDATE B_productos SET nombre=@Nombre,descripcion=@Descripcion, valor=@Valor_Producto, estado=@Estado_Producto, fecha_adquisicion=@Fecha_Adquision," +
                    "fecha_vencimiento=@Fecha_Caducidad, unidadxcaja=@UnidadxCaja, lote=@Lote, cantidadStock=@Cantidad_Stock, proveedor=@Proveedor, ubicacion=@Ubicacion_Producto " +
                    "where Id_producto=@Id_producto";

                SqlCommand comando = new SqlCommand(consulta, cn);
                comando.Parameters.AddWithValue("@Id_producto", EP.IdProducto);
                comando.Parameters.AddWithValue("@Fecha_Adquision", EP.FechaAdquisicion);
                comando.Parameters.AddWithValue("@Nombre", EP.Nombre);
                comando.Parameters.AddWithValue("@Descripcion", EP.Descripcion);
                comando.Parameters.AddWithValue("@UnidadxCaja", EP.UnidadxCaja);
                comando.Parameters.AddWithValue("@Lote", EP.Lote);
                comando.Parameters.AddWithValue("@Cantidad_Stock", EP.CantidadStock);
                comando.Parameters.AddWithValue("@Ubicacion_Producto", EP.Ubicacion);
                comando.Parameters.AddWithValue("@Valor_Producto", EP.Valor);
                comando.Parameters.AddWithValue("@Proveedor", EP.Proveedor);
                comando.Parameters.AddWithValue("@Fecha_Caducidad", EP.FechaVencimiento);
                comando.Parameters.AddWithValue("@Estado_Producto", EP.Estado);
                cn.Open();
                comando.ExecuteNonQuery();
                return "Registro modificado con exito!";
            }
            catch (Exception ex)
            {
                rpa = ex.Message;
            }
            finally
            {
                if (cn.State == ConnectionState.Open) cn.Close(); 
            }
            return rpa;
        }

        /// <summary>
        /// Elimina un producto del inventario.
        /// </summary>
        /// <param name="EP">La entidad E_productos con el ID del producto a eliminar.</param>
        /// <returns>Un mensaje indicando el resultado de la eliminación.</returns>
        public String Eliminar_inventario(E_productos EP)
        {
            String rpa = "";
            try
            {
                String consulta = "delete from B_productos where id_producto =@Id_producto";
                SqlCommand comando = new SqlCommand(consulta, cn);
                comando.Parameters.AddWithValue("@Id_producto", EP.IdProducto);
                cn.Open();
                comando.ExecuteNonQuery();
                return "REGISTRO ELIMINADO";
            }
            catch (Exception ex)
            {
                rpa= ex.Message;
            }
            finally
            {
                if (cn.State == ConnectionState.Open) cn.Close();
            }
            return rpa;
        }
    }
}
