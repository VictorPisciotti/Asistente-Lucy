#region NameSpace
using System;
using System.Windows.Forms;
using System.Windows.Threading;
using WMPLib;
using TagLib;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO;
using System.Diagnostics;
using System.Globalization;
#endregion NameSpace

namespace Reproductor_Compacto
{
    public partial class ReproductorMini : Form
    {
#region Declaraciones Universales

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);
        
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]//Para capturar el mouse,Mover Form
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]//Para captura posicion del mouse,Mover Form
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        
        enum ModificadordeTecla
        {
            None = 0,
            Alt = 1,
            Control = 2,
            Shift = 4,
            WinKey = 8
        }
        WindowsMediaPlayer Reproductor = new WindowsMediaPlayer();
        DispatcherTimer Comparador; DispatcherTimer Duracion; DispatcherTimer Nombre; DispatcherTimer Barra; DispatcherTimer Msg; DispatcherTimer ColorForm;
        int vecesplay = 1; int vecesclick = 1; int vecesclickocultar = 1; int vecesIlustra = 1; int vecesCaratula = 1; int conId = 1; int Ocultar = 1; int contdescarga = 1;
        bool RadioClick = false;
        string [] Coleccion;
        string Artista = ""; string Genero; bool VerIlustra = false;
        string Filtro = "Archivos de audio mp3 (*.mp3)|*.mp3";
        string Ruta = "C:\\Speech Lucy\\Reproductor Compacto\\Reproductor Compacto\\bin\\Debug\\Imagenes\\Generos\\";
        ListBox Lista = new ListBox();//http://offliberty.com/
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReproductorMini));
        
        #endregion Declaraciones Universales

#region Principal Load
        public ReproductorMini()
        {
            InitializeComponent();
            IdTeclado();
        }
        private void IdTeclado()
        {
            int id = 0; int id2 = 1; int id3 = 2; int id4 = 3; int id5 = 4; int id6 = 5; int id7 = 6; int id8 = 7;
            RegisterHotKey(this.Handle, id,  (int)ModificadordeTecla.Control, Keys.D1.GetHashCode()); //Emisora 1       
            RegisterHotKey(this.Handle, id2, (int)ModificadordeTecla.Control, Keys.D2.GetHashCode()); //Emisora 2    
            RegisterHotKey(this.Handle, id3, (int)ModificadordeTecla.Control, Keys.D3.GetHashCode()); //Emisora 3  
            RegisterHotKey(this.Handle, id8, (int)ModificadordeTecla.Control, Keys.D4.GetHashCode()); //YouTube
            RegisterHotKey(this.Handle, id4, (int)ModificadordeTecla.Alt, Keys.Up.GetHashCode()); //Volumen Up
            RegisterHotKey(this.Handle, id5, (int)ModificadordeTecla.Alt, Keys.Down.GetHashCode()); //Volumen Down
            RegisterHotKey(this.Handle, id6, (int)ModificadordeTecla.Alt, Keys.Left.GetHashCode()); //Previous Track
            RegisterHotKey(this.Handle, id7, (int)ModificadordeTecla.Alt, Keys.Right.GetHashCode()); //Next Track
        }
        private void ReproductorMini_Load(object sender, EventArgs e)
        {
            RefresDuracion(); RefresComparador(); RefresNombre(); RefresBarra(); lbPanel2.SendToBack(); RefreshColores();
            Ilustra.Image = Image.FromFile(@"C:\Speech Lucy\Reproductor Compacto\Reproductor Compacto\bin\Debug\Imagenes\Nota.jpg");
        }//Carga las actualizaciones necesarias
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == 0x0312)
            {
                int id = m.WParam.ToInt32();

                #region Keys Emisoras

                if (id == 0)
                {
                    Emisora1();
                }
                if (id == 1)
                {
                    Emisora2();
                }
                if (id == 2)
                {
                    Emisora3();
                }
                if (id == 7)
                {
                    YouTube();
                }

                #endregion Keys Emisoras

                #region Keys Control de reproduccion

                if (id == 3)
                {
                   //Volume Up 
                    if (Volumen.Value <= 9)
                    {
                        Volumen.Value = Volumen.Value + 1;    
                    }
                }
                if (id == 4)
                {
                    //Volume Down
                    if (Volumen.Value >= 1)
                    {
                        Volumen.Value = Volumen.Value - 1;    
                    }
                }
                if (id == 5)
                {
                    //Previous Track
                    if (Lista.SelectedIndex > 0 && Reproductor.playState == WMPPlayState.wmppsPlaying)//Se devuelve, osea resta un indice al actual 
                    {
                        Lista.SelectedIndex = Lista.SelectedIndex - 1; ListaReproduccion.SelectedIndex = Lista.SelectedIndex;
                        Reproductor.controls.stop(); Reproductor.controls.pause(); Reproductor.controls.previous(); Reproductor.URL = Lista.SelectedItem.ToString();
                    }
                    else {}
                }
                if (id == 6)
                {
                    //Next Track
                    if (Reproductor.playState == WMPPlayState.wmppsPlaying && Lista.SelectedIndex < Lista.Items.Count | ListaReproduccion.SelectedIndex < ListaReproduccion.Items.Count)
                    {
                        if (this.Lista.SelectedIndex == this.Lista.Items.Count - 1 & Lista.Items.Count > 0)//Si esta en la ultima cancion que se reinicie la lista
                        {
                            Lista.SelectedIndex = 0; ListaReproduccion.SelectedIndex = Lista.SelectedIndex;
                        }
                        else
                        {
                            Lista.SelectedIndex = Lista.SelectedIndex + 1; ListaReproduccion.SelectedIndex = Lista.SelectedIndex;
                            Reproductor.controls.stop(); Reproductor.controls.pause(); Reproductor.controls.next(); Reproductor.URL = Lista.SelectedItem.ToString();
                        }
                    }
                }

                #endregion Keys Control de reproduccion
            }
        }   

        #endregion Principal Load

