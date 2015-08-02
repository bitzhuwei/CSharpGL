using CSharpGL;
using CSharpGL.Objects.Texts.FreeTypes;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace TTF2Bmps
{

    /// <summary>
    /// A true 3D Font
    /// </summary>
    public class Font3D
    {

        /// <summary>
        /// A true 3D Font
        /// </summary>
        /// <param name="font">TTF file name</param>
        /// <param name="size"></param>
        public Font3D(string font, int size, string outputDir)
        {
            // 初始化FreeType库：创建FreeType库指针
            FreeTypeLibrary library = new FreeTypeLibrary();

            // 初始化字体库
            FreeTypeFace face = new FreeTypeFace(library, font);

            const int textureCount = 128;// char.MaxValue;
            for (int c = 0; c < textureCount; c++)
            {
                Compile_Character(face, c, size, outputDir);
            }

            // 释放字体库和FreeFont库
            face.Dispose();
            library.Dispose();
        }

        public void Compile_Character(FreeTypeFace face, int c, int fontHeight, string outputDir)
        {
            // Convert the glyph to a bitmap
            // 把字形转换为纹理
            FreeTypeBitmapGlyph bmpGlyph = new FreeTypeBitmapGlyph(face, Convert.ToChar(c), fontHeight);
            int size = (bmpGlyph.obj.bitmap.width * bmpGlyph.obj.bitmap.rows);
            if (size <= 0)
            {
                return;

            }

            byte[] bmp = new byte[size];
            Marshal.Copy(bmpGlyph.obj.bitmap.buffer, bmp, 0, bmp.Length);

            // Next we expand the bitmap into an opengl texture
            // 把glyph_bmp.bitmap的长宽扩展成2的指数倍
            int width = next_po2(bmpGlyph.obj.bitmap.width);
            int height = next_po2(bmpGlyph.obj.bitmap.rows);
            UnmanagedArray<byte> expanded = new UnmanagedArray<byte>(2 * width * height);
            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    expanded[2 * (i + j * width)] = expanded[2 * (i + j * width) + 1] =
                        (i >= bmpGlyph.obj.bitmap.width || j >= bmpGlyph.obj.bitmap.rows) ?
                        (byte)0 : bmp[i + bmpGlyph.obj.bitmap.width * j];
                }
            }

            {
                //  Create the bitmap.
                System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(
                    width / 2,
                    bmpGlyph.obj.bitmap.rows,
                    width * 4 / 2,
                    System.Drawing.Imaging.PixelFormat.Format32bppRgb,
                    expanded.Header);
                string path = Path.Combine(outputDir, string.Format("{0}.bmp", c));
                bitmap.Save(path);
                bitmap.Dispose();
            }
            expanded = null;
            bmp = null;

            //// Account for freetype spacing rules
            //// 矩阵平移
            //GL.Translatef(bmpGlyph.obj.left, 0, 0);
            //GL.PushMatrix();
            //GL.Translatef(0, bmpGlyph.obj.top - bmpGlyph.obj.bitmap.rows, 0);
            //float x = (float)bmpGlyph.obj.bitmap.width / (float)width;
            //float y = (float)bmpGlyph.obj.bitmap.rows / (float)height;

            //// Draw the quad
            //// 用Quad+纹理绘制字符
            //GL.Begin(GL.GL_QUADS);
            //GL.TexCoord2d(0, 0); GL.Vertex2f(0, bmpGlyph.obj.bitmap.rows);
            //GL.TexCoord2d(0, y); GL.Vertex2f(0, 0);
            //GL.TexCoord2d(x, y); GL.Vertex2f(bmpGlyph.obj.bitmap.width, 0);
            //GL.TexCoord2d(x, 0); GL.Vertex2f(bmpGlyph.obj.bitmap.width, bmpGlyph.obj.bitmap.rows);
            //GL.End();
            //GL.PopMatrix();

            //// Advance for the next character
            //// 准备绘制下一个字符
            //GL.Translatef(bmpGlyph.obj.bitmap.width, 0, 0);
            //extent_x[c] = bmpGlyph.obj.left + bmpGlyph.obj.bitmap.width;

        }

        internal int next_po2(int a)
        {
            int rval = 1;
            while (rval < a) rval <<= 1;
            return rval;
        }

    }

}