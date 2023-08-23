/**
 * Este es la clase capa negocio de cotizaciones
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
    /// Clase que encapsula la lógica de negocio relacionada con las cotizaciones.
    /// </summary>
    public class N_cotizaciones
    {

        D_cotizaciones datosC= new D_cotizaciones();

        public DataTable listado_co()
        {
            return datosC.Listado_CO();
        }

       public DataTable CargarProductosCMB_CO()
        {
            return datosC.CargarProductosCMB_CO();
        }

        public String Registrar_cotizacion(String accion, E_cotizaciones oCO)
        {
            return datosC.Registrar_cotizacion(accion, oCO);
        }
        public DataTable CargarProductosCMB()
        {
            return datosC.CargarProductosCMB();
        }

        public List<E_usuario> ObtenerRegistrosInicioSesion(int usuario)
        {
            return datosC.ObtenerRegistrosInicioSesion(usuario);
        }
    }
}
