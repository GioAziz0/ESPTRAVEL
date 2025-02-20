using System;
using System.Collections.Generic;
using System.Drawing; // Aggiunto per gestire le immagini
using System.IO;
using System.Linq;

namespace Mappa.Classi
{
    public class SaveJson
    {
        public string image { get; set; }
        public List<Segmento> arcs { get; set; } = new List<Segmento>();
        public List<Punto> points { get; set; } = new List<Punto>();

        public SaveJson(string imageUrl)
        {
            image = ConvertImageToBase64(imageUrl);
        }

        public string ConvertImageToBase64(string imagePath)
        {
            using (Image image = Image.FromFile(imagePath))
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
}
