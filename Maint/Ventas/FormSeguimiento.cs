using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Negocio;
using Capa_Entidad;

namespace Maint.Ventas
{
    public partial class FormSeguimiento : Form
    {
        E_pedidos EP = new E_pedidos();
        N_pedidos EN = new N_pedidos();
        public FormSeguimiento()
        {
            InitializeComponent();
        }
        #region "Mis metodos"

        private void Formato_pe()
        {
            dgvPrincipal.Columns[0].Width=50;
            dgvPrincipal.Columns[0].HeaderText = "ID";
            dgvPrincipal.Columns[1].Width = 100;
            dgvPrincipal.Columns[1].HeaderText = "Identificacion";
            dgvPrincipal.Columns[2].Width = 50;
            dgvPrincipal.Columns[2].HeaderText = "ID_PRODUCTO";
            dgvPrincipal.Columns[3].Width = 100;
            dgvPrincipal.Columns[3].HeaderText = "Pago";
            dgvPrincipal.Columns[4].Width = 100;
            dgvPrincipal.Columns[4].HeaderText = "Fecha emitida";
            dgvPrincipal.Columns[5].Width = 100;
            dgvPrincipal.Columns[5].HeaderText = "Estado";
            dgvPrincipal.Columns[6].Width = 90;
            dgvPrincipal.Columns[6].HeaderText = "Precio Unitario";
            dgvPrincipal.Columns[7].Width = 90;
            dgvPrincipal.Columns[7].HeaderText = "Precio Total";
        }

        #endregion

        private void FormSeguimiento_Load(object sender, EventArgs e)
        {
            dgvPrincipal.DataSource = EN.Listado_pe();
            this.Formato_pe();
        }

        private void btnRegistrarPedido_Click(object sender, EventArgs e)
        {
            FormPedido FP = new FormPedido();

            // Llamar al método abriFormPanel de FormPrincipal para abrir FormSeguimiento dentro del panel
            FormPrincipal pe = this.ParentForm as FormPrincipal;
            if (pe != null)
            {
                pe.abriFormPanel(FP);
            }
        }
    }
}
