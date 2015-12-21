using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Alarma.Properties;
using windowsform = System.Windows.Forms;
using System.Diagnostics;
using System.Media;

namespace Alarma
{
    public partial class MainWindow : Window
    {
        DispatcherTimer Hora;
        SoundPlayer TonoAlarma;//Para usarlo se descomenta en tonos
        SoundPlayer TonoAlarma2;
        public MainWindow()
        {
            InitializeComponent();
            conftiempo();
            Valorinicial();
        }
        void conftiempo()
        {
            Hora = new DispatcherTimer();
            Hora.Interval = new TimeSpan(0, 0, 1);//Intervalo para testear la hora c/s
            Hora.Tick += Hora_Tick;
            Hora.Start();
        }
        void Valorinicial()
        {
            Periodo.Items.Add("AM");
            Periodo.Items.Add("PM");
            for (int i = 0; i < 13; i++)
            {
                cbHora.Items.Add(i);    
            }
            for (int i = 0; i < 10; i++)
            {
                Minutos.Items.Add(+ i);//Minutos.Items.Add("0" + i); original
            }
            for (int i = 10; i < 60; i++)
            {
                Minutos.Items.Add(i);
            }
            Activar.Items.Add("Activar");
            Activar.Items.Add("Desactivar");
            cbHora.Text = Settings.Default.tHora;
            Minutos.Text = Settings.Default.tMinutos;
            Periodo.Text = Settings.Default.tPeriodo;
            Activar.Text = Settings.Default.tTiempo;
            Rutaaudio.Text = Settings.Default.tRuta;
        }
        void Hora_Tick(object sender, EventArgs e)
        {
            DateTime actual = DateTime.Now;//obtiene hora actual
            Tiempo.Content = actual.ToString("h:m:ss tt", new CultureInfo("en-US"));//Muestra la hora en el Labeltiempo
            string horaguardada = Settings.Default.tHora + ":" + Settings.Default.tMinutos + ":00 " + Settings.Default.tPeriodo;
            string horaactual = actual.ToString("h:m:ss tt", new CultureInfo("en-US"));
            if (Settings.Default.tTiempo == "Activar")
            {
                if (horaguardada == horaactual)
                {
                  //  Programar el boton Buscar para escoger el Tono de Alarma
                  //  TonoAlarma = new SoundPlayer(@"C:\Speech Lucy\Alarma\Alarma\bin\Debug\Tonos\AlarmTone 1.wav");
                  //  TonoAlarma.Play();
                    TonoAlarma2 = new SoundPlayer(@"C:\Speech Lucy\Alarma\Alarma\bin\Debug\Tonos\AlarmTone 2.wav");       
                    TonoAlarma2.Play();
                    if (tbNota.Text != "Nota..."){tbNota.Visibility = Visibility.Visible;}
                    else {}
                }
            }
        }
        private void Buscar_Click(object sender, RoutedEventArgs e)
        {//Este boton esta oculto en el diseñador ,Abrir un archivo de audio
        }      
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {DragMove();}
        private void cbHora_DropDownClosed(object sender, EventArgs e)
        {Settings.Default.tHora = cbHora.Text;Settings.Default.Save();}
        private void Minutos_DropDownClosed(object sender, EventArgs e)
        {Settings.Default.tMinutos = Minutos.Text;Settings.Default.Save();}
        private void Periodo_DropDownClosed(object sender, EventArgs e)
        {Settings.Default.tPeriodo = Periodo.Text;Settings.Default.Save();}
        private void Activar_DropDownClosed(object sender, EventArgs e)
        {Settings.Default.tTiempo = Activar.Text;Settings.Default.Save();}
        private void Cerrar_Click(object sender, RoutedEventArgs e)
        {this.Close();}
        private void Minimizar_Click(object sender, RoutedEventArgs e)
        {this.WindowState = System.Windows.WindowState.Minimized;}
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Activar.Text == "Activar"){tbNota.Visibility = Visibility.Visible;tbNota.MouseWheel += tbNota_MouseWheel;}
            else {}
        }
        void tbNota_MouseWheel(object sender, MouseWheelEventArgs e)
        {tbNota.Visibility = Visibility.Hidden;}
    }
}