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
using Capa_Entidad;
using Capa_Negocio;

namespace Maint
{
    public partial class FormPedido : Form
    {
        E_pedidos Ep = new E_pedidos();
        N_pedidos En = new N_pedidos();

        public FormPedido()
        {
            InitializeComponent();
            CargardatosInicioSesion();
            txtCajas.TextChanged += TxtCajas_TextChanged;
            txtPrecioT.TextChanged += TxtPrecioT_TextChanged;
            dtpFechaActual.Value = DateTime.Now;
        }

        private void TxtPrecioT_TextChanged(object sender, EventArgs e)
        {
            ActualizarTOTAL();
        }

        private void TxtCajas_TextChanged(object sender, EventArgs e)
        {
            ActualizarTOTAL();
        }

        private void btnSeguimiento_Click(object sender, EventArgs e)
        {
            // Crear una instancia de Formulario3
            FormSeguimiento se = new FormSeguimiento();

            // Llamar al método abriFormPanel de FormPrincipal para abrir FormSeguimiento dentro del panel
            FormPrincipal pe = this.ParentForm as FormPrincipal;
            if (pe != null)
            {
                pe.abriFormPanel(se);
            }
        }
        #region mis metodos
        void limpiar()
        {
            cmbProducto.Text = "";
            txtCajas.Text = "";
            txtPrecioU.Text = "";
            txtPrecioT.Text = "";
            txtDetalles.Text = "";
            txtDetalles.Text = "";
        }

        void Mantenimiento(String accion)
        {
            Ep.Id_pe = 1;
            Ep.Cedula_pe = Convert.ToInt32(txtCedula.Text);
            Ep.Producto_pe = idMetodoProducto();
            Ep.Mpago_pe = cmbMetodoPago.Text;
            Ep.Fecha_pe = dtpFechaActual.Value;
            Ep.PrecioUNI_pe = float.Parse(txtPrecioU.Text);
            Ep.PrecioTOT_pe = float.Parse(txtPrecioT.Text);
            Ep.descripcion = txtDetalles.Text;
            Ep.Estado = "PENDIENTE";
            String me = En.Mantenimiento_pedido(accion, Ep);
            MessageBox.Show(me, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ActualizarTOTAL()
        {
            //float precioU = float.Parse(txtPrecioU.Text);
            //int cajas = int.Parse(txtCajas.Text);
            if (float.TryParse(txtPrecioU.Text, out float precioU) && int.TryParse(txtCajas.Text, out int cajas))
            {
                float preciototal = precioU * cajas;
                txtPrecioT.Text = preciototal.ToString();
            }
            else if(String.IsNullOrEmpty(txtCajas.Text))
            {
                float preciototal = 0;
                txtPrecioT.Text = preciototal.ToString();
            }
            else
            {
                txtCajas.Text = "";
                MessageBox.Show("Ingrese las cajas en numero!", "Aviso del sistem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion 

        private void btnPedido_Click(object sender, EventArgs e)
        {
            if (txtPedido.Text == "")
            {
                if (MessageBox.Show("Deseas registrar el pedido?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    Mantenimiento("1");
                    limpiar();
                }
            }
        }

        private void FormPedido_Load(object sender, EventArgs e)
        {
            /** COMBOX 1 - CARGA DE PRODUCTOS**/
            cmbProducto.DataSource = En.CargarProductosCMB();
            cmbProducto.DisplayMember = "nombre";
            cmbProducto.ValueMember = "id_producto";
            /** COMBOX 2 - CARGA DE METODOS DE PAGO**/
            cmbMetodoPago.DataSource = En.CargarMPagoCMB();
            cmbMetodoPago.DisplayMember = "nombre";
            cmbMetodoPago.ValueMember = "id_Mpago";
        }

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProducto.SelectedItem != null)
            {
                DataRow select = (cmbProducto.SelectedItem as DataRowView)?.Row;
                if (select != null)
                {
                    decimal valor = Convert.ToDecimal(select["valor"]);
                    txtPrecioU.Text = valor.ToString();
                }
            }
        }

        public int idMetodoProducto()
        {
            int id_producto = 0;
            if (cmbProducto.SelectedItem != null)
            {
                DataRow select = (cmbProducto.SelectedItem as DataRowView)?.Row;
                if (select != null)
                {
                    id_producto = Convert.ToInt32(select["id_producto"]);
                }
            }
            return id_producto;
        }

        private void CargardatosInicioSesion()
        {
            List<E_usuario> registros = En.ObtenerRegistrosInicioSesion();
            foreach (E_usuario registro in registros)
            {
                txtCedula.Text = Convert.ToString(registro.cedula);
                txtNombre.Text = registro.nombre;
                txtTelefono.Text = Convert.ToString(registro.telefono);
                txtDireccion.Text = registro.direccion;
            }
        }
    }
}
