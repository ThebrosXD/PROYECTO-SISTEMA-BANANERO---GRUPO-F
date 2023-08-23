/**
 * Este es el formulario para realizar el seguimiento a los pedidos realizados
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
using Capa_Negocio;
using Capa_Entidad;

namespace Maint.Ventas
{
    public partial class FormSeguimiento : Form
    {
        E_pedidos Ep = new E_pedidos(); // Crea una instancia de la entidad E_pedidos
        N_pedidos En = new N_pedidos(); // Crea una instancia de la capa de negocio N_pedidos
        E_usuario EU = new E_usuario(); // Crea una instancia de la entidad E_usuario

        public FormSeguimiento()
        {
            InitializeComponent();
        }

        #region "Mis metodos"
        private void Formato_pe()
        {
            dgvPrincipal.Columns[0].Width = 50;
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
            dgvPrincipal.Columns[8].Width = 100;
            dgvPrincipal.Columns[8].HeaderText = "Descripcion";
        }

        #endregion
        private void FormSeguimiento_Load(object sender, EventArgs e)
        {
            // Carga datos de pedidos en el DataGridView dgvPrincipal
            LoadDataPEDIDOS();
            desabilitarBotones2();
            //this.Formato_pe();
        }

        //metodo carga de datos del que inicio sesion
        private int CargardatosInicioSesion()
        {
            int cedula = 0, usuario = E_Usuarioactual.UsuarioLogeado;
            List<E_usuario> registros = En.ObtenerRegistrosInicioSesion(usuario);
            foreach (E_usuario registro in registros)
            {
                cedula = registro.cedula;
            }
            return cedula;
        }

        //cargas de datos tablas pedidos
        private void LoadDataPEDIDOS()
        {
            DataTable dataTable = En.Tablas_seguimiento(CargardatosInicioSesion());
            dgvPrincipal.DataSource = dataTable;
        }

        //cargas de datos tablas cotizaciones
        private void LoadDataCOTIZACIONES()
        {
            DataTable dataTable = En.Tablas_seguimientoCoti(CargardatosInicioSesion());
            dgvPrincipal.DataSource = dataTable;
        }

        //cargas de datos tablas pedidos
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

        //Metodos desabilitar botones de pedidos
        private void desabilitarBotones()
        {
            btnBuscar.Visible = false;
            btnEliminar.Visible = false;
        }

        //Metodos habilitar botones de pedidos
        private void habilitarBotones()
        {
            btnBuscar.Visible = true;
            btnEliminar.Visible = true;
        }

        //Metodos desabilitar botones de cotizaciones
        private void desabilitarBotones2()
        {
            btnBuscar2.Visible = false;
            btnEliminar2.Visible = false;
        }

        //Metodos habilitar botones de cotizaciones
        private void habilitarBotones2()
        {
            btnBuscar2.Visible = true;
            btnEliminar2.Visible = true;
        }

        // Maneja el evento de clic en el botón para eliminar un pedido
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Convert.ToString(dgvPrincipal.Columns[0].ValueType)))
            {
                MessageBox.Show("No hay Informacion para eliminar");
            }
            else
            {
                // Solicita confirmación para eliminar el pedido seleccionado
                DialogResult opcion;
                opcion = MessageBox.Show("Desear eliminar el registro seleccionado?","Aviso del sistema",MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (opcion == DialogResult.Yes)
                {
                    string rpa = "";
                    int id=0;
                    id = Convert.ToInt32(dgvPrincipal.CurrentRow.Cells["id_pedido"].Value);
                    rpa = En.Eliminar_pedido(id); // Llama al método de negocio para eliminar el pedido
                    if (rpa.Equals("OK"))
                    {
                        LoadDataPEDIDOS(); // Actualiza la lista de pedidos
                        MessageBox.Show("Registro eliminado del sistema","Aviso del sistema", MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                }
            }
        }

        // Maneja el evento de clic en el botón "Cotizaciones"
        private void btnCotizaciones_Click(object sender, EventArgs e)
        {
            // Crear una instancia de Formulario3
            FormCotizaciones CO = new FormCotizaciones();

            // Llamar al método abriFormPanel de FormPrincipal para abrir FormSeguimiento dentro del panel
            FormPrincipal pe = this.ParentForm as FormPrincipal;
            if (pe != null)
            {
                pe.abriFormPanel(CO);
            }
        }

        //busca el pedido con el boton "buscar" en pedidos
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtBuscar.Text, out int pedidoABuscar))
            {
                DataTable dt = En.BuscarPedido(pedidoABuscar);
                dgvPrincipal.DataSource = dt;
            }
            else if (String.IsNullOrEmpty(txtBuscar.Text))
            {
                    LoadDataPEDIDOS();
            }
            else
            {
                MessageBox.Show("Ingresa un número de pedido válido.");
            }
        }

        //Metodo si seleciona "cotizaciones" se desabilitan los botones de pedidos
        private void cmbTablas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTablas.Text == "Cotizaciones")
            {
                desabilitarBotones();
                habilitarBotones2();
                LoadDataCOTIZACIONES();
            }
            else
            {
                habilitarBotones();
                desabilitarBotones2();
                LoadDataPEDIDOS() ; 
            }
        }

        // Maneja el evento de clic en el botón para eliminar una cotizacion
        private void btnEliminar2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Convert.ToString(dgvPrincipal.Columns[0].ValueType)))
            {
                MessageBox.Show("No hay Informacion para eliminar");
            }
            else
            {
                DialogResult opcion;
                opcion = MessageBox.Show("Desear eliminar el registro seleccionado?", "Aviso del sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (opcion == DialogResult.Yes)
                {
                    string rpa = "";
                    int id = 0;
                    id = Convert.ToInt32(dgvPrincipal.CurrentRow.Cells["id_cotizacion"].Value);
                    rpa = En.Eliminar_cotizacion(id);
                    if (rpa.Equals("OK"))
                    {
                        LoadDataCOTIZACIONES();
                        MessageBox.Show("Registro eliminado del sistema", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        //busca el pedido con el boton "buscar" en cotizaciones
        private void btnBuscar2_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtBuscar.Text, out int cotizacionABuscar))
            {
                DataTable dt = En.BuscarCotizacion(cotizacionABuscar);
                dgvPrincipal.DataSource = dt;
            }
            else if (String.IsNullOrEmpty(txtBuscar.Text))
            {
                LoadDataCOTIZACIONES();
            }
            else
            {
                MessageBox.Show("Ingresa un número de pedido válido.");
            }
        }
    }
}
