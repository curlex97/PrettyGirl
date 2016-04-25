using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PrettyGirl
{
    /// <summary>
    /// Управляющий класс.
    /// Реализует генерирование графического 
    /// отображения букв, 
    /// преобразованных из текста.
    /// </summary>
    public class Hand
    {


        public delegate void SetProgressBar(int value);
        HandWrite handWrite = new HandWrite();

        public Hand.SetProgressBar OnSetProgressBar;


        void OnSetPB(int v)
        {
            if (OnSetProgressBar != null)
                OnSetProgressBar(v);
        }


        /// <summary>
        /// буффер последнего генерирования
        /// отображения почерка
        /// </summary>
        public Graphics LastBuffer;

        public Bitmap LastCompile = null;

        /// <summary>
        /// Длина, ширина холста
        /// и нижний и верхний порог
        /// вариативности номера букв.
        /// </summary>
        public static int Width = 210 * 3, Height = 297 * 3, RMin = 0, RMax = 2;

        /// <summary>
        /// для рисования с помощью gdi
        /// </summary>
        private Graphics g;

        /// <summary>
        /// курсор по x
        /// </summary>
        float x0 = HandRandom.BeginX;

        /// <summary>
        /// курсор по y
        /// </summary>
        float y0 = HandRandom.BeginY;

        /// <summary>
        /// для отображения загрузки программы
        /// </summary>
        ProgressBar progressBar = new ProgressBar();

        /// <summary>
        /// отображать ли "на ходу".
        /// </summary>
        public static bool LiveShow = false;

        HandWriteConfig handWriteConfig = new HandWriteConfig();

        /// <summary>
        /// счеткичи символов и слов 
        /// во время генерирования
        /// </summary>
        public int cursor = 0;

        /// <summary>
        /// буффер текста
        /// </summary>
        public static string Buffer = "";

        public float Y0
        {
            get { return y0; }
        }

        /// <summary>
        /// Контруктор
        /// </summary>
        /// <param name="pb">прогресс бар с формы</param>
        public Hand(ProgressBar pb = null, string path = "")
        {
            if (pb != null) progressBar = pb;
            progressBar.Minimum = 0;
            progressBar.Maximum = 100;
            ReadConfig();
          try{  if (new FileInfo(path).Exists) OpenHWT(path);}
          catch { }
        }

        /// <summary>
        /// чтение конфигурации программы
        /// </summary>
        public void ReadConfig()
        {


            string[] strs = File.ReadAllLines(Path.GetDirectoryName(Application.ExecutablePath) + "/data/lower.cfg");         
            SymbolReplacer.BuildDictionary();
            handWriteConfig.ReadConfig();
          //  handWriteConfig.WriteConfig();

            try
            {
                strs = null;
                strs = File.ReadAllText(Path.GetDirectoryName(Application.ExecutablePath) + 
                    "/data/config.ini").Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                if (strs.Length >= 18)
                {

                    RMin = Convert.ToInt32(strs[0]);
                    RMax = Convert.ToInt32(strs[1]);
                    HandRandom.SetConfiguration(
                        Convert.ToInt32(strs[2]),
                        Convert.ToInt32(strs[3]),
                        Convert.ToInt32(strs[4]),
                        Convert.ToInt32(strs[5]),
                        Convert.ToInt32(strs[6]),
                        Convert.ToInt32(strs[7]),
                        Convert.ToInt32(strs[8]),
                        Convert.ToInt32(strs[9]),
                        Convert.ToInt32(strs[10]),
                        Convert.ToInt32(strs[11]),
                        Convert.ToInt32(strs[12]),
                        Convert.ToInt32(strs[13]),
                        Convert.ToInt32(strs[14]),
                        Convert.ToInt32(strs[15]),
                        Convert.ToInt32(strs[16]),
                        Convert.ToInt32(strs[17]));

                }
            }
            catch
            {

            }

        }

        /// <summary>
        /// генерирование изображения почерка из текста
        /// </summary>
        /// <param name="text">текст</param>
        /// <param name="bitmap">готовый буфер. если нне null, 
        /// то текст допишется</param>
        /// <returns></returns>
        public Bitmap BuildAndWrite(string text)
        {
            handWrite.Letters.Clear();
            text = SymbolReplacer.ReplaceSymbols(text);
            Bitmap b1;
                b1 = new Bitmap(Width, Height);
                x0 = HandRandom.BeginX;
                y0 = HandRandom.BeginY;
                Buffer = "";
                cursor = 0;

            
            Buffer += text;
            b1.SetResolution(300, 300);
            g = Graphics.FromImage(b1);
            LastBuffer = g;

            double delta = progressBar.Maximum / Convert.ToDouble(text.Length);
            double progress = 0;
            SetProgress(progress);

            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];
                TextToLetter(c, -1);

                progress += delta;

                if (c == ' ')
                {
                    handWrite.Letters.Add(Letter.Empty);
                    int dx = HandRandom.GetSpaceLength(cursor);
                    x0 += dx;
                    cursor = 0;
                    int h = 0;
                    x0 -= dx / 2;
                    int u = HandRandom.GetRightEdge();
                    if (x0 + WordSeparator.GetWordLength(text.Substring(i + 1).
                        Split(new[] { ' ' })[0]) > Width - u)
                    {
                        int sw = SeparateWord(text, u, i);
                        i += sw;
                        progress += delta * sw;
                    }

                }
                else if (c == '\n')
                {
                    cursor = 0;
                    x0 = HandRandom.BeginX;
                    y0 += HandRandom.GetLineSpace();
                }

                else if (c == '\t')
                {
                    cursor = 0;
                    x0 += HandRandom.GetSpaceLength(3) * 4;
                }


                if (!LiveShow) SetProgress(progress);

            }


            handWrite.Draw(g);
            LastCompile = b1;
            return b1;
        }

        public void WriteConfigFromNewList()
        {
            foreach (var config in HandWriteBuilder.Configuration)
            {
                handWriteConfig.AddConfig(config);
            }
            handWriteConfig.WriteConfig();
        }

        public Bitmap Write()
        {
            Bitmap  b1 = new Bitmap(Width, Height);
            b1.SetResolution(300, 300);
            g = Graphics.FromImage(b1);
            handWrite.Draw(g);
            LastCompile = b1;
            return b1;
        }

        /// <summary>
        /// возвращает смещение буквы
        /// справа и сверху и переносит крусор
        /// на смещение буквы слева
        /// </summary>
        /// <param name="c"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        PointF GetLetterParams(char c, int i)
        {

            try
            {
                LetterConfig letter = handWriteConfig.GetLetter(c, i);
                        x0 += letter.LeftDx * float.Parse(HandRandom.GetMainScale().ToString());
                        return new PointF(float.Parse((letter.RightDx * HandRandom.GetMainScale()).ToString()),
                            y0 - float.Parse((letter.DY * HandRandom.GetMainScale()).ToString()));
            }
            catch (Exception)
            {

                return new PointF(0, y0);
            }
        }

        /// <summary>
        /// рисует символ
        /// </summary>
        /// <param name="c">символ</param>
        /// <param name="random">номер по порядку</param>
        void TextToLetter(char c, int random)
        {

            int rand = HandRandom.Random.Next(RMin, RMax + 1);
            if (random != -1) rand = random;

            PointF point = GetLetterParams(c, rand);

            if (c != ' ' && c != '|')
            {
                char p = c;
                if (p == '~') p = '-';
                cursor++;
                string str;
                if(!Char.IsUpper(c)) str= Directory.GetCurrentDirectory() + @"\bases\let\" + p + rand + ".png";
                else str = Directory.GetCurrentDirectory() + @"\bases\let\" + p + "!" + rand + ".png";

                try
                {
                    if (!new FileInfo(str).Exists)
                    {
                        rand = 0;
                        point = GetLetterParams(c, 0);
                        if (!Char.IsUpper(c)) str = Directory.GetCurrentDirectory() + @"\bases\let\" + p + rand + ".png";
                        else str = Directory.GetCurrentDirectory() + @"\bases\let\" + p + "!" + rand + ".png";
                    }
                    if (new FileInfo(str).Exists)
                    {
                        Letter letter = new Letter(str, Convert.ToInt32(x0), Convert.ToInt32(point.Y), rand, c);
                        handWrite.Letters.Add(letter);
                        x0 += letter.Width / 1.27f + point.X;
                    }
                }
                catch
                {
                }
            }

        }

        public Bitmap WriteSelectedLetter()
        {
            Bitmap b1 = new Bitmap(Width, Height);
            b1.SetResolution(300, 300);
            g = Graphics.FromImage(b1);
            handWrite.SelectedLetter.Draw(g);
            return b1;
        }

        public HandWriteConfig HandWriteConfig
        {
            get { return handWriteConfig; }
        }

        public HandWrite HandWrite
        {
            get { return handWrite; }
        }

        /// <summary>
        /// рисует символ верхнего регистра
        /// </summary>
        /// <param name="c">символ</param>
        /// <param name="random">номер по порядку</param>

        /// <summary>
        /// разделяет и рисует слово по слогам
        /// </summary>
        /// <param name="text">текст</param>
        /// <param name="randSpace">свободное место до границы холста</param>
        /// <returns>возвращает длину символа</returns>
        public int SeparateWord(string text, int randSpace, int ii)
        {
            text = text.Substring(ii + 1);
            text = text.Replace("-", "|");
            int rr = Convert.ToInt32(Width - x0 - randSpace - HandRandom.DefaultSpace);
            string word = WordSeparator.GetSeparateWord(text, 0, rr);

            string secondPath = "";
            string firstPath = "";
            string fullword = "";

            string[] strs2 = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (strs2.Length > 0) fullword = strs2[0];

            if (word.Contains('~'))
            {
                string[] strs = word.Split(new[] { '~' }, StringSplitOptions.RemoveEmptyEntries);
                firstPath = strs[0].Replace("|", "-") + "~";
                secondPath = strs[1].Replace("|", "-");
                int length = WordSeparator.GetWordLength(firstPath);
                if (length + x0 > Width - randSpace)
                {
                    x0 = HandRandom.BeginX;
                    y0 += HandRandom.GetLineSpace();
                    return 0;
                }

                for (int i = 0; i < firstPath.Length; i++)
                    TextToLetter(firstPath[i], -1);

                

            }
            else
            {
                x0 = HandRandom.BeginX;
                y0 += HandRandom.GetLineSpace();
                return 0;
            }
            x0 = HandRandom.BeginX;
            y0 += HandRandom.GetLineSpace();

            for (int i = 0; i < secondPath.Length; i++)
            {
                char c = secondPath[i];
                if (Char.IsUpper(c)) TextToLetter(c, -1);
                else TextToLetter(c, -1);
            }

            if (firstPath == "") return word.Length;
            return word.Length - 1;
        }

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
            OnSetPB(Convert.ToInt32(progress));
            if (progressBar.InvokeRequired)
            {
                DrawingProgress d = SetProgress;
                progressBar.Invoke(d, new object[] { progress });
            }
            else
            {
                if (progress >= progressBar.Maximum)
                {
                    progress = 0;
                    // MessageBox.Show("Синтезирование заверешено.");
                }
                progressBar.Value = Convert.ToInt32(progress);
            }
        }

        public void SaveHWT()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string path = sfd.FileName;
                if (Path.GetExtension(path) != ".hwt") path += ".hwt";
                File.WriteAllText(path, handWrite.ToString());
            }
        }

        public string OpenHWT(string path = "")
        {
            if (path == "")
            {
                OpenFileDialog ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == DialogResult.OK)
                    if (Path.GetExtension(ofd.FileName) == ".hwt")
                        path = ofd.FileName;
            }

            return handWrite.FromString(File.ReadAllText(path));


        }

    }
}
