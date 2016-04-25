using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PrettyGirl
{
    public partial class PreviewForm : Form
    {
        public PictureBox PictureBox
        {
            get { return pictureBox1; }
        }

        public PreviewForm()
        {
            InitializeComponent();
            

        }

        public void Refresh(Bitmap bitmap)
        {
            if (bitmap != null)
                pictureBox1.Image = pictureBox1.Image = new Bitmap(bitmap, pictureBox1.Width,
                                    pictureBox1.Height);
        }
    }
}
