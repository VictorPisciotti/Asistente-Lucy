using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Asistente_personal_Lucy
{
    public partial class Menu_aplicaciones : Form
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        public Menu_aplicaciones()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e) { Close(); }
        private void btnword_Click(object sender, EventArgs e){this.btnword.DialogResult = DialogResult.Yes;}
        private void button2_Click(object sender, EventArgs e){this.button2.DialogResult = DialogResult.No;}
        private void btnPht_Click(object sender, EventArgs e){this.btnPht.DialogResult = DialogResult.OK;}
        private void btnMpaint_Click(object sender, EventArgs e) { this.btnMpaint.DialogResult = DialogResult.Retry; }
        private void btnPicasa_Click(object sender, EventArgs e) { }//Desactivado
        private void btnExcel_Click(object sender, EventArgs e){this.btnExcel.DialogResult = DialogResult.Ignore;}
        private void btnPP_Click(object sender, EventArgs e){this.btnPP.DialogResult = DialogResult.Abort;}
        private void Menu_aplicaciones_MouseDown(object sender, MouseEventArgs e)
        {ReleaseCapture(); SendMessage(this.Handle, 0x112, 0xf012, 0);}
    }
}
