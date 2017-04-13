using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Font2Texture
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestIfDoubleCharChangesHeight();

            //TestIfAllHeightSame();

            TestAllUnicodeSizes();

            Console.WriteLine("all done!");
        }

        private static void TestAllUnicodeSizes()
        {
            var font = new Font("Arial", 32);
            using (var bmp = new Bitmap(1, 1))
            {
                using (var graphics = Graphics.FromImage(bmp))
                {
                    for (int i = 0; i <= char.MaxValue; i++)
                    {
                        Console.WriteLine("Processing {0}/{1}", i, char.MaxValue);
                        Size oneSize = graphics.MeasureString(string.Format("{0}", (char)i), font).ToSize();
                        Size doubleSize = graphics.MeasureString(string.Format("{0}{0}", (char)i), font).ToSize();

                        if (oneSize.Height != doubleSize.Height) { continue; }
                        if (oneSize.Width >= doubleSize.Width) { continue; }

                        Size charSize = new Size(doubleSize.Width - oneSize.Width, oneSize.Height);
                        string dirName = string.Format("{0}x{1}", charSize.Width, charSize.Height);
                        if (!Directory.Exists(dirName)) { Directory.CreateDirectory(dirName); }

                        using (var oneBitmap = new Bitmap(oneSize.Width, oneSize.Height))
                        {
                            using (var g = Graphics.FromImage(oneBitmap))
                            { g.DrawString(string.Format("{0}", (char)i), font, Brushes.Red, 0, 0); }

                            using (var charBitmap = new Bitmap(charSize.Width, charSize.Height))
                            {
                                using (var g = Graphics.FromImage(charBitmap))
                                {
                                    g.DrawImage(oneBitmap, -(oneSize.Width - charSize.Width) / 2, 0);
                                }

                                charBitmap.Save(string.Format(@"{0}x{1}\{2}.png", charSize.Width, charSize.Height, i));
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 有2种高度
        /// </summary>
        private static void TestIfAllHeightSame()
        {
            var font = new Font("Arial", 32);
            var heightDict = new Dictionary<float, List<char>>();

            using (var bmp = new Bitmap(1, 1))
            {
                using (var graphics = Graphics.FromImage(bmp))
                {
                    for (int i = 0; i <= char.MaxValue; i++)
                    {
                        SizeF oneSize = graphics.MeasureString(string.Format("{0}", (char)i), font);
                        SizeF doubleSize = graphics.MeasureString(string.Format("{0}{0}", (char)i), font);
                        if (oneSize.Height != doubleSize.Height) { continue; }

                        if (heightDict.ContainsKey(oneSize.Height))
                        {
                            heightDict[oneSize.Height].Add((char)i);
                        }
                        else
                        {
                            heightDict.Add(oneSize.Height, new List<char>((char)i));
                        }
                    }
                }
            }

            Console.WriteLine("{0} heights", heightDict.Count);
        }

        /// <summary>
        /// result: only (char)10 and (char)132 triggers ("!!!!!!!!!!!!!!");
        /// </summary>
        static void TestIfDoubleCharChangesHeight()
        {
            var font = new Font("Arial", 32);
            using (var bmp = new Bitmap(1, 1))
            {
                using (var graphics = Graphics.FromImage(bmp))
                {
                    for (int i = 0; i <= char.MaxValue; i++)
                    {
                        SizeF oneSize = graphics.MeasureString(string.Format("{0}", (char)i), font);
                        SizeF doubleSize = graphics.MeasureString(string.Format("{0}{0}", (char)i), font);
                        if (oneSize.Height != doubleSize.Height)
                        {
                            Console.WriteLine("!!!!!!!!!!!!!!");
                        }
                    }
                }
            }
        }
    }
}