#region Actualizaciones y cambio de Track

       private void RefresDuracion()
        { Duracion = new DispatcherTimer(); Duracion.Interval = new TimeSpan(0, 0, 1); Duracion.Tick += Duracion_Tick; }
       private void RefresComparador()
        { Comparador = new DispatcherTimer(); Comparador.Interval = new TimeSpan(0, 0, 1); Comparador.Tick += Comparador_Tick; }//Con 3 segundos se corrige el salto de track al pulsar los botones 
       private void RefresNombre()
        {Nombre = new DispatcherTimer(); Nombre.Interval = new TimeSpan(0, 0, 5); Nombre.Tick += Nombre_Tick;}
       private void RefresBarra()
        {Barra = new DispatcherTimer(); Barra.Interval = new TimeSpan(0, 0, 5); Barra.Tick += Barra_Tick;}
       private void RefreshColores()
        { ColorForm = new DispatcherTimer(); ColorForm.Interval = new TimeSpan(0, 0, 30); ColorForm.Tick += Color_Tick; ColorForm.Start(); }
       private void Color_Tick(object sender, EventArgs e)
        {
            if (vecesCaratula == 1)
            {
                Random randomGen = new Random();
                KnownColor [] names = (KnownColor [])Enum.GetValues(typeof(KnownColor));
                KnownColor randomColorName = names [randomGen.Next(names.Length)];
                Color randomColor = Color.FromKnownColor(randomColorName);
                this.BackColor = randomColor; this.lbMover.BackColor = randomColor; this.lbBarra.BackColor = randomColor;
            }
            else {}
        }//Cambia el color de fondo aleatoriamente
       private void Barra_Tick(object sender, EventArgs e)
        {
           //Que va hacer cada 5 segundos ?. Incrementar el tamaño de este -- Limites de incremento : Min 0 & Max 130
            if (Ilustra != null & VerIlustra == true)//Si contiene alguna imagen y se presiona el boton de default
            {
                this.BackgroundImage = Ilustra.Image;//Copia la imagen de ilustracion al formulario con dimensiones diferentes    
            }
            else {}
            lbBarra.Width = lbBarra.Width + 1;
            if (Conteo.Text == "00:02" | lbBarra.Width == 130){lbBarra.Width = 0;}//Se reinicia la barra
            else if (Conteo.Text == ""){lbBarra.Width = 0; Barra.Stop();}
        }//Incrementa la barra de tiempo cada 5 segundos
       private void Nombre_Tick(object sender, EventArgs e)
        {
            //Que va hacer cada 5 segundos ?.Actualizar el nombre de la cancion actual
            if (Lista.Items.Count != 0) { NameCancion.Text = Reproductor.controls.currentItem.name; }
            else if (RadioClick == true) { NameCancion.Text = Reproductor.controls.currentItem.name; }
            else { NameCancion.Text = Reproductor.controls.currentItem.name;}
        }//Actualiza el nombre del Track Actual cada 5 segundos
       private void Duracion_Tick(object sender, EventArgs e)
        {
            //Que va hacer cada segundo ?.Actualizar cuanto dura el Track Actual
            if (Lista.Items.Count != 0) { Final.Text = Reproductor.controls.currentItem.durationString; InfoCanciones(); }
        }//Actualiza la imagen de cada track,se detiene en 00:02 y con Stop
       private void Comparador_Tick(object sender, EventArgs e)
        {
            //Que va hacer cada segundo comparar que el label Conteo este en 00:02
            Conteo.Text = Reproductor.controls.currentPositionString;//Muestra y va contando los segundo del Track
            Barra.Start();//Inicia cuando empieza un track, cada 5s
            if (Conteo.Text == "00:02"){Duracion.Stop();}//Se detiene la duracion del Track
            else if (Conteo.Text == "" & Lista.Items.Count != 0)//Condicion principal para el cambio de Track                          
            {
                for (int i = 0; i < Lista.SelectedItems.Count; i++)
                {
                    if (this.Lista.SelectedIndex == this.Lista.Items.Count - 1)//Si esta en la ultima cancion que se reinicie la lista
                    {
                        Lista.SelectedIndex = 0; ListaReproduccion.SelectedIndex = Lista.SelectedIndex;
                    }
                    else
                    Lista.SelectedIndex = Lista.SelectedIndex + 1;//Cambia de cancion
                    ListaReproduccion.SelectedIndex = Lista.SelectedIndex;//Selecciona el mismo indice en la lista de reproduccion
                    Reproductor.URL = Lista.SelectedItem.ToString();//Reproduce la cancion seleccionada
                    Duracion.Start();//Vuelve a actualizar la duracion del Track
                }
            }
        }//Cambio de Track

        #endregion Actualizaciones y cambio de Track

