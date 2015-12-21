using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Threading;
using WMPLib;

namespace Asistente_personal_Lucy
{
    #region Principal
    public partial class Musica : Form
    {
#region Declaraciones Universales

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
     
        OpenFileDialog imagen = new OpenFileDialog(); OpenFileDialog ilustracion = new OpenFileDialog();
        int contadorBarra = 0; int contadorPuntero = 681; int contadorPuntero2 = 686; int contZoom = 1; int contBalance = 1; int contOff = 1; int conEfect = 1; int contTema = 1; int contTxtlink = 1; int contExpan = 1;
        DispatcherTimer Refreshnombre;DispatcherTimer RefreshSlider;DispatcherTimer RefreshDuracion;DispatcherTimer RefresBarra;DispatcherTimer RefreshVumetro;DispatcherTimer RefreshEfecto2;DispatcherTimer TintroM;
        IntroMusica intro1 = new IntroMusica();
        bool reanudar = true;public bool lockMaxMin = true;
        string NoSongs = "No hay canciones en la lista";
        string opcion;
        
        
        #region Resolucion
        private int CamAncho = 1360, CamAlto = 768;//Es la resolucion que se desea cambiar por default        
        int alto = Screen.PrimaryScreen.Bounds.Height;//Obtiene el alto de la pantalla principal en pixeles.
        int ancho = Screen.PrimaryScreen.Bounds.Width; //Obtiene el ancho de la pantalla principal en pixeles.
        #endregion Resolucion
        #region Rutas
        string Ruta = "C:\\Speech Lucy\\Asistente personal Lucy\\Asistente personal Lucy\\bin\\Debug\\Recursos\\Album\\";
        string RutaDisplayRed = "C:\\Speech Lucy\\Asistente personal Lucy\\Asistente personal Lucy\\bin\\Debug\\Recursos\\Display Red\\";
        string RutaDisplayGreen = "C:\\Speech Lucy\\Asistente personal Lucy\\Asistente personal Lucy\\bin\\Debug\\Recursos\\Display Green\\";
        string PlayList = "D:\\MuSiK\\Listas\\";
        string ImgPlayList = "PlayList.gif";
        string Filtro = "Archivos de audio mp3 (*.mp3)|*.mp3|PlayList WMP (*.wpl)|*.wpl";
        string Filtro2 = "Bitmap files (*.bmp)|*.bmp|Gif files (*.gif)|*.gif|JGP files (*.jpg)|*.jpg|All (*.*)|*.* |PNG (*.png)|*.png ";
        #endregion Rutas
        
        #endregion Declaraciones Universales

#region Controles Dinamicos y Radio
         Label Caratula = new   Label(); Label Caratula1 = new  Label();
         Label Caratula2 = new  Label(); Label Caratula3 = new  Label();
         Label Caratula4 = new  Label(); Label Caratula5 = new  Label();
         Label Caratula6 = new  Label(); Label CaratulaRadio = new  Label();
                             //Contadores por cada click
        int BotonUbicacion = 321;int VecesCreacion = 0;int Creacion = 0;int Creacion1  = 0;int Creacion2 = 0;int Creacion3 = 0;int Creacion4 = 0;int Creacion5 = 0;int Creacion6 = 0;
                                //Botones Dinamicos
         Button btn = new  Button();  Button btn1 = new  Button(); Button btn2 = new  Button();
         Button btn3 = new  Button(); Button btn4 = new  Button(); Button btn5 = new  Button();
         Button btn6 = new  Button();
                      //Labels Dinamicos para el nombre de la playlist
         Label lb = new   Label(); Label lb1 = new  Label(); Label lb2 = new  Label();
         Label lb3 = new  Label(); Label lb4 = new  Label(); Label lb5 = new  Label();
         Label lb6 = new  Label();
                 //Se guardan las canciones de cada boton en estos ListBox
         ListBox canciones = new   ListBox(); ListBox canciones1 = new  ListBox(); ListBox canciones2 = new  ListBox();
         ListBox canciones3 = new  ListBox(); ListBox canciones4 = new  ListBox(); ListBox canciones5 = new  ListBox();
         ListBox canciones6 = new  ListBox(); 
                //Se guardan el SOLO nombres de las canciones de cada boton en estos ListBox
         ListBox Lista = new  ListBox(); ListBox Lista1 = new ListBox(); ListBox Lista2 = new ListBox();
         ListBox Lista3 = new ListBox(); ListBox Lista4 = new ListBox(); ListBox Lista5 = new ListBox(); 
         ListBox Lista6 = new ListBox();
        #endregion Controles Dinamicos y Radio

#region Main Load
        public Musica()
        {
            InitializeComponent();
            tiempointro();//1
            Thread Hilo1 = new Thread(LoadImagenes);//Subproceso para cargar las ilustraciones
            Hilo1.Start();
            ActualizarEfectoR();//Alterna el canal R y L
            ActualizarNombre();//Actualiza el nombre del track actual cada segundo
            ActualizarPosicion();//Cuenta cada segundo reproducido del Track
            ActualizarDuracion();//Se detiene a los dos segundos de cada Track
            ActualizacionBarra();//Actualiza la barra de Track
            ActualizarVumetro();//Actualiza el estado del Vumetro cuando se da click en el radio
        }
        private void Musica_Load(object sender, EventArgs e)
        {
            button38.MouseWheel += button38_MouseWheel;//Alto contraste
            PanelSuperior.SendToBack();//Se envia atras de los controles
            label35.SendToBack();//Envia atras el label de mimimizar con el mouse
            MostrarVumetros(); 
            Loadintro();//2 
        }
        private void LoadImagenes()
        {
            
            button1.BackgroundImage = Image.FromFile(Ruta + "Alcolirykoz.gif");
            button2.BackgroundImage = Image.FromFile(Ruta + "Afaz.gif");
            button3.BackgroundImage = Image.FromFile(Ruta + "aldeanos.gif");
            button4.BackgroundImage = Image.FromFile(Ruta + "bob marley.gif");
            button5.BackgroundImage = Image.FromFile(Ruta + "chulito.gif");
            button6.BackgroundImage = Image.FromFile(Ruta + "3 coronas.gif");
            button7.BackgroundImage = Image.FromFile(Ruta + "cultura profetica.gif");
            button8.BackgroundImage = Image.FromFile(Ruta + "descarga.gif");
            button9.BackgroundImage = Image.FromFile(Ruta + "la etnia.gif");
            button10.BackgroundImage = Image.FromFile(Ruta + "mala.gif");
            button11.BackgroundImage = Image.FromFile(Ruta + "MO.gif");
            button12.BackgroundImage = Image.FromFile(Ruta + "morodo.gif");
            button13.BackgroundImage = Image.FromFile(Ruta + "nach.gif");
            button14.BackgroundImage = Image.FromFile(Ruta + "nonpalidece.gif");
            button15.BackgroundImage = Image.FromFile(Ruta + "Norykko.gif");
            button16.BackgroundImage = Image.FromFile(Ruta + "paramore.gif");
            button17.BackgroundImage = Image.FromFile(Ruta + "R & B.gif");
            button18.BackgroundImage = Image.FromFile(Ruta + "reggae 2.gif");
            button19.BackgroundImage = Image.FromFile(Ruta + "Rock.gif");
            button20.BackgroundImage = Image.FromFile(Ruta + "santaflow.gif");
            button21.BackgroundImage = Image.FromFile(Ruta + "skap.gif");
            button22.BackgroundImage = Image.FromFile(Ruta + "swan.gif");
            button23.BackgroundImage = Image.FromFile(Ruta + "tempo.gif");
            button24.BackgroundImage = Image.FromFile(Ruta + "the birthday massacre.gif");
            button25.BackgroundImage = Image.FromFile(Ruta + "xplicitos.gif");
            button26.BackgroundImage = Image.FromFile(Ruta + "ZG.gif");
            //Boton 27 es el de cerrar
            button28.BackgroundImage = Image.FromFile(Ruta + "Trey Songz.gif");
            button29.BackgroundImage = Image.FromFile(Ruta + "doble V.gif");
            button30.BackgroundImage = Image.FromFile(Ruta + "Canserbero.gif");
            button31.BackgroundImage = Image.FromFile(Ruta + "Eminem.gif");
            button32.BackgroundImage = Image.FromFile(Ruta + "Barrington.gif");
            button34.BackgroundImage = Image.FromFile(Ruta + "Clementino.gif");   
        }
        private void Loadintro()
        {
            intro1.Show();
            if (intro1.Visible == true)
            {
                TintroM.Start();
            }
            else {}
        }

