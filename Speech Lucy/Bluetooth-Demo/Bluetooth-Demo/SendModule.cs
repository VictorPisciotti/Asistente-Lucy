using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InTheHand.Net;

namespace Bluetooth_Demo
{
    public static class SendModule
    {
        
    public static ObexStatusCode SendFile(BluetoothAddress address, string file_path)
    {
    // string FileName = file_path.Substring(file_path.LastIndexOf("\\"));          //No es necesario para enviar string
   
        Uri uri = new Uri("obex://" + address.ToString() + "/" + file_path);        //file_path = Hola mundo; o cualquier otro string en la otra clase

        ObexWebRequest request = new ObexWebRequest(uri);
   //   request.ReadFile(file_path);                                                //Se comento para que no leea la ruta del archivo y tire error debido a que es un string
        ObexWebResponse response = (ObexWebResponse)request.GetResponse();  
        response.Close();

        return response.StatusCode;                                                 //Como el celular no lee string directamente,el servidor genera un Error
                                                                                    //El modulo HC-05 si recibe string o byte
    }

    }
}