#region Activaciones
        private void Activaciones()
        {
            Duracion.Start();//Cuanto dura el Track, se detiene en 2s
            Comparador.Start();//Compara si esta en 00:02 para el cambio de Track, cada 1s
            Nombre.Start();//Actualiza el nombre del Track actual, cada 5s
            Barra.Start();//Actualiza la barra de carga
        }//Ensayos (No funciona con emisoras)
#endregion Activaciones

#region Opciones
        private void Opciones_Click(object sender, EventArgs e)
        {
            if (vecesclickocultar == 1)
            {
                ListaReproduccion.Visible = false;
                MostrarOpciones();
                vecesclickocultar = 2;
            }
            else if (vecesclickocultar == 2)
            {
                ListaReproduccion.Visible = false;
                OcultarOpciones();
                vecesclickocultar = 1;
            }
            if (vecesIlustra == 2 & VerIlustra == true)//Se cumple cuando se hace click en agregar y click en Default
            {
                if (Ilustra != null)//Si contiene alguna imagen que oculte Ilustra
                {
                    Ilustra.Visible = false;
                }
                else {}  
            }
            if (NaveTube.Visible == true)
            {
                NaveTube.Visible = false; Final.Visible = true;
            }
        }//Solo muestra 4 opciones
       
        private void Op1_Click(object sender, EventArgs e)
        {
            if (vecesclick == 1)
            {
                OcultarOpciones(); RadioClick = false; vecesIlustra = 2; OpenFileDialog Buscar = new OpenFileDialog();
                Buscar.Title = "Archivos de audio MP3"; Buscar.Filter = Filtro; Buscar.Multiselect = true;
                if (Buscar.ShowDialog() == DialogResult.OK)
                {
                    Coleccion = Buscar.FileNames;//Se agregan en una Matriz
                    foreach (string cancion in Coleccion)//Aqui se recorren las canciones agregadas
                    {
                        Lista.Items.Add(cancion);//Se guardan las canciones en un listbox dinamico
                        Lista.SelectedIndex = 0;//Se selecciona el primer indice del ListBox
                    }
                    foreach (string Nombres in Coleccion)//Aqui se recorre solo el nombre de cada Track
                    {
                        ListaReproduccion.Items.Add(System.IO.Path.GetFileNameWithoutExtension(Nombres));//Se guardan los nombres de las canciones en un listbox
                        ListaReproduccion.SelectedIndex = 0;//Se selecciona el primer indice del ListBox
                    }
                    Reproductor.URL = Lista.SelectedItem.ToString();
                    NameCancion.Text = Reproductor.controls.currentItem.name;
                    Activaciones();
                }
                else { }
            }
            else if (vecesclick != 1)//Para agregar y encolar nuevas canciones
            {
                OcultarOpciones(); OpenFileDialog Buscar = new OpenFileDialog();
                Buscar.Title = "Archivos de audio MP3"; Buscar.Filter = Filtro; Buscar.Multiselect = true;
                if (Buscar.ShowDialog() == DialogResult.OK)
                {
                    string [] Coleccion = Buscar.FileNames;
                    foreach (string cancion in Coleccion)//Aqui se recorren las canciones agregadas
                    {
                        Lista.Items.Add(cancion); Lista.SelectedIndex = 0;
                    }
                    foreach (string Nombres in Coleccion)//Aqui se recorre solo el nombre de cada Track
                    {
                        ListaReproduccion.Items.Add(System.IO.Path.GetFileNameWithoutExtension(Nombres)); ListaReproduccion.SelectedIndex = 0;
                    }
                    Activaciones();
                }
                else {}
            }
        }//Opcion 1 Agrega las canciones
        private void Op2_Click(object sender, EventArgs e)
        {
            OcultarOpciones(); ListaReproduccion.Visible = true;
        }//Opcion 2 Muestra la lista de Reproducción
        private void Op3_Click(object sender, EventArgs e)
        {
            if (Lista.Items != null) { Lista.Items.Clear(); ListaReproduccion.Items.Clear(); lbDrop.Visible = true; }
            else { }
        }//Opcion 3 Elimina las canciones de los ListBox
        private void Op4_Click(object sender, EventArgs e)
        {
            MostrarEmisoras();
        }//Opcion 4 Online
        private void MostrarOpciones()
        {
            Op1.Visible = true;Op2.Visible = true;
            Op3.Visible = true;Op4.Visible = true;
        }
        private void OcultarOpciones()
        {
            Op1.Visible = false;Op2.Visible = false;
            Op3.Visible = false;Op4.Visible = false;
            OcultarEmisoras();
        }

        #endregion Opciones

