using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    public class E_productos
    {
        public int IdProducto { get; set; }
        public DateTime FechaAdquisicion { get; set; }
        public String Nombre { get; set; }
        public String Descripcion { get; set; }
        public decimal UnidadxCaja { get; set; }
        public String Lote { get; set; }
        public int CantidadStock { get; set; }
        public string Ubicacion { get; set; }
        public decimal Valor { get; set; }
        public String Proveedor { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string Estado { get; set; }
    }
}
