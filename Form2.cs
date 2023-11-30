using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pokemon
{
    public partial class Battle : Form
    {
        public Battle()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
            
        }
        private void ChangePictureBoxImage(string imageName)
        {
            
            string imagePath = $"C:\\Users\\s3keka03\\source\\repos\\pokemon\\pictures\\{imageName}.png";

            
            if (System.IO.File.Exists(imagePath))
            {
                
                pictureBox1.Image = Image.FromFile(imagePath);
            }
            else
            {
                
                pictureBox1.Image = null;
            }
        }

     
    }
}