#region Informacion de Canciones
        private void InfoCanciones()
        {
            if (Coleccion == null)
            {}
            else 
            foreach (string cancion in Coleccion)
            {
                 TagLib.File ArchivoMp3 = TagLib.File.Create(cancion);//Sirve para recorrer las imagenes o informacion de cada Track
                 TagLib.Tag Leerinfo = ArchivoMp3.GetTag(TagTypes.Id3v2);//Solo sirve para informacion tipo string
                 Artista = Leerinfo.FirstAlbumArtist;
                 string Letra = Leerinfo.Lyrics;//Si la cancion contiene letra se guarda en un string
                 Genero = Leerinfo.FirstGenre;//Lleva el nombre del artista y el genero
                 Ilustraciones();
            }
        }
        #endregion Informacion de Canciones

#region Ilustraciones
        private void Ilustraciones()
        {
            if (Artista == "Afaz Natural")
            {Ilustra.Image = Image.FromFile(Ruta + "Afaz.jpg");}
            else if (Artista == "R & B" | Genero == "R & B")
            { Ilustra.Image = Image.FromFile(Ruta + "R & B.jpg"); }
            else if (Artista == "AlcolirykoZ")
            { Ilustra.Image = Image.FromFile(Ruta + "Alcolirykoz.jpg"); }
            else if (Artista == "Asilo 38")
            {Ilustra.Image = Image.FromFile(Ruta + "Asilo 38.jpg"); }
            else if (Artista == "Barrington Levy")
            { Ilustra.Image = Image.FromFile(Ruta + "B Levy.jpg"); }
            else if (Artista == "Bob Marley")
            { Ilustra.Image = Image.FromFile(Ruta + "bob marley.jpg"); }
            else if (Artista == "Canserbero")
            { Ilustra.Image = Image.FromFile(Ruta + "Canserbero.jpg"); }
            else if (Artista == "Hip Hop" | Genero == "Hip Hop")
            { Ilustra.Image = Image.FromFile(Ruta + "Hip Hop.jpg"); }
            else if (Artista == "Open")
            { Ilustra.Image = Image.FromFile(Ruta + "Open.jpg"); }
            else if (Artista == "Cultura Profetica")
            { Ilustra.Image = Image.FromFile(Ruta + "cultura profetica.jpg"); }
            else if (Artista == "Reggae" | Genero == "Reggae")
            { Ilustra.Image = Image.FromFile(Ruta + "reggae 1.jpg"); }
            else if (Artista == "Rock" | Genero == "Rock")
            { Ilustra.Image = Image.FromFile(Ruta + "Rock.jpg"); }
            else if (Artista == "Swan")
            { Ilustra.Image = Image.FromFile(Ruta + "swan.jpg"); }
            else if (Artista == "Paramore")
            { Ilustra.Image = Image.FromFile(Ruta + "paramore.jpg"); }
            else if (Artista == "Nach")
            { Ilustra.Image = Image.FromFile(Ruta + "nach.jpg"); }
            else if (Artista == "Trey Songz")
            { Ilustra.Image = Image.FromFile(Ruta + "Trey.jpg"); }
            else {}
            Artista = "";Genero = "";

        }//Se comparan los Artistas ó Generos para agregar su caratula
        #endregion Ilustraciones

