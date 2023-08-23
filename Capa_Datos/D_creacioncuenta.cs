/**
 * Este es la clase capa datos de crear cuenta
 * @author Grupo F
 * @version   1.1
 * @return El mensaje usado para el saludo
 * Created on July 5, 2023, 4:24 AM
*/
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidad;


namespace Capa_Datos
{
    public class D_creacioncuenta
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);

        /// <summary>
        /// Registra un nuevo producto en el inventario.
        /// </summary>
        /// <param name="accion">accion para crear la cuenta.</param>
        /// <param name="USER">La entidad E_usuarios con los nuevos datos del usuario.</param>
        /// <returns>Un mensaje indicando que se ha creado con exito la cuenta</returns>
        public String CrearCuenta(String accion, E_usuario USER)
        {
            String rpa = "";
            cn.Open();
            SqlCommand cmd1 = new SqlCommand("select * from B_usuario where cedula=@cedula", cn);
            cmd1.Parameters.AddWithValue("@cedula", USER.cedula);
            SqlDataReader resultV = cmd1.ExecuteReader();
            if (resultV.HasRows == true)
            {
                rpa="El usuario ya existe, intente de nuevo! ";
            }
            else
            {
                resultV.Close();
                SqlCommand cmd = new SqlCommand("Crearcuenta_usuario", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cedula", USER.cedula);
                cmd.Parameters.AddWithValue("@nombre", USER.nombre);
                cmd.Parameters.AddWithValue("@apellido", USER.apellido);
                cmd.Parameters.AddWithValue("@contrasena", USER.contrasena);
                cmd.Parameters.AddWithValue("@direccion", USER.direccion);
                cmd.Parameters.AddWithValue("@correo", USER.correo);
                cmd.Parameters.AddWithValue("@telefono", USER.telefono);
                cmd.Parameters.AddWithValue("@fecha_registro", USER.fecha_registro);
                cmd.Parameters.AddWithValue("@rol", USER.rol);
                cmd.Parameters.Add("@accion", SqlDbType.VarChar, 100).Value = accion;
                cmd.Parameters["@accion"].Direction = ParameterDirection.InputOutput;
                SqlDataReader resultC = cmd.ExecuteReader();
                accion = cmd.Parameters["@accion"].Value.ToString();
                return accion;
            }
            cn.Close();

            return rpa;
        }

        public DataTable CargarRoles()
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("select id_rol, nombre from B_rol", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            DataRow fila = dt.NewRow();
            fila["nombre"] = "Eliga un rol";
            dt.Rows.InsertAt(fila, 0);
            cn.Close();
            return dt;
        }
    }
}
