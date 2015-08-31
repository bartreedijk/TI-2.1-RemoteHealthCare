using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fietsclient
{
    class KettlerBikeComm
    {

        private static KettlerBikeComm _instance;
        public static KettlerBikeComm Instance
        {
            get { return _instance ?? (_instance = new KettlerBikeComm()); }
        }

        private KettlerBikeComm()
        {

        }
    }
}
