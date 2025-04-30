using System;
using System.Collections.Generic;
using System.Drawing; // Aggiunto per gestire le immagini
using System.IO;
using System.Linq;

namespace Mappa.Classi
{
    public class SalvaJson
    {
        public List<SavePiano> piani { get; set; } = new List<SavePiano>();
    }

    public class SavePiano()
    {

        public string Name { get; set; }
        public int Level { get; set; } 
        public string image { get; set; }
        public List<Segmento> arcs { get; set; } = new List<Segmento>();
        public List<Punto> points { get; set; } = new List<Punto>();
        public string ConvertImageToBase64(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat); // Salva l'immagine nel MemoryStream
                byte[] imageBytes = ms.ToArray(); // Converte l'immagine in byte[]
                return Convert.ToBase64String(imageBytes); // Codifica in Base64
            }
        }
    }
}
