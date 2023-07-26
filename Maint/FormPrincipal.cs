using Maint.Ventas;
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

        private void button4_Click(object sender, EventArgs e)
        {
            abriFormPanel(new FormVentas());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FormLogin lgn = new FormLogin();
            this.Close();
            lgn.Show();
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
    }
}
