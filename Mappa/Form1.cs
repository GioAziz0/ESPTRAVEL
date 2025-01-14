using System;
using System.Drawing;
using System.IO; 
using System.Text.Json;  
using System.Windows.Forms;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Mappa
{
    public partial class Form1 : Form
    {
        private PictureBox pictureBox;
        private Image img; // Usa Bitmap per una modifica efficace dell'immagine
        private Bitmap imgBitmap; // Bitmap modificabile
        private string filePath;
        private List<Point> puntiSelezionati = new List<Point>();

        public Form1()
        {
            InitializeComponent();
            pictureBox = new PictureBox();
            cmbModalita.SelectedIndex = 0;
            abilitazioneControlli(false);
        }

        private void caricaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Immagini|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            fileDialog.Title = "Seleziona immagine";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string imgPath = fileDialog.FileName;
                img = Image.FromFile(imgPath);

                // Crea una Bitmap modificabile per il disegno
                imgBitmap = new Bitmap(img);

                int altezza = (int)(ClientSize.Height * 0.9);
                int larghezza = (img.Width * altezza) / img.Height;
                pictureBox.Size = new Size(larghezza, altezza);
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox.Image = imgBitmap; // Usa la bitmap modificata
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
            Point pointclick = new Point(positionX, positionY);
            int pointSize = 30;

            if (cmbModalita.SelectedIndex == 0)
            {
                listPoints.Items.Add(new Point(positionX, positionY));

                DisegnaPunti();
            }
            else if (cmbModalita.SelectedIndex == 1)
            {
                List<Point> punti = listPoints.Items.Cast<Point>().ToList();
                punti = punti.OrderBy(p => Distanza(p, pointclick)).ToList();
                Point puntoPiuVicino = punti.First();
                listSegmenti.Items.Add(puntoPiuVicino);
                
                foreach (Point p in punti)
                {
                    if (p == puntoPiuVicino)
                    {
                        listPoints.Items.Remove(p);

                        puntiSelezionati.Add(p);

                        if (puntiSelezionati.Count == 2)
                        {
                            break;
                        }

                        Bitmap tempBitmap = new Bitmap(imgBitmap);

                        using (Graphics gpr = Graphics.FromImage(tempBitmap))
                        {
                            
                            //int pointSize = 30; // Dimensione del punto da disegnare
                            gpr.FillRectangle(Brushes.Orange, p.X - pointSize / 2, p.Y - pointSize / 2, pointSize, pointSize);
                            
                            foreach (Point p1 in listPoints.Items)
                            {
                                gpr.FillRectangle(Brushes.Red, p1.X - pointSize / 2, p1.Y - pointSize / 2, pointSize, pointSize);
                            }
                        }

                        // Aggiorna l'immagine nel PictureBox
                        pictureBox.Image = new Bitmap(tempBitmap);
                        pictureBox.Refresh(); // Rendi visibile l'aggiornamento

                        

                    }
                    break;
                }
                //listPoints.Items.Add(puntoPiuVicino);
                

                if (listSegmenti.Items.Count == 2)
                {
                    foreach (Point p in puntiSelezionati)
                    {
                        listPoints.Items.Add(p);
                    }
                    puntiSelezionati.Clear();

                    drawSegment();
                    listSegmenti.Items.Clear();
                }
            }
        }

        private void drawSegment()
        {
            using (Graphics g = Graphics.FromImage(imgBitmap))
            {
                List<Point> punti = listSegmenti.Items.Cast<Point>().ToList();

                if (punti.Count == 2)
                {
                    Pen pen = new Pen(Color.FromArgb(0, 0, 255), 3);  // Dimensione penna adatta
                    g.DrawLine(pen, punti[0], punti[1]);
                }
            }

            // Aggiorna l'immagine nel PictureBox con imgBitmap che contiene il segmento disegnato
            pictureBox.Image = new Bitmap(imgBitmap);
            DisegnaPunti();
        }

        private float Distanza(Point p1, Point p2)
        {
            return (float)Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }

        private void DisegnaPunti()
        {
            // Crea una nuova bitmap modificabile
            Bitmap tempBitmap = new Bitmap(imgBitmap);

            using (Graphics gpr = Graphics.FromImage(tempBitmap))
            {
                // Disegna ogni punto dalla lista
                foreach (Point p in listPoints.Items)
                {
                    int pointSize = 30; // Dimensione del punto da disegnare
                    gpr.FillRectangle(Brushes.Red, p.X - pointSize / 2, p.Y - pointSize / 2, pointSize, pointSize);
                }
            }

            // Aggiorna l'immagine nel PictureBox
            pictureBox.Image = new Bitmap(tempBitmap);
            pictureBox.Refresh(); // Rendi visibile l'aggiornamento
        }

        private void Form1_ClientSizeChanged(object sender, EventArgs e)
        {
            // Rivedere la posizione e le dimensioni del PictureBox
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
                    filePath = saveFileDialog.FileName;
                    SavePoints();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SavePoints()
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }
            // Serializza i punti in JSON
            string stringJson = JsonSerializer.Serialize(listPoints.Items);
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
                    filePath = openFileDialog.FileName;
                    LoadPoints();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /*private void LoadPoints()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                listPoints.Items.Clear();
                List<Point[]> temp = JsonSerializer.Deserialize<Point[]>(json);
                listPoints.Items.Add(JsonSerializer.Deserialize<Point[]>(json));

                // Dopo aver caricato i punti, ridisegnali
                DisegnaPunti();
            }
        }*/

        private void LoadPoints()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                listPoints.Items.Clear();

                // Deserializza la lista di punti dal JSON
                var pointsList = JsonSerializer.Deserialize<List<Point>>(json);

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
            }
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
            pnlSegmenti.Location = new Point(ClientSize.Width -160, 37);

            DisegnaPunti(); // Ridisegna i punti quando la finestra viene ridimensionata
        }
    }
}

