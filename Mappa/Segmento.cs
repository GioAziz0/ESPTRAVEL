using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mappa
{
    public class Segmento
    {
        public double Peso { get; set; }
        public string Nome { get; set; }

        public Segmento(Punto P1, Punto P2) {
            Nome = P1.Name + "-" + P2.Name;
            Peso = Math.Sqrt(Math.Pow(P1.CordinatePunti.X - P2.CordinatePunti.X, 2) + Math.Pow(P1.CordinatePunti.Y - P2.CordinatePunti.Y, 2));
        }

        public override string ToString()
        {
            return $"Segmento {Nome}";
        }
    }
}
