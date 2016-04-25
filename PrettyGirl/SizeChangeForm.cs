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
    public partial class SizeChangeForm : Form
    {
        public int RHeight;
        public int RWidth;

        public SizeChangeForm(int w, int h)
        {
            RWidth = w;
            RHeight = h;
            InitializeComponent();
        }

        private void SizeChangeForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = RWidth.ToString();
            textBox2.Text = RHeight.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int w = RWidth;
            int h = RHeight;
            try
            {
                RWidth = Convert.ToInt32(textBox1.Text);
                RHeight = Convert.ToInt32(textBox2.Text);
                this.Close();
            }
            catch (Exception)
            {
                RWidth= w;
                RHeight = h;
                MessageBox.Show("значения неверны");
                throw;
            }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {


                 if (comboBox1.SelectedItem.ToString() == "Малый")
                {
                    RWidth = 420;
                    RHeight = 594;
                }

                else if (comboBox1.SelectedItem.ToString() == "Стандарт")
                {
                    RWidth = 210 * 4;
                    RHeight = 297 * 4;
                }

                else if (comboBox1.SelectedItem.ToString() == "Большой")
                {
                    RWidth = 210*6;
                    RHeight = 297*6;
                }

                 else if (comboBox1.SelectedItem.ToString() == "Огромный")
                 {
                     RWidth = 210 * 8;
                     RHeight = 297 * 8;
                 }

                else if (comboBox1.SelectedItem.ToString() == "А4")
                {
                    RWidth = 2480;
                    RHeight = 3508;
                }

                else if (comboBox1.SelectedItem.ToString() == "B5")
                {
                    RWidth = 1524;
                    RHeight = 2150;
                }

                  

                textBox1.Text = RWidth.ToString();
                textBox2.Text = RHeight.ToString();
            }
        }
    }
}
