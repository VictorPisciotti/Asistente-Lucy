using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Threading;

namespace Reloj_Digital
{
    public partial class Reloj : Form
    {

#region Declraciones Universales 
        


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

        int contVeces = 1; int Cambio = 1;
        string Ruta = "C:\\Speech Lucy\\Asistente personal Lucy\\Asistente personal Lucy\\bin\\Debug\\Asistente personal Lucy.exe";
        Screen screen = Screen.PrimaryScreen; 
        DispatcherTimer TiempoColores;
        Calendar f = new Calendar();

#endregion Declraciones Universales

#region Main
        public Reloj()
        {
            InitializeComponent();
            int id = 0;     
            int id2 = 1;
            int id3 = 2;
            RegisterHotKey(this.Handle, id, (int)ModificadordeTecla.Alt, Keys.C.GetHashCode());
            RegisterHotKey(this.Handle, id2, (int)ModificadordeTecla.Alt, Keys.V.GetHashCode());
            RegisterHotKey(this.Handle, id3, (int)ModificadordeTecla.Alt, Keys.L.GetHashCode());
            TiempoCambioColor();
        }
#endregion Main

#region Mostrar Reloj

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == 0x0312)
            {
                //------------------Que mustre o oculte el reloj----------------------
                int id = m.WParam.ToInt32();

                if (id == 0)
                {   
                   TopMost = true;
                }
                else if (id == 1)
                {
                   TopMost = false;
                }
                else if (id == 2)
                {
                    //Abra Lucy
                    try
                    {
                        System.Diagnostics.Process.Start(Ruta);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                }
            }
        }

        private void Reloj_Activated(object sender, EventArgs e)
        {
            TopMost = false;
        }

        #endregion Mostrar Reloj

#region Form Load
        private void Form1_Load(object sender, EventArgs e)
        { 
            Temporizador.Start();//Nunca se detiene
            TiempoColores.Start();//Nunca se detiene
        }//Inician los dos Timer
#endregion Form Load

#region Mover Formulario
        private void lbMove_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture(); SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
#endregion Mover Formulario

#region Tiempos de actualizacion
        private void Temporizador_Tick(object sender, EventArgs e)
        {
            DateTime HoraActual = DateTime.Now;
            lbDate.Text = DateTime.Now.ToLongDateString();//Fecha 
            lbHora.Text = HoraActual.ToString("h:m:ss tt", new CultureInfo("en-US"));//Hora
           Resolucion();
        }
        private void TiempoCambioColor()
        {TiempoColores = new DispatcherTimer(); TiempoColores.Interval = new TimeSpan(0, 1, 0); TiempoColores.Tick += TiempoColores_Tick;}
        void TiempoColores_Tick(object sender, EventArgs e)
        {
            //Que va hacer cada 1 minuto? Cambiar el color de los label's y la resolucion
            Colores(); //Resolucion();
        }
#endregion Tiempos de actualizacion

#region Cambio de color
        private void Colores()
       {
           Random randomGen = new Random();
           KnownColor [] names = (KnownColor [])Enum.GetValues(typeof(KnownColor));
           KnownColor randomColorName = names [randomGen.Next(names.Length)];
           Color randomColor = Color.FromKnownColor(randomColorName);
           lbDate.ForeColor = randomColor;lbHora.ForeColor = randomColor;lbMove.BackColor = randomColor;
       }
#endregion Cambio de color

#region Cambio de Resolucion

        private void Resolucion()
       {
           int Height = screen.Bounds.Width;int Width = screen.Bounds.Height;
           if (contVeces == 1)
           {
               if (Height == 1920 & Width == 1080) 
               {
                   contVeces = 2; 
                   this.Location = new Point(1650, 50);
                   f.Location = new Point(1715, 30); 
               }
               else if (Height == 1360 & Width == 768 | Height == 1366 & Width == 768) 
               {
                   contVeces = 2;
                   this.Location = new Point(1050, 50);
                   f.Location = new Point(1152, 30); 
               }
           }
           else {}
       }
#endregion Cambio de Resolucion

#region Calendario
        private void lbMove_MouseEnter(object sender, EventArgs e)
        {
            if (Cambio == 1 | Cambio == 2)
            {
                Cambio = Cambio + 1;
            }
            else if (Cambio == 3)
            {
                Cambio = 1;
                f.ShowDialog();
            }
        }
        #endregion Calendario
     
    }
}