/**
 * Este es el formulario principal, de donde se puede ir a los demás formularios
 * @author Grupo F
 * @version   1.1
 * @return El mensaje usado para el saludo
 * Created on July 5, 2023, 4:24 AM
*/
using Maint.Ventas; // Importa el espacio de nombres Ventas
using Maint.Inventario; // Importa el espacio de nombres Inventario
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Entidad;
using Capa_Negocio;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Maint
{
    public partial class FormPrincipal : Form
    {
        N_pedidos NP= new N_pedidos();
        N_creacioncuenta Nc=new N_creacioncuenta();

        public FormPrincipal()
        {
            InitializeComponent();
            CargardatosInicioSesion();
            ActualizarBotonesSegunRol();
            // Configura los valores iniciales de los DateTimePickers
            dtpHora.Value = DateTime.Now;
            dtpFecha.Value = DateTime.Now;
        }

        //Abre un form hijo en un panel del form principal
        public void abriFormPanel(object Formhijo)
        {
            if (this.pnContenedor.Controls.Count > 0)
                this.pnContenedor.Controls.RemoveAt(0);
            Form fh = Formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.pnContenedor.Controls.Add(fh);
            this.pnContenedor.Tag = fh;
            fh.Show();
        }

        // Abre un formulario de seguimiento en el panel
        public void abrirFormSeguimiento()
        {
            FormSeguimiento se = new FormSeguimiento();
            se.TopLevel = false;
            se.FormBorderStyle = FormBorderStyle.None;
            se.Dock = DockStyle.Fill;
            pnContenedor.Controls.Clear();
            pnContenedor.Controls.Add(se);
            se.Show();
        }

        // Maneja el evento de clic en el botón "Cerrar Sesión"
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            FormLogin lgn = new FormLogin();
            this.Close();
            lgn.Show();
        }

        // Maneja el evento de clic en el botón "Ventas"
        private void btnVentas_Click(object sender, EventArgs e)
        {
            abriFormPanel(new FormPedido());
        }

        // Maneja el evento de clic en el botón "Inventario"
        private void btnInventario_Click(object sender, EventArgs e)
        {
            abriFormPanel(new FormInventario());
        }

        // Método para habilitar o deshabilitar los botones según el rol del usuario
        private void ActualizarBotonesSegunRol()
        {
            String rol = CargardatosInicioSesion();
            // Supongamos que "btnVentas" y "btnInventario" son los nombres de tus botones
            if (rol.Equals("Cliente"))
            {
                btnInventario.Enabled = true;
                btnVentas.Enabled = true;
            }
            else
            {
                btnVentas.Enabled = true;
                btnInventario.Enabled = false;
            }
        }

        // En algún lugar donde determines el rol del usuario, llama a esta función para actualizar los botones


        private String CargardatosInicioSesion()
        {
            String roll="";
            int usuario = E_Usuarioactual.user3;
            List<E_usuario> registros = Nc.ObtenerRegistrosInicioSesion(usuario);
            foreach (E_usuario registro in registros)
            {
                roll = registro.rol;
            }
            return roll;
        }
    }
}
