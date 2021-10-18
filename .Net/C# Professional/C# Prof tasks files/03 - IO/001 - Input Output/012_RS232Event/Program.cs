using System;
using System.IO.Ports;
using System.Threading;

namespace ConsoleApplication1
{
    class Program
    {

        static void Main(string[] args)
        {
            var serialPort10 = new SerialPort("COM10");

            serialPort10.DataReceived +=  new SerialDataReceivedEventHandler(SerialPort10DataReceived);
            serialPort10.Open();
            //DataReceived event handler will execute on other thread
            Thread.Sleep(50000);
            
        }

        static void SerialPort10DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            var serialPort = sender as SerialPort;
            if (serialPort == null) return;
      
            string received = serialPort.ReadExisting();
            Console.WriteLine("COM10 received: {0}",received);
        }
    }
}
