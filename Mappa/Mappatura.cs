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
using Mappa.Classi;
using System.Windows.Input;


namespace Mappa
{
    public partial class Mappatura : Form
    {
        public Piano piano { get; private set; }
        PictureBox pictureBox;
        Image img;
        Image immagineOriginale;
        List<Punto> listaPunti;
        List<Segmento> listaSegmenti;
        string URL;
        List<int> livelliUtilizzati;

        public Mappatura(List<int> livelliUtilizzati)
        {
            InitializeComponent();
            inizializzazioneInComune();
            piano = new Piano("", new List<Segmento>(), new List<Punto>(), null, int.MinValue, new List<CollegaPunti>());
            this.livelliUtilizzati = new List<int>(livelliUtilizzati);
            abilitazioneControlli(false);
        }

        public Mappatura(Piano pianoOriginale, List<int> livelliUtilizzati)
        {
            InitializeComponent();
            inizializzazioneInComune();
            piano = new Piano(pianoOriginale.Name,
                     new List<Segmento>(pianoOriginale.Segmenti),
                     new List<Punto>(pianoOriginale.Punti),
                     pianoOriginale.Img, pianoOriginale.Level,
                     pianoOriginale.CollegaPunti);
            CaricaPiano();
            txtLevel.Text = piano.Level.ToString();
        }

        private void inizializzazioneInComune()
        {
            this.KeyPreview = true; // Abilita la cattura degli eventi da tastiera da parte del form
            pictureBox = new PictureBox();
            listaPunti = new List<Punto>();
            listaSegmenti = new List<Segmento>();
            //cmbModalita.SelectedIndex = 0;
            DoubleBuffered = true;
            this.livelliUtilizzati = new List<int>();
            this.livelliUtilizzati = livelliUtilizzati;
        }

        private void CaricaPiano()
        {
            immagineOriginale = piano.Img;
            img = new Bitmap(immagineOriginale);

            int altezza = (int)(ClientSize.Height * 0.9);
            int larghezza = (img.Width * altezza) / img.Height;
            pictureBox.Size = new Size(larghezza, altezza);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.Image = img;
            pictureBox.Location = new Point(ClientSize.Width / 2 - larghezza / 2, 44);
            pictureBox.MouseClick += pctClick;
            pictureBox.MouseWheel += gestioneMouse;
            pictureBox.Visible = true;
            Controls.Add(pictureBox);
            abilitazioneControlli(true);

            txtNomePiano.Text = piano.Name;
            listaPunti = piano.Punti;
            foreach (var punto in piano.Punti)
            {
                listBoxPunti.Items.Add(punto);
            }
            listaSegmenti = piano.Segmenti;
            foreach (var segmento in listaSegmenti)
            {
                listBoxSegmenti.Items.Add(segmento);
            }

            DisegnaPunti();
            DisegnaSegmenti();
        }

        private void caricaToolStripMenuItem_Click(object sender, EventArgs e)  //carica immagine della mappa
        {
            if (img != null)    //se è gia stata caricata un'immagine (resetta la mappa)
            {
                img.Dispose();
                listaPunti = new List<Punto>();
                listBoxPunti.Items.Clear();
                listBoxPuntiSeg.Items.Clear();
                listBoxSegmenti.Items.Clear();
                //cmbModalita.SelectedIndex = 0;
                btnPuntoMode.Checked = true;
            }

            // Apre la finestra di dialogo per selezionare l'immagine

            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Immagini|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            fileDialog.Title = "Seleziona immagine";

            // Se l'utente seleziona un'immagine, viene renderizzata nel PictureBox

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string imgPath = fileDialog.FileName;
                URL = imgPath;
                immagineOriginale = Image.FromFile(imgPath);
                img = new Bitmap(immagineOriginale);

                int altezza = (int)(ClientSize.Height * 0.9);
                int larghezza = (img.Width * altezza) / img.Height;
                pictureBox.Size = new Size(larghezza, altezza);
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox.Image = img;
                pictureBox.Location = new Point(ClientSize.Width / 2 - larghezza / 2, 44);
                pictureBox.MouseClick += pctClick;
                pictureBox.MouseWheel += gestioneMouse;
                pictureBox.Visible = true;
                Controls.Add(pictureBox);
                abilitazioneControlli(true);

            }
        }

