using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace PrettyGirl
{
    public partial class Form1 : Form
    {

        Hand hand;

        public Hand Hand
        {
            get { return hand; }
        }
        private Bitmap bitmap = null;
      //  private int count =0;
        Thread t1 = null;
        private PreviewForm form = new PreviewForm();
        private LetterForm letterForm;

        /// <summary>
        /// дегегат отображения прогрессБара
        /// </summary>
        /// <param name="progress">значение</param>
        private delegate void DrawingProgress(double progress);

        /// <summary>
        /// Задает значение прогрессБара
        /// </summary>
        /// <param name="progress">значение</param>
        void SetProgress(double progress)
        {
            if (label2.InvokeRequired)
            {
                DrawingProgress d = SetProgress;
                label2.Invoke(d, new object[] { progress });
            }
            else

                label2.Text = Convert.ToInt32(progress)+"%";
            
        }

        public Form1(string[] args)
        {
            try
            {
                InitializeComponent();             
               // DateTime dt = DateTime.Now;
              //  MessageBox.Show("start");
              //  HandWriteBuilder.BuildHandWrite("C:/Games/tanya_lower.png", 0, 5);
            //  TimeSpan ts = DateTime.Now - dt;
             //  MessageBox.Show("ready: " + ts.TotalSeconds);
                this.MaximizeBox = false;
                hand = new Hand(progressBar1);
                hand.OnSetProgressBar += value => SetProgress(value);
                hand.ReadConfig();
                if (args != null && args.Length > 0)
                {
                  //  //MessageBox.Show(args[0]);
                    textBox1.Text = hand.OpenHWT(args[0]);
                  //  //MessageBox.Show(hand.HandWrite.Letters.Count.ToString());
                  //  Refresh(false);
                }
            }
            catch(Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {


           


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
            if (Hand.LiveShow)
            {

                    bitmap = hand.BuildAndWrite(textBox1.Text);
                    bitmap.SetResolution(300, 300);
                    pictureBox1.Image = new Bitmap(bitmap, pictureBox1.Width, pictureBox1.Height);
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK && sfd.FileName.Length > 0)
            {

                string path = sfd.FileName;
                try
                {
                    string extension = Path.GetExtension(path);
                    if (extension != ".png") path += ".png";
                }
                catch
                {
                    path += ".png";
                }
                int w = Hand.Width;
                int h = Hand.Height;
                Hand.Height = Convert.ToInt32(hand.Y0 + 150);
                if (hand.LastCompile == null) hand.Write();
                hand.LastCompile.Save(path,  ImageFormat.Png);
                Hand.Width = w;
                Hand.Height = h;
                
            }
            
        }

        private void liveотображениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hand.LiveShow = !Hand.LiveShow;
            liveотображениеToolStripMenuItem.Checked = Hand.LiveShow;

        }

        private void отобразитьToolStripMenuItem_Click(object sender, EventArgs e)
        {


            Refresh(false);

        }

        private void progressBar1_SizeChanged(object sender, EventArgs e)
        {
            label1.Text = progressBar1.Value.ToString() + "%";
        }

        private void размерХолстаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SizeChangeForm sizeChangeForm = new SizeChangeForm(Hand.Width, Hand.Height);
            sizeChangeForm.ShowDialog();
            Hand.Width = sizeChangeForm.RWidth;
            Hand.Height = sizeChangeForm.RHeight;
            Refresh();
        }

        private void настройкаШрифтаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HWOptionsForm form = new HWOptionsForm(Hand.RMin, Hand.RMax);
            form.ShowDialog();
            Hand.RMin = form.RMin;
            Hand.RMax = form.RMax;
            Refresh();
        }

        private void обновитьКонфигурациюToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // //MessageBox.Show("WHFT");
            try
            {
                hand.ReadConfig();
                Refresh();
            }
            catch
            {
               // //MessageBox.Show("fasdffasdf");
            }
        }

        void Refresh(bool rebuild = true, bool reconfig = false)
        {
           

                if (t1 != null)
                {
                    t1.Abort();
                    t1 = null;
                }

                t1 = new Thread(() =>
                {
                    try
                    {
                        if (reconfig) hand.HandWrite.Update();
                        if (rebuild) bitmap = hand.BuildAndWrite(textBox1.Text);
                        else bitmap = hand.Write();

                        bitmap.SetResolution(300, 300);
                        pictureBox1.Image = new Bitmap(bitmap, pictureBox1.Width, pictureBox1.Height);
                        form.Refresh(hand.LastCompile);
                        ////MessageBox.Show("33333");
                    }
                    catch
                    {
                        //MessageBox.Show("123456");
                    }
                });
                t1.IsBackground = true;
                t1.Start();
            
         
        }

        private void предпросмотрToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form = new PreviewForm();
            form.PictureBox.MouseUp += pictureBox1_MouseUp;
            form.Show();
            form.Refresh(hand.LastCompile);
            
        }

        private void открытьФайлПочеркаToolStripMenuItem_Click(object sender, EventArgs e)
        {
           textBox1.Text =  hand.OpenHWT();
            Refresh(false);
        }

        private void сохранитьФайлПочеркаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hand.SaveHWT();
        }

        private void настроитьБуквуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            letterForm = new LetterForm(hand.HandWrite.SelectedLetter);
            letterForm.Closed += (o, args) => Refresh(false, true);
            letterForm.XTrackBar.Click += (o, args) =>
            {
                if (hand.HandWrite.SelectedLetter != null)
                    hand.HandWrite.SelectedLetter.X = letterForm.XTrackBar.Value;
                Refresh(false);
            };

            letterForm.YTrackBar.Click += (o, args) =>
            {
                if (hand.HandWrite.SelectedLetter != null)
                    hand.HandWrite.SelectedLetter.Y = letterForm.YTrackBar.Value;
                Refresh(false);
            };

            letterForm.ScaleWTrackBar.Click += (o, args) =>
            {
                if (hand.HandWrite.SelectedLetter != null)
                    hand.HandWrite.SelectedLetter.Width = letterForm.ScaleWTrackBar.Value;
                Refresh(false);
            };

            letterForm.ScaleHTrackBar.Click += (o, args) =>
            {
                if (hand.HandWrite.SelectedLetter != null)
                    hand.HandWrite.SelectedLetter.Height = letterForm.ScaleHTrackBar.Value;
                Refresh(false);
            };


            letterForm.XTextBox.TextChanged += (o, args) =>
            {
                if (hand.HandWrite.SelectedLetter != null)
                    hand.HandWrite.SelectedLetter.X = letterForm.XTrackBar.Value;
                Refresh(false);
            };

            letterForm.YTextBox.TextChanged += (o, args) =>
            {
                if (hand.HandWrite.SelectedLetter != null)
                    hand.HandWrite.SelectedLetter.Y = letterForm.YTrackBar.Value;
                Refresh(false);
            };

            letterForm.ScaleWTextBox.TextChanged += (o, args) =>
            {
                if (hand.HandWrite.SelectedLetter != null)
                    hand.HandWrite.SelectedLetter.Width = letterForm.ScaleWTrackBar.Value;
                Refresh(false);
            };

            letterForm.ScaleHTextBox.TextChanged += (o, args) =>
            {
                if (hand.HandWrite.SelectedLetter != null)
                    hand.HandWrite.SelectedLetter.Height = letterForm.ScaleHTrackBar.Value;
                Refresh(false);
            };

            letterForm.Show();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            PictureBox pbx = sender as PictureBox;
            hand.HandWrite.SelectLetter(e.X, e.Y, pbx.Width, pbx.Height);  
            if(letterForm != null) letterForm.ChangeLetter(hand.HandWrite.SelectedLetter);
        }

        public static void AssociateExtension(string applicationExecutablePath, string extension)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\Classes", true);
            key.CreateSubKey("." + extension).SetValue(string.Empty, extension + "_auto_file");

            key = key.CreateSubKey(extension + "_auto_file");
            key.CreateSubKey("DefaultIcon").SetValue(string.Empty, applicationExecutablePath + ",0");

            key = key.CreateSubKey("Shell");
            key.SetValue(string.Empty, "Open");

            key = key.CreateSubKey("Open");

            key.CreateSubKey("Command").SetValue(string.Empty, "\"" + applicationExecutablePath + "\" \"%1\"");

            key.CreateSubKey("ddeexec\\Topic").SetValue(string.Empty, "System");
        }

        private void построитьНовыйПочеркToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuildHWForm hwForm = new BuildHWForm();
           hwForm.ShowDialog();
            
                hand.WriteConfigFromNewList();
            
                
        }


    }


  
    

   
}
