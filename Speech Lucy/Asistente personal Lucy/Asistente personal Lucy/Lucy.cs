using System;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Collections;
using System.IO;
using System.Media;
using System.Runtime.InteropServices;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Threading;
using WindowsInput;
using Microsoft.Win32;

namespace Asistente_personal_Lucy
{
    #region Principal
    public partial class Asistente_virtual : Form
    {
        #region Declaraciones Universales
        
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
       
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        [DllImport("shell32")]
        private static extern void SHEmptyRecycleBin(int hwnd, string pszRootPath, int dwFlags);
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);
        enum ModificadordeTecla
        {
            None = 0,
            Alt = 1,
            Control = 2,
            Shift = 4,
            WinKey = 8
        }

        //Resolucion de Pantalla
        private int CamAncho = 1920, CamAlto = 1080;//Es la resolucion que se desea cambiar por default

        String Estado;
        int Respuesta = 1; int Voz = 1; int Off = 2; int audiolevel; int KeyVoz = 1; int Encima = 1; int config = 1;
        string palabra; string nombre; string Usuario; string User; string Password; string SaveColor;
        string Silencio = "•••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••••";
        string RutaRecursos = "C:\\Speech Lucy\\Asistente personal Lucy\\Asistente personal Lucy\\bin\\Debug\\Recursos\\";
        string RutaAplicaciones = "C:\\Speech Lucy\\";
        string RutaProgramasX86 = "C:\\Program Files (x86)\\";
        string RutaProgramas = "C:\\Program Files\\";
        string RutaMusica = "D:\\MuSiK\\Listas\\";
        string RutaSystem32 = "C:\\Windows\\System32\\";
        string ErrorArduino = "El comando no pudo ser enviado,por favor verifica el numero del puerto serial y vuelve a intentarlo";
        bool Permiso = false;//Siempre en false
        DispatcherTimer Tiempo1; DispatcherTimer Tiempo2; 
        DispatcherTimer Tiempo3; DispatcherTimer Tiempo4;
        DispatcherTimer TIntro2;
        SpeechRecognitionEngine Detectar = new SpeechRecognitionEngine();
        SpeechSynthesizer Lucy = new SpeechSynthesizer();
        Comandos_Arduino Comandos = new Comandos_Arduino();
        Intro intro2 = new Intro();

        #endregion Declaraciones Universales

        #region Main Load

