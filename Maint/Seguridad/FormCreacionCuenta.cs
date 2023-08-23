using Capa_Entidad; // Importa el espacio de nombres Capa_Entidad
using Capa_Negocio;  // Importa el espacio de nombres Capa_Negocio
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
        E_usuario EU=new E_usuario();
        N_creacioncuenta NC= new N_creacioncuenta();

        public FormCreacionCuenta()
        {
            InitializeComponent();
            MaximizeBox = false; // desabilitar el boton de maximizar ventana
            dtpFECHA.Value = DateTime.Now;
        }

        // Metodo limpiar textbox del formulario cuando se crea una cuenta
        void limpiar()
        {
            txtNombre.Text="";
            txtCedula.Text = "";
            txtApellido.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtContrasena.Text = "";
            txtCorreo.Text = "";
        }

        // Metodo para recoger los datos puesto en los textbox
        void Mantenimiento(String accion)
        {
            EU.cedula = Convert.ToInt32(txtCedula.Text);
            EU.nombre = txtNombre.Text;
            EU.apellido = txtApellido.Text;
            EU.correo = txtDireccion.Text;
            EU.telefono = int.Parse(txtTelefono.Text);
            EU.rol = cmbRol.Text;
            EU.direccion = txtCorreo.Text;
            EU.contrasena = txtContrasena.Text;
            EU.fecha_registro = dtpFECHA.Value;
            String me = NC.CrearCuenta(accion, EU);
            MessageBox.Show(me, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Metodo para volver a iniciar sesion
        private void button2_Click(object sender, EventArgs e)
        {
            FormLogin login=new FormLogin();
            login.Show();
            this.Close();
        }


        //Metodo para crear una cuenta nueva
        private void btnCrearCuenta_Click(object sender, EventArgs e)
        {
            
            if (txtNombre.Text != "")
            {
                if (MessageBox.Show("Desea continuar con el registro de la cuenta?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    Mantenimiento("1");
                    limpiar();
                }
            }
        }

        public int idMetodoROLES()
        {
            int id_producto = 0;
            if (cmbRol.SelectedItem != null)
            {
                DataRow select = (cmbRol.SelectedItem as DataRowView)?.Row;
                if (select != null)
                {
                    id_producto = Convert.ToInt32(select["id_rol"]);
                }
            }
            return id_producto;
        }

        // Maneja el evento Load del formulario de roles
        private void FormCreacionCuenta_Load(object sender, EventArgs e)
        {
            cmbRol.DataSource = NC.CargarRoles(); // Carga datos en el ComboBox de productos
            cmbRol.DisplayMember = "nombre";
            cmbRol.ValueMember = "id_rol";
        }
    }
    
}
