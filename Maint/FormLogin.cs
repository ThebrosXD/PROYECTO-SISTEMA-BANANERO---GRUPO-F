
/**
 * Este es el formulario de logeo, requisito para ingresar al formulario principal
 * @author Grupo F
 * @version   1.1
 * @return El mensaje usado para el saludo
 * Created on July 5, 2023, 4:24 AM
*/
using Capa_Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Maint;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Web;
using Maint.Seguridad;
using Capa_Entidad;

namespace Maint
{
    public partial class FormLogin : Form
    {

        public FormLogin()
        {
            InitializeComponent();
            MaximizeBox = false;
        }

        // Crear una conexión a la base de datos DBBanano
        SqlConnection cn = new SqlConnection("SERVER=DESKTOP-R2245IH;DATABASE=DBBanano;INTEGRATED SECURITY=true");

        // Maneja el evento de clic en el botón de inicio de sesión
        private void button1_Click(object sender, EventArgs e)
        {
            cn.Open(); // Abre la conexión a la base de datos
            this.Hide(); // Oculta el formulario actual
            // Crea un comando SQL para seleccionar la cédula y contraseña del usuario
            SqlCommand cmd = new SqlCommand("SELECT cedula, contrasena FROM B_usuario WHERE cedula=@cedula AND contrasena=@contrasena", cn);
            cmd.Parameters.AddWithValue("@cedula", txtUsuario.Text);
            cmd.Parameters.AddWithValue("@contrasena", txtContrasena.Text);

             SqlDataReader result = cmd.ExecuteReader(); // Ejecuta el comando y obtiene el resultado
            if (result.Read())
             {
                    cn.Close();
                    FormPrincipal pantalla = new FormPrincipal();
                    pantalla.Show(); // Muestra el formulario principal
            }
            E_Usuarioactual.UsuarioLogeado= Convert.ToInt32(txtUsuario.Text); //guarda el usuario que inicio sesion
            E_Usuarioactual.user2 = Convert.ToInt32(txtUsuario.Text);
            E_Usuarioactual.user3 = Convert.ToInt32(txtUsuario.Text);
        }

        // Maneja el evento de clic en el botón para crear una cuenta
        private void button2_Click(object sender, EventArgs e)
        {
            string nueva = Application.StartupPath + "\\seguridad\\FormCreacionCuenta.cs"; // Obtiene la ruta del formulario de creación de cuenta
            FormCreacionCuenta nu = new FormCreacionCuenta(); // Crea una instancia del formulario de creación de cuenta
            this.Hide();  // Oculta el formulario actual
            nu.Show(); // Muestra el formulario de creación de cuenta
        }
    }
}
