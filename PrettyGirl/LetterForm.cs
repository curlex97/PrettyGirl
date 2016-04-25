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
    public partial class LetterForm : Form
    {
        public TrackBar XTrackBar
        {
            get { return xTrackBar; }
        }

        public TrackBar YTrackBar
        {
            get { return yTrackBar; }
        }

        public TrackBar ScaleWTrackBar
        {
            get { return scaleWTrackBar; }
        }

        public TrackBar ScaleHTrackBar
        {
            get { return scaleHTrackBar; }
        }

        public TextBox XTextBox
        {
            get { return xTextBox; }
        }

        public TextBox YTextBox
        {
            get { return yTextBox; }
        }

        public TextBox ScaleWTextBox
        {
            get { return scaleWTextBox; }
        }

        public TextBox ScaleHTextBox
        {
            get { return scaleHTextBox; }
        }

        public LetterForm(Letter letter)
        {
           
//С одной стороны улицы подряд стоят пять домов, каждый — своего цвета. В каждом живёт человек, все пять — разных национальностей. Каждый человек предпочитает уникальную марку сигарет, напиток и домашнее животное. Кроме того:

//    Норвежец живет в первом доме.
//    Англичанин живет в красном доме.
//    Зеленый дом находится сразу слева от белого.
//    Датчанин пьет чай.
//    Тот, кто курит Marlboro, живет рядом с тем, кто выращивает кошек.
//    Тот, кто живет в желтом доме, курит Dunhill.
//    Немец курит Rothmans.
//    Тот, кто живет в центре, пьет молоко.
//    Сосед того, кто курит Marlboro, пьет воду.
//    Тот, кто курит Pall Mall, выращивает птиц.
//    Швед выращивает собак.
//    Норвежец живет рядом с синим домом.
//    Тот, кто выращивает лошадей, живет в синем доме.
//    Тот, кто курит Winfield, пьет пиво.
//    В зеленом доме пьют кофе.

//Вопрос:  кто разводит
//            рыбок? 
            InitializeComponent();
           if(letter != null) label5.Text = "Буква: " + letter.Symbol + ", Вариант: " + letter.Index;
            scaleHTextBox.Text = scaleHTrackBar.Value.ToString();
            scaleWTextBox.Text = scaleWTrackBar.Value.ToString();
            yTextBox.Text = yTrackBar.Value.ToString();
            xTextBox.Text = xTrackBar.Value.ToString();
            
        }

        public void ChangeLetter(Letter letter)
        {
            if (letter != null) label5.Text = "Буква: " + letter.Symbol + ", Вариант: " + letter.Index;
        }

        public void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void xTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if(xTextBox.Text.Length != 0 && xTextBox.Text != "-")
                xTrackBar.Value = Convert.ToInt32(xTextBox.Text);
                
            }
            catch
            {
                xTextBox.Text = xTrackBar.Value.ToString();
                xTextBox.SelectionStart = xTextBox.Text.Length;
            }
        }

        private void yTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (yTextBox.Text.Length != 0 && yTextBox.Text != "-")
                    yTrackBar.Value = Convert.ToInt32(yTextBox.Text);

            }
            catch
            {
                yTextBox.Text = yTrackBar.Value.ToString();
                yTextBox.SelectionStart = yTextBox.Text.Length;
            }
        }

        private void scaleWTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (scaleWTextBox.Text.Length != 0 && scaleWTextBox.Text != "-")
                    scaleWTrackBar.Value = Convert.ToInt32(scaleWTextBox.Text);

            }
            catch
            {
                scaleWTextBox.Text = scaleWTrackBar.Value.ToString();
                scaleWTextBox.SelectionStart = scaleWTextBox.Text.Length;
            }
        }

        private void scaleHTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (scaleHTextBox.Text.Length != 0 && scaleHTextBox.Text != "-")
                    scaleHTrackBar.Value = Convert.ToInt32(scaleHTextBox.Text);

            }
            catch
            {
                scaleHTextBox.Text = scaleHTrackBar.Value.ToString();
                scaleHTextBox.SelectionStart = scaleHTextBox.Text.Length;
            }
        }

        private void xTrackBar_ValueChanged(object sender, EventArgs e)
        {
            xTextBox.Text = xTrackBar.Value.ToString();

        }

        private void yTrackBar_ValueChanged(object sender, EventArgs e)
        {
            yTextBox.Text = yTrackBar.Value.ToString();
        }

        private void scaleWTrackBar_ValueChanged(object sender, EventArgs e)
        {
           scaleWTextBox.Text = scaleWTrackBar.Value.ToString();
        }

        private void scaleHTrackBar_ValueChanged(object sender, EventArgs e)
        {
            scaleHTextBox.Text = scaleHTrackBar.Value.ToString();
        }
    }
}
