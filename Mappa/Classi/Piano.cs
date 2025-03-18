using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mappa.Classi
{
    public class Piano
    {
        public string Name { get; set; }
        public List<Segmento> Segmenti { get; set; }
        public List<Punto> Punti { get; set; }

        public Piano(string name, List<Segmento> segmenti, List<Punto> punti) {
            Name = name;
            Segmenti = segmenti;
            Punti = punti;
        }
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
