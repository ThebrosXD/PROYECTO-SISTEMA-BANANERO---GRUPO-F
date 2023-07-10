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

namespace Maint
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }
        SqlConnection cn = new SqlConnection("SERVER=DESKTOP-R2245IH;DATABASE=DBBanano;INTEGRATED SECURITY=true");

        private void button1_Click(object sender, EventArgs e)
        {
            cn.Open();
            this.Hide();
            SqlCommand cmd = new SqlCommand("SELECT cedula, contrasena FROM clientesB WHERE cedula=@cedula AND contrasena=@contrasena", cn);
            cmd.Parameters.AddWithValue("@cedula", txtUsuario.Text);
            cmd.Parameters.AddWithValue("@contrasena", txtContrasena.Text);

             SqlDataReader result = cmd.ExecuteReader();
             if (result.Read())
             {
                    cn.Close();
                    FormPrincipal pantalla = new FormPrincipal();
                    pantalla.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string nueva = Application.StartupPath + "\\seguridad\\FormCreacionCuenta.cs";
            FormCreacionCuenta nu = new FormCreacionCuenta();
            this.Hide();
            nu.Show();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
