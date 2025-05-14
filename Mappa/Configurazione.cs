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
            lblPiano1.Name = piano1.Name;
            lblPiano2.Name = piano1.Name;
        }

        private void ConfigureListView()
        {
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.Columns.Add(piano1.Name, 75);
            listView1.Columns.Add(piano2.Name, 75);
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
        }

        private void Configura()
        {
            try
            {
                if(lstPuntiPiano1.SelectedItems.Count > 0 && lstPuntiPiano2.SelectedItems.Count > 0)
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore nella configurazione!!!!!!!!");
            }
        }

        private void Configurazione_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
