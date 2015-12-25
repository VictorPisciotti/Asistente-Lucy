using System;
using System.Windows.Forms;
namespace Asistente_personal_Lucy
{
    public partial class Ayuda : Form
    {
        public Ayuda()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.button1.DialogResult = DialogResult.Yes;
        }
    }
}
