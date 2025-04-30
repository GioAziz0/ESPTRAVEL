using Mappa.Classi;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mappa
{
    public partial class Home : Form
    {
        List<Piano> piani;
        public Home()
        {
            InitializeComponent();
            piani = new List<Piano>();
        }

        void SistemaPiani()
        {
            if (listBox1.Items.Count > 0)
            {
                piani = piani.OrderBy(piano => piano.Level).ToList();
                listBox1.Items.Clear();
                foreach (Piano p in piani) { listBox1.Items.Add(p); }
            }
        }

        private void aggiungiPianoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<int> livelli = new List<int>();

            foreach (Piano piano in listBox1.Items)
            {
                livelli.Add(piano.Level);
            }

            Mappatura form = new Mappatura(livelli);
            DialogResult result = form.ShowDialog();

            if (result == DialogResult.OK)
            {
                Piano piano = form.piano;
                listBox1.Items.Add(piano);
                MessageBox.Show(piano.Level.ToString());
                piani.Add(piano);
                SistemaPiani();
            }
        }

        private void aPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBox1.SelectedItems.Count > 0)
                {
                    if (listBox1.SelectedItem is Piano)
                    {
                        List<int> livelli = new List<int>();

                        foreach (Piano piano in listBox1.Items)
                        {
                            livelli.Add(piano.Level);
                            MessageBox.Show(piano.Level.ToString());
                        }
                        livelli.RemoveAt(listBox1.SelectedIndex);

                        Mappatura form = new Mappatura(listBox1.SelectedItem as Piano, livelli);
                        DialogResult result = form.ShowDialog();

                        if (result == DialogResult.OK)
                        {
                            Piano newPiano = form.piano;
                            listBox1.Items.Remove(listBox1.SelectedItem);
                            piani.Remove(listBox1.SelectedItem as Piano);
                            piani.Add((Piano)newPiano);
                            listBox1.Items.Add(newPiano);
                        }
                        else if (result == DialogResult.Cancel)
                        {
                            MessageBox.Show("Operazione cancellata");
                        }
                    }
                }
                else
                    throw new Exception("Selezionare un piano");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void salvaJsonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveJson fileSalvataggio = new SaveJson();
            foreach (Piano piano in listBox1.Items)
            {
                SavePiano savePiano = new SavePiano();
                savePiano.points = piano.Punti;
                foreach (Segmento segmento in piano.Segmenti)
                {
                    List<string> list = segmento.ToList();
                    savePiano.arcs.Add(list);
                }
                savePiano.image = savePiano.ConvertImageToBase64(piano.Img);
                savePiano.Name = piano.Name;
                savePiano.Level = piano.Level;
                fileSalvataggio.piani.Add(savePiano);
            }

            string downloadPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");

            string filePath = Path.Combine(downloadPath, "dati.json");

            string stringJson = JsonConvert.SerializeObject(fileSalvataggio);
            File.WriteAllText(filePath, stringJson);

            MessageBox.Show("File Salvato");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var s in listBox1.Items)
            {
                checkedListBox1.Items.Add(s);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //apre le due mappe selezionate  e permette all'utente di selezionare i punti (uno per mappa) che rappresentano il segmento della scala (collegamento verticale tra i piani)
            if (listBox1.Items.Count == 2)
            {
                Piano uno = listBox1.Items[0] as Piano;
                Piano due = listBox1.Items[1] as Piano;

                checkedListBox1.Items.Clear();
                checkedListBox1.Items.Add(uno.Punti);
                checkedListBox2.Items.Clear();
                checkedListBox2.Items.Add(due.Punti);
            }
            else
            {
                MessageBox.Show("Selezionare due piani");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnUnisci_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.CheckedItems.Count != 1 || checkedListBox2.CheckedItems.Count != 1)
            {
                MessageBox.Show("Selezionare un punto per mappa");
                return;
            }

            Punto punto1 = (Punto)checkedListBox1.CheckedItems[0];
            Punto punto2 = (Punto)checkedListBox2.CheckedItems[0];

            Segmento segmento = new Segmento(punto1, punto2);

            

        }
    }
}
