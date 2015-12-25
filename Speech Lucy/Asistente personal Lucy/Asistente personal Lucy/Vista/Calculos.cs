using System;
using System.Speech.Recognition;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.IO;

namespace Asistente_personal_Lucy
{
    public partial class Calculos : Form
    {
        SpeechRecognitionEngine palabrasdecalculo = new SpeechRecognitionEngine();//Reconoce
        SpeechSynthesizer Lucy = new SpeechSynthesizer();//Habla
        public Calculos()
        {
            InitializeComponent();
            palabrasdecalculo.SetInputToDefaultAudioDevice();
            palabrasdecalculo.LoadGrammarAsync(Migramatica());//Quitar el Async por si algo sucede
           // palabrasdecalculo.LoadGrammar(new DictationGrammar());
            palabrasdecalculo.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(palabrasdecalculo_SppeechRecognized);
            palabrasdecalculo.RecognizeAsync(RecognizeMode.Multiple);
        }
        private static Grammar Migramatica()
        {
            Grammar migramatica = new Grammar(AppDomain.CurrentDomain.BaseDirectory + "//Palabras.xml");
            migramatica.Name = "Mi grmatica de calculos";
            return migramatica;
        }
        void palabrasdecalculo_SppeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            foreach (RecognizedWordUnit palabra in e.Result.Words)
            {
                if (palabra.Text == "Sumar" || palabra.Text == "Sumalos")
                {Operaciones();DialogResult = System.Windows.Forms.DialogResult.Yes;}
                else if (palabra.Text == "Multiplicar" || palabra.Text == "Multiplicalos")
                {OperacionesMultiplicacion();DialogResult = System.Windows.Forms.DialogResult.No;}
                else if (palabra.Text == "Restar" || palabra.Text == "Restalos")
                {OperacionesResta();DialogResult = System.Windows.Forms.DialogResult.Retry;}
                else if (palabra.Text == "Dividir" || palabra.Text == "Dividelos")
                {OperacionesDivision();DialogResult = System.Windows.Forms.DialogResult.Cancel;}
                else if (palabra.Text == "Raizcuadrada")
                {OperacionesRaiz();DialogResult = System.Windows.Forms.DialogResult.Ignore;}
                //else if...
            }
        }
        void Operaciones()
        {
         double sum;double N1; double N2;
         try
         {
             if (Valor1 == null & Valor2 == null)
             {
                 Lucy.SpeakAsync("Ingresa los valores para poder calcular"); this.Visible = true;
             }
             else
             {
                 N1 = int.Parse(Valor1.Text); N2 = int.Parse(Valor2.Text); sum = N1 + N2;
                 string escribir = sum.ToString();
                 StreamWriter f = new StreamWriter(@"C:\Speech Lucy\Asistente personal Lucy\Asistente personal Lucy\bin\Debug\Recursos\Suma.txt");
                 f.WriteLine(escribir); f.Close();
             }
         }
         catch (Exception Ex)
         {
                Lucy.SpeakAsync("Lo siento pero no puedo realizar las operaciones " + ".."); MessageBox.Show(Ex.Message); }
         }
        void OperacionesResta()
            {
             double res1; double res2; double N1; double N2;
             try
             {
                 if (Valor1 == null & Valor2 == null)
                 {
                     Lucy.SpeakAsync("Ingresa los valores para poder calcular"); this.Visible = true;
                 }
                 else
                 { 
              N1 = int.Parse(Valor1.Text);N2 = int.Parse(Valor2.Text);res1 = N1 - N2;res2 = N2 - N1;
              string escribir5 = res1.ToString();
              StreamWriter f5 = new StreamWriter(@"C:\Speech Lucy\Asistente personal Lucy\Asistente personal Lucy\bin\Debug\Recursos\Resta 1.txt");
              f5.WriteLine(escribir5); f5.Close();
              string escribir6 = res2.ToString();
              StreamWriter f6 = new StreamWriter(@"C:\Speech Lucy\Asistente personal Lucy\Asistente personal Lucy\bin\Debug\Recursos\Resta 2.txt");
              f6.WriteLine(escribir6); f6.Close();
                 }
             }
             catch (Exception Ex) { Lucy.SpeakAsync("Lo siento pero no puedo realizar las operaciones " + ".."); MessageBox.Show(Ex.Message); }
            }
        void OperacionesDivision()
          {
            double N1; double N2; double div; double div2;
            try
            {
                if (Valor1 == null & Valor2 == null)
                {
                    Lucy.SpeakAsync("Ingresa los valores para poder calcular"); this.Visible = true;
                }
                else
                {
                    N1 = int.Parse(Valor1.Text); N2 = int.Parse(Valor2.Text); div = N1 / N2; div2 = N2 / N1;
                    string escribir3 = div.ToString();
                    StreamWriter f3 = new StreamWriter(@"C:\Speech Lucy\Asistente personal Lucy\Asistente personal Lucy\bin\Debug\Recursos\Division 1.txt");
                    f3.WriteLine(escribir3); f3.Close();
                    string escribir4 = div2.ToString();
                    StreamWriter f4 = new StreamWriter(@"C:\Speech Lucy\Asistente personal Lucy\Asistente personal Lucy\bin\Debug\Recursos\Division 2.txt");
                    f4.WriteLine(escribir4); f4.Close();
                }
            }
            catch (Exception Ex) { Lucy.SpeakAsync("Lo siento pero no puedo realizar las operaciones " + ".."); MessageBox.Show(Ex.Message); }
        }
        void OperacionesMultiplicacion() 
        {
          double mul; double N1; double N2;
          try
          {
              if (Valor1 == null & Valor2 == null)
              {
                  Lucy.SpeakAsync("Ingresa los valores para poder calcular"); this.Visible = true;
              }
              else
              {
                  N1 = int.Parse(Valor1.Text); N2 = int.Parse(Valor2.Text); mul = N1 * N2;
                  string escribir2 = mul.ToString();
                  StreamWriter f2 = new StreamWriter(@"C:\Speech Lucy\Asistente personal Lucy\Asistente personal Lucy\bin\Debug\Recursos\Multiplicacion.txt");
                  f2.WriteLine(escribir2); f2.Close();
              }
          }
          catch (Exception Ex) { Lucy.SpeakAsync("Lo siento pero no puedo realizar las operaciones " + ".."); MessageBox.Show(Ex.Message); }
        }
        void OperacionesRaiz()
        {
            double rz1; double rz2; double N1; double N2;
            if (Valor1.Text != "" && Valor2.Text == "")
            {
                N1 = int.Parse(Valor1.Text);
                double a = N1;
                rz1 = Math.Sqrt(a);
                    string escribir9 = " ";
                    StreamWriter f9 = new StreamWriter(@"C:\Speech Lucy\Asistente personal Lucy\Asistente personal Lucy\bin\Debug\Recursos\Raiz2.txt");
                    f9.WriteLine(escribir9); f9.Close();
                    string escribir7 = rz1.ToString();
                    StreamWriter f7 = new StreamWriter(@"C:\Speech Lucy\Asistente personal Lucy\Asistente personal Lucy\bin\Debug\Recursos\Raiz1.txt");
                    f7.WriteLine(escribir7); f7.Close();
            }
            if (Valor1.Text == "" && Valor2.Text != "")
            {
                N2 = int.Parse(Valor2.Text);
                double b = N2;
                rz2 = Math.Sqrt(b);
                {
                    string escribir10 = " ";
                    StreamWriter f10 = new StreamWriter(@"C:\Speech Lucy\Asistente personal Lucy\Asistente personal Lucy\bin\Debug\Recursos\Raiz1.txt");
                    f10.WriteLine(escribir10); f10.Close();
                    string escribir8 = rz2.ToString();
                    StreamWriter f8 = new StreamWriter(@"C:\Speech Lucy\Asistente personal Lucy\Asistente personal Lucy\bin\Debug\Recursos\Raiz2.txt");
                    f8.WriteLine(escribir8); f8.Close();
                }
            }
            if (Valor1.Text != "" && Valor2.Text != "")
            {
                N1 = int.Parse(Valor1.Text);
                double a = N1;
                rz1 = Math.Sqrt(a);
                N2 = int.Parse(Valor2.Text);
                double b = N2;
                rz2 = Math.Sqrt(b);
                {
                    string escribir7 = rz1.ToString();
                    StreamWriter f7 = new StreamWriter(@"C:\Speech Lucy\Asistente personal Lucy\Asistente personal Lucy\bin\Debug\Recursos\Raiz1.txt");
                    f7.WriteLine(escribir7); f7.Close();
                    string escribir8 = rz2.ToString();
                    StreamWriter f8 = new StreamWriter(@"C:\Speech Lucy\Asistente personal Lucy\Asistente personal Lucy\bin\Debug\Recursos\Raiz2.txt");
                    f8.WriteLine(escribir8); f8.Close();
                }
            }
        }
    }
}
