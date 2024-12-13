using System.Windows.Forms;

namespace Mappa
{
    public partial class Form1 : Form
    {
        PictureBox pictureBox;
        float ratio;
        Image originalImage;

        public Form1()
        {
            InitializeComponent();
            pictureBox = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            this.Resize += Form1_Resize; // Collega l'evento Resize del form
        }

        private void caricaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Immagini|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            fileDialog.Title = "Seleziona immagine";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string imgPath = fileDialog.FileName;
                originalImage = Image.FromFile(imgPath);
                pictureBox.Image = new Bitmap(originalImage);

                // Calcola il rapporto larghezza/altezza
                ratio = (float)originalImage.Width / originalImage.Height;

                ResizePictureBox(); // Ridimensiona il PictureBox
                pictureBox.MouseClick += pctClick; // Collega l'evento Click del PictureBox
                Controls.Add(pictureBox);
            }
        }

        private void ResizePictureBox()
        {
            // Ottieni le dimensioni disponibili della finestra
            int availableWidth = this.ClientSize.Width;
            int availableHeight = this.ClientSize.Height;

            // Calcola il nuovo rettangolo del PictureBox rispettando le proporzioni
            int newWidth, newHeight;
            if ((float)availableWidth / availableHeight > ratio)
            {
                newHeight = availableHeight-100;
                newWidth = (int)(newHeight * ratio);
            }
            else
            {
                newWidth = availableWidth-100;
                newHeight = (int)(newWidth / ratio);
            }

            // Centra il PictureBox nella finestra
            pictureBox.Width = newWidth;
            pictureBox.Height = newHeight;
            pictureBox.Left = (this.ClientSize.Width - pictureBox.Width) / 2;
            pictureBox.Top = (this.ClientSize.Height - pictureBox.Height) / 2;
        }

        private void pctClick(object sender, MouseEventArgs e)
        {
            // Converte le coordinate del click per adattarle all'immagine originale
            float scaleX = (float)originalImage.Width / pictureBox.Width;
            float scaleY = (float)originalImage.Height / pictureBox.Height;

            int originalX = (int)(e.X * scaleX);
            int originalY = (int)(e.Y * scaleY);

            using (Graphics gpr = Graphics.FromImage(originalImage))
            {
                // Disegna un punto nero nella posizione calcolata
                gpr.FillRectangle(Brushes.Red, originalX - 2, originalY - 2, 5, 5);
            }

            // Aggiorna il PictureBox con l'immagine modificata
            pictureBox.Image = new Bitmap(originalImage);
            pictureBox.Refresh();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (originalImage != null)
            {
                ResizePictureBox();
            }
        }
    }
}
