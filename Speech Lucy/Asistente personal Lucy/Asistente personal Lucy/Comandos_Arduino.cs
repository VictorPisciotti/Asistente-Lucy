using System;
using System.IO.Ports;
using System.Windows.Threading;

namespace Asistente_personal_Lucy
{
    class Comandos_Arduino
    {
        #region Declaraciones

        SerialPort PuertoBluetooth = new SerialPort();
        public string Estadodeenvio;//Variable de Estado (Pasar a Lucy)
        DispatcherTimer Tempo;
        string Puerto = "COM7";

        #endregion Declaraciones

        #region Abrir/Cerrar Puerto
        public void AbrirPuerto()
        {
            this.PuertoBluetooth.ReadBufferSize = 4096;
            this.PuertoBluetooth.DataBits = 8;
            this.PuertoBluetooth.BaudRate = 9600;
            this.PuertoBluetooth.PortName = Puerto;
            try
            {
                this.PuertoBluetooth.Open();
                Tiempo();
                //CheckForIllegalCrossThreadCalls = false;
            }
            catch (Exception Ex)
            {
                Estadodeenvio = Ex.Message;
            }
          //  PuertoBluetooth.DataReceived += PuertoBluetooth_DataReceived;
        }
        public void CerrarPuerto()
        {
            this.PuertoBluetooth.Close();
        }
        #endregion Abrir/Cerrar Puerto

        #region Comandos para enviar a Arduino
        public void Comando1()
        {
            if (PuertoBluetooth.IsOpen)
            {
                this.PuertoBluetooth.Write("a");
                EnvioExitoso();
            }
            else { FalloEnvio(); }
        }
        public void Comando2()
        {
            if (PuertoBluetooth.IsOpen)
            {
                this.PuertoBluetooth.Write("b");
                EnvioExitoso();
            }
            else { FalloEnvio(); }
        }
        public void Comando3()
        {
            if (PuertoBluetooth.IsOpen)
            {
                this.PuertoBluetooth.Write("c");
                EnvioExitoso();
            }
            else { FalloEnvio(); }
        }
        public void Comando4()
        {
            if (PuertoBluetooth.IsOpen)
            {
                this.PuertoBluetooth.Write("d");
                EnvioExitoso();
            }
            else { FalloEnvio(); }
        }
        public void Comando5()
        {
            if (PuertoBluetooth.IsOpen)
            {
                this.PuertoBluetooth.Write("e");
                EnvioApagado();
            }
            else { FalloEnvio(); }
        }
        public void Comando6()
        {
            if (PuertoBluetooth.IsOpen)
            {
                this.PuertoBluetooth.Write("f");
                EnvioApagado();
            }
            else { FalloEnvio(); }
        }
        public void Comando7()
        {
            if (PuertoBluetooth.IsOpen)
            {
                this.PuertoBluetooth.Write("g");
                EnvioApagado();
            }
            else { FalloEnvio(); }
        }
        public void Comando8()
        {
            if (PuertoBluetooth.IsOpen)
            {
                this.PuertoBluetooth.Write("h");
                EnvioApagado();
            }
            else { FalloEnvio(); }
        }
        public void Comando9()
        {
            if (PuertoBluetooth.IsOpen)
            {
                this.PuertoBluetooth.Write("0");
                EnvioApagado();
            }
            else { FalloEnvio(); }
        }

        #endregion Comandos para enviar a Arduino

        #region Respuesta de Arduino
        public void PuertoBluetooth_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (this.PuertoBluetooth.ReadExisting() == "1")
            {
                Estadodeenvio = "Encendido";//Esto lo lee Lucy
            }
            else if (this.PuertoBluetooth.ReadExisting() == "0")
                Estadodeenvio = "Apagado";//Esto lo lee Lucy
            else {}
        }
        #endregion Respuesta de Arduino

        #region Actualizaciones
        public void Tiempo()
        {
            Tempo = new DispatcherTimer();
            Tempo.Interval = new TimeSpan(0,0,5);
            Tempo.Tick +=Tempo_Tick;
        }
        void Tempo_Tick(object sender, EventArgs e)
        {
            //Cada segundo va a borrar el texto que hay en la variable 'Estadodeenvio'
            Estadodeenvio = "";
        }
        #endregion Actualizaciones

        #region Resultado de envio
        private void EnvioExitoso()
        {
            Estadodeenvio = "Encendido"; 
        }
        private void EnvioApagado()
        {
            Estadodeenvio = "Apagado";
        }
        private void FalloEnvio()
        {
            Estadodeenvio = "Error";
        }
        #endregion Resultado de envio
    }
}
