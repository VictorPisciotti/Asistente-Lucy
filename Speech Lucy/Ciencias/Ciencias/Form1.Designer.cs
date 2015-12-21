namespace Ciencias
{
    partial class Electricidad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Electricidad));
            this.btnCalcular = new System.Windows.Forms.Button();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.Categorias = new System.Windows.Forms.ListBox();
            this.Valor2 = new System.Windows.Forms.TextBox();
            this.Valor1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelVoltaje = new System.Windows.Forms.Label();
            this.Resistencia2 = new System.Windows.Forms.Label();
            this.labelResistencia = new System.Windows.Forms.Label();
            this.labelCorriente = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCalcular
            // 
            this.btnCalcular.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCalcular.Location = new System.Drawing.Point(25, 160);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(75, 23);
            this.btnCalcular.TabIndex = 0;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // btnBorrar
            // 
            this.btnBorrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBorrar.Location = new System.Drawing.Point(109, 160);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(75, 23);
            this.btnBorrar.TabIndex = 1;
            this.btnBorrar.Text = "Borrar";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // Categorias
            // 
            this.Categorias.BackColor = System.Drawing.Color.LightSlateGray;
            this.Categorias.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Categorias.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Categorias.ForeColor = System.Drawing.Color.MediumBlue;
            this.Categorias.FormattingEnabled = true;
            this.Categorias.ItemHeight = 20;
            this.Categorias.Items.AddRange(new object[] {
            "Potencia",
            "Resistencia",
            "Corriente",
            "Voltaje"});
            this.Categorias.Location = new System.Drawing.Point(223, 84);
            this.Categorias.Name = "Categorias";
            this.Categorias.Size = new System.Drawing.Size(120, 80);
            this.Categorias.TabIndex = 2;
            this.Categorias.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Categorias_MouseDown);
            // 
            // Valor2
            // 
            this.Valor2.BackColor = System.Drawing.SystemColors.Info;
            this.Valor2.Location = new System.Drawing.Point(107, 118);
            this.Valor2.Multiline = true;
            this.Valor2.Name = "Valor2";
            this.Valor2.Size = new System.Drawing.Size(81, 20);
            this.Valor2.TabIndex = 3;
            // 
            // Valor1
            // 
            this.Valor1.BackColor = System.Drawing.SystemColors.Info;
            this.Valor1.Location = new System.Drawing.Point(22, 118);
            this.Valor1.Multiline = true;
            this.Valor1.Name = "Valor1";
            this.Valor1.Size = new System.Drawing.Size(80, 20);
            this.Valor1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label1.Location = new System.Drawing.Point(101, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 29);
            this.label1.TabIndex = 5;
            this.label1.Text = "ELECTRICIDAD";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label2.Location = new System.Drawing.Point(219, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 24);
            this.label2.TabIndex = 6;
            this.label2.Text = "CATEGORIAS";
            // 
            // labelVoltaje
            // 
            this.labelVoltaje.AutoSize = true;
            this.labelVoltaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelVoltaje.Location = new System.Drawing.Point(38, 92);
            this.labelVoltaje.Name = "labelVoltaje";
            this.labelVoltaje.Size = new System.Drawing.Size(51, 17);
            this.labelVoltaje.TabIndex = 7;
            this.labelVoltaje.Text = "Voltaje";
            this.labelVoltaje.Visible = false;
            // 
            // Resistencia2
            // 
            this.Resistencia2.AutoSize = true;
            this.Resistencia2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Resistencia2.Location = new System.Drawing.Point(107, 92);
            this.Resistencia2.Name = "Resistencia2";
            this.Resistencia2.Size = new System.Drawing.Size(81, 17);
            this.Resistencia2.TabIndex = 8;
            this.Resistencia2.Text = "Resistencia";
            this.Resistencia2.Visible = false;
            // 
            // labelResistencia
            // 
            this.labelResistencia.AutoSize = true;
            this.labelResistencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelResistencia.Location = new System.Drawing.Point(22, 92);
            this.labelResistencia.Name = "labelResistencia";
            this.labelResistencia.Size = new System.Drawing.Size(81, 17);
            this.labelResistencia.TabIndex = 9;
            this.labelResistencia.Text = "Resistencia";
            this.labelResistencia.Visible = false;
            // 
            // labelCorriente
            // 
            this.labelCorriente.AutoSize = true;
            this.labelCorriente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelCorriente.Location = new System.Drawing.Point(117, 92);
            this.labelCorriente.Name = "labelCorriente";
            this.labelCorriente.Size = new System.Drawing.Size(66, 17);
            this.labelCorriente.TabIndex = 10;
            this.labelCorriente.Text = "Corriente";
            this.labelCorriente.Visible = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Brown;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Location = new System.Drawing.Point(348, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(25, 23);
            this.button3.TabIndex = 11;
            this.button3.Text = "X";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.LightSlateGray;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBox1.Location = new System.Drawing.Point(34, 47);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(140, 42);
            this.textBox1.TabIndex = 13;
            this.textBox1.Text = "Ingrese un valor...";
            // 
            // Electricidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(378, 195);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.labelCorriente);
            this.Controls.Add(this.labelResistencia);
            this.Controls.Add(this.Resistencia2);
            this.Controls.Add(this.labelVoltaje);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Valor1);
            this.Controls.Add(this.Valor2);
            this.Controls.Add(this.Categorias);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.btnCalcular);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Electricidad";
            this.Text = "Electricidad";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.ListBox Categorias;
        private System.Windows.Forms.TextBox Valor2;
        private System.Windows.Forms.TextBox Valor1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelVoltaje;
        private System.Windows.Forms.Label Resistencia2;
        private System.Windows.Forms.Label labelResistencia;
        private System.Windows.Forms.Label labelCorriente;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox1;
    }
}