        #endregion Main Load

#region Alto Contraste
        void button38_MouseWheel(object sender, MouseEventArgs e)
        {
            Thread Hilo1 = new Thread(LoadCopia);
            DialogResult opcion = MessageBox.Show("Desea activar el tema en alto contraste ?", "Accesibilidad", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (opcion == DialogResult.Yes)
            {
                btnAtras.Text = "<<"; btnStop.Text = "■"; btnPlay.Text = "►"; btnNext.Text = ">>";
                Hilo1.Start(); //Subproceso para copiar las ilustraciones
            }
            else if (opcion == DialogResult.No)
            {
                btnAtras.Text = ""; btnStop.Text = ""; btnPlay.Text = ""; btnNext.Text = "";
            }   
        }
        private void LoadCopia()
        {
            button1.Image = button1.BackgroundImage; button2.Image = button2.BackgroundImage; button3.Image = button3.BackgroundImage; button4.Image = button4.BackgroundImage;
            button5.Image = button5.BackgroundImage; button6.Image = button6.BackgroundImage; button7.Image = button7.BackgroundImage; button8.Image = button8.BackgroundImage;
            button9.Image = button9.BackgroundImage; button10.Image = button10.BackgroundImage; button11.Image = button11.BackgroundImage; button12.Image = button12.BackgroundImage;
            button13.Image = button13.BackgroundImage; button14.Image = button14.BackgroundImage; button15.Image = button15.BackgroundImage; button16.Image = button16.BackgroundImage;
            button17.Image = button17.BackgroundImage; button18.Image = button18.BackgroundImage; button19.Image = button19.BackgroundImage; button20.Image = button20.BackgroundImage;
            button21.Image = button21.BackgroundImage; button22.Image = button22.BackgroundImage; button23.Image = button23.BackgroundImage; button24.Image = button24.BackgroundImage;
            button25.Image = button25.BackgroundImage; button26.Image = button26.BackgroundImage; button27.Image = button27.BackgroundImage; button28.Image = button28.BackgroundImage;
            button29.Image = button29.BackgroundImage; button30.Image = button30.BackgroundImage; button31.Image = button31.BackgroundImage; button33.Image = button33.BackgroundImage;//Minimizar
            button32.Image = button32.BackgroundImage; button34.Image = button34.BackgroundImage; btnAgregar.Image = btnAgregar.BackgroundImage; btnRadio.Image = btnRadio.BackgroundImage;
            btnYoutube.Image = btnYoutube.BackgroundImage; 
            //Contadores Digitales
            Rojo2.Image = Rojo2.BackgroundImage; Rojo1.Image = Rojo1.BackgroundImage; Verde2.Image = Verde2.BackgroundImage; Verde1.Image = Verde1.BackgroundImage;
        }
        

#endregion Alto Contraste

#region Tiempos de Actualizacion
        
        void ActualizarVumetro()
        {
            RefreshVumetro = new DispatcherTimer();RefreshVumetro.Interval = new TimeSpan(0, 0, 1);RefreshVumetro.Tick += RefreshVumetro_Tick;
        }//Cada segundo actualiza las imagenes del vumetro
        void ActualizarDuracion()
        {
            RefreshDuracion = new DispatcherTimer();RefreshDuracion.Interval = new TimeSpan(0, 0, 1);RefreshDuracion.Tick += RefreshDuracion_Tick;
        }//Cada segundo actualiza cuanto dura cada Track
        void ActualizarNombre()
        {
            Refreshnombre = new DispatcherTimer();Refreshnombre.Interval = new TimeSpan(0, 0, 1);Refreshnombre.Tick += Refreshnombre_Tick;
        }//Cada segundo actualiza el nombre del Track actual
        void ActualizarPosicion()
        {
            RefreshSlider = new DispatcherTimer();RefreshSlider.Interval = new TimeSpan(0, 0, 2);RefreshSlider.Tick += RefreshSlider_Tick;
        }//Cada dos segundos va contando la reproduccion del Track
        void ActualizacionBarra()
        {
            RefresBarra = new DispatcherTimer();RefresBarra.Interval = new TimeSpan(0, 0, 1);RefresBarra.Tick += RefresBarra_Tick;
        }//Cada segundo suma 5 al ancho del lbBarra
        void ActualizarEfectoR()
        { RefreshEfecto2 = new DispatcherTimer(); RefreshEfecto2.Interval = new TimeSpan(0, 0, 1); RefreshEfecto2.Tick += RefreshEfecto2_Tick;}//Cada segundo Intercambia el valor de volumen en los canales R y L
        void RefreshEfecto2_Tick(object sender, EventArgs e)//Parlante Izquierdo
        {
            //Que va hacer cada 2 segundos? Alternar el canal R
            if (contBalance == 1)//Parlante izquierdo
            {Reproductor.settings.balance = -100; Reproductor.settings.balance = 0; Reproductor.settings.balance = 100; Reproductor.settings.balance = -40;contBalance = contBalance + 1;}//-40 ó -30
            else if (contBalance == 2)//Parlante derecho
           {Reproductor.settings.balance = 100; Reproductor.settings.balance = 0; Reproductor.settings.balance = -100; Reproductor.settings.balance = 30;contBalance = 1;}  
        }
        void RefreshVumetro_Tick(object sender, EventArgs e)
        {
            //Que va hacer cada segundo
            //Actualizar la barra cuando se de click en el boton de radio
            Vumetro1.Visible = false; Vumetro2.Visible = false; Vumetro3.Visible = false;//No se mueven Fijos
            lbVumetro1.Visible = true; lbVumetro2.Visible = true; lbVumetro3.Visible = true;//Se mueven
        }
        void RefresBarra_Tick(object sender, EventArgs e)
        {
            //Que va hacer cada segundo
            //Incrementar el tamaño de un label hasta cierto punto
            lbBarra.Width = 17 + contadorBarra;
            Puntero.Location = new Point(contadorPuntero, 86);
            Puntero2.Location = new Point(contadorPuntero2, 86);
            if (tb1.Text == "00:02" | tb1.Text == "00:03" | lbBarra.Width == 260)
            {
                contadorBarra = 0;//Que se reinicie cuando se acabe cada Track
                contadorPuntero = 681;//Que se reinicie cuando se acabe cada Track
                contadorPuntero2 = 686;//Que se reinicie cuando se acabe cada Track
                NaveLista.Refresh();//Que se actualize la pagina o lista de reproduccion actual
            }
            else if (tb1.Text == "")//Ocurre cuando termina una PlayList
            { contadorBarra = 0; contadorPuntero = 681; contadorPuntero2 = 686; RefresBarra.Stop(); }
        }
        void RefreshDuracion_Tick(object sender, EventArgs e)
        {
            //Que va hacer cada segundo ?
            //Actualizar Cuanto dura el track que se esta reproduciendo
            if (listBox1.Items.Count != 0)
            { DuracionTrack.Text = Reproductor.Ctlcontrols.currentItem.durationString; }//Se detiene en 00:02 y en Stop
        }
        void Refreshnombre_Tick(object sender, EventArgs e)//Solo se detiene en Stop
        {
            //Que va ha hacer cada segundo ?
            //Actualizar el nombre del Artista que se esta reproduciendo
            if (listBox1.Items.Count != 0)
            {label38.Text = Reproductor.Ctlcontrols.currentItem.name;}
            else label38.Text = Reproductor.Ctlcontrols.currentItem.name;
        }
        void RefreshSlider_Tick(object sender, EventArgs e)//Se encarga del cambio de cancion//Solo se detiene en Stop
        {
            //Que va hacer cada segundo ?
            //Comparar el estado del texBox1 hasta que sea igual a null
            tb1.Text = Reproductor.Ctlcontrols.currentPositionString;
            RefresBarra.Start();//Inicia la barra con el tiempo que dura el track
            contadorBarra = contadorBarra + 1;//Incrementa la barra
            contadorPuntero = contadorPuntero + 1;//Incrementa el puntero 1
            contadorPuntero2 = contadorPuntero2 + 1;//Incrementa el puntero 2
            if (tb1.Text == "00:02" )//Cuando exista este valor en el texbox1 detiene el Timer Duracion
            {RefreshDuracion.Stop();}//Se detiene en el valor que dura el Track
            if (tb1.Text == "" & listBox1.Items.Count != 0 & reanudar == true)//Cuando termina cada cancion el valor siempre es null y si contiene canciones...
            {
                for (int f = 0; f < listBox1.SelectedItems.Count; f++)//Va hasta el numero de canciones que contiene la lista
                  {
                      listBox1.SelectedIndex = listBox1.SelectedIndex + 1;//Suma +1 a cada indice
                      ReproducirSeleccionado();//Reproduce el indice seleccionado
                      ContadordecancionesVerde();//Muestra en el display verde la cancion que esta sonando actualmente----------------------------------------------------------------------------------------
                      IgualSeleccion();//Para que sea la amisma seleccion en la lista de reproduccion*******************Borrar si tira error
                      if (tb1.Text == "" & this.listBox1.SelectedIndex == this.listBox1.Items.Count - 1)//Si el texBox1 es null y la seleccion es la ultima cancion
                        {
                            ReproducirSeleccionado();//No reproduce la cancion,se salta esta instruccion y reinicia la playList 
                            if (tb1.Text == "" & this.listBox1.SelectedIndex == this.listBox1.Items.Count - 1 & Reproductor.playState != WMPPlayState.wmppsPlaying)//Entra derecho
                            {  
                                listBox1.SelectedIndex = 0;////Vuelve a empezar la playlist
                            }
                            else
                            {}
                        }
                        else
                          ReproducirSeleccionado();
                  }  
            }
        }
        void tiempointro()
        { TintroM = new DispatcherTimer(); TintroM.Interval = new TimeSpan(0, 0, 5); TintroM.Tick += TintroM_Tick;  }//Muestra el splash sreen durante 5 segundos
        void TintroM_Tick(object sender, EventArgs e)
        {
            TintroM.Stop();
            this.intro1.Close();
            Opacity = 100;
        }//3

        #endregion Tiempos de Actualizacion

#region Listas Default
        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                if (tb1.Text != "" | tb1.Text == "")
                {
                    Reproductor.URL = PlayList + "Nach Scratch.wpl";//Reproduce una PlayList de el artista
                    Reproductor.Ctlcontrols.play();
                    Cambios();//Envia el nombre del Track actual y el nombre de la PlayList
                    ImagenAlbum();//Envia la imagen del Album
                } 
            }
            catch (Exception Ex) {MessageBox.Show(Ex.Message); }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (tb1.Text != "" | tb1.Text == "")
                { Reproductor.URL = PlayList + "AlcolirykoZ.wpl"; Reproductor.Ctlcontrols.play(); Cambios(); ImagenAlbum2(); }
            }
            catch (Exception Ex) { MessageBox.Show(Ex + "No se puede reproducir el Archivo"); }
        }
        private void button17_Click(object sender, EventArgs e)
        {
            try
            {
                if (tb1.Text != "" | tb1.Text == "")
                { Reproductor.URL = PlayList + "R & B.wpl"; Reproductor.Ctlcontrols.play(); Cambios(); ImagenAlbum3(); }
            }
            catch (Exception Ex)
            {MessageBox.Show(Ex.Message); }
        }
        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                if (tb1.Text != "" | tb1.Text == "")
                { Reproductor.URL = PlayList + "Morodo.wpl"; Reproductor.Ctlcontrols.play(); Cambios(); ImagenAlbum4(); }
            }
            catch (Exception Ex) { MessageBox.Show(Ex.Message); }
        }
        private void button16_Click(object sender, EventArgs e)
        {
            try
            {
                if (tb1.Text != "" | tb1.Text == "")
                { Reproductor.URL = PlayList + "Paramore.wpl"; Reproductor.Ctlcontrols.play(); Cambios(); ImagenAlbum5(); }   
            }
            catch (Exception Ex) { MessageBox.Show(Ex.Message); }
        }
        private void button26_Click(object sender, EventArgs e)
        {
            try
            {
                if (tb1.Text != "" | tb1.Text == "")
                { Reproductor.URL = PlayList + "Zona Ganjah.wpl"; Reproductor.Ctlcontrols.play(); Cambios(); ImagenAlbum6(); }
            }
            catch (Exception Ex)
            {MessageBox.Show(Ex.Message); }
        }
        private void button18_Click(object sender, EventArgs e)
        {
            try
            {
                if (tb1.Text != "" | tb1.Text == "")
                { Reproductor.URL = PlayList + "Reggae.wpl"; Reproductor.Ctlcontrols.play(); Cambios(); ImagenAlbum7(); }
            }
            catch (Exception Ex)
            {MessageBox.Show(Ex.Message); }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (tb1.Text != "" | tb1.Text == "")
                { Reproductor.URL = PlayList + "Bob Marley.wpl"; Reproductor.Ctlcontrols.play(); Cambios(); ImagenAlbum8(); }
            }
            catch (Exception Ex)
            {MessageBox.Show(Ex.Message); }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                if (tb1.Text != "" | tb1.Text == "")
                { Reproductor.URL = PlayList + "Hip Hop.wpl"; Reproductor.Ctlcontrols.play(); Cambios(); ImagenAlbum9(); }
            }
            catch (Exception Ex)
            {MessageBox.Show(Ex.Message); }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (tb1.Text != "" | tb1.Text == "")
                { Reproductor.URL = PlayList + "Los Aldeanos.wpl"; Reproductor.Ctlcontrols.play(); Cambios(); ImagenAlbum10(); }
            }
            catch (Exception Ex)
            {MessageBox.Show(Ex.Message); }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (tb1.Text != "" | tb1.Text == "")
                { Reproductor.URL = PlayList + "Cultura Profetica.wpl"; Reproductor.Ctlcontrols.play(); Cambios(); ImagenAlbum11(); }
            }
            catch (Exception Ex)
            {MessageBox.Show(Ex.Message); }
        }
        private void button23_Click(object sender, EventArgs e)
        {
            try
            {
                if (tb1.Text != "" | tb1.Text == "")
                { Reproductor.URL = PlayList + "Tempo.wpl"; Reproductor.Ctlcontrols.play(); Cambios(); ImagenAlbum12(); }
            }
            catch (Exception Ex)
            {MessageBox.Show(Ex.Message); }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (tb1.Text != "" | tb1.Text == "")
                { Reproductor.URL = PlayList + "Tres Coronas.wpl"; Reproductor.Ctlcontrols.play(); Cambios(); ImagenAlbum13(); }
            }
            catch (Exception Ex) {MessageBox.Show(Ex.Message); }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (tb1.Text != "" | tb1.Text == "")
                { Reproductor.URL = PlayList + "Afaz Natural.wpl"; Reproductor.Ctlcontrols.play(); Cambios(); ImagenAlbum14(); }
            }
            catch (Exception Ex) {MessageBox.Show(Ex.Message); }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (tb1.Text != "" | tb1.Text == "")
                { Reproductor.URL = PlayList + "Chulito Camacho.wpl"; Reproductor.Ctlcontrols.play(); Cambios(); ImagenAlbum15(); }
            }
            catch (Exception Ex) { MessageBox.Show(Ex.Message); }
        }
        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                if (tb1.Text != "" | tb1.Text == "")
                { Reproductor.URL = PlayList + "La Etnnia 527.wpl"; Reproductor.Ctlcontrols.play(); Cambios(); ImagenAlbum16(); }   
            }
            catch (Exception Ex) { MessageBox.Show(Ex.Message); }
        }
        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                if (tb1.Text != "" | tb1.Text == "")
                { Reproductor.URL = PlayList + "Mala Rodriguez.wpl"; Reproductor.Ctlcontrols.play(); Cambios(); ImagenAlbum17(); }
            }
            catch (Exception Ex) { MessageBox.Show(Ex.Message); }
        }
        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                if (tb1.Text != "" | tb1.Text == "")
                { Reproductor.URL = PlayList + "Movimiento O.wpl"; Reproductor.Ctlcontrols.play(); Cambios(); ImagenAlbum18(); }
            }
            catch (Exception Ex) { MessageBox.Show(Ex.Message); }
        }
        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                if (tb1.Text != "" | tb1.Text == "")
                { Reproductor.URL = PlayList + "Noryyko.wpl"; Reproductor.Ctlcontrols.play(); Cambios(); ImagenAlbum19(); }
            }
            catch (Exception Ex) { MessageBox.Show(Ex.Message); }
        }
        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                if (tb1.Text != "" | tb1.Text == "")
                { Reproductor.URL = PlayList + "Nonpalidece.wpl"; Reproductor.Ctlcontrols.play(); Cambios(); ImagenAlbum20(); }
            }
            catch (Exception Ex) { MessageBox.Show(Ex.Message); }
        }
        private void button19_Click(object sender, EventArgs e)
        {
            try
            {
                if (tb1.Text != "" | tb1.Text == "")
                { Reproductor.URL = PlayList + "Rock.wpl"; Reproductor.Ctlcontrols.play(); Cambios(); ImagenAlbum21(); }
            }
            catch (Exception Ex) { MessageBox.Show(Ex.Message); }
        }
        private void button20_Click(object sender, EventArgs e)
        {
            try
            {
                if (tb1.Text != "" | tb1.Text == "")
                { Reproductor.URL = PlayList + "SantaFlow.wpl"; Reproductor.Ctlcontrols.play(); Cambios(); ImagenAlbum22(); }
            }
            catch (Exception Ex) { MessageBox.Show(Ex.Message); }
        }
        private void button21_Click(object sender, EventArgs e)
        {
            try
            {
                if (tb1.Text != "" | tb1.Text == "")
                { Reproductor.URL = PlayList + "SKA-P.wpl"; Reproductor.Ctlcontrols.play(); Cambios(); ImagenAlbum23(); }
            }
            catch (Exception Ex) { MessageBox.Show(Ex.Message); }
        }
        private void button22_Click(object sender, EventArgs e)
        {
            try
            {
                if (tb1.Text != "" | tb1.Text == "")
                { Reproductor.URL = PlayList + "Swan Fyahbwoy.wpl"; Reproductor.Ctlcontrols.play(); Cambios(); ImagenAlbum24(); }
            }
            catch (Exception Ex) { MessageBox.Show(Ex.Message); }
        }
        private void button24_Click(object sender, EventArgs e)
        {
            try
            {
                if (tb1.Text != "" | tb1.Text == "")
                { Reproductor.URL = PlayList + "The Birthday Masacre.wpl"; Reproductor.Ctlcontrols.play(); Cambios(); ImagenAlbum25(); }
            }
            catch (Exception Ex) { MessageBox.Show(Ex.Message); }
        }
        private void button25_Click(object sender, EventArgs e)
        {
            try
            {
                if (tb1.Text != "" | tb1.Text == "")
                { Reproductor.URL = PlayList + "Xplicitos.wpl"; Reproductor.Ctlcontrols.play(); Cambios(); ImagenAlbum26(); }
            }
            catch (Exception Ex) { MessageBox.Show(Ex.Message); }
        }
        private void button28_Click(object sender, EventArgs e)
        {
            try
            {
                if (tb1.Text != "" | tb1.Text == "")
                { Reproductor.URL = PlayList + "Trey Songz.wpl"; Reproductor.Ctlcontrols.play(); Cambios(); ImagenAlbum27(); }
            }
            catch (Exception Ex) { MessageBox.Show(Ex.Message); }
        }
        private void button29_Click(object sender, EventArgs e)
        {
            try
            {
                if (tb1.Text != "" | tb1.Text == "")
                { Reproductor.URL = PlayList + "Doble V.wpl"; Reproductor.Ctlcontrols.play(); Cambios(); ImagenAlbum28(); }  
            }
            catch (Exception Ex) { MessageBox.Show(Ex.Message); }
        }
        private void button30_Click(object sender, EventArgs e)
        {
            try
            {
                if (tb1.Text != "" | tb1.Text == "")
                { Reproductor.URL = PlayList + "Canserbero.wpl"; Reproductor.Ctlcontrols.play(); Cambios(); ImagenAlbum29(); }
            }
            catch (Exception Ex) { MessageBox.Show(Ex.Message); }
        }
        private void button34_Click(object sender, EventArgs e)
        {
            try
            {
                if (tb1.Text != "" | tb1.Text == "")
                { Reproductor.URL = PlayList + "Clementino.wpl"; Reproductor.Ctlcontrols.play(); Cambios(); ImagenAlbum30(); }
            }
            catch (Exception Ex) { MessageBox.Show(Ex.Message); }
        }  
        private void button31_Click(object sender, EventArgs e)
        {
            try
            {
                if (tb1.Text != "" | tb1.Text == "")
                { Reproductor.URL = PlayList + "Eminem.wpl"; Reproductor.Ctlcontrols.play(); Cambios(); ImagenAlbum31(); }
            }
            catch (Exception Ex) { MessageBox.Show(Ex.Message); }
        }
        private void button32_Click(object sender, EventArgs e)
        {
            try
            {
                if (tb1.Text != "" | tb1.Text == "")
                { Reproductor.URL = PlayList + "Barrington Levy.wpl"; Reproductor.Ctlcontrols.play(); Cambios(); ImagenAlbum32(); }
            }
            catch (Exception Ex) { MessageBox.Show(Ex.Message); }
        }
