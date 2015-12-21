namespace Reproductor_Compacto
{
    partial class ReproductorMini
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
            //base.Dispose(false);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReproductorMini));
            this.Ilustra = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lbDrop = new System.Windows.Forms.Label();
            this.NameCancion = new System.Windows.Forms.Label();
            this.Final = new System.Windows.Forms.Label();
            this.Conteo = new System.Windows.Forms.Label();
            this.lbBarra = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbOcultar = new System.Windows.Forms.Label();
            this.lbMover = new System.Windows.Forms.Label();
            this.lbPanel2 = new System.Windows.Forms.Label();
            this.Opciones = new System.Windows.Forms.Button();
            this.btndefault = new System.Windows.Forms.Button();
            this.btnMini = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnatras = new System.Windows.Forms.Button();
            this.btnplay = new System.Windows.Forms.Button();
            this.btnnext = new System.Windows.Forms.Button();
            this.Volumen = new System.Windows.Forms.TrackBar();
            this.PanelInferior = new System.Windows.Forms.Panel();
            this.btndescarga = new System.Windows.Forms.Button();
            this.btnEmi1 = new System.Windows.Forms.Button();
            this.btnEmi2 = new System.Windows.Forms.Button();
            this.btnEmi3 = new System.Windows.Forms.Button();
            this.btnEmi4 = new System.Windows.Forms.Button();
            this.Op4 = new System.Windows.Forms.Button();
            this.Op3 = new System.Windows.Forms.Button();
            this.Op2 = new System.Windows.Forms.Button();
            this.Op1 = new System.Windows.Forms.Button();
            this.ListaReproduccion = new System.Windows.Forms.ListBox();
            this.Navedescarga = new System.Windows.Forms.WebBrowser();
            this.NaveTube = new System.Windows.Forms.WebBrowser();
            ((System.ComponentModel.ISupportInitialize)(this.Ilustra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Volumen)).BeginInit();
            this.PanelInferior.SuspendLayout();
            this.SuspendLayout();
            // 
            // Ilustra
            // 
            this.Ilustra.Location = new System.Drawing.Point(12, 12);
            this.Ilustra.Name = "Ilustra";
            this.Ilustra.Size = new System.Drawing.Size(126, 130);
            this.Ilustra.TabIndex = 13;
            this.Ilustra.TabStop = false;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Location = new System.Drawing.Point(222, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(10, 8);
            this.label6.TabIndex = 18;
            // 
            // lbDrop
            // 
            this.lbDrop.AutoSize = true;
            this.lbDrop.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lbDrop.Location = new System.Drawing.Point(159, 12);
            this.lbDrop.Name = "lbDrop";
            this.lbDrop.Size = new System.Drawing.Size(118, 13);
            this.lbDrop.TabIndex = 7;
            this.lbDrop.Text = "Arrastre canciones aqui";
            // 
            // NameCancion
            // 
            this.NameCancion.BackColor = System.Drawing.Color.Transparent;
            this.NameCancion.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.NameCancion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameCancion.ForeColor = System.Drawing.Color.Gold;
            this.NameCancion.Location = new System.Drawing.Point(10, 142);
            this.NameCancion.Name = "NameCancion";
            this.NameCancion.Size = new System.Drawing.Size(130, 24);
            this.NameCancion.TabIndex = 9;
            this.NameCancion.Text = "No hay canciones";
            this.NameCancion.Click += new System.EventHandler(this.NameCancion_Click);
            // 
            // Final
            // 
            this.Final.BackColor = System.Drawing.Color.Transparent;
            this.Final.ForeColor = System.Drawing.Color.Lime;
            this.Final.Location = new System.Drawing.Point(290, 10);
            this.Final.Name = "Final";
            this.Final.Size = new System.Drawing.Size(38, 16);
            this.Final.TabIndex = 6;
            this.Final.Text = "00:00";
            // 
            // Conteo
            // 
            this.Conteo.BackColor = System.Drawing.Color.Transparent;
            this.Conteo.ForeColor = System.Drawing.Color.Lime;
            this.Conteo.Location = new System.Drawing.Point(110, 10);
            this.Conteo.Name = "Conteo";
            this.Conteo.Size = new System.Drawing.Size(38, 16);
            this.Conteo.TabIndex = 5;
            this.Conteo.Text = "00:00";
            // 
            // lbBarra
            // 
            this.lbBarra.BackColor = System.Drawing.Color.BlueViolet;
            this.lbBarra.Location = new System.Drawing.Point(154, 13);
            this.lbBarra.Name = "lbBarra";
            this.lbBarra.Size = new System.Drawing.Size(0, 10);
            this.lbBarra.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(101, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(2, 32);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Location = new System.Drawing.Point(175, 148);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(5, 4);
            this.label8.TabIndex = 20;
            // 
            // lbOcultar
            // 
            this.lbOcultar.BackColor = System.Drawing.Color.Transparent;
            this.lbOcultar.Location = new System.Drawing.Point(149, 0);
            this.lbOcultar.Name = "lbOcultar";
            this.lbOcultar.Size = new System.Drawing.Size(128, 10);
            this.lbOcultar.TabIndex = 32;
            this.lbOcultar.MouseEnter += new System.EventHandler(this.lbOcultar_MouseEnter);
            // 
            // lbMover
            // 
            this.lbMover.BackColor = System.Drawing.Color.Black;
            this.lbMover.Cursor = System.Windows.Forms.Cursors.NoMove2D;
            this.lbMover.Location = new System.Drawing.Point(-3, -3);
            this.lbMover.Name = "lbMover";
            this.lbMover.Size = new System.Drawing.Size(43, 13);
            this.lbMover.TabIndex = 33;
            this.lbMover.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbMover_MouseDown);
            // 
            // lbPanel2
            // 
            this.lbPanel2.BackColor = System.Drawing.Color.Black;
            this.lbPanel2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lbPanel2.Location = new System.Drawing.Point(285, 0);
            this.lbPanel2.Name = "lbPanel2";
            this.lbPanel2.Size = new System.Drawing.Size(46, 169);
            this.lbPanel2.TabIndex = 35;
            // 
            // Opciones
            // 
            this.Opciones.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Opciones.BackgroundImage")));
            this.Opciones.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Opciones.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Opciones.Location = new System.Drawing.Point(288, 24);
            this.Opciones.Name = "Opciones";
            this.Opciones.Size = new System.Drawing.Size(36, 40);
            this.Opciones.TabIndex = 5;
            this.Opciones.UseVisualStyleBackColor = true;
            this.Opciones.Click += new System.EventHandler(this.Opciones_Click);
            // 
            // btndefault
            // 
            this.btndefault.BackColor = System.Drawing.Color.YellowGreen;
            this.btndefault.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btndefault.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btndefault.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.btndefault.Location = new System.Drawing.Point(291, 70);
            this.btndefault.Name = "btndefault";
            this.btndefault.Size = new System.Drawing.Size(32, 23);
            this.btndefault.TabIndex = 22;
            this.btndefault.Text = "Θn";
            this.btndefault.UseVisualStyleBackColor = false;
            this.btndefault.Click += new System.EventHandler(this.btndefault_Click);
            // 
            // btnMini
            // 
            this.btnMini.BackColor = System.Drawing.Color.DimGray;
            this.btnMini.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMini.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnMini.ForeColor = System.Drawing.Color.White;
            this.btnMini.Location = new System.Drawing.Point(291, 0);
            this.btnMini.Name = "btnMini";
            this.btnMini.Size = new System.Drawing.Size(20, 20);
            this.btnMini.TabIndex = 23;
            this.btnMini.Text = "-";
            this.btnMini.UseVisualStyleBackColor = false;
            this.btnMini.Click += new System.EventHandler(this.btnMini_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Brown;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Location = new System.Drawing.Point(310, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(20, 20);
            this.btnClose.TabIndex = 24;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnatras
            // 
            this.btnatras.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnatras.BackgroundImage")));
            this.btnatras.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnatras.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnatras.Location = new System.Drawing.Point(12, 7);
            this.btnatras.Name = "btnatras";
            this.btnatras.Size = new System.Drawing.Size(25, 25);
            this.btnatras.TabIndex = 0;
            this.btnatras.UseVisualStyleBackColor = true;
            this.btnatras.Click += new System.EventHandler(this.btnatras_Click);
            // 
            // btnplay
            // 
            this.btnplay.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnplay.BackgroundImage")));
            this.btnplay.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnplay.Location = new System.Drawing.Point(43, 7);
            this.btnplay.Name = "btnplay";
            this.btnplay.Size = new System.Drawing.Size(25, 25);
            this.btnplay.TabIndex = 1;
            this.btnplay.UseVisualStyleBackColor = true;
            this.btnplay.Click += new System.EventHandler(this.btnplay_Click);
            // 
            // btnnext
            // 
            this.btnnext.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnnext.BackgroundImage")));
            this.btnnext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnnext.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnnext.Location = new System.Drawing.Point(74, 7);
            this.btnnext.Name = "btnnext";
            this.btnnext.Size = new System.Drawing.Size(25, 25);
            this.btnnext.TabIndex = 2;
            this.btnnext.UseVisualStyleBackColor = true;
            this.btnnext.Click += new System.EventHandler(this.btnnext_Click);
            // 
            // Volumen
            // 
            this.Volumen.AutoSize = false;
            this.Volumen.BackColor = System.Drawing.Color.Black;
            this.Volumen.Location = new System.Drawing.Point(287, 97);
            this.Volumen.Name = "Volumen";
            this.Volumen.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.Volumen.Size = new System.Drawing.Size(36, 69);
            this.Volumen.TabIndex = 3;
            this.Volumen.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.Volumen.Value = 5;
            this.Volumen.ValueChanged += new System.EventHandler(this.Volumen_ValueChanged);
            // 
            // PanelInferior
            // 
            this.PanelInferior.AllowDrop = true;
            this.PanelInferior.BackColor = System.Drawing.Color.Black;
            this.PanelInferior.Controls.Add(this.lbDrop);
            this.PanelInferior.Controls.Add(this.Final);
            this.PanelInferior.Controls.Add(this.Conteo);
            this.PanelInferior.Controls.Add(this.lbBarra);
            this.PanelInferior.Controls.Add(this.label1);
            this.PanelInferior.Controls.Add(this.btnnext);
            this.PanelInferior.Controls.Add(this.btnatras);
            this.PanelInferior.Controls.Add(this.btnplay);
            this.PanelInferior.Cursor = System.Windows.Forms.Cursors.Default;
            this.PanelInferior.ForeColor = System.Drawing.Color.Black;
            this.PanelInferior.Location = new System.Drawing.Point(0, 169);
            this.PanelInferior.Name = "PanelInferior";
            this.PanelInferior.Size = new System.Drawing.Size(331, 44);
            this.PanelInferior.TabIndex = 4;
            this.PanelInferior.DragDrop += new System.Windows.Forms.DragEventHandler(this.PanelInferior_DragDrop);
            this.PanelInferior.DragEnter += new System.Windows.Forms.DragEventHandler(this.PanelInferior_DragEnter);
            // 
            // btndescarga
            // 
            this.btndescarga.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btndescarga.BackgroundImage")));
            this.btndescarga.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btndescarga.Location = new System.Drawing.Point(321, 20);
            this.btndescarga.Name = "btndescarga";
            this.btndescarga.Size = new System.Drawing.Size(28, 28);
            this.btndescarga.TabIndex = 38;
            this.btndescarga.UseVisualStyleBackColor = true;
            this.btndescarga.Visible = false;
            this.btndescarga.Click += new System.EventHandler(this.btndescarga_Click);
            // 
            // btnEmi1
            // 
            this.btnEmi1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnEmi1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEmi1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmi1.Location = new System.Drawing.Point(148, 12);
            this.btnEmi1.Name = "btnEmi1";
            this.btnEmi1.Size = new System.Drawing.Size(56, 23);
            this.btnEmi1.TabIndex = 39;
            this.btnEmi1.Text = "Hot 108";
            this.btnEmi1.UseVisualStyleBackColor = false;
            this.btnEmi1.Visible = false;
            this.btnEmi1.Click += new System.EventHandler(this.btnEmi1_Click);
            // 
            // btnEmi2
            // 
            this.btnEmi2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnEmi2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEmi2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmi2.Location = new System.Drawing.Point(148, 35);
            this.btnEmi2.Name = "btnEmi2";
            this.btnEmi2.Size = new System.Drawing.Size(56, 23);
            this.btnEmi2.TabIndex = 40;
            this.btnEmi2.Text = "Reggae";
            this.btnEmi2.UseVisualStyleBackColor = false;
            this.btnEmi2.Visible = false;
            this.btnEmi2.Click += new System.EventHandler(this.btnEmi2_Click);
            // 
            // btnEmi3
            // 
            this.btnEmi3.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnEmi3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEmi3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmi3.Location = new System.Drawing.Point(148, 59);
            this.btnEmi3.Name = "btnEmi3";
            this.btnEmi3.Size = new System.Drawing.Size(56, 23);
            this.btnEmi3.TabIndex = 41;
            this.btnEmi3.Text = "181.FM";
            this.btnEmi3.UseVisualStyleBackColor = false;
            this.btnEmi3.Visible = false;
            this.btnEmi3.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnEmi4
            // 
            this.btnEmi4.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnEmi4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEmi4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F);
            this.btnEmi4.Location = new System.Drawing.Point(148, 82);
            this.btnEmi4.Name = "btnEmi4";
            this.btnEmi4.Size = new System.Drawing.Size(56, 23);
            this.btnEmi4.TabIndex = 42;
            this.btnEmi4.Text = "YouTube";
            this.btnEmi4.UseVisualStyleBackColor = false;
            this.btnEmi4.Visible = false;
            this.btnEmi4.Click += new System.EventHandler(this.button2_Click);
            // 
            // Op4
            // 
            this.Op4.BackColor = System.Drawing.Color.Khaki;
            this.Op4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Op4.Location = new System.Drawing.Point(210, 83);
            this.Op4.Name = "Op4";
            this.Op4.Size = new System.Drawing.Size(63, 23);
            this.Op4.TabIndex = 43;
            this.Op4.Text = "Online";
            this.Op4.UseVisualStyleBackColor = false;
            this.Op4.Visible = false;
            this.Op4.Click += new System.EventHandler(this.Op4_Click);
            // 
            // Op3
            // 
            this.Op3.BackColor = System.Drawing.Color.Khaki;
            this.Op3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Op3.Location = new System.Drawing.Point(210, 59);
            this.Op3.Name = "Op3";
            this.Op3.Size = new System.Drawing.Size(63, 23);
            this.Op3.TabIndex = 44;
            this.Op3.Text = "Borrar";
            this.Op3.UseVisualStyleBackColor = false;
            this.Op3.Visible = false;
            this.Op3.Click += new System.EventHandler(this.Op3_Click);
            // 
            // Op2
            // 
            this.Op2.BackColor = System.Drawing.Color.Khaki;
            this.Op2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Op2.Location = new System.Drawing.Point(210, 36);
            this.Op2.Name = "Op2";
            this.Op2.Size = new System.Drawing.Size(63, 23);
            this.Op2.TabIndex = 45;
            this.Op2.Text = "PlayList";
            this.Op2.UseVisualStyleBackColor = false;
            this.Op2.Visible = false;
            this.Op2.Click += new System.EventHandler(this.Op2_Click);
            // 
            // Op1
            // 
            this.Op1.BackColor = System.Drawing.Color.Khaki;
            this.Op1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Op1.Location = new System.Drawing.Point(210, 12);
            this.Op1.Name = "Op1";
            this.Op1.Size = new System.Drawing.Size(63, 23);
            this.Op1.TabIndex = 46;
            this.Op1.Text = "Agregar";
            this.Op1.UseVisualStyleBackColor = false;
            this.Op1.Visible = false;
            this.Op1.Click += new System.EventHandler(this.Op1_Click);
            // 
            // ListaReproduccion
            // 
            this.ListaReproduccion.BackColor = System.Drawing.Color.Black;
            this.ListaReproduccion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ListaReproduccion.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.ListaReproduccion.FormattingEnabled = true;
            this.ListaReproduccion.Location = new System.Drawing.Point(148, 12);
            this.ListaReproduccion.Name = "ListaReproduccion";
            this.ListaReproduccion.Size = new System.Drawing.Size(126, 130);
            this.ListaReproduccion.TabIndex = 12;
            this.ListaReproduccion.Visible = false;
            this.ListaReproduccion.SelectedIndexChanged += new System.EventHandler(this.ListaReproduccion_SelectedIndexChanged);
            // 
            // Navedescarga
            // 
            this.Navedescarga.Location = new System.Drawing.Point(5, 10);
            this.Navedescarga.MinimumSize = new System.Drawing.Size(20, 20);
            this.Navedescarga.Name = "Navedescarga";
            this.Navedescarga.ScriptErrorsSuppressed = true;
            this.Navedescarga.Size = new System.Drawing.Size(113, 129);
            this.Navedescarga.TabIndex = 47;
            this.Navedescarga.Url = new System.Uri("http://offliberty.com/", System.UriKind.Absolute);
            this.Navedescarga.Visible = false;
            // 
            // NaveTube
            // 
            this.NaveTube.Location = new System.Drawing.Point(5, 10);
            this.NaveTube.MinimumSize = new System.Drawing.Size(20, 20);
            this.NaveTube.Name = "NaveTube";
            this.NaveTube.Size = new System.Drawing.Size(113, 129);
            this.NaveTube.TabIndex = 31;
            this.NaveTube.Url = new System.Uri("https://www.youtube.com/", System.UriKind.Absolute);
            this.NaveTube.Visible = false;
            // 
            // ReproductorMini
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(331, 210);
            this.Controls.Add(this.Navedescarga);
            this.Controls.Add(this.Op1);
            this.Controls.Add(this.Op2);
            this.Controls.Add(this.Op3);
            this.Controls.Add(this.Op4);
            this.Controls.Add(this.btnEmi4);
            this.Controls.Add(this.btnEmi3);
            this.Controls.Add(this.btnEmi2);
            this.Controls.Add(this.btnEmi1);
            this.Controls.Add(this.btndescarga);
            this.Controls.Add(this.lbPanel2);
            this.Controls.Add(this.lbMover);
            this.Controls.Add(this.lbOcultar);
            this.Controls.Add(this.NaveTube);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnMini);
            this.Controls.Add(this.btndefault);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Ilustra);
            this.Controls.Add(this.ListaReproduccion);
            this.Controls.Add(this.NameCancion);
            this.Controls.Add(this.Opciones);
            this.Controls.Add(this.PanelInferior);
            this.Controls.Add(this.Volumen);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ReproductorMini";
            this.Text = "Música";
            this.Load += new System.EventHandler(this.ReproductorMini_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Ilustra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Volumen)).EndInit();
            this.PanelInferior.ResumeLayout(false);
            this.PanelInferior.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnatras;
        private System.Windows.Forms.Button btnplay;
        private System.Windows.Forms.Button btnnext;
        private System.Windows.Forms.Button btndescarga;
        private System.Windows.Forms.Button btnEmi1;
        private System.Windows.Forms.Button btnEmi2;
        private System.Windows.Forms.Button btnEmi3;
        private System.Windows.Forms.Button btnEmi4;
        private System.Windows.Forms.Button btndefault;
        private System.Windows.Forms.Button btnMini;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button Opciones;
        private System.Windows.Forms.Button Op4;
        private System.Windows.Forms.Button Op3;
        private System.Windows.Forms.Button Op2;
        private System.Windows.Forms.Button Op1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbDrop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbBarra;
        private System.Windows.Forms.Label Conteo;
        private System.Windows.Forms.Label NameCancion;
        private System.Windows.Forms.Label Final;
        private System.Windows.Forms.Label lbOcultar;
        private System.Windows.Forms.Label lbMover;
        private System.Windows.Forms.Label lbPanel2;
        private System.Windows.Forms.ListBox ListaReproduccion;
        private System.Windows.Forms.PictureBox Ilustra;
        private System.Windows.Forms.WebBrowser NaveTube;
        private System.Windows.Forms.WebBrowser Navedescarga;
        private System.Windows.Forms.TrackBar Volumen;
        private System.Windows.Forms.Panel PanelInferior;


        
    }
}

