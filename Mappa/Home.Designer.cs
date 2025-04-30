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
            listView1 = new ListView();
            menuStrip1.SuspendLayout();
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
            menuStrip1.Items.AddRange(new ToolStripItem[] { aggiungiPianoToolStripMenuItem, eliminaPianoToolStripMenuItem, aPToolStripMenuItem, salvaJsonToolStripMenuItem, apriJsonToolStripMenuItem });
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
            // listView1
            // 
            listView1.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            listView1.Location = new Point(12, 27);
            listView1.Name = "listView1";
            listView1.Size = new Size(300, 375);
            listView1.TabIndex = 2;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(listView1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Home";
            Text = "Homecs";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
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
    }
}