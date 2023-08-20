namespace Maint.Ventas
{
    partial class FormSeguimiento
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
            this.button5 = new System.Windows.Forms.Button();
            this.btnCotizaciones = new System.Windows.Forms.Button();
            this.btnRegistrarPedido = new System.Windows.Forms.Button();
            this.dgvPrincipal = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrincipal)).BeginInit();
            this.SuspendLayout();
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(121)))), ((int)(((byte)(248)))));
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(283, 12);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(110, 23);
            this.button5.TabIndex = 33;
            this.button5.Text = "Seguimiento";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // btnCotizaciones
            // 
            this.btnCotizaciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(121)))), ((int)(((byte)(248)))));
            this.btnCotizaciones.FlatAppearance.BorderSize = 0;
            this.btnCotizaciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCotizaciones.ForeColor = System.Drawing.Color.White;
            this.btnCotizaciones.Location = new System.Drawing.Point(154, 12);
            this.btnCotizaciones.Name = "btnCotizaciones";
            this.btnCotizaciones.Size = new System.Drawing.Size(110, 23);
            this.btnCotizaciones.TabIndex = 32;
            this.btnCotizaciones.Text = "Cotizaciones";
            this.btnCotizaciones.UseVisualStyleBackColor = false;
            this.btnCotizaciones.Click += new System.EventHandler(this.btnCotizaciones_Click);
            // 
            // btnRegistrarPedido
            // 
            this.btnRegistrarPedido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(121)))), ((int)(((byte)(248)))));
            this.btnRegistrarPedido.FlatAppearance.BorderSize = 0;
            this.btnRegistrarPedido.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarPedido.ForeColor = System.Drawing.Color.White;
            this.btnRegistrarPedido.Location = new System.Drawing.Point(27, 12);
            this.btnRegistrarPedido.Name = "btnRegistrarPedido";
            this.btnRegistrarPedido.Size = new System.Drawing.Size(110, 23);
            this.btnRegistrarPedido.TabIndex = 31;
            this.btnRegistrarPedido.Text = "Registrar pedido";
            this.btnRegistrarPedido.UseVisualStyleBackColor = false;
            this.btnRegistrarPedido.Click += new System.EventHandler(this.btnRegistrarPedido_Click);
            // 
            // dgvPrincipal
            // 
            this.dgvPrincipal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrincipal.Location = new System.Drawing.Point(12, 108);
            this.dgvPrincipal.Name = "dgvPrincipal";
            this.dgvPrincipal.Size = new System.Drawing.Size(776, 293);
            this.dgvPrincipal.TabIndex = 36;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 407);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 37;
            this.button1.Text = "Eliminar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Open Sans Semibold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(244, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(333, 37);
            this.label1.TabIndex = 38;
            this.label1.Text = "Seguimiento de pedidos";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(666, 66);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 39;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(673, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 40;
            this.label2.Text = "label2";
            // 
            // FormSeguimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(800, 451);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvPrincipal);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.btnCotizaciones);
            this.Controls.Add(this.btnRegistrarPedido);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormSeguimiento";
            this.Text = "FormSeguimiento";
            this.Load += new System.EventHandler(this.FormSeguimiento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrincipal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btnCotizaciones;
        private System.Windows.Forms.Button btnRegistrarPedido;
        private System.Windows.Forms.DataGridView dgvPrincipal;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
    }
}