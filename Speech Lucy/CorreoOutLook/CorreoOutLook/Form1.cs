using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using Microsoft.VisualBasic;
using System.Windows.Threading;

namespace CorreoOutLook
{
    public partial class Form1 : Form
    {
        DispatcherTimer actualizarpag;DispatcherTimer enviarasunto1;DispatcherTimer enviarasunto2;
        DispatcherTimer enviarasunto3;DispatcherTimer enviarasunto4;DispatcherTimer enviarasunto5;
        public Form1()
        {
            InitializeComponent();
            label2.BringToFront();
            label3.SendToBack();
            webBrowser1.WebBrowserShortcutsEnabled = true;
            timpoactualizar();         //Para que ejecute el metodo automaticamente
            actualizarpag.Start();          //Inicia el conteo de 10 minutos
            tiempoasunto1();
            enviarasunto1.Start();//Inicia cuando pasa 1 minuto
            tiempoasunto2();
            enviarasunto2.Start();//Inicia cuando pasan 2 minutos
            timepoasunto3();
            enviarasunto3.Start();//Inicia cuando pasan 3 minutos
            tiempoasunto4();
            enviarasunto4.Start();//Inicia cuando pasan 4 minutos
            tiempoasunto5();
            enviarasunto5.Start();//Inicia cuando pasan 5 minutos
        }//Carga los metodos al inicio del programa
        void tiempoasunto1()
        {
            enviarasunto1 = new DispatcherTimer();
            enviarasunto1.Interval = new TimeSpan(0, 1, 0);
            enviarasunto1.Tick += enviarasunto1_Tick;
        }//9 minutos
        void enviarasunto1_Tick(object sender, EventArgs e)
        {
            textBox1.Text = "Ramon";
            richTextBox1.Text = webBrowser1.DocumentText;//Se envia el codigo HTML
            Thread.Sleep(100);    //Minimo 100 - Depende de la velocidad del internet
            richTextBox1.SelectAll();
            int posicion = 0;
            int numero = 1;
            while (numero != 0)
            {
                posicion = Convert.ToInt32(Strings.InStr(numero, richTextBox1.Text, textBox1.Text));
                if (posicion > 0)
                {
                    richTextBox1.SelectionStart = posicion - 1;
                    richTextBox1.SelectionLength = textBox1.TextLength;
                    richTextBox1.SelectionColor = Color.Red;
                    numero += 1;
                 //   MessageBox.Show(richTextBox1.SelectedText);
                    if (richTextBox1.SelectedText == "Ramon Castro" || richTextBox1.SelectedText == "Ramon" || richTextBox1.SelectedText == "ramon")
                    {
                        string escribir = "Electronica Analógica";
                        System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Speech Lucy\Asistente personal Lucy\Asistente personal Lucy\bin\Debug\Recursos\Asunto 1.txt");
                        file.WriteLine(escribir);
                        file.Close();
                       // MessageBox.Show("Tienes un correo de Electronica analogica");
                    }
                    // if...
                    numero = 0;//Para que se salga del ciclo while
                }
                else
                {
                    numero = 0;
                }
            }
            enviarasunto1.Stop();
        }//Filtro Ramom
        void tiempoasunto2()
        {
            enviarasunto2 = new DispatcherTimer();
            enviarasunto2.Interval = new TimeSpan(0, 2, 0);
            enviarasunto2.Tick += enviarasunto2_Tick;
        }//10 minutos
        void enviarasunto2_Tick(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Text = "Marcela";
            richTextBox1.Text = webBrowser1.DocumentText;//Se envia el codigo HTML
            Thread.Sleep(100);    //Minimo 100 - Depende de la velocidad del internet
            richTextBox1.SelectAll();
            string Asuntos = richTextBox1.Text;
            int posicion = 0;
            int numero = 1;
            while (numero != 0)
            {
                posicion = Convert.ToInt32(Strings.InStr(numero, richTextBox1.Text, textBox1.Text));
                if (posicion > 0)
                {
                    richTextBox1.SelectionStart = posicion - 1;
                    richTextBox1.SelectionLength = textBox1.TextLength;
                    richTextBox1.SelectionColor = Color.Red;
                    numero += 1;

                    if (richTextBox1.SelectedText == "Marcela Vallejo" || richTextBox1.SelectedText == "Marcela" || richTextBox1.SelectedText == "marcela")
                    {
                        string escribir = "Laboratorio de electronica";
                        System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Speech Lucy\Asistente personal Lucy\Asistente personal Lucy\bin\Debug\Recursos\Asunto 2.txt");
                        file.WriteLine(escribir);
                        file.Close();
                      //  MessageBox.Show("Tienes un correo de laboratorio");
                    }
                    // if...
                    numero = 0;//Para que se salga del ciclo while
                }
                else
                {
                    numero = 0;
                }
            }
           enviarasunto2.Stop();
        }//Filtro Marcela
        void timepoasunto3()
        {
            enviarasunto3 = new DispatcherTimer();
            enviarasunto3.Interval = new TimeSpan(0, 3, 0);
            enviarasunto3.Tick += enviarasunto3_Tick;
        }//11 minutos
        void enviarasunto3_Tick(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Text = "Comunicaciones";
            richTextBox1.Text = webBrowser1.DocumentText;//Se envia el codigo HTML
            Thread.Sleep(100);    //Minimo 100 - Depende de la velocidad del internet
            richTextBox1.SelectAll();
            string Asuntos = richTextBox1.Text;
            int posicion = 0;
            int numero = 1;
            while (numero != 0)
            {
                posicion = Convert.ToInt32(Strings.InStr(numero, richTextBox1.Text, textBox1.Text));
                if (posicion > 0)
                {
                    richTextBox1.SelectionStart = posicion - 1;
                    richTextBox1.SelectionLength = textBox1.TextLength;
                    richTextBox1.SelectionColor = Color.Red;
                    numero += 1;

                    if (richTextBox1.SelectedText == "Comunicaciones ITM" || richTextBox1.SelectedText == "Comunicaciones" || richTextBox1.SelectedText == "comunicaciones")
                    {
                        string escribir = "Comunicaciones ITM";
                        System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Speech Lucy\Asistente personal Lucy\Asistente personal Lucy\bin\Debug\Recursos\Asunto 3.txt");
                        file.WriteLine(escribir);
                        file.Close();
                      //  MessageBox.Show("Tienes nuevos rellenos del ITM,quiero decir correos XD");
                    }
                    // if...
                    numero = 0;//Para que se salga del ciclo while
                }
                else
                {
                    numero = 0;
                }
            }
            enviarasunto3.Stop();
        }//Filtro Comunicaciones
        void tiempoasunto4()
        {
            enviarasunto4 = new DispatcherTimer();
            enviarasunto4.Interval = new TimeSpan(0, 4, 0);
            enviarasunto4.Tick += enviarasunto4_Tick;
        }//12 minutos
        void enviarasunto4_Tick(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Text = "jhonny alejandro";
            richTextBox1.Text = webBrowser1.DocumentText;//Se envia el codigo HTML
            Thread.Sleep(100);    //Minimo 100 - Depende de la velocidad del internet
            richTextBox1.SelectAll();
            string Asuntos = richTextBox1.Text;
            int posicion = 0;
            int numero = 1;
            while (numero != 0)
            {
                posicion = Convert.ToInt32(Strings.InStr(numero, richTextBox1.Text, textBox1.Text));
                if (posicion > 0)
                {
                    richTextBox1.SelectionStart = posicion - 1;
                    richTextBox1.SelectionLength = textBox1.TextLength;
                    richTextBox1.SelectionColor = Color.Red;
                    numero += 1;

                    if (richTextBox1.SelectedText == "jhonny alejandro")
                    {
                        string escribir = "El doti";
                        System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Speech Lucy\Asistente personal Lucy\Asistente personal Lucy\bin\Debug\Recursos\Asunto 4.txt");
                        file.WriteLine(escribir);
                        file.Close();
                       // MessageBox.Show("Tienes correos del Dothi");
                    }
                    // if...
                    numero = 0;//Para que se salga del ciclo while
                }
                else
                {
                    numero = 0;
                }
            }
           enviarasunto4.Stop();
        }//Filtro Dothi
        void tiempoasunto5()
        {
            enviarasunto5 = new DispatcherTimer();
            enviarasunto5.Interval = new TimeSpan(0, 5, 0);
            enviarasunto5.Tick += enviarasunto5_Tick;
        }//13 minutos
        void enviarasunto5_Tick(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Text = "Calendario de Outlook.com";
            richTextBox1.Text = webBrowser1.DocumentText;//Se envia el codigo HTML
            Thread.Sleep(100);    //Minimo 100 - Depende de la velocidad del internet
            richTextBox1.SelectAll();
            string Asuntos = richTextBox1.Text;
            int posicion = 0;
            int numero = 1;
            while (numero != 0)
            {
                posicion = Convert.ToInt32(Strings.InStr(numero, richTextBox1.Text, textBox1.Text));
                if (posicion > 0)
                {
                    richTextBox1.SelectionStart = posicion - 1;
                    richTextBox1.SelectionLength = textBox1.TextLength;
                    richTextBox1.SelectionColor = Color.Red;
                    numero += 1;

                    if (richTextBox1.SelectedText == "Calendario de Outlook.com" || richTextBox1.SelectedText == "Calendario" || richTextBox1.SelectedText == "calendario")
                    {
                        string escribir = "Calendario";
                        System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Speech Lucy\Asistente personal Lucy\Asistente personal Lucy\bin\Debug\Recursos\Eventos Calendario.txt");
                        file.WriteLine(escribir);
                        file.Close();
                      //  MessageBox.Show("Tienes nuevos eventos en tu calendario");
                    }
                    // if...
                    numero = 0;//Para que se salga del ciclo while
                }
                else
                {
                    numero = 0;
                }
            }
           enviarasunto5.Stop(); //enviarasunto1.Start();  //Se vuelve a iniciar el tick 1 despues de 15 minutos
        }//Filtro Calendario                              
        void timpoactualizar()
        {
            actualizarpag = new DispatcherTimer();
            actualizarpag.Interval = new TimeSpan(0, 13, 30);
            actualizarpag.Tick += actualizarpag_Tick;
        }//Tiempo para reiniciar la pagina 13.30s
        void actualizarpag_Tick(object sender, EventArgs e)
        {
            Application.Restart();
            //webBrowser1.Refresh();//actualizarpag.Stop();
        }                
                                              //Botones del formulario
        private void btnAtras_Click(object sender, EventArgs e)
        {webBrowser1.GoBack();}
        private void btnAdelante_Click(object sender, EventArgs e)
        {webBrowser1.GoForward();}
        private void btnActualizar_Click(object sender, EventArgs e)
        {webBrowser1.Refresh();}
        private void btnSpam_Click(object sender, EventArgs e)
        {
            string spam;
            spam = "https://blu168.mail.live.com/?fid=fljunk";
            webBrowser1.Navigate(new Uri(spam));
        }
        private void btnEnviados_Click(object sender, EventArgs e)
        {
            string enviados;
            enviados = "https://blu168.mail.live.com/?fid=flsent";
            webBrowser1.Navigate(new Uri(enviados));
        }
        private void btnEliminados_Click(object sender, EventArgs e)
        {
            string eliminados;
            eliminados = "https://blu168.mail.live.com/?fid=fltrash";
            webBrowser1.Navigate(new Uri(eliminados));
        }
        private void btnLaboratorio_Click(object sender, EventArgs e)
        {
            string laboratorio;
            laboratorio = "https://blu168.mail.live.com/?fid=flAI0jMoZ8yECzpDgwq_WI8w2";
            webBrowser1.Navigate(new Uri(laboratorio));
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string Analogica;
            Analogica = "https://blu168.mail.live.com/?fid=fl46Ku8rymaEWCaRMul4IbQw2";
            webBrowser1.Navigate(new Uri(Analogica));
        }
    }
}
