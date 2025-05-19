using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mappa.Classi;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Mappa
{
    public partial class Configurazione : Form
    {
        public Piano piano1 { get; set; }
        public Piano piano2 { get; set; }
        public Configurazione(Piano piano1, Piano piano2)
        {
            this.piano1 = piano1;
            this.piano2 = piano2;
            InitializeComponent();
            ConfigureListView();
            AggiungiPunti();
            lblPiano1.Text = "Lista punit di: " + piano1.Name;
            lblPiano2.Text = "Lista punti di: " + piano2.Name;
        }

        private void ConfigureListView()
        {
            listvPianiCollegati.View = View.Details;
            listvPianiCollegati.FullRowSelect = true;
            listvPianiCollegati.GridLines = true;
            listvPianiCollegati.Columns.Add(piano1.Name, 85);
            listvPianiCollegati.Columns.Add(piano2.Name, 85);
        }

        private void AggiungiPunti()
        {
            foreach (var punto in piano1.Punti)
            {
                lstPuntiPiano1.Items.Add(punto);
            }
            foreach (var punto in piano2.Punti)
            {
                lstPuntiPiano2.Items.Add(punto);
            }

            List<CollegaPunti> collegamenti = piano1.CollegaPunti.Where(x => x.Floor2 == piano2.Level).ToList();
            MessageBox.Show($"Collegamenti trovati: {collegamenti.Count}");
            foreach (var collegamento in collegamenti)
            {
                ListViewItem item = new ListViewItem(collegamento.Punto1.Name);
                item.SubItems.Add(collegamento.Punto2.Name);
                listvPianiCollegati.Items.Add(item);
            }

        }

        private void Configura(object sender, EventArgs e)
        {
            try
            {
                if (lstPuntiPiano1.SelectedItems.Count > 0 && lstPuntiPiano2.SelectedItems.Count > 0)
                {
                    if (!string.IsNullOrEmpty(txtPeso.Text))
                    {
                        if(Convert.ToInt32(txtPeso.Text) < 0)
                        {
                            throw new Exception("Il peso deve essere maggiore di 0");
                        }

                        int peso = Convert.ToInt32(txtPeso.Text);

                        piano1.CollegaPunti.Add(new CollegaPunti()
                        {
                            Floor1 = piano1.Level,
                            Floor2 = piano2.Level,
                            Punto1 = (Punto)lstPuntiPiano1.SelectedItem,
                            Punto2 = (Punto)lstPuntiPiano2.SelectedItem,
                            Peso = peso
                        });

                        piano2.CollegaPunti.Add(new CollegaPunti()
                        {
                            Floor1 = piano2.Level,
                            Floor2 = piano1.Level,
                            Punto1 = (Punto)lstPuntiPiano2.SelectedItem,
                            Punto2 = (Punto)lstPuntiPiano1.SelectedItem,
                            Peso = peso    
                        });

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        throw new Exception("Inserire un peso");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Errore nella configurazione. {ex.Message}");
            }
        }

        private void Configurazione_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btn_collega_Click(object sender, EventArgs e)
        {

        }
    }
}