#endregion Listas Default

#region Funciones del reproductor

        private void ReproducirSeleccionado()
        {
            Reproductor.URL = listBox1.SelectedItem.ToString();
        }
        private void DetenerReproductor()
        {
            Reproductor.Ctlcontrols.stop();
        }
        private void IgualSeleccion()
        {
            ListaReproduccion.SelectedIndex = listBox1.SelectedIndex;
        }
        #endregion Funciones del reproductor

#region Botones Comunes
        private void button27_Click(object sender, EventArgs e)//boton cerrar
        {
            //DetenerReproductor();
            Reproductor.Ctlcontrols.stop();
            CambioResolucion();
           // Thread.Sleep(2000);
            this.DialogResult = DialogResult.Yes;
        }
        private void CambioResolucion()
        {
            Resolution.CResolution Cambiar = new Resolution.CResolution(CamAncho, CamAlto);
        }
        private void button33_Click(object sender, EventArgs e)//Boton Minimizar
        { this.WindowState = FormWindowState.Minimized; }
        private void PanelSuperior_MouseDown(object sender, MouseEventArgs e)//Para mover el Form
        {ReleaseCapture(); SendMessage(this.Handle, 0x112, 0xf012, 0);}
        private void label34_MouseEnter(object sender, EventArgs e)//Maximizar
        {
            //Acopla los botones en una nueva location
            //Se llama a la clase que hace eso
            if (lockMaxMin == false)
            { 
                {
                    this.button33.Location = new Point(1861, 5);//Mini..
                    this.button27.Location = new Point(1888, 5);//Cerrar
                    this.label47.Location = new Point(1660, 63);//Titulo Lista de reproduccion
                    this.ListaReproduccion.Location = new Point(1615, 98);//Lista de reproduccion //X,Y
                    this.ListaReproduccion.Width = 275; this.ListaReproduccion.Height = 510;//Ancho y Alto
                    if (ListaActual.Visible == true) { this.ListaActual.Visible = true; }//Muestra la Lista Actual de Radio    
                    else {}
                    this.button36.Location = new Point(1870, 97);//Boton Clear
                    this.Location = Screen.PrimaryScreen.WorkingArea.Location;//se acopla al tamaño de la pantalla
                    this.Size = Screen.PrimaryScreen.WorkingArea.Size;//se acopla al tamaño de la pantalla 
                    lockMaxMin = true;
                }
            }
            else {}
        }
        private void label35_MouseEnter(object sender, EventArgs e)//Restaurar
        {
            //Restaura las ubicaciones de los objetos
            if (lockMaxMin == true)
            {
                    this.button33.Location = new Point(1528, 5);//Mini...
                    this.button27.Location = new Point(1555, 5);//Cerrar
                    this.label47.Location = new Point(462, 4);//Titulo Lista de reproduccion
                    this.ListaReproduccion.Width = 196; this.ListaReproduccion.Height = 74;//Ancho y Alto
                    this.ListaReproduccion.Location = new Point(461, 28);//Lista de reproduccion //X,Y
                    this.button36.Location = new Point(638, 27);//Boton Clear
                    this.Size = new Size(1589, 646);
                    lockMaxMin = false;  
            }
        }
        
#endregion Botones Comunes

#region Botones de Reproduccion
        private void btnStop_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count == 0 & lbArtista.Text == "--------")//Los dos vacios
            { MessageBox.Show("Por favor agregue canciones a la lista"); }
            else if (Reproductor.playState == WMPPlayState.wmppsPlaying)//Si reproduciendo algo
            {
                DetenerReproductor();//Se detiene el reproductor
                Refreshnombre.Stop();//Apaga el Timer de Nombres
                RefreshSlider.Stop();//Apaga el Timer de Posicion
                RefreshDuracion.Stop();//Apaga el Timer de Duracion
                RefreshVumetro.Stop();//Apaga el vumetro
                MostrarVumetrosInver();//Fijos
            }
            else
                DetenerReproductor();//Para las PlayList
        }
        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count == 0 & lbArtista.Text == "--------")//Los dos vacios
            {MessageBox.Show("No existen canciones,por favor agregue canciones a la lista");}
            else if (Reproductor.playState == WMPPlayState.wmppsStopped)//Para reanudar
            {
                Reproductor.Ctlcontrols.play(); Refreshnombre.Start(); RefreshSlider.Start(); RefreshDuracion.Start(); RefreshVumetro.Start();
                MostrarVumetros(); OcultarVumetros();
            }
            else
                Reproductor.Ctlcontrols.play();//Para las PlayList
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (Form.ActiveForm.Contains(btn) | Form.ActiveForm.Contains(btn1) | Form.ActiveForm.Contains(btn2) | Form.ActiveForm.Contains(btn3) | Form.ActiveForm.Contains(btn4) | Form.ActiveForm.Contains(btn5) | Form.ActiveForm.Contains(btn6) & Reproductor.playState == WMPPlayState.wmppsPlaying & listBox1.SelectedIndex < listBox1.Items.Count)
            {
                if (listBox1.SelectedIndex == listBox1.Items.Count - 1)//Si esta en el ultimo Track que se reinicie la lista
                {
                    listBox1.SelectedIndex = 0; IgualSeleccion();
                }
                else//Si no esta en el ultimo Track que continue
                {
                    listBox1.SelectedIndex = listBox1.SelectedIndex + 1; IgualSeleccion();
                    DetenerReproductor(); Reproductor.Ctlcontrols.pause(); Reproductor.Ctlcontrols.next();
                    ReproducirSeleccionado();
                    label38.Text = Reproductor.Ctlcontrols.currentItem.name;
                }
            }
            else
            {Reproductor.Ctlcontrols.next();}//Este se cumple cuando son playlist
        }
        private void btnAtras_Click(object sender, EventArgs e)
        {
            if (Form.ActiveForm.Contains(btn) | Form.ActiveForm.Contains(btn1) | Form.ActiveForm.Contains(btn2) | Form.ActiveForm.Contains(btn3) | Form.ActiveForm.Contains(btn4) | Form.ActiveForm.Contains(btn5) | Form.ActiveForm.Contains(btn6) & listBox1.SelectedIndex > 0 & Reproductor.playState == WMPPlayState.wmppsPlaying)
            {
                if (listBox1.SelectedIndex == 0){}//Que no haga nada
                else
                listBox1.SelectedIndex = listBox1.SelectedIndex - 1; IgualSeleccion();
                DetenerReproductor(); Reproductor.Ctlcontrols.pause(); Reproductor.Ctlcontrols.previous();
                ReproducirSeleccionado();label38.Text = Reproductor.Ctlcontrols.currentItem.name;
            }
            else
            {Reproductor.Ctlcontrols.previous();}//Este se cumple cuando son playlist
        }

        #endregion Botones de Reproduccion

#region Cambios
        //Metodo para mostrar el nombre de la PlayList y el nombre del Track actual
        void Cambios()
        {
            btnExpandir.Visible = false;
            lbArtista.Text = "";btnGuardarList.Visible = true;listBox1.Visible = false; ListaReproduccion.Visible = true;
            lbArtista.Text = Reproductor.currentPlaylist.name.ToString(); txtLink.Visible = false;//Oculta el TexBox de Radio
            Refreshnombre.Start();//Actualiza el nombre del track cada segundo
            RefreshSlider.Start();//Actualiza la posicion del track cada segundo
            RefreshDuracion.Start();//Se detiene cada 00:02 de cada Track
            RefreshVumetro.Stop();//Se detiene el vumetro y queda visible las barras
            Album.Visible = true;//Muestra el Album cuando se reproduce algo
            ListaActual.Visible = false;//Oculta la lista de reproduccion online
            lbArtista.ForeColor =  Color.PaleGreen;//Devuelve el color normal
            Balance.Value = 5;//Mitad de balance para evitar el Bug del canal derecho
            NaveLista.Visible = false;//Se oculta la lista de radio
            label64.Visible = false;//Lista de reproduccion online(Titulo)
            txtLink.Visible = false;label41.Visible = false;label42.Visible = false;label43.Visible = false;label44.Visible = false;label45.Visible = false;
            label47.Visible = true;ImagenRadio.Visible = false;button35.Visible = false;ImagenRadio.Visible = false;button36.Visible = true;
            MostrarVumetros(); OcultarVumetros();
        }
        private void MostrarVumetros()
        {
            lbVumetro1.Visible = true; lbVumetro2.Visible = true; lbVumetro3.Visible = true;//Se mueven (Si) 
        }
        private void OcultarVumetros()
        {
            Vumetro1.Visible = false; Vumetro2.Visible = false; Vumetro3.Visible = false;//No se mueven (No)
        }
        private void MostrarVumetrosInver()
        {
            Vumetro1.Visible = true; Vumetro2.Visible = true; Vumetro3.Visible = true;//No se mueven QUIETOS
            lbVumetro1.Visible = false; lbVumetro2.Visible = false; lbVumetro3.Visible = false;//Se mueven MOVIMIENTO
        }
        
#endregion Cambios

#region Caratulas
                                                                             //Metodos para mostrar la caratula del album de cada artista
        void ImagenAlbum()//Nach
        { if (button13.Name != null) { Album.BackgroundImage = Image.FromFile(Ruta + "nach.gif"); } }
        void ImagenAlbum2()//Alcolirykoz
        { if (button1.Name != null) { Album.BackgroundImage = Image.FromFile(Ruta + "Alcolirykoz.gif"); } }
        void ImagenAlbum3()//R & B
        { if (button17.Name != null) { Album.BackgroundImage = Image.FromFile(Ruta + "R & B.gif"); } }
        void ImagenAlbum4()//Morodo
        { if (button12.Name != null) { Album.BackgroundImage = Image.FromFile(Ruta + "morodo.gif"); } }
        void ImagenAlbum5()//Paramore
        { if (button16.Name != null) { Album.BackgroundImage = Image.FromFile(Ruta + "paramore.gif"); } }
        void ImagenAlbum6()//Zona ganjah
        { if (button26.Name != null) { Album.BackgroundImage = Image.FromFile(Ruta + "ZG.gif"); } }
        void ImagenAlbum7()//Reggae
        { if (button18.Name != null) { Album.BackgroundImage = Image.FromFile(Ruta + "reggae 1.gif"); } }
        void ImagenAlbum8()//Bob Marley
        { if (button4.Name != null) { Album.BackgroundImage = Image.FromFile(Ruta + "bob marley.gif"); } }
        void ImagenAlbum9()//Hip Hop
        { if (button8.Name != null) { Album.BackgroundImage = Image.FromFile(Ruta + "descarga.gif"); } }
        void ImagenAlbum10()//Los Aldeanos
        { if (button3.Name != null) { Album.BackgroundImage = Image.FromFile(Ruta + "aldeanos.gif"); } }
        void ImagenAlbum11()//Cultura P
        { if (button7.Name != null) { Album.BackgroundImage = Image.FromFile(Ruta + "cultura profetica.gif"); } }
        void ImagenAlbum12()//Tempo
        { if (button23.Name != null) { Album.BackgroundImage = Image.FromFile(Ruta + "tempo.gif"); } }
        void ImagenAlbum13()//Tres Coronas
        { if (button6.Name != null) { Album.BackgroundImage = Image.FromFile(Ruta + "3 coronas.gif"); } }
        void ImagenAlbum14()//Afaz Natural
        { if (button2.Name != null) { Album.BackgroundImage = Image.FromFile(Ruta + "Afaz.gif"); } }
        void ImagenAlbum15()//Chulito Camacho
        { if (button5.Name != null) { Album.BackgroundImage = Image.FromFile(Ruta + "chulito.gif"); } }
        void ImagenAlbum16()//La Etnnia 527
        { if (button9.Name != null) { Album.BackgroundImage = Image.FromFile(Ruta + "la etnia.gif"); } }
        void ImagenAlbum17()//Mala Rodriguez
        { if (button10.Name != null) { Album.BackgroundImage = Image.FromFile(Ruta + "mala.gif"); } }
        void ImagenAlbum18()//Movimiento O.
        { if (button11.Name != null) { Album.BackgroundImage = Image.FromFile(Ruta + "MO.gif"); } }
        void ImagenAlbum19()//Noryyko
        { if (button15.Name != null) { Album.BackgroundImage = Image.FromFile(Ruta + "Norykko.gif"); } }
        void ImagenAlbum20()//Nonpalice
        { if (button14.Name != null) { Album.BackgroundImage = Image.FromFile(Ruta + "nonpalidece.gif"); } }
        void ImagenAlbum21()//Rock
        { if (button19.Name != null) { Album.BackgroundImage = Image.FromFile(Ruta + "Rock.gif"); } }
        void ImagenAlbum22()//Santaflow
        { if (button20.Name != null) { Album.BackgroundImage = Image.FromFile(Ruta + "santaflow.gif"); } }
        void ImagenAlbum23()//SKA-P
        { if (button21.Name != null) { Album.BackgroundImage = Image.FromFile(Ruta + "skap.gif"); } }
        void ImagenAlbum24()//Swan F.
        { if (button22.Name != null) { Album.BackgroundImage = Image.FromFile(Ruta + "swan.gif"); } }
        void ImagenAlbum25()//The B. M.
        { if (button24.Name != null) { Album.BackgroundImage = Image.FromFile(Ruta + "the birthday massacre.gif"); } }
        void ImagenAlbum26()//Xplicitos
        { if (button25.Name != null) { Album.BackgroundImage = Image.FromFile(Ruta + "xplicitos.gif"); } }
        void ImagenAlbum27()//Trey
        { if (button28.Name != null) { Album.BackgroundImage = Image.FromFile(Ruta + "Trey Songz.gif"); } }
        void ImagenAlbum28()//Doble V
        { if (button29.Name != null) { Album.BackgroundImage = Image.FromFile(Ruta + "doble V.gif"); } }
        void ImagenAlbum29()//Canserbero
        { if (button30.Name != null) { Album.BackgroundImage = Image.FromFile(Ruta + "Canserbero.gif"); } }
        void ImagenAlbum30()//Clementino
        { if (button34.Name != null) { Album.BackgroundImage = Image.FromFile(Ruta + "Clementino.gif"); } }
        void ImagenAlbum31()//Eminem
        { if (button31.Name != null) { Album.BackgroundImage = Image.FromFile(Ruta + "Eminem.gif"); } }
        void ImagenAlbum32()//Barrington Levy
        { if (button32.Name != null) { Album.BackgroundImage = Image.FromFile(Ruta + "Barrington.gif"); } }
