using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    public class E_usuario
    {
        public int cedula { get; set; }
        public String nombre { get; set; }
        public String apellido { get; set; }
        public int telefono { get; set; }
        public String direccion { get; set; }
        public String contrasena { get; set; }
        public String correo { get; set; }
        public DateTime fecha_registro { get; set; }
        public String rol { get; set; }
    }
}