        private void abilitazioneControlli(bool ablitazione)
        {
            //salvaJSONToolStripMenuItem.Enabled = ablitazione;
            //apriJSONToolStripMenuItem.Enabled = ablitazione;
            rimuoviToolStripMenuItem.Enabled = ablitazione;
            modalitaToolStripMenuItem.Enabled = ablitazione;
            saveConfigToolStripMenuItem.Enabled = ablitazione;
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

            Punto PuntoClick = new Punto(new Point(positionX, positionY), TrovaNome());

            if (/*cmbModalita.SelectedIndex == 0*/btnPuntoMode.Checked)
            {
                listaPunti.Add(PuntoClick);
                listBoxPunti.Items.Add(PuntoClick);

                DisegnaPunto(PuntoClick.CordinatePunti.X, PuntoClick.CordinatePunti.Y, PuntoClick.Name, Brushes.Red);

                //pictureBox.Image = img;
                pictureBox.Refresh();
            }
            else if (/*cmbModalita.SelectedIndex == 1*/btnSegmentoMode.Checked)
            {
                var listaPuntiOrdinati = listaPunti.OrderBy(p => Distanza(p, PuntoClick)).ToList();
                Punto puntoPiuVicino = listaPuntiOrdinati.First();
                listBoxPuntiSeg.Items.Add(puntoPiuVicino);

                if (listBoxPuntiSeg.Items.Count == 2)
                {
                    if (listBoxPuntiSeg.Items[0] == listBoxPuntiSeg.Items[1])
                    {
                        MessageBox.Show("I punti selezionti sono uguali");
                        listBoxPuntiSeg.Items.Clear();
                        DisegnaPunti();
                        return;
                    }
                    Punto punto1 = listBoxPuntiSeg.Items[0] as Punto;
                    Punto punto2 = listBoxPuntiSeg.Items[1] as Punto;
                    bool esiste = listaSegmenti.Any(segmento =>
                        (segmento.Nome1 + segmento.Nome2 == punto1.Name + punto2.Name) ||
                        (segmento.Nome1 + segmento.Nome2 == punto2.Name + punto1.Name));

                    if (esiste)
                    {
                        MessageBox.Show("Esiste gia un segmento con questi punti");
                        listBoxPuntiSeg.Items.Clear();
                        DisegnaPunti();
                        return;
                    }
                    Segmento segTemp = new Segmento(listBoxPuntiSeg.Items[0] as Punto, listBoxPuntiSeg.Items[1] as Punto);
                    // Aggiunge il nuovo segmento
                    drawSegment();
                    listBoxSegmenti.Items.Add(segTemp);
                    listaSegmenti.Add(segTemp);
                    listBoxPuntiSeg.Items.Clear();

                    if (chSegmentiContinui.Checked)
                    {
                        listBoxPuntiSeg.Items.Add(punto2);
                        DisegnaPunto(punto2.CordinatePunti.X, punto2.CordinatePunti.Y, punto2.Name, Brushes.Green);
                        pictureBox.Refresh();
                    }
                }
                else
                {
                    DisegnaPunto(puntoPiuVicino.CordinatePunti.X, puntoPiuVicino.CordinatePunti.Y, puntoPiuVicino.Name, Brushes.Green);
                    pictureBox.Refresh();

                }

            }
        }

        public string TrovaNome()
        {
            string nome;
            int indice = 1;
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
            while (listaPunti.Any(x => x.Name == nome));

            return nome;
        }
        private void DisegnaPunto(int x_, int y_, string nome, Brush colore)
        {
            using (Graphics gpr = Graphics.FromImage(img))
            {
                int pointSize = 70; // Dimensione del punto da disegnare
                gpr.FillRectangle(colore, x_ - pointSize / 2, y_ - pointSize / 2, pointSize, pointSize);
                Font font = new Font("Arial", 60, FontStyle.Bold);
                Brush brush = Brushes.Black;
                gpr.DrawString(nome, font, brush, new PointF(x_, y_ - 10));
            }
        }

        private void drawSegment()
        {
            using (Graphics g = Graphics.FromImage(img))
            {
                if (listBoxPuntiSeg.Items.Count == 2)
                {
                    Punto punto1 = listBoxPuntiSeg.Items[0] as Punto;
                    Punto punto2 = listBoxPuntiSeg.Items[1] as Punto;
                    Pen pen = new Pen(Color.FromArgb(0, 0, 255), 10);  // Dimensione penna adatta
                    g.DrawLine(pen, punto1.CordinatePunti, punto2.CordinatePunti);
                }
            }

            //pictureBox.Image = img;
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
                foreach (Punto p in listaPunti)
                {
                    DisegnaPunto(p.CordinatePunti.X, p.CordinatePunti.Y, p.Name, Brushes.Red);
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
                foreach (Segmento segmento in listaSegmenti)
                {
                    Pen pen = new Pen(Color.FromArgb(0, 0, 255), 10);  // Dimensione penna adatta
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

        private void refresh()
        {
            try
            {
                int altezza = (int)(ClientSize.Height * 0.9);
                int larghezza = (img.Width * altezza) / img.Height;
                pictureBox.Size = new Size(larghezza, altezza);
                pictureBox.Location = new Point(ClientSize.Width / 2 - larghezza / 2, 44);
                pnlSegmenti.Location = new Point(ClientSize.Width - 160, 37);

                DisegnaPunti(); // Ridisegna i punti quando la finestra viene ridimensionata

                pictureBox.Image = img;
            }
            catch { }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //cmbModalita.SelectedIndex = 0;
        }

        private void rimuoviPuntoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBoxPunti.SelectedItems.Count >= 1)
                {
                    int index = listBoxPunti.SelectedIndex;
                    Punto puntoRimuovere = listBoxPunti.Items[index] as Punto;

                    listBoxPunti.Items.RemoveAt(index);
                    listaPunti.Remove(puntoRimuovere);
                    listaSegmenti.RemoveAll(seg => seg.Nome1 == puntoRimuovere.Name || seg.Nome2 == puntoRimuovere.Name);
                    listBoxSegmenti.Items.Clear();
                    foreach (Segmento segmento in listaSegmenti)
                    {
                        listBoxSegmenti.Items.Add(segmento);
                    }
                    Bitmap immagineOrg = new Bitmap(immagineOriginale);
                    img = immagineOrg;

                    DisegnaPunti();
                    DisegnaSegmenti();

                    pictureBox.Image = img;
                }
                else
                {
                    throw new Exception("Seleziona almeno un punto da rimuovere");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore nella rimozione dalla punto. Errore: " + ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void rimuoviSegmentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBoxSegmenti.SelectedItems.Count > 0)
                {
                    Segmento segmentoSelezionato = (Segmento)listBoxSegmenti.SelectedItem;
                    listaSegmenti.Remove(segmentoSelezionato);
                    listBoxSegmenti.Items.RemoveAt(listBoxSegmenti.SelectedIndex);

                    Bitmap immagineOrg = new Bitmap(immagineOriginale);
                    img = immagineOrg;

                    DisegnaPunti();
                    DisegnaSegmenti();

                    pictureBox.Image = img;
                }
                else
                {
                    throw new Exception("Seleziona almeno un segmento da rimuovere");
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void salvaConfigurazioneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNomePiano.Text.Length > 0)
                {
                    if (!string.IsNullOrEmpty(txtLevel.Text))
                    {
                        int livelloPiano = Convert.ToInt32(txtLevel.Text);

                        if (!livelliUtilizzati.Contains(livelloPiano))
                        {
                            piano.Name = txtNomePiano.Text;
                            piano.Punti = new List<Punto>(listaPunti);
                            piano.Segmenti = new List<Segmento>(listaSegmenti);
                            piano.Img = immagineOriginale;
                            piano.Level = Convert.ToInt32(txtLevel.Text);
                            Mappatura_FormClosed(null, null);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else throw new Exception("Piano già utlizzato cambiare il valore.");
                    }
                    else throw new Exception("INserisci il livello del piano");
                }
                else
                    throw new Exception("Inserisci il nome del piano");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore nella salvataggio della configurazione. Errore: " + ex.Message, "Error", MessageBoxButtons.OK);
            }

        }

        private void listPoints_SelectedIndexChanged(object sender, EventArgs e)
        {
            Punto puntoSelezionato = listBoxPunti.SelectedItem as Punto;

            if (puntoSelezionato != null)
            {
                DisegnaPunti();
                DisegnaPunto(puntoSelezionato.CordinatePunti.X, puntoSelezionato.CordinatePunti.Y, puntoSelezionato.Name, Brushes.Blue);
                pictureBox.Refresh();
            }
        }

        private void cancellaConfiguToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void Mappatura_FormClosed(object sender, FormClosedEventArgs e)
        {
            listaPunti.Clear();
            listaSegmenti.Clear();
            listBoxPunti.Items.Clear();
            listBoxPuntiSeg.Items.Clear();
            listBoxSegmenti.Items.Clear();
            if (img != null)
            {
                img.Dispose();
                immagineOriginale.Dispose();
            }
        }

        private void chSegmentiContinui_CheckedChanged(object sender, EventArgs e)
        {
            if (!chSegmentiContinui.Checked)
            {
                listBoxPuntiSeg.Items.Clear();
                DisegnaPunti();
                pictureBox.Refresh();
            }
        }

        private void Mappatura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                listBoxPuntiSeg.Items.Clear();
                refresh();
            }
        }

        private void btnModificaNomePunto_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBoxPunti.SelectedItems.Count > 0)
                {
                    string nomePunto = txtNomePunto.Text.Trim();

                    if (string.IsNullOrWhiteSpace(nomePunto))
                        return;

                    bool giaEsistente = listaPunti.Any(x => x.Name == nomePunto);

                    if (!giaEsistente)
                    {
                        Punto vecchioPunto = listBoxPunti.SelectedItem as Punto;
                        Punto nuovoPunto = new Punto(vecchioPunto.CordinatePunti, nomePunto);

                        listaPunti.Remove(vecchioPunto);
                        listaPunti.Add(nuovoPunto);

                        for (int i = 0; i < listaSegmenti.Count; i++)
                        {
                            Segmento seg = listaSegmenti[i];
                            if (seg.punto1 == vecchioPunto || seg.punto2 == vecchioPunto)
                            {
                                Punto punto1 = (seg.punto1 == vecchioPunto) ? nuovoPunto : seg.punto1;
                                Punto punto2 = (seg.punto2 == vecchioPunto) ? nuovoPunto : seg.punto2;
                                Segmento nuovoSegmento = new Segmento(punto1, punto2);

                                listaSegmenti[i] = nuovoSegmento;
                            }
                        }

                        listBoxPunti.Items.Clear();
                        listBoxSegmenti.Items.Clear();

                        foreach (var punto in listaPunti)
                        {
                            listBoxPunti.Items.Add(punto);
                        }

                        foreach (var segmento in listaSegmenti)
                        {
                            listBoxSegmenti.Items.Add(segmento);
                        }

                        Bitmap immagineOrg = new Bitmap(immagineOriginale);
                        img = immagineOrg;

                        DisegnaPunti();
                        DisegnaSegmenti();
                        pictureBox.Image = img;
                    }
                    else throw new Exception("Nome del punto gia usato");
                }
                else
                    throw new Exception("Nessun punto selezionato");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore nella modifica del nome del punto.{ex.Message}");
            }
        }

        private void txtNomePunto_TextChanged(object sender, EventArgs e)
        {

        }

        /***********************/


        private double _zoomLevel = 1.0;
        private int _originalWidth;
        private int _originalHeight;

        private void gestioneMouse(object sender, MouseEventArgs e)
        {
            /*if (e.Delta > 0) // Rotellina verso l'alto
            {
                _zoomLevel += 0.1;
            }
            else if (e.Delta < 0) // Rotellina verso il basso
            {
                _zoomLevel -= 0.1;
            }
            if (_zoomLevel < 0.1) _zoomLevel = 0.1;
            if (_zoomLevel > 3.0) _zoomLevel = 3.0;

            int newWidth = (int)(_originalWidth * _zoomLevel);
            int newHeight = (int)(_originalHeight * _zoomLevel);

            pictureBox.Width = newWidth;
            pictureBox.Height = newHeight;
            pictureBox.Image = ResizeImage((Bitmap)pictureBox.Image, newWidth, newHeight);*/
        }

        private Bitmap ResizeImage(Bitmap image, int width, int height)
        {
            Bitmap resizedImage = new Bitmap(image);
            Graphics graphics = Graphics.FromImage(resizedImage);
            graphics.DrawImage(image, 0, 0, width, height);
            graphics.Dispose();
            return resizedImage;
        }
    }
}

