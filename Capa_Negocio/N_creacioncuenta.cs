/**
 * Este es la clase capa negocio de creacion de cuenta
 * @author Grupo F
 * @version   1.1
 * @return El mensaje usado para el saludo
 * Created on July 5, 2023, 4:24 AM
*/
using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using System.Data;

namespace Capa_Negocio
{
    public class N_creacioncuenta
    {
        D_creacioncuenta DC=new D_creacioncuenta();
        D_principal dp=new D_principal();

        /// <summary>
        /// Crea una cuenta en el aplicativo.
        /// </summary>
        /// <param name="accion">La acción a realizar (registro, modificación, eliminación).</param>
        /// <param name="USER">La entidad E_usuario que contiene los datos del usuario.</param>
        /// <returns>Un mensaje indicando que la cuenta ha sido creada.</returns>
        public String CrearCuenta(String accion, E_usuario USER)
        {
            return DC.CrearCuenta(accion,USER);
        }

        public DataTable CargarRoles()
        {
            return DC.CargarRoles();
        }

        public List<E_usuario> ObtenerRegistrosInicioSesion(int user3)
        {
            return dp.ObtenerRegistrosInicioSesion(user3);
        }
    }
}
