using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FietsLibrary;

namespace ServerV2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Server wordt gestart");
            SSLCrypto.CreateSelfSignedCert();
            new AppGlobal();
        }
    }
}
