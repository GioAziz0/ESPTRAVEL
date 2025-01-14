using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mappa
{
    public class Segmento
    {
        public Punto Punto1 { get; set; }
        public Punto Punto2 { get; set; }
        public double Peso { get; set; }

        public Segmento(Punto P1, Punto P2) {
            Punto1 = P1;
            Punto2 = P2;
            double peso = Math.Sqrt(Math.Pow(P1.CordinatePunti.X - P2.CordinatePunti.X, 2) + Math.Pow(P1.CordinatePunti.Y - P2.CordinatePunti.Y, 2));
        }

        public override string ToString()
        {
            return $"Segmento {Punto1.Name}-{Punto2.Name}";
        }
    }
}
