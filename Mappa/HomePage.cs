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
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void ciaoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Immagini|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            fileDialog.Title = "Seleziona immagine";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string imgPath = fileDialog.FileName;
                Image img = Image.FromFile(imgPath);

                CostruisciMappa form = new CostruisciMappa(img);
                form.ShowDialog();
            }
        }
    }
}
