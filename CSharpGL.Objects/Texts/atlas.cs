using CSharpGL.Objects.Texts.FreeTypes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Objects.Texts
{
    ///**
    // * The atlas struct holds a texture that contains the visible US-ASCII characters
    // * of a certain font rendered with a certain character height.
    // * It also contains an array that contains all the information necessary to
    // * generate the appropriate vertex and texture coordinates for each character.
    // *
    // * After the constructor is run, you don't need to use any FreeType functions anymore.
    // */

    /// <summary>
    ///
    /// </summary>
    struct CharacterInformation
    {
        public float advanceX;	// advance.x
        public float advanceY;	// advance.y

        public float bitmapWidth;	// bitmap.width;
        public float bitmapHeight;	// bitmap.height;

        public float bitmapLeft;	// bitmap_left;
        public float bitmapTop;	// bitmap_top;

        public float xoffset;	// x offset of glyph in texture coordinates
        public float yoffset;	// y offset of glyph in texture coordinates
    } //c[128];		// character information

    /// <summary>
    /// 用一个纹理绘制ASCII表上所有可见字符（具有指定的高度和字体）
    /// </summary>
    class Atlas
    {
        public uint[] tex = new uint[1];		// texture object

        public int widthOfTexture;			// width of texture in pixels
        public int heightOfTexture;			// height of texture in pixels

        public CharacterInformation[] characterInfos = new CharacterInformation[128];
        int[] MaxWidth = new int[1];

        public Atlas(FreeTypeFace face, int fontHeight, Shaders.ShaderProgram shaderProgram)
        {
            //Dictionary<char, System.Drawing.Bitmap> charBitmapDict = new Dictionary<char, System.Drawing.Bitmap>();


            //	Get the maximum texture size supported by GL.
            GL.GetInteger(GetTarget.MaxTextureSize, MaxWidth);

            /* Find minimum size for a texture holding all visible ASCII characters */
            FindTextureSize(face, fontHeight);

            System.Drawing.Bitmap bigBitmap = new System.Drawing.Bitmap(this.widthOfTexture, this.heightOfTexture);
            Graphics graphics = Graphics.FromImage(bigBitmap);

            /* Paste all glyph bitmaps into the texture, remembering the offset */
            int xoffset = 0;
            int yoffset = 0;

            int newRowHeight = 0;

            for (int i = 32; i < 128; i++)
            {
                char c = Convert.ToChar(i);
                FreeTypeBitmapGlyph bmpGlyph = new FreeTypeBitmapGlyph(face, c, fontHeight);
                int width = 0, height = 0;

                if (bmpGlyph.obj.bitmap.buffer != IntPtr.Zero)
                {
                    int size = (bmpGlyph.obj.bitmap.width * bmpGlyph.obj.bitmap.rows);
                    byte[] bmp = new byte[size];
                    Marshal.Copy(bmpGlyph.obj.bitmap.buffer, bmp, 0, bmp.Length);

                    // Next we expand the bitmap into an opengl texture
                    // 把glyph_bmp.bitmap的长宽扩展成2的指数倍
                    width = next_po2(bmpGlyph.obj.bitmap.width);
                    height = next_po2(bmpGlyph.obj.bitmap.rows);
                    UnmanagedArray<byte> expanded = new UnmanagedArray<byte>(2 * width * height);
                    for (int row = 0; row < height; row++)
                    {
                        for (int col = 0; col < width; col++)
                        {
                            expanded[2 * (col + row * width)] = expanded[2 * (col + row * width) + 1] =
                                (col >= bmpGlyph.obj.bitmap.width || row >= bmpGlyph.obj.bitmap.rows) ?
                                (byte)0 : bmp[col + bmpGlyph.obj.bitmap.width * row];
                        }
                    }

                    if (xoffset + width + 1 >= MaxWidth[0])
                    {
                        yoffset += newRowHeight;
                        newRowHeight = 0;
                        xoffset = 0;
                    }

                    //GL.TexSubImage2D(TexSubImage2DTarget.Texture2D, 0,
                    //    xoffset, yoffset,
                    //    width, height,
                    //    //bmpGlyph.obj.bitmap.width, bmpGlyph.obj.bitmap.rows,
                    //    TexSubImage2DFormats.Alpha, TexSubImage2DType.UnsignedByte,
                    //    expanded.Header);
                    //bmpGlyph.obj.bitmap.buffer);

                    //{
                    //  Create the bitmap.
                    {
                        System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(
                            width / 2,
                            bmpGlyph.obj.bitmap.rows,
                            width * 4 / 2,
                            System.Drawing.Imaging.PixelFormat.Format32bppRgb,
                            expanded.Header);
                        //charBitmapDict.Add(c, bitmap);
                        graphics.DrawImage(bitmap, xoffset, yoffset);
                        //bitmap.Save(string.Format("Atlas{0}.bmp", i));
                    }
                    //{
                    //    System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(
                    //        bmpGlyph.obj.bitmap.width,
                    //        bmpGlyph.obj.bitmap.rows,
                    //        bmpGlyph.obj.bitmap.width * 4,
                    //        System.Drawing.Imaging.PixelFormat.Format32bppRgb,
                    //        bmpBytes.Header);//bmpGlyph.obj.bitmap.buffer);
                    //    bitmap.Save(string.Format("bmpGlyph{0}.bmp", i));
                    //}
                    //}
                }

                characterInfos[i].advanceX = bmpGlyph.glyphRec.advance.x >> 6;
                characterInfos[i].advanceY = bmpGlyph.glyphRec.advance.y >> 6;

                characterInfos[i].bitmapWidth = width;
                characterInfos[i].bitmapHeight = height;

                characterInfos[i].bitmapLeft = bmpGlyph.obj.left;
                characterInfos[i].bitmapTop = bmpGlyph.obj.top;

                characterInfos[i].xoffset = xoffset / (float)widthOfTexture;
                characterInfos[i].yoffset = yoffset / (float)heightOfTexture;

                newRowHeight = Math.Max(newRowHeight, height);
                xoffset += width + 1;
            }

            {
                bigBitmap.Save("bigbitmap.bmp");

                /* Create a texture that will be used to hold all ASCII glyphs */
                CreateTextureObject(bigBitmap, shaderProgram);

                graphics.Dispose();
                bigBitmap.Dispose();
            }

            // 把整个纹理输出为图片
            //{
            //    UnmanagedArray<byte> image = new UnmanagedArray<byte>(widthOfTexture * heightOfTexture);

            //    GL.GetTexImage(GetTexImageTargets.Texture2D, 0, GetTexImageFormats.Alpha, GetTexImageTypes.UnsignedByte, image);

            //    //  Create the bitmap.
            //    foreach (var pixelFormat in Enum.GetValues(typeof(System.Drawing.Imaging.PixelFormat)))
            //    {
            //        try
            //        {
            //            System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(
            //                widthOfTexture,
            //                heightOfTexture,
            //                widthOfTexture * 4,
            //                (System.Drawing.Imaging.PixelFormat)pixelFormat,
            //                image.Header);

            //            bitmap.Save(string.Format("wholeTexture-{0}.bmp", pixelFormat));
            //            bitmap.Dispose();
            //        }
            //        catch (Exception e)
            //        {
            //            Console.WriteLine(e);
            //        }
            //    }
            //}
        }

        private void CreateTextureObject(System.Drawing.Bitmap image, Shaders.ShaderProgram shaderProgram)
        {
            //	Get the maximum texture size supported by OpenGL.
            int[] textureMaxSize = { 0 };
            GL.GetInteger(GetTarget.MaxTextureSize, textureMaxSize);

            //	Find the target width and height sizes, which is just the highest
            //	posible power of two that'll fit into the image.
            int targetWidth = textureMaxSize[0];
            int targetHeight = textureMaxSize[0];

            for (int size = 1; size <= textureMaxSize[0]; size *= 2)
            {
                if (image.Width < size)
                {
                    targetWidth = size / 2;
                    break;
                }
                if (image.Width == size)
                    targetWidth = size;

            }

            for (int size = 1; size <= textureMaxSize[0]; size *= 2)
            {
                if (image.Height < size)
                {
                    targetHeight = size / 2;
                    break;
                }
                if (image.Height == size)
                    targetHeight = size;
            }

            //  If need to scale, do so now.
            if (image.Width != targetWidth || image.Height != targetHeight)
            {
                //  Resize the image.
                Image newImage = image.GetThumbnailImage(targetWidth, targetHeight, null, IntPtr.Zero);

                //  Destory the old image, and reset.
                //image.Dispose();
                image = (System.Drawing.Bitmap)newImage;
            }

            //  Lock the image bits (so that we can pass them to OGL).
            BitmapData bitmapData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height),
                ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            //	Set the width and height.
            widthOfTexture = image.Width;
            heightOfTexture = image.Height;

            ////
            //GL.ActiveTexture(GL.GL_TEXTURE0);
            GL.GenTextures(1, tex);
            GL.BindTexture(GL.GL_TEXTURE_2D, tex[0]);
            shaderProgram.SetUniform1("tex", tex[0]);

            GL.TexImage2D(GL.GL_TEXTURE_2D, 0, (int)GL.GL_RGBA,
                widthOfTexture, heightOfTexture, 0, GL.GL_BGRA, GL.GL_UNSIGNED_BYTE,
                bitmapData.Scan0);

            //  Unlock the image.
            image.UnlockBits(bitmapData);

            //  Dispose of the image file.
            image.Dispose();

            //GL.TexImage2D(TexImage2DTargets.Texture2D, 0,
            //    TexImage2DFormats.Alpha, widthOfTexture, heightOfTexture,
            //    0, TexImage2DFormats.Alpha, TexImage2DTypes.UnsignedByte, IntPtr.Zero);

            /* We require 1 byte alignment when uploading texture data */
            GL.PixelStorei(GL.GL_UNPACK_ALIGNMENT, 1);

            /* Clamping to edges is important to prevent artifacts when scaling */
            GL.TexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_WRAP_S, (int)GL.GL_CLAMP_TO_EDGE);
            GL.TexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_WRAP_T, (int)GL.GL_CLAMP_TO_EDGE);

            /* Linear filtering usually looks best for text */
            GL.TexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MIN_FILTER, (int)GL.GL_LINEAR);
            GL.TexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MAG_FILTER, (int)GL.GL_LINEAR);
            ////

            ////	Bind our texture object (make it the current texture).
            //gl.BindTexture(OpenGL.GL_TEXTURE_2D, TextureName);

            ////  Set the image data.
            //gl.TexImage2D(OpenGL.GL_TEXTURE_2D, 0, (int)OpenGL.GL_RGBA,
            //    width, height, 0, OpenGL.GL_BGRA, OpenGL.GL_UNSIGNED_BYTE,
            //    bitmapData.Scan0);

            ////  Unlock the image.
            //image.UnlockBits(bitmapData);

            ////  Dispose of the image file.
            //image.Dispose();

            ////  Set linear filtering mode.
            //gl.TexParameter(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_MIN_FILTER, OpenGL.GL_LINEAR);
            //gl.TexParameter(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_MAG_FILTER, OpenGL.GL_LINEAR);
            //////
            ////GL.ActiveTexture(GL.GL_TEXTURE0);
            //GL.GenTextures(1, tex);
            //GL.BindTexture(GL.GL_TEXTURE_2D, tex[0]);
            //shaderProgram.SetUniform1("tex", tex[0]);

            //GL.TexImage2D(TexImage2DTargets.Texture2D, 0, TexImage2DFormats.Alpha, widthOfTexture, heightOfTexture, 0, TexImage2DFormats.Alpha, TexImage2DTypes.UnsignedByte, IntPtr.Zero);

            ///* We require 1 byte alignment when uploading texture data */
            //GL.PixelStorei(GL.GL_UNPACK_ALIGNMENT, 1);

            ///* Clamping to edges is important to prevent artifacts when scaling */
            //GL.TexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_WRAP_S, (int)GL.GL_CLAMP_TO_EDGE);
            //GL.TexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_WRAP_T, (int)GL.GL_CLAMP_TO_EDGE);

            ///* Linear filtering usually looks best for text */
            //GL.TexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MIN_FILTER, (int)GL.GL_LINEAR);
            //GL.TexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MAG_FILTER, (int)GL.GL_LINEAR);
        }

        private void FindTextureSize(FreeTypeFace face, int fontHeight)
        {
            this.widthOfTexture = 0;
            this.heightOfTexture = 0;

            int newRowWidth = 0;
            int newRowHeight = 0;

            for (int i = 32; i < 128; i++)
            {
                FreeTypeBitmapGlyph bmpGlyph = new FreeTypeBitmapGlyph(face, Convert.ToChar(i), fontHeight);

                // Next we expand the bitmap into an opengl texture
                // 把glyph_bmp.bitmap的长宽扩展成2的指数倍
                int width = next_po2(bmpGlyph.obj.bitmap.width);
                int height = next_po2(bmpGlyph.obj.bitmap.rows);

                if (newRowWidth + width + 1 >= MaxWidth[0])
                {
                    widthOfTexture = Math.Max(widthOfTexture, newRowWidth);
                    heightOfTexture += newRowHeight;
                    newRowWidth = 0;
                    newRowHeight = 0;
                }
                newRowWidth += width + 1;
                newRowHeight = Math.Max(newRowHeight, height);
            }

            widthOfTexture = Math.Max(widthOfTexture, newRowWidth);
            heightOfTexture += newRowHeight;
        }

        internal int next_po2(int a)
        {
            int rval = 1;
            while (rval < a) rval <<= 1;
            return rval;
        }

        ~Atlas()
        {
            //glDeleteTextures(1, &tex);
            //GL.DeleteTextures(1, tex);
        }
    };
}
