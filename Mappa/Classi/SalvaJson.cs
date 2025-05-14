using System;
using System.Collections;
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
        public List<List<string>> arcs { get; set; } = new List<List<string>>();
        public List<Punto> points { get; set; } = new List<Punto>();
        public List<CollegaPunti> CollegaPunti { get; set; } = new List<CollegaPunti>();
        public string ConvertImageToBase64(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat); // Salva l'immagine nel MemoryStream
                byte[] imageBytes = ms.ToArray(); // Converte l'immagine in byte[]
                return Convert.ToBase64String(imageBytes); // Codifica in Base64
            }
        }

        public List<Segmento> CreaSegmenti(List<List<string>> lista)
        {
            var segmenti = new List<Segmento>();

            foreach (var item in lista)
            {
                if (item.Count != 3)
                    continue; // oppure throw exception

                string nome1 = item[0];
                string nome2 = item[1];
                if (!double.TryParse(item[2], out double peso))
                    peso = 0; // oppure gestisci errore

                Punto punto1 = points.FirstOrDefault(p => p.Name == nome1);
                Punto punto2 = points.FirstOrDefault(p => p.Name == nome2);

                segmenti.Add(new Segmento(punto1, punto2));
            }
            return segmenti;
        }
    }
}
