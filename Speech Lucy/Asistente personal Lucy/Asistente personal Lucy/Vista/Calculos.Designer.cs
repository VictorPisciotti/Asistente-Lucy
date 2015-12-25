namespace Asistente_personal_Lucy
{
    partial class Calculos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Calculos));
            this.Valor1 = new System.Windows.Forms.TextBox();
            this.Valor2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Valor1
            // 
            this.Valor1.Location = new System.Drawing.Point(7, 30);
            this.Valor1.Name = "Valor1";
            this.Valor1.Size = new System.Drawing.Size(100, 20);
            this.Valor1.TabIndex = 0;
            // 
            // Valor2
            // 
            this.Valor2.Location = new System.Drawing.Point(125, 30);
            this.Valor2.Name = "Valor2";
            this.Valor2.Size = new System.Drawing.Size(100, 20);
            this.Valor2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Constantia", 10.75F);
            this.label1.Location = new System.Drawing.Point(32, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Valor 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Constantia", 10.75F);
            this.label2.Location = new System.Drawing.Point(153, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Valor 2";
            // 
            // Calculos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(258, 52);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Valor2);
            this.Controls.Add(this.Valor1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Calculos";
            this.Text = "Calculos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Valor1;
        private System.Windows.Forms.TextBox Valor2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}