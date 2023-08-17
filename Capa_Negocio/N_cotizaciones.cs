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

        public List<E_usuario> ObtenerRegistrosInicioSesion()
        {
            return datosC.ObtenerRegistrosInicioSesion();
        }
    }
}
