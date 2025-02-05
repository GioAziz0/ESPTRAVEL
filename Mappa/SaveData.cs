using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mappa
{
    public class SaveData
    {
        public List<Punto> Punti { get; set; }
        public List<Segmento> Segmenti { get; set; }

        public SaveData() {
            Punti = new List<Punto>();
            Segmenti = new List<Segmento>();
        }

        public SaveData(List<Punto> punti, List<Segmento> segmenti)
        {
            Punti = punti;
            Segmenti = segmenti;
        }
    }
}
