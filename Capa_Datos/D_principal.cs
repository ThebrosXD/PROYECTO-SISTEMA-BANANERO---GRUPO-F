using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos
{
    public class D_principal
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);

        public List<E_usuario> ObtenerRegistrosInicioSesion(int cedula)
        {
            List<E_usuario> registros = new List<E_usuario>();

            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString))
            {
                cn.Open();
                using (SqlCommand command = new SqlCommand("select cedula, nombre, telefono, direccion, rol from B_usuario where cedula=@cedula", cn))
                {
                    command.Parameters.AddWithValue("@cedula", cedula);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            E_usuario registro = new E_usuario
                            {
                                cedula = Convert.ToInt32(reader["cedula"]),
                                nombre = reader["nombre"].ToString(),
                                telefono = Convert.ToInt32(reader["telefono"]),
                                direccion = reader["direccion"].ToString(),
                                rol = reader["rol"].ToString(),
                            };
                            registros.Add(registro);
                        }
                    }
                }
                cn.Close();
            }

            return registros;
        }
    }
}
