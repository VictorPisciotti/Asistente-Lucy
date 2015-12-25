using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asistente_personal_Lucy
{
    class Maximizar
    {
        Musica Open = new Musica();

        public void MaximizarForm()
        {
            if (Open.lockMaxMin == false)
            {
                int alto = Screen.PrimaryScreen.Bounds.Height;//Obtiene el alto de la pantalla principal en pixeles.
                int ancho = Screen.PrimaryScreen.Bounds.Width; //Obtiene el ancho de la pantalla principal en pixeles.
                if (alto != 1080 & ancho != 1920)
                { MessageBox.Show("La resolucion de pantalla no es correcta,puede que algunos elementos no se visualizen adecuadamente", "Coleccion Musical", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                else
                Open.button33.Location = new Point(1861, 5);//Mini...
                Open.button27.Location = new Point(1888, 5);//Cerrar...
                Open.label47.Location = new Point(1660, 63);//Titulo Lista de reproduccion
                Open.ListaReproduccion.Location = new Point(1615, 98);//Lista de reproduccion //X,Y
                Open.ListaReproduccion.Width = 275; Open.ListaReproduccion.Height = 510;//Ancho y Alto
                if (Open.ListaActual.Visible == true) { Open.ListaActual.Visible = true; }//Muestra la Lista Actual de Radio    
                else { }
                Open.button36.Location = new Point(1870, 97);//Boton Clear
                Open.Location = Screen.PrimaryScreen.WorkingArea.Location;//se acopla al tamaño de la pantalla
                Open.Size = Screen.PrimaryScreen.WorkingArea.Size;//se acopla al tamaño de la pantalla 
                Open.lockMaxMin = true;   
            }
            else {}   
            
        }

        public void MinimizarForm()
        {
            if (Open.lockMaxMin == true)
            {
                Open.button33.Location = new Point(1528, 5);//Mini...
                Open.button27.Location = new Point(1555, 5);//Cerrar
                Open.label47.Location = new Point(462, 4);//Titulo Lista de reproduccion
                Open.ListaReproduccion.Width = 196; Open.ListaReproduccion.Height = 74;//Ancho y Alto
                Open.ListaReproduccion.Location = new Point(461, 28);//Lista de reproduccion //X,Y
                Open.button36.Location = new Point(638, 27);//Boton Clear
                Open.Size = new Size(1589, 646);
                Open.lockMaxMin = false;  
            }
           else {}
        }
    }
}
