using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mappa
{
    public class Punto
    {
        public string Name {  get; set; }

        public Point CordinatePunti { get; set; }

        public Punto(Point punto, string name) {
            CordinatePunti = punto;
            Name = name;
        }
        public override string ToString()
        {
            return $"Punto: {Name}, Cordinate: ({CordinatePunti.X}, {CordinatePunti.Y})";
        }
    }
}
