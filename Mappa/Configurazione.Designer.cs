namespace Mappa
{
    partial class Configurazione
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
            lstPuntiPiano1 = new ListBox();
            lstPuntiPiano2 = new ListBox();
            lblPiano1 = new Label();
            lblPiano2 = new Label();
            listView1 = new ListView();
            label3 = new Label();
            btn_collega = new Button();
            SuspendLayout();
            // 
            // lstPuntiPiano1
            // 
            lstPuntiPiano1.FormattingEnabled = true;
            lstPuntiPiano1.ItemHeight = 15;
            lstPuntiPiano1.Location = new Point(12, 47);
            lstPuntiPiano1.Name = "lstPuntiPiano1";
            lstPuntiPiano1.Size = new Size(250, 349);
            lstPuntiPiano1.TabIndex = 0;
            // 
            // lstPuntiPiano2
            // 
            lstPuntiPiano2.FormattingEnabled = true;
            lstPuntiPiano2.ItemHeight = 15;
            lstPuntiPiano2.Location = new Point(321, 47);
            lstPuntiPiano2.Name = "lstPuntiPiano2";
            lstPuntiPiano2.Size = new Size(250, 349);
            lstPuntiPiano2.TabIndex = 1;
            // 
            // lblPiano1
            // 
            lblPiano1.AutoSize = true;
            lblPiano1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPiano1.Location = new Point(12, 9);
            lblPiano1.Name = "lblPiano1";
            lblPiano1.Size = new Size(78, 32);
            lblPiano1.TabIndex = 2;
            lblPiano1.Text = "label1";
            // 
            // lblPiano2
            // 
            lblPiano2.AutoSize = true;
            lblPiano2.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPiano2.Location = new Point(321, 9);
            lblPiano2.Name = "lblPiano2";
            lblPiano2.Size = new Size(78, 32);
            lblPiano2.TabIndex = 3;
            lblPiano2.Text = "label2";
            // 
            // listView1
            // 
            listView1.Location = new Point(613, 47);
            listView1.Name = "listView1";
            listView1.Size = new Size(150, 100);
            listView1.TabIndex = 4;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(613, 9);
            label3.Name = "label3";
            label3.Size = new Size(164, 25);
            label3.TabIndex = 5;
            label3.Text = "Punti già collegati";
            // 
            // btn_collega
            // 
            btn_collega.Location = new Point(684, 170);
            btn_collega.Name = "btn_collega";
            btn_collega.Size = new Size(93, 38);
            btn_collega.TabIndex = 6;
            btn_collega.Text = "Collega";
            btn_collega.UseVisualStyleBackColor = true;
            // 
            // Configurazione
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_collega);
            Controls.Add(label3);
            Controls.Add(listView1);
            Controls.Add(lblPiano2);
            Controls.Add(lblPiano1);
            Controls.Add(lstPuntiPiano2);
            Controls.Add(lstPuntiPiano1);
            Name = "Configurazione";
            Text = "Configurazione";
            FormClosing += Configurazione_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lstPuntiPiano1;
        private ListBox lstPuntiPiano2;
        private Label lblPiano1;
        private Label lblPiano2;
        private ListView listView1;
        private Label label3;
        private Button btn_collega;
    }
}