using SharpFont;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

using System.Windows.Forms;

namespace CSharpGL.Demos
{
    public partial class Form1111SharpFont : Form
    {

        public Form1111SharpFont()
        {
            InitializeComponent();
        }

        private void btnDumpGlyphsTo_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.btnDumpGlyphsTo.Enabled = false;

                string ttfFilename = this.openFileDialog1.FileName;
                var fileInfo = new FileInfo(ttfFilename);
                //var fontResource = FontResource.Load(ttfFilename, ' ', (char)126);
                //fontResource.CharInfoDict.ToXElement().Save(
                //    Path.Combine(fileInfo.DirectoryName, string.Format("{0}.xml", fileInfo.Name)));
                using (FileStream file = File.OpenRead(ttfFilename))
                {
                    var typeface = new FontFace(file);
                    int pixelSize = 32;
                    for (int c = 0; c <= char.MaxValue; c++)
                    {
                        Surface surface; Glyph glyph;
                        if (RenderGlyph(typeface, (char)c, pixelSize, out surface, out glyph))
                        {
                            string glyphFilename = Path.Combine(fileInfo.DirectoryName,
                                string.Format("{0}.{1}.bmp", fileInfo.Name, (int)c));
                            SaveSurface(surface, glyph, pixelSize, glyphFilename);

                            surface.Dispose();
                        }
                    }
                }

                this.btnDumpGlyphsTo.Enabled = true;
            }
        }

        private static unsafe bool RenderGlyph(FontFace typeface, char c, int pixelSize, out Surface surface, out Glyph glyph)
        {
            bool result = false;

            glyph = typeface.GetGlyph(c, pixelSize);
            if (glyph != null && glyph.RenderWidth > 0 && glyph.RenderHeight > 0)
            {
                surface = new Surface
                {
                    Bits = Marshal.AllocHGlobal(glyph.RenderWidth * glyph.RenderHeight),
                    Width = glyph.RenderWidth,
                    Height = glyph.RenderHeight,
                    Pitch = glyph.RenderWidth
                };

                var stuff = (byte*)surface.Bits;
                for (int i = 0; i < surface.Width * surface.Height; i++)
                    *stuff++ = 0;

                glyph.RenderTo(surface);

                result = true;
            }
            else
            {
                surface = new Surface();
            }

            return result;
        }

        static unsafe void SaveSurface(Surface surface, Glyph glyph, int pixelSize, string fileName)
        {
            if (surface.Width > 0 && surface.Height > 0)
            {
                var surfaceBitmap = GetSurfaceBitmap(ref surface);
                var bitmap = new Bitmap(surface.Width, pixelSize);
                Graphics g = Graphics.FromImage(bitmap);
                g.DrawImage(surfaceBitmap, 0, pixelSize * 3 / 4 - glyph.HorizontalMetrics.Bearing.Y);
                g.Dispose();
                surfaceBitmap.Dispose();

                bitmap.Save(fileName);
                bitmap.Dispose();
            }
        }

        unsafe private static Bitmap GetSurfaceBitmap(ref Surface surface)
        {
            var bitmap = new Bitmap(surface.Width, surface.Height, PixelFormat.Format24bppRgb);
            var bitmapData = bitmap.LockBits(new Rectangle(0, 0, surface.Width, surface.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
            for (int y = 0; y < surface.Height; y++)
            {
                var dest = (byte*)bitmapData.Scan0 + y * bitmapData.Stride;
                var src = (byte*)surface.Bits + y * surface.Pitch;

                for (int x = 0; x < surface.Width; x++)
                {
                    var b = *src++;
                    *dest++ = b;
                    *dest++ = b;
                    *dest++ = b;
                }
            }
            bitmap.UnlockBits(bitmapData);
            return bitmap;
        }
    }

}