#region Volumen
        private void Volumen_ValueChanged(object sender, EventArgs e)
        {
            if (Volumen.Value == 0) { Reproductor.settings.mute = true; }
            if (Volumen.Value == 1) { Reproductor.settings.mute = false; Reproductor.settings.volume = 10; }
            if (Volumen.Value == 2) { Reproductor.settings.volume = 20; }if (Volumen.Value == 3) { Reproductor.settings.volume = 30; }
            if (Volumen.Value == 4) { Reproductor.settings.volume = 40; }if (Volumen.Value == 5) { Reproductor.settings.volume = 50; }
            if (Volumen.Value == 6) { Reproductor.settings.volume = 60; }if (Volumen.Value == 7) { Reproductor.settings.volume = 70; }
            if (Volumen.Value == 8) { Reproductor.settings.volume = 80; }if (Volumen.Value == 9) { Reproductor.settings.volume = 90; }
            if (Volumen.Value == 10) { Reproductor.settings.volume = 100;}
        }
        #endregion Volumen

#region Botones de reproduccion
        private void btnatras_Click(object sender, EventArgs e)
        {
            if (Lista.SelectedIndex > 0 & Reproductor.playState == WMPPlayState.wmppsPlaying)//Se devuelve, osea resta un indice al actual 
            {
                Lista.SelectedIndex = Lista.SelectedIndex - 1;ListaReproduccion.SelectedIndex = Lista.SelectedIndex;
                Reproductor.controls.stop();Reproductor.controls.pause();Reproductor.controls.previous();Reproductor.URL = Lista.SelectedItem.ToString();
            }
        }//Boton Anterior
        private void btnplay_Click(object sender, EventArgs e)
        {
            if (vecesplay == 1 & Reproductor.playState == WMPPlayState.wmppsPlaying)
            {
                DetenerReproduccion();
                btnplay.Image = Image.FromFile(@"C:\Speech Lucy\Reproductor Compacto\Reproductor Compacto\bin\Debug\Imagenes\Stop.jpg");
                vecesplay = 2;
            }
            else if (vecesplay == 2 & Reproductor.playState == WMPPlayState.wmppsStopped)
            {
                if (ListaReproduccion.SelectedIndex != 0){Reproductor.URL = ListaReproduccion.SelectedItem.ToString();}
                else
                Reproductor.controls.play();
                Activaciones();
                btnplay.Image = Image.FromFile(@"C:\Speech Lucy\Reproductor Compacto\Reproductor Compacto\bin\Debug\Imagenes\Play.jpg");
                vecesplay = 1;//Se reinicia
            }
        }//Boton Play / Pause
        private void btnnext_Click(object sender, EventArgs e)
        {
            if (Reproductor.playState == WMPPlayState.wmppsPlaying & Lista.SelectedIndex < Lista.Items.Count | ListaReproduccion.SelectedIndex < ListaReproduccion.Items.Count)
            {
                if (this.Lista.SelectedIndex == this.Lista.Items.Count - 1 & Lista.SelectedIndex == 0)//Si esta en la ultima cancion que se reinicie la lista
                {
                    Lista.SelectedIndex = 0;ListaReproduccion.SelectedIndex = Lista.SelectedIndex;
                }
                else if (Lista.Items.Count != 0 & this.Lista.SelectedIndex != this.Lista.Items.Count - 1)
                {
                    Lista.SelectedIndex = Lista.SelectedIndex + 1;ListaReproduccion.SelectedIndex = Lista.SelectedIndex;
                    Reproductor.controls.stop();Reproductor.controls.pause();Reproductor.controls.next();Reproductor.URL = Lista.SelectedItem.ToString();
                }
            }
        }//Boton Siguiente
        private void DetenerReproduccion()
        {
            Reproductor.controls.stop();
            Barra.Stop();
            Comparador.Stop();
            Duracion.Stop();
            Nombre.Stop();   
        }//No se detiene o pausa cuando conecta a las emisoras
       
        #endregion Botones de reproduccion

