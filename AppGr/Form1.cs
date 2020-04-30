using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneradorQR 
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
            QrCode qrCode = new QrCode();
            qrEncoder.TryEncode(textValor.Text, out qrCode);
            GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(400,QuietZoneModules.Zero),Brushes.Black,Brushes.White);

            MemoryStream ms = new MemoryStream();
            renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
            var imageTemporal = new Bitmap(ms);
            var imagen = new Bitmap(imageTemporal, new Size(new Point(200,200)));
            panelResultado.BackgroundImage = imagen;

            imagen.Save("imagen.png",ImageFormat.Png);
            btnGuardar.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Image img = (Image)panelResultado.BackgroundImage.Clone();

            SaveFileDialog caja = new SaveFileDialog();
            caja.AddExtension = true;
            caja.Filter = "Image PNG(*.png)|*.png";
            caja.ShowDialog();
            if (!string.IsNullOrEmpty(caja.FileName))
                img.Save(caja.FileName,ImageFormat.Png);


            {
                img.Dispose();
            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }
    }
}
