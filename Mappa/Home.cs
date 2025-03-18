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
            DialogResult dialog = form.ShowDialog();

            if (dialog == DialogResult.OK)
            {
                Piano piano = form.piano;
                listBox1.Items.Add(piano);
            }
        }
    }
}
