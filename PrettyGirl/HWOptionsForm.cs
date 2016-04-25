using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PrettyGirl
{
    public partial class HWOptionsForm : Form
    {
        public int RMin, RMax;

        public HWOptionsForm(int RMin, int RMax)
        {
            this.RMax = RMax;
            this.RMin = RMin;
            InitializeComponent();
            Set();
        }

        public void Set()
        {
            textBox1.Text = RMin.ToString();
            textBox2.Text = RMax.ToString();

            /*int , int , 
            int , int ,
            int , int , 
            int , int , 
            int , int , int , int , int 
             */
            textBox3.Text = HandRandom.MinGetSpaceLength.ToString();
            textBox4.Text = HandRandom.MaxGetSpaceLength.ToString();
            textBox5.Text = HandRandom.MultiGetSpaceLength.ToString();
            textBox6.Text = HandRandom.MinGetLineSpace.ToString();
            textBox7.Text = HandRandom.MaxGetLineSpace.ToString();
            textBox8.Text = HandRandom.DivGetLetterScaleX.ToString();
            textBox9.Text = HandRandom.DivGetLetterScaleY.ToString();
            textBox10.Text = HandRandom.MinGetDeltaMoveY.ToString();
            textBox11.Text = HandRandom.MaxGetDeltaMoveY.ToString();
            textBox12.Text = HandRandom.BeginY.ToString();
            textBox13.Text = HandRandom.DefaultLine.ToString();
            textBox14.Text = HandRandom.DefaultSpace.ToString();
            textBox15.Text = HandRandom.MinBeginX.ToString();
            textBox16.Text = HandRandom.MaxBeginX.ToString();
            textBox17.Text = HandRandom.ScaleMultipler.ToString();
            textBox18.Text = HandRandom.RightEdge.ToString();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int max = RMax;
            int min = RMin;

            try
            {
                RMin = Convert.ToInt32(textBox1.Text);
                RMax = Convert.ToInt32(textBox2.Text);
                bool fl = HandRandom.SetConfiguration(Convert.ToInt32(textBox3.Text),
                    Convert.ToInt32(textBox4.Text),
                    Convert.ToInt32(textBox5.Text),
                    Convert.ToInt32(textBox6.Text),
                    Convert.ToInt32(textBox7.Text),
                    Convert.ToInt32(textBox8.Text),
                    Convert.ToInt32(textBox9.Text),
                    Convert.ToInt32(textBox10.Text),
                    Convert.ToInt32(textBox11.Text),
                    Convert.ToInt32(textBox12.Text),
                    Convert.ToInt32(textBox13.Text),
                    Convert.ToInt32(textBox14.Text),
                    Convert.ToInt32(textBox15.Text),
                    Convert.ToInt32(textBox16.Text),
                    Convert.ToInt32(textBox17.Text),
                    Convert.ToInt32(textBox18.Text));
                Set();
                if (new FileInfo("data/config.ini").Exists) new FileInfo("data/config.ini").Delete();
                using (StreamWriter fs = new StreamWriter("data/config.ini", false))
                {
                    fs.WriteLine(
                        textBox1.Text + ";" +
                        textBox2.Text + ";" +
                        textBox3.Text  + ";" +
                        textBox4.Text  + ";" +
                        textBox5.Text  + ";" +
                        textBox6.Text  + ";" +
                        textBox7.Text  + ";" +
                        textBox8.Text  + ";" +
                        textBox9.Text  + ";" +
                        textBox10.Text + ";" +
                        textBox11.Text + ";" +
                        textBox12.Text + ";" +
                        textBox13.Text + ";" +
                        textBox14.Text + ";" +
                        textBox15.Text + ";" +
                        textBox16.Text + ";" +
                        textBox17.Text + ";" +
                        textBox18.Text);
                }

                if (!fl)
                    MessageBox.Show("обнаружены проблемы в новой конфигурации.\n Праметры оптимизированны.");
                else
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                

            }
            catch (Exception)
            {
                RMax = max;
                RMin = min;
                MessageBox.Show("обнаружены критические проблемы в новой конфигурации.\n Праметры оптимизированны.");
                this.DialogResult = DialogResult.Cancel;
                this.Close();
                throw;
            }

            
            
        }

        private void HWOptionsForm_Load(object sender, EventArgs e)
        {

        }

    
    }
}
