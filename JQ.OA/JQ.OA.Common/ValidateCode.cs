using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JQ.OA.Common
{
    /// <summary>
    /// Create a capthcha image
    /// </summary>
    public class ValidateCode
    {
        public ValidateCode() { }

        /// <summary>
        /// The max length of the captcha code
        /// </summary>
        public int MaxLength
        {
            get { return 10; }
        }
        /// <summary>
        /// The minimum length of the captcha code
        /// </summary>
        public int MinLength
        {
            get { return 1; }
        }

        public string CreateValidateCode(int length)
        {
            int[] randMembers = new int[length];
            int[] validateNums = new int[length];
            string validateNumberStr = "";

            //Create initial sequence values
            int seekSeek = unchecked((int)DateTime.Now.Ticks);
            Random seekRand = new Random(seekSeek);
            int beginSeek = (int)seekRand.Next(0, Int32.MaxValue - length * 10000);
            int[] seeks = new int[length];
            for (int i = 0; i < length; i++)
            {
                beginSeek += 10000;
                seeks[i] = beginSeek;
            }

            //Generate a random number
            for (int i = 0; i < length; i++)
            {
                Random rand = new Random(seeks[i]);
                int pownum = 1 * (int)Math.Pow(10, length);
                randMembers[i] = rand.Next(pownum, Int32.MaxValue);

            }

            //Pick "length" numbers in random
            for (int i = 0; i < length; i++)
            {
                string numStr = randMembers[i].ToString();
                int numLength = numStr.Length;
                Random rand = new Random();
                int numPosition = rand.Next(0, numLength - 1);
                validateNums[i] = Int32.Parse(numStr.Substring(numPosition, 1));
            }

            //Create captcha code
            for (int i = 0; i < length; i++)
            {
                validateNumberStr += validateNums[i].ToString();
            }
            
            return validateNumberStr;
        }

        /// <summary>
        /// Caculate the length of captcha code image
        /// </summary>
        /// <param name="validateNumLength"></param>
        /// <returns></returns>
        public static int GetImageWidth (int validateNumLength)
        {
            return (int)(validateNumLength * 12);
        }

        public static double GetImageHeight()
        {
            return 22.5;
        }

        public byte[] CreateValidateGraphic(string validateCode)
        {
            Bitmap image = new Bitmap((int)Math.Ceiling(validateCode.Length * 12.0), 22);
            Graphics g = Graphics.FromImage(image);
            try
            {
                Random random = new Random();
                g.Clear(Color.White);

                //Draw inference lines
                for (int i = 0; i < 25; i++)
                {
                    int x1 = random.Next(image.Width);
                    int x2 = random.Next(image.Width);
                    int y1 = random.Next(image.Height);
                    int y2 = random.Next(image.Height);

                    g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
                }

                Font font = new Font("Arial", 12, (FontStyle.Bold | FontStyle.Italic));
                LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height)
                    , Color.Blue, Color.DarkRed, 1.2f, true);
                g.DrawString(validateCode, font, brush, 3, 2);

                //Draw inference points
                for (int i=0; i < 100; i++)
                {
                    int x = random.Next(image.Width);
                    int y = random.Next(image.Height);
                    image.SetPixel(x, y, Color.FromArgb(random.Next()));
                }

                //Draw frame lines 
                g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);

                //Save image data
                MemoryStream stream = new MemoryStream();
                image.Save(stream, ImageFormat.Jpeg);

                //Output image stream
                return stream.ToArray();
            }finally
            {
                g.Dispose();
                image.Dispose();
            }
        }
    
    }
}
