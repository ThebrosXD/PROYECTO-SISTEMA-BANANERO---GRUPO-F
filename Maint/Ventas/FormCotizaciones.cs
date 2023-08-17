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

namespace Maint.Ventas
{
    public partial class FormCotizaciones : Form
    {
        E_cotizaciones EC = new E_cotizaciones();
        N_cotizaciones NC= new N_cotizaciones();

        public FormCotizaciones()
        {
            InitializeComponent();
            CargardatosInicioSesion();
            txtPrecioT.TextChanged += txtPrecioT_TextChanged;
            txtCajas.TextChanged += txtCajas_TextChanged;
            dtpFechaActual.Value = DateTime.Now;
        }
        #region mis metodos
        void limpiar()
        {
            txtCajas.Text = "";
            txtDetalles.Text = "";
            txtPrecioU.Text = "";
        }

        void Mantenimiento(String accion)
        {
            EC.id_cotizacion = 1;
            EC.id_cedula = Convert.ToInt32(txtCedula.Text);
            EC.id_producto = idMetodoProducto();
            EC.precioUNI = float.Parse(txtPrecioU.Text);
            EC.precioTOTAL = float.Parse(txtPrecioT.Text);
            EC.fecha_cotizacion = dtpFechaActual.Value;
            EC.fecha_aceptacion = dtpFechaActual.Value;
            EC.comentarios = txtDetalles.Text;
            EC.estado = "PENDIENTE";
            String me = NC.Registrar_cotizacion(accion, EC);
            MessageBox.Show(me, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MensajeCamposEmpty()
        {
            MessageBox.Show("Rellene los campos para registrar el pedido!", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        #endregion

        private void btnRegistrarPedido_Click(object sender, EventArgs e)
        {
            // Crear una instancia de Formulario3
            FormPedido PE = new FormPedido();

            // Llamar al método abriFormPanel de FormPrincipal para abrir FormSeguimiento dentro del panel
            FormPrincipal PR = this.ParentForm as FormPrincipal;
            if (PR != null)
            {
                PR.abriFormPanel(PE);
            }
        }

        private void btnSeguimiento_Click(object sender, EventArgs e)
        {
            // Crear una instancia de Formulario3
            FormSeguimiento se = new FormSeguimiento();

            // Llamar al método abriFormPanel de FormPrincipal para abrir FormSeguimiento dentro del panel
            FormPrincipal PR = this.ParentForm as FormPrincipal;
            if (PR != null)
            {
                PR.abriFormPanel(se);
            }
        }

        private void btnCotizacion_Click(object sender, EventArgs e)
        {
            if (cmbProducto.Text.Equals("Eliga un producto") || (txtCajas.Text.Equals("")))
            {
                MensajeCamposEmpty();
            }
            else if (txtCotizacion.Text != "")
            {
                if (MessageBox.Show("?Deseas enviar la cotizacion?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    Mantenimiento("1");
                    limpiar();
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

        private void FormCotizaciones_Load(object sender, EventArgs e)
        {
            cmbProducto.DataSource = NC.CargarProductosCMB();
            cmbProducto.DisplayMember = "nombre";
            cmbProducto.ValueMember = "id_producto";
        }

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProducto.SelectedItem != null)
            {
                DataRow select = (cmbProducto.SelectedItem as DataRowView)?.Row;
                if (select != null)
                {
                    object val = select["valor"];
                    if (!Convert.IsDBNull(val))
                    {
                        limpiar();
                        decimal valor = Convert.ToDecimal(select["valor"]);
                        txtPrecioU.Text = valor.ToString();
                        String Des = Convert.ToString(select["descripcion"]);
                        String estado = Convert.ToString(select["estado"]);
                        String total = "Descripcion: " + Des + " \n" + "\n Estado: " + estado;
                        txtDetalles.Text = total;
                    }
                    else
                    {
                        limpiar();
                    }
                }
            }
        }
        private void ActualizarTOTAL()
        {
            if (float.TryParse(txtPrecioU.Text, out float precioU) && int.TryParse(txtCajas.Text, out int cajas))
            {
                float preciototal = precioU * cajas;
                txtPrecioT.Text = preciototal.ToString();
            }
            else if (String.IsNullOrEmpty(txtCajas.Text))
            {
                float preciototal = 0;
                txtPrecioT.Text = preciototal.ToString();
            }
            else if (char.IsDigit(Convert.ToChar(txtCajas.Text)) && cmbProducto.Text.Equals("Eliga un producto"))
            {
                txtCajas.Text = "";
                MessageBox.Show("Selecione un producto!", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                txtCajas.Text = "";
                MessageBox.Show("Ingrese las cajas en numero!", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtPrecioT_TextChanged(object sender, EventArgs e)
        {
            ActualizarTOTAL();
        }

        private void txtCajas_TextChanged(object sender, EventArgs e)
        {
            ActualizarTOTAL();
        }

        private void CargardatosInicioSesion()
        {
            List<E_usuario> registros = NC.ObtenerRegistrosInicioSesion();
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
