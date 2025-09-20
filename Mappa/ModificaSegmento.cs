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
    public partial class ModificaSegmento : Form
    {
        public bool IsAccessible => chkAccessibile.Checked;
        public double Peso;
        //public double FattoreDifficolta => (double)numFattore.Value * Peso;
        public bool AtoB_Open => chkAtoB.Checked;
        public bool BtoA_Open => chkBtoA.Checked;
        public double AtoB_Fattore => (double)AtoB_numFattore.Value;
        public double BtoA_Fattore => (double)BtoA_numFattore.Value;


        private CheckBox chkAccessibile = new CheckBox { Text = "Accessibile", Width = 4000 };
        //private NumericUpDown numFattore = new NumericUpDown { Minimum = 0, Maximum = 300, DecimalPlaces = 1, Value = 100, Width = 200 };
        private CheckBox chkAtoB = new CheckBox { Text = "", Width = 4000 };
        private CheckBox chkBtoA = new CheckBox { Text = "", Width = 4000 };
        private NumericUpDown AtoB_numFattore = new NumericUpDown { Minimum = 0, Maximum = 100, DecimalPlaces = 3, Value = 1, Width = 200 };
        private NumericUpDown BtoA_numFattore = new NumericUpDown { Minimum = 0, Maximum = 100, DecimalPlaces = 3, Value = 1, Width = 200 };
        private CheckBox chkPendenza = new CheckBox { Text = "È una pendenza? (viene calcolata automaticamente la difficoltà nel senso opposto)", Width = 4000 };

        public ModificaSegmento()
        {
            InitializeComponent();
        }

        public ModificaSegmento(Segmento segmento)
        {
            Text = "Modifica Segmento";
            chkAccessibile.Checked = segmento.IsAccessible;
            Peso = segmento.Peso;

            var btnOk = new Button { Text = "OK", DialogResult = DialogResult.OK };
            var btnCancel = new Button { Text = "Annulla", DialogResult = DialogResult.Cancel };

            chkAtoB.Text = "Il segmento è percorribile da '" + segmento.punto1.Name + "' a '" + segmento.punto2.Name + "'? ";
            chkAtoB.Checked = segmento.Difficolta.AtoB_open;
            chkBtoA.Text = "Il segmento è percorribile da '" + segmento.punto2.Name + "' a '" + segmento.punto1.Name + "'? ";
            chkBtoA.Checked = segmento.Difficolta.BtoA_open;

            AtoB_numFattore.Value = (decimal)segmento.Difficolta.AtoB_fattore;
            BtoA_numFattore.Value = (decimal)segmento.Difficolta.BtoA_fattore;

            //aggingi evento alla spunta della casella di chkpendenza, che se chkpendenza è selezionato disabilita chkBtoA e imposta BtoA_numFattore = 1/AtoB_numFattore
            chkPendenza.CheckedChanged += (s, e) =>
            {
                if (chkPendenza.Checked)
                {
                    BtoA_numFattore.Value = AtoB_numFattore.Value != 0 ? 1 / AtoB_numFattore.Value : 0;
                    BtoA_numFattore.Enabled = false;
                }
                else
                {
                    BtoA_numFattore.Enabled = true;
                }
            };

            var layout = new FlowLayoutPanel { Dock = DockStyle.Fill };
            layout.Controls.Add(chkAccessibile);
            layout.Controls.Add(chkAtoB);
            layout.Controls.Add(chkBtoA);
            layout.Controls.Add(new Label { Text = "Peso attuale del segmento:" +
                "\n '" + segmento.punto1.Name + "'-->'" + segmento.punto2.Name + "'=" + (segmento.Difficolta.AtoB_fattore * Peso) +
                "\n '" + segmento.punto2.Name + "'-->'" + segmento.punto1.Name + "'=" + (segmento.Difficolta.AtoB_fattore * Peso), 
                Size = new Size(406, 75) });
            //layout.Controls.Add(new Label { Text = "Fattore difficoltà (%) (0-300)" });
            layout.Controls.Add(new Label { Text = "Moltiplicatore difficoltà (1=normale, <1 = più facile, >1 = più difficile)" });
            layout.Controls.Add(chkPendenza);
            layout.Controls.Add(new Label { Text = "'" + segmento.punto1.Name + "'-->'" + segmento.punto2.Name + "'" });
            layout.Controls.Add(AtoB_numFattore);
            layout.Controls.Add(new Label { Text = "'" + segmento.punto2.Name + "'-->'" + segmento.punto1.Name + "'" });
            layout.Controls.Add(BtoA_numFattore);
            layout.Controls.Add(btnOk);
            layout.Controls.Add(btnCancel);

            Controls.Add(layout);
            AcceptButton = btnOk;
            CancelButton = btnCancel;

            this.Size = new Size(500, 500);
        }
    }
}
