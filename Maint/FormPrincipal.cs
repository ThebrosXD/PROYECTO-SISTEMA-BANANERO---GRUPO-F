using Maint.Ventas;
using Maint.Inventario;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maint
{
    public partial class FormPrincipal : Form
    {

        public FormPrincipal()
        {
            InitializeComponent();
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

        //Cierra sesion del usuario logeado
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            FormLogin lgn = new FormLogin();
            this.Close();
            lgn.Show();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            abriFormPanel(new FormPedido());
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            abriFormPanel(new FormInventario());
        }
    }
}
