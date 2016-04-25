using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrettyGirl
{
    class HandWriteBuilder
    {

        public static double Progress = 0;

        private static int Height = -1;

        static List<LetterConfig> configuration = new List<LetterConfig>();


        public static List<LetterConfig> Configuration
        {
            get { return configuration; }
        }

        public delegate void SetBuildProgress(double d);

        public static SetBuildProgress OnBuildProgress;

        protected static string GetPath(Color leftMark, Color rightMark, char symbol, int index)
        {
            if (leftMark.GetBrightness() < .5f && rightMark.GetBrightness() > .5f)
                return Environment.CurrentDirectory + @"\bases\let\" + symbol + index + ".png";
            if (leftMark.GetBrightness() > .5f && rightMark.GetBrightness() > .5f)
                return Environment.CurrentDirectory + @"\bases\let\" + symbol + "!" + index + ".png";
            if(leftMark.GetBrightness() > .5f && rightMark.GetBrightness() < .5f)
                return Environment.CurrentDirectory + @"\bases\let\" + symbol + index + ".png";
            return String.Empty;
        }

        public static void BuildLine(Bitmap image, 
            Color leftMark, 
            Color rightMark, 
            int startX, 
            int startY, 
            string symbols, 
            int startId, 
            int endId)
        {

            int length = endId - startId;

            for (int i = 0; i < symbols.Length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                   Bitmap letterBitmap = image.Clone(new Rectangle(startX + j*143, startY + i*300, 115, 115), image.PixelFormat);

                    Bitmap outBitmap = new Bitmap(letterBitmap.Width, letterBitmap.Height);

                    for (int bi = 0; bi < outBitmap.Height; bi++)
                    {
                        for (int bj = 0; bj < outBitmap.Width; bj++)
                        {
                            Color color = letterBitmap.GetPixel(bj, bi);
                            int avg = (color.R + color.B + color.G)/3;
                            if(avg < 225) outBitmap.SetPixel(bj, bi, color);
                        }
                    }


                    string path = GetPath(leftMark, rightMark, symbols[i], startId + j);
                   // MessageBox.Show(path);
                    if(new FileInfo(path).Exists) new FileInfo(path).Delete();
                    Bitmap resultBitmap = SliceLetter(outBitmap);
                    
                    resultBitmap.Save(path);
                    configuration.Add(GetConfig(symbols[i], j, resultBitmap.Width, resultBitmap.Height));
                    Progress += .333;
                    OnProgress();
                }
            }
        }

        public static void BuildHandWrite(string path, int startId, int endId)
        {
            Progress = 0;
            Height = -1;
            string firstPath = "", secondPath = "", thirdPath = "";
            int firstX = 0, firstY = 0;
            int secondX = 0, secondY = 0;
            int thirdX = 0, thirdY = 0;

            Bitmap image = new Bitmap(path);
            Color leftMark = image.GetPixel(100, 100);
            Color rightMark = image.GetPixel(2450, 100);

            if (leftMark.GetBrightness() < .5f && rightMark.GetBrightness() > .5f)
            {
                firstX = 200;
                firstY = 205;
                secondX = 925;
                secondY = 357;
                thirdX = 1648;
                thirdY = 205;
                firstPath = "абвгдежзийк";
                secondPath = "лмнопрстуф";
                thirdPath = "хцчшщъыьэюя";
            }
            if (leftMark.GetBrightness() > .5f && rightMark.GetBrightness() > .5f)
            {
                firstX = 195;
                firstY = 205;
                secondX = 920;
                secondY = 357;
                thirdX = 1643;
                thirdY = 205;
                firstPath = "абвгдежзийк".ToLower();
                secondPath = "лмнопрстуф".ToLower();
                thirdPath = "хцчшщъыьэюя".ToLower();
            }
            if (leftMark.GetBrightness() > .5f && rightMark.GetBrightness() < .5f)
            {
                
            }


            BuildLine(image, leftMark, rightMark, firstX, firstY, firstPath, startId, endId);
            BuildLine(image, leftMark, rightMark, secondX, secondY, secondPath, startId, endId);
            BuildLine(image, leftMark, rightMark, thirdX, thirdY, thirdPath, startId, endId);
        }

        static void  OnProgress()
        {
            if (OnBuildProgress != null)
                OnBuildProgress(Progress);
        }

        static LetterConfig GetConfig(char c, int idx, int width, int height)
        {
            if (Height == -1) Height = height;
            return new LetterConfig(c, idx, 0, 2, height - Height, new Size(width, height));
        }

        protected static Bitmap SliceLetter(Bitmap letter)
        {
            int x = 0, y = 0, w = letter.Width, h = letter.Height;

            for (int i = 0; i < letter.Width; i++)
            {
                int count = 0;
                for (int j = 0; j < letter.Height; j++)               
                    if (letter.GetPixel(i, j).A > 20) count++;
                if (count < 3) x++;
                else break;
            }

            for (int i = 0; i < letter.Height; i++)
            {
                int count = 0;
                for (int j = 0; j < letter.Width; j++)
                    if (letter.GetPixel(j, i).A > 20) count++;
                if (count < 3) y++;
                else break;
            }

            for (int i = letter.Width-1; i >=0 ; i--)
            {
                int count = 0;
                for (int j = 0; j < letter.Height; j++)
                    if (letter.GetPixel(i, j).A > 20) count++;
                if (count < 3) w--;
                else break;
            }

            for (int i = letter.Height - 1; i >=0 ; i--)
            {
                int count = 0;
                for (int j = 0; j < letter.Width; j++)
                    if (letter.GetPixel(j, i).A > 20) count++;
                if (count < 3) h--;
                else break;
            }

            Bitmap bitmap = new Bitmap(w-x, h-y);
            bitmap = letter.Clone(new Rectangle(x, y, w-x, h-y), letter.PixelFormat);
            return bitmap;
        }
    }
}
