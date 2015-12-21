using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ciencias
{
    public partial class Electricidad : Form
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        public Electricidad()
        {
            InitializeComponent();
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        { ReleaseCapture(); SendMessage(this.Handle, 0x112, 0xf012, 0); }
        private void button3_Click(object sender, EventArgs e)
        { Close(); }
        private void btnBorrar_Click(object sender, EventArgs e)
        { Valor1.ResetText(); Valor2.ResetText(); }
        private void Categorias_MouseDown(object sender, MouseEventArgs e)
        {
            if ((string)Categorias.SelectedItem == "Potencia")
            { Resistencia2.Visible = false; labelResistencia.Visible = false; labelVoltaje.Visible = true; labelCorriente.Visible = true; }
            if ((string)Categorias.SelectedItem == "Resistencia")
            { Resistencia2.Visible = false; labelResistencia.Visible = false; labelVoltaje.Visible = true; labelCorriente.Visible = true; }
            if ((string)Categorias.SelectedItem == "Voltaje")
            { Resistencia2.Visible = false; labelVoltaje.Visible = false; labelResistencia.Visible = true; labelCorriente.Visible = true; }
            if ((string)Categorias.SelectedItem == "Corriente")
            { labelCorriente.Visible = false; labelVoltaje.Visible = true; labelResistencia.Visible = false; Resistencia2.Visible = true; }
        }
        private void btnCalcular_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            if ((string)Categorias.SelectedItem == "Potencia")
            {
                //Voltaje  * Intensidad
                double Numero; double Numero2;
                double Potencia;
                if (Valor1.Text != "" && Valor2.Text != "")
                {
                    Numero = int.Parse(Valor1.Text);
                    Numero2 = int.Parse(Valor2.Text);
                    Potencia = Numero * Numero2;
                    textBox1.Text = (Potencia.ToString() + " Watts");
                }
            }
            if ((string)Categorias.SelectedItem == "Resistencia")
            {
                //Voltaje  / Intensidad 
                double Numero; double Numero2;
                double Resistencia;
                if (Valor1.Text != "" && Valor2.Text != "")
                {
                    Numero = int.Parse(Valor1.Text);
                    Numero2 = int.Parse(Valor2.Text);
                    Resistencia = Numero / Numero2;
                    textBox1.Text = (Resistencia.ToString() + " Ohmios");
                }
            }
            if ((string)Categorias.SelectedItem == "Voltaje")
            {
                //Intensidad * Resistencia
                double Numero; double Numero2;
                double Voltaje;
                if (Valor1.Text != "" && Valor2.Text != "")
                {
                    Numero = int.Parse(Valor1.Text);
                    Numero2 = int.Parse(Valor2.Text);
                    Voltaje = Numero * Numero2;
                    textBox1.Text = (Voltaje.ToString() + " Voltios");
                }
            }
            if ((string)Categorias.SelectedItem == "Corriente")
            {
                //Voltaje / Resistencia
                double Numero; double Numero2;
                double Intensidad;
                if (Valor1.Text != "" && Valor2.Text != "")
                {
                    Numero = int.Parse(Valor1.Text);
                    Numero2 = int.Parse(Valor2.Text);
                    Intensidad = Numero / Numero2;
                    textBox1.Text = (Intensidad.ToString() + " Amperios");
                    
                }
            }
        }
    }
}
