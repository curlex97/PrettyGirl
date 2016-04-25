using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;

namespace PrettyGirl
{

 

    /// <summary>
    /// Реализует рукописную букву,
    /// содержащую все параметры отображения.
    /// </summary>
    public class LetterConfig
    {

        private char value;
        private int variable;
        private int leftDX, rightDX, dY;
        private Size size;

        /// <summary>
        /// Конструктор класса Letter
        /// </summary>
        /// <param name="c">символ</param>
        /// <param name="variable">номер символа по порядку</param>
        /// <param name="ldx">смещение слева</param>
        /// <param name="rdx">смещение справа</param>
        /// <param name="dy">смещение вверх</param>
        /// <param name="size">графический размер буквы</param>
        public LetterConfig(char c, int variable, int ldx, int rdx, int dy, Size size)
        {
            value = c;
            this.variable = variable;
            leftDX = ldx;
            rightDX = rdx;
            dY = dy;
            this.size = size;

        }

        /// <summary>
        /// Сравнивает значение символа
        ///и номер по порядку
        /// </summary>
        /// <param name="c">символ</param>
        /// <param name="i">номер по порядку</param>
        /// <returns></returns>
        public bool Equivalent(char c, int i)
        {
            return value == c && variable == i;
        }

        /// <summary>
        /// Символ буквы
        /// </summary>
        public char Value
        {
            get { return value; }
            set { this.value = value; }
        }

        /// <summary>
        /// Номер символа
        /// </summary>
        public int Variable
        {
            get { return variable; }
            set { variable = value; }
        }

        /// <summary>
        /// Смещение буквы справа
        /// </summary>
        public int RightDx
        {
            get { return rightDX; }
            set { rightDX = value; }
        }

        /// <summary>
        /// Смещение буквы слева
        /// </summary>
        public int LeftDx
        {
            get { return leftDX; }
            set { leftDX = value; }
        }

        /// <summary>
        /// смещение буквы вверх
        /// </summary>
        public int DY
        {
            get { return dY; }
            set { dY = value; }
        }

        /// <summary>
        /// Графический размер буквы
        /// </summary>
        public Size Size
        {
            get { return size; }
            set { size = value; }
        }

        

        public override string ToString()
        {
            //о: 0, -3, -1, 0;
            return value + ": " + variable + ", " + LeftDx + ", " + RightDx + ", " + DY + ";";
        }
    }

    public class HandWriteConfig
    {
        /// <summary>
        /// список конфигурации графических букв.
        /// заполняется в конструкторе и дальнейшее
        /// генерирование проиходит из памяти, что
        /// обеспечивает более быструю работу.
        /// </summary>
        public static List<LetterConfig> Letters = new List<LetterConfig>();

        public HandWriteConfig()
        {
            
        }

        public void ReadConfig()
        {
            Letters.Clear();
            string[] strs = File.ReadAllLines(Path.GetDirectoryName(Application.ExecutablePath) + "/data/lower.cfg");
            foreach (string str in strs)
            {
                try
                {

                    string[] buf = str.Replace(" ", String.Empty).Split(new[] { ';', ',', ':' }, StringSplitOptions.RemoveEmptyEntries);
                    string path = Directory.GetCurrentDirectory() + @"\bases\let\" + buf[0] + buf[1] + ".png";
                    Bitmap bitmap = new Bitmap(path);
                    Letters.Add(new LetterConfig(buf[0][0], Convert.ToInt32(buf[1]), Convert.ToInt32(buf[2]),
                        Convert.ToInt32(buf[3]), Convert.ToInt32(buf[4]), new Size(bitmap.Width, bitmap.Height)));
                }
                catch { }
            }

            strs = File.ReadAllLines(Path.GetDirectoryName(Application.ExecutablePath) + "/data/upper.cfg");
            foreach (string str in strs)
            {
                try
                {

                    string[] buf = str.Replace(" ", String.Empty).Split(new[] { ';', ',', ':' }, StringSplitOptions.RemoveEmptyEntries);
                    string path = Directory.GetCurrentDirectory() + @"\bases\let\" + buf[0] + buf[1] + ".png";
                    Bitmap bitmap = new Bitmap(path);
                    Letters.Add(new LetterConfig(buf[0][0], Convert.ToInt32(buf[1]), Convert.ToInt32(buf[2]),
                        Convert.ToInt32(buf[3]), Convert.ToInt32(buf[4]), new Size(bitmap.Width, bitmap.Height)));
                }
                catch { }
            }

        }

        public void AddConfig(LetterConfig letter)
        {
             int idx = GetLetterIndex(letter.Value, letter.Variable);
            if (idx < 0)
                Letters.Add(letter);
            else
            {
                Letters[idx].DY = letter.DY;
                Letters[idx].LeftDx = letter.LeftDx;
                Letters[idx].RightDx = letter.RightDx;
                Letters[idx].Size = letter.Size;
            }
            
        }

        public void WriteConfig()
        {
            List<string> upperStr = new List<string>();
            List<string> lowerStr = new List<string>();



            foreach (var letter in Letters)
            {
                if (Char.IsUpper(letter.Value)) upperStr.Add(letter.ToString());
                else lowerStr.Add(letter.ToString());
            }

            File.WriteAllLines(Path.GetDirectoryName(Application.ExecutablePath) + "/data/lower.cfg", lowerStr);
            File.WriteAllLines(Path.GetDirectoryName(Application.ExecutablePath) + "/data/upper.cfg", upperStr);
        }

      public LetterConfig GetLetter(char c, int i)
      {
          return Letters.FirstOrDefault(letter => letter.Equivalent(c, i));
      }

      public static int GetLetterIndex(char c, int i)
        {
            if (Letters.Any(t => t.Equivalent(c, i)))
                return i;        
            return -1;
        }
    }

    public class Letter
    {
        public static Letter Empty = new Letter();
        private int x, px;
        private int y, py;
        private int width;
        private int height;
        private int index;
        private char symbol;
        private Bitmap image;
        private double pWidth = 1, pHeight = 1;
        private string path ="";

        public Bitmap Image
        {
            get { return image; }
            set { image = value; }
        }

        public int X
        {
            get { return x + px; }
            set { px = value; }
        }

        public int Y
        {
            get { return y + py; }
            set { py = value; }
        }

        public int Width
        {
            get { return Convert.ToInt32(Convert.ToDouble(width) * pWidth); }
            set { if (value > 0) pWidth = Convert.ToDouble(value)/100; }
        }

        public int Height
        {
            get { return Convert.ToInt32(Convert.ToDouble(height) * pHeight); }
            set { if(value > 0) pHeight = Convert.ToDouble(value) / 100; }
        }

        public int Index
        {
            get { return index; }
            set { index = value; }
        }

        public char Symbol
        {
            get { return symbol; }
            set { symbol = value; }
        }

        Letter()
        {
            x = 0;
            y = 0;
            width = 0;
            height = 0;
            index = 0;
            symbol = ' ';
            image = null;
        }

        public Letter(string str, int x, int y, int index, char symbol)
        {
            this.x = x;
            this.y = y + HandRandom.GetDeltaMoveY();
            path = str;
            this.index = index;
            this.symbol = symbol;
            double scaleX = HandRandom.GetLetterScaleX();
            double scaleY = HandRandom.GetLetterScaleY();
            try
            {
                image = new Bitmap(str);
                this.width = image.Width;
                this.height = image.Height;
                image = new Bitmap(image, Convert.ToInt32(width*scaleX), Convert.ToInt32(height*scaleY));
                image.SetResolution(300, 300);
            }
            catch
            {
                return;
            }



        }

        public Letter(string memory)
        {
            string[] strs = memory.Split(new[] {'^'}, StringSplitOptions.RemoveEmptyEntries);
            if (strs.Length == 6)
            {
                try
                {
                    symbol = strs[0][0];
                    char path = symbol;
                    if (path == '~') path = '-';
                    index = Convert.ToInt32(strs[1]);
                    x = Convert.ToInt32(strs[2]);
                    y = Convert.ToInt32(strs[3]);
                    width = Convert.ToInt32(strs[4]);
                    height = Convert.ToInt32(strs[5]);
                    string str;
                    if (!Char.IsUpper(symbol)) str = Directory.GetCurrentDirectory() + @"\bases\let\" + path + index + ".png";
                    else str = Directory.GetCurrentDirectory() + @"\bases\let\" + path + "!" + index + ".png";
                    this.path = str;
                    image = new Bitmap(new Bitmap(str), Convert.ToInt32(width), Convert.ToInt32(height));
                    image.SetResolution(300, 300);
                }
                catch (Exception)
                {
                 
                    
                }
            }
        }

        public void UpdateImage()
        {
            try
            {
                image = new Bitmap(new Bitmap(path), Width, Height);
                image.SetResolution(300, 300);
            }
            catch (Exception)
            {
  
                
            }
        
        }

        public void Draw(Graphics g)
        {
            if (image != null)
            {
                try
                {
                    image = new Bitmap(image, Width, Height);
                    image.SetResolution(300, 300);
                    g.DrawImage(image, new PointF(X, Y));
                }
                catch { }
            }
        }

        public override string ToString()
        {
            return  symbol + "^" + index + "^" + X + "^" + Y + "^" + Width + "^" + Height;
        }

        public bool IsEmpty()
        {
            return image == null;
        }
    }

    public class HandWrite
    {
        List<Letter> letters = new List<Letter>();
        private int selectedLetter;

        public Letter SelectedLetter
        {
            get { if(selectedLetter >= 0 && selectedLetter < letters.Count) return letters[selectedLetter];
                return null;
            }
        }

        public List<Letter> Letters
        {
            get { return letters; }
            set { letters = value; }
        }

        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < letters.Count; i++) str += letters[i].ToString() + "\n";
                return str;
        }

        public string FromString(string text)
        {
            string str = "";
            letters.Clear();
            string[] strs = text.Split(new[] {'\n'}, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < strs.Length; i++)
            {
                letters.Add(new Letter(strs[i]));
                char c = letters[letters.Count - 1].Symbol;
               if(c!='~') str += c;
            }
            return str;
        }

        public void Update()
        {
            for(int i=0; i<letters.Count; i++)
                letters[i].UpdateImage();
        }

        public void Draw(Graphics g)
        {
            g.Clear(Color.FromArgb(0,0,0,0));
            for(int i=0; i<letters.Count; i++)
                if (!letters[i].IsEmpty()) 
                    letters[i].Draw(g);
        }

        public void SelectLetter(int x, int y, int pw, int ph)
        {
            x = Convert.ToInt32(Convert.ToDouble(Hand.Width) / Convert.ToDouble(pw) * Convert.ToDouble(x));
            y = Convert.ToInt32(Convert.ToDouble(Hand.Height) / Convert.ToDouble(ph) * Convert.ToDouble(y));
          
            for(int i =0; i<letters.Count; i++)
                if (
                    new Rectangle(letters[i].X, letters[i].Y, letters[i].Width, letters[i].Height).Contains(new Point(
                        x, y)))
                    selectedLetter = i;

        }
    }
}
