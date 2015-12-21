using System.Windows;
using System.IO;

namespace Notasrapidas
{
    public partial class MainWindow : Window
    {
        //int Visible = 1;
        public MainWindow()
        {
            InitializeComponent();
            //Inicia la lectura de los bloc y los lleva a cada TextBox
            StreamReader leerbloc1 = new StreamReader(@"C:\Speech Lucy\Notasrapidas\Notasrapidas\bin\Debug\Anotaciones\Anotaciones 1.txt");
            string Anotaciones = leerbloc1.ReadToEnd();
            box1.Text = Anotaciones;
            leerbloc1.Close();
            StreamReader leerbloc2 = new StreamReader(@"C:\Speech Lucy\Notasrapidas\Notasrapidas\bin\Debug\Anotaciones\Anotaciones 2.txt");
            string Anotaciones2 = leerbloc2.ReadToEnd();
            box2.Text = Anotaciones2;
            leerbloc2.Close();
            StreamReader leerbloc3 = new StreamReader(@"C:\Speech Lucy\Notasrapidas\Notasrapidas\bin\Debug\Anotaciones\Anotaciones 3.txt");
            string Anotaciones3 = leerbloc3.ReadToEnd();
            box3.Text = Anotaciones3;
            leerbloc3.Close();
            StreamReader leerbloc4 = new StreamReader(@"C:\Speech Lucy\Notasrapidas\Notasrapidas\bin\Debug\Anotaciones\Anotaciones 4.txt");
            string Anotaciones4 = leerbloc4.ReadToEnd();
            box4.Text = Anotaciones4;
            leerbloc4.Close();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string escribir = box1.Text;
            System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Speech Lucy\Notasrapidas\Notasrapidas\bin\Debug\Anotaciones\Anotaciones 1.txt");
            file.WriteLine(escribir);
            file.Close();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string escribir2 = box2.Text;
            System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Speech Lucy\Notasrapidas\Notasrapidas\bin\Debug\Anotaciones\Anotaciones 2.txt");
            file.WriteLine(escribir2);
            file.Close();
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string escribir3 = box3.Text;
            System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Speech Lucy\Notasrapidas\Notasrapidas\bin\Debug\Anotaciones\Anotaciones 3.txt");
            file.WriteLine(escribir3);
            file.Close();
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            string escribir4 = box4.Text;
            System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Speech Lucy\Notasrapidas\Notasrapidas\bin\Debug\Anotaciones\Anotaciones 4.txt");
            file.WriteLine(escribir4);
            file.Close();
        }

        private void Recordatorios_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Recordatorios_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            btnCerrar.Visibility = Visibility.Visible;
            tache1.Visibility = Visibility.Visible;
            tache2.Visibility = Visibility.Visible;
            tache3.Visibility = Visibility.Visible;
            tache4.Visibility = Visibility.Visible;
        }

        private void Recordatorios_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            btnCerrar.Visibility = Visibility.Hidden;
            tache1.Visibility = Visibility.Hidden;
            tache2.Visibility = Visibility.Hidden;
            tache3.Visibility = Visibility.Hidden;
            tache4.Visibility = Visibility.Hidden;
        }

        private void Recordatorios_Loaded(object sender, RoutedEventArgs e)
        {
            if (box1.Text != null)
            {
                box1.Visibility = Visibility.Visible;
            }
            else
                box1.Visibility = Visibility.Hidden;
            if (box2.Text != null)
            {
                box2.Visibility = Visibility.Visible;
            }
            else
                box2.Visibility = Visibility.Hidden;
            if (box3.Text != null)
            {
                box3.Visibility = Visibility.Visible;
            }
            else 
                box3.Visibility = Visibility.Hidden;
            if (box4.Text != null)
            {
                box4.Visibility = Visibility.Visible;
            }
            else 
                box4.Visibility = Visibility.Hidden;
        }
    }
}
