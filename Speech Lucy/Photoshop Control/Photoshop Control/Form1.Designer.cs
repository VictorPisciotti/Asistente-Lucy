namespace Photoshop_Control
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lbCaptado = new System.Windows.Forms.Label();
            this.lbActivado = new System.Windows.Forms.Label();
            this.lbPalabras = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbCaptado
            // 
            this.lbCaptado.BackColor = System.Drawing.Color.Red;
            this.lbCaptado.Location = new System.Drawing.Point(15, 6);
            this.lbCaptado.Name = "lbCaptado";
            this.lbCaptado.Size = new System.Drawing.Size(21, 15);
            this.lbCaptado.TabIndex = 0;
            this.lbCaptado.Visible = false;
            // 
            // lbActivado
            // 
            this.lbActivado.BackColor = System.Drawing.Color.Lime;
            this.lbActivado.Location = new System.Drawing.Point(42, 6);
            this.lbActivado.Name = "lbActivado";
            this.lbActivado.Size = new System.Drawing.Size(23, 15);
            this.lbActivado.TabIndex = 1;
            this.lbActivado.Text = "On";
            this.lbActivado.Visible = false;
            // 
            // lbPalabras
            // 
            this.lbPalabras.BackColor = System.Drawing.Color.Transparent;
            this.lbPalabras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbPalabras.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPalabras.ForeColor = System.Drawing.Color.Black;
            this.lbPalabras.Location = new System.Drawing.Point(12, 25);
            this.lbPalabras.Name = "lbPalabras";
            this.lbPalabras.Size = new System.Drawing.Size(137, 38);
            this.lbPalabras.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Red;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Location = new System.Drawing.Point(144, 1);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(20, 20);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(164, 72);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lbPalabras);
            this.Controls.Add(this.lbActivado);
            this.Controls.Add(this.lbCaptado);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Photoshop Control";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbCaptado;
        private System.Windows.Forms.Label lbActivado;
        private System.Windows.Forms.Label lbPalabras;
        private System.Windows.Forms.Button btnClose;
    }
}

