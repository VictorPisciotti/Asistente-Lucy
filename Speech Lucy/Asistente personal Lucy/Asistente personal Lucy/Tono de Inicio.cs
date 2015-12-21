using System.Media;

namespace Asistente_personal_Lucy
{
    class Tono_de_Inicio
    {
        public SoundPlayer Tono;

        public void TonodeInicio()
        {
            Tono = new SoundPlayer(@"C:\Speech Lucy\Asistente personal Lucy\Asistente personal Lucy\bin\Debug\Recursos\Song\Start.wav");
            Tono.Play();
        }
        public void TonodeCierre()
        {
            Tono = new SoundPlayer(@"C:\Speech Lucy\Asistente personal Lucy\Asistente personal Lucy\bin\Debug\Recursos\Song\End.wav");
            Tono.Play();
        }

    }
}
