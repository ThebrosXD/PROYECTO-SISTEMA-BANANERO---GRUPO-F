/**
 * Este es la clase capa negocios de inventario
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
using Capa_Datos;
using Capa_Entidad;

namespace Capa_Negocio
{
    /// <summary>
    /// Clase que encapsula la lógica de negocio relacionada con el inventario de productos.
    /// </summary>
    public class N_inventario
    {
        D_Inventario DI=new D_Inventario();

        /// <summary>
        /// Obtiene un listado de productos en el inventario.
        /// </summary>
        /// <returns>Un objeto DataTable con los datos de los productos en el inventario.</returns>
        public DataTable Listado_inventario()
        {
            return DI.Listado_inventario();
        }

        /// <summary>
        /// Registra un nuevo producto en el inventario.
        /// </summary>
        /// <param name="EP">La entidad E_productos que contiene los datos del producto.</param>
        /// <returns>Un mensaje indicando el resultado de la operación.</returns>
        public String Registrar_inventario(E_productos EP)
        {
            return DI.Registrar_Inventario(EP);
        }

        /// <summary>
        /// Modifica los datos de un producto en el inventario.
        /// </summary>
        /// <param name="EP">La entidad E_productos que contiene los nuevos datos del producto.</param>
        /// <returns>Un mensaje indicando el resultado de la operación.</returns>
        public String Modificar_inventario(E_productos EP)
        {
            return DI.Modificar_Inventario(EP);
        }

        /// <summary>
        /// Elimina un producto del inventario.
        /// </summary>
        /// <param name="EP">La entidad E_productos que contiene los datos del producto a eliminar.</param>
        /// <returns>Un mensaje indicando el resultado de la operación.</returns>
        public String Eliminar_inventario(E_productos EP)
        {
            return DI.Eliminar_inventario(EP);
        }
    }
}
