namespace Mappa
{
    partial class HomePage
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
            listView1 = new ListView();
            toolTip1 = new ToolTip(components);
            menuStrip1 = new MenuStrip();
            ciaoToolStripMenuItem = new ToolStripMenuItem();
            sparaMappaToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Location = new Point(318, 46);
            listView1.Name = "listView1";
            listView1.Size = new Size(377, 194);
            listView1.TabIndex = 2;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // menuStrip1
            // 
            menuStrip1.Dock = DockStyle.Left;
            menuStrip1.GripStyle = ToolStripGripStyle.Visible;
            menuStrip1.Items.AddRange(new ToolStripItem[] { ciaoToolStripMenuItem, sparaMappaToolStripMenuItem, toolStripMenuItem1 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(123, 453);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            menuStrip1.TextDirection = ToolStripTextDirection.Vertical270;
            // 
            // ciaoToolStripMenuItem
            // 
            ciaoToolStripMenuItem.Name = "ciaoToolStripMenuItem";
            ciaoToolStripMenuItem.Size = new Size(116, 19);
            ciaoToolStripMenuItem.Text = "_Carica Immagine";
            ciaoToolStripMenuItem.TextDirection = ToolStripTextDirection.Horizontal;
            ciaoToolStripMenuItem.Click += ciaoToolStripMenuItem_Click_1;
            // 
            // sparaMappaToolStripMenuItem
            // 
            sparaMappaToolStripMenuItem.Name = "sparaMappaToolStripMenuItem";
            sparaMappaToolStripMenuItem.Size = new Size(116, 19);
            sparaMappaToolStripMenuItem.Text = "_SparaMappa";
            sparaMappaToolStripMenuItem.TextDirection = ToolStripTextDirection.Horizontal;
            sparaMappaToolStripMenuItem.Click += sparaMappaToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(116, 4);
            // 
            // HomePage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(798, 453);
            Controls.Add(listView1);
            Controls.Add(menuStrip1);
            Name = "HomePage";
            Text = "HomaPage";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView listView1;
        private ToolTip toolTip1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem ciaoToolStripMenuItem;
        private ToolStripMenuItem sparaMappaToolStripMenuItem;
    }
}