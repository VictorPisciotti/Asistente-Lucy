using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Youtube
{
    public partial class YouTube : Form
    {
        public YouTube()
        {
            InitializeComponent();
            webBrowser1.WebBrowserShortcutsEnabled = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {webBrowser1.GoBack();}
        private void button2_Click(object sender, EventArgs e)
        {webBrowser1.GoForward();}
        private void button3_Click(object sender, EventArgs e)
        {webBrowser1.Refresh();}
        private void button4_Click(object sender, EventArgs e)
        {string paginicio;paginicio = "http://www.youtube.com/";webBrowser1.Navigate(new Uri(paginicio));}

        private void YouTube_Load(object sender, EventArgs e)
        {
            webBrowser1.ScrollBarsEnabled = false;
           /////////////////////////////////////////
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            webBrowser1.Update();
        }
    }
}