#endregion Caratulas

#region Control de volumen
        //Controlar la barra de Volumen
        private void Volumen_ValueChanged(object sender, EventArgs e)
        {
            if (Volumen.Value == 0) { Reproductor.settings.mute = true; }
            if (Volumen.Value == 1) { Reproductor.settings.mute = false; Reproductor.settings.volume = 10; }
            if (Volumen.Value == 2) { Reproductor.settings.volume = 20; }
            if (Volumen.Value == 3) { Reproductor.settings.volume = 30; }
            if (Volumen.Value == 4) { Reproductor.settings.volume = 40; }
            if (Volumen.Value == 5) { Reproductor.settings.volume = 50; }
            if (Volumen.Value == 6) { Reproductor.settings.volume = 60; }
            if (Volumen.Value == 7) { Reproductor.settings.volume = 70; }
            if (Volumen.Value == 8) { Reproductor.settings.volume = 80; }
            if (Volumen.Value == 9) { Reproductor.settings.volume = 90; }
            if (Volumen.Value == 10){ Reproductor.settings.volume = 100;}
        }
        #endregion Control de volumen

#region Control de Balance
        //Controlar la barra de Balance
        private void Balance_ValueChanged(object sender, EventArgs e)
        {
            if (Balance.Value == 0) { Reproductor.settings.balance = 100; }
            if (Balance.Value == 1) { Reproductor.settings.balance = 90; }
            if (Balance.Value == 2) { Reproductor.settings.balance = 80; }
            if (Balance.Value == 3) { Reproductor.settings.balance = 70; }
            if (Balance.Value == 4) { Reproductor.settings.balance = 60; }
            if (Balance.Value == 5) { Reproductor.settings.balance = 0; }
            if (Balance.Value == 6) { Reproductor.settings.balance = -60; }
            if (Balance.Value == 7) { Reproductor.settings.balance = -70; }
            if (Balance.Value == 8) { Reproductor.settings.balance = -80; }
            if (Balance.Value == 9) { Reproductor.settings.balance = -90; }
            if (Balance.Value == 10) { Reproductor.settings.balance = -100; } 
        }
        #endregion Control de Balance

#region Efecto FadeChannel
        private void btnEfecto_Click(object sender, EventArgs e)
        {
            if (conEfect == 1 & contOff == 1){RefreshEfecto2.Start(); btnEfecto.Text = "Apagar"; btnEfecto.ForeColor = Color.Red; contOff = 2; conEfect = 2;}
            else if (conEfect == 2 & contOff == 2){RefreshEfecto2.Stop(); Reproductor.settings.balance = 0; btnEfecto.Text = "Fade"; btnEfecto.ForeColor = Color.LimeGreen; contOff = 1; conEfect = 1;}
        }
      
        #endregion Efecto FadeChannel

