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
            rimuoviToolStripMenuItem = new ToolStripMenuItem();
            rimuoviPuntoToolStripMenuItem = new ToolStripMenuItem();
            rimuoviSegmentoToolStripMenuItem = new ToolStripMenuItem();
            modalitaToolStripMenuItem = new ToolStripMenuItem();
            segmentoToolStripMenuItem = new ToolStripMenuItem();
            puntoToolStripMenuItem = new ToolStripMenuItem();
            saveConfigToolStripMenuItem = new ToolStripMenuItem();
            cancellaConfiguToolStripMenuItem = new ToolStripMenuItem();
            listBoxPunti = new ListBox();
            listBoxPuntiSeg = new ListBox();
            pnlSegmenti = new Panel();
            txtLevel = new TextBox();
            panel1 = new Panel();
            chSegmentiContinui = new CheckBox();
            label1 = new Label();
            btnPuntoMode = new RadioButton();
            btnSegmentoMode = new RadioButton();
            txtNomePiano = new TextBox();
            listBoxSegmenti = new ListBox();
            menuStrip1.SuspendLayout();
            pnlSegmenti.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { caricaToolStripMenuItem, rimuoviToolStripMenuItem, modalitaToolStripMenuItem, saveConfigToolStripMenuItem, cancellaConfiguToolStripMenuItem });
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
            // listBoxPuntiSeg
            // 
            listBoxPuntiSeg.FormattingEnabled = true;
            listBoxPuntiSeg.ItemHeight = 15;
            listBoxPuntiSeg.Location = new Point(4, 195);
            listBoxPuntiSeg.Name = "listBoxPuntiSeg";
            listBoxPuntiSeg.Size = new Size(124, 34);
            listBoxPuntiSeg.TabIndex = 5;
            // 
            // pnlSegmenti
            // 
            pnlSegmenti.Controls.Add(txtLevel);
            pnlSegmenti.Controls.Add(panel1);
            pnlSegmenti.Controls.Add(txtNomePiano);
            pnlSegmenti.Controls.Add(listBoxSegmenti);
            pnlSegmenti.Controls.Add(listBoxPuntiSeg);
            pnlSegmenti.Location = new Point(841, 37);
            pnlSegmenti.Name = "pnlSegmenti";
            pnlSegmenti.Size = new Size(131, 512);
            pnlSegmenti.TabIndex = 6;
            // 
            // txtLevel
            // 
            txtLevel.Location = new Point(4, 32);
            txtLevel.Name = "txtLevel";
            txtLevel.PlaceholderText = "Livello n.";
            txtLevel.Size = new Size(124, 23);
            txtLevel.TabIndex = 12;
            // 
            // panel1
            // 
            panel1.Controls.Add(chSegmentiContinui);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnPuntoMode);
            panel1.Controls.Add(btnSegmentoMode);
            panel1.Location = new Point(4, 61);
            panel1.Name = "panel1";
            panel1.Size = new Size(124, 123);
            panel1.TabIndex = 11;
            // 
            // chSegmentiContinui
            // 
            chSegmentiContinui.AutoSize = true;
            chSegmentiContinui.Location = new Point(21, 83);
            chSegmentiContinui.Name = "chSegmentiContinui";
            chSegmentiContinui.Size = new Size(73, 34);
            chSegmentiContinui.TabIndex = 12;
            chSegmentiContinui.Text = "Modalità\r\ncontinua";
            chSegmentiContinui.UseVisualStyleBackColor = true;
            chSegmentiContinui.CheckedChanged += chSegmentiContinui_CheckedChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(118, 30);
            label1.TabIndex = 11;
            label1.Text = "Seleziona la modalità\r\ndi inserimento";
            // 
            // btnPuntoMode
            // 
            btnPuntoMode.AutoSize = true;
            btnPuntoMode.Checked = true;
            btnPuntoMode.Location = new Point(3, 33);
            btnPuntoMode.Name = "btnPuntoMode";
            btnPuntoMode.Size = new Size(57, 19);
            btnPuntoMode.TabIndex = 7;
            btnPuntoMode.TabStop = true;
            btnPuntoMode.Text = "Punto";
            btnPuntoMode.UseVisualStyleBackColor = true;
            // 
            // btnSegmentoMode
            // 
            btnSegmentoMode.AutoSize = true;
            btnSegmentoMode.Location = new Point(3, 58);
            btnSegmentoMode.Name = "btnSegmentoMode";
            btnSegmentoMode.Size = new Size(79, 19);
            btnSegmentoMode.TabIndex = 10;
            btnSegmentoMode.Text = "Segmento";
            btnSegmentoMode.UseVisualStyleBackColor = true;
            // 
            // txtNomePiano
            // 
            txtNomePiano.Location = new Point(4, 3);
            txtNomePiano.Name = "txtNomePiano";
            txtNomePiano.PlaceholderText = "Nome piano";
            txtNomePiano.Size = new Size(124, 23);
            txtNomePiano.TabIndex = 7;
            // 
            // listBoxSegmenti
            // 
            listBoxSegmenti.FormattingEnabled = true;
            listBoxSegmenti.ItemHeight = 15;
            listBoxSegmenti.Location = new Point(4, 235);
            listBoxSegmenti.Name = "listBoxSegmenti";
            listBoxSegmenti.Size = new Size(124, 274);
            listBoxSegmenti.TabIndex = 6;
            // 
            // Mappatura
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 561);
            Controls.Add(pnlSegmenti);
            Controls.Add(listBoxPunti);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Mappatura";
            Text = "Form1";
            FormClosed += Mappatura_FormClosed;
            Load += Form1_Load;
            ClientSizeChanged += Form1_ClientSizeChanged;
            KeyPress += Mappatura_KeyPress;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            pnlSegmenti.ResumeLayout(false);
            pnlSegmenti.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem caricaToolStripMenuItem;
        private ListBox listBoxPunti;
        private ToolStripMenuItem rimuoviToolStripMenuItem;
        private ToolStripMenuItem modalitaToolStripMenuItem;
        private ToolStripMenuItem segmentoToolStripMenuItem;
        private ToolStripMenuItem puntoToolStripMenuItem;
        private ListBox listBoxPuntiSeg;
        private Panel pnlSegmenti;
        private ListBox listBoxSegmenti;
        private ToolStripMenuItem rimuoviPuntoToolStripMenuItem;
        private ToolStripMenuItem rimuoviSegmentoToolStripMenuItem;
        private ToolStripMenuItem saveConfigToolStripMenuItem;
        private TextBox txtNomePiano;
        private ToolStripMenuItem cancellaConfiguToolStripMenuItem;
        private RadioButton btnPuntoMode;
        private RadioButton btnSegmentoMode;
        private Panel panel1;
        private Label label1;
        private TextBox txtLevel;
        private CheckBox chSegmentiContinui;
    }
}
