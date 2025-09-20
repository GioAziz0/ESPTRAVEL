using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mappa
{
    public class DifficoltaSegmento
    {
        public bool AtoB_open { get; set; }
        public bool BtoA_open { get; set; }
        //public double AtoB_peso { get; set; }
        //public double BtoA_peso { get; set; }
        public double BtoA_fattore { get; set; }
        public double AtoB_fattore { get; set; }

        public DifficoltaSegmento()
        {
            AtoB_open = true;
            BtoA_open = true;
            //AtoB_peso = 1;
            //BtoA_peso = 1;
            AtoB_fattore = 1;
            BtoA_fattore = 1;
        }
    }
}