#region Boton Agregar Controles Dinamicos
        //Crea el nuevo boton y va moviendo el boton de Agregar
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            do
            {
                for (int i = 0; i < 1; i++)
                {
                    if (VecesCreacion >= 0 & VecesCreacion <= 6)
                    { 
                        //Propiedades de los botones y los labels
                        if (VecesCreacion == 0)//Crea el boton 1 y label 1...
                        {
                            btn.Width = 152;btn.Height = 144;btn.FlatStyle = FlatStyle.Popup;btn.BackgroundImageLayout = ImageLayout.Stretch;btn.BackColor =  Color.Transparent;btn.ForeColor =  Color.Black;
                            btn.Location = new  Point(321, 645);//Posicion inicial del boton
                            btn.Click += btn_Click;lb.Width = 152;lb.Height = 16;lb.ForeColor =  Color.Lime;lb.BackColor =  Color.Transparent;lb.Location = new  Point(321, 795);//Posicion inicial del Label
                            lb.Click += lb_Click; btn.MouseWheel += btn_MouseWheel;
                        }
                        if (VecesCreacion == 1)
                        {
                            btn1.Width = 152;btn1.Height = 144;btn1.FlatStyle = FlatStyle.Popup;btn1.BackgroundImageLayout = ImageLayout.Stretch;btn1.BackColor =  Color.Transparent;btn1.ForeColor =  Color.Black;
                            btn1.Location = new  Point(BotonUbicacion + 0, 645);btn1.Click += btn1_Click;lb1.Width = 152;lb1.Height = 16;lb1.ForeColor =  Color.Lime;lb1.BackColor =  Color.Transparent;
                            lb1.Location = new  Point(480, 795); lb1.Click += lb1_Click; btn1.MouseWheel += btn1_MouseWheel;
                        }
                        if (VecesCreacion == 2)
                        {
                            btn2.Width = 152;btn2.Height = 144;btn2.FlatStyle = FlatStyle.Popup;btn2.BackgroundImageLayout = ImageLayout.Stretch;btn2.BackColor =  Color.Transparent;btn2.ForeColor =  Color.Black;
                            btn2.Location = new  Point(BotonUbicacion + 0, 645);btn2.Click += btn2_Click;lb2.Width = 152;lb2.Height = 16;lb2.ForeColor =  Color.Lime;lb2.BackColor =  Color.Transparent;
                            lb2.Location = new  Point(639, 795); lb2.Click += lb2_Click; btn2.MouseWheel += btn2_MouseWheel;
                        }
                        if (VecesCreacion == 3)
                        {
                            btn3.Width = 152;btn3.Height = 144;btn3.FlatStyle = FlatStyle.Popup;btn3.BackgroundImageLayout = ImageLayout.Stretch;btn3.BackColor =  Color.Transparent;btn3.ForeColor =  Color.Black;
                            btn3.Location = new  Point(BotonUbicacion + 0, 645);btn3.Click += btn3_Click;lb3.Width = 152;lb3.Height = 16;lb3.ForeColor =  Color.Lime;lb3.BackColor =  Color.Transparent;
                            lb3.Location = new  Point(798, 795); lb3.Click += lb3_Click; btn3.MouseWheel += btn3_MouseWheel;
                        }
                        if (VecesCreacion == 4)
                        {
                            btn4.Width = 152;btn4.Height = 144;btn4.FlatStyle = FlatStyle.Popup;btn4.BackgroundImageLayout = ImageLayout.Stretch;btn4.BackColor =  Color.Transparent;btn4.ForeColor =  Color.Black;
                            btn4.Location = new  Point(BotonUbicacion + 0, 645);btn4.Click += btn4_Click;lb4.Width = 152;lb4.Height = 16;lb4.ForeColor =  Color.Lime;lb4.BackColor =  Color.Transparent;
                            lb4.Location = new  Point(957, 795); lb4.Click += lb4_Click; btn4.MouseWheel += btn4_MouseWheel;
                        }
                        if (VecesCreacion == 5)
                        {
                            btn5.Width = 152;btn5.Height = 144;btn5.FlatStyle = FlatStyle.Popup;btn5.BackgroundImageLayout = ImageLayout.Stretch;btn5.BackColor =  Color.Transparent;btn5.ForeColor =  Color.Black;
                            btn5.Location = new  Point(BotonUbicacion + 0, 645);btn5.Click += btn5_Click;lb5.Width = 152;lb5.Height = 16;lb5.ForeColor =  Color.Lime;lb5.BackColor =  Color.Transparent;
                            lb5.Location = new  Point(1116, 795); lb5.Click += lb5_Click; btn5.MouseWheel += btn5_MouseWheel;
                        }
                        if (VecesCreacion == 6)
                        {
                            btn6.Width = 152;btn6.Height = 144;btn6.FlatStyle = FlatStyle.Popup;btn6.BackgroundImageLayout = ImageLayout.Stretch;btn6.BackColor =  Color.Transparent;btn6.ForeColor =  Color.Black;
                            btn6.Location = new  Point(BotonUbicacion + 0, 645);btn6.Click += btn6_Click;lb6.Width = 152;lb6.Height = 16;lb6.ForeColor =  Color.Lime;lb6.BackColor =  Color.Transparent;
                            lb6.Location = new  Point(1275, 795); lb6.Click += lb6_Click; btn6.MouseWheel += btn6_MouseWheel;
                        }
                    btnAgregar.Location = new  Point(BotonUbicacion + 159, 645); //Para que el boton Agregar lo vaya moviendo + 159 espacios
                    }
                    VecesCreacion = VecesCreacion + 1;
                }
                if (VecesCreacion == 7)//No se mueve mas el boton de Agregar
                {
                    btnAgregar.Location = new  Point(1434, 645);//Posicion limite
                    MessageBox.Show("No se pueden agregar mas controles a la coleccion", "Música", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                BotonUbicacion = BotonUbicacion + 159;Musica.ActiveForm.Controls.Add(btn);Musica.ActiveForm.Controls.Add(btn1);Musica.ActiveForm.Controls.Add(btn2);Musica.ActiveForm.Controls.Add(btn3);
                Musica.ActiveForm.Controls.Add(btn4);Musica.ActiveForm.Controls.Add(btn5);Musica.ActiveForm.Controls.Add(btn6);Musica.ActiveForm.Controls.Add(lb); Musica.ActiveForm.Controls.Add(lb1); Musica.ActiveForm.Controls.Add(lb2); Musica.ActiveForm.Controls.Add(lb3);
                Musica.ActiveForm.Controls.Add(lb4); Musica.ActiveForm.Controls.Add(lb5); Musica.ActiveForm.Controls.Add(lb6);
            } while (VecesCreacion == 7);    
        }
        

#endregion Boton Agregar Controles Dinamicos

#region Insertar caratula con Scroll
                        //Con la rueda del mouse vuelve a abrir el dialogo para insertar una ilustracion
        void btn6_MouseWheel(object sender, MouseEventArgs e)
        { if (Musica.ActiveForm.Controls.Contains(btn6)) { AgregarIlustracion6(); } else {}}
        void btn5_MouseWheel(object sender, MouseEventArgs e)
        { if (Musica.ActiveForm.Controls.Contains(btn5)) { AgregarIlustracion5(); } else {}}
        void btn4_MouseWheel(object sender, MouseEventArgs e)
        { if (Musica.ActiveForm.Controls.Contains(btn4)) { AgregarIlustracion4(); } else {}}
        void btn3_MouseWheel(object sender, MouseEventArgs e)
        { if (Musica.ActiveForm.Controls.Contains(btn3)) { AgregarIlustracion3(); } else {}}
        void btn2_MouseWheel(object sender, MouseEventArgs e)
        { if (Musica.ActiveForm.Controls.Contains(btn2)) { AgregarIlustracion2(); } else {}}
        void btn1_MouseWheel(object sender, MouseEventArgs e)
        { if (Musica.ActiveForm.Controls.Contains(btn1)) { AgregarIlustracion1(); } else {}}
        void btn_MouseWheel(object sender, MouseEventArgs e)
        { if (Musica.ActiveForm.Controls.Contains(btn)) { AgregarIlustracion(); } else {}}
        #endregion Insertar caratula con Scroll

#region Label's Dinamicos
        void lb6_Click(object sender, EventArgs e)
        {NameList6.Text = "Renombrar Lista...";NameList6.Location = new Point(1275, 795);lb6.TextAlign = ContentAlignment.MiddleCenter;NameList6.Visible = true;}
        void lb5_Click(object sender, EventArgs e)
        {NameList5.Text = "Renombrar Lista...";NameList5.Location = new Point(1116, 795);NameList5.Visible = true;lb5.TextAlign = ContentAlignment.MiddleCenter;lb5.Text = NameList5.Text;}
        void lb4_Click(object sender, EventArgs e)
        {NameList4.Text = "Renombrar Lista...";NameList4.Location = new Point(957, 795);NameList4.Visible = true;lb4.TextAlign = ContentAlignment.MiddleCenter;lb4.Text = NameList4.Text;}
        void lb3_Click(object sender, EventArgs e)
        {NameList3.Text = "Renombrar Lista...";NameList3.Location = new Point(798, 795);NameList3.Visible = true;lb3.TextAlign = ContentAlignment.MiddleCenter;lb3.Text = NameList3.Text;}
        void lb2_Click(object sender, EventArgs e)
        {NameList2.Text = "Renombrar Lista...";NameList2.Location = new Point(639, 795);NameList2.Visible = true;lb2.TextAlign = ContentAlignment.MiddleCenter;lb2.Text = NameList2.Text;}
        void lb1_Click(object sender, EventArgs e)
        {NameList1.Text = "Renombrar Lista...";NameList1.Location = new Point(480, 795);NameList1.Visible = true;lb1.TextAlign = ContentAlignment.MiddleCenter;lb1.Text = NameList1.Text;}
        void lb_Click(object sender, EventArgs e)
        {NameList.Text = "Renombrar Lista...";NameList.Visible = true;NameList.Location = new Point(321, 795);lb.TextAlign = ContentAlignment.MiddleCenter;lb.Text = NameList.Text;}
            //Renombrar la lista y ocultar el TextBox cuando se presiona ENTER
        private void NameList_KeyDown(object sender, KeyEventArgs e)
        {if (e.KeyCode == Keys.Enter) { NameList.Visible = false; lb.Text = NameList.Text;  }}
        private void NameList1_KeyDown(object sender, KeyEventArgs e)
        {if (e.KeyCode == Keys.Enter) { NameList1.Visible = false; lb1.Text = NameList1.Text;  }}
        private void NameList2_KeyDown(object sender, KeyEventArgs e)
        {if (e.KeyCode == Keys.Enter) { NameList2.Visible = false; lb2.Text = NameList2.Text;  }}
        private void NameList3_KeyDown(object sender, KeyEventArgs e)
        {if (e.KeyCode == Keys.Enter) { NameList3.Visible = false; lb3.Text = NameList3.Text;  }}
        private void NameList4_KeyDown(object sender, KeyEventArgs e)
        {if (e.KeyCode == Keys.Enter) { NameList4.Visible = false; lb4.Text = NameList4.Text; }}
        private void NameList5_KeyDown(object sender, KeyEventArgs e)
        {if (e.KeyCode == Keys.Enter) { NameList5.Visible = false; lb5.Text = NameList5.Text;  }}
        private void NameList6_KeyDown(object sender, KeyEventArgs e)
        {if (e.KeyCode == Keys.Enter) { NameList6.Visible = false; lb6.Text = NameList6.Text; }}
        #endregion Label's Dinamicos

#region Botones Dinamicos
        //Botones para agregar La caratula y la PlayList
        void btn6_Click(object sender, EventArgs e)
        {
            Creacion6 = Creacion6 + 1;
            if (Creacion6 == 1)
            {
                    if (ListaReproduccion.Items.Count != 0){ ListaReproduccion.Items.Clear(); listBox1.Items.Clear(); }
                    else {}
                    OpenFileDialog lista = new OpenFileDialog(); lista.Filter = Filtro;
                    lista.CustomPlaces.Add(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic));lista.Multiselect = true;
                    if (lista.ShowDialog() == DialogResult.OK)
                    {
                        string[] Coleccion = lista.FileNames;
                        foreach (string cancion in Coleccion)
                        {canciones6.Items.Add(cancion);listBox1.Items.Add(cancion);listBox1.SelectedIndex = 0;canciones6.SelectedIndex = 0;}
                        foreach (string cancion2 in Coleccion)
                        {
                            Lista6.Items.Add(System.IO.Path.GetFileNameWithoutExtension(cancion2));
                            ListaReproduccion.Items.Add(System.IO.Path.GetFileNameWithoutExtension(cancion2));
                            ListaReproduccion.SelectedIndex = 0; 
                            ContadordecancionesRojo(); 
                        }
                        Reproductor.URL = canciones6.SelectedItem.ToString(); btn6.BackgroundImage = Image.FromFile(Ruta + ImgPlayList);
                        Cambios();lb6.Text = Reproductor.currentPlaylist.name.ToString();Creacion6 = Creacion6 + 1;
                    }
                    else if (Musica.ActiveForm.Controls.Contains(btn6))
                        { Musica.ActiveForm.Controls.Remove(btn6); Musica.ActiveForm.Refresh(); btnAgregar.Location = new  Point(321, 645); VecesCreacion = 0; BotonUbicacion = 321; Creacion6 = 0;}
            }
            else if (canciones6.Items.Count != 0)
            {
                Cambios();
                if (Creacion6 == 3 & Musica.ActiveForm.Controls.Contains(btn6))
                { AgregarIlustracion6(); }
                lbArtista.Text = NameList6.Text; 
                listBox1.Items.Clear();
                ListaReproduccion.Items.Clear();
                foreach (string item in canciones6.Items)
                {listBox1.Items.Add(item);listBox1.SelectedIndex = 0;}
                foreach (string item2 in Lista6.Items)
                {ListaReproduccion.Items.Add(item2);ListaReproduccion.SelectedIndex = 0;}
                canciones6.SelectedIndex = 0;Album.BackgroundImage = Caratula6.Image;
                Reproductor.URL = canciones6.SelectedItem.ToString();
            }
            else if (canciones6.Items.Count == 0)
            { MessageBox.Show(NoSongs); }  
        }
        void btn5_Click(object sender, EventArgs e)
        {
            Creacion5 = Creacion5 + 1;
            if (Creacion5 == 1)
            {
                    if (ListaReproduccion.Items.Count != 0){ ListaReproduccion.Items.Clear(); listBox1.Items.Clear(); }
                    else {}
                    OpenFileDialog lista = new OpenFileDialog(); lista.Filter = Filtro;
                    lista.CustomPlaces.Add(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic));lista.Multiselect = true;
                    if (lista.ShowDialog() == DialogResult.OK)
                    {
                        string[] Coleccion = lista.FileNames;
                        foreach (string cancion in Coleccion)
                        {canciones5.Items.Add(cancion);listBox1.Items.Add(cancion);listBox1.SelectedIndex = 0;canciones5.SelectedIndex = 0;}
                        foreach (string cancion2 in Coleccion)
                        {
                            Lista5.Items.Add(System.IO.Path.GetFileNameWithoutExtension(cancion2));
                            ListaReproduccion.Items.Add(System.IO.Path.GetFileNameWithoutExtension(cancion2));
                            ListaReproduccion.SelectedIndex = 0; 
                            ContadordecancionesRojo();
                        }
                        Reproductor.URL = canciones5.SelectedItem.ToString(); btn5.BackgroundImage = Image.FromFile(Ruta + ImgPlayList);
                        Cambios();lb5.Text = Reproductor.currentPlaylist.name.ToString();Creacion5 = Creacion5 + 1;
                    }
                    else if (Musica.ActiveForm.Controls.Contains(btn5))
                        { Musica.ActiveForm.Controls.Remove(btn5); Musica.ActiveForm.Refresh(); btnAgregar.Location = new  Point(321, 645); VecesCreacion = 0; BotonUbicacion = 321; Creacion5 = 0; }
            }
            else if (canciones5.Items.Count != 0)
            {
                Cambios(); 
                if (Creacion5 == 3 & Musica.ActiveForm.Controls.Contains(btn5))
                { AgregarIlustracion5();  }
                lbArtista.Text = NameList5.Text;
                listBox1.Items.Clear();
                ListaReproduccion.Items.Clear();
                foreach (string item in canciones5.Items)
                {listBox1.Items.Add(item);listBox1.SelectedIndex = 0;}
                foreach (string item2 in Lista5.Items)
                {ListaReproduccion.Items.Add(item2);ListaReproduccion.SelectedIndex = 0;}
                canciones5.SelectedIndex = 0;Album.BackgroundImage = Caratula5.Image;Reproductor.URL = canciones5.SelectedItem.ToString();
            }
            else if (canciones5.Items.Count == 0)
            { MessageBox.Show(NoSongs); }  
        }
        void btn4_Click(object sender, EventArgs e)
        {
            Creacion4 = Creacion4 + 1;
            if (Creacion4 == 1)
            {
                    if (ListaReproduccion.Items.Count != 0){ ListaReproduccion.Items.Clear(); listBox1.Items.Clear(); }
                    else {}
                    OpenFileDialog lista = new OpenFileDialog(); lista.Filter = Filtro;
                    lista.CustomPlaces.Add(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic));lista.Multiselect = true;
                    if (lista.ShowDialog() == DialogResult.OK)
                    {
                        string[] Coleccion = lista.FileNames;
                        foreach (string cancion in Coleccion)
                        {canciones4.Items.Add(cancion);listBox1.Items.Add(cancion);listBox1.SelectedIndex = 0;canciones4.SelectedIndex = 0;}
                        foreach (string cancion2 in Coleccion)
                        {
                            Lista4.Items.Add(System.IO.Path.GetFileNameWithoutExtension(cancion2));
                            ListaReproduccion.Items.Add(System.IO.Path.GetFileNameWithoutExtension(cancion2));
                            ListaReproduccion.SelectedIndex = 0; 
                            ContadordecancionesRojo(); 
                        }
                        Reproductor.URL = canciones4.SelectedItem.ToString(); btn4.BackgroundImage = Image.FromFile(Ruta + ImgPlayList);
                        Cambios();lb4.Text = Reproductor.currentPlaylist.name.ToString();Creacion4 = Creacion4 + 1;
                    }
                    else if (Musica.ActiveForm.Controls.Contains(btn4))
                        { Musica.ActiveForm.Controls.Remove(btn4); Musica.ActiveForm.Refresh(); btnAgregar.Location = new  Point(321, 645); VecesCreacion = 0; BotonUbicacion = 321; Creacion4 = 0; }
            }
            else if (canciones4.Items.Count != 0)
            {
                Cambios(); 
                if (Creacion4 == 3 & Musica.ActiveForm.Controls.Contains(btn4))
                { AgregarIlustracion4();  }
                lbArtista.Text = NameList4.Text;
                listBox1.Items.Clear();
                ListaReproduccion.Items.Clear();
                foreach (string item in canciones4.Items)
                {listBox1.Items.Add(item);listBox1.SelectedIndex = 0;}
                foreach (string item2 in Lista4.Items)
                {ListaReproduccion.Items.Add(item2);ListaReproduccion.SelectedIndex = 0;}
                canciones4.SelectedIndex = 0;Album.BackgroundImage = Caratula4.Image;Reproductor.URL = canciones4.SelectedItem.ToString();
            }
            else if (canciones4.Items.Count == 0)
            { MessageBox.Show(NoSongs); }  
        }
        void btn3_Click(object sender, EventArgs e)
        {
            Creacion3 = Creacion3 + 1;
            if (Creacion3 == 1)
            {
                    if (ListaReproduccion.Items.Count != 0){ ListaReproduccion.Items.Clear(); listBox1.Items.Clear(); }
                    else {}
                    OpenFileDialog lista = new OpenFileDialog(); lista.Filter = Filtro;
                    lista.CustomPlaces.Add(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic));lista.Multiselect = true;
                    if (lista.ShowDialog() == DialogResult.OK)
                    {
                        
                        string[] Coleccion = lista.FileNames;
                        foreach (string cancion in Coleccion)
                        {canciones3.Items.Add(cancion);listBox1.Items.Add(cancion);listBox1.SelectedIndex = 0;canciones3.SelectedIndex = 0;}
                        foreach (string cancion2 in Coleccion)
                        {
                            Lista3.Items.Add(System.IO.Path.GetFileNameWithoutExtension(cancion2));
                            ListaReproduccion.Items.Add(System.IO.Path.GetFileNameWithoutExtension(cancion2));
                            ListaReproduccion.SelectedIndex = 0;
                            ContadordecancionesRojo(); 
                        }
                        Reproductor.URL = canciones3.SelectedItem.ToString(); btn3.BackgroundImage = Image.FromFile(Ruta + ImgPlayList);
                        Cambios();lb3.Text = Reproductor.currentPlaylist.name.ToString();Creacion3 = Creacion3 + 1;
                    }
                    else
                        if (Musica.ActiveForm.Controls.Contains(btn3))
                        { Musica.ActiveForm.Controls.Remove(btn3); Musica.ActiveForm.Refresh(); btnAgregar.Location = new  Point(321, 645); VecesCreacion = 0; BotonUbicacion = 321; Creacion3 = 0; }   
            }
            else if (canciones3.Items.Count != 0)
            {
                Cambios(); 
                if (Creacion3 == 3 & Musica.ActiveForm.Controls.Contains(btn3))
                { AgregarIlustracion3(); }
                lbArtista.Text = NameList3.Text; 
                listBox1.Items.Clear();
                ListaReproduccion.Items.Clear();
                foreach (string item in canciones3.Items)
                {listBox1.Items.Add(item);listBox1.SelectedIndex = 0;}
                foreach (string item2 in Lista3.Items)
                {ListaReproduccion.Items.Add(item2);ListaReproduccion.SelectedIndex = 0;}
                canciones3.SelectedIndex = 0;Album.BackgroundImage = Caratula3.Image;Reproductor.URL = canciones3.SelectedItem.ToString();
            }
            else if (canciones3.Items.Count == 0)
            { MessageBox.Show(NoSongs); }  
      
        }
        void btn2_Click(object sender, EventArgs e)
        {
            Creacion2 = Creacion2 + 1;
            if (Creacion2 == 1)
            {
                    if (ListaReproduccion.Items.Count != 0){ ListaReproduccion.Items.Clear(); listBox1.Items.Clear(); }
                    else {}
                    OpenFileDialog lista = new OpenFileDialog(); lista.Filter = Filtro;
                    lista.CustomPlaces.Add(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic));lista.Multiselect = true;
                    if (lista.ShowDialog() == DialogResult.OK)
                    {
                        string[] Coleccion = lista.FileNames;
                        foreach (string cancion in Coleccion)
                        {canciones2.Items.Add(cancion);listBox1.Items.Add(cancion);listBox1.SelectedIndex = 0;canciones2.SelectedIndex = 0;}
                        foreach (string cancion2 in Coleccion)
                        {
                            Lista2.Items.Add(System.IO.Path.GetFileNameWithoutExtension(cancion2));
                            ListaReproduccion.Items.Add(System.IO.Path.GetFileNameWithoutExtension(cancion2)); 
                            ListaReproduccion.SelectedIndex = 0; 
                            ContadordecancionesRojo(); 
                        }
                        Reproductor.URL = canciones2.SelectedItem.ToString(); btn2.BackgroundImage = Image.FromFile(Ruta + ImgPlayList);
                        Cambios();lb2.Text = Reproductor.currentPlaylist.name.ToString();Creacion2 = Creacion2 + 1;
                    }
                    else if (Musica.ActiveForm.Controls.Contains(btn2))
                        { Musica.ActiveForm.Controls.Remove(btn2); Musica.ActiveForm.Refresh(); btnAgregar.Location = new Point(321, 645); VecesCreacion = 0; BotonUbicacion = 321; Creacion2 = 0; }
            }
            else if (canciones2.Items.Count != 0)
            {
                Cambios(); 
                if (Creacion2 == 3 & Musica.ActiveForm.Controls.Contains(btn2))
                { AgregarIlustracion2();}
                lbArtista.Text = NameList2.Text; 
                listBox1.Items.Clear();
                ListaReproduccion.Items.Clear();
                foreach (string item in canciones2.Items)
                {listBox1.Items.Add(item);listBox1.SelectedIndex = 0;}
                foreach (string item2 in Lista2.Items)
                {ListaReproduccion.Items.Add(item2);ListaReproduccion.SelectedIndex = 0;}
                canciones2.SelectedIndex = 0;Album.BackgroundImage = Caratula2.Image;Reproductor.URL = canciones2.SelectedItem.ToString();
            }
            else if (canciones2.Items.Count == 0)
            { MessageBox.Show(NoSongs); }  
        }
        void btn1_Click(object sender, EventArgs e)
        {
            Creacion1 = Creacion1 + 1;
            if (Creacion1 == 1)
            {
                {
                    if (ListaReproduccion.Items.Count != 0) { ListaReproduccion.Items.Clear(); listBox1.Items.Clear(); }
                    else {}
                    OpenFileDialog lista = new OpenFileDialog(); lista.Filter = Filtro;
                    lista.CustomPlaces.Add(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic)); lista.Multiselect = true;
                    if (lista.ShowDialog() == DialogResult.OK)
                    {
                        string[] Coleccion = lista.FileNames;
                        foreach (string cancion in Coleccion)
                        {
                            canciones1.Items.Add(cancion); 
                            listBox1.Items.Add(cancion); 
                            listBox1.SelectedIndex = 0; 
                            canciones1.SelectedIndex = 0;
                        }
                        foreach (string cancion2 in Coleccion)
                        { 
                            Lista1.Items.Add(System.IO.Path.GetFileNameWithoutExtension(cancion2)); 
                            ListaReproduccion.Items.Add(System.IO.Path.GetFileNameWithoutExtension(cancion2)); 
                            ListaReproduccion.SelectedIndex = 0; 
                            ContadordecancionesRojo(); 
                        }
                        Reproductor.URL = canciones1.SelectedItem.ToString(); btn1.BackgroundImage = Image.FromFile(Ruta + ImgPlayList);
                        Cambios(); lb1.Text = Reproductor.currentPlaylist.name.ToString(); Creacion1 = Creacion1 + 1;
                    }
                    else if (Musica.ActiveForm.Controls.Contains(btn1))
                    { Musica.ActiveForm.Controls.Remove(btn1); Musica.ActiveForm.Refresh(); btnAgregar.Location = new  Point(321, 645); VecesCreacion = 0; BotonUbicacion = 321; Creacion1 = 0; }
                }
            }
            else if (canciones1.Items.Count != 0)
            {
                Cambios(); 
                if (Creacion1 == 3 & Musica.ActiveForm.Controls.Contains(btn1))
                { AgregarIlustracion1();  }
                lbArtista.Text = NameList1.Text;
                listBox1.Items.Clear();
                ListaReproduccion.Items.Clear();
                foreach (string item in canciones1.Items)
                {listBox1.Items.Add(item);listBox1.SelectedIndex = 0;}
                foreach (string item2 in Lista1.Items)
                {ListaReproduccion.Items.Add(item2);ListaReproduccion.SelectedIndex = 0;}
                canciones1.SelectedIndex = 0;Album.BackgroundImage = Caratula1.Image;Reproductor.URL = canciones1.SelectedItem.ToString();
            }
            else if (canciones1.Items.Count == 0)
            { MessageBox.Show(NoSongs); }  
        }
        void btn_Click(object sender, EventArgs e) 
        {
            Creacion = Creacion + 1;
            if (Creacion == 1)
            {
                    if (ListaReproduccion.Items.Count != 0)//Si contiene canciones que las borre cuando se agregue otra coleccion,porque ya estan copiadas en otro listBox Temporal (canciones)
                    { ListaReproduccion.Items.Clear(); listBox1.Items.Clear(); }
                    else { }
                    OpenFileDialog lista = new OpenFileDialog(); lista.Filter = Filtro;
                    lista.CustomPlaces.Add(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic));lista.Multiselect = true;
                    if (lista.ShowDialog() == DialogResult.OK)
                    {
                        string[] Coleccion = lista.FileNames;//Solo recorre la ruta completa de cada Track
                        foreach (string cancion in Coleccion)
                        {
                            canciones.Items.Add(cancion);//Guarda la coleccion es un listBox Dinamico
                            listBox1.Items.Add(cancion);//Las agrega a la lista
                            listBox1.SelectedIndex = 0;//Primer Track
                            canciones.SelectedIndex = 0;//Primer Track (Temporal)
                        }
                        foreach (string cancion2 in Coleccion)
                        {
                            Lista.Items.Add(System.IO.Path.GetFileNameWithoutExtension(cancion2));//Guarda SOLO el nombre de las canciones en un listBox Dinamico y borra la extension
                            ListaReproduccion.Items.Add(System.IO.Path.GetFileNameWithoutExtension(cancion2));//Las agrega a la lista
                            ListaReproduccion.SelectedIndex = 0;//Primera cancion la selecciona
                            ContadordecancionesRojo();//Inicia el contador de canciones que hay en la lista de reproduccion
                        }
                        Reproductor.URL = canciones.SelectedItem.ToString(); btn.BackgroundImage = Image.FromFile(Ruta + ImgPlayList);
                        Cambios();lb.Text = Reproductor.currentPlaylist.name.ToString();Creacion = Creacion + 1;
                    }
                    else if (Musica.ActiveForm.Controls.Contains(btn))
                        {Musica.ActiveForm.Controls.Remove(btn); Musica.ActiveForm.Refresh(); btnAgregar.Location = new  Point(321, 645); VecesCreacion = 0; BotonUbicacion = 321; Creacion = 0;}
            }
            else if (canciones.Items.Count != 0)
            {
                Cambios(); 
                if (Creacion == 3 & Musica.ActiveForm.Controls.Contains(btn))
                {
                    AgregarIlustracion();//Llama al dialogo para pedir una caratula
                }
                lbArtista.Text = NameList.Text;//Copia el nombre del Artista ingresado en el textbox
                ListaReproduccion.Items.Clear();
                listBox1.Items.Clear();//Borra los de otros artistas
                foreach (string item in canciones.Items)
                {
                    listBox1.Items.Add(item);//Agrega nuevamente las canciones guardadas en un ListBox Dinamico
                    listBox1.SelectedIndex = 0;
                }
                foreach (string item2 in Lista.Items)
                {
                    ListaReproduccion.Items.Add(item2);//Agrega SOLO el nombre de las canciones a la lista de reproduccion
                    ListaReproduccion.SelectedIndex = 0;
                }
                canciones.SelectedIndex = 0;Album.BackgroundImage = Caratula.Image;//Recupera la imagen guardada
                Reproductor.URL = canciones.SelectedItem.ToString();//Vuelve a reproducir las canciones guardadas en el listBox Dinamico
            }
            else if (canciones.Items.Count == 0)
            { MessageBox.Show(NoSongs); }
        }
        
