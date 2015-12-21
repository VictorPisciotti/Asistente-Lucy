namespace Asistente_personal_Lucy
{
    partial class BusquedaGoogle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BusquedaGoogle));
            this.btnhablar = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.NaveGoogle = new System.Windows.Forms.WebBrowser();
            this.button2 = new System.Windows.Forms.Button();
            this.tbPalabra = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnhablar
            // 
            this.btnhablar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnhablar.ForeColor = System.Drawing.Color.Black;
            this.btnhablar.Location = new System.Drawing.Point(83, 9);
            this.btnhablar.Name = "btnhablar";
            this.btnhablar.Size = new System.Drawing.Size(442, 64);
            this.btnhablar.TabIndex = 2;
            this.btnhablar.Text = "Para iniciar la busqueda diga: \"Buscar\"";
            this.btnhablar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(3, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(74, 67);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // NaveGoogle
            // 
            this.NaveGoogle.Location = new System.Drawing.Point(3, 105);
            this.NaveGoogle.MinimumSize = new System.Drawing.Size(20, 20);
            this.NaveGoogle.Name = "NaveGoogle";
            this.NaveGoogle.ScriptErrorsSuppressed = true;
            this.NaveGoogle.Size = new System.Drawing.Size(544, 320);
            this.NaveGoogle.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Maroon;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Location = new System.Drawing.Point(531, 1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(20, 20);
            this.button2.TabIndex = 6;
            this.button2.Text = "X";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // tbPalabra
            // 
            this.tbPalabra.Location = new System.Drawing.Point(3, 79);
            this.tbPalabra.Name = "tbPalabra";
            this.tbPalabra.Size = new System.Drawing.Size(544, 20);
            this.tbPalabra.TabIndex = 7;
            // 
            // BusquedaGoogle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(552, 428);
            this.Controls.Add(this.tbPalabra);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.NaveGoogle);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnhablar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BusquedaGoogle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BusquedaGoogle";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.BusquedaGoogle_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BusquedaGoogle_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label btnhablar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.WebBrowser NaveGoogle;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox tbPalabra;
    }
}