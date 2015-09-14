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
            new FietsSimulator("COM6");
            while (true)
            {
                Thread.Sleep(10);
            }
        }
    }

}
