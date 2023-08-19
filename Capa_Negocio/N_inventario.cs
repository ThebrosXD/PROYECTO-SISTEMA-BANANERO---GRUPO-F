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
    public class N_inventario
    {
        D_Inventario DI=new D_Inventario();

        public DataTable Listado_inventario()
        {
            return DI.Listado_inventario();
        }

        public String Registrar_inventario(E_productos EP)
        {
            return DI.Registrar_Inventario(EP);
        }

        public String Modificar_inventario(E_productos EP)
        {
            return DI.Modificar_Inventario(EP);
        }

        public String Eliminar_inventario(E_productos EP)
        {
            return DI.Eliminar_inventario(EP);
        }
    }
}
