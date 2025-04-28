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
            //apre le due mappe selezionate nella checkedListBox e permette all'utente di selezionare i punti (uno per mappa) che rappresentano il segmento della scala (collegamento verticale tra i piani)
            /*if (checkedListBox1.CheckedItems.Count == 2)
            {
                Mappatura form = new Mappatura(checkedListBox1.CheckedItems[0] as Piano, checkedListBox1.CheckedItems[1] as Piano);
                DialogResult result = form.ShowDialog();

                if (result == DialogResult.OK)
                {
                    Segmento segmento = form.segmento;
                    Piano piano1 = checkedListBox1.CheckedItems[0] as Piano;
                    Piano piano2 = checkedListBox1.CheckedItems[1] as Piano;

                    piano1.Segmenti.Add(segmento);
                    piano2.Segmenti.Add(segmento);
                }
            }
            else
            {
                MessageBox.Show("Selezionare due piani");
            }*/
        }
    }
}