#endregion Botones Dinamicos

#region Agregar Ilustracion

        void AgregarIlustracion6()
        {
            DialogoIlustracion();
            if (ilustracion.ShowDialog() == DialogResult.OK)
            {
                if (ilustracion.FileName != null)
                {
                    Caratula6.Image =  Image.FromFile(ilustracion.FileName);
                    btn6.BackgroundImage =  Image.FromFile(ilustracion.FileName);
                    Album.BackgroundImage =  Image.FromFile(ilustracion.FileName);
                }
            }
            else
            {
                btn6.BackgroundImage = Image.FromFile(Ruta + ImgPlayList);
                AlbumDefault();
            }
        }
        void AgregarIlustracion5()
        {
            DialogoIlustracion();
            if (ilustracion.ShowDialog() == DialogResult.OK)
            {
                if (ilustracion.FileName != null)
                {
                    Caratula5.Image =  Image.FromFile(ilustracion.FileName);
                    btn5.BackgroundImage =  Image.FromFile(ilustracion.FileName);
                    Album.BackgroundImage =  Image.FromFile(ilustracion.FileName);
                }
            }
            else
            {
                btn5.BackgroundImage = Image.FromFile(Ruta + ImgPlayList);
                AlbumDefault();
            }
        }
        void AgregarIlustracion4()
        {
            DialogoIlustracion();
            if (ilustracion.ShowDialog() == DialogResult.OK)
            {
                if (ilustracion.FileName != null)
                {
                    Caratula4.Image =  Image.FromFile(ilustracion.FileName);
                    btn4.BackgroundImage =  Image.FromFile(ilustracion.FileName);
                    Album.BackgroundImage =  Image.FromFile(ilustracion.FileName);
                }
            }
            else
            {
                btn4.BackgroundImage = Image.FromFile(Ruta + ImgPlayList);
                AlbumDefault();
            }
        }
        void AgregarIlustracion3()
        {
            DialogoIlustracion();
            if (ilustracion.ShowDialog() == DialogResult.OK)
            {
                if (ilustracion.FileName != null)
                {
                    Caratula3.Image =  Image.FromFile(ilustracion.FileName);
                    btn3.BackgroundImage =  Image.FromFile(ilustracion.FileName);
                    Album.BackgroundImage =  Image.FromFile(ilustracion.FileName);
                }
            }
            else
            {
                btn3.BackgroundImage = Image.FromFile(Ruta + ImgPlayList);
                AlbumDefault();
            }
        }
        void AgregarIlustracion2()
        {
            DialogoIlustracion();
            if (ilustracion.ShowDialog() == DialogResult.OK)
            {
                if (ilustracion.FileName != null)
                {
                    Caratula2.Image =  Image.FromFile(ilustracion.FileName);
                    btn2.BackgroundImage =  Image.FromFile(ilustracion.FileName);
                    Album.BackgroundImage =  Image.FromFile(ilustracion.FileName);
                }
            }
            else
            {
                btn2.BackgroundImage = Image.FromFile(Ruta + ImgPlayList);
                AlbumDefault();
            }
        }
        void AgregarIlustracion1()
        {
            DialogoIlustracion();
            if (ilustracion.ShowDialog() == DialogResult.OK)
            {
                if (ilustracion.FileName != null)
                {
                    Caratula1.Image =  Image.FromFile(ilustracion.FileName);
                    btn1.BackgroundImage =  Image.FromFile(ilustracion.FileName);
                    Album.BackgroundImage =  Image.FromFile(ilustracion.FileName);
                }
            }
            else
            {
                btn1.BackgroundImage = Image.FromFile(Ruta + ImgPlayList);
                AlbumDefault();
            }
        }
        void AgregarIlustracion()
        {
            DialogoIlustracion();
            if (ilustracion.ShowDialog() == DialogResult.OK)
            {
                if (ilustracion.FileName != null)
                {
                    Caratula.Image =  Image.FromFile(ilustracion.FileName);//Guarda la imagen en un label dinamico
                    btn.BackgroundImage =  Image.FromFile(ilustracion.FileName);//Que pinte el boton con la caratula
                    Album.BackgroundImage =  Image.FromFile(ilustracion.FileName);//Que lleve la caratula al PictureBox
                }
            }
            else
            {
                btn.BackgroundImage = Image.FromFile(Ruta + ImgPlayList);
                AlbumDefault();
            }
        }
        private void DialogoIlustracion()
        {
            ilustracion.Filter = Filtro2;
            ilustracion.CustomPlaces.Add(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)); ilustracion.Multiselect = false;
        }
        private void AlbumDefault()
        {
            Album.BackgroundImage = Image.FromFile(Ruta + "Nota.gif");//Se recupera la imagen de la nota musical
        }
        #endregion Agregar Ilustracion

#region Radio Online
        private void btnRadio_Click(object sender, EventArgs e)
        {
            try
            {
                    StopRadio();//Que detenga la lista de reproducion o PlayList antes de conectar una emisora
                    Balance.Value = 5;//Mitad de balance para evitar el Bug del canal derecho
                    RefreshVumetro.Start(); btnGuardarList.Visible = false; listBox1.Visible = false; lbArtista.Text = "Radio ♫♪";NaveLista.Visible = true;
                    lbArtista.ForeColor =  Color.Red; Refreshnombre.Start(); RefreshSlider.Start(); RefreshDuracion.Start(); ListaReproduccion.Visible = false; Album.Visible = false;
                    ImagenRadio.Image =  Image.FromFile("C:\\Speech Lucy\\Asistente personal Lucy\\Asistente personal Lucy\\bin\\Debug\\Recursos\\Imagenes\\Antena.gif"); ImagenRadio.Visible = true;
                    Reproductor.URL = "http://108.61.73.119:8054"; Reproductor.Ctlcontrols.play(); //Emisora Default
                    label41.Visible = true; label42.Visible = true; label43.Visible = true; label44.Visible = true; label45.Visible = true; label45.BackColor =  Color.Black;
                    label45.BackColor =  Color.DarkViolet; label47.Visible = false; button35.Visible = true; button36.Visible = false; label64.Visible = true;
                    NaveLista.Navigate(new Uri("http://108.61.73.119:8054/played.html"));//Lista de 181.The Beats
                    NaveLista.Focus();//Se le da el foco para enviar un zoom 
            }
            catch (Exception Ex) { MessageBox.Show(Ex.Message); }
        }
        void StopRadio()
        {
            try
            {
                reanudar = false;
                if (canciones.Items.Count != 0 & lbArtista.Text != "--------" & ListaReproduccion.Items.Count != 0 & reanudar == false)//Los tres vacios
                {
                    Refreshnombre.Stop();
                    RefreshSlider.Stop();
                    RefreshDuracion.Stop();
                    RefreshVumetro.Stop();
                    DetenerReproductor(); Album.BackgroundImage = Image.FromFile(Ruta + "Nota 2.gif");
                    MostrarVumetrosInver();
                }
                else
                {
                    DetenerReproductor(); RefreshVumetro.Stop();MostrarVumetrosInver();
                }
            }
            catch (Exception Ex)
            { MessageBox.Show(Ex.Message); }
        }
        private void label45_Click(object sender, EventArgs e)//Emisora 181.The Beats
        {
            try
            {
                Reproductor.URL = "http://108.61.73.119:8054"; Reproductor.Ctlcontrols.play(); label45.BackColor =  Color.Transparent; label45.BackColor =  Color.DarkViolet;
                label41.BackColor =  Color.Transparent; label42.BackColor =  Color.Transparent; label43.BackColor =  Color.Transparent; 
                NaveLista.Navigate(new Uri("http://108.61.73.119:8054/played.html"));//Se actualiza con la barra
            }
            catch (Exception Ex){MessageBox.Show(Ex.Message);}
        }
        private void label42_Click(object sender, EventArgs e)//HOT 108 JAMZ
        {
            try
            {
                NaveLista.Focus();//Se le da el foco para enviar un zoom 
                if (contZoom == 1 | contZoom == 2)
                {
                     SendKeys.SendWait("^{ADD}");//Se envia el zoom a la pagina
                    contZoom = contZoom + 1;
                }
                else { }
                Reproductor.URL = "http://108.61.30.179:4010"; Reproductor.Ctlcontrols.play(); label42.BackColor =  Color.Transparent; label42.BackColor =  Color.DarkViolet;
                label41.BackColor =  Color.Transparent; label43.BackColor =  Color.Transparent; label45.BackColor =  Color.Transparent;
                NaveLista.Navigate(new Uri("http://www.hot108.com/includes/php/last-10-played-wmp.php"));//No es necesario actualizar
                 SendKeys.SendWait("^{ADD}");//Se envia el zoom a la pagina
                
            }
            catch (Exception Ex){MessageBox.Show(Ex.Message);}
        }
        private void label41_Click(object sender, EventArgs e)//Reggae 141
        {
            try
            {
                Reproductor.URL = "http://184.107.197.154:8002"; Reproductor.Ctlcontrols.play(); label41.BackColor =  Color.Transparent; label41.BackColor =  Color.DarkViolet;
                label42.BackColor =  Color.Transparent; label43.BackColor =  Color.Transparent; label45.BackColor =  Color.Transparent;
                NaveLista.Navigate(new Uri("http://184.107.197.154:8002/played.html"));//Se actualiza con la barra
                
            }
            catch (Exception Ex) { MessageBox.Show(Ex.Message); }
        }
                                //Boton para guardar guardar una emisora personalizada
        private void button35_Click(object sender, EventArgs e)
        {
            txtLink.TextChanged += txtLink_TextChanged;
            if (contTxtlink == 2) { txtLink.Visible = false; button35.Text = "Nuevo"; button35.ForeColor = Color.Orange; contTxtlink = 1;}
            else if (contTxtlink == 1) { MessageBox.Show("Por favor ingrese un link en el campo..."); txtLink.Visible = true; contTxtlink = 2; button35.Text = "Cancelar"; button35.ForeColor = Color.Red; }
        }
        void txtLink_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtLink.Text != "")
                {
                    Thread.Sleep(2000);
                    Reproductor.URL = txtLink.Text; label43.BackColor =  Color.Black; label43.BackColor =  Color.DarkViolet;
                    label41.BackColor =  Color.Black; label42.BackColor =  Color.Black; label45.BackColor =  Color.Black;
                }
                else {}    
            }
            catch (Exception Ex)
            {MessageBox.Show(Ex.Message);}
        }
#endregion Radio

#region Cambios en la PlayList

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tb1.Text == "" & listBox1.SelectedIndex != listBox1.Items.Count - 1 | listBox1.Items.Count != 0 & reanudar == true)//Ocurre cuando NO se selecciona en el ultimo Track (Automatico)
            {
                if (listBox1.SelectedIndex > 0){ReproducirSeleccionado();RefreshDuracion.Start();}
                else {}//Si no que no haga nada
            }
            if (tb1.Text == "" & listBox1.SelectedIndex == listBox1.Items.Count - 1)//Ocurre cuando SI selecciona el ultimo track
            {
                ReproducirSeleccionado();//Se salta esta instruccion
                if (tb1.Text == "" & listBox1.SelectedIndex == listBox1.Items.Count - 1 & Reproductor.playState != WMPPlayState.wmppsPlaying)
                {
                    listBox1.SelectedIndex = 0;//Vuelve a empezar la playlist
                }else{}
            }
            if (listBox1.SelectedIndex > 0){ReproducirSeleccionado();}
            else {}//Si no que no haga nada
        }
        private void ListaReproduccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tb1.Text == "" & listBox1.SelectedIndex != listBox1.Items.Count - 1 | listBox1.Items.Count != 0)
            {listBox1.SelectedIndex = ListaReproduccion.SelectedIndex; ContadordecancionesVerde();}
        }
        private void button36_Click(object sender, EventArgs e)
        {
            if (ListaReproduccion.Items.Count != 0){ListaReproduccion.Items.Clear();}
            else {}
        }

        #endregion

#region Agregar canciones por Individual //----------------------Asignar otra función a este boton----------------------->
        //Boton para agregar una cancion  (Agregar la coleccion en una Matriz o encolar canciones)
        private void btnGuardarList_Click(object sender, EventArgs e)
        {
           //Asignar alguna funcion
        }
#endregion Agregar canciones por Individual  

#region Tema de fondo
        private void button38_Click(object sender, EventArgs e)
        {
            //No acepta ninguna otra imagen con un nombre diferente
            if (contTema == 1) {MessageBox.Show("Tambíen puede utilizar el tema en alto contraste.Para esto desplaze la rueda del mouse sobre éste botón"); contTema = 2;}
            imagen.Filter = Filtro2;
            imagen.FilterIndex = 3;
            imagen.FileName = "Seleccione una imagen para mostar como fondo";
            imagen.Title = "Imagen de fondo";
            if (imagen.ShowDialog() == DialogResult.OK)
            {
                opcion = imagen.FileName;
                string nombre = imagen.SafeFileName;
                if (nombre.Contains("Tapiz 5 Mosaico.jpg") | nombre.Contains("Tapiz 4 Mosaico.jpg"))
                {
                    ImagendeFondo();
                    BackgroundImageLayout = ImageLayout.Tile;
                }
                else if (nombre.Contains("Tapiz (1366x768).jpg") | nombre.Contains("Tapiz 1 (1366x768).jpg") | nombre.Contains("Tapiz 2 (1366x768).jpg") | nombre.Contains("Tapiz 3 (1366x768).jpg") | nombre.Contains("Tapiz 6 (1366x768).jpg"))
                {
                    ImagendeFondo();
                    BackgroundImageLayout = ImageLayout.Stretch;
                }
                else if (nombre.Contains("Tapiz (1920x1080).jpg") | nombre.Contains("Tapiz 1 (1920x1080).jpg") | nombre.Contains("Tapiz 2 (1920x1080).jpg") | nombre.Contains("Tapiz 3 (1920x1080).jpg") | nombre.Contains("Tapiz 6 (1920x1080).jpg"))
                {
                    ImagendeFondo();
                    BackgroundImageLayout = ImageLayout.None;
                }
                else if (nombre.Contains("Usuario.gif"))
                {
                    ImagendeFondo();
                    BackgroundImageLayout = ImageLayout.Stretch;
                }
            }
            else {} //Lo deja con la imagen seleccionada
        }
        private void ImagendeFondo()
        {
            BackgroundImage = Image.FromFile(opcion); 
        }
        #endregion Tema de fondo

