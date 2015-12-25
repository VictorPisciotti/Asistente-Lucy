namespace Asistente_personal_Lucy
{
    partial class Asistente_virtual
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Asistente_virtual));
            this.Escucha = new System.Windows.Forms.Label();
            this.captado = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.Notificacion = new System.Windows.Forms.NotifyIcon(this.components);
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.AlarmaSP = new System.ComponentModel.BackgroundWorker();
            this.button2 = new System.Windows.Forms.Button();
            this.txbname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listTemas = new System.Windows.Forms.ListBox();
            this.Flecha = new System.Windows.Forms.Button();
            this.AnotacionesSP = new System.ComponentModel.BackgroundWorker();
            this.button3 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.labelmostrar = new System.Windows.Forms.Label();
            this.Reiniciar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Escucha
            // 
            this.Escucha.BackColor = System.Drawing.Color.Transparent;
            this.Escucha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Escucha.ForeColor = System.Drawing.Color.Lime;
            this.Escucha.Location = new System.Drawing.Point(71, 61);
            this.Escucha.Name = "Escucha";
            this.Escucha.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Escucha.Size = new System.Drawing.Size(75, 13);
            this.Escucha.TabIndex = 3;
            this.Escucha.Text = "Reconocido";
            this.Escucha.Visible = false;
            // 
            // captado
            // 
            this.captado.BackColor = System.Drawing.Color.Transparent;
            this.captado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.captado.ForeColor = System.Drawing.Color.Red;
            this.captado.Location = new System.Drawing.Point(70, 37);
            this.captado.Name = "captado";
            this.captado.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.captado.Size = new System.Drawing.Size(75, 15);
            this.captado.TabIndex = 4;
            this.captado.Text = "Escuchando...";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(193, -1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 25);
            this.button1.TabIndex = 10;
            this.button1.Text = "▬";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Notificacion
            // 
            this.Notificacion.Icon = ((System.Drawing.Icon)(resources.GetObject("Notificacion.Icon")));
            this.Notificacion.Text = "Speech Lucy";
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.Color.Coral;
            this.progressBar1.ForeColor = System.Drawing.Color.Red;
            this.progressBar1.Location = new System.Drawing.Point(64, 50);
            this.progressBar1.MarqueeAnimationSpeed = 40000;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.progressBar1.RightToLeftLayout = true;
            this.progressBar1.Size = new System.Drawing.Size(81, 10);
            this.progressBar1.Step = 50;
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 11;
            this.progressBar1.Value = 50;
            // 
            // AlarmaSP
            // 
            this.AlarmaSP.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Black;
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F);
            this.button2.ForeColor = System.Drawing.Color.Transparent;
            this.button2.Location = new System.Drawing.Point(0, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(25, 25);
            this.button2.TabIndex = 13;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txbname
            // 
            this.txbname.BackColor = System.Drawing.Color.DimGray;
            this.txbname.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbname.ForeColor = System.Drawing.Color.Yellow;
            this.txbname.Location = new System.Drawing.Point(2, 66);
            this.txbname.Name = "txbname";
            this.txbname.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txbname.Size = new System.Drawing.Size(53, 13);
            this.txbname.TabIndex = 18;
            this.txbname.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txbname.TextChanged += new System.EventHandler(this.txbname_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Aqua;
            this.label2.Location = new System.Drawing.Point(4, 47);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Usuario:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listTemas
            // 
            this.listTemas.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.listTemas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listTemas.ForeColor = System.Drawing.Color.Black;
            this.listTemas.FormattingEnabled = true;
            this.listTemas.Items.AddRange(new object[] {
            "Azul",
            "Negro",
            "Verde",
            "Naranja",
            "Indigo",
            "Glass"});
            this.listTemas.Location = new System.Drawing.Point(107, 54);
            this.listTemas.Name = "listTemas";
            this.listTemas.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.listTemas.Size = new System.Drawing.Size(44, 78);
            this.listTemas.TabIndex = 21;
            this.listTemas.Visible = false;
            this.listTemas.SelectedIndexChanged += new System.EventHandler(this.listTemas_SelectedIndexChanged);
            // 
            // Flecha
            // 
            this.Flecha.BackColor = System.Drawing.Color.DimGray;
            this.Flecha.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Flecha.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Flecha.ForeColor = System.Drawing.Color.Lime;
            this.Flecha.Location = new System.Drawing.Point(198, 66);
            this.Flecha.Name = "Flecha";
            this.Flecha.Size = new System.Drawing.Size(17, 30);
            this.Flecha.TabIndex = 24;
            this.Flecha.Text = "<";
            this.Flecha.UseVisualStyleBackColor = false;
            this.Flecha.Visible = false;
            this.Flecha.Click += new System.EventHandler(this.Flecha_Click);
            // 
            // AnotacionesSP
            // 
            this.AnotacionesSP.DoWork += new System.ComponentModel.DoWorkEventHandler(this.AnotacionesSP_DoWork);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Black;
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.button3.ForeColor = System.Drawing.Color.Transparent;
            this.button3.Location = new System.Drawing.Point(156, 133);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(60, 21);
            this.button3.TabIndex = 30;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button6
            // 
            this.button6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button6.BackgroundImage")));
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.ForeColor = System.Drawing.Color.DimGray;
            this.button6.Location = new System.Drawing.Point(7, 101);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(32, 26);
            this.button6.TabIndex = 28;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Visible = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Black;
            this.button5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button5.BackgroundImage")));
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button5.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.button5.ForeColor = System.Drawing.Color.Transparent;
            this.button5.Location = new System.Drawing.Point(45, 133);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(58, 21);
            this.button5.TabIndex = 27;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label8
            // 
            this.label8.Cursor = System.Windows.Forms.Cursors.Default;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Image = ((System.Drawing.Image)(resources.GetObject("label8.Image")));
            this.label8.Location = new System.Drawing.Point(215, -2);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(199, 156);
            this.label8.TabIndex = 26;
            this.label8.Visible = false;
            // 
            // label7
            // 
            this.label7.Cursor = System.Windows.Forms.Cursors.Default;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Image = ((System.Drawing.Image)(resources.GetObject("label7.Image")));
            this.label7.Location = new System.Drawing.Point(215, -2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(199, 156);
            this.label7.TabIndex = 25;
            this.label7.Visible = false;
            // 
            // label5
            // 
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Image = ((System.Drawing.Image)(resources.GetObject("label5.Image")));
            this.label5.Location = new System.Drawing.Point(215, -2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(199, 156);
            this.label5.TabIndex = 22;
            this.label5.Visible = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Black;
            this.button4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button4.BackgroundImage")));
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.button4.ForeColor = System.Drawing.Color.Transparent;
            this.button4.Location = new System.Drawing.Point(101, 133);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(55, 21);
            this.button4.TabIndex = 20;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // labelmostrar
            // 
            this.labelmostrar.BackColor = System.Drawing.Color.Black;
            this.labelmostrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.labelmostrar.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelmostrar.ForeColor = System.Drawing.Color.Lime;
            this.labelmostrar.Image = ((System.Drawing.Image)(resources.GetObject("labelmostrar.Image")));
            this.labelmostrar.Location = new System.Drawing.Point(1, -1);
            this.labelmostrar.Name = "labelmostrar";
            this.labelmostrar.Size = new System.Drawing.Size(215, 37);
            this.labelmostrar.TabIndex = 5;
            this.labelmostrar.Text = "Bienvenido";
            this.labelmostrar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelmostrar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelmostrar_MouseDown);
            this.labelmostrar.MouseEnter += new System.EventHandler(this.labelmostrar_MouseEnter);
            // 
            // Reiniciar
            // 
            this.Reiniciar.BackColor = System.Drawing.Color.Black;
            this.Reiniciar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Reiniciar.BackgroundImage")));
            this.Reiniciar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Reiniciar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Reiniciar.ForeColor = System.Drawing.Color.Transparent;
            this.Reiniciar.Location = new System.Drawing.Point(0, 133);
            this.Reiniciar.Name = "Reiniciar";
            this.Reiniciar.Size = new System.Drawing.Size(46, 21);
            this.Reiniciar.TabIndex = 0;
            this.Reiniciar.UseVisualStyleBackColor = false;
            this.Reiniciar.Click += new System.EventHandler(this.Reiniciar_Click);
            // 
            // Asistente_virtual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.DimGray;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(412, 154);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Flecha);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.listTemas);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txbname);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelmostrar);
            this.Controls.Add(this.captado);
            this.Controls.Add(this.Escucha);
            this.Controls.Add(this.Reiniciar);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Asistente_virtual";
            this.Opacity = 0D;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Speech Lucy";
            this.TransparencyKey = System.Drawing.Color.DimGray;
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.Asistente_virtual_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Reiniciar;
        private System.Windows.Forms.Label Escucha;
        private System.Windows.Forms.Label captado;
        private System.Windows.Forms.Label labelmostrar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NotifyIcon Notificacion;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker AlarmaSP;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txbname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ListBox listTemas;
        private System.Windows.Forms.Button Flecha;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.ComponentModel.BackgroundWorker AnotacionesSP;
        private System.Windows.Forms.Button button3;
    }
}

