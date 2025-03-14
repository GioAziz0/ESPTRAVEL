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
        int counterPiani;
        Thread piano;
        public Home()
        {
            InitializeComponent();
            counterPiani = 0;
            SetupListView();
        }
        private void SetupListView()
        {
            ImgPiani.ImageSize = new Size(100, 100);
            lstViewPiani.LargeImageList = ImgPiani;
        }

        private void aggiungiPianoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //piano = new Thread(CreaPiano);
            //piano.Start();

            CreaPiano();


        }

        private void CreaPiano()
        {
            Mappatura form = new Mappatura();
            DialogResult dialog = form.ShowDialog();

            if (dialog == DialogResult.OK)
            {
                ListViewItem item = new ListViewItem($"Piano {counterPiani + 1}");
                item.ImageIndex = counterPiani;
                item.Tag = "filepath";
                lstViewPiani.Items.Add(item);
                counterPiani++;
            }
        }
    }
}
