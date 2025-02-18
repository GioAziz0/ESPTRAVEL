namespace Mappa
{
    partial class CostruisciMappa
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            salvaJSONToolStripMenuItem = new ToolStripMenuItem();
            apriJSONToolStripMenuItem = new ToolStripMenuItem();
            rimuoviToolStripMenuItem = new ToolStripMenuItem();
            modalitaToolStripMenuItem = new ToolStripMenuItem();
            segmentoToolStripMenuItem = new ToolStripMenuItem();
            puntoToolStripMenuItem = new ToolStripMenuItem();
            listPoints = new ListBox();
            cmbModalita = new ComboBox();
            listPuntiSeg = new ListBox();
            pnlSegmenti = new Panel();
            listSegmenti = new ListBox();
            menuStrip1.SuspendLayout();
            pnlSegmenti.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { salvaJSONToolStripMenuItem, apriJSONToolStripMenuItem, rimuoviToolStripMenuItem, modalitaToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(984, 24);
            menuStrip1.TabIndex = 7;
            menuStrip1.Text = "menuStrip1";
            // 
            // salvaJSONToolStripMenuItem
            // 
            salvaJSONToolStripMenuItem.Name = "salvaJSONToolStripMenuItem";
            salvaJSONToolStripMenuItem.Size = new Size(77, 20);
            salvaJSONToolStripMenuItem.Text = "Salva JSON";
            // 
            // apriJSONToolStripMenuItem
            // 
            apriJSONToolStripMenuItem.Name = "apriJSONToolStripMenuItem";
            apriJSONToolStripMenuItem.Size = new Size(72, 20);
            apriJSONToolStripMenuItem.Text = "Apri JSON";
            // 
            // rimuoviToolStripMenuItem
            // 
            rimuoviToolStripMenuItem.Name = "rimuoviToolStripMenuItem";
            rimuoviToolStripMenuItem.Size = new Size(63, 20);
            rimuoviToolStripMenuItem.Text = "Rimuovi";
            // 
            // modalitaToolStripMenuItem
            // 
            modalitaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { segmentoToolStripMenuItem, puntoToolStripMenuItem });
            modalitaToolStripMenuItem.Name = "modalitaToolStripMenuItem";
            modalitaToolStripMenuItem.Size = new Size(66, 20);
            modalitaToolStripMenuItem.Text = "Modalita";
            // 
            // segmentoToolStripMenuItem
            // 
            segmentoToolStripMenuItem.BackColor = SystemColors.ButtonHighlight;
            segmentoToolStripMenuItem.Name = "segmentoToolStripMenuItem";
            segmentoToolStripMenuItem.Size = new Size(127, 22);
            segmentoToolStripMenuItem.Text = "segmento";
            // 
            // puntoToolStripMenuItem
            // 
            puntoToolStripMenuItem.Name = "puntoToolStripMenuItem";
            puntoToolStripMenuItem.Size = new Size(127, 22);
            puntoToolStripMenuItem.Text = "punto";
            // 
            // listPoints
            // 
            listPoints.FormattingEnabled = true;
            listPoints.ItemHeight = 15;
            listPoints.Location = new Point(0, 27);
            listPoints.Name = "listPoints";
            listPoints.Size = new Size(169, 469);
            listPoints.TabIndex = 8;
            // 
            // cmbModalita
            // 
            cmbModalita.DisplayMember = "(nessuno)";
            cmbModalita.FormattingEnabled = true;
            cmbModalita.Items.AddRange(new object[] { "Punto", "Segmento" });
            cmbModalita.Location = new Point(4, 6);
            cmbModalita.Name = "cmbModalita";
            cmbModalita.Size = new Size(124, 23);
            cmbModalita.TabIndex = 4;
            // 
            // listPuntiSeg
            // 
            listPuntiSeg.FormattingEnabled = true;
            listPuntiSeg.ItemHeight = 15;
            listPuntiSeg.Location = new Point(3, 35);
            listPuntiSeg.Name = "listPuntiSeg";
            listPuntiSeg.Size = new Size(124, 34);
            listPuntiSeg.TabIndex = 5;
            // 
            // pnlSegmenti
            // 
            pnlSegmenti.Controls.Add(listSegmenti);
            pnlSegmenti.Controls.Add(cmbModalita);
            pnlSegmenti.Controls.Add(listPuntiSeg);
            pnlSegmenti.Location = new Point(840, 87);
            pnlSegmenti.Name = "pnlSegmenti";
            pnlSegmenti.Size = new Size(131, 424);
            pnlSegmenti.TabIndex = 9;
            // 
            // listSegmenti
            // 
            listSegmenti.FormattingEnabled = true;
            listSegmenti.ItemHeight = 15;
            listSegmenti.Location = new Point(3, 75);
            listSegmenti.Name = "listSegmenti";
            listSegmenti.Size = new Size(124, 349);
            listSegmenti.TabIndex = 6;
            // 
            // CostruisciMappa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 561);
            Controls.Add(menuStrip1);
            Controls.Add(listPoints);
            Controls.Add(pnlSegmenti);
            Name = "CostruisciMappa";
            Text = "CostruisciMappa";
            Load += CostruisciMappa_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            pnlSegmenti.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem salvaJSONToolStripMenuItem;
        private ToolStripMenuItem apriJSONToolStripMenuItem;
        private ToolStripMenuItem rimuoviToolStripMenuItem;
        private ToolStripMenuItem modalitaToolStripMenuItem;
        private ToolStripMenuItem segmentoToolStripMenuItem;
        private ToolStripMenuItem puntoToolStripMenuItem;
        private ListBox listPoints;
        private ComboBox cmbModalita;
        private ListBox listPuntiSeg;
        private Panel pnlSegmenti;
        private ListBox listSegmenti;
    }
}