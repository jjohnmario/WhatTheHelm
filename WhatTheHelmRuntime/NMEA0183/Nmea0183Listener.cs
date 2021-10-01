using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using WhatTheHelmRuntime.NMEA0183.Sentences;

namespace WhatTheHelmRuntime.NMEA0183
{

    public class Nmea0183Listener : TcpListener
    {
        public event EventHandler<Nmea0183Sentence> NewMessage;

        public Nmea0183Listener(string ipAddress, int port) : base(IPAddress.Parse(ipAddress),port)
        {
         
        }

        public void ListenAsync()
        {
            Task.Run(() =>
           {
               // Buffer for reading data
               Byte[] bytes = new Byte[256];
               String data = null;

               Start();

               // Enter the listening loop.
               while (true)
               {
                   // Perform a blocking call to accept requests.
                   // You could also use server.AcceptSocket() here.
                   TcpClient client = AcceptTcpClient();

                   data = null;

                   // Get a stream object for reading and writing
                   NetworkStream stream = client.GetStream();

                   int i;

                   // Loop to receive all the data sent by the client.
                   while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                   {
                       // Translate data bytes to a ASCII string.
                       data = Encoding.ASCII.GetString(bytes, 0, i);

                       // Process the data sent by the client.
                       data = data.ToUpper();

                       string[] dataArray = data.Split(',');
                       var sentence = Nmea0183Sentence.GetSentenceType(dataArray[0].Substring(1));
                       sentence = sentence.DeserializeFields(data);
                       if (NewMessage != null)
                           NewMessage.Invoke(this, sentence);               
                   }
               }
           });
        }
    }
}
