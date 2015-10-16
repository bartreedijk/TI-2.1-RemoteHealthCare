using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Server.lib
{
    class SSLCrypto
    {
        public static void CreateSelfSignedCert()
        {
            if (!File.Exists("testcert.pfx"))
            {
                byte[] c = SelfSignedCertificate.CreateSelfSignCertificatePfx(
            "CN=brdk.nl", //host name
            DateTime.Parse("2015-01-01"), //not valid before
            DateTime.Parse("2025-01-01"), //not valid after
            "jancoow"); //password to encrypt key file

                using (BinaryWriter binWriter = new BinaryWriter(
                    File.Open(@"testcert.pfx", FileMode.Create)))
                {
                    binWriter.Write(c);
                }
            }
        }

        public static X509Certificate LoadCert()
        {
            X509Certificate cert = new X509Certificate2(
                            @"testcert.pfx",
                            "jancoow");
            return cert;
        }

    }
}
