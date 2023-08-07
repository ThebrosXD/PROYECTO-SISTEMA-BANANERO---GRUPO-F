using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    public class E_pedidos
    {
        public int Id_pe { get; set; }
        public int Cedula_pe { get; set; }
        public int Producto_pe { get; set; }
        public String Mpago_pe { get; set; }
        public DateTime Fecha_pe { get; set; }
        public String Estado { get; set; }
        public float PrecioUNI_pe { get; set; }
        public float PrecioTOT_pe { get; set; }
    }
}
