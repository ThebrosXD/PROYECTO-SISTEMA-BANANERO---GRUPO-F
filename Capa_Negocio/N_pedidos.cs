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
        public DataTable Listado_pe()
        {
            return datosD.Listado_pe();
        }

    }
}
