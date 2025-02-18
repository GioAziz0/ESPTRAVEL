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
    public partial class CostruisciMappa : Form
    {
        Image immagineSfondo;
        public CostruisciMappa(Image img)
        {
            InitializeComponent();
            immagineSfondo = img;
        }

        private void CostruisciMappa_Load(object sender, EventArgs e)
        {
            
        }
    }
}
