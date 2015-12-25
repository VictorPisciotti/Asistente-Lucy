using System;
using System.Windows.Forms;

namespace Asistente_personal_Lucy
{
    public partial class Login : Form
    {    
        public Login()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Pisciotti" && textBox2.Text == "123"){this.button1.DialogResult = DialogResult.OK;}
            else if (textBox1.Text != "Pisciotti" || textBox2.Text != "123"){this.button1.DialogResult = DialogResult.Yes; }
        }
    }
}
