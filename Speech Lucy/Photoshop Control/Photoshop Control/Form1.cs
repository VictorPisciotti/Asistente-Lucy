using System;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Windows.Forms;
using System.IO;
using WindowsInput;
using System.Runtime.InteropServices;

namespace Photoshop_Control
{
    public partial class Form1 : Form
    {
#region Declaraciones Universales
        SpeechRecognitionEngine reconocedor = new SpeechRecognitionEngine();//Reconoce
        SpeechSynthesizer Lucy = new SpeechSynthesizer();//Habla
        bool activarvoz = true; int audioLevel; string Palabra; int Dialogo = 1;
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        #endregion Declaraciones Universales

#region Load
        public Form1()
        {
            InitializeComponent();
        }//Load Main
        private void Form1_Load(object sender, EventArgs e)
        {
            activarvoz = false; CargarGramtica();
        }//Form Load
        #endregion Load

#region Botones comunes
        private void button1_Click(object sender, EventArgs e)
        {Application.Exit();}//Boton cerrar
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {ReleaseCapture(); SendMessage(this.Handle, 0x112, 0xf012, 0);}
        #endregion Botones comunes

#region Gramatica
        private void CargarGramtica()
        {
            reconocedor.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(File.ReadAllLines(@"C:\Speech Lucy\Photoshop Control\Photoshop Control\bin\Debug\Recursos\Comandos.txt")))));
            reconocedor.RequestRecognizerUpdate();//Actualiza el reconocedor
            Lucy.SpeakCompleted += Lucy_SpeakCompleted;
            Lucy.SpeakStarted += Lucy_SpeakStarted;
            reconocedor.AudioLevelUpdated += reconocedor_AudioLevelUpdated;
            reconocedor.SpeechRecognized += reconocedor_SpeechRecognized;
            reconocedor.SetInputToDefaultAudioDevice();//MIC Default
            reconocedor.RecognizeAsync(RecognizeMode.Multiple);
        }
        #endregion Gramatica

#region Ocurre cuando cambia el nivel del MIC
        void reconocedor_AudioLevelUpdated(object sender, AudioLevelUpdatedEventArgs e)//Cuando cambia el valor de volumen del MIC
        {
            audioLevel = e.AudioLevel;//Que me lleve el valor que hay actualmente
            if (audioLevel == 2)
            {
                lbCaptado.Visible = true;
                //Que pasen 3 segundos y se oculte el label
            }
            else { lbCaptado.Visible = false; }
        }
        #endregion Ocurre cuando cambia el nivel del MIC

#region Activar/Desactivar el asistente
        void Lucy_SpeakStarted(object sender, SpeakStartedEventArgs e)//Cuando empieza hablar
        {
            activarvoz = false;
        }
        void Lucy_SpeakCompleted(object sender, SpeakCompletedEventArgs e)//Cuando termina de hablar
        {
            activarvoz = true;
        }
        #endregion Activar/Desactivar el asistente

#region Comandos de Activacion
        void reconocedor_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)//Para reconocer cada una de las palabras de la gramatica
        {
            Palabra = e.Result.Text;
            switch (Palabra)
	            {
                    case "Lucy":

                        if (Dialogo == 1){Lucy.SpeakAsync("En que te puedo ayudar"); Dialogo = 2; }
                        else if (Dialogo == 2){Lucy.SpeakAsync("Dime"); Dialogo = 3;}
                        else if (Dialogo == 3){Lucy.SpeakAsync("Que deseas que haga"); Dialogo = 1;}
                        activarvoz = true; lbActivado.Visible = true;//Se activa    
                        break;
                    case "Suspender": activarvoz = false; lbPalabras.Text = "Suspendido"; lbCaptado.Visible = false; lbActivado.Visible = false;//Se apaga
                        break;
                }
#endregion Comandos de Activacion

#region Comandos Comunes para photoshop

            if (activarvoz == true)
            {
                lbPalabras.Text = Palabra;
                switch (Palabra)
                {
                    case "Copiar": InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_C);
                        break;
                    case "Pegar": InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_V);
                        break;
                    case "Coleccion de brochas": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_B);
                        break;
                    case "Borrador": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_E);
                        break;
                    case "Guardar edicion": InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_S);
                        break;
                    case "Atras": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_Z);
                        break;
                    case "Adelante": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_Y);
                        break;
                    case "Cerrar el editor": InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_Q);
                        break;
                    case "Nueva edicion": InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_N);
                        break;
                    case "Abrir imagen": InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_O);
                        break;
                    case "Cambia la vista a pantalla completa": InputSimulator.SimulateKeyPress(VirtualKeyCode.F11);
                        break;
                    case "Cambia a vista normal": InputSimulator.SimulateKeyPress(VirtualKeyCode.F11);
                        break;
                    case "Rotacion izquierda": InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.LEFT);
                        break;
                    case "Rotacion derecha": InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.RIGHT);
                        break;
                    case "Espejar horizontalmente": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_I);
                        break;
                    case "Espejar verticalmente": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_U);
                        break;
                    case "Editor de brochas": InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.SHIFT, VirtualKeyCode.VK_B);
                        break;
                    case "Cambia el tamaño a 10": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_F);
                        break;
                    case "Cambia el tamaño a 5": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_D);
                        break;
                    case "Aumenta la opacidad a 10": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_S);
                        break;
                    case "Reduce la opacidad a 5": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_A);
                        break;
                    case "Recoger color": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_R);
                        break;
                    case "Muestras de color": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_T);
                        break;
                    case "Muestrame las capas": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_L);
                        break;
                    case "Borrar edicion": InputSimulator.SimulateKeyPress(VirtualKeyCode.BACK);//suprimir
                        break;
                }
            }
        }
        #endregion Comandos Comunes para photoshop

    }
}
