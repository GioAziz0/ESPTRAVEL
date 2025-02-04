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

namespace Mappa
{
    public partial class Form1 : Form
    {
        private PictureBox pictureBox;
        private Image img;
        private List<Punto> ListaPunti;
        List<Punto> PuntiSegmento;


        public Form1()
        {
            InitializeComponent();
            pictureBox = new PictureBox();
            ListaPunti = new List<Punto>();
            PuntiSegmento = new List<Punto>();
            cmbModalita.SelectedIndex = 0;
            abilitazioneControlli(false);
        }

        private void caricaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img != null)
            {
                img.Dispose();
                ListaPunti = new List<Punto>();
                PuntiSegmento = new List<Punto>();
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

        private void abilitazioneControlli(bool ablilitazione)
        {
            salvaJSONToolStripMenuItem.Enabled = ablilitazione;
            apriJSONToolStripMenuItem.Enabled = ablilitazione;
            rimuoviToolStripMenuItem.Enabled = ablilitazione;
            modalitaToolStripMenuItem.Enabled = ablilitazione;
            pnlSegmenti.Visible = ablilitazione;
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
            int pointSize = 30;

            if (cmbModalita.SelectedIndex == 0)
            {
                ListaPunti.Add(PuntoClick);
                listPoints.Items.Add(PuntoClick);
                DisegnaPunti();
            }
            else if (cmbModalita.SelectedIndex == 1)
            {
                ListaPunti = ListaPunti.OrderBy(p => Distanza(p, PuntoClick)).ToList();
                Punto puntoPiuVicino = ListaPunti.First();
                listPuntiSeg.Items.Add(puntoPiuVicino);
                PuntiSegmento.Add(puntoPiuVicino);
                if (PuntiSegmento.Count() == 2)
                {
                    drawSegment();
                    Segmento seg = new Segmento(PuntiSegmento[0], PuntiSegmento[1]);
                    listSegmenti.Items.Add(seg);
                    listPuntiSeg.Items.Clear();
                    PuntiSegmento.Clear();
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
                if (PuntiSegmento.Count == 2)
                {
                    Pen pen = new Pen(Color.FromArgb(0, 0, 255), 3);  // Dimensione penna adatta
                    g.DrawLine(pen, PuntiSegmento[0].CordinatePunti, PuntiSegmento[1].CordinatePunti);
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
                foreach (Punto p in listPoints.Items)
                {
                    int pointSize = 30; // Dimensione del punto da disegnare
                    gpr.FillRectangle(Brushes.Red, p.CordinatePunti.X - pointSize / 2, p.CordinatePunti.Y - pointSize / 2, pointSize, pointSize);
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

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    SavePoints(filePath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SavePoints(string filePath)
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
                    // Rimuovi il punto dalla lista
                    int index = listPoints.SelectedIndex;
                    listPoints.Items.RemoveAt(index);
                    DisegnaPunti();
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

