using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Windows.Threading;
using System.Timers;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Speech.Recognition;

namespace Asistente_personal_Lucy
{
    public partial class BusquedaGoogle : Form
    {
        #region Declaraciones

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private SpeechRecognitionEngine palabra = new SpeechRecognitionEngine();
        string Base = "https://www.google.com/search?q=";
        string Link;
        #endregion Declaraciones

        #region Main
        public BusquedaGoogle()
        {
            InitializeComponent();
            try
            {
                palabra.SetInputToDefaultAudioDevice();
                palabra.LoadGrammar(new DictationGrammar());
                palabra.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(Detectado);//Se comenta si se desea activar con el boton
                palabra.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (Exception Ex)
            { MessageBox.Show("Ocurrio un problema al detectar las palabras" + Ex.Message);} 
        }                                                  //Boton de conexion
        private void BusquedaGoogle_Load(object sender, EventArgs e)
        { this.button2.DialogResult = System.Windows.Forms.DialogResult.Yes; }

        #endregion Main

        #region Mover Form

        private void BusquedaGoogle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture(); SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        #endregion Mover Form

        #region Comandos

        public void Detectado(object sender, SpeechRecognizedEventArgs e)
        {
            foreach (RecognizedWordUnit palabra in e.Result.Words)
            {
                tbPalabra.SelectedText = " " + palabra.Text.Replace("busca", "");
                Link = Base + tbPalabra.Text;
                if (tbPalabra.Text.Contains("cancelar") | tbPalabra.Text.Contains("borrar"))
                {
                    tbPalabra.Clear();
                }
                else if (palabra.Text == "busca" | palabra.Text == "buscar")
                {
                    NaveGoogle.Url = new Uri(Link);
                    tbPalabra.Clear();
                }
                else if (tbPalabra.Text.Contains("busca") | tbPalabra.Text.Contains("buscar"))
                {
                    tbPalabra.SelectedText = " " + palabra.Text.Replace("busca", "".Replace("buscar","")); 
                }
            }
        }
        #endregion Comandos

    }
}
