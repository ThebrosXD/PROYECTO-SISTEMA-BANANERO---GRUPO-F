namespace Maint.Inventario
{
    partial class FormInventario
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.dgvInventario = new System.Windows.Forms.DataGridView();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.labelUnixCaja = new System.Windows.Forms.Label();
            this.labelEstadoP = new System.Windows.Forms.Label();
            this.BoxEstadoP = new System.Windows.Forms.TextBox();
            this.labelProveedor = new System.Windows.Forms.Label();
            this.BoxProveedor = new System.Windows.Forms.TextBox();
            this.labelValorP = new System.Windows.Forms.Label();
            this.BoxValorP = new System.Windows.Forms.TextBox();
            this.labelUbicacionP = new System.Windows.Forms.Label();
            this.BoxUbicacionP = new System.Windows.Forms.TextBox();
            this.labelFechaV = new System.Windows.Forms.Label();
            this.labelCantidadStock = new System.Windows.Forms.Label();
            this.BoxCantidadS = new System.Windows.Forms.TextBox();
            this.labelLote = new System.Windows.Forms.Label();
            this.BoxLote = new System.Windows.Forms.TextBox();
            this.BoxUnidadxCaja = new System.Windows.Forms.TextBox();
            this.labelDescripciónP = new System.Windows.Forms.Label();
            this.BoxDescripciónP = new System.Windows.Forms.TextBox();
            this.labelNombre = new System.Windows.Forms.Label();
            this.BoxNombre = new System.Windows.Forms.TextBox();
            this.labelFechaA = new System.Windows.Forms.Label();
            this.labelIdProducto = new System.Windows.Forms.Label();
            this.BoxId = new System.Windows.Forms.TextBox();
            this.btnOcultarCampos = new System.Windows.Forms.Button();
            this.btnMostarCampos = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnBuscarCodigo = new System.Windows.Forms.Button();
            this.txtBuscaCodigo = new System.Windows.Forms.TextBox();
            this.Inventario = new System.Windows.Forms.Label();
            this.dtpFechaActual = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaVencimiento = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventario)).BeginInit();
            this.SuspendLayout();
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnModificar.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.Location = new System.Drawing.Point(150, 432);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(87, 37);
            this.btnModificar.TabIndex = 112;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnEditar.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.Location = new System.Drawing.Point(15, 432);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(87, 37);
            this.btnEditar.TabIndex = 111;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnAgregar.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Location = new System.Drawing.Point(557, 347);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(91, 37);
            this.btnAgregar.TabIndex = 110;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // dgvInventario
            // 
            this.dgvInventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventario.Location = new System.Drawing.Point(9, 473);
            this.dgvInventario.Name = "dgvInventario";
            this.dgvInventario.ReadOnly = true;
            this.dgvInventario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInventario.Size = new System.Drawing.Size(765, 208);
            this.dgvInventario.TabIndex = 109;
            this.dgvInventario.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewInventario_CellClick);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnLimpiar.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Location = new System.Drawing.Point(429, 347);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(87, 37);
            this.btnLimpiar.TabIndex = 108;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // labelUnixCaja
            // 
            this.labelUnixCaja.AutoSize = true;
            this.labelUnixCaja.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUnixCaja.ForeColor = System.Drawing.Color.Black;
            this.labelUnixCaja.Location = new System.Drawing.Point(12, 306);
            this.labelUnixCaja.Name = "labelUnixCaja";
            this.labelUnixCaja.Size = new System.Drawing.Size(130, 16);
            this.labelUnixCaja.TabIndex = 107;
            this.labelUnixCaja.Text = "Unidades por Caja";
            // 
            // labelEstadoP
            // 
            this.labelEstadoP.AutoSize = true;
            this.labelEstadoP.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEstadoP.ForeColor = System.Drawing.Color.Black;
            this.labelEstadoP.Location = new System.Drawing.Point(426, 294);
            this.labelEstadoP.Name = "labelEstadoP";
            this.labelEstadoP.Size = new System.Drawing.Size(136, 16);
            this.labelEstadoP.TabIndex = 106;
            this.labelEstadoP.Text = "Estado del Producto";
            // 
            // BoxEstadoP
            // 
            this.BoxEstadoP.BackColor = System.Drawing.SystemColors.Info;
            this.BoxEstadoP.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BoxEstadoP.Location = new System.Drawing.Point(608, 288);
            this.BoxEstadoP.Multiline = true;
            this.BoxEstadoP.Name = "BoxEstadoP";
            this.BoxEstadoP.Size = new System.Drawing.Size(66, 28);
            this.BoxEstadoP.TabIndex = 105;
            // 
            // labelProveedor
            // 
            this.labelProveedor.AutoSize = true;
            this.labelProveedor.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProveedor.ForeColor = System.Drawing.Color.Black;
            this.labelProveedor.Location = new System.Drawing.Point(426, 204);
            this.labelProveedor.Name = "labelProveedor";
            this.labelProveedor.Size = new System.Drawing.Size(72, 16);
            this.labelProveedor.TabIndex = 104;
            this.labelProveedor.Text = "Proveedor";
            // 
            // BoxProveedor
            // 
            this.BoxProveedor.BackColor = System.Drawing.SystemColors.Info;
            this.BoxProveedor.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BoxProveedor.Location = new System.Drawing.Point(608, 199);
            this.BoxProveedor.Multiline = true;
            this.BoxProveedor.Name = "BoxProveedor";
            this.BoxProveedor.Size = new System.Drawing.Size(172, 27);
            this.BoxProveedor.TabIndex = 103;
            // 
            // labelValorP
            // 
            this.labelValorP.AutoSize = true;
            this.labelValorP.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelValorP.ForeColor = System.Drawing.Color.Black;
            this.labelValorP.Location = new System.Drawing.Point(426, 157);
            this.labelValorP.Name = "labelValorP";
            this.labelValorP.Size = new System.Drawing.Size(128, 16);
            this.labelValorP.TabIndex = 102;
            this.labelValorP.Text = "Valor del Producto";
            // 
            // BoxValorP
            // 
            this.BoxValorP.BackColor = System.Drawing.SystemColors.Info;
            this.BoxValorP.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BoxValorP.Location = new System.Drawing.Point(608, 152);
            this.BoxValorP.Multiline = true;
            this.BoxValorP.Name = "BoxValorP";
            this.BoxValorP.Size = new System.Drawing.Size(66, 26);
            this.BoxValorP.TabIndex = 101;
            // 
            // labelUbicacionP
            // 
            this.labelUbicacionP.AutoSize = true;
            this.labelUbicacionP.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUbicacionP.ForeColor = System.Drawing.Color.Black;
            this.labelUbicacionP.Location = new System.Drawing.Point(426, 79);
            this.labelUbicacionP.Name = "labelUbicacionP";
            this.labelUbicacionP.Size = new System.Drawing.Size(159, 16);
            this.labelUbicacionP.TabIndex = 100;
            this.labelUbicacionP.Text = "Ubicación del Producto";
            // 
            // BoxUbicacionP
            // 
            this.BoxUbicacionP.BackColor = System.Drawing.SystemColors.Info;
            this.BoxUbicacionP.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BoxUbicacionP.Location = new System.Drawing.Point(608, 79);
            this.BoxUbicacionP.Multiline = true;
            this.BoxUbicacionP.Name = "BoxUbicacionP";
            this.BoxUbicacionP.Size = new System.Drawing.Size(172, 56);
            this.BoxUbicacionP.TabIndex = 99;
            // 
            // labelFechaV
            // 
            this.labelFechaV.AutoSize = true;
            this.labelFechaV.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFechaV.ForeColor = System.Drawing.Color.Black;
            this.labelFechaV.Location = new System.Drawing.Point(426, 249);
            this.labelFechaV.Name = "labelFechaV";
            this.labelFechaV.Size = new System.Drawing.Size(152, 16);
            this.labelFechaV.TabIndex = 98;
            this.labelFechaV.Text = "Fecha de Vencimiento";
            // 
            // labelCantidadStock
            // 
            this.labelCantidadStock.AutoSize = true;
            this.labelCantidadStock.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCantidadStock.ForeColor = System.Drawing.Color.Black;
            this.labelCantidadStock.Location = new System.Drawing.Point(12, 395);
            this.labelCantidadStock.Name = "labelCantidadStock";
            this.labelCantidadStock.Size = new System.Drawing.Size(129, 16);
            this.labelCantidadStock.TabIndex = 96;
            this.labelCantidadStock.Text = "Cantidad de Stock";
            // 
            // BoxCantidadS
            // 
            this.BoxCantidadS.BackColor = System.Drawing.SystemColors.Info;
            this.BoxCantidadS.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BoxCantidadS.Location = new System.Drawing.Point(185, 390);
            this.BoxCantidadS.Multiline = true;
            this.BoxCantidadS.Name = "BoxCantidadS";
            this.BoxCantidadS.Size = new System.Drawing.Size(66, 27);
            this.BoxCantidadS.TabIndex = 95;
            // 
            // labelLote
            // 
            this.labelLote.AutoSize = true;
            this.labelLote.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLote.ForeColor = System.Drawing.Color.Black;
            this.labelLote.Location = new System.Drawing.Point(12, 351);
            this.labelLote.Name = "labelLote";
            this.labelLote.Size = new System.Drawing.Size(33, 16);
            this.labelLote.TabIndex = 94;
            this.labelLote.Text = "Lote";
            // 
            // BoxLote
            // 
            this.BoxLote.BackColor = System.Drawing.SystemColors.Info;
            this.BoxLote.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BoxLote.Location = new System.Drawing.Point(185, 347);
            this.BoxLote.Multiline = true;
            this.BoxLote.Name = "BoxLote";
            this.BoxLote.Size = new System.Drawing.Size(106, 25);
            this.BoxLote.TabIndex = 93;
            // 
            // BoxUnidadxCaja
            // 
            this.BoxUnidadxCaja.BackColor = System.Drawing.SystemColors.Info;
            this.BoxUnidadxCaja.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BoxUnidadxCaja.Location = new System.Drawing.Point(185, 301);
            this.BoxUnidadxCaja.Multiline = true;
            this.BoxUnidadxCaja.Name = "BoxUnidadxCaja";
            this.BoxUnidadxCaja.Size = new System.Drawing.Size(66, 26);
            this.BoxUnidadxCaja.TabIndex = 92;
            // 
            // labelDescripciónP
            // 
            this.labelDescripciónP.AutoSize = true;
            this.labelDescripciónP.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDescripciónP.ForeColor = System.Drawing.Color.Black;
            this.labelDescripciónP.Location = new System.Drawing.Point(9, 216);
            this.labelDescripciónP.Name = "labelDescripciónP";
            this.labelDescripciónP.Size = new System.Drawing.Size(170, 16);
            this.labelDescripciónP.TabIndex = 91;
            this.labelDescripciónP.Text = "Descripción del Producto";
            // 
            // BoxDescripciónP
            // 
            this.BoxDescripciónP.BackColor = System.Drawing.SystemColors.Info;
            this.BoxDescripciónP.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BoxDescripciónP.Location = new System.Drawing.Point(185, 215);
            this.BoxDescripciónP.Multiline = true;
            this.BoxDescripciónP.Name = "BoxDescripciónP";
            this.BoxDescripciónP.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BoxDescripciónP.Size = new System.Drawing.Size(201, 70);
            this.BoxDescripciónP.TabIndex = 90;
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNombre.ForeColor = System.Drawing.Color.Black;
            this.labelNombre.Location = new System.Drawing.Point(9, 162);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(145, 16);
            this.labelNombre.TabIndex = 89;
            this.labelNombre.Text = "Nombre del Producto";
            // 
            // BoxNombre
            // 
            this.BoxNombre.BackColor = System.Drawing.SystemColors.Info;
            this.BoxNombre.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BoxNombre.Location = new System.Drawing.Point(185, 156);
            this.BoxNombre.Multiline = true;
            this.BoxNombre.Name = "BoxNombre";
            this.BoxNombre.Size = new System.Drawing.Size(201, 28);
            this.BoxNombre.TabIndex = 88;
            // 
            // labelFechaA
            // 
            this.labelFechaA.AutoSize = true;
            this.labelFechaA.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFechaA.ForeColor = System.Drawing.Color.Black;
            this.labelFechaA.Location = new System.Drawing.Point(9, 119);
            this.labelFechaA.Name = "labelFechaA";
            this.labelFechaA.Size = new System.Drawing.Size(149, 16);
            this.labelFechaA.TabIndex = 87;
            this.labelFechaA.Text = "Fecha de Adquisición";
            // 
            // labelIdProducto
            // 
            this.labelIdProducto.AutoSize = true;
            this.labelIdProducto.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIdProducto.ForeColor = System.Drawing.Color.Black;
            this.labelIdProducto.Location = new System.Drawing.Point(9, 79);
            this.labelIdProducto.Name = "labelIdProducto";
            this.labelIdProducto.Size = new System.Drawing.Size(106, 16);
            this.labelIdProducto.TabIndex = 85;
            this.labelIdProducto.Text = "Id del Producto";
            // 
            // BoxId
            // 
            this.BoxId.BackColor = System.Drawing.SystemColors.HighlightText;
            this.BoxId.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BoxId.ForeColor = System.Drawing.SystemColors.InfoText;
            this.BoxId.Location = new System.Drawing.Point(185, 73);
            this.BoxId.Multiline = true;
            this.BoxId.Name = "BoxId";
            this.BoxId.Size = new System.Drawing.Size(66, 29);
            this.BoxId.TabIndex = 84;
            // 
            // btnOcultarCampos
            // 
            this.btnOcultarCampos.BackColor = System.Drawing.Color.Firebrick;
            this.btnOcultarCampos.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOcultarCampos.Location = new System.Drawing.Point(661, 12);
            this.btnOcultarCampos.Name = "btnOcultarCampos";
            this.btnOcultarCampos.Size = new System.Drawing.Size(119, 34);
            this.btnOcultarCampos.TabIndex = 83;
            this.btnOcultarCampos.Text = "Ocultar Campos";
            this.btnOcultarCampos.UseVisualStyleBackColor = false;
            this.btnOcultarCampos.Click += new System.EventHandler(this.btnOcultarCampos_Click);
            // 
            // btnMostarCampos
            // 
            this.btnMostarCampos.BackColor = System.Drawing.Color.ForestGreen;
            this.btnMostarCampos.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMostarCampos.Location = new System.Drawing.Point(527, 12);
            this.btnMostarCampos.Name = "btnMostarCampos";
            this.btnMostarCampos.Size = new System.Drawing.Size(116, 34);
            this.btnMostarCampos.TabIndex = 82;
            this.btnMostarCampos.Text = "Mostar Campos";
            this.btnMostarCampos.UseVisualStyleBackColor = false;
            this.btnMostarCampos.Click += new System.EventHandler(this.btnMostarCampos_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnEliminar.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Location = new System.Drawing.Point(689, 347);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(91, 37);
            this.btnEliminar.TabIndex = 81;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnBuscarCodigo
            // 
            this.btnBuscarCodigo.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnBuscarCodigo.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarCodigo.ForeColor = System.Drawing.Color.White;
            this.btnBuscarCodigo.Location = new System.Drawing.Point(283, 31);
            this.btnBuscarCodigo.Name = "btnBuscarCodigo";
            this.btnBuscarCodigo.Size = new System.Drawing.Size(119, 30);
            this.btnBuscarCodigo.TabIndex = 80;
            this.btnBuscarCodigo.Text = "Buscar Código";
            this.btnBuscarCodigo.UseVisualStyleBackColor = false;
            this.btnBuscarCodigo.Click += new System.EventHandler(this.btnBuscarCodigo_Click);
            // 
            // txtBuscaCodigo
            // 
            this.txtBuscaCodigo.Location = new System.Drawing.Point(12, 37);
            this.txtBuscaCodigo.Multiline = true;
            this.txtBuscaCodigo.Name = "txtBuscaCodigo";
            this.txtBuscaCodigo.Size = new System.Drawing.Size(261, 24);
            this.txtBuscaCodigo.TabIndex = 79;
            this.txtBuscaCodigo.Text = "Ingrese el codigo del producto";
            this.txtBuscaCodigo.Click += new System.EventHandler(this.txtBuscaCodigo_Click);
            // 
            // Inventario
            // 
            this.Inventario.AutoSize = true;
            this.Inventario.Font = new System.Drawing.Font("Microsoft JhengHei", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Inventario.ForeColor = System.Drawing.Color.Black;
            this.Inventario.Location = new System.Drawing.Point(9, -1);
            this.Inventario.Name = "Inventario";
            this.Inventario.Size = new System.Drawing.Size(147, 35);
            this.Inventario.TabIndex = 78;
            this.Inventario.Text = "Inventario";
            this.Inventario.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dtpFechaActual
            // 
            this.dtpFechaActual.Enabled = false;
            this.dtpFechaActual.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaActual.Location = new System.Drawing.Point(185, 119);
            this.dtpFechaActual.Name = "dtpFechaActual";
            this.dtpFechaActual.Size = new System.Drawing.Size(88, 20);
            this.dtpFechaActual.TabIndex = 113;
            // 
            // dtpFechaVencimiento
            // 
            this.dtpFechaVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaVencimiento.Location = new System.Drawing.Point(608, 245);
            this.dtpFechaVencimiento.Name = "dtpFechaVencimiento";
            this.dtpFechaVencimiento.Size = new System.Drawing.Size(88, 20);
            this.dtpFechaVencimiento.TabIndex = 114;
            // 
            // FormInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(834, 451);
            this.Controls.Add(this.dtpFechaVencimiento);
            this.Controls.Add(this.dtpFechaActual);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.dgvInventario);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.labelUnixCaja);
            this.Controls.Add(this.labelEstadoP);
            this.Controls.Add(this.BoxEstadoP);
            this.Controls.Add(this.labelProveedor);
            this.Controls.Add(this.BoxProveedor);
            this.Controls.Add(this.labelValorP);
            this.Controls.Add(this.BoxValorP);
            this.Controls.Add(this.labelUbicacionP);
            this.Controls.Add(this.BoxUbicacionP);
            this.Controls.Add(this.labelFechaV);
            this.Controls.Add(this.labelCantidadStock);
            this.Controls.Add(this.BoxCantidadS);
            this.Controls.Add(this.labelLote);
            this.Controls.Add(this.BoxLote);
            this.Controls.Add(this.BoxUnidadxCaja);
            this.Controls.Add(this.labelDescripciónP);
            this.Controls.Add(this.BoxDescripciónP);
            this.Controls.Add(this.labelNombre);
            this.Controls.Add(this.BoxNombre);
            this.Controls.Add(this.labelFechaA);
            this.Controls.Add(this.labelIdProducto);
            this.Controls.Add(this.BoxId);
            this.Controls.Add(this.btnOcultarCampos);
            this.Controls.Add(this.btnMostarCampos);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnBuscarCodigo);
            this.Controls.Add(this.txtBuscaCodigo);
            this.Controls.Add(this.Inventario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormInventario";
            this.Text = "FormInventario";
            this.Load += new System.EventHandler(this.FormInventario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DataGridView dgvInventario;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label labelUnixCaja;
        private System.Windows.Forms.Label labelEstadoP;
        private System.Windows.Forms.TextBox BoxEstadoP;
        private System.Windows.Forms.Label labelProveedor;
        private System.Windows.Forms.TextBox BoxProveedor;
        private System.Windows.Forms.Label labelValorP;
        private System.Windows.Forms.TextBox BoxValorP;
        private System.Windows.Forms.Label labelUbicacionP;
        private System.Windows.Forms.TextBox BoxUbicacionP;
        private System.Windows.Forms.Label labelFechaV;
        private System.Windows.Forms.Label labelCantidadStock;
        private System.Windows.Forms.TextBox BoxCantidadS;
        private System.Windows.Forms.Label labelLote;
        private System.Windows.Forms.TextBox BoxLote;
        private System.Windows.Forms.TextBox BoxUnidadxCaja;
        private System.Windows.Forms.Label labelDescripciónP;
        private System.Windows.Forms.TextBox BoxDescripciónP;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.TextBox BoxNombre;
        private System.Windows.Forms.Label labelFechaA;
        private System.Windows.Forms.Label labelIdProducto;
        private System.Windows.Forms.TextBox BoxId;
        private System.Windows.Forms.Button btnOcultarCampos;
        private System.Windows.Forms.Button btnMostarCampos;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnBuscarCodigo;
        private System.Windows.Forms.TextBox txtBuscaCodigo;
        private System.Windows.Forms.Label Inventario;
        private System.Windows.Forms.DateTimePicker dtpFechaActual;
        private System.Windows.Forms.DateTimePicker dtpFechaVencimiento;
    }
}