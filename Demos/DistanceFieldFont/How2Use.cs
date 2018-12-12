using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RectangleTexture
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var fileInfo = new FileInfo(this.openFileDialog1.FileName);
                string directory = fileInfo.DirectoryName;
                string fileName = fileInfo.Name.Substring(0, fileInfo.Name.Length - ".txt".Length);
                string pngFilename = Path.Combine(directory, fileName + ".png");
                Dictionary<char, CharInfo> dict = SDFDictParser.Parse(fileInfo.FullName);
                {
                    Bitmap outPng = OutputRectangle(pngFilename, dict);
                    string outPngFilename = Path.Combine(directory, fileName + ".rect.png");
                    outPng.Save(outPngFilename);
                    outPng.Dispose();
                }
                {
                    Bitmap outPng = OutputLine(pngFilename, dict);
                    string outPngFilename = Path.Combine(directory, fileName + ".line.png");
                    outPng.Save(outPngFilename);
                    outPng.Dispose();
                }
                //{
                //    OutputRectangle2(pngFilename, dict, directory, fileName);
                //}
            }
        }

        private Bitmap OutputRectangle2(string pngFilename, Dictionary<char, CharInfo> dict,
            string directory, string fileName)
        {
            var bmpInput = new Bitmap(pngFilename);
            var bmpOutput = new Bitmap(bmpInput);
            bmpInput.Dispose();
            using (var g = Graphics.FromImage(bmpOutput))
            {
                bool odd = true;
                int index = 0;
                foreach (var item in dict)
                {
                    CharInfo charInfo = item.Value;
                    int x = charInfo.x, y = charInfo.y;
                    int width = charInfo.width, height = charInfo.height;
                    g.DrawRectangle(odd ? Pens.Red : Pens.Green, x, y, width, height);
                    odd = !odd;
                    bmpOutput.Save(Path.Combine(directory, string.Format("{0}.line.{1}.png", fileName, index)));
                    index++;
                }
            }

            return bmpOutput;
        }

        private Bitmap OutputLine(string pngFilename, Dictionary<char, CharInfo> dict)
        {
            float totalWidth = 0;
            float maxHeight = 0;
            foreach (var item in dict)
            {
                CharInfo charInfo = item.Value;
                //totalWidth += charInfo.width;
                totalWidth += charInfo.xAdvance;
                if (maxHeight < charInfo.yOffset) { maxHeight = charInfo.yOffset; }
            }

            float maxDelta = 0;
            foreach (var item in dict)
            {
                CharInfo charInfo = item.Value;
                float delta = charInfo.height - charInfo.yOffset;
                if (maxDelta < delta) { maxDelta = delta; }
            }
            maxHeight += maxDelta;

            var bmpOutput = new Bitmap((int)Math.Ceiling(totalWidth), (int)Math.Ceiling(maxHeight));
            float cursorX = 0, cursorY = 0;
            using (var g = Graphics.FromImage(bmpOutput))
            {
                var bmpInput = new Bitmap(pngFilename);
                bool odd = true;
                foreach (var item in dict)
                {
                    CharInfo charInfo = item.Value;
                    int x = charInfo.x, y = charInfo.y;
                    int width = charInfo.width, height = charInfo.height;
                    var dst = new RectangleF(
                        cursorX + charInfo.xOffset,
                        cursorY + maxHeight - charInfo.yOffset - maxDelta,
                        width, height);
                    g.DrawImage(bmpInput, dst, new Rectangle(x, y, width, height),
                        GraphicsUnit.Pixel);
                    g.DrawRectangle(odd ? Pens.Red : Pens.Green, dst.X, dst.Y, dst.Width - 1, dst.Height - 1);
                    odd = !odd;
                    //cursorX += charInfo.width;
                    cursorX += charInfo.xAdvance;
                }
                bmpInput.Dispose();
            }

            return bmpOutput;
        }

        private Bitmap OutputRectangle(string pngFilename, Dictionary<char, CharInfo> dict)
        {
            var bmpInput = new Bitmap(pngFilename);
            var bmpOutput = new Bitmap(bmpInput);
            bmpInput.Dispose();
            using (var g = Graphics.FromImage(bmpOutput))
            {
                bool odd = true;
                foreach (var item in dict)
                {
                    CharInfo charInfo = item.Value;
                    int x = charInfo.x, y = charInfo.y;
                    int width = charInfo.width, height = charInfo.height;
                    g.DrawRectangle(odd ? Pens.Red : Pens.Green, x, y, width, height);
                    odd = !odd;
                }
            }

            return bmpOutput;
        }
    }
}
