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
            listBox1.Items.Clear();
            foreach (Piano p in piani.OrderBy(p => p.Level))
            {
                listBox1.Items.Add(p);
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

        private void salvaJsonLocale(object sender, EventArgs e)
{
    try
    {
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.Filter = "JSON|*.json";
        saveFileDialog.Title = "Salva punti in JSON";

        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        {
            string filePath = saveFileDialog.FileName;
            SaveJson listaPiani = new SaveJson();
            
            // Usa la lista piani come sorgente principale invece di listBox1.Items
            foreach (Piano piano in piani)
            {
                SavePiano savePiano = new SavePiano();
                savePiano.points = piano.Punti;
                savePiano.arcs = piano.Segmenti;
                savePiano.image = savePiano.ConvertImageToBase64(piano.Img);
                savePiano.Name = piano.Name;
                savePiano.Level = piano.Level;
                listaPiani.piani.Add(savePiano);
            }

            string stringJson = JsonConvert.SerializeObject(listaPiani, Formatting.Indented);
            File.WriteAllText(filePath, stringJson);

            MessageBox.Show("File Salvato con successo", "Salvataggio completato", 
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Errore durante il salvataggio: {ex.Message}", "Errore", 
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}

        private void SalvaJsonCluod(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void apriJsonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
            openFileDialog.Title = "Scegli il file json da aprire";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filePath = openFileDialog.FileName;
                    string jsonString = File.ReadAllText(filePath);

                    LoaderPiani caricaPiani = new LoaderPiani();
                    piani.AddRange(caricaPiani.LoadFromJson(jsonString));

                    if (piani.Count > 0)
                    {
                        foreach(Piano piano in piani)
                        {
                            listBox1.Items.Add(piano);  
                        }
                    }
                    else
                    {
                        throw new Exception($"Nessun piano trovato in {filePath}");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Errore nell'apertura del file json. " + ex.Message, "error", MessageBoxButtons.OK);
                }
            }
        }
    }
}

