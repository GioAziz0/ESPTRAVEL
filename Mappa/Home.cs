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
        List<CollegaPunti> _collegamenti = new List<CollegaPunti>();
        private readonly List<Piano> _piani = new List<Piano>();
        private const string JsonFilter = "JSON files (*.json)|*.json|All files (*.*)|*.*";

        public Home()
        {
            InitializeComponent();
            ConfigureListView();
        }

        private void ConfigureListView()
        {
            listViewPiani.View = View.Details;
            listViewPiani.FullRowSelect = true;
            listViewPiani.GridLines = true;
            listViewPiani.Columns.Add("Livello", 100);
            listViewPiani.Columns.Add("Nome", 200);

            listViewCollegaPiani.View = View.Details;
            listViewCollegaPiani.FullRowSelect = true;
            listViewCollegaPiani.GridLines = true;
            listViewCollegaPiani.Columns.Add("Livello", 75);
            listViewCollegaPiani.Columns.Add("Nome", 150);
        }

        private void RefreshPianiList()
        {
            listViewPiani.Items.Clear();
            foreach (var piano in _piani.OrderBy(p => p.Level))
            {
                var item = new ListViewItem(piano.Level.ToString());
                item.SubItems.Add(piano.Name);
                item.Tag = piano;
                listViewPiani.Items.Add(item);
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
            if (listViewPiani.SelectedItems.Count == 0)
            {
                MessageBox.Show("Selezionare un piano", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedItem = listViewPiani.SelectedItems[0];
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
                        image = piano.ConvertImageToBase64(piano.Img),
                        Name = piano.Name,
                        Level = piano.Level,
                        arcs = piano.CreaSegmenti(piano.Segmenti),
                        CollegaPunti = piano.CollegaPunti
                    }));


                    var jsonString = JsonConvert.SerializeObject(listaPiani, Formatting.Indented);
                    File.WriteAllText(saveFileDialog.FileName, jsonString);

                    MessageBox.Show("File salvato con successo", "Operazione completata", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        arcs = piano.CreaSegmenti(piano.Segmenti),
                        image = piano.ConvertImageToBase64(piano.Img),
                        Name = piano.Name,
                        Level = piano.Level,
                        CollegaPunti = piano.CollegaPunti

                    }));

                    var jsonContent = JsonConvert.SerializeObject(listaPiani, Formatting.Indented);

                    using (var client = new HttpClient())
                    using (var request = new HttpRequestMessage(HttpMethod.Post, "https://127.0.0.1:8000/laod?id=prova4"))
                    {
                        request.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                        var response = await client.SendAsync(request);
                        response.EnsureSuccessStatusCode();

                        MessageBox.Show("Dati salvati con successo sul server", "Operazione completata", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        public void AggiungiPianoConfigurazione(object sender, EventArgs e)
        {
            try
            {
                if (listViewCollegaPiani.Items.Count < 2)
                {
                    if (listViewPiani.SelectedItems.Count == 0)
                    {
                        throw new Exception("Selezionare un piano");
                    }

                    var selectedItem = listViewPiani.SelectedItems[0];
                    if (!(selectedItem.Tag is Piano pianoSelezionato)) return;
                    Piano piano = (Piano)selectedItem.Tag;

                    var item = new ListViewItem(piano.Level.ToString());
                    item.SubItems.Add(piano.Name);
                    item.Tag = piano;
                    listViewCollegaPiani.Items.Add(item);
                }
                else throw new Exception("Sono già stati inseriti due piani");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore nell'aggiunta di un piani.{ex.Message}!!!");
                return;
            }
        }

        private void HandleError(string message, Exception ex)
        {
            MessageBox.Show($"{message}: {ex.Message}", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void apriCollegaPianiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlCollegaPiani.Visible = true;
        }

        private void btnChiudiCollega_Click(object sender, EventArgs e)
        {
            pnlCollegaPiani.Visible = false;
        }

        private void ApriCollega(object sender, EventArgs e)
        {
            try
            {
                if (listViewCollegaPiani.Items.Count == 2)
                {
                    Piano piano1 = listViewCollegaPiani.Items[0].Tag as Piano;
                    Piano piano2 = listViewCollegaPiani.Items[1].Tag as Piano;

                    using (Configurazione form = new Configurazione(piano1, piano2))
                    {
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            var newPiano1 = form.piano1;
                            var newPiano2 = form.piano2;

                            foreach (ListViewItem item in listViewPiani.Items)
                            {
                                Piano p = item.Tag as Piano;

                                int index = _piani.FindIndex(x => x.Level == p.Level);
                                if (index != -1)
                                {
                                    _piani[index] = p; // sostituisce l'elemento trovato con 'p'
                                }
                            }

                            RefreshPianiList();
                            listViewCollegaPiani.Items.Clear();
                        }
                    }
                }
                else MessageBox.Show("Inserire due piani prima di aprire la configurazione");
            }
            catch (Exception ex)
            {
                HandleError("Errore nell'apertura della configurazione", ex);
            }
        }

        private void btnRimuoviCollega_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewCollegaPiani.SelectedItems.Count > 0)
                {
                    // Prendi il primo elemento selezionato
                    var item = listViewCollegaPiani.SelectedItems[0];

                    // Eventualmente puoi usare item.Tag se ci hai messo un oggetto
                    listViewCollegaPiani.Items.Remove(item);
                }
                else
                {
                    throw new Exception("Seleziona un elemento da rimuovere!!!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore nella rimozione del piano. {ex.Message}!!!");
            }
        }

        private void eliminaPianoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewPiani.SelectedItems.Count > 0)
                {
                    ListViewItem elemento = listViewPiani.SelectedItems[0];
                    listViewPiani.Items.Remove(elemento);
                }
                else
                    throw new Exception("Nessun elemento selezionato");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore nella rimozione del punto.{ex.Message}!!!");
            }
        }
    }
}