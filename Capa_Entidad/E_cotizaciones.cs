using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    public class E_cotizaciones
    {
        public int id_cotizacion { get; set; }
        public int id_cedula { get; set; }
        public int id_producto { get; set; }
        public float precioUNI { get; set; }
        public float precioTOTAL { get; set; }
        public String estado { get; set; }
        public DateTime fecha_cotizacion { get; set; }
        public DateTime fecha_aceptacion { get; set; }
        public String comentarios { get; set; }

    }
}
