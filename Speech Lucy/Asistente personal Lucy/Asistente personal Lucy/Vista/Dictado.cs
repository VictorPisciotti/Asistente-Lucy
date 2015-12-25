using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Speech.Recognition;
using System.Windows.Forms;

namespace Asistente_personal_Lucy
{
    public partial class Dictado : Form
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        SpeechRecognitionEngine reconocedordepalabras = new SpeechRecognitionEngine();
        public Dictado()
        {
            InitializeComponent();
            reconocedordepalabras.SetInputToDefaultAudioDevice();
            reconocedordepalabras.LoadGrammar(new DictationGrammar());//Gramatica predeterminada del equipo
            reconocedordepalabras.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(reconocedordepalabras_SpeechRecognized);
            reconocedordepalabras.RecognizeAsync(RecognizeMode.Multiple);
            System.Windows.Forms.MessageBox.Show("Si desea mejorar el dictado y evitar posibles errores puede entrenar al equipo en la sección de reconocimiento de voz.", "Dictado Lucy",
            MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
                                                            //Boton de conexion
        private void Calendario_Load(object sender, EventArgs e)
        {
            this.btncancelar.DialogResult = System.Windows.Forms.DialogResult.Yes;
        }
                                                  //Borra el texto y crea un nuevo Bloc
        private void btnBorrar_Click(object sender, EventArgs e) 
        {
            textBox1.Clear();
            string archivo1 = @"C:\\Speech Lucy\\Asistente personal Lucy\\Asistente personal Lucy\\bin\\Debug\\Recursos\Portapapeles Dictado.txt";
            try
            {if (File.Exists(archivo1)) { File.Delete(archivo1); } using (FileStream a1 = File.Create(archivo1)){}}
            catch (Exception Ex) { MessageBox.Show(Ex.ToString()); }
        }
        private void btnayuda_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Para entrenar al equipo diríjase al panel de control y haga click sobre el reconocimiento de voz,acontinuacion siga dichos pasos", 
                "Dictado Lucy", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Calendario_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture(); SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        void reconocedordepalabras_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)//Todo lo que se reconoce es guardado en el bloc de dictado y se puede devolver con decir 'Pegar'
        {
            foreach (RecognizedWordUnit palabras in e.Result.Words)
            {
                textBox1.SelectedText = " " + palabras.Text;
                bool si = true;
                do
                {
                    string escribir = textBox1.Text;
                    System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Speech Lucy\Asistente personal Lucy\Asistente personal Lucy\bin\Debug\Recursos\Portapapeles Dictado.txt");
                    file.WriteLine(escribir);
                    file.Close();
                    si = false;
                }
                while (si == true);
                StreamReader leercorreo1 = new StreamReader(@"C:\Speech Lucy\Asistente personal Lucy\Asistente personal Lucy\bin\Debug\Recursos\Portapapeles Dictado.txt");
                string asunto1 = leercorreo1.ReadToEnd(); leercorreo1.Close();
                Clipboard.SetText(asunto1);
                //if...
            }   
        }
    }
}