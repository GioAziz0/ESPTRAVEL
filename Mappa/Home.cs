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
        public Home()
        {
            InitializeComponent();
        }

        private void aggiungiPianoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Mappatura form = new Mappatura();
            DialogResult result = form.ShowDialog();

            if (result == DialogResult.OK)
            {
                Piano piano = form.piano;
                listBox1.Items.Add(piano);
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
                        Mappatura form = new Mappatura(listBox1.SelectedItem as Piano);
                        DialogResult result = form.ShowDialog();

                        if (result == DialogResult.OK)
                        {
                            Piano newPiano = form.piano;
                            listBox1.Items.Remove(listBox1.SelectedItem);
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
                savePiano.arcs = piano.Segmenti;
                savePiano.image = savePiano.ConvertImageToBase64(piano.Img);
                savePiano.Name = piano.Name;

                fileSalvataggio.piani.Add(savePiano);
            }

            string downloadPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");

            string filePath = Path.Combine(downloadPath, "dati.json");

            string stringJson = JsonConvert.SerializeObject(fileSalvataggio);
            File.WriteAllText(filePath, stringJson);

            MessageBox.Show("File Salvato");

        }
    }
}
