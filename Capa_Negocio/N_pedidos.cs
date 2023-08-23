/**
 * Este es la clase capa negocio de pedidos
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
using System.Data;
using System.Data.SqlClient;
using Capa_Entidad;
using Capa_Datos;

namespace Capa_Negocio
{
    public class N_pedidos
    {
        D_pedidos datosD = new D_pedidos();
        /**public DataTable Listado_pe()
        {
            return datosD.Listado_pe();
        }*/

        /// <summary>
        /// Realiza operaciones de mantenimiento de pedidos, como registrar, modificar o eliminar.
        /// </summary>
        /// <param name="accion">La acción a realizar (registro, modificación, eliminación).</param>
        /// <param name="oPE">La entidad E_pedidos que contiene los datos del pedido.</param>
        /// <returns>Un mensaje indicando el resultado de la operación.</returns>
        public String Mantenimiento_pedido(String accion, E_pedidos oPE)
        {
            return datosD.Registrar_pedido(accion, oPE);
        }

        /// <summary>
        /// Carga los productos disponibles en un objeto DataTable.
        /// </summary>
        /// <returns>Un objeto DataTable con los productos disponibles.</returns>
        public DataTable CargarProductosCMB()
        {
            return datosD.CargarProductosCMB();
        }

        /// <summary>
        /// Carga los métodos de pago disponibles en un objeto DataTable.
        /// </summary>
        /// <returns>Un objeto DataTable con los métodos de pago disponibles.</returns>
        public DataTable CargarMPagoCMB()
        {
            return datosD.CargarMPagoCMB();
        }

        /// <summary>
        /// Obtiene registros de inicio de sesión de usuarios.
        /// </summary>
        /// <returns>Una lista de entidades E_usuario con los registros de inicio de sesión.</returns>
        public List<E_usuario> ObtenerRegistrosInicioSesion(int cedula)
        {
            return datosD.ObtenerRegistrosInicioSesion(cedula);
        }

        /// <summary>
        /// Elimina un pedido en base a su código.
        /// </summary>
        /// <param name="codigo">El código del pedido a eliminar.</param>
        /// <returns>Un mensaje indicando el resultado de la operación.</returns>
        public String Eliminar_pedido(int codigo)
        {
            return datosD.Eliminar_pedido(codigo);
        }

        public DataTable Tablas_seguimiento(int USER)
        {
            return datosD.Tablas_seguimiento(USER);
        }

        public DataTable BuscarPedido(int codigo)
        {
            return datosD.BuscarPedido(codigo);
        }

        public DataTable BuscarCotizacion(int codigo)
        {
            return datosD.BuscarCotizacion(codigo);
        }

        public String Eliminar_cotizacion(int codigo)
        {
            return datosD.Eliminar_cotizacion(codigo);
        }
        
        public DataTable Tablas_seguimientoCoti(int USER)
        {
            return datosD.Tablas_seguimientoCoti(USER);
        }
    }
}
