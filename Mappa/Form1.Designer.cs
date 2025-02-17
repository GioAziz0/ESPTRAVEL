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
            inserisciPianoToolStripMenuItem = new ToolStripMenuItem();
            listPoints = new ListBox();
            cmbModalita = new ComboBox();
            listPuntiSeg = new ListBox();
            pnlSegmenti = new Panel();
            listSegmenti = new ListBox();
            lblPianoAttuale = new Label();
            btnVaiAPianoSuperiore = new PictureBox();
            btnVaiAPianoInferiore = new PictureBox();
            panel1 = new Panel();
            lblPianoMinimo = new Label();
            lblPianoMassimo = new Label();
            superioreToolStripMenuItem = new ToolStripMenuItem();
            inferioreToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            pnlSegmenti.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnVaiAPianoSuperiore).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnVaiAPianoInferiore).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { caricaToolStripMenuItem, salvaJSONToolStripMenuItem, apriJSONToolStripMenuItem, rimuoviToolStripMenuItem, modalitaToolStripMenuItem, inserisciPianoToolStripMenuItem });
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
            // inserisciPianoToolStripMenuItem
            // 
            inserisciPianoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { superioreToolStripMenuItem, inferioreToolStripMenuItem });
            inserisciPianoToolStripMenuItem.Name = "inserisciPianoToolStripMenuItem";
            inserisciPianoToolStripMenuItem.Size = new Size(94, 20);
            inserisciPianoToolStripMenuItem.Text = "Inserisci Piano";
            // 
            // listPoints
            // 
            listPoints.FormattingEnabled = true;
            listPoints.ItemHeight = 15;
            listPoints.Location = new Point(12, 37);
            listPoints.Name = "listPoints";
            listPoints.Size = new Size(175, 424);
            listPoints.TabIndex = 3;
            listPoints.SelectedIndexChanged += listPoints_SelectedIndexChanged;
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
            pnlSegmenti.Location = new Point(840, 37);
            pnlSegmenti.Name = "pnlSegmenti";
            pnlSegmenti.Size = new Size(131, 424);
            pnlSegmenti.TabIndex = 6;
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
            // lblPianoAttuale
            // 
            lblPianoAttuale.AutoSize = true;
            lblPianoAttuale.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPianoAttuale.Location = new Point(20, 56);
            lblPianoAttuale.Name = "lblPianoAttuale";
            lblPianoAttuale.Size = new Size(19, 21);
            lblPianoAttuale.TabIndex = 9;
            lblPianoAttuale.Text = "0";
            // 
            // btnVaiAPianoSuperiore
            // 
            btnVaiAPianoSuperiore.BackgroundImage = Properties.Resources.frecciasu;
            btnVaiAPianoSuperiore.Image = Properties.Resources.frecciasu;
            btnVaiAPianoSuperiore.Location = new Point(3, 3);
            btnVaiAPianoSuperiore.Name = "btnVaiAPianoSuperiore";
            btnVaiAPianoSuperiore.Size = new Size(50, 50);
            btnVaiAPianoSuperiore.SizeMode = PictureBoxSizeMode.StretchImage;
            btnVaiAPianoSuperiore.TabIndex = 10;
            btnVaiAPianoSuperiore.TabStop = false;
            // 
            // btnVaiAPianoInferiore
            // 
            btnVaiAPianoInferiore.BackgroundImage = Properties.Resources.frecciagiu;
            btnVaiAPianoInferiore.Image = Properties.Resources.frecciagiu;
            btnVaiAPianoInferiore.Location = new Point(3, 80);
            btnVaiAPianoInferiore.Name = "btnVaiAPianoInferiore";
            btnVaiAPianoInferiore.Size = new Size(50, 50);
            btnVaiAPianoInferiore.SizeMode = PictureBoxSizeMode.StretchImage;
            btnVaiAPianoInferiore.TabIndex = 11;
            btnVaiAPianoInferiore.TabStop = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblPianoMinimo);
            panel1.Controls.Add(lblPianoMassimo);
            panel1.Controls.Add(btnVaiAPianoSuperiore);
            panel1.Controls.Add(lblPianoAttuale);
            panel1.Controls.Add(btnVaiAPianoInferiore);
            panel1.Location = new Point(750, 37);
            panel1.Name = "panel1";
            panel1.Size = new Size(84, 138);
            panel1.TabIndex = 13;
            // 
            // lblPianoMinimo
            // 
            lblPianoMinimo.AutoSize = true;
            lblPianoMinimo.Location = new Point(59, 106);
            lblPianoMinimo.Name = "lblPianoMinimo";
            lblPianoMinimo.Size = new Size(13, 15);
            lblPianoMinimo.TabIndex = 15;
            lblPianoMinimo.Text = "0";
            // 
            // lblPianoMassimo
            // 
            lblPianoMassimo.AutoSize = true;
            lblPianoMassimo.Location = new Point(59, 12);
            lblPianoMassimo.Name = "lblPianoMassimo";
            lblPianoMassimo.Size = new Size(13, 15);
            lblPianoMassimo.TabIndex = 14;
            lblPianoMassimo.Text = "0";
            // 
            // superioreToolStripMenuItem
            // 
            superioreToolStripMenuItem.Name = "superioreToolStripMenuItem";
            superioreToolStripMenuItem.Size = new Size(180, 22);
            superioreToolStripMenuItem.Text = "Superiore";
            superioreToolStripMenuItem.Click += superioreToolStripMenuItem_Click;
            // 
            // inferioreToolStripMenuItem
            // 
            inferioreToolStripMenuItem.Name = "inferioreToolStripMenuItem";
            inferioreToolStripMenuItem.Size = new Size(180, 22);
            inferioreToolStripMenuItem.Text = "Inferiore";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 561);
            Controls.Add(panel1);
            Controls.Add(pnlSegmenti);
            Controls.Add(listPoints);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ClientSizeChanged += Form1_ClientSizeChanged;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            pnlSegmenti.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)btnVaiAPianoSuperiore).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnVaiAPianoInferiore).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
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
        private ListBox listPuntiSeg;
        private Panel pnlSegmenti;
        private ListBox listSegmenti;
        private ToolStripMenuItem inserisciPianoToolStripMenuItem;
        private Label lblPianoAttuale;
        private PictureBox btnVaiAPianoSuperiore;
        private PictureBox btnVaiAPianoInferiore;
        private Panel panel1;
        private Label lblPianoMassimo;
        private Label lblPianoMinimo;
        private ToolStripMenuItem superioreToolStripMenuItem;
        private ToolStripMenuItem inferioreToolStripMenuItem;
    }
}