#region Contadores Display
        void ContadordecancionesRojo()
        {
            int Total; int menos;
            Total = ListaReproduccion.Items.Count;
            menos = Total - 1;
            if (menos == 1)//Si el numero de elementos de la coleecion es = X ,entonces...que muestre la cantidad X en un display
            {
                //Que muestre el display el numero 1 solo en el label Rojo2
                
                Rojo2.BackgroundImage = Image.FromFile(RutaDisplayRed + "1.gif");
            }
            if (menos == 2)
            {
                Rojo2.BackgroundImage = Image.FromFile(RutaDisplayRed + "2.gif");  
            }
            if (menos == 3)
            {
                Rojo2.BackgroundImage =  Image.FromFile(RutaDisplayRed + "3.gif");
            }
            if (menos == 4)
            {
                Rojo2.BackgroundImage =  Image.FromFile(RutaDisplayRed + "4.gif");
            }
            if (menos == 5)
            {
                Rojo2.BackgroundImage =  Image.FromFile(RutaDisplayRed + "5.gif");
            }
            if (menos == 6)
            {
                Rojo2.BackgroundImage =  Image.FromFile(RutaDisplayRed + "6.gif");
            }
            if (menos == 7)
            {
                Rojo2.BackgroundImage =  Image.FromFile(RutaDisplayRed + "7.gif"); 
            }
            if (menos == 8)
            {
                Rojo2.BackgroundImage =  Image.FromFile(RutaDisplayRed + "8.gif");
            }
            if (menos == 9)
            {
                Rojo2.BackgroundImage =  Image.FromFile(RutaDisplayRed + "9.gif");
            }
            //Se comienzan a utilizar los dos display
            if (menos == 10)
            {
                Rojo1.BackgroundImage =  Image.FromFile(RutaDisplayRed + "1.gif");
                Rojo2.BackgroundImage =  Image.FromFile(RutaDisplayRed + "0.gif");
            }
            if (menos == 11)
            {
                Rojo1.BackgroundImage =  Image.FromFile(RutaDisplayRed + "1.gif");
                Rojo2.BackgroundImage =  Image.FromFile(RutaDisplayRed + "1.gif");
            }
            if (menos == 12)
            {
                Rojo1.BackgroundImage =  Image.FromFile(RutaDisplayRed + "1.gif");
                Rojo2.BackgroundImage =  Image.FromFile(RutaDisplayRed + "2.gif");
            }
            if (menos == 13)
            {
                Rojo1.BackgroundImage =  Image.FromFile(RutaDisplayRed + "1.gif");
                Rojo2.BackgroundImage =  Image.FromFile(RutaDisplayRed + "3.gif");
            }
            if (menos == 14)
            {
                Rojo1.BackgroundImage =  Image.FromFile(RutaDisplayRed + "1.gif");
                Rojo2.BackgroundImage =  Image.FromFile(RutaDisplayRed + "4.gif");
            }
            if (menos == 15)
            {
                Rojo1.BackgroundImage =  Image.FromFile(RutaDisplayRed + "1.gif");
                Rojo2.BackgroundImage =  Image.FromFile(RutaDisplayRed + "5.gif");
            }
            if (menos == 16)
            {
                Rojo1.BackgroundImage =  Image.FromFile(RutaDisplayRed + "1.gif");
                Rojo2.BackgroundImage =  Image.FromFile(RutaDisplayRed + "6.gif");
            }
            if (menos == 17)
            {
                Rojo1.BackgroundImage =  Image.FromFile(RutaDisplayRed + "1.gif");
                Rojo2.BackgroundImage =  Image.FromFile(RutaDisplayRed + "7.gif");
            }
            if (menos == 18)
            {
                Rojo1.BackgroundImage =  Image.FromFile(RutaDisplayRed + "1.gif");
                Rojo2.BackgroundImage =  Image.FromFile(RutaDisplayRed + "8.gif");
            }
            if (menos == 19)
            {
                Rojo1.BackgroundImage =  Image.FromFile(RutaDisplayRed + "1.gif");
                Rojo2.BackgroundImage =  Image.FromFile(RutaDisplayRed + "9.gif");
            }
            if (menos == 20)
            {
                Rojo1.BackgroundImage =  Image.FromFile(RutaDisplayRed + "2.gif");
                Rojo2.BackgroundImage =  Image.FromFile(RutaDisplayRed + "0.gif");
            }
            if (menos == 21)
            {
                Rojo1.BackgroundImage =  Image.FromFile(RutaDisplayRed + "2.gif");
                Rojo2.BackgroundImage =  Image.FromFile(RutaDisplayRed + "1.gif");
            }
            if (menos == 22)
            {
                Rojo1.BackgroundImage =  Image.FromFile(RutaDisplayRed + "2.gif");
                Rojo2.BackgroundImage =  Image.FromFile(RutaDisplayRed + "2.gif");
            }
            if (menos == 23)
            {
                Rojo1.BackgroundImage =  Image.FromFile(RutaDisplayRed + "2.gif");
                Rojo2.BackgroundImage =  Image.FromFile(RutaDisplayRed + "3.gif");
            }
            if (menos == 24)
            {
                Rojo1.BackgroundImage =  Image.FromFile(RutaDisplayRed + "2.gif");
                Rojo2.BackgroundImage =  Image.FromFile(RutaDisplayRed + "4.gif");
            }
            if (menos == 25)
            {
                Rojo1.BackgroundImage =  Image.FromFile(RutaDisplayRed + "2.gif");
                Rojo2.BackgroundImage =  Image.FromFile(RutaDisplayRed + "5.gif");
            }
            if (menos == 26)
            {
                Rojo1.BackgroundImage =  Image.FromFile(RutaDisplayRed + "2.gif");
                Rojo2.BackgroundImage =  Image.FromFile(RutaDisplayRed + "6.gif");
            }
            if (menos == 27)
            {
                Rojo1.BackgroundImage =  Image.FromFile(RutaDisplayRed + "2.gif");
                Rojo2.BackgroundImage =  Image.FromFile(RutaDisplayRed + "7.gif");
            }
            if (menos == 28)
            {
                Rojo1.BackgroundImage =  Image.FromFile(RutaDisplayRed + "2.gif");
                Rojo2.BackgroundImage =  Image.FromFile(RutaDisplayRed + "8.gif");
            }
            if (menos == 29)
            {
                Rojo1.BackgroundImage =  Image.FromFile(RutaDisplayRed + "2.gif");
                Rojo2.BackgroundImage =  Image.FromFile(RutaDisplayRed + "9.gif");
            }
            if (menos == 30)
            {
                Rojo1.BackgroundImage =  Image.FromFile(RutaDisplayRed + "3.gif");
                Rojo2.BackgroundImage =  Image.FromFile(RutaDisplayRed + "0.gif");
            }
            if (menos == 31)
            {
                Rojo1.BackgroundImage =  Image.FromFile(RutaDisplayRed + "3.gif");
                Rojo2.BackgroundImage =  Image.FromFile(RutaDisplayRed + "1.gif");
            }
            if (menos == 32)
            {
                Rojo1.BackgroundImage =  Image.FromFile(RutaDisplayRed + "3.gif");
                Rojo2.BackgroundImage =  Image.FromFile(RutaDisplayRed + "2.gif");
            }
            if (menos == 33)
            {
                Rojo1.BackgroundImage =  Image.FromFile(RutaDisplayRed + "3.gif");
                Rojo2.BackgroundImage =  Image.FromFile(RutaDisplayRed + "3.gif");
            }
            if (menos == 34)
            {
                Rojo1.BackgroundImage =  Image.FromFile(RutaDisplayRed + "3.gif");
                Rojo2.BackgroundImage =  Image.FromFile(RutaDisplayRed + "4.gif");
            }
            if (menos == 35)
            {
                Rojo1.BackgroundImage =  Image.FromFile(RutaDisplayRed + "3.gif");
                Rojo2.BackgroundImage =  Image.FromFile(RutaDisplayRed + "5.gif");
            }
            if (menos == 36)
            {
                Rojo1.BackgroundImage =  Image.FromFile(RutaDisplayRed + "3.gif");
                Rojo2.BackgroundImage =  Image.FromFile(RutaDisplayRed + "6.gif");
            }
            if (menos == 37)
            {
                Rojo1.BackgroundImage =  Image.FromFile(RutaDisplayRed + "3.gif");
                Rojo2.BackgroundImage =  Image.FromFile(RutaDisplayRed + "7.gif");
            }
            if (menos == 38)
            {
                Rojo1.BackgroundImage =  Image.FromFile(RutaDisplayRed + "3.gif");
                Rojo2.BackgroundImage =  Image.FromFile(RutaDisplayRed + "8.gif");
            }
            if (menos == 39)
            {
                Rojo1.BackgroundImage =  Image.FromFile(RutaDisplayRed + "3.gif");
                Rojo2.BackgroundImage =  Image.FromFile(RutaDisplayRed + "9.gif");
            }
            if (menos == 40)
            {
                Rojo1.BackgroundImage =  Image.FromFile(RutaDisplayRed + "4.gif");
                Rojo2.BackgroundImage =  Image.FromFile(RutaDisplayRed + "0.gif");
            }
            if (menos == 41)
            {
                Rojo1.BackgroundImage =  Image.FromFile(RutaDisplayRed + "4.gif");
                Rojo2.BackgroundImage =  Image.FromFile(RutaDisplayRed + "1.gif");
            }
            if (menos == 42)
            {
                Rojo1.BackgroundImage =  Image.FromFile(RutaDisplayRed + "4.gif");
                Rojo2.BackgroundImage =  Image.FromFile(RutaDisplayRed + "2.gif");
            }
            if (menos == 43)
            {
                Rojo1.BackgroundImage =  Image.FromFile(RutaDisplayRed + "4.gif");
                Rojo2.BackgroundImage =  Image.FromFile(RutaDisplayRed + "3.gif");
            }
            if (menos == 44)
            {
                Rojo1.BackgroundImage =  Image.FromFile(RutaDisplayRed + "4.gif");
                Rojo2.BackgroundImage =  Image.FromFile(RutaDisplayRed + "4.gif");
            }
            if (menos == 45)
            {
                Rojo1.BackgroundImage =  Image.FromFile(RutaDisplayRed + "4.gif");
                Rojo2.BackgroundImage =  Image.FromFile(RutaDisplayRed + "5.gif");
            }
            if (menos == 46)
            {
                Rojo1.BackgroundImage =  Image.FromFile(RutaDisplayRed + "4.gif");
                Rojo2.BackgroundImage =  Image.FromFile(RutaDisplayRed + "6.gif");
            }
            if (menos == 47)
            {
                Rojo1.BackgroundImage =  Image.FromFile(RutaDisplayRed + "4.gif");
                Rojo2.BackgroundImage =  Image.FromFile(RutaDisplayRed + "7.gif");
            }
            if (menos == 48)
            {
                Rojo1.BackgroundImage =  Image.FromFile(RutaDisplayRed + "4.gif");
                Rojo2.BackgroundImage =  Image.FromFile(RutaDisplayRed + "8.gif");
            }
            if (menos == 49)
            {
                Rojo1.BackgroundImage =  Image.FromFile(RutaDisplayRed + "4.gif");
                Rojo2.BackgroundImage =  Image.FromFile(RutaDisplayRed + "9.gif");
            }
            if (menos == 50)
            {
                Rojo1.BackgroundImage =  Image.FromFile(RutaDisplayRed + "5.gif");
                Rojo2.BackgroundImage =  Image.FromFile(RutaDisplayRed + "0.gif");
            }
            else
            {
                //Si hay mas de 50 canciones que no haga nada
            }
        }
        void ContadordecancionesVerde()
        {
            if (ListaReproduccion.SelectedIndex == 0)//Si tira error borrar este if
            {
                Verde1.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "0.gif");
                Verde2.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "0.gif");
            }
            if (ListaReproduccion.SelectedIndex == 1)//Si el indice es = x,entonces que el display es  = x
            {
                Verde1.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "0.gif");
                Verde2.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "1.gif");
            }
            if (ListaReproduccion.SelectedIndex == 2)
            {
                Verde1.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "0.gif");
                Verde2.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "2.gif");
            }
            if (ListaReproduccion.SelectedIndex == 3)
            {
                Verde1.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "0.gif");
                Verde2.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "3.gif");
            }
            if (ListaReproduccion.SelectedIndex == 4)
            {
                Verde1.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "0.gif");
                Verde2.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "4.gif");
            }
            if (ListaReproduccion.SelectedIndex == 5)
            {
                Verde1.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "0.gif");
                Verde2.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "5.gif");
            }
            if (ListaReproduccion.SelectedIndex == 6)
            {
                Verde1.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "0.gif");
                Verde2.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "6.gif");
            }
            if (ListaReproduccion.SelectedIndex == 7)
            {
                Verde1.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "0.gif");
                Verde2.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "7.gif");
            }
            if (ListaReproduccion.SelectedIndex == 8)
            {
                Verde1.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "0.gif");
                Verde2.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "8.gif");
            }
            if (ListaReproduccion.SelectedIndex == 9)
            {
                Verde1.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "0.gif");
                Verde2.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "9.gif");
            }
            //Se comienzan a utilizar los dos display
            if (ListaReproduccion.SelectedIndex == 10)
            {
                Verde1.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "1.gif");
                Verde2.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "0.gif");
            }
            if (ListaReproduccion.SelectedIndex == 11)
            {
                Verde1.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "1.gif");
                Verde2.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "1.gif");
            }
            if (ListaReproduccion.SelectedIndex == 12)
            {
                Verde1.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "1.gif");
                Verde2.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "2.gif");
            }
            if (ListaReproduccion.SelectedIndex == 13)
            {
                Verde1.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "1.gif");
                Verde2.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "3.gif");
            }
            if (ListaReproduccion.SelectedIndex == 14)
            {
                Verde1.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "1.gif");
                Verde2.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "4.gif");
            }
            if (ListaReproduccion.SelectedIndex == 15)
            {
                Verde1.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "1.gif");
                Verde2.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "5.gif");
            }
            if (ListaReproduccion.SelectedIndex == 16)
            {
                Verde1.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "1.gif");
                Verde2.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "6.gif");
            }
            if (ListaReproduccion.SelectedIndex == 17)
            {
                Verde1.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "1.gif");
                Verde2.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "7.gif");
            }
            if (ListaReproduccion.SelectedIndex == 18)
            {
                Verde1.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "1.gif");
                Verde2.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "8.gif");
            }
            if (ListaReproduccion.SelectedIndex == 19)
            {
                Verde1.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "1.gif");
                Verde2.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "9.gif");
            }
            if (ListaReproduccion.SelectedIndex == 20)
            {
                Verde1.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "2.gif");
                Verde2.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "0.gif");
            }
            if (ListaReproduccion.SelectedIndex == 21)
            {
                Verde1.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "2.gif");
                Verde2.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "1.gif");
            }
            if (ListaReproduccion.SelectedIndex == 22)
            {
                Verde1.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "2.gif");
                Verde2.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "2.gif");
            }
            if (ListaReproduccion.SelectedIndex == 23)
            {
                Verde1.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "2.gif");
                Verde2.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "3.gif");
            }
            if (ListaReproduccion.SelectedIndex == 24)
            {
                Verde1.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "2.gif");
                Verde2.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "4.gif");
            }
            if (ListaReproduccion.SelectedIndex == 25)
            {
                Verde1.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "2.gif");
                Verde2.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "5.gif");
            }
            if (ListaReproduccion.SelectedIndex == 26)
            {
                Verde1.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "2.gif");
                Verde2.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "6.gif");
            }
            if (ListaReproduccion.SelectedIndex == 27)
            {
                Verde1.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "2.gif");
                Verde2.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "7.gif");
            }
            if (ListaReproduccion.SelectedIndex == 28)
            {
                Verde1.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "2.gif");
                Verde2.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "8.gif");
            }
            if (ListaReproduccion.SelectedIndex == 29)
            {
                Verde1.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "2.gif");
                Verde2.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "9.gif");
            }
            if (ListaReproduccion.SelectedIndex == 30)
            {
                Verde1.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "3.gif");
                Verde2.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "0.gif");
            }
            if (ListaReproduccion.SelectedIndex == 31)
            {
                Verde1.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "3.gif");
                Verde2.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "1.gif");
            }
            if (ListaReproduccion.SelectedIndex == 32)
            {
                Verde1.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "3.gif");
                Verde2.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "2.gif");
            }
            if (ListaReproduccion.SelectedIndex == 33)
            {
                Verde1.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "3.gif");
                Verde2.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "3.gif");
            }
            if (ListaReproduccion.SelectedIndex == 34)
            {
                Verde1.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "3.gif");
                Verde2.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "4.gif");
            }
            if (ListaReproduccion.SelectedIndex == 35)
            {
                Verde1.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "3.gif");
                Verde2.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "5.gif");
            }
            if (ListaReproduccion.SelectedIndex == 36)
            {
                Verde1.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "3.gif");
                Verde2.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "6.gif");
            }
            if (ListaReproduccion.SelectedIndex == 37)
            {
                Verde1.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "3.gif");
                Verde2.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "7.gif");
            }
            if (ListaReproduccion.SelectedIndex == 38)
            {
                Verde1.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "3.gif");
                Verde2.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "8.gif");
            }
            if (ListaReproduccion.SelectedIndex == 39)
            {
                Verde1.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "3.gif");
                Verde2.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "9.gif");
            }
            if (ListaReproduccion.SelectedIndex == 40)
            {
                Verde1.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "4.gif");
                Verde2.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "0.gif");
            }
            if (ListaReproduccion.SelectedIndex == 41)
            {
                Verde1.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "4.gif");
                Verde2.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "1.gif");
            }
            if (ListaReproduccion.SelectedIndex == 42)
            {
                Verde1.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "4.gif");
                Verde2.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "2.gif");
            }
            if (ListaReproduccion.SelectedIndex == 43)
            {
                Verde1.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "4.gif");
                Verde2.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "3.gif");
            }
            if (ListaReproduccion.SelectedIndex == 44)
            {
                Verde1.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "4.gif");
                Verde2.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "4.gif");
            }
            if (ListaReproduccion.SelectedIndex == 45)
            {
                Verde1.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "4.gif");
                Verde2.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "5.gif");
            }
            if (ListaReproduccion.SelectedIndex == 46)
            {
                Verde1.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "4.gif");
                Verde2.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "6.gif");
            }
            if (ListaReproduccion.SelectedIndex == 47)
            {
                Verde1.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "4.gif");
                Verde2.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "7.gif");
            }
            if (ListaReproduccion.SelectedIndex == 48)
            {
                Verde1.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "4.gif");
                Verde2.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "8.gif");
            }
            if (ListaReproduccion.SelectedIndex == 49)
            {
                Verde1.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "4.gif");
                Verde2.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "9.gif");
            }
            if (ListaReproduccion.SelectedIndex == 50)
            {
                Verde1.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "5.gif");
                Verde2.BackgroundImage =  Image.FromFile(RutaDisplayGreen + "0.gif");
            }
            else
            {
                //Que no pase nada y muestre doble cero
               //Se viene directo aqui si se agregan imagenes
            }

        }
#endregion Contadores Display

#region Boton de YouTube
        private void btnYoutube_Click(object sender, EventArgs e)
        {
            btnExpandir.Visible = true;
            YoutubeMini();
            ListaActual.WebBrowserShortcutsEnabled = true;//Desplazamiento con las teclas
        }
        private void btnConfig_Click(object sender, EventArgs e)
        {

        }
        private void YoutubeMaxi()
        {
            ListaActual.Visible = false;
            this.ListaActual.Width = 1579;
            this.ListaActual.Height = 527;
            ListaActual.Location = new Point(0, 107);
            ListaActual.Visible = true;
        }
        private void YoutubeMini()
        {
            ListaActual.Visible = false;
            this.ListaActual.Width = 330;
            this.ListaActual.Height = 500;
            this.ListaActual.Location = new Point(1590, 98);
            ListaActual.Visible = true;
        }
        private void btnExpandir_Click(object sender, EventArgs e)
        {
            if (contExpan == 1)
            {
                contExpan = 2;
                YoutubeMaxi();
            }
            else if (contExpan == 2)
            {
                contExpan = 1;
                YoutubeMini();
            }
        }


        #endregion Boton de YouTube
        
    }
    #endregion Principal
}