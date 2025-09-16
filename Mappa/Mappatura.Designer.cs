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
            panel3 = new Panel();
            label5 = new Label();
            AccessibleNo = new RadioButton();
            chSegmentiContinui = new CheckBox();
            AccessibleYes = new RadioButton();
            panel2 = new Panel();
            label4 = new Label();
            JointNo = new RadioButton();
            JointYes = new RadioButton();
            label1 = new Label();
            btnPuntoMode = new RadioButton();
            btnSegmentoMode = new RadioButton();
            txtNomePiano = new TextBox();
            listBoxSegmenti = new ListBox();
            label2 = new Label();
            btnModificaNomePunto = new Button();
            label3 = new Label();
            txtNomePunto = new TextBox();
            trackBar1 = new TrackBar();
            pnlPunti = new Panel();
            menuStrip1.SuspendLayout();
            pnlSegmenti.SuspendLayout();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            pnlPunti.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            menuStrip1.Items.AddRange(new ToolStripItem[] { caricaToolStripMenuItem, rimuoviToolStripMenuItem, modalitaToolStripMenuItem, saveConfigToolStripMenuItem, cancellaConfiguToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(984, 29);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // caricaToolStripMenuItem
            // 
            caricaToolStripMenuItem.Name = "caricaToolStripMenuItem";
            caricaToolStripMenuItem.Size = new Size(143, 25);
            caricaToolStripMenuItem.Text = "Carica Immagine";
            caricaToolStripMenuItem.Click += caricaToolStripMenuItem_Click;
            // 
            // rimuoviToolStripMenuItem
            // 
            rimuoviToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { rimuoviPuntoToolStripMenuItem, rimuoviSegmentoToolStripMenuItem });
            rimuoviToolStripMenuItem.Name = "rimuoviToolStripMenuItem";
            rimuoviToolStripMenuItem.Size = new Size(81, 25);
            rimuoviToolStripMenuItem.Text = "Rimuovi";
            // 
            // rimuoviPuntoToolStripMenuItem
            // 
            rimuoviPuntoToolStripMenuItem.Name = "rimuoviPuntoToolStripMenuItem";
            rimuoviPuntoToolStripMenuItem.Size = new Size(219, 26);
            rimuoviPuntoToolStripMenuItem.Text = "Rimuovi Punto";
            rimuoviPuntoToolStripMenuItem.Click += rimuoviPuntoToolStripMenuItem_Click;
            // 
            // rimuoviSegmentoToolStripMenuItem
            // 
            rimuoviSegmentoToolStripMenuItem.Name = "rimuoviSegmentoToolStripMenuItem";
            rimuoviSegmentoToolStripMenuItem.Size = new Size(219, 26);
            rimuoviSegmentoToolStripMenuItem.Text = "Rimuovi Segmento";
            rimuoviSegmentoToolStripMenuItem.Click += rimuoviSegmentoToolStripMenuItem_Click;
            // 
            // modalitaToolStripMenuItem
            // 
            modalitaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { segmentoToolStripMenuItem, puntoToolStripMenuItem });
            modalitaToolStripMenuItem.Name = "modalitaToolStripMenuItem";
            modalitaToolStripMenuItem.Size = new Size(87, 25);
            modalitaToolStripMenuItem.Text = "Modalita";
            // 
            // segmentoToolStripMenuItem
            // 
            segmentoToolStripMenuItem.BackColor = SystemColors.ButtonHighlight;
            segmentoToolStripMenuItem.Name = "segmentoToolStripMenuItem";
            segmentoToolStripMenuItem.Size = new Size(154, 26);
            segmentoToolStripMenuItem.Text = "segmento";
            // 
            // puntoToolStripMenuItem
            // 
            puntoToolStripMenuItem.Name = "puntoToolStripMenuItem";
            puntoToolStripMenuItem.Size = new Size(154, 26);
            puntoToolStripMenuItem.Text = "punto";
            // 
            // saveConfigToolStripMenuItem
            // 
            saveConfigToolStripMenuItem.Name = "saveConfigToolStripMenuItem";
            saveConfigToolStripMenuItem.Size = new Size(174, 25);
            saveConfigToolStripMenuItem.Text = "Salva Configurazione";
            saveConfigToolStripMenuItem.Click += salvaConfigurazioneToolStripMenuItem_Click;
            // 
            // cancellaConfiguToolStripMenuItem
            // 
            cancellaConfiguToolStripMenuItem.Name = "cancellaConfiguToolStripMenuItem";
            cancellaConfiguToolStripMenuItem.Size = new Size(199, 25);
            cancellaConfiguToolStripMenuItem.Text = "Cancellla configurazione";
            cancellaConfiguToolStripMenuItem.Click += cancellaConfiguToolStripMenuItem_Click;
            // 
            // listBoxPunti
            // 
            listBoxPunti.FormattingEnabled = true;
            listBoxPunti.ItemHeight = 15;
            listBoxPunti.Location = new Point(0, 28);
            listBoxPunti.Name = "listBoxPunti";
            listBoxPunti.Size = new Size(197, 349);
            listBoxPunti.TabIndex = 3;
            listBoxPunti.SelectedIndexChanged += listPoints_SelectedIndexChanged;
            // 
            // listBoxPuntiSeg
            // 
            listBoxPuntiSeg.FormattingEnabled = true;
            listBoxPuntiSeg.ItemHeight = 15;
            listBoxPuntiSeg.Location = new Point(4, 327);
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
            pnlSegmenti.Location = new Point(841, 35);
            pnlSegmenti.Name = "pnlSegmenti";
            pnlSegmenti.Size = new Size(131, 644);
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
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnPuntoMode);
            panel1.Controls.Add(btnSegmentoMode);
            panel1.Location = new Point(4, 61);
            panel1.Name = "panel1";
            panel1.Size = new Size(124, 260);
            panel1.TabIndex = 11;
            // 
            // panel3
            // 
            panel3.Controls.Add(label5);
            panel3.Controls.Add(AccessibleNo);
            panel3.Controls.Add(chSegmentiContinui);
            panel3.Controls.Add(AccessibleYes);
            panel3.Location = new Point(0, 177);
            panel3.Name = "panel3";
            panel3.Size = new Size(124, 80);
            panel3.TabIndex = 17;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(13, 37);
            label5.Name = "label5";
            label5.Size = new Size(77, 15);
            label5.TabIndex = 19;
            label5.Text = "È accessibile?";
            // 
            // AccessibleNo
            // 
            AccessibleNo.AutoSize = true;
            AccessibleNo.Location = new Point(60, 54);
            AccessibleNo.Name = "AccessibleNo";
            AccessibleNo.Size = new Size(41, 19);
            AccessibleNo.TabIndex = 18;
            AccessibleNo.Text = "No";
            AccessibleNo.UseVisualStyleBackColor = true;
            // 
            // chSegmentiContinui
            // 
            chSegmentiContinui.AutoSize = true;
            chSegmentiContinui.Location = new Point(18, 0);
            chSegmentiContinui.Name = "chSegmentiContinui";
            chSegmentiContinui.Size = new Size(73, 34);
            chSegmentiContinui.TabIndex = 12;
            chSegmentiContinui.Text = "Modalità\r\ncontinua";
            chSegmentiContinui.UseVisualStyleBackColor = true;
            chSegmentiContinui.CheckedChanged += chSegmentiContinui_CheckedChanged;
            // 
            // AccessibleYes
            // 
            AccessibleYes.AutoSize = true;
            AccessibleYes.Checked = true;
            AccessibleYes.Location = new Point(13, 54);
            AccessibleYes.Name = "AccessibleYes";
            AccessibleYes.Size = new Size(34, 19);
            AccessibleYes.TabIndex = 17;
            AccessibleYes.TabStop = true;
            AccessibleYes.Text = "Si";
            AccessibleYes.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.Controls.Add(label4);
            panel2.Controls.Add(JointNo);
            panel2.Controls.Add(JointYes);
            panel2.Location = new Point(0, 58);
            panel2.Name = "panel2";
            panel2.Size = new Size(124, 80);
            panel2.TabIndex = 12;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 0);
            label4.Name = "label4";
            label4.Size = new Size(78, 15);
            label4.TabIndex = 16;
            label4.Text = "È uno snodo?";
            // 
            // JointNo
            // 
            JointNo.AutoSize = true;
            JointNo.Location = new Point(60, 17);
            JointNo.Name = "JointNo";
            JointNo.Size = new Size(41, 19);
            JointNo.TabIndex = 15;
            JointNo.Text = "No";
            JointNo.UseVisualStyleBackColor = true;
            // 
            // JointYes
            // 
            JointYes.AutoSize = true;
            JointYes.Checked = true;
            JointYes.Location = new Point(13, 17);
            JointYes.Name = "JointYes";
            JointYes.Size = new Size(34, 19);
            JointYes.TabIndex = 14;
            JointYes.TabStop = true;
            JointYes.Text = "Si";
            JointYes.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.FromArgb(255, 128, 0);
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
            btnPuntoMode.ForeColor = Color.FromArgb(255, 128, 0);
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
            btnSegmentoMode.ForeColor = Color.FromArgb(255, 128, 0);
            btnSegmentoMode.Location = new Point(3, 153);
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
            listBoxSegmenti.Location = new Point(4, 367);
            listBoxSegmenti.Name = "listBoxSegmenti";
            listBoxSegmenti.Size = new Size(124, 274);
            listBoxSegmenti.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(105, 25);
            label2.TabIndex = 7;
            label2.Text = "Lista punti";
            // 
            // btnModificaNomePunto
            // 
            btnModificaNomePunto.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnModificaNomePunto.Location = new Point(120, 430);
            btnModificaNomePunto.Name = "btnModificaNomePunto";
            btnModificaNomePunto.Size = new Size(77, 29);
            btnModificaNomePunto.TabIndex = 8;
            btnModificaNomePunto.Text = "Modifica";
            btnModificaNomePunto.UseVisualStyleBackColor = true;
            btnModificaNomePunto.Click += btnModificaNomePunto_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(0, 391);
            label3.Name = "label3";
            label3.Size = new Size(206, 25);
            label3.TabIndex = 9;
            label3.Text = "Modifica nome punto";
            // 
            // txtNomePunto
            // 
            txtNomePunto.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNomePunto.Location = new Point(0, 430);
            txtNomePunto.Name = "txtNomePunto";
            txtNomePunto.PlaceholderText = "Nome Punto";
            txtNomePunto.Size = new Size(105, 29);
            txtNomePunto.TabIndex = 10;
            txtNomePunto.TextChanged += txtNomePunto_TextChanged;
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(23, 504);
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(104, 45);
            trackBar1.TabIndex = 11;
            // 
            // pnlPunti
            // 
            pnlPunti.Controls.Add(label2);
            pnlPunti.Controls.Add(trackBar1);
            pnlPunti.Controls.Add(listBoxPunti);
            pnlPunti.Controls.Add(txtNomePunto);
            pnlPunti.Controls.Add(btnModificaNomePunto);
            pnlPunti.Controls.Add(label3);
            pnlPunti.Location = new Point(12, 38);
            pnlPunti.Name = "pnlPunti";
            pnlPunti.Size = new Size(200, 599);
            pnlPunti.TabIndex = 12;
            // 
            // Mappatura
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 691);
            Controls.Add(pnlPunti);
            Controls.Add(pnlSegmenti);
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
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            pnlPunti.ResumeLayout(false);
            pnlPunti.PerformLayout();
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
        private TextBox txtLevel;
        private RadioButton btnPuntoMode;
        private RadioButton btnSegmentoMode;
        private Panel panel1;
        private Label label1;
        private CheckBox chSegmentiContinui;
        private Label label2;
        private Button btnModificaNomePunto;
        private Label label3;
        private TextBox txtNomePunto;
        private Label label4;
        private RadioButton JointNo;
        private RadioButton JointYes;
        private TrackBar trackBar1;
        private Panel panel3;
        private Panel panel2;
        private Label label5;
        private RadioButton AccessibleNo;
        private RadioButton AccessibleYes;
        private Panel pnlPunti;
    }
}
