using Mappa.Classi;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mappa
{
    public partial class Home : Form
    {
        private readonly List<Piano> _piani = new List<Piano>();
        private const string JsonFilter = "JSON files (*.json)|*.json|All files (*.*)|*.*";

        public Home()
        {
            InitializeComponent();
            ConfigureListView();
        }

        private void ConfigureListView()
        {
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.Columns.Add("Livello", 100);
            listView1.Columns.Add("Nome", 200);
        }

        private void RefreshPianiList()
        {
            listView1.Items.Clear();
            foreach (var piano in _piani.OrderBy(p => p.Level))
            {
                var item = new ListViewItem(piano.Level.ToString());
                item.SubItems.Add(piano.Name);
                item.Tag = piano;
                listView1.Items.Add(item);
            }
        }

        private void aggiungiPianoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var existingLevels = _piani.Select(p => p.Level).ToList();
            using (var form = new Mappatura(existingLevels))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    _piani.Add(form.piano);
                    RefreshPianiList();
                }
            }
        }

        private void aPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Selezionare un piano", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedItem = listView1.SelectedItems[0];
            if (!(selectedItem.Tag is Piano pianoSelezionato)) return;

            var otherLevels = _piani.Where(p => p.Level != pianoSelezionato.Level)
                                   .Select(p => p.Level)
                                   .ToList();

            using (var form = new Mappatura(pianoSelezionato, otherLevels))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    _piani.Remove(pianoSelezionato);
                    _piani.Add(form.piano);
                    RefreshPianiList();
                }
            }
        }

        private void salvaJsonLocale(object sender, EventArgs e)
        {
            try
            {
                using (var saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = JsonFilter;
                    saveFileDialog.Title = "Salva punti in JSON";

                    if (saveFileDialog.ShowDialog() != DialogResult.OK) return;

                    var listaPiani = new SalvaJson();
                    listaPiani.piani.AddRange(_piani.Select(piano => new SavePiano
                    {
                        points = piano.Punti,
                        arcs = piano.Segmenti,
                        image = piano.ConvertImageToBase64(piano.Img),
                        Name = piano.Name,
                        Level = piano.Level
                    }));

                    var jsonString = JsonConvert.SerializeObject(listaPiani, Formatting.Indented);
                    File.WriteAllText(saveFileDialog.FileName, jsonString);

                    MessageBox.Show("File salvato con successo", "Operazione completata",MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                HandleError("Errore durante il salvataggio", ex);
            }
        }

        private async void SalvaJsonCluod(object sender, EventArgs e)
        {
            try
            {
                using (var saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = JsonFilter;
                    saveFileDialog.Title = "Salva punti in JSON";

                    if (saveFileDialog.ShowDialog() != DialogResult.OK) return;

                    var listaPiani = new SalvaJson();
                    listaPiani.piani.AddRange(_piani.Select(piano => new SavePiano
                    {
                        points = piano.Punti,
                        arcs = piano.Segmenti,
                        image = piano.ConvertImageToBase64(piano.Img),
                        Name = piano.Name,
                        Level = piano.Level
                    }));

                    var jsonContent = JsonConvert.SerializeObject(listaPiani, Formatting.Indented);

                    using (var client = new HttpClient())
                    using (var request = new HttpRequestMessage(HttpMethod.Post, "https://127.0.0.1:8000/laod?id=prova4"))
                    {
                        request.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                        var response = await client.SendAsync(request);
                        response.EnsureSuccessStatusCode();

                        MessageBox.Show("Dati salvati con successo sul server", "Operazione completata",MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                HandleError("Errore durante il salvataggio sul server", ex);
            }
        }

        private void apriJsonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (var openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = JsonFilter;
                    openFileDialog.Title = "Scegli il file JSON da aprire";

                    if (openFileDialog.ShowDialog() != DialogResult.OK) return;

                    var jsonString = File.ReadAllText(openFileDialog.FileName);
                    var caricaPiani = new LoaderPiani();
                    var pianiCaricati = caricaPiani.LoadFromJson(jsonString);

                    if (!pianiCaricati.Any())
                    {
                        MessageBox.Show($"Nessun piano trovato nel file selezionato", "Attenzione",
                                      MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    _piani.Clear();
                    _piani.AddRange(pianiCaricati);
                    RefreshPianiList();
                }
            }
            catch (Exception ex)
            {
                HandleError("Errore nell'apertura del file JSON", ex);
            }
        }

        private void HandleError(string message, Exception ex)
        {
            MessageBox.Show($"{message}: {ex.Message}", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}