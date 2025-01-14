namespace Mappa
{
    partial class Form1
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
            modalitaToolStripMenuItem = new ToolStripMenuItem();
            segmentoToolStripMenuItem = new ToolStripMenuItem();
            puntoToolStripMenuItem = new ToolStripMenuItem();
            listPoints = new ListBox();
            cmbModalita = new ComboBox();
            listSegmenti = new ListBox();
            panel1 = new Panel();
            menuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { caricaToolStripMenuItem, salvaJSONToolStripMenuItem, apriJSONToolStripMenuItem, rimuoviToolStripMenuItem, modalitaToolStripMenuItem });
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
            rimuoviToolStripMenuItem.Name = "rimuoviToolStripMenuItem";
            rimuoviToolStripMenuItem.Size = new Size(63, 20);
            rimuoviToolStripMenuItem.Text = "Rimuovi";
            rimuoviToolStripMenuItem.Click += rimuoviToolStripMenuItem_Click;
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
            listPoints.Location = new Point(12, 37);
            listPoints.Name = "listPoints";
            listPoints.Size = new Size(175, 424);
            listPoints.TabIndex = 3;
            // 
            // cmbModalita
            // 
            cmbModalita.DisplayMember = "(nessuno)";
            cmbModalita.FormattingEnabled = true;
            cmbModalita.Items.AddRange(new object[] { "Punto", "Segmento" });
            cmbModalita.Location = new Point(3, 3);
            cmbModalita.Name = "cmbModalita";
            cmbModalita.Size = new Size(124, 23);
            cmbModalita.TabIndex = 4;
            // 
            // listSegmenti
            // 
            listSegmenti.FormattingEnabled = true;
            listSegmenti.ItemHeight = 15;
            listSegmenti.Location = new Point(3, 32);
            listSegmenti.Name = "listSegmenti";
            listSegmenti.Size = new Size(124, 64);
            listSegmenti.TabIndex = 5;
            // 
            // panel1
            // 
            panel1.Controls.Add(cmbModalita);
            panel1.Controls.Add(listSegmenti);
            panel1.Location = new Point(840, 37);
            panel1.Name = "panel1";
            panel1.Size = new Size(131, 304);
            panel1.TabIndex = 6;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 511);
            Controls.Add(panel1);
            Controls.Add(listPoints);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            ClientSizeChanged += Form1_ClientSizeChanged;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem caricaToolStripMenuItem;
        private ToolStripMenuItem salvaJSONToolStripMenuItem;
        private ListBox listPoints;
        private ToolStripMenuItem apriJSONToolStripMenuItem;
        private ToolStripMenuItem rimuoviToolStripMenuItem;
        private ToolStripMenuItem modalitaToolStripMenuItem;
        private ToolStripMenuItem segmentoToolStripMenuItem;
        private ToolStripMenuItem puntoToolStripMenuItem;
        private ComboBox cmbModalita;
        private ListBox listSegmenti;
        private Panel panel1;
    }
}
