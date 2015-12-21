using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Reloj_Digital
{
    public partial class Calendar : Form
    {
        #region Declaraciones
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        int incre = 2; int final = 350;
        #endregion Declaraciones

        #region Eventos
        public Calendar()
        {
            InitializeComponent();
            if (incre == 206){}
            else
                for (incre = 2; incre < final; incre++){this.Size = new Size(212, incre);}
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        { this.DialogResult = DialogResult.Yes; }
        private void Calendar_MouseDown(object sender, MouseEventArgs e)
        {/*ReleaseCapture();SendMessage(this.Handle, 0x112, 0xf012, 0);*/ }
        #endregion Eventos
    }
}
