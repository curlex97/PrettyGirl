using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrettyGirl
{
    public partial class BuildHWForm : Form
    {
        public int minId, maxId;
        public string path = "";

        public BuildHWForm()
        {
            InitializeComponent();
            HandWriteBuilder.OnBuildProgress += SetProgressBar;
        }


        delegate void SetTextCallback(double text);

        private void SetProgressBar(double text)
        {
            if (this.progressBar1.InvokeRequired)   // запущена ли эта функция в чужом потоке?
            {
                SetTextCallback d = new SetTextCallback(SetProgressBar);
                this.progressBar1.Invoke(d, new object[] { text });
            }
            else
            {
                int u = Convert.ToInt32(text*2);
                if (u > 100) u = 100;
                progressBar1.Value = u;
                if(progressBar1.Value >= 99) this.Close();
            }
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            
          //  DialogResult = DialogResult.Cancel;
           // this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK &&
                (Path.GetExtension(ofd.FileName) == ".png" || Path.GetExtension(ofd.FileName) == ".jpg"))
                textBox1.Text = ofd.FileName;
            else textBox1.Text = "Формат файла на поддерживается";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
               
                maxId = Convert.ToInt32(textBox3.Text);
                minId = Convert.ToInt32(textBox2.Text);
                path = textBox1.Text;
                if (new FileInfo(path).Exists)
                {
                //    DialogResult = DialogResult.OK;
                    Thread t1 = new Thread(()=>HandWriteBuilder.BuildHandWrite(path, minId, maxId));
                    t1.IsBackground = true;
                    t1.Start();
                    button1.Enabled = false;
                    button2.Enabled = false;
                    button3.Enabled = false;
                }
              //  else DialogResult = DialogResult.Cancel;
                //this.Close();

            }
            catch
            {
                DialogResult = DialogResult.Cancel;
              //  this.Close();
            }
          
        }
    }
}
