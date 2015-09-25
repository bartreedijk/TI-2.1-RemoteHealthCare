using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace FietsSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            //show available ports
            Console.WriteLine("Availabe Comports: \n" + String.Join(" \n", SerialPort.GetPortNames()));

            //ask for port
            Console.WriteLine("Enter Comport:");

            //start simulator on entered port 
            new FietsSimulator(Console.ReadLine());
            Console.WriteLine("Started Simulator");
            while (true)
                Thread.Sleep(10);
            
        }
    }

    
}