        public Asistente_virtual()
        {
            InitializeComponent();
            tiempointro2();
            LoadIntro();
            int id = 0;     //Es la id de la tecla
            RegisterHotKey(this.Handle, id, (int)ModificadordeTecla.Shift, Keys.L.GetHashCode());//Si se presionan las teclas Shift + A hace algo (Muestra un · Mensaje mas abajo ·)  
            Thread Hilo1 = new Thread(LoadImagenes);//Subproceso para cargar las imagenes del formulario
            Hilo1.Start();
            StreamReader leernombre = new StreamReader(RutaRecursos + "NombreUser.txt");
            nombre = leernombre.ReadToEnd(); leernombre.Close(); Usuario = nombre;
        }
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == 0x0312)
            {
                //------------------Que active o desactive a lucy----------------------
                if (KeyVoz == 1) { Voz = 2; KeyVoz = 2; Tono_de_Inicio T1 = new Tono_de_Inicio(); T1.TonodeInicio(); }//Cuando se activa reproduce un sonido en segundo plano
                else if (KeyVoz == 2) { Voz = 1; KeyVoz = 1; Tono_de_Inicio T1 = new Tono_de_Inicio(); T1.TonodeCierre(); }
            }
        }
        private void Asistente_virtual_Load(object sender, EventArgs e)
        {
            Off = 1; cargarGramaticas(); Flecha.Text = ">";
            tiempoimagen(); tiempoimagen2(); tiempoimagen3(); tiempohablarlargo(); 
            label5.Visible = true;//                                                                                0: Parpedeo Largo                                                        
        }
        private void LoadImagenes()
        {
            StreamReader leerColor = new StreamReader(RutaRecursos + "Tema.txt");
            string Colores = leerColor.ReadLine(); leerColor.Close();
            if (Colores == "Negro")
            {
                ColorNegro();
            }
            if (Colores == "Azul")
            {
                ColorAzul();
            }
            if (Colores == "Verde")
            {
                ColorVerde();
            }
            if (Colores == "Naranja")
            {
                ColorNaranja();
            }
            if (Colores == "Indigo")
            {
                ColorIndigo();
            }
            if (Colores == "Glass")
            {
                ColorGlass();
            } 
        }
        private void LoadIntro()
        {
            intro2.Show();
            if (intro2.Visible == true)
            {
                TIntro2.Start();  
            }
            else {}
        }
      
        #endregion Main Load

        #region Gramatica
        private void cargarGramaticas()
        {
            Detectar.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(File.ReadAllLines(RutaRecursos + "Comandos.txt")))));
            //Detectar.LoadGrammarAsync(new DictationGrammar());//Gramatica predeterminada del equipo
            Detectar.RequestRecognizerUpdate();
            Lucy.SpeakCompleted += Lucy_SpeakCompleted;
            Detectar.AudioLevelUpdated += Detectar_AudioLevelUpdated;
            Detectar.SpeechRecognized += Detectar_SpeechRecognized;//Palabras
            Detectar.SetInputToDefaultAudioDevice();
            Detectar.RecognizeAsync(RecognizeMode.Multiple);
        }
        #endregion Gramatica

        #region Botones Comunes y Animaciones
              //Para mostrar las opciones cuando se pasa el mouse
        private void labelmostrar_MouseEnter(object sender, EventArgs e)
        {
            if (config == 1)
            {
                config = 2;
                button1.Visible = true;
                button2.Visible = true;
            }
            else if (config == 2)
            {
                config = 1;
                button1.Visible = false;
                button2.Visible = false;
            }
        }  
                    //Altavoz para cerrar a Lucy rapido
        private void button3_Click(object sender, EventArgs e)
        {Notificacion.Visible = false; Application.Exit();}
                  //Para mover el formulario libremente
        private void labelmostrar_MouseDown(object sender, MouseEventArgs e)
        { ReleaseCapture(); SendMessage(this.Handle, 0x112, 0xf012, 0); }
                      //Boton para ocultar a Lucy
        private void Flecha_Click(object sender, EventArgs e)
        {if (Flecha.Text == ">") {  this.Width = 215; this.Height = 154; Flecha.Text = "<"; }//Reducir form
        else if (Flecha.Text == "<") { this.Width = 412; this.Height = 154; Flecha.Text = ">"; }}                    
                       //Para vaciar la papelera
        private void VaciarPapelera(string Unidad, bool Dialogo_Confirmar)
        {int vaciar = 0;vaciar = 1;SHEmptyRecycleBin(0, Unidad, vaciar);}
                        //Boton 'siempre encima'
        private void button5_Click(object sender, EventArgs e)
        {
            if (Encima == 1)
            {
                Encima = 2; TopMost = true;
            }
            else if (Encima == 2)
            {
                Encima = 1; TopMost = false;
            }
        }    
 
                     //Animacion de barra de escucha
        void Detectar_AudioLevelUpdated(object sender, AudioLevelUpdatedEventArgs e)
        {
         audiolevel = e.AudioLevel;
         progressBar1.Value = audiolevel;
        }
                         //Boton para reiniciar
        private void Reiniciar_Click(object sender, EventArgs e)
        {System.Windows.Forms.Application.Restart();}
                   //Proceso de la alarma en segundo plano
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {System.Diagnostics.Process.Start(@"C:\Speech Lucy\Alarma\Alarma\bin\Debug\Alarma.exe");}
                //Proceso de leer anotaciones en segundo plano
        private void AnotacionesSP_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                Lucy.SpeakAsync("Nota 1"); StreamReader leerbloc1 = new StreamReader(@"C:\Speech Lucy\Notasrapidas\Notasrapidas\bin\Debug\Anotaciones\Anotaciones 1.txt");
                string Anotaciones = leerbloc1.ReadToEnd(); Lucy.SpeakAsync(Anotaciones); leerbloc1.Close(); Lucy.SpeakAsync("Nota 2");
                StreamReader leerbloc2 = new StreamReader(@"C:\Speech Lucy\Notasrapidas\Notasrapidas\bin\Debug\Anotaciones\Anotaciones 2.txt");
                string Anotaciones2 = leerbloc2.ReadToEnd(); Lucy.SpeakAsync(Anotaciones2); leerbloc2.Close(); Lucy.SpeakAsync("Nota 3");
                StreamReader leerbloc3 = new StreamReader(@"C:\Speech Lucy\Notasrapidas\Notasrapidas\bin\Debug\Anotaciones\Anotaciones 3.txt");
                string Anotaciones3 = leerbloc3.ReadToEnd(); Lucy.SpeakAsync(Anotaciones3); leerbloc3.Close(); Lucy.SpeakAsync("Nota 4");
                StreamReader leerbloc4 = new StreamReader(@"C:\Speech Lucy\Notasrapidas\Notasrapidas\bin\Debug\Anotaciones\Anotaciones 4.txt");
                string Anotaciones4 = leerbloc4.ReadToEnd(); Lucy.Speak(Anotaciones4 + ".."); leerbloc4.Close();
            }
            catch (Exception Ex)
            { Lucy.SpeakAsync("Lo siento pero no encuentro la ruta o el archivo de notas rapidas" + ".."); MessageBox.Show(Ex + ""); } ConstantedeTiempo(); Off = 1;
        }
                       //Boton de ayuda en la Web
        private void button2_Click(object sender, EventArgs e)
        {
            try{
                Ayuda f = new Ayuda();
                f.ShowDialog();
                if (f.DialogResult == DialogResult.Yes){}Lucy.SpeakAsync("Abriendo la sección de ayuda");
                Lucy.SpeakAsync("Para mejorar el reconocimiento y la interpretacion de palabras,sigue los siguientes pasos");
                System.Diagnostics.Process.Start(RutaRecursos + "Ayuda.htm");
                  }
            catch (Exception EX)
                {MessageBox.Show(EX + "");}
        }

        #endregion Botones Comunes y Animaciones

        #region Temas
        
        private void button4_Click(object sender, EventArgs e)
        {listTemas.Visible = true;}
            //Guarda el Tema seleccionado del listBox
        private void listTemas_SelectedIndexChanged(object sender, EventArgs e)
        {   
            if ((string)listTemas.SelectedItem == "Negro")
            {
                SaveColor = "Negro";
                SaveTema();
            }
            else if ((string)listTemas.SelectedItem == "Azul")
            {
                SaveColor = "Azul";
                SaveTema();
            }
            else if ((string)listTemas.SelectedItem == "Verde")
            {
                SaveColor = "Verde";
                SaveTema();
            }
            else if ((string)listTemas.SelectedItem == "Naranja")
            {
                SaveColor = "Naranja";
                SaveTema(); 
            }
            else if ((string)listTemas.SelectedItem == "Indigo")
            {
                SaveColor = "Indigo";
                SaveTema(); 
            }
            else if ((string)listTemas.SelectedItem == "Glass")
            {
                SaveColor = "Glass";
                SaveTema();
            }
        }
        private void SaveTema()
        {
            StreamWriter file = new StreamWriter(@"C:\Speech Lucy\Asistente personal Lucy\Asistente personal Lucy\bin\Debug\Recursos\Tema.txt");
            file.WriteLine(SaveColor); file.Close();
            if (SaveColor == "Negro")
            {
                ColorNegro();
            }
            else if (SaveColor == "Azul")
            {
                ColorAzul();
            }
            else if (SaveColor == "Verde")
            {
                ColorVerde();
            }
            else if (SaveColor == "Naranja")
            {
                ColorNaranja();
            }
            else if (SaveColor == "Indigo")
            {
                ColorIndigo();
            }
            else if (SaveColor == "Glass")
            {
                ColorGlass();
            }
        }

        private void ColorNegro()
        {
            this.BackColor = Color.Black;
            OcultarTemas();
            txbname.BackColor = Color.Black;
            Flecha.BackColor = Color.Black;
        }
        private void ColorAzul()
        {
            this.BackColor = Color.Teal; OcultarTemas();
        }
        private void ColorVerde()
        {
            this.BackColor = Color.Green; OcultarTemas();
        }
        private void ColorNaranja()
        {
            this.BackColor = Color.Orange; OcultarTemas();
        }
        private void ColorIndigo()
        {
            this.BackColor = Color.Indigo; OcultarTemas();
        }
        private void ColorGlass()
        {
            this.BackColor = Color.DimGray; OcultarTemas();
            txbname.BackColor = Color.DimGray;
            Flecha.BackColor = Color.DimGray;
        }
        private void OcultarTemas()
        {
            listTemas.Visible = false; 
        }

        #endregion Temas

        #region Iconos de notificacion
        //Determina el estado del Form y muestra una notificacion
        private void button1_Click(object sender, EventArgs e)
        {this.WindowState = FormWindowState.Minimized;}
    
        #endregion Iconos de notificacion

        #region Nombre de usuario
        //Guarda el nombre de usuario en un Bloc
        private void txbname_TextChanged(object sender, EventArgs e)
        {
            string escribiruser = txbname.Text; StreamWriter file = new StreamWriter(RutaRecursos + "NombreUser.txt");
        file.WriteLine(escribiruser); file.Close();}
        #endregion Nombre de usuario

        #region Activar/Desactivar escucha
                                                         //Activa ó Desactiva la escucha de Lucy
        void Lucy_SpeakCompleted(object sender, SpeakCompletedEventArgs e) 
        {
            if (Off == 1)//Aqui se apaga y deja de escuchar
            {
                Voz = 1;
            }
            else
            Voz = 2;
        }//Si se invierten los valores se desactiva completamente
        #endregion Activar/Desactivar escucha

        #region Tiempos de actualizacion
        //Intervalos de tiempo entre cada imagen a mostrar
        void tiempoimagen()
        {Tiempo1 = new DispatcherTimer();Tiempo1.Interval = new TimeSpan(0, 0, 1);Tiempo1.Tick += Tiempo1_Tick;}
        void tiempoimagen2()
        {Tiempo2 = new DispatcherTimer();Tiempo2.Interval = new TimeSpan(0, 0, 8);Tiempo2.Tick += Tiempo2_Tick;}
        void tiempoimagen3()
        {Tiempo3 = new DispatcherTimer();Tiempo3.Interval = new TimeSpan(0, 0, 13);Tiempo3.Tick += Tiempo3_Tick;}//                                                                                             4: Parpadeo largo infinito
        void tiempohablarlargo()
        {Tiempo4 = new DispatcherTimer(); Tiempo4.Interval = new TimeSpan(0, 0, 2); Tiempo4.Tick += Tiempo4_Tick;}//                                                                                         5: Frases cortas
        void Tiempo1_Tick(object sender, EventArgs e)//                                                                       1: Estatica
        {label7.Visible = false;label5.Visible = false;label8.Visible = true;Tiempo1.Stop();}
        void Tiempo2_Tick(object sender, EventArgs e)//                                                                       2: Parpadeo Corto
        {label8.Visible = false;label5.Visible = true;Tiempo2.Stop();}
        void Tiempo3_Tick(object sender, EventArgs e)//                                                                       3: Parpadeo Largo
        {label5.Visible = true;label8.Visible = false;Tiempo3.Stop();}
        void Tiempo4_Tick(object sender, EventArgs e)//                                                                       4: Tiempo de intro
        { label7.Visible = false; label5.Visible = true; label8.Visible = false; Tiempo4.Stop(); Escucha.Visible = false; }
        void tiempointro2()
        {TIntro2 = new DispatcherTimer(); TIntro2.Interval = new TimeSpan(0, 0, 5); TIntro2.Tick += TIntro_Tick;}
        void TIntro_Tick(object sender, EventArgs e)
        {
            intro2.Close();
            TIntro2.Stop();
            this.Opacity = 100;
            this.WindowState = FormWindowState.Normal;
        }
       
        #endregion Tiempos de actualizacion

        #region Cambio de Resolucion

       
        private void CambioResolucion()
        {Resolution.CResolution Cambiar = new Resolution.CResolution(CamAncho,CamAlto);}

        #endregion Cambio de Resolucion

        #region Comandos de activacion
        void Detectar_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            
            palabra = e.Result.Text;
            switch (palabra)
            {
                case "Hola Lucy":  Off = 2; Constantes(); Lucy.Resume();
                     if (Respuesta == 1) { txbname.Text = nombre; Lucy.SpeakAsync("Hola" + nombre + Silencio); ConstantedeTiempo(); Respuesta = 2; }
                     else if (Respuesta == 2) { Lucy.SpeakAsync("Dime" + Silencio); ConstantedeTiempo(); Respuesta = 1; }
                     break;
                case "Suspender": Voz = 1; Notificacion.Visible = true; Notificacion.Icon = SystemIcons.Shield; Notificacion.BalloonTipText = "Para Activar diga: 'Hola Lucy'";
                     Notificacion.BalloonTipTitle = "Suspendido"; Notificacion.ShowBalloonTip(5); labelmostrar.Text = "Suspendido";Lucy.Pause();Respuesta = 2;
                     //Detectar.Dispose();//---------------------------------Apaga el microfono
                      Off = 1;   
                      break;
                case "Lucy": //Detectar.EndSilenceTimeout = new TimeSpan(0,0,5);//Ejecuta el comando despues de que pasan 5 segundos
                      Off = 2; Constantes(); Lucy.Resume(); 
                      if (Respuesta == 1) { Respuesta = 2; Lucy.SpeakAsync("Dime" + Silencio); ConstantedeTiempo(); }
                      else if (Respuesta == 2) { Respuesta = 1; Lucy.SpeakAsync("En que te puedo ayudar" + Silencio); Tiempo4.Start(); }
                      break;
            }
            #endregion Comandos de activacion
    
            //Cuando termina de leer el valor es : 2
            if (Voz == 2)
            {
                switch (palabra)
                {

        #region Operaciones Basicas
                    case "Operaciones basicas": Off = 1; labelmostrar.Text = palabra;
                        try
                        {
                            Calculos test6 = new Calculos();test6.ShowDialog();
                            if (test6.DialogResult == DialogResult.Yes)
                            {
                                StreamReader leer1 = new StreamReader(RutaRecursos + "Suma.txt");
                                string suma = leer1.ReadToEnd(); leer1.Close();
                                if (suma != "")
                                { Lucy.SpeakAsync("La suma es: " + suma + Silencio);  }
                            }
                            else if (test6.DialogResult == DialogResult.No)
                            {
                                StreamReader leer6 = new StreamReader(RutaRecursos + "Multiplicacion.txt");
                                string multiplicacion = leer6.ReadToEnd(); leer6.Close();
                                if (multiplicacion != "")
                                { Lucy.SpeakAsync("La multiplicacion es: " + multiplicacion + Silencio); }
                            }
                            else if (test6.DialogResult == DialogResult.Retry)
                            {
                                StreamReader leer2 = new StreamReader(RutaRecursos + "Resta 1.txt");
                                string resta1 = leer2.ReadToEnd(); leer2.Close();
                                StreamReader leer3 = new StreamReader(RutaRecursos + "Resta 2.txt");
                                string resta2 = leer3.ReadToEnd(); leer3.Close();
                                if (resta1 != "" || resta2 != "")
                                { Lucy.SpeakAsync("La primera resta es: " + resta1 + "la segunda resta es: " + resta2 + Silencio);  }
                            }
                            else if (test6.DialogResult == DialogResult.Cancel)
                            {
                                StreamReader leer4 = new StreamReader(RutaRecursos + "Division 1.txt");
                                string division1 = leer4.ReadToEnd(); leer4.Close();
                                StreamReader leer5 = new StreamReader(RutaRecursos + "Division 2.txt");
                                string division2 = leer5.ReadToEnd(); leer5.Close();
                                if (division1 != "" || division2 != "")
                                { Lucy.SpeakAsync("La primera division es: " + division1 + "la segunda division es: " + division2 + Silencio); }
                            }
                            else if (test6.DialogResult == DialogResult.Ignore)
                            {
                                StreamReader leer7 = new StreamReader(RutaRecursos + "Raiz1.txt");
                                string raiz1 = leer7.ReadToEnd(); leer7.Close();
                                StreamReader leer8 = new StreamReader(RutaRecursos + "Raiz2.txt");
                                string raiz2 = leer8.ReadToEnd(); leer8.Close();
                                if (raiz1 != "")
                                { Lucy.SpeakAsync("La raiz cuadrada del primer numero es: " + raiz1 + Silencio);  }
                                if (raiz2 != "")
                                { Lucy.SpeakAsync("La raiz cuadrada del segundo numero es: " + raiz2 + Silencio); }
                            }
                        }
                        catch (Exception Ex) { MessageBox.Show(Ex.Message + "No se puede iniciar la aplicacion de: Calculos"); }
                        ConstantedeTiempo();
                        break;
                    #endregion Operaciones Basicas
       
        #region Comandos Arduino Bluetooth

                    case "Enciende las luces": Off = 1; 
                        labelmostrar.Text = palabra;
                        Comandos.AbrirPuerto(); 
                        Comandos.Comando1(); 
                        Estado = Comandos.Estadodeenvio;
                        Comandos.CerrarPuerto();
                        if (Estado.Contains("Encendido"))
                            Lucy.SpeakAsync("El estado de las luces es :" + Estado + Silencio);
                        else if (Estado.Contains("Error"))
                            Lucy.SpeakAsync(ErrorArduino + Silencio);
                            break;
                    case "Enciende las luces dos": Off = 1; labelmostrar.Text = palabra; Comandos.AbrirPuerto(); Comandos.Comando2(); Estado = Comandos.Estadodeenvio; Comandos.CerrarPuerto();
                        if (Estado.Contains("Encendido"))
                            Lucy.SpeakAsync("El estado de las luces es :" + Estado + Silencio);
                        else if (Estado.Contains("Error"))
                            Lucy.SpeakAsync(ErrorArduino + Silencio);
                           break;
                    case "Enciende las luces tres": Off = 1; labelmostrar.Text = palabra; Comandos.AbrirPuerto(); Comandos.Comando3(); Estado = Comandos.Estadodeenvio; Comandos.CerrarPuerto();
                        if (Estado.Contains("Encendido"))
                            Lucy.SpeakAsync("El estado de las luces es :" + Estado + Silencio);
                        else if (Estado.Contains("Error"))
                            Lucy.SpeakAsync(ErrorArduino + Silencio);
                         break;
                    case "Enciende las luces cuatro": Off = 1; labelmostrar.Text = palabra; Comandos.AbrirPuerto(); Comandos.Comando4(); Estado = Comandos.Estadodeenvio; Comandos.CerrarPuerto();
                        if (Estado.Contains("Encendido"))
                            Lucy.SpeakAsync("El estado de las luces es :" + Estado + Silencio);
                        else if (Estado.Contains("Error"))
                            Lucy.SpeakAsync(ErrorArduino + Silencio);
                         break;
                    case "Apaga las luces": Off = 1; labelmostrar.Text = palabra; Comandos.AbrirPuerto(); Comandos.Comando1(); Estado = Comandos.Estadodeenvio; Comandos.CerrarPuerto();
                        if (Estado.Contains("Apagado"))
                            Lucy.SpeakAsync("El estado de las luces es :" + Estado + Silencio);
                        else if (Estado.Contains("Error"))
                            Lucy.SpeakAsync(ErrorArduino + Silencio);
                         break;
                    case "Apaga las luces dos": Off = 1; labelmostrar.Text = palabra; Comandos.AbrirPuerto(); Comandos.Comando2(); Estado = Comandos.Estadodeenvio; Comandos.CerrarPuerto();
                        if (Estado.Contains("Apagado"))
                            Lucy.SpeakAsync("El estado de las luces es :" + Estado + Silencio);
                        else if (Estado.Contains("Error"))
                            Lucy.SpeakAsync(ErrorArduino + Silencio);
                         break;
                    case "Apaga las luces tres": Off = 1; labelmostrar.Text = palabra; Comandos.AbrirPuerto(); Comandos.Comando3(); Estado = Comandos.Estadodeenvio; Comandos.CerrarPuerto();
                        if (Estado.Contains("Apagado"))
                            Lucy.SpeakAsync("El estado de las luces es :" + Estado + Silencio);
                        else if (Estado.Contains("Error"))
                            Lucy.SpeakAsync(ErrorArduino + Silencio);
                         break;
                    case "Apaga las luces cuatro": Off = 1; labelmostrar.Text = palabra; Comandos.AbrirPuerto(); Comandos.Comando4(); Estado = Comandos.Estadodeenvio; Comandos.CerrarPuerto();
                        if (Estado.Contains("Apagado"))
                            Lucy.SpeakAsync("El estado de las luces es :" + Estado + Silencio);
                        else if (Estado.Contains("Error"))
                            Lucy.SpeakAsync(ErrorArduino + Silencio);
                         break;
                    case "Apaga todas las luces": Off = 1; labelmostrar.Text = palabra; Comandos.AbrirPuerto(); Comandos.Comando8(); Estado = Comandos.Estadodeenvio; Comandos.CerrarPuerto();
                        if (Estado.Contains("Apagado"))
                            Lucy.SpeakAsync("El estado de las luces es :" + Estado + Silencio);
                        else if (Estado.Contains("Error"))
                            Lucy.SpeakAsync(ErrorArduino + Silencio);
                         break;
                    

        #endregion Comandos Arduino Bluetooth

        #region Comandos comunes
                    case "Dime la informacion del equipo": Off = 1; Constantes(); Lucy.SpeakAsync("Okey" + Silencio); ConstantedeTiempo();
                        string info = SystemInformation.PowerStatus.PowerLineStatus.ToString();
                        String ruta = "HARDWARE\\DESCRIPTION\\System\\CentralProcessor\\0";
                        RegistryKey key = Registry.LocalMachine.OpenSubKey(ruta);
                        String procesador = key.GetValue("ProcessorNameString").ToString();
                        Lucy.SpeakAsync("El cable de alimentación esta " + info + ",actualmente no esta disponible la informacion de la batería" + Silencio);
                        Lucy.SpeakAsync("El tipo de procesador es un : " + procesador + Silencio);
                        /*string info2 = SystemInformation.PowerStatus.BatteryLifePercent.ToString();MessageBox.Show(info2);//Lo que queda de carga
                        string info3 = SystemInformation.PowerStatus.BatteryChargeStatus.ToString();MessageBox.Show(info3);//Porcentaje cargado
                        string info4 = SystemInformation.UserName;MessageBox.Show(info4);//Nombre de usuario actual*/
                         break;
                    case "Cambia el tema a alto contraste":Off = 1;Constantes(); Lucy.SpeakAsync("Okey"); ConstantedeTiempo(); 
                        button6.Image = button6.BackgroundImage;button2.Image = button2.BackgroundImage;Reiniciar.Image = Reiniciar.BackgroundImage;
                         break;
                    case "Sabes cual es mi nombre":Off = 1;  Lucy.SpeakAsync("si, tu nombre es " + Usuario + ", no creo que se me valla olvidar"); Constantes(); ConstantedeTiempo();   
                         break;
                    case "Recuerdas mi nombre":Off = 1;  Lucy.SpeakAsync("Claro, te llamas" + Usuario); Constantes(); ConstantedeTiempo();  
                         break;
                    case "Desactiva el pasword":Off = 1;  Permiso = true; Lucy.SpeakAsync("Claro, la contraseña a sido desactivada"); 
                         break;
                    case "Cierrate":Off = 1;  Constantes(); Lucy.Speak("Espero haberte servido,hasta luego"); Close(); 
                         break;
                    case "Administrador de tareas":Constantes(); System.Diagnostics.Process.Start(RutaSystem32 + "Taskmgr.exe");   
                         Voz =1;   break;
                    case "Buscar aplicaciones":Constantes();   System.Diagnostics.Process.Start(@"shell:::{2559a1f8-21d7-11d4-bdaf-00c04f60b9f0}"); 
                         Voz = 1;   break;
                    case "Reiniciar":Off = 1;  Constantes(); Lucy.Speak("Reiniciando la aplicación"); Application.Restart(); 
                         break;
                    case "Escritorio":Off = 1;  Constantes(); Lucy.SpeakAsync("Okey" + Silencio);//-------------------------------------------------------------------------------------------------------------------------------
                        string mesc = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);System.Diagnostics.Process.Start(mesc);
                        ConstantedeTiempo();  
                         break;
                    case "Documentos":Off = 1; Constantes(); Lucy.SpeakAsync("listo" + Silencio);  //------------------------------------------------------------------------------------------------------------------------
                        string mdoc = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                        System.Diagnostics.Process.Start(mdoc);ConstantedeTiempo();
                         break;
                    case "Calendario":Off = 1;  Constantes(); Lucy.SpeakAsync("Okey" + Silencio);  
                        System.Diagnostics.Process.Start(@"C:\Speech Lucy\CalendarioLucy\CalendarioLucy\bin\Debug\CalendarioLucy.exe");
                          ConstantedeTiempo();  
                         break;
                    case "Alarma":Off = 1;  Constantes(); Lucy.SpeakAsync("listo" + Silencio); AlarmaSP.RunWorkerAsync();  
                          ConstantedeTiempo(); 
                         break;
                    case "Dime la hora": Off = 1; Constantes(); Lucy.SpeakAsync(DateTime.Now.ToString("t")); ConstantedeTiempo();   
                         break;
                    case "Que hora es": Off = 1; Constantes(); Lucy.SpeakAsync((DateTime.Now.ToString("t"))); ConstantedeTiempo();   
                         break;
                    case "Dime la fecha": Off = 1; Constantes(); Lucy.SpeakAsync((DateTime.Now.ToString("M"))); ConstantedeTiempo();   
                         break;
                    case "Que dia es": Off = 1; Constantes(); Lucy.SpeakAsync((DateTime.Now.ToString("M"))); ConstantedeTiempo();   
                         break;
                    case "Quien te creo y que eres": Off = 1; Constantes(); Lucy.SpeakAsync("Víctor Pisiotti" + Silencio);  
                          Lucy.SpeakAsync("Soy una inteligencia articifial,todabía estoy en fase BETA"+ Silencio); ConstantedeTiempo();  
                         break;
                    case "No me interesas": Off = 1; Constantes(); Lucy.SpeakAsync("Oye calmate,mejor trata de solucionar tú problema" + Silencio); ConstantedeTiempo();  
                         break;
                    case "Como te llamas": Off = 1; Constantes(); Lucy.SpeakAsync("Me llamo lucy,soy una asistente personal virtual,diseñada para realizar mucho mas eficiente ciertas tareas en tu computador" + Silencio);  
                          ConstantedeTiempo();  
                         break;
                    case "Cuentame un chiste": Off = 1; Constantes(); Lucy.SpeakAsync("Mamá, ¿qué haces en frente de la computadora con los ojos cerrados?" + Silencio);  
                        Lucy.SpeakAsync("Nada hijo, es que Windows me dijo que cerrara las pestañas"+ Silencio);   ConstantedeTiempo();  
                         break;
                    case "Laboratorio": Off = 1; Constantes(); Lucy.SpeakAsync("Okey");  
                        try
                        { System.Diagnostics.Process.Start(@"C:\Users\victor\Documents\Laboratorio"); ConstantedeTiempo();  }
                        catch (Exception Ex){MessageBox.Show(Ex.Message + "\nNo existe la carpeta o el directorio");}
                         break;
                    case "Carpeta de usuario": Off = 1; Constantes(); Lucy.SpeakAsync("Okey" + Silencio);  
                        string muser = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);System.Diagnostics.Process.Start(muser);  
                        ConstantedeTiempo(); 
                         break;
                    case "Imagenes": Off = 1; Constantes(); Lucy.SpeakAsync("enseguida" + Silencio);  
                        string mima = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);System.Diagnostics.Process.Start(mima);  
                        ConstantedeTiempo(); 
                         break;
                    case "Mi equipo": Off = 1; Constantes(); Lucy.SpeakAsync("Okey" + Silencio); System.Diagnostics.Process.Start(@"::{20D04FE0-3AEA-1069-A2D8-08002B30309D}");  
                          ConstantedeTiempo(); 
                         break;
                    case "Coleccion": Off = 1; Constantes(); Lucy.SpeakAsync("listo" + Silencio);  
                        //string mmus = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
                        //System.Diagnostics.Process.Start(mmus);
                        try { System.Diagnostics.Process.Start(@"D:\MuSiK"); ConstantedeTiempo();}
                        catch (Exception Ex){MessageBox.Show(Ex.Message + "\nNo existe la carpeta o el directorio");}   
                         break;
                    case "Programas": Off = 1; Constantes(); Lucy.SpeakAsync("enseguida" + Silencio);   
                        string mpro = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86 | Environment.SpecialFolder.ProgramFiles); System.Diagnostics.Process.Start(mpro);
                          ConstantedeTiempo(); 
                         break;
                    case "Abre mis Archivos": Off = 1; Constantes(); Lucy.SpeakAsync("Okey" + Silencio);  
                        try { System.Diagnostics.Process.Start(@"D:\"); ConstantedeTiempo();  }
                        catch (Exception Ex){MessageBox.Show(Ex.Message + "\nNo existe el archivo o el directorio");}
                         break;
                    case "Panel de control": Off = 1; Constantes(); Lucy.SpeakAsync("listo" + Silencio);
                        System.Diagnostics.Process.Start(RutaSystem32 + "control.exe");  
                        ConstantedeTiempo(); 
                         break;
                    case "Calculadora": Off = 1; Constantes(); Lucy.SpeakAsync("Okey" + Silencio);
                        System.Diagnostics.Process.Start(RutaSystem32 + "calc.exe");  
                        ConstantedeTiempo(); 
                         break;
                    case "Mai peint": Off = 1; Constantes(); Lucy.SpeakAsync("Okey" + Silencio);
                        Lucy.Speak("Puedes utilizar comandos de voz para maipeint" + Silencio);
                        try { System.Diagnostics.Process.Start(RutaProgramas + "MyPaint\\mypaint.exe"); ConstantedeTiempo();  }
                        catch (Exception Ex)
                        { Lucy.SpeakAsync("Lo siento pero no tienes este programa instalado en el equipo" + Silencio); MessageBox.Show(Ex.Message); }
                         break;
                    case "Terminal": Off = 1; Constantes(); Lucy.SpeakAsync("Okey" + Silencio);
                        System.Diagnostics.Process.Start(RutaSystem32 + "cmd.exe");  
                        ConstantedeTiempo(); 
                         break;
                    case "Bloc de notas": Off = 1; Constantes(); Lucy.SpeakAsync("bueno" + Silencio);  
                        try
                        { System.Diagnostics.Process.Start(RutaSystem32 + "notepad.exe"); ConstantedeTiempo(); }
                        catch (Exception Ex){MessageBox.Show(Ex.Message + "\n\n\tNo se puede abrir la aplicacion");}
                         break;
                    case "Control de volumen": Off = 1; Constantes(); Lucy.SpeakAsync("Okey" + Silencio);  
                        System.Diagnostics.Process.Start(RutaSystem32 + "SndVol.exe");  ConstantedeTiempo();
                         break;
                    case "Nitro PDF": Off = 1; Constantes(); Lucy.SpeakAsync("listo" + Silencio);  
                        try { System.Diagnostics.Process.Start(RutaProgramasX86 + "Nitro\\Pro 9\\NitroPDF.exe"); ConstantedeTiempo(); }
                        catch (Exception Ex) { Lucy.SpeakAsync("Lo siento pero no tienes este programa instalado en el equipo" + Silencio); MessageBox.Show(Ex.Message); }
                         break;
                    case "Reproductor": Off = 1; Constantes(); Lucy.SpeakAsync("Okey" + Silencio);
                        try{System.Diagnostics.Process.Start(RutaAplicaciones + "\\Reproductor Compacto\\Reproductor Compacto\\bin\\Debug\\Reproductor Compacto.exe");}
                        catch (Exception Ex)
                        {Lucy.SpeakAsync("Lo siento pero no tienes este programa instalado en el equipo" + Silencio); MessageBox.Show(Ex.Message);}
                        ConstantedeTiempo();
                         break;
                    case "Abre monect": Off = 1; Constantes(); Lucy.SpeakAsync("bueno" + Silencio);  
                        try { System.Diagnostics.Process.Start(RutaProgramasX86 + "MonectHost\\MonectHost.exe"); ConstantedeTiempo();  }
                        catch (Exception Ex) { Lucy.SpeakAsync("Lo siento pero no tienes este programa instalado en el equipo" + Silencio); MessageBox.Show(Ex.Message); }
                         Off = 1;   break;
                    case "Photoshop": Constantes(); Lucy.SpeakAsync("enseguida" + Silencio);  
                        try { System.Diagnostics.Process.Start(RutaProgramasX86 + "Photoshop Cs6\\PSCS6.exe"); ConstantedeTiempo();  }
                        catch (Exception Ex) { Lucy.SpeakAsync("Lo siento pero no tienes este programa instalado en el equipo" + Silencio); MessageBox.Show(Ex.Message); } 
                         break;
                    case "Maxthon": Off = 1; Constantes();
                        try { System.Diagnostics.Process.Start(RutaProgramasX86 + "Maxthon\\Bin\\Maxthon.exe"); ConstantedeTiempo();  }
                        catch (Exception Ex) { Lucy.SpeakAsync("Lo siento pero no tienes este programa instalado en el equipo" + Silencio); MessageBox.Show(Ex.Message); }
                         break;
                    case "Modo lectura": System.Windows.Forms.SendKeys.SendWait("^(l)"); Voz = 1;
                         break;
                    case "Cambiar pestaña": System.Windows.Forms.SendKeys.SendWait("^{TAB}"); Voz = 1;
                         break;
                    case "Power point": Off = 1; Detectar.SpeechRecognized += Detectar_SpeechRecognizedPP;//Palabras Power Point
                        Constantes(); Lucy.SpeakAsync("bueno" + Silencio);  
                        try { System.Diagnostics.Process.Start(RutaProgramasX86 + "Microsoft Office\\Office15\\POWERPNT.exe"); }
                        catch (Exception Ex) { Lucy.SpeakAsync("Lo siento pero no tienes este programa instalado en el equipo" + Silencio); MessageBox.Show(Ex.Message); }
                         break;
                    case "*Abre word": Off = 1; Detectar.SpeechRecognized += Detectar_SpeechRecognizedword;//Palabras de Word
                        Constantes(); Lucy.SpeakAsync("Okey" + Silencio);  
                        Lucy.SpeakAsync("Puedes utilizar comandos de voz para Word");
                        try { System.Diagnostics.Process.Start(RutaProgramasX86 + "Microsoft Office\\Office15\\WINWORD.exe"); ConstantedeTiempo(); }
                        catch (Exception Ex) { Lucy.SpeakAsync("Lo siento pero no tienes este programa instalado en el equipo"); MessageBox.Show(Ex.Message); }
                         break;
                    case "Abre excel": Off = 1; Detectar.SpeechRecognized += Detectar_SpeechRecognizedExcel;//Palabras Excel
                        Constantes(); Lucy.SpeakAsync("listo" + Silencio);  
                        try { System.Diagnostics.Process.Start(RutaProgramasX86 + "Microsoft Office\\Office15\\EXCEL.exe"); ConstantedeTiempo();  }
                        catch (Exception Ex) { Lucy.SpeakAsync("Lo siento pero no tienes este programa instalado en el equipo" + Silencio); MessageBox.Show(Ex.Message); }
                         break;
                    case "Vacia la papelera": Off = 1; Lucy.SpeakAsync("Listo" + Silencio); VaciarPapelera("c:\\", true); Off = 1;
                         break;
                    case "Cerrar": Constantes(); System.Windows.Forms.SendKeys.SendWait("%{F4}"); Voz = 1;
                         break;
                    case "Cerrar aplicacion": Constantes(); System.Windows.Forms.SendKeys.SendWait("%{F4}"); Voz = 1;
                         break;
                    case "Cierra eso": Constantes(); System.Windows.Forms.SendKeys.SendWait("%{F4}"); Voz = 1;
                         break;
                    case "Cerrar ventana": Constantes(); System.Windows.Forms.SendKeys.SendWait("%{F4}"); Voz = 1;
                        break;
                    case "Que puedo decir": Off = 1; Constantes(); Lucy.SpeakAsync("Estos son algunos de los comandos que puedes usar" + "..");
                          System.Diagnostics.Process.Start(RutaRecursos + "Que puedo decir.txt");
                          ConstantedeTiempo(); 
                            break; 


                    case "Cambiar":  Constantes();  // "%{TAB}" o "^{TAB}" o "{TAB}"
                         System.Windows.Forms.SendKeys.SendWait("%{TAB}"); 
                         Voz = 1; 
                         break;

                    case "Dispositivos": Constantes(); 
                         System.Diagnostics.Process.Start(@"C:\Users\Default\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\System Tools\Devices.lnk"); Voz = 1;
                         break;
                    case "Informacion del sistema": Constantes();
                         System.Diagnostics.Process.Start(@"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\Administrative Tools\System Information.lnk"); Voz = 1;
                         break;
                    case "Renombrar": Constantes(); System.Windows.Forms.SendKeys.SendWait("{F2}"); Voz = 1;
                         break;
                    case "Buscar": Constantes(); System.Diagnostics.Process.Start(@"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\Search.lnk"); Voz = 1;
                         break;
                    case "Copiar": Constantes(); System.Windows.Forms.SendKeys.SendWait("^(c)"); Voz = 1;
                         break;
                    case "Copia eso": Constantes(); System.Windows.Forms.SendKeys.SendWait("^(c)"); Voz = 1;
                         break;
                    case "Pegar": Constantes(); System.Windows.Forms.SendKeys.SendWait("^(v)"); Voz = 1;
                         break;
                    case "Cortar": Constantes(); System.Windows.Forms.SendKeys.SendWait("^(x)"); Voz = 1;
                         break;
                    case "Iniciar dictado": Off = 1; Constantes(); Lucy.Speak("Okey" + Silencio); ConstantedeTiempo();
                         try { Dictado test = new Dictado(); test.ShowDialog(); Voz = 1; if (test.DialogResult == DialogResult.Yes) { Voz = 1; } }
                         catch (Exception Ex) { Lucy.SpeakAsync("Lo siento pero no puedo abrir iniciar la aplicacion de dictado" + Silencio); MessageBox.Show(Ex.Message); }
                            break;
                    case "Menu de aplicaciones": Off = 1; Constantes(); Lucy.Speak("Okey" + Silencio); ConstantedeTiempo();
                        try
                        {
                            Menu_aplicaciones f2 = new Menu_aplicaciones(); f2.ShowDialog(); 
                            if (f2.DialogResult == DialogResult.Yes)//btnWord
                            {
                                Detectar.SpeechRecognized += Detectar_SpeechRecognizedword;//Palabras de Word
                                Lucy.SpeakAsync("Puedes utilizar comandos de voz para Word" + Silencio);
                                try { System.Diagnostics.Process.Start(RutaProgramasX86 + "Microsoft Office\\Office15\\WINWORD.exe");  }
                                catch (Exception Ex) { Lucy.SpeakAsync("Lo siento pero no tienes este programa instalado en el equipo" + Silencio); MessageBox.Show(Ex.Message); }
                            }
                            if (f2.DialogResult == DialogResult.No)//Coleccion Musical
                            {
                                
                                Musica f1 = new Musica(); f1.ShowDialog(); ;
                            }
                            if (f2.DialogResult == DialogResult.OK)//btnPhotoshop
                            {
                                Detectar.SpeechRecognized += Detectar_SpeechRecognizedPhoto;
                                Lucy.SpeakAsync("Puedes utilizar comandos de voz para fotoshop" + Silencio);
                                try { System.Diagnostics.Process.Start(RutaProgramasX86 + "Photoshop Cs6\\PSCS6.exe");  }
                                catch (Exception Ex) { Lucy.SpeakAsync("Lo siento pero no tienes este programa instalado en el equipo" + Silencio); MessageBox.Show(Ex.Message); }
                            }
                            if (f2.DialogResult == DialogResult.Retry)//My Paint
                            {
                                Detectar.SpeechRecognized += Detectar_SpeechRecognizedmypanit;
                                Lucy.SpeakAsync("Puedes utilizar comandos de voz para maipeint" + Silencio);
                                try { System.Diagnostics.Process.Start(RutaProgramas + "MyPaint\\mypaint.exe"); }
                                catch (Exception Ex) { Lucy.SpeakAsync("Lo siento pero no tienes este programa instalado en el equipo" + Silencio); MessageBox.Show(Ex.Message); }
                            }
                            if (f2.DialogResult == DialogResult.Ignore)//Excel
                            {
                                Detectar.SpeechRecognized += Detectar_SpeechRecognizedExcel;
                                Lucy.SpeakAsync("Puedes utilizar comandos de voz para Excel" + Silencio);
                                try { System.Diagnostics.Process.Start(RutaProgramasX86 + "Microsoft Office\\Office15\\EXCEL.exe");; }
                                catch (Exception Ex) { Lucy.SpeakAsync("Lo siento pero no tienes este programa instalado en el equipo" + Silencio); MessageBox.Show(Ex.Message); }
                            }
                            if (f2.DialogResult == DialogResult.Abort)//Power Point
                            {
                                Detectar.SpeechRecognized += Detectar_SpeechRecognizedPP;
                                Lucy.SpeakAsync("Puedes utilizar comandos de voz para pauer point" + Silencio);
                                try { System.Diagnostics.Process.Start(RutaProgramasX86 + "Microsoft Office\\Office15\\POWERPNT.exe"); }
                                catch (Exception Ex) { Lucy.SpeakAsync("Lo siento pero no tienes este programa instalado en el equipo" + Silencio); MessageBox.Show(Ex.Message); }
                            }
                        }
                        catch (Exception Ex) { Lucy.SpeakAsync("Lo siento pero no puedo abrir el menu de aplicaciones" + Silencio); MessageBox.Show(Ex.Message); }
                        break;
                    case "Coleccion musical": Off = 1;
                        if (Permiso == true)
                        {
                            Voz = 1;
                            CambioResolucion();//Se cambia la resolucion
                            Thread.Sleep(2000); 
                            ColeccionMusical(); 
                        }
                        else if (Permiso == false)
                        {
                            Lucy.SpeakAsync("por favor ingresa tu clave de acceso" + Silencio);
                            try
                            {
                                Login f4 = new Login(); f4.ShowDialog();
                                if (f4.DialogResult == DialogResult.OK)
                                {
                                    {
                                        Confirmacion();
                                        if ("Pisciotti" == User && "123" == Password)
                                        {
                                            Voz = 1;
                                            CambioResolucion();//Se cambia la resolucion
                                            Thread.Sleep(2000);
                                            ColeccionMusical(); 
                                        }
                                    }
                                }
                                if (f4.DialogResult == DialogResult.Yes)
                                {
                                    Lucy.SpeakAsync("El nombre de usuario ó la contraseña no son correctos" + Silencio);
                                }
                            }
                            catch (Exception Ex)
                            {
                                Lucy.SpeakAsync("Lo siento pero no puedo abrir tu coleccion de musica" + Silencio); MessageBox.Show(Ex.Message);
                            }  
                        }
                         break;
                    case "Ciencias": Off = 1; Constantes(); Lucy.SpeakAsync("listo" + Silencio); ConstantedeTiempo();
                        System.Diagnostics.Process.Start(@"C:\Speech Lucy\Ciencias\Ciencias\bin\Debug\Ciencias.exe");
                         break;
                    case "Abrir Notas": Off = 1; Constantes(); Lucy.SpeakAsync("enseguida" + Silencio); ConstantedeTiempo();
                        System.Diagnostics.Process.Start(@"C:\Speech Lucy\Notasrapidas\Notasrapidas\bin\Debug\Notasrapidas.exe");
                         break;
                    case "Leer anotaciones": Off = 1; AnotacionesSP.RunWorkerAsync();
                         break;
                    case "Lee esto": Off = 1; Constantes(); Lucy.SpeakAsync("Okey" + Silencio); System.Windows.Forms.SendKeys.SendWait("^(c)");
                        if (Clipboard.ContainsText()) { string copia; copia = Clipboard.GetText(); Lucy.SpeakAsync(copia + Silencio); }
                        else { MessageBox.Show("Por favor seleccione una cadena de texto para poder leer"); }
                         break;
            #endregion Comandos comunes

        #region Comandos de musica
                    case "Play music Nach": Constantes(); labelmostrar.Text = "Nach";  
                        try
                        {System.Diagnostics.Process.Start(RutaMusica + "Nach Scratch.wpl");}
                        catch (Exception Ex){Lucy.SpeakAsync("No se encuentra la ruta o el directorio del archivo");MessageBox.Show(Ex.Message);}
                         Voz =1; break;
                    case "Play music morodo":  Constantes(); labelmostrar.Text = "Morodo";  
                        try
                        {System.Diagnostics.Process.Start(RutaMusica + "Morodo.wpl");}
                        catch (Exception Ex) { Lucy.SpeakAsync("No se encuentra la ruta o el directorio del archivo"); MessageBox.Show(Ex.Message); }
                         Voz =1; break;
                    case "Play music parmor": Constantes(); labelmostrar.Text = "Paramore";  
                        try
                        { System.Diagnostics.Process.Start(RutaMusica + "Paramore.wpl"); }
                        catch (Exception Ex) { Lucy.SpeakAsync("No se encuentra la ruta o el directorio del archivo"); MessageBox.Show(Ex.Message); }
                         Voz =1;   break;
                    case "Play music zona ganjah": Constantes();     labelmostrar.Text = "Zona Ganjah";  
                        try
                        {System.Diagnostics.Process.Start(RutaMusica + "Zona Ganjah.wpl");}
                        catch (Exception Ex)
                        { Lucy.SpeakAsync("No se encuentra la ruta o el directorio del archivo"); MessageBox.Show(Ex.Message); }
                         Voz =1;   break;
                    case "Play music regue": Constantes();     labelmostrar.Text = "Reggae";  
                        try
                        {System.Diagnostics.Process.Start(RutaMusica + "Reggae.wpl");}
                        catch (Exception Ex)
                        { Lucy.SpeakAsync("No se encuentra la ruta o el directorio del archivo"); MessageBox.Show(Ex.Message); }
                         Voz =1; break;
                    case "Play music arenbi":  Constantes(); labelmostrar.Text = "R & B";  
                        try
                        {System.Diagnostics.Process.Start(RutaMusica + "R & B.wpl");}
                        catch (Exception Ex)
                        { Lucy.SpeakAsync("No se encuentra la ruta o el directorio del archivo"); MessageBox.Show(Ex.Message); }
                         Voz =1;   break;
                    case "Play music treysong": Constantes(); labelmostrar.Text = "Trey songz";  
                        try
                        { System.Diagnostics.Process.Start(RutaMusica + "Trey Songz.wpl"); }
                        catch (Exception Ex)
                        { Lucy.SpeakAsync("No se encuentra la ruta o el directorio del archivo"); MessageBox.Show(Ex.Message); }
                         Voz =1;   break;
                    case "Play music canserbero": Constantes();     labelmostrar.Text = "Canserbero";  
                        try
                        { System.Diagnostics.Process.Start(RutaMusica + "Canserbero.wpl"); }
                        catch (Exception Ex)
                        { Lucy.SpeakAsync("No se encuentra la ruta o el directorio del archivo"); MessageBox.Show(Ex.Message); } 
                         Voz =1; break;
                    case "Play music bob Marly": Constantes(); labelmostrar.Text = "Bob Marley";  
                        try
                        { System.Diagnostics.Process.Start(RutaMusica + "Bob Marley.wpl"); }
                        catch (Exception Ex)
                        { Lucy.SpeakAsync("No se encuentra la ruta o el directorio del archivo"); MessageBox.Show(Ex.Message); }
                         Voz =1;  break;
                    case "Play music jipjap": Constantes(); labelmostrar.Text = "Hip Hop";  
                        try
                        { System.Diagnostics.Process.Start(RutaMusica + "Hip Hop.wpl"); }
                        catch (Exception Ex)
                        { Lucy.SpeakAsync("No se encuentra la ruta o el directorio del archivo"); MessageBox.Show(Ex.Message); }
                         Voz =1;  break;
                    case "Play music barrington Levy": Constantes();     labelmostrar.Text = "Barrington Levy";  
                        try
                        { System.Diagnostics.Process.Start(RutaMusica + "Barrington Levy.wpl"); }
                        catch (Exception Ex)
                        { Lucy.SpeakAsync("No se encuentra la ruta o el directorio del archivo"); MessageBox.Show(Ex.Message); }
                         Voz =1;  break;
                    case "Play music los aldeanos": Constantes();     labelmostrar.Text = "Los Aldeanos";  
                        try
                        { System.Diagnostics.Process.Start(RutaMusica + "Los Aldeanos.wpl"); }
                        catch (Exception Ex)
                        { Lucy.SpeakAsync("No se encuentra la ruta o el directorio del archivo"); MessageBox.Show(Ex.Message); }
                        Voz =1; break;
                    case "Play music cultura profetica": Constantes();     labelmostrar.Text = "Cultura Profetica";  
                        try
                        { System.Diagnostics.Process.Start(RutaMusica + "Cultura Profetica.wpl"); }
                        catch (Exception Ex)
                        { Lucy.SpeakAsync("No se encuentra la ruta o el directorio del archivo"); MessageBox.Show(Ex.Message); }
                        Voz =1;   break;
                    case "Play music tempo": Constantes();     labelmostrar.Text = "Tempo";  
                        try
                        { System.Diagnostics.Process.Start(RutaMusica + "Tempo.wpl"); }
                        catch (Exception Ex)
                        { Lucy.SpeakAsync("No se encuentra la ruta o el directorio del archivo"); MessageBox.Show(Ex.Message); }
                         Voz =1;  break;
                    case "Play music doble v": Constantes();     labelmostrar.Text = "Doble V";  
                        try
                        { System.Diagnostics.Process.Start(RutaMusica + "Doble V.wpl"); }
                        catch (Exception Ex)
                        { Lucy.SpeakAsync("No se encuentra la ruta o el directorio del archivo"); MessageBox.Show(Ex.Message); }
                         Voz =1;   break;
                    case "Play music tres coronas": Constantes();     labelmostrar.Text = "Tres Coronas";  
                        try
                        { System.Diagnostics.Process.Start(RutaMusica + "Tres Coronas.wpl"); }
                        catch (Exception Ex) { Lucy.SpeakAsync("No se encuentra la ruta o el directorio del archivo"); MessageBox.Show(Ex.Message); }
                         Voz =1;  break;
                    #endregion Comandos de musica

        #region Comandos Web
                    case "Facebook": Off = 1; Constantes(); Lucy.SpeakAsync("Abriendo féisbuk" + Silencio);    
                        System.Diagnostics.Process.Start(@"https://www.facebook.com/"); ConstantedeTiempo();
                         break;
                    case "Youtube": Off = 1; Constantes(); Lucy.SpeakAsync("Abriendo iutub" + Silencio);  
                        try{System.Diagnostics.Process.Start(@"C:\Speech Lucy\Youtube\Youtube\bin\Debug\Youtube.exe");  ConstantedeTiempo();}
                        catch (Exception Ex)
                        {MessageBox.Show(Ex.Message + "No se puede abrir la aplicacion");
                        Lucy.SpeakAsync("Lo siento pero no puedo abrir la aplicacion de iutub,por favor intentalo mas tarde" + Silencio);
                        }
                         break;
                    case "Amazon": Off = 1; Constantes(); Lucy.SpeakAsync("Abriendo Amazon" + Silencio); System.Diagnostics.Process.Start(@"http://www.amazon.com/"); ConstantedeTiempo(); 
                         break;
                    case "Abre Google": Off = 1; Constantes(); Lucy.SpeakAsync("Abriendo gúgol" + Silencio); System.Diagnostics.Process.Start(@"https://www.google.com.co/");
                          ConstantedeTiempo(); 
                         break;
                    case "Revisa mis correos": Off = 1;
                        if (Permiso == true)
                        {
                            Correo(); 
                        }
                        else if (Permiso == false)
                        {
                            Lucy.SpeakAsync("por favor ingresa tu clave de acceso" + Silencio);
                            try
                            {
                                Login f5 = new Login(); f5.ShowDialog();
                                if (f5.DialogResult == DialogResult.OK)
                                {
                                    {
                                        Confirmacion();
                                        if ("Pisciotti" == User && "123" == Password)
                                        {
                                            Correo(); 
                                        }
                                    }
                                }
                                if (f5.DialogResult == DialogResult.Yes) { Lucy.SpeakAsync("El nombre de usuario ó la contraseña no son correctos" + Silencio); }
                            }
                            catch (Exception Ex) { Lucy.SpeakAsync("Lo siento pero no puedo abrir tus correos,intentalo mas tarde" + Silencio); MessageBox.Show(Ex.Message); }   
                        }
                         break;
                    case "Abre los correos personales": Off = 1;
                        if (Permiso == true)
                        {
                            CorreosPersonales();
                        }
                        else if (Permiso == false)
                        {
                            Lucy.SpeakAsync("por favor ingresa tu clave de acceso" + Silencio);
                            try
                            {
                                Login f6 = new Login(); f6.ShowDialog();
                                if (f6.DialogResult == DialogResult.OK)
                                {
                                    {
                                        Confirmacion();
                                        if ("Pisciotti" == User && "123" == Password)
                                        {
                                            CorreosPersonales(); 
                                        }
                                    }
                                }
                                if (f6.DialogResult == DialogResult.Yes) { Lucy.SpeakAsync("El nombre de usuario ó la contraseña no son correctos" + Silencio); }
                            }
                            catch (Exception Ex) { Lucy.SpeakAsync("Lo siento pero no puedo abrir tus correos,intentalo mas tarde" + Silencio); MessageBox.Show(Ex.Message); }
                        }
                         break;
                    case "Elimina todos los correos": Off = 1; Lucy.SpeakAsync("Okey,todos los correos han sido eliminados" + Silencio);  
                        string archivo1 = RutaRecursos + "Asunto 1.txt";
                        string archivo2 = RutaRecursos + "Asunto 2.txt";
                        string archivo3 = RutaRecursos + "Asunto 3.txt";
                        string archivo4 = RutaRecursos + "Asunto 4.txt";
                        string archivo5 = RutaRecursos + "Eventos Calendario.txt";
                        try{if (File.Exists(archivo1)){File.Delete(archivo1);}using (FileStream a1 = File.Create(archivo1)){}}
                        catch (Exception Ex){MessageBox.Show(Ex.ToString());}
                        try{if (File.Exists(archivo2)){File.Delete(archivo2);}using (FileStream a2 = File.Create(archivo2)){}}
                        catch (Exception Ex){MessageBox.Show(Ex.ToString());}
                        try{if (File.Exists(archivo3)){File.Delete(archivo3);}using (FileStream a3 = File.Create(archivo3)){}}
                        catch (Exception Ex){MessageBox.Show(Ex.ToString());}
                        try{if (File.Exists(archivo4)){File.Delete(archivo4);}using (FileStream a4 = File.Create(archivo4)){}}
                        catch (Exception Ex){MessageBox.Show(Ex.ToString());}
                        try{if (File.Exists(archivo5)){File.Delete(archivo5);}using (FileStream a5 = File.Create(archivo5)){}}
                        catch (Exception Ex){MessageBox.Show(Ex.Message);} ConstantedeTiempo();
                         break;
                    case "No los deseo eliminar": Off = 1; Constantes(); txbname.Text = nombre; Lucy.SpeakAsync("Okey, como tu quieras " + nombre + Silencio); ConstantedeTiempo(); 
                         break;
                    case "Busqueda por voz": Off = 1; Constantes();Lucy.SpeakAsync("Dime que deseas que busque en la ueb" + Silencio);ConstantedeTiempo();
                          try { BusquedaGoogle test3 = new BusquedaGoogle(); test3.ShowDialog(); if (test3.DialogResult == DialogResult.Yes) { Voz = 1; } }
                          catch (Exception Ex) { MessageBox.Show(Ex.Message + "No se puede iniciar la aplicacion de Busqueda por voz"); }
                          break;
                    #endregion Comandos Web

        #region Minimizar/Ocultar/Restaurar
                    case "Ocultar": Constantes();   this.Show(); this.WindowState = FormWindowState.Normal; Notificacion.Visible = true;
                        if (this.WindowState == FormWindowState.Normal){this.Visible = false;Notificacion.Visible = true;} 
                         Off = 1;   break;
                    case "Minimizar": Constantes(); this.WindowState = FormWindowState.Minimized;   
                         Off = 1;   break;
                    case "Restaurar": Constantes(); this.Show(); this.WindowState = FormWindowState.Normal; Notificacion.Visible = false; 
                         Off = 1;   break;
                    #endregion Minimizar/Ocultar/Restaurar

        #region Comando de Apagado
                    case "Cierra todo y apaga el equipo": Off = 1; Constantes(); labelmostrar.Text = "Apagar";  
                        Lucy.SpeakAsync("Okey,Confirma que deseas apagar el equipo"+ Silencio); DialogResult opcion = MessageBox.Show("Realmente desea apagar el equipo?", "Salir y Apagar", MessageBoxButtons.YesNoCancel);
                        if (opcion == DialogResult.Yes) { Lucy.Speak("Finalizando procesos del sistema,hasta luego" + Silencio); System.Diagnostics.Process.Start("shutdown", " /s /t 0"); }
                        else if (opcion == DialogResult.No) { Lucy.SpeakAsync("Me alegra poder seguir trabajando contigo" + Silencio); }
                        else if (opcion == DialogResult.Cancel) { Application.Restart(); }ConstantedeTiempo();
                         break;
                    #endregion Comando de Apagado

        #region Comandos WMP
                    case "Pausar cancion":  Constantes(); InputSimulator.SimulateKeyPress(VirtualKeyCode.MEDIA_PLAY_PAUSE);    
                         Voz = 1;break;
                    case "Reanudar cancion": Constantes(); InputSimulator.SimulateKeyPress(VirtualKeyCode.MEDIA_PLAY_PAUSE);    
                         Voz = 1;break;
                    case "Siguiente cancion": Constantes(); InputSimulator.SimulateKeyPress(VirtualKeyCode.MEDIA_NEXT_TRACK);    
                         Voz = 1;break;
                    case "Cancion anterior": Constantes(); InputSimulator.SimulateKeyPress(VirtualKeyCode.MEDIA_PREV_TRACK);    
                       Voz = 1;   break;
                    case "Reproduccion aleatoria": Constantes(); System.Windows.Forms.SendKeys.SendWait("^(h)");    
                         Voz = 1;  break;
                    case "Repetir": Constantes(); System.Windows.Forms.SendKeys.SendWait("^(y)");    
                         Voz = 1;  break;
                    case "Silenciar": Constantes(); InputSimulator.SimulateKeyPress(VirtualKeyCode.VOLUME_MUTE);    
                        Voz = 1;   break;
                    case "Mostrar album": Constantes(); System.Windows.Forms.SendKeys.SendWait("^(3)");    
                         Voz = 1;  break;
                    case "Modo normal": Constantes(); System.Windows.Forms.SendKeys.SendWait("^(1)");    
                         Voz = 1;   break;
                    case "Subir volumen": Constantes(); InputSimulator.SimulateKeyPress(VirtualKeyCode.VOLUME_UP);    
                         Voz = 1;   break;
                    case "Bajar volumen": Constantes(); InputSimulator.SimulateKeyPress(VirtualKeyCode.VOLUME_DOWN);    
                         Voz = 1;   break;
                }
            }
        }
                    #endregion Comandos WMP

        #region Correos & Constantes

        private void Correo()
        {
            Constantes(); Lucy.SpeakAsync("Abriendo tus correos personales" + Silencio);      
            //Confirma y Lee los asuntos que hay en un bloc de notas que se actualiza cada 1 minutos
            StreamReader leercorreo1 = new StreamReader(RutaRecursos + "Asunto 1.txt");
            string asunto1 = leercorreo1.ReadToEnd(); leercorreo1.Close();
            StreamReader leercorreo2 = new StreamReader(RutaRecursos + "Asunto 2.txt");
            string asunto2 = leercorreo2.ReadToEnd(); leercorreo2.Close();
            StreamReader leercorreo3 = new StreamReader(RutaRecursos + "Asunto 3.txt");
            string asunto3 = leercorreo3.ReadToEnd(); leercorreo3.Close();
            StreamReader leercorreo4 = new StreamReader(RutaRecursos + "Asunto 4.txt");
            string asunto4 = leercorreo4.ReadToEnd(); leercorreo4.Close();
            StreamReader leerEventos = new StreamReader(RutaRecursos + "Eventos Calendario.txt");
            string calendario = leerEventos.ReadToEnd(); leerEventos.Close();
            if (asunto1 == "" && asunto2 == "" && asunto3 == "" && asunto4 == "")
            { Lucy.SpeakAsync("Por ahora,No tienes nuevos correos" + Silencio); } if (asunto1 != "" || asunto2 != "" || asunto3 != "" || asunto4 != "")
            { Lucy.SpeakAsync("Tienes correos de, " + asunto1 + asunto2 + asunto3 + asunto4 + ",ya no tienes mas correos en tu bandeja de entrada" + Silencio); }
            if (calendario != "") { Lucy.SpeakAsync("Tienes nuevos eventos en tu " + calendario + Silencio); }
            if (calendario == "") { Lucy.SpeakAsync("No tienes nuevos eventos en tu calendario" + Silencio); }
            if (asunto1 != "" || asunto2 != "" || asunto3 != "" || asunto4 != "")
            { Lucy.SpeakAsync("¿Deseas eliminar los correos leidos?" + Silencio); } ConstantedeTiempo(); 
        }
        private void CorreosPersonales()
        {
            Constantes(); Lucy.SpeakAsync("Espera abro tus correos" + Silencio);  
            System.Diagnostics.Process.Start(@"C:\Speech Lucy\CorreoOutLook\CorreoOutLook\bin\Debug\CorreoOutLook.exe"); ConstantedeTiempo(); 
        }
        private void ColeccionMusical()
        {
            
            this.WindowState = FormWindowState.Minimized; this.Visible = true;
            Constantes();   Voz = 1;
            try { Musica f1 = new Musica(); f1.ShowDialog(); if (DialogResult == DialogResult.Yes) {  } } //Detectar.Dispose();//----------------------Apaga el microfono
            catch (Exception Ex) { Lucy.SpeakAsync("Lo siento pero no puedo abrir tu coleccion de musica" + Silencio); MessageBox.Show(Ex.Message + "No se puede abrir la coleccion de musica"); }
        }
        private void Confirmacion()
        {
            StreamReader leerbloc1 = new StreamReader(RutaRecursos + "Contraseña.txt");
            Password = leerbloc1.ReadToEnd(); leerbloc1.Close();
            StreamReader leerbloc2 = new StreamReader(RutaRecursos + "Usuario.txt");
            User = leerbloc2.ReadToEnd(); leerbloc2.Close();
        }
        private void Constantes()
        {
            Escucha.Visible = true;
            label7.Visible = true;
            labelmostrar.Text = "";
            labelmostrar.Text = palabra;
            Tiempo4.Start();
        }
        private void ConstantedeTiempo()
        {
            Tiempo1.Start(); Tiempo2.Start(); Tiempo3.Start();
        }
        #endregion Correos & Constantes

        #region Comandos para Word
       private void Detectar_SpeechRecognizedword(object sender, SpeechRecognizedEventArgs e)
        {
            palabra = e.Result.Text;
            if (Voz == 2 & Off == 2)
            {
                switch (palabra)
                {
                    case "Negrita": Off = 1; InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_N); Constantes();  
                           break;
                    case "Cursiva": Off = 1; InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_K); Constantes();  
                            break;
                    case "Subrayar": Off = 1; InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_S); Constantes();  
                            break;
                    case "Deshacer": Off = 1; InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_Z); Constantes();  
                            break;
                    case "Borrar": Off = 1; SendKeys.SendWait("{BACKSPACE}"); Constantes();  
                            break;
                    case "Centrar": Off = 1; InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_T); Constantes();  
                            break;
                    case "Justificar": Off = 1; InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_J); Constantes();  
                            break;
                    case "Alinear a la izquierda": Off = 1; InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_Q); Constantes();  
                            break;
                    case "Alinear a la derecha": Off = 1; InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_D); Constantes();  
                            break;
                    case "Imprimir": Off = 1; InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_P); Constantes();  
                            break;
                    case "Interlineado simple": Off = 1; SendKeys.SendWait("^(1)"); Constantes();  
                            break;
                } 
            }
            else {}
        }
        #endregion Comandos para Word

        #region Comandos para Power Point
       private void Detectar_SpeechRecognizedPP(object sender , SpeechRecognizedEventArgs e)
        {
        palabra = e.Result.Text;
        if (Voz == 2 & Off == 2)
            {
                switch (palabra)
                {
                    case "Nueva diapositiva": Off = 1; SendKeys.SendWait("^(m)"); Constantes(); 
                            break;
                //case...
                }
            }
        }
        #endregion  Power Point

        #region Comandos para Excel
       private void Detectar_SpeechRecognizedExcel(object sender, SpeechRecognizedEventArgs e)
        {
        palabra = e.Result.Text;
        if (Voz == 1)
            {
                switch (palabra)
                { 
                //Faltan los case para Excel
                }
            }
        }
        #endregion Comandos para Excel

        #region Comandos para Mypaint
       private void Detectar_SpeechRecognizedmypanit(object sender, SpeechRecognizedEventArgs e)
        {
            palabra = e.Result.Text;
            if (Voz == 2 & Off == 2)
            {
                switch (palabra)
                { 
                
                }
            }
        }
        #endregion Comandos para Mypaint

        #region Comandos para Photoshop CS6
       private void Detectar_SpeechRecognizedPhoto(object sender, SpeechRecognizedEventArgs e)
        {
            palabra = e.Result.Text;
            if (Voz == 2 & Off == 2)
            {
                switch (palabra)
                {
                    case "Pincel": Off = 1; InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_B); Constantes();  
                           break;
                    case "Marco rectangular": Off = 1; InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_M); Constantes();  
                            break;
                }
            }
        }
        #endregion Comandos para Photoshop CS6

        #region Contraseña
        private void button6_Click(object sender, EventArgs e)
        {Permiso = true;}
        #endregion Contraseña
        
    }
    #endregion Principal
}
        