using Mappa.Classi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Mappa
{
    public partial class ModificaMappa : Form
    {
        Image immagineSfondo;
        Image imgAttuale;
        PictureBox pct;
        List<Punto> listaPunti;
        List<Segmento> listaSegmenti;
        public ModificaMappa(Image img)
        {
            InitializeComponent();
            immagineSfondo = img;
            pct = new PictureBox();
            listaPunti = new List<Punto>();
            listaSegmenti = new List<Segmento>();
            abilitazioneControlli(false);
        }
        private void ModificaMappa_Load(object sender, EventArgs e)
        {
            imgAttuale = new Bitmap(immagineSfondo);
            pct = new PictureBox();

            int altezza = (int)(ClientSize.Height * 0.9);
            int larghezza = (imgAttuale.Width * altezza) / imgAttuale.Height;
            pct.Size = new Size(larghezza, altezza);
            pct.SizeMode = PictureBoxSizeMode.StretchImage;
            pct.Image = imgAttuale;
            pct.Location = new Point(ClientSize.Width / 2 - larghezza / 2, 44);

            pct.MouseClick += pctClick;

            pct.Visible = true;
            Controls.Add(pct);
            abilitazioneControlli(true);
        }

        private void abilitazioneControlli(bool abilitazione)
        {
            salvaJSONToolStripMenuItem.Enabled = abilitazione;
            apriJSONToolStripMenuItem.Enabled = abilitazione;
            rimuoviToolStripMenuItem.Enabled = abilitazione;
            modalitaToolStripMenuItem.Enabled = abilitazione;
            pnlSegmenti.Visible = abilitazione;
            MaximizeBox = abilitazione;
            MinimizeBox = abilitazione;
            if (abilitazione) WindowState = FormWindowState.Maximized;
        }
        private async void pctClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("Ciao");
            float scaleX = (float)imgAttuale.Width / pct.Width;
            float scaleY = (float)imgAttuale.Height / pct.Height;
            int positionX = (int)(e.X * scaleX);
            int positionY = (int)(e.Y * scaleY);

            string nome = await TrovaNome();
            Punto PuntoClick = new Punto(new Point(positionX, positionY), nome);

            if (cmbModalita.SelectedIndex == 0) //codice per disegnare il punto
            {
                listaPunti.Add(PuntoClick);
                listBoxPunti.Items.Add(PuntoClick);
                await DisegnaPunto(PuntoClick);
                pct.Refresh();
            }
            else if (cmbModalita.SelectedIndex == 1) //codice in modalita segmento
            {
                var ListaPuntiOrdinati = listaPunti.OrderBy(p => Distanza(p, PuntoClick)).ToList();
                Punto puntoPiuVicino = ListaPuntiOrdinati.First();
                listBoxPuntiSeg.Items.Add(puntoPiuVicino);

                if (listBoxPuntiSeg.Items.Count == 2)
                {
                    if (listBoxPuntiSeg.Items[0] == listBoxPuntiSeg.Items[1])
                    {
                        MessageBox.Show("I punti selezionti sono uguali");
                        listBoxPuntiSeg.Items.Clear();
                        return;
                    }
                    Punto punto1 = listBoxPuntiSeg.Items[0] as Punto;
                    Punto punto2 = listBoxPuntiSeg.Items[1] as Punto;
                    bool esiste = listaSegmenti.Any(segmento => segmento.Nome1 + segmento.Nome2 == punto1.Name + punto2.Name);
                    if (esiste)
                    {
                        MessageBox.Show("Esiste gia un segmento con questyi punti");
                        listBoxPuntiSeg.Items.Clear();
                        return;
                    }
                    Segmento segmento = new Segmento(listBoxPuntiSeg.Items[0] as Punto, listBoxPuntiSeg.Items[1] as Punto);
                    listBoxSegmenti.Items.Add(segmento);
                    listaSegmenti.Add(segmento);
                    await DisegnaSegmento(segmento);
                    listBoxPuntiSeg.Items.Clear();
                }
                else
                {
                    using (Graphics g = pct.CreateGraphics())
                    {
                        int pointSize = 30;
                        g.FillRectangle(Brushes.Green, puntoPiuVicino.CordinatePunti.X, puntoPiuVicino.CordinatePunti.Y, pointSize, pointSize);
                    }
                }
            }
        }
        private async Task DisegnaPunto(Punto punto)
        {
            using (Graphics gpr = pct.CreateGraphics())
            {
                int pointSize = 30; // Dimensione del punto da disegnare
                gpr.FillRectangle(Brushes.Red, punto.CordinatePunti.X, punto.CordinatePunti.Y, pointSize, pointSize);
                Font font = new Font("Arial", 40, FontStyle.Bold);
                Brush brush = Brushes.Black;
                gpr.DrawString(punto.Name, font, brush, new PointF(punto.CordinatePunti.X, punto.CordinatePunti.Y - 10));
            }
        }
        private async Task DisegnaPunti()
        {
            foreach (Punto punto in listaPunti)
            {
                await DisegnaPunto(punto);
            }
        }
        private async Task DisegnaSegmento(Segmento segmento)
        {
            using (Graphics gpr = pct.CreateGraphics())
            {
                Pen pen = new Pen(Color.FromArgb(0, 0, 255), 3);  // Dimensione penna adatta
                gpr.DrawLine(pen, segmento.Punto1.CordinatePunti, segmento.Punto2.CordinatePunti);
            }
        }
        private async Task DisegnaSegmenti()
        {
            foreach (Segmento segmento in listaSegmenti)
            {
                await DisegnaSegmento(segmento);
            }
        }

        private async Task<float> Distanza(Punto p1, Punto p2)
        {
            return (float)Math.Sqrt(Math.Pow(p1.CordinatePunti.X - p2.CordinatePunti.X, 2) + Math.Pow(p1.CordinatePunti.Y - p2.CordinatePunti.Y, 2));
        }
        private async Task<string> TrovaNome()
        {
            string nome;
            int indice = 1;
            do
            {
                nome = string.Empty;
                int tempIndice = indice;
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

        private async void rimuoviPuntoToolStripMenuItem_Click(object sender, EventArgs e)
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
                    Bitmap immagineOrg = new Bitmap(immagineSfondo);
                    imgAttuale = immagineOrg;

                    await DisegnaPunti();
                    await DisegnaSegmenti();
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

        private async void rimuoviSegmentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBoxSegmenti.SelectedItems.Count > 0)
                {
                    Segmento segmentoSelezionato = (Segmento)listBoxSegmenti.SelectedItem;
                    listaSegmenti.Remove(segmentoSelezionato);
                    listBoxSegmenti.Items.RemoveAt(listBoxSegmenti.SelectedIndex);

                    Bitmap immagineOrg = new Bitmap(immagineSfondo);
                    imgAttuale = immagineOrg;

                    await DisegnaPunti();
                    await DisegnaSegmenti();
                }
                else
                {
                    throw new Exception("Seleziona almeno un segmento da rimuovere");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore nella rimozione del segmento. Errore: " + ex.Message, "Error", MessageBoxButtons.OK);
            }
        }
        private async void ModificaMappa_Resize(object sender, EventArgs e)
        {
            int altezza = (int)(ClientSize.Height * 0.9);
            int larghezza = (imgAttuale.Width * altezza) / imgAttuale.Height;
            pct.Size = new Size(larghezza, altezza);
            pct.Location = new Point(ClientSize.Width / 2 - larghezza / 2, 44);
            pnlSegmenti.Location = new Point(ClientSize.Width - 160, 37);

            await DisegnaPunti();
        }
    }
}
