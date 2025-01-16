using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mappa
{
    public class Segmento
    {
       
        public string Nome1 { get; set; }
        public string Nome2 { get; set; }
        public double Peso { get; set; }

        public Segmento(Punto P1, Punto P2) {
            Nome1 = P1.Name;
            Nome2 = P2.Name;
            Peso = Math.Sqrt(Math.Pow(P1.CordinatePunti.X - P2.CordinatePunti.X, 2) + Math.Pow(P1.CordinatePunti.Y - P2.CordinatePunti.Y, 2));
        }

        public override string ToString()
        {
            return $"Segmento {Nome1}-{Nome2}";
        }

        public List<string> ToList() { 
            List<string> ciao = new List<string>();
            ciao.Add(Nome1);
            ciao.Add(Nome2);
            ciao.Add(Peso.ToString());
            return ciao;
        }
    }
}
