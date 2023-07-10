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
using static System.Net.Mime.MediaTypeNames;

namespace Maint.Seguridad
{
    public partial class FormCreacionCuenta : Form
    {
        public FormCreacionCuenta()
        {
            InitializeComponent();
        }

        SqlConnection cn = new SqlConnection("SERVER=DESKTOP-R2245IH;DATABASE=DBBanano;INTEGRATED SECURITY=true");

        private void button2_Click(object sender, EventArgs e)
        {
            FormLogin login=new FormLogin();
            login.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cn.Open();
            SqlCommand cmd1 = new SqlCommand("select * from clientesB where cedula=@cedula", cn);
            cmd1.Parameters.AddWithValue("@cedula", txtCedula.Text);
            SqlDataReader resultV = cmd1.ExecuteReader();
            if (resultV.HasRows == true)
            {
                MessageBox.Show("El usuario ya existe, intente de nuevo! ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                resultV.Close();
                SqlCommand cmd = new SqlCommand("insert into clientesB (cedula, nombre, contrasena, direccion, correo, telefono, rol) values (@cedula, @nombre, @contrasena, @direccion, @correo, @telefono, @rol)", cn);
                cmd.Parameters.AddWithValue("@cedula", txtCedula.Text);
                cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@contrasena", txtContrasena.Text);
                cmd.Parameters.AddWithValue("@direccion", txtDireccion.Text);
                cmd.Parameters.AddWithValue("@correo", txtCorreo.Text);
                cmd.Parameters.AddWithValue("@telefono", txtTelefono.Text);
                cmd.Parameters.AddWithValue("@rol", cmbRol.Text);

                SqlDataReader resultC = cmd.ExecuteReader();
                MessageBox.Show("El Usuario a sido registrado exitosamente! ", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            cn.Close();
        }
    }
    
}
