namespace Mappa
{
    partial class Home
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            ImgPiani = new ImageList(components);
            menuStrip1 = new MenuStrip();
            aggiungiPianoToolStripMenuItem = new ToolStripMenuItem();
            eliminaPianoToolStripMenuItem = new ToolStripMenuItem();
            aPToolStripMenuItem = new ToolStripMenuItem();
            salvaJsonToolStripMenuItem = new ToolStripMenuItem();
            localeToolStripMenuItem = new ToolStripMenuItem();
            cluodToolStripMenuItem = new ToolStripMenuItem();
            entrambiToolStripMenuItem = new ToolStripMenuItem();
            apriJsonToolStripMenuItem = new ToolStripMenuItem();
            apriCollegaPianiToolStripMenuItem = new ToolStripMenuItem();
            listView1 = new ListView();
            pnlCollegaPiani = new Panel();
            listView2 = new ListView();
            btnVaiConfigurazione = new Button();
            menuStrip1.SuspendLayout();
            pnlCollegaPiani.SuspendLayout();
            SuspendLayout();
            // 
            // ImgPiani
            // 
            ImgPiani.ColorDepth = ColorDepth.Depth32Bit;
            ImgPiani.ImageStream = (ImageListStreamer)resources.GetObject("ImgPiani.ImageStream");
            ImgPiani.TransparentColor = Color.Transparent;
            ImgPiani.Images.SetKeyName(0, "reset.png");
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { aggiungiPianoToolStripMenuItem, eliminaPianoToolStripMenuItem, aPToolStripMenuItem, salvaJsonToolStripMenuItem, apriJsonToolStripMenuItem, apriCollegaPianiToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // aggiungiPianoToolStripMenuItem
            // 
            aggiungiPianoToolStripMenuItem.Name = "aggiungiPianoToolStripMenuItem";
            aggiungiPianoToolStripMenuItem.Size = new Size(101, 20);
            aggiungiPianoToolStripMenuItem.Text = "Aggiungi Piano";
            aggiungiPianoToolStripMenuItem.Click += aggiungiPianoToolStripMenuItem_Click;
            // 
            // eliminaPianoToolStripMenuItem
            // 
            eliminaPianoToolStripMenuItem.Name = "eliminaPianoToolStripMenuItem";
            eliminaPianoToolStripMenuItem.Size = new Size(91, 20);
            eliminaPianoToolStripMenuItem.Text = "Elimina Piano";
            // 
            // aPToolStripMenuItem
            // 
            aPToolStripMenuItem.Name = "aPToolStripMenuItem";
            aPToolStripMenuItem.Size = new Size(74, 20);
            aPToolStripMenuItem.Text = "Apri Piano";
            aPToolStripMenuItem.Click += aPToolStripMenuItem_Click;
            // 
            // salvaJsonToolStripMenuItem
            // 
            salvaJsonToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { localeToolStripMenuItem, cluodToolStripMenuItem, entrambiToolStripMenuItem });
            salvaJsonToolStripMenuItem.Name = "salvaJsonToolStripMenuItem";
            salvaJsonToolStripMenuItem.Size = new Size(72, 20);
            salvaJsonToolStripMenuItem.Text = "Salva Json";
            // 
            // localeToolStripMenuItem
            // 
            localeToolStripMenuItem.Name = "localeToolStripMenuItem";
            localeToolStripMenuItem.Size = new Size(122, 22);
            localeToolStripMenuItem.Text = "Locale";
            localeToolStripMenuItem.Click += salvaJsonLocale;
            // 
            // cluodToolStripMenuItem
            // 
            cluodToolStripMenuItem.Name = "cluodToolStripMenuItem";
            cluodToolStripMenuItem.Size = new Size(122, 22);
            cluodToolStripMenuItem.Text = "Cluod";
            cluodToolStripMenuItem.Click += SalvaJsonCluod;
            // 
            // entrambiToolStripMenuItem
            // 
            entrambiToolStripMenuItem.Name = "entrambiToolStripMenuItem";
            entrambiToolStripMenuItem.Size = new Size(122, 22);
            entrambiToolStripMenuItem.Text = "Entrambi";
            // 
            // apriJsonToolStripMenuItem
            // 
            apriJsonToolStripMenuItem.Name = "apriJsonToolStripMenuItem";
            apriJsonToolStripMenuItem.Size = new Size(67, 20);
            apriJsonToolStripMenuItem.Text = "Apri Json";
            apriJsonToolStripMenuItem.Click += apriJsonToolStripMenuItem_Click;
            // 
            // apriCollegaPianiToolStripMenuItem
            // 
            apriCollegaPianiToolStripMenuItem.Name = "apriCollegaPianiToolStripMenuItem";
            apriCollegaPianiToolStripMenuItem.Size = new Size(113, 20);
            apriCollegaPianiToolStripMenuItem.Text = "Apri Collega Piani";
            // 
            // listView1
            // 
            listView1.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            listView1.Location = new Point(12, 27);
            listView1.Name = "listView1";
            listView1.Size = new Size(300, 375);
            listView1.TabIndex = 2;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // pnlCollegaPiani
            // 
            pnlCollegaPiani.Controls.Add(btnVaiConfigurazione);
            pnlCollegaPiani.Controls.Add(listView2);
            pnlCollegaPiani.Location = new Point(318, 27);
            pnlCollegaPiani.Name = "pnlCollegaPiani";
            pnlCollegaPiani.Size = new Size(402, 242);
            pnlCollegaPiani.TabIndex = 3;
            // 
            // listView2
            // 
            listView2.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            listView2.Location = new Point(3, 28);
            listView2.Name = "listView2";
            listView2.Size = new Size(189, 81);
            listView2.TabIndex = 4;
            listView2.UseCompatibleStateImageBehavior = false;
            // 
            // btnVaiConfigurazione
            // 
            btnVaiConfigurazione.Location = new Point(268, 98);
            btnVaiConfigurazione.Name = "btnVaiConfigurazione";
            btnVaiConfigurazione.Size = new Size(75, 23);
            btnVaiConfigurazione.TabIndex = 5;
            btnVaiConfigurazione.Text = "Vai";
            btnVaiConfigurazione.UseVisualStyleBackColor = true;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pnlCollegaPiani);
            Controls.Add(listView1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Home";
            Text = "Homecs";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            pnlCollegaPiani.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ImageList ImgPiani;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem aggiungiPianoToolStripMenuItem;
        private ToolStripMenuItem eliminaPianoToolStripMenuItem;
        private ToolStripMenuItem aPToolStripMenuItem;
        private ToolStripMenuItem salvaJsonToolStripMenuItem;
        private ToolStripMenuItem apriJsonToolStripMenuItem;
        private ToolStripMenuItem localeToolStripMenuItem;
        private ToolStripMenuItem cluodToolStripMenuItem;
        private ToolStripMenuItem entrambiToolStripMenuItem;
        private ListView listView1;
        private ToolStripMenuItem apriCollegaPianiToolStripMenuItem;
        private Panel pnlCollegaPiani;
        private ListView listView2;
        private Button btnVaiConfigurazione;
    }
}