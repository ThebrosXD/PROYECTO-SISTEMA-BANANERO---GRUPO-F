/**
 * Este es el formulario ventas de cotizaciones, 
 * @author Grupo F
 * @version   1.1
 * @return El mensaje usado para el saludo
 * Created on July 5, 2023, 4:24 AM
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Entidad; // Importa el espacio de nombres Capa_Entidad
using Capa_Negocio; // Importa el espacio de nombres Capa_Negocio

namespace Maint.Ventas
{
    public partial class FormCotizaciones : Form
    {
        E_cotizaciones EC = new E_cotizaciones();  // Crea una instancia de la entidad E_cotizaciones
        N_cotizaciones NC = new N_cotizaciones();  // Crea una instancia de la capa de negocio N_cotizaciones

        public FormCotizaciones()
        {
            InitializeComponent();
            CargardatosInicioSesion(); // Carga los datos de inicio de sesión
            txtPrecioT.TextChanged += txtPrecioT_TextChanged; // Asigna un evento al cambio en el campo de precio total
            txtCajas.TextChanged += txtCajas_TextChanged; // Asigna un evento al cambio en el campo de cajas
            dtpFechaActual.Value = DateTime.Now; // Establece la fecha actual en el DateTimePicker
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

        // Maneja el evento de clic en el botón "Registrar Pedido"
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

        // Maneja el evento de clic en el botón "Seguimiento"
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

        // Maneja el evento de clic en el botón "Cotización"
        private void btnCotizacion_Click(object sender, EventArgs e)
        {
            if (cmbProducto.Text.Equals("Eliga un producto") || (txtCajas.Text.Equals("")))
            {
                MensajeCamposEmpty();
            }
            else if (txtCotizacion.Text != "")
            {
                if (MessageBox.Show("sDeseas enviar la cotizacion?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    Mantenimiento("1");
                    limpiar();
                }
            }
        }

        // Obtiene el ID del producto seleccionado
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

        // Maneja el evento Load del formulario de cotizaciones
        private void FormCotizaciones_Load(object sender, EventArgs e)
        {
            cmbProducto.DataSource = NC.CargarProductosCMB(); // Carga datos en el ComboBox de productos
            cmbProducto.DisplayMember = "nombre";
            cmbProducto.ValueMember = "id_producto";
        }

        // Maneja el evento de cambio en la selección del ComboBox de productos
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

        // Actualiza el campo de precio total al cambiar el precio unitario o la cantidad de cajas
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

        // Maneja el evento de cambio en el campo de precio total
        private void txtPrecioT_TextChanged(object sender, EventArgs e)
        {
            ActualizarTOTAL();
        }

        // Maneja el evento de cambio en el campo de cajas
        private void txtCajas_TextChanged(object sender, EventArgs e)
        {
            ActualizarTOTAL();
        }

        // Carga los datos de inicio de sesión en los campos correspondientes
        private void CargardatosInicioSesion()
        {
            int usuario = E_Usuarioactual.UsuarioLogeado;
            List<E_usuario> registros = NC.ObtenerRegistrosInicioSesion(usuario);
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
