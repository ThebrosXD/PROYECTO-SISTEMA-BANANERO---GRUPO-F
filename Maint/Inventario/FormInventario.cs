using Capa_Entidad;
using Capa_Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maint.Inventario
{
    public partial class FormInventario : Form
    {
        private bool modoEdicion = false;
        private bool camposVisibles = true;
        N_inventario NI= new N_inventario();
        E_productos EP = new E_productos();

        public FormInventario()
        {
            InitializeComponent();
            dtpFechaActual.Value = DateTime.Now;
            dtpFechaVencimiento.Value = DateTime.Now;
        }

        private void limpiar_casillas()
        {
            txtBuscaCodigo.Clear();
        }

        private void LimpiarCampos()
        {
            BoxId.Text = "";
            BoxNombre.Text = "";
            BoxDescripciónP.Text = "";
            BoxUnidadxCaja.Text = "";
            BoxLote.Text = "";
            BoxCantidadS.Text = "";
            BoxUbicacionP.Text = "";
            BoxValorP.Text = "";
            BoxProveedor.Text = "";
            BoxEstadoP.Text = "";
            dtpFechaVencimiento.Text = "";
        }

        private void btnMostarCampos_Click(object sender, EventArgs e)
        {
            // Mostrar los campos de nombre y fecha
            BoxId.Visible = true;
            dtpFechaActual.Visible = true;
            BoxNombre.Visible = true;
            BoxDescripciónP.Visible = true;
            BoxUnidadxCaja.Visible = true;
            BoxLote.Visible = true;
            BoxCantidadS.Visible = true;
            BoxUbicacionP.Visible = true;
            BoxValorP.Visible = true;
            BoxProveedor.Visible = true;
            dtpFechaVencimiento.Visible = true;
            BoxEstadoP.Visible = true;

            // Actualizar la variable que indica el estado de los campos
            camposVisibles = true;

        }

        private void btnOcultarCampos_Click(object sender, EventArgs e)
        {
            // Mostrar los campos de nombre y fecha
            BoxId.Visible = false;
            dtpFechaActual.Visible = false;
            BoxNombre.Visible = false;
            BoxDescripciónP.Visible = false;
            BoxUnidadxCaja.Visible = false;
            BoxLote.Visible = false;
            BoxCantidadS.Visible = false;
            BoxUbicacionP.Visible = false;
            BoxValorP.Visible = false;
            BoxProveedor.Visible = false;
            dtpFechaVencimiento.Visible = false;
            BoxEstadoP.Visible = false;

            // Actualizar la variable que indica el estado de los campos
            camposVisibles = false;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            // Limpiar los campos de búsqueda, nombre y fecha
            BoxId.Text = "";
            dtpFechaActual.Text = "";
            BoxNombre.Text = "";
            BoxDescripciónP.Text = "";
            BoxUnidadxCaja.Text = "";
            BoxLote.Text = "";
            BoxCantidadS.Text = "";
            BoxUbicacionP.Text = "";
            BoxValorP.Text = "";
            BoxProveedor.Text = "";
            dtpFechaVencimiento.Text = "";
            BoxEstadoP.Text = "";
        }

        private void HabilitarEdicion(bool habilitar)
        {
            BoxId.ReadOnly = !habilitar;
            BoxNombre.ReadOnly = !habilitar;
            BoxDescripciónP.ReadOnly = !habilitar;
            BoxUnidadxCaja.ReadOnly = !habilitar;
            BoxLote.ReadOnly = !habilitar;
            BoxCantidadS.ReadOnly = !habilitar;
            BoxUbicacionP.ReadOnly = !habilitar;
            BoxValorP.ReadOnly = !habilitar;
            BoxProveedor.ReadOnly = !habilitar;
            BoxEstadoP.ReadOnly = !habilitar;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!modoEdicion)
            {
                // Cambiar los atributos ReadOnly para habilitar la edición
                HabilitarEdicion(true);

                // Cambiar el estado del modo de edición
                modoEdicion = true;

                // Bloquear el botón btnAgregar
                btnAgregar.Enabled = false;

                // Mostrar un mensaje al usuario
                MessageBox.Show("Los campos están en modo de edición. Puede realizar cambios ahora.");

            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            E_productos EP = new E_productos();
            // Verificar que los campos no estén vacíos antes de agregar el nuevo registro
            if (!string.IsNullOrWhiteSpace(BoxId.Text) && !string.IsNullOrWhiteSpace(dtpFechaActual.Text) && !string.IsNullOrWhiteSpace(BoxDescripciónP.Text) && !string.IsNullOrWhiteSpace(BoxUnidadxCaja.Text) && !string.IsNullOrWhiteSpace(BoxLote.Text) && !string.IsNullOrWhiteSpace(BoxCantidadS.Text)
                && !string.IsNullOrWhiteSpace(BoxUbicacionP.Text) && !string.IsNullOrWhiteSpace(BoxValorP.Text) && !string.IsNullOrWhiteSpace(BoxProveedor.Text) && !string.IsNullOrWhiteSpace(dtpFechaVencimiento.Text) && !string.IsNullOrWhiteSpace(BoxEstadoP.Text))
            {
                EP.IdProducto = Convert.ToInt32(BoxId.Text);
                EP.Nombre = BoxNombre.Text;
                EP.Descripcion = BoxDescripciónP.Text;
                EP.Valor = Convert.ToDecimal(BoxValorP.Text);
                EP.Estado = BoxEstadoP.Text;
                EP.FechaAdquisicion = dtpFechaActual.Value;
                EP.FechaVencimiento = dtpFechaVencimiento.Value;
                EP.UnidadxCaja = Convert.ToDecimal(BoxUnidadxCaja.Text);
                EP.Lote = BoxLote.Text;
                EP.CantidadStock = Convert.ToInt32(BoxCantidadS.Text);
                EP.Proveedor = BoxProveedor.Text;
                EP.Ubicacion = BoxUbicacionP.Text;
                try
                {
                    String me = NI.Registrar_inventario(EP);
                    MessageBox.Show(me, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al agregar el registro: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Por favor, complete todos los campos antes de agregar un nuevo registro.");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            E_productos EP = new E_productos();
            // Verificar que los campos no estén vacíos antes de agregar el nuevo registro
            if (!string.IsNullOrWhiteSpace(BoxId.Text) && !string.IsNullOrWhiteSpace(dtpFechaActual.Text) && !string.IsNullOrWhiteSpace(BoxDescripciónP.Text) && !string.IsNullOrWhiteSpace(BoxUnidadxCaja.Text) && !string.IsNullOrWhiteSpace(BoxLote.Text) && !string.IsNullOrWhiteSpace(BoxCantidadS.Text)
                && !string.IsNullOrWhiteSpace(BoxUbicacionP.Text) && !string.IsNullOrWhiteSpace(BoxValorP.Text) && !string.IsNullOrWhiteSpace(BoxProveedor.Text) && !string.IsNullOrWhiteSpace(dtpFechaVencimiento.Text) && !string.IsNullOrWhiteSpace(BoxEstadoP.Text))
            {
                EP.IdProducto = Convert.ToInt32(BoxId.Text);
                EP.Nombre = BoxNombre.Text;
                EP.Descripcion = BoxDescripciónP.Text;
                EP.Valor = Convert.ToDecimal(BoxValorP.Text);
                EP.Estado = BoxEstadoP.Text;
                EP.FechaAdquisicion = dtpFechaActual.Value;
                EP.FechaVencimiento = dtpFechaVencimiento.Value;
                EP.UnidadxCaja = Convert.ToDecimal(BoxUnidadxCaja.Text);
                EP.Lote = BoxLote.Text;
                EP.CantidadStock = Convert.ToInt32(BoxCantidadS.Text);
                EP.Proveedor = BoxProveedor.Text;
                EP.Ubicacion = BoxUbicacionP.Text;
                try
                {
                    String me = NI.Modificar_inventario(EP);
                    MessageBox.Show(me, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvInventario.DataSource = NI.Listado_inventario();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al modificar el registro: " + ex.Message);
                }

            }
            else
            {
                MessageBox.Show("Por favor, complete todos los campos antes de modificar un registro.");
            }
        }

        private void DataGridViewInventario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvInventario.Rows.Count - 1)
            {

                BoxId.Text = dgvInventario.SelectedCells[0].Value.ToString();
                BoxNombre.Text = dgvInventario.SelectedCells[1].Value.ToString();
                BoxDescripciónP.Text = dgvInventario.SelectedCells[2].Value.ToString();
                BoxValorP.Text = dgvInventario.SelectedCells[3].Value.ToString();
                BoxEstadoP.Text = dgvInventario.SelectedCells[4].Value.ToString();
                if (DateTime.TryParse(dgvInventario.SelectedCells[5].Value.ToString(), out DateTime fechaa))
                {
                    dtpFechaActual.Value = fechaa;
                }
                if (DateTime.TryParse(dgvInventario.SelectedCells[6].Value.ToString(), out DateTime fechav))
                {
                    dtpFechaVencimiento.Value = fechav;
                }
                BoxUnidadxCaja.Text = dgvInventario.SelectedCells[7].Value.ToString();
                BoxLote.Text = dgvInventario.SelectedCells[8].Value.ToString();
                BoxCantidadS.Text = dgvInventario.SelectedCells[9].Value.ToString();
                BoxProveedor.Text = dgvInventario.SelectedCells[10].Value.ToString();
                BoxUbicacionP.Text = dgvInventario.SelectedCells[11].Value.ToString();
                
                
                // Deshabilitar la edición de los campos de texto
                BoxId.ReadOnly = true;
                dtpFechaActual.Visible = true;
                BoxNombre.ReadOnly = true;
                BoxDescripciónP.ReadOnly = true;
                BoxUnidadxCaja.ReadOnly = true;
                BoxLote.ReadOnly = true;
                BoxCantidadS.ReadOnly = true;
                BoxUbicacionP.ReadOnly = true;
                BoxValorP.ReadOnly = true;
                BoxProveedor.ReadOnly = true;
                dtpFechaVencimiento.Visible = true;
                BoxEstadoP.ReadOnly = true;

                // Mostrar un mensaje al usuario
                MessageBox.Show("Los campos están en modo de solo lectura. \nPara editarlos, haga clic en el botón de 'EDITAR'.","Mensaje");
                dgvInventario.DataSource = NI.Listado_inventario();
            }
        }

        private void FormInventario_Load(object sender, EventArgs e)
        {
            dgvInventario.DataSource = NI.Listado_inventario();
        }

        private void btnBuscarCodigo_Click(object sender, EventArgs e)
        {
            if (txtBuscaCodigo.Text != "")
            {
                bool seEncontro = false;
                string textoBusqueda = txtBuscaCodigo.Text;

                foreach (DataGridViewRow row in dgvInventario.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[0].Value.ToString().Equals(textoBusqueda))
                    {

                        // Se encontró la búsqueda
                        seEncontro = true;

                        // Mostrar el resultado en los campos de nombre y fecha
                        BoxId.Text = row.Cells[0].Value.ToString();
                        BoxNombre.Text = row.Cells[1].Value.ToString();
                        BoxDescripciónP.Text = row.Cells[2].Value.ToString();
                        BoxValorP.Text = row.Cells[3].Value.ToString();
                        BoxEstadoP.Text = row.Cells[4].Value.ToString();
                        if (DateTime.TryParse(row.Cells[5].Value.ToString(), out DateTime fechaa))
                        {
                            dtpFechaActual.Value = fechaa;
                        }
                        if (DateTime.TryParse(row.Cells[6].Value.ToString(), out DateTime fechav))
                        {
                            dtpFechaVencimiento.Value = fechav;
                        }
                        BoxUnidadxCaja.Text = row.Cells[7].Value.ToString();
                        BoxLote.Text = row.Cells[8].Value.ToString();
                        BoxCantidadS.Text = row.Cells[9].Value.ToString();
                        BoxProveedor.Text = row.Cells[10].Value.ToString();
                        BoxUbicacionP.Text = row.Cells[11].Value.ToString();

                        break; // Puedes detener el ciclo ya que se encontró una coincidencia

                    }
                }

                if (seEncontro)
                {
                    MessageBox.Show("BÚSQUEDA ENCONTRADA.");
                }
                else
                {
                    MessageBox.Show("BÚSQUEDA NO ENCONTRADA.");
                    BoxId.Text = ""; // Limpiar el campo de nombre si no se encontró la búsqueda
                    dtpFechaActual.Text = ""; // Limpiar el campo de fecha si no se encontró la búsqueda
                    BoxNombre.Text = ""; // Limpiar el campo de fecha si no se encontró la búsqueda
                    BoxDescripciónP.Text = ""; // Limpiar el campo de fecha si no se encontró la búsqueda
                    BoxUnidadxCaja.Text = ""; // Limpiar el campo de fecha si no se encontró la búsqueda
                    BoxLote.Text = ""; // Limpiar el campo de fecha si no se encontró la búsqueda
                    BoxCantidadS.Text = ""; // Limpiar el campo de fecha si no se encontró la búsqueda
                    BoxUbicacionP.Text = ""; // Limpiar el campo de fecha si no se encontró la búsqueda
                    BoxValorP.Text = ""; // Limpiar el campo de fecha si no se encontró la búsqueda
                    BoxProveedor.Text = ""; // Limpiar el campo de fecha si no se encontró la búsqueda
                    dtpFechaVencimiento.Text = ""; // Limpiar el campo de fecha si no se encontró la búsqueda
                    BoxEstadoP.Text = ""; // Limpiar el campo de fecha si no se encontró la búsqueda
                }

                txtBuscaCodigo.Text = "";

            }
            else
            {
                MessageBox.Show("POR FAVOR RELLENAR LA CASILLA DE BÚSQUEDA");
            }
        }

        private void txtBuscaCodigo_Click(object sender, EventArgs e)
        {
            txtBuscaCodigo.Text = "";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Deseas eliminar el producto?", "Mensaje del sistema",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                EP.IdProducto = Convert.ToInt32(BoxId.Text);
                String me = NI.Eliminar_inventario(EP);
                MessageBox.Show(me, "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                dgvInventario.DataSource = NI.Listado_inventario();
            }
        }
    }
}
