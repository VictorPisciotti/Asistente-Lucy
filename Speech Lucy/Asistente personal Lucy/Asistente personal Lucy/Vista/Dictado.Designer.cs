namespace Asistente_personal_Lucy
{
    partial class Dictado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dictado));
            this.btncancelar = new System.Windows.Forms.Button();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnayuda = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btncancelar
            // 
            this.btncancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btncancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btncancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.btncancelar.ForeColor = System.Drawing.Color.Black;
            this.btncancelar.Location = new System.Drawing.Point(243, 239);
            this.btncancelar.Name = "btncancelar";
            this.btncancelar.Size = new System.Drawing.Size(75, 23);
            this.btncancelar.TabIndex = 0;
            this.btncancelar.Text = "Cancelar";
            this.btncancelar.UseVisualStyleBackColor = true;
            // 
            // btnBorrar
            // 
            this.btnBorrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnBorrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBorrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.btnBorrar.ForeColor = System.Drawing.Color.Black;
            this.btnBorrar.Location = new System.Drawing.Point(162, 239);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(75, 23);
            this.btnBorrar.TabIndex = 2;
            this.btnBorrar.Text = "Borrar";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(173, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Dictado por voz";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBox1.ForeColor = System.Drawing.Color.MediumSpringGreen;
            this.textBox1.Location = new System.Drawing.Point(12, 38);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(464, 195);
            this.textBox1.TabIndex = 4;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnayuda
            // 
            this.btnayuda.BackColor = System.Drawing.Color.Transparent;
            this.btnayuda.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnayuda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnayuda.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnayuda.Location = new System.Drawing.Point(12, 9);
            this.btnayuda.Name = "btnayuda";
            this.btnayuda.Size = new System.Drawing.Size(50, 23);
            this.btnayuda.TabIndex = 5;
            this.btnayuda.Text = "Ayuda";
            this.btnayuda.UseVisualStyleBackColor = false;
            this.btnayuda.Click += new System.EventHandler(this.btnayuda_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Brown;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(450, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(26, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Calendario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(488, 274);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnayuda);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.btncancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Calendario";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Bloc de dictado";
            this.Load += new System.EventHandler(this.Calendario_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Calendario_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btncancelar;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnayuda;
        private System.Windows.Forms.Button button1;
    }
}