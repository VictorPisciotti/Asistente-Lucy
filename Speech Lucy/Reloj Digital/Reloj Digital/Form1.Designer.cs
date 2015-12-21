namespace Reloj_Digital
{
    partial class Reloj
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
            this.components = new System.ComponentModel.Container();
            this.lbHora = new System.Windows.Forms.Label();
            this.Temporizador = new System.Windows.Forms.Timer(this.components);
            this.lbDate = new System.Windows.Forms.Label();
            this.lbMove = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbHora
            // 
            this.lbHora.BackColor = System.Drawing.Color.Black;
            this.lbHora.Font = new System.Drawing.Font("Verdana", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHora.ForeColor = System.Drawing.Color.Lime;
            this.lbHora.Location = new System.Drawing.Point(-3, 2);
            this.lbHora.Name = "lbHora";
            this.lbHora.Size = new System.Drawing.Size(210, 39);
            this.lbHora.TabIndex = 0;
            this.lbHora.Text = "h";
            // 
            // Temporizador
            // 
            this.Temporizador.Tick += new System.EventHandler(this.Temporizador_Tick);
            // 
            // lbDate
            // 
            this.lbDate.BackColor = System.Drawing.Color.Black;
            this.lbDate.Font = new System.Drawing.Font("Constantia", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDate.ForeColor = System.Drawing.Color.Lime;
            this.lbDate.Location = new System.Drawing.Point(-2, 39);
            this.lbDate.Name = "lbDate";
            this.lbDate.Size = new System.Drawing.Size(209, 65);
            this.lbDate.TabIndex = 1;
            this.lbDate.Text = "D";
            // 
            // lbMove
            // 
            this.lbMove.BackColor = System.Drawing.Color.Lime;
            this.lbMove.Location = new System.Drawing.Point(1, 100);
            this.lbMove.Name = "lbMove";
            this.lbMove.Size = new System.Drawing.Size(213, 10);
            this.lbMove.TabIndex = 2;
            this.lbMove.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbMove_MouseDown);
            this.lbMove.MouseEnter += new System.EventHandler(this.lbMove_MouseEnter);
            // 
            // Reloj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(214, 111);
            this.Controls.Add(this.lbMove);
            this.Controls.Add(this.lbDate);
            this.Controls.Add(this.lbHora);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(1050, 50);
            this.Name = "Reloj";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Reloj Digital";
            this.TransparencyKey = System.Drawing.Color.Black;
            this.Activated += new System.EventHandler(this.Reloj_Activated);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbHora;
        private System.Windows.Forms.Timer Temporizador;
        private System.Windows.Forms.Label lbDate;
        private System.Windows.Forms.Label lbMove;
    }
}