#region Cambio de track cuando se selecciona
        private void ListaReproduccion_SelectedIndexChanged(object sender, EventArgs e)
        { Lista.SelectedIndex = ListaReproduccion.SelectedIndex; Reproductor.URL = Lista.SelectedItem.ToString(); Duracion.Start(); Activaciones(); }
        #endregion Cambio track cuando se selecciona

#region Mover el Form
        private void lbMover_MouseDown(object sender, MouseEventArgs e)
        {ReleaseCapture(); SendMessage(this.Handle, 0x112, 0xf012, 0); }
        #endregion Mover el Form

#region Botones Comunes
        private void btndefault_Click(object sender, EventArgs e)
        {
            if (vecesCaratula == 1)//Tamaño Adaptable de los objetos
            {
                vecesCaratula = 2; VerIlustra = true;
                Ilustra.Visible = false; 
                ListaReproduccion.Width = 262;
                ListaReproduccion.Location = new Point(12,12);
                NameCancion.Width = 260;
                NameCancion.ForeColor = Color.Gold;
                btndefault.BackColor = Color.DarkRed;
                this.lbMover.BackColor = Color.Black;
                lbMover.Size = new Size(288, 13);
                btndefault.Text = "Θff";
            }
            else if (vecesCaratula == 2)//Tamaño Original de los objetos
            {
                vecesCaratula = 1; VerIlustra = false; 
                Ilustra.Visible = true; 
                this.BackgroundImage = null;
                this.BackColor = Color.Black; 
                ListaReproduccion.Width = 126;
                ListaReproduccion.Location = new Point(148, 12);
                NameCancion.Width = 130;
                NameCancion.ForeColor = Color.Gold;
                btndefault.BackColor = Color.YellowGreen;
                lbMover.Size = new Size(43, 13);
                btndefault.Text = "Θn";
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {Application.Exit();}
        private void btnMini_Click(object sender, EventArgs e)
        {this.WindowState = FormWindowState.Minimized; }
        #endregion Botones Comunes

#region Drag & Drop

        private void PanelInferior_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
        private void PanelInferior_DragDrop(object sender, DragEventArgs e)
        {
            lbDrop.Visible = false;
            string[] Coleccion = (string[])e.Data.GetData(DataFormats.FileDrop, false);//Lleva la ruta de las canciones
            foreach (string cancion in Coleccion)//Aqui se recorren las canciones agregadas
            {
                Lista.Items.Add(Path.GetFullPath(cancion));//Lleva la ruta completa con la extension
                Lista.SelectedIndex = 0;
            }
            foreach (string Nombre in Coleccion)
            {
                ListaReproduccion.Items.Add(Path.GetFileNameWithoutExtension(Nombre));//Solo trae los nombres
                ListaReproduccion.SelectedIndex = 0; Activaciones(); Ilustraciones();
            }
        }                      

        #endregion Drag & Drop

#region Online

        private void btnEmi1_Click(object sender, EventArgs e)
        {
            Emisora1();
        }
        private void btnEmi2_Click(object sender, EventArgs e)
        {
            Emisora2();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Emisora3();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            YouTube(); 
        }

        #region Emisoras & YouTube
        private void Emisora1()
        {
            try
            {
                DetenerReproduccion(); OcultarEmisoras(); OcultarOpciones(); RadioClik(); Artista = "R & B"; Ilustraciones();
                Reproductor.URL = "http://108.61.30.179:4010"; Nombre.Start();
            }
            catch (Exception Ex) { MessageBox.Show(Ex.Message); }
        }
        private void Emisora2()
        {
            try
            {
                DetenerReproduccion(); OcultarEmisoras(); OcultarOpciones(); RadioClik(); Artista = "Reggae"; Ilustraciones();
                Reproductor.URL = "http://184.107.197.154:8002"; Nombre.Start();
            }
            catch (Exception Ex) { MessageBox.Show(Ex.Message); }
        }
        private void Emisora3()
        {
            try
            {
                DetenerReproduccion(); OcultarEmisoras(); OcultarOpciones(); RadioClik(); Artista = "R & B"; Ilustraciones();
                Reproductor.URL = "http://108.61.73.115:8054"; Nombre.Start();
            }
            catch (Exception Ex) { MessageBox.Show(Ex.Message); }
        }
        private void YouTube()
        {
            try
            {
                if (NaveTube.Visible == false) { NaveTube.Visible = true; }
                DetenerReproduccion(); OcultarEmisoras(); OcultarOpciones(); Ocultarbotones();
                RadioClik(); Agrandar(); Artista = "Youtube";
            }
            catch (Exception Ex) { MessageBox.Show(Ex.Message); } 
        }
        #endregion Emisoras & YouTube

        private void MostrarEmisoras()
        {
            btnEmi1.Visible = true; btnEmi2.Visible = true; btnEmi3.Visible = true; btnEmi4.Visible = true;
        }
        private void OcultarEmisoras()
        {
            btnEmi1.Visible = false; btnEmi2.Visible = false; btnEmi3.Visible = false; btnEmi4.Visible = false;
        }
        private void RadioClik()
        {
            RadioClick = true;
        }
        #endregion  Online

#region Ocultar Botones

        private void lbOcultar_MouseEnter(object sender, EventArgs e)
        {
            if (Ocultar == 1 & NaveTube.Visible == true)
            {
                Ocultar = 2; Agrandar(); Ocultarbotones();
            }
            else if (Ocultar == 2)
            {
                Ocultar = 3;
            }
            else if (Ocultar == 3 & NaveTube.Visible == true)
            {
                Ocultar = 1; Reducir(); Mostrarbotones();
            }
        }
        private void Ocultarbotones()
        {
            NaveTube.Visible = true; Final.Visible = false; btndefault.Visible = false; Opciones.Visible = false; btnClose.Visible = false; btnMini.Visible = false;
        }
        private void Mostrarbotones()
        {
            btndefault.Visible = true; Opciones.Visible = true; btnClose.Visible = true; btnMini.Visible = true; 
        }
        #endregion Ocultar Botones

#region Cambio de tamaño del form
        private void Agrandar()
        {
            lbPanel2.Visible = false;
            PanelInferior.Visible = false;
            this.Size = new Size(463, 300);
            NaveTube.Size = new System.Drawing.Size(454, 285);
            Navedescarga.Size = new System.Drawing.Size(448,285);
            btndescarga.Visible = true;
        }
        private void Reducir()
        {
            Navedescarga.Visible = false;
            btndescarga.Visible = false;
            NaveTube.Size = new System.Drawing.Size(280, 194);
            Navedescarga.Size = new System.Drawing.Size(280, 194);
            this.Size = new Size(331, 210);
            lbPanel2.Visible = true;
            PanelInferior.Visible = true;
            lbMover.Size = new Size(43, 13);
        }

        #endregion Cambio de tamaño del form

#region Descargas
        private void btndescarga_Click(object sender, EventArgs e)
        {
            if (contdescarga == 1)
            {
              contdescarga = 2;
              Clipboard.SetDataObject(NaveTube.Document.Url.ToString());
              //Zoom de pagina x2
              btndescarga.BringToFront();
              Navedescarga.Visible = true; 
            }
            else if (contdescarga == 2)
            {
                contdescarga = 1;Navedescarga.Visible = false; 
            }
        }

        #endregion Descargas

#region PlayList Online
        private void NameCancion_Click(object sender, EventArgs e)
        {

        }
#endregion PlayList Online

    }
}