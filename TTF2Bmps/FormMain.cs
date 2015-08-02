using CSharpGL;
using CSharpGL.Objects.Texts;
using CSharpGL.Objects.Texts.FreeTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TTF2Bmps
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void btnBrowseTTFFile_Click(object sender, EventArgs e)
        {
            if (openTTFFileDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.txtTTFFullname.Text = openTTFFileDlg.FileName;
            }
        }

        private void btnBrowseFolder_Click(object sender, EventArgs e)
        {
            if (saveToFolderDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.txtDestFolder.Text = saveToFolderDlg.SelectedPath;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtTTFFullname.Text))
            {
                string message = string.Format("{0}", "Please select a TTF file first!");
                MessageBox.Show(message);
                return;
            }

            if (string.IsNullOrEmpty(this.txtDestFolder.Text))
            {
                string message = string.Format("{0}", "Please select the path to save bitmaps to first!");
                MessageBox.Show(message);
                return;
            }

            string fontFullname = this.txtTTFFullname.Text;
            int fontHeight = 48;
            Font3D font3D = new Font3D(fontFullname, fontHeight);

            //FreeTypeLibrary lib = new FreeTypeLibrary();
            //FreeTypeFace face = new FreeTypeFace(lib, this.txtTTFFullname.Text);

            ////// Freetype measures the font size in 1/64th of pixels for accuracy
            ////// so we need to request characters in size*64
            ////// 设置字符大小？
            ////FreeTypeAPI.FT_Set_Char_Size(face.pointer, size << 6, size << 6, 96, 96);

            ////// Provide a reasonably accurate estimate for expected pixel sizes
            ////// when we later on create the bitmaps for the font
            ////// 设置像素大小？
            ////FreeTypeAPI.FT_Set_Pixel_Sizes(face.pointer, size, size);

            //for (int i = 0; i < 128; i++)
            //{
            //    char c = Convert.ToChar(i);
            //    Compile_Character(face, i, fontHeight);
            //}

            //face.Dispose();
            //lib.Dispose();


        }

        //public void Compile_Character(FreeTypeFace face, int charIndex, int fontHeight)
        //{
        //    char c = Convert.ToChar(charIndex);
        //    // Convert the glyph to a bitmap
        //    // 把字形转换为纹理
        //    FreeTypeBitmapGlyph bmpGlyph = new FreeTypeBitmapGlyph(face, c, fontHeight);
        //    int size = (bmpGlyph.obj.bitmap.width * bmpGlyph.obj.bitmap.rows);
        //    if (size <= 0) { return; }

        //    byte[] bmp = new byte[size];
        //    Marshal.Copy(bmpGlyph.obj.bitmap.buffer, bmp, 0, bmp.Length);

        //    // Next we expand the bitmap into an opengl texture
        //    // 把glyph_bmp.bitmap的长宽扩展成2的指数倍
        //    int width = next_po2(bmpGlyph.obj.bitmap.width);
        //    int height = next_po2(bmpGlyph.obj.bitmap.rows);
        //    UnmanagedArray<byte> expanded = new UnmanagedArray<byte>(2 * width * height);
        //    for (int j = 0; j < height; j++)
        //    {
        //        for (int i = 0; i < width; i++)
        //        {
        //            expanded[2 * (i + j * width)] = expanded[2 * (i + j * width) + 1] =
        //                (i >= bmpGlyph.obj.bitmap.width || j >= bmpGlyph.obj.bitmap.rows) ?
        //                (byte)0 : bmp[i + bmpGlyph.obj.bitmap.width * j];
        //        }
        //    }

        //    {
        //        //  Create the bitmap.
        //        System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(
        //            width / 2,
        //            bmpGlyph.obj.bitmap.rows,
        //            width * 2,
        //            System.Drawing.Imaging.PixelFormat.Format32bppRgb,
        //            expanded.Header);
        //        FileInfo file = new FileInfo(this.txtTTFFullname.Text);
        //        string fullname = Path.Combine(this.txtDestFolder.Text, file.Name + charIndex + ".bmp");
        //        bitmap.Save(fullname);
        //    }

        //    expanded = null;
        //    bmp = null;

        //    float x = (float)bmpGlyph.obj.bitmap.width / (float)width;
        //    float y = (float)bmpGlyph.obj.bitmap.rows / (float)height;

        //    // Draw the quad
        //    // 用Quad+纹理绘制字符
        //    GL.Begin(GL.GL_QUADS);
        //    GL.TexCoord2d(0, 0); GL.Vertex2f(0, bmpGlyph.obj.bitmap.rows);
        //    GL.TexCoord2d(0, y); GL.Vertex2f(0, 0);
        //    GL.TexCoord2d(x, y); GL.Vertex2f(bmpGlyph.obj.bitmap.width, 0);
        //    GL.TexCoord2d(x, 0); GL.Vertex2f(bmpGlyph.obj.bitmap.width, bmpGlyph.obj.bitmap.rows);
        //    GL.End();

        //}

        //internal int next_po2(int a)
        //{
        //    int rval = 1;
        //    while (rval < a) rval <<= 1;
        //    return rval;
        //}
    }
}
