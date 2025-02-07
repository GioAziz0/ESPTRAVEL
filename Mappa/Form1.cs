using System;
using System.Drawing;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Reflection;
using Newtonsoft.Json;
using Microsoft.VisualBasic.ApplicationServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Diagnostics;
using System.Runtime.InteropServices.Marshalling;
using System.Net.Mime;
using System.Drawing.Configuration;


namespace Mappa
{
    public partial class Form1 : Form
    {
        PictureBox pictureBox;
        Image img;
        Image Immagineoriginale;
        List<Punto> ListaPunti;
        List<Segmento> Segmenti;

        public Form1()
        {
            InitializeComponent();
            pictureBox = new PictureBox();
            ListaPunti = new List<Punto>();
            Segmenti = new List<Segmento>();
            cmbModalita.SelectedIndex = 0;
            abilitazioneControlli(false);
        }

        private void caricaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img != null)
            {
                img.Dispose();
                ListaPunti = new List<Punto>();
                listPoints.Items.Clear();
                listPuntiSeg.Items.Clear();
                listSegmenti.Items.Clear();
                cmbModalita.SelectedIndex = 0;
            }


            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Immagini|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            fileDialog.Title = "Seleziona immagine";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string imgPath = fileDialog.FileName;
                img = Image.FromFile(imgPath);
                Immagineoriginale = Image.FromFile(imgPath);

                int altezza = (int)(ClientSize.Height * 0.9);
                int larghezza = (img.Width * altezza) / img.Height;
                pictureBox.Size = new Size(larghezza, altezza);
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox.Image = img;
                pictureBox.Location = new Point(ClientSize.Width / 2 - larghezza / 2, 44);
                pictureBox.MouseClick += pctClick;
                pictureBox.Visible = true;
                Controls.Add(pictureBox);
                abilitazioneControlli(true);

            }
        }

        private void abilitazioneControlli(bool ablitazione)
        {
            salvaJSONToolStripMenuItem.Enabled = ablitazione;
            apriJSONToolStripMenuItem.Enabled = ablitazione;
            rimuoviToolStripMenuItem.Enabled = ablitazione;
            modalitaToolStripMenuItem.Enabled = ablitazione;
            pnlSegmenti.Visible = ablitazione;
            MaximizeBox = ablitazione;
            MinimizeBox = ablitazione;
            if (ablitazione) WindowState = FormWindowState.Maximized;
        }

        private void pctClick(object sender, MouseEventArgs e)
        {
            // Calcola i fattori di scala per la larghezza e l'altezza
            float scaleX = (float)img.Width / pictureBox.Width;
            float scaleY = (float)img.Height / pictureBox.Height;

            // Calcola la posizione corretta nell'immagine originale
            int positionX = (int)(e.X * scaleX);
            int positionY = (int)(e.Y * scaleY);

            Punto PuntoClick = new Punto(new Point(positionX, positionY), TrovaNome(ListaPunti.Count()));

            if (cmbModalita.SelectedIndex == 0)
            {
                ListaPunti.Add(PuntoClick);
                listPoints.Items.Add(PuntoClick);
                using (Graphics g = pictureBox.CreateGraphics())
                {
                    // Calcola la scala corrente per l'adattamento dell'immagine
                    float scaleX1 = (float)pictureBox.Width / img.Width;
                    float scaleY1 = (float)pictureBox.Height / img.Height;

                    // Dimensione adattata del punto
                    int basePointSize = 30; // Dimensione base del punto
                    int pointSize = (int)(basePointSize * Math.Min(scaleX1, scaleY1));

                    // Calcolo delle coordinate del punto scalate
                    float x = PuntoClick.CordinatePunti.X * scaleX1 - pointSize / 2;
                    float y = PuntoClick.CordinatePunti.Y * scaleY1 - pointSize / 2;

                    // Disegna il punto arancione come quadrato
                    g.FillRectangle(Brushes.Red, x - 1, y - 1, pointSize, pointSize);
                    Font font = new Font("Arial", 20, FontStyle.Bold);
                    Brush brush = Brushes.Black;
                    g.DrawString(PuntoClick.Name, font, brush, new PointF(x, y-10));
                }
                
            }
            else if (cmbModalita.SelectedIndex == 1)
            { 
                var ListaPuntiOrdinati = ListaPunti.OrderBy(p => Distanza(p, PuntoClick)).ToList();
                Punto puntoPiuVicino = ListaPuntiOrdinati.First();
                listPuntiSeg.Items.Add(puntoPiuVicino);
                
                if (listPuntiSeg.Items.Count == 2)
                {
                    if (listPuntiSeg.Items[0] == listPuntiSeg.Items[1])
                    {
                        MessageBox.Show("I punti selezionti sono uguali");
                        listPuntiSeg.Items.Clear();
                        return;
                    }
                    Punto punto1 = listPuntiSeg.Items[0] as Punto;
                    Punto punto2 = listPuntiSeg.Items[1] as Punto;
                    bool esiste = Segmenti.Any(segmento => segmento.Nome1 + segmento.Nome2 == punto1.Name + punto2.Name);
                    if (esiste)
                    {
                        MessageBox.Show("Esiste gia un segmento con questyi punti");
                        listPuntiSeg.Items.Clear();
                        return;
                    }
                    Segmento segTemp = new Segmento(listPuntiSeg.Items[0] as Punto, listPuntiSeg.Items[1] as Punto);
                    // Aggiunge il nuovo segmento
                    drawSegment();
                    listSegmenti.Items.Add(segTemp);
                    Segmenti.Add(segTemp);
                    listPuntiSeg.Items.Clear();
                }
                else
                {
                    using (Graphics g = pictureBox.CreateGraphics())
                    {
                        // Calcola la scala corrente per l'adattamento dell'immagine
                        float scaleX1 = (float)pictureBox.Width / img.Width;
                        float scaleY1 = (float)pictureBox.Height / img.Height;

                        // Dimensione adattata del punto
                        int basePointSize = 30; // Dimensione base del punto
                        int pointSize = (int)(basePointSize * Math.Min(scaleX1, scaleY1));

                        // Calcolo delle coordinate del punto scalate
                        float x = puntoPiuVicino.CordinatePunti.X * scaleX1 - pointSize / 2;
                        float y = puntoPiuVicino.CordinatePunti.Y * scaleY1 - pointSize / 2;

                        // Disegna il punto arancione come quadrato
                        g.FillRectangle(Brushes.Green, x - 1, y - 1, pointSize, pointSize);
                    }
                }

            }
        }

        public string TrovaNome(int indice)
        {
            string nome;
            indice++;
            do
            {
                nome = string.Empty;
                int tempIndice = indice;

                // Converte l'indice in un nome alfabetico
                while (tempIndice > 0)
                {
                    tempIndice--;
                    nome = (char)('A' + (tempIndice % 26)) + nome;
                    tempIndice /= 26;
                }

                indice++;
            }
            while (ListaPunti.Any(x => x.Name == nome));

            return nome;
        }

        private void drawSegment()
        {
            using (Graphics g = Graphics.FromImage(img))
            {
                if (listPuntiSeg.Items.Count == 2)
                {
                    Punto punto1 = listPuntiSeg.Items[0] as Punto;
                    Punto punto2 = listPuntiSeg.Items[1] as Punto;
                    Pen pen = new Pen(Color.FromArgb(0, 0, 255), 3);  // Dimensione penna adatta
                    g.DrawLine(pen, punto1.CordinatePunti, punto2.CordinatePunti);
                }
            }

            pictureBox.Image = img;
            DisegnaPunti();
        }

        private float Distanza(Punto p1, Punto p2)
        {
            return (float)Math.Sqrt(Math.Pow(p1.CordinatePunti.X - p2.CordinatePunti.X, 2) + Math.Pow(p1.CordinatePunti.Y - p2.CordinatePunti.Y, 2));
        }

        private void DisegnaPunti()
        {
            using (Graphics gpr = Graphics.FromImage(img))
            {
                // Disegna ogni punto dalla lista
                foreach (Punto p in ListaPunti)
                {
                    int pointSize = 30; // Dimensione del punto da disegnare
                    gpr.FillRectangle(Brushes.Red, p.CordinatePunti.X - pointSize / 2, p.CordinatePunti.Y - pointSize / 2, pointSize, pointSize);
                    Font font = new Font("Arial", 20, FontStyle.Bold);
                    Brush brush = Brushes.Black;
                    gpr.DrawString(p.Name, font, brush, new PointF(p.CordinatePunti.X, p.CordinatePunti.Y - 10));
                }
            }

            pictureBox.Image = img;
            pictureBox.Refresh();
        }
        public void DisegnaSegmenti()
        {
            using (Graphics gpr = Graphics.FromImage(img))
            {
                // Disegna ogni punto dalla lista
                foreach (Segmento segmento in Segmenti)
                {
                    Pen pen = new Pen(Color.FromArgb(0, 0, 255), 3);  // Dimensione penna adatta
                    gpr.DrawLine(pen, segmento.punto1.CordinatePunti, segmento.punto2.CordinatePunti);
                }
            }

            pictureBox.Image = img;
            pictureBox.Refresh();
        }

        private void Form1_ClientSizeChanged(object sender, EventArgs e)
        {
            refresh();
        }

        private void salvaJSONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "JSON|*.json";
                saveFileDialog.Title = "Salva punti in JSON";
                saveFileDialog.FileName = "ListaPunti";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    filePath = filePath.Remove(filePath.Length - 5);
                    SavePointsGioAziz(filePath + "_GioAziz.json");
                    SavePoints(filePath + "_ListaPunti.json");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SavePointsGioAziz(string filePath)
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }
            // Serializza i punti in JSON
            List<List<string>> temp = new List<List<string>>();
            foreach (Segmento segmento in listSegmenti.Items)
            {
                temp.Add(segmento.ToList());
            }
            string stringJson = JsonConvert.SerializeObject(temp);
            File.WriteAllText(filePath, stringJson);
        }

        private void SavePoints(string filePath)
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }
            else
            {
                //avvisa l'utente che il file esiste gi� e chiede se vuole sovrascriverlo
                DialogResult dialogResult = MessageBox.Show("Il file esiste gi�, vuoi sovrascriverlo?", "Attenzione", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    //richiama la funzione per salvare (pu� scegliere un'altro nome
                    salvaJSONToolStripMenuItem_Click(null, null);
                    return;
                }
            }
            // Serializza i punti in JSON
            string stringJson = JsonConvert.SerializeObject(listPoints.Items);
            File.WriteAllText(filePath, stringJson);
        }

        private void apriJSONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "JSON|*.json";
                openFileDialog.Title = "Apri file JSON";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = openFileDialog.FileName;
                    string destinazioneCartella = "C:\\Users\\gamba.21149\\source\\repos\\Mappa1\\Mappa\\bin\\Debug\\net8.0-windows";
                    if (File.Exists(fileName) && Directory.Exists(destinazioneCartella))
                    {
                        string nomeFile = Path.GetFileName(fileName);
                        string destinazioneCompleta = Path.Combine(destinazioneCartella, nomeFile);
                        File.Move(fileName, destinazioneCompleta);
                        if (File.Exists(destinazioneCompleta))
                        {
                            MessageBox.Show("File spostato correttamente in:\n" + destinazioneCartella);
                        }
                        else
                        {
                            throw new Exception("Impossibile spostare il file.");
                        }
                    }
                    else
                    {
                        throw new Exception("Percorso non valido.");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadPoints()
        {
            /*if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                listPoints.Items.Clear();

                // Deserializza la lista di punti dal JSON
                var pointsList = JsonConvert.DeserializeObject<List<Point>>(json);

                if (pointsList != null)
                {
                    foreach (var point in pointsList)
                    {
                        listPoints.Items.Add(point);
                    }
                }

                // Dopo aver caricato i punti, ridisegnali
                DisegnaPunti();
                refresh();
            }*/
        }

        private void rimuoviToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (listPoints.SelectedItems.Count >= 1)
                {
                    int index = listPoints.SelectedIndex;
                    Punto puntoRimuovere = listPoints.Items[index] as Punto;

                    listPoints.Items.RemoveAt(index);
                    ListaPunti.Remove(puntoRimuovere);
                    Segmenti.RemoveAll(seg => seg.Nome1 == puntoRimuovere.Name || seg.Nome2 == puntoRimuovere.Name);
                    listSegmenti.Items.Clear();
                    foreach(Segmento segmento in Segmenti)
                    {
                        listSegmenti.Items.Add(segmento);
                    }
                    Bitmap immagineOrg = new Bitmap(Immagineoriginale);
                    img = immagineOrg;

                    DisegnaPunti();
                    DisegnaSegmenti();
                }
                else
                {
                    throw new Exception("Seleziona almeno un punto da rimuovere");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore nella rimozione dalla lista. Errore: " + ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void refresh()
        {
            int altezza = (int)(ClientSize.Height * 0.9);
            int larghezza = (img.Width * altezza) / img.Height;
            pictureBox.Size = new Size(larghezza, altezza);
            pictureBox.Location = new Point(ClientSize.Width / 2 - larghezza / 2, 44);
            pnlSegmenti.Location = new Point(ClientSize.Width - 160, 37);

            DisegnaPunti(); // Ridisegna i punti quando la finestra viene ridimensionata
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbModalita.SelectedIndex = 0;
        }

    }
}

