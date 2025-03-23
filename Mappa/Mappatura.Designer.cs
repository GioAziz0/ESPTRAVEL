namespace Mappa
{
    partial class Mappatura
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            caricaToolStripMenuItem = new ToolStripMenuItem();
            salvaJSONToolStripMenuItem = new ToolStripMenuItem();
            apriJSONToolStripMenuItem = new ToolStripMenuItem();
            rimuoviToolStripMenuItem = new ToolStripMenuItem();
            rimuoviPuntoToolStripMenuItem = new ToolStripMenuItem();
            rimuoviSegmentoToolStripMenuItem = new ToolStripMenuItem();
            modalitaToolStripMenuItem = new ToolStripMenuItem();
            segmentoToolStripMenuItem = new ToolStripMenuItem();
            puntoToolStripMenuItem = new ToolStripMenuItem();
            saveConfigToolStripMenuItem = new ToolStripMenuItem();
            cancellaConfiguToolStripMenuItem = new ToolStripMenuItem();
            listBoxPunti = new ListBox();
            cmbModalita = new ComboBox();
            listBoxPuntiSeg = new ListBox();
            pnlSegmenti = new Panel();
            listBoxSegmenti = new ListBox();
            txtNomePiano = new TextBox();
            menuStrip1.SuspendLayout();
            pnlSegmenti.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { caricaToolStripMenuItem, salvaJSONToolStripMenuItem, apriJSONToolStripMenuItem, rimuoviToolStripMenuItem, modalitaToolStripMenuItem, saveConfigToolStripMenuItem, cancellaConfiguToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(984, 24);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // caricaToolStripMenuItem
            // 
            caricaToolStripMenuItem.Name = "caricaToolStripMenuItem";
            caricaToolStripMenuItem.Size = new Size(52, 20);
            caricaToolStripMenuItem.Text = "Carica";
            caricaToolStripMenuItem.Click += caricaToolStripMenuItem_Click;
            // 
            // salvaJSONToolStripMenuItem
            // 
            salvaJSONToolStripMenuItem.Name = "salvaJSONToolStripMenuItem";
            salvaJSONToolStripMenuItem.Size = new Size(77, 20);
            salvaJSONToolStripMenuItem.Text = "Salva JSON";
            salvaJSONToolStripMenuItem.Click += salvaJSONToolStripMenuItem_Click;
            // 
            // apriJSONToolStripMenuItem
            // 
            apriJSONToolStripMenuItem.Name = "apriJSONToolStripMenuItem";
            apriJSONToolStripMenuItem.Size = new Size(72, 20);
            apriJSONToolStripMenuItem.Text = "Apri JSON";
            apriJSONToolStripMenuItem.Click += apriJSONToolStripMenuItem_Click;
            // 
            // rimuoviToolStripMenuItem
            // 
            rimuoviToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { rimuoviPuntoToolStripMenuItem, rimuoviSegmentoToolStripMenuItem });
            rimuoviToolStripMenuItem.Name = "rimuoviToolStripMenuItem";
            rimuoviToolStripMenuItem.Size = new Size(63, 20);
            rimuoviToolStripMenuItem.Text = "Rimuovi";
            // 
            // rimuoviPuntoToolStripMenuItem
            // 
            rimuoviPuntoToolStripMenuItem.Name = "rimuoviPuntoToolStripMenuItem";
            rimuoviPuntoToolStripMenuItem.Size = new Size(175, 22);
            rimuoviPuntoToolStripMenuItem.Text = "Rimuovi Punto";
            rimuoviPuntoToolStripMenuItem.Click += rimuoviPuntoToolStripMenuItem_Click;
            // 
            // rimuoviSegmentoToolStripMenuItem
            // 
            rimuoviSegmentoToolStripMenuItem.Name = "rimuoviSegmentoToolStripMenuItem";
            rimuoviSegmentoToolStripMenuItem.Size = new Size(175, 22);
            rimuoviSegmentoToolStripMenuItem.Text = "Rimuovi Segmento";
            rimuoviSegmentoToolStripMenuItem.Click += rimuoviSegmentoToolStripMenuItem_Click;
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
            // saveConfigToolStripMenuItem
            // 
            saveConfigToolStripMenuItem.Name = "saveConfigToolStripMenuItem";
            saveConfigToolStripMenuItem.Size = new Size(130, 20);
            saveConfigToolStripMenuItem.Text = "Salva Configurazione";
            saveConfigToolStripMenuItem.Click += salvaConfigurazioneToolStripMenuItem_Click;
            // 
            // cancellaConfiguToolStripMenuItem
            // 
            cancellaConfiguToolStripMenuItem.Name = "cancellaConfiguToolStripMenuItem";
            cancellaConfiguToolStripMenuItem.Size = new Size(149, 20);
            cancellaConfiguToolStripMenuItem.Text = "Cancellla configurazione";
            cancellaConfiguToolStripMenuItem.Click += cancellaConfiguToolStripMenuItem_Click;
            // 
            // listBoxPunti
            // 
            listBoxPunti.FormattingEnabled = true;
            listBoxPunti.ItemHeight = 15;
            listBoxPunti.Location = new Point(12, 37);
            listBoxPunti.Name = "listBoxPunti";
            listBoxPunti.Size = new Size(175, 424);
            listBoxPunti.TabIndex = 3;
            listBoxPunti.SelectedIndexChanged += listPoints_SelectedIndexChanged;
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
            // listBoxPuntiSeg
            // 
            listBoxPuntiSeg.FormattingEnabled = true;
            listBoxPuntiSeg.ItemHeight = 15;
            listBoxPuntiSeg.Location = new Point(3, 35);
            listBoxPuntiSeg.Name = "listBoxPuntiSeg";
            listBoxPuntiSeg.Size = new Size(124, 34);
            listBoxPuntiSeg.TabIndex = 5;
            // 
            // pnlSegmenti
            // 
            pnlSegmenti.Controls.Add(listBoxSegmenti);
            pnlSegmenti.Controls.Add(cmbModalita);
            pnlSegmenti.Controls.Add(listBoxPuntiSeg);
            pnlSegmenti.Location = new Point(841, 64);
            pnlSegmenti.Name = "pnlSegmenti";
            pnlSegmenti.Size = new Size(131, 424);
            pnlSegmenti.TabIndex = 6;
            // 
            // listBoxSegmenti
            // 
            listBoxSegmenti.FormattingEnabled = true;
            listBoxSegmenti.ItemHeight = 15;
            listBoxSegmenti.Location = new Point(4, 72);
            listBoxSegmenti.Name = "listBoxSegmenti";
            listBoxSegmenti.Size = new Size(124, 349);
            listBoxSegmenti.TabIndex = 6;
            // 
            // txtNomePiano
            // 
            txtNomePiano.Location = new Point(844, 35);
            txtNomePiano.Name = "txtNomePiano";
            txtNomePiano.PlaceholderText = "Nome piano";
            txtNomePiano.Size = new Size(124, 23);
            txtNomePiano.TabIndex = 7;
            // 
            // Mappatura
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 561);
            Controls.Add(txtNomePiano);
            Controls.Add(pnlSegmenti);
            Controls.Add(listBoxPunti);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Mappatura";
            Text = "Form1";
            FormClosed += Mappatura_FormClosed;
            Load += Form1_Load;
            ClientSizeChanged += Form1_ClientSizeChanged;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            pnlSegmenti.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem caricaToolStripMenuItem;
        private ToolStripMenuItem salvaJSONToolStripMenuItem;
        private ListBox listBoxPunti;
        private ToolStripMenuItem apriJSONToolStripMenuItem;
        private ToolStripMenuItem rimuoviToolStripMenuItem;
        private ToolStripMenuItem modalitaToolStripMenuItem;
        private ToolStripMenuItem segmentoToolStripMenuItem;
        private ToolStripMenuItem puntoToolStripMenuItem;
        private ComboBox cmbModalita;
        private ListBox listBoxPuntiSeg;
        private Panel pnlSegmenti;
        private ListBox listBoxSegmenti;
        private ToolStripMenuItem rimuoviPuntoToolStripMenuItem;
        private ToolStripMenuItem rimuoviSegmentoToolStripMenuItem;
        private ToolStripMenuItem saveConfigToolStripMenuItem;
        private TextBox txtNomePiano;
        private ToolStripMenuItem cancellaConfiguToolStripMenuItem;
    }
}
