using System;
using System.Runtime.InteropServices;

namespace CSharpGL.Objects.Texts
{

    /// <summary>
    /// A true 3D Font
    /// </summary>
    public class Font3D : IDisposable
    {
        private uint list_base;

        /// <summary>
        /// 字体大小
        /// </summary>
        private int font_size;

        private uint[] textures;

        private int[] extent_x;

        /// <summary>
        /// A true 3D Font
        /// </summary>
        /// <param name="font">TTF file name</param>
        /// <param name="size"></param>
        public Font3D(string font, int size)
        {
            // 保存字体大小，在渲染时用
            font_size = size;

            // We begin by creating a library pointer
            // 初始化FreeType库：创建FreeType库指针
            System.IntPtr libptr;
            {
                int ret = FreeTypeAPI.FT_Init_FreeType(out libptr);
                if (ret != 0) { throw new Exception("Could not init freetype library!"); }

                object libObj = Marshal.PtrToStructure(libptr, typeof(Library));
                Library lib = (Library)libObj;
                //lib = Marshal.PtrToStructure<Library>(libptr);
            }

            // Once we have the library we create and load the font face
            // 加载字体库
            System.IntPtr faceptr;
            Face face;
            {
                int retb = FreeTypeAPI.FT_New_Face(libptr, font, 0, out faceptr);
                if (retb != 0) { throw new Exception("Could not open font"); }

                face = (Face)Marshal.PtrToStructure(faceptr, typeof(Face));
            }

            // Freetype measures the font size in 1/64th of pixels for accuracy 
            // so we need to request characters in size*64
            // 设置字符大小？
            FreeTypeAPI.FT_Set_Char_Size(faceptr, size << 6, size << 6, 96, 96);

            // Provide a reasonably accurate estimate for expected pixel sizes
            // when we later on create the bitmaps for the font
            // 设置像素大小？
            FreeTypeAPI.FT_Set_Pixel_Sizes(faceptr, size, size);

            // Once we have the face loaded and sized we generate opengl textures 
            // from the glyphs for each printable character
            // 为所有可打印的字符的创建纹理
            const int textureCount = 128;// char.MaxValue;
            textures = new uint[textureCount];
            extent_x = new int[textureCount];
            list_base = GL.GenLists(textureCount);
            GL.GenTextures(textureCount, textures);
            for (int c = 0; c < textureCount; c++)
            {
                Compile_Character(face, faceptr, c);
            }

            // Dispose of these as we don't need
            // 释放字体库和FreeFont库
            FreeTypeAPI.FT_Done_Face(faceptr);
            FreeTypeAPI.FT_Done_FreeType(libptr);
        }

        public void Compile_Character(Face face, System.IntPtr faceptr, int c)
        {
            // We first convert the number index to a character index
            // 根据字符获取其编号
            int index = FreeTypeAPI.FT_Get_Char_Index(faceptr, Convert.ToChar(c));

            // Here we load the actual glyph for the character
            // 加载此字符的字形
            int ret = FreeTypeAPI.FT_Load_Glyph(faceptr, index, FT_LOAD_TYPES.FT_LOAD_DEFAULT);
            if (ret != 0) { throw new Exception(string.Format("Could not load character '{0}'", Convert.ToChar(c))); }

            // Convert the glyph to a bitmap
            // 把字形转换为纹理
            System.IntPtr glyph;
            {
                int retb = FreeTypeAPI.FT_Get_Glyph(face.glyphrec, out glyph);
                if (retb != 0) return;
                object objGlyphRec = Marshal.PtrToStructure(face.glyphrec, typeof(GlyphRec));
                GlyphRec glyph_rec = (GlyphRec)objGlyphRec;
            }

            FreeTypeAPI.FT_Glyph_To_Bitmap(out glyph, FT_RENDER_MODES.FT_RENDER_MODE_NORMAL, 0, 1);
            BitmapGlyph glyph_bmp = (BitmapGlyph)Marshal.PtrToStructure(glyph, typeof(BitmapGlyph));
            int size = (glyph_bmp.bitmap.width * glyph_bmp.bitmap.rows);
            if (size <= 0)
            {
                // space is a special `blank` character
                // 空格需要特殊处理
                extent_x[c] = 0;
                if (c == 32)
                {
                    GL.NewList((uint)(list_base + c), GL.GL_COMPILE);
                    GL.Translatef(font_size >> 1, 0, 0);
                    extent_x[c] = font_size >> 1;
                    GL.EndList();
                }
                return;

            }

            byte[] bmp = new byte[size];
            Marshal.Copy(glyph_bmp.bitmap.buffer, bmp, 0, bmp.Length);

            // Next we expand the bitmap into an opengl texture
            // 把glyph_bmp.bitmap的长宽扩展成2的指数倍
            int width = next_po2(glyph_bmp.bitmap.width);
            int height = next_po2(glyph_bmp.bitmap.rows);
            byte[] expanded = new byte[2 * width * height];
            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    expanded[2 * (i + j * width)] = expanded[2 * (i + j * width) + 1] =
                        (i >= glyph_bmp.bitmap.width || j >= glyph_bmp.bitmap.rows) ?
                        (byte)0 : bmp[i + glyph_bmp.bitmap.width * j];
                }
            }

            // Set up some texture parameters for opengl
            // 指定OpenGL的纹理参数
            GL.BindTexture(GL.GL_TEXTURE_2D, textures[c]);
            GL.TexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MAG_FILTER, (int)GL.GL_LINEAR);
            GL.TexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MIN_FILTER, (int)GL.GL_LINEAR);

            // Create the texture
            // 创建纹理
            GL.TexImage2D(GL.GL_TEXTURE_2D, 0, GL.GL_RGBA, width, height,
                0, GL.GL_LUMINANCE_ALPHA, GL.GL_UNSIGNED_BYTE, expanded);
            expanded = null;
            bmp = null;

            // Create a display list and bind a texture to it
            // 创建显示列表，绑定纹理
            GL.NewList((uint)(list_base + c), GL.GL_COMPILE);
            GL.BindTexture(GL.GL_TEXTURE_2D, textures[c]);

            // Account for freetype spacing rules
            // 矩阵平移
            GL.Translatef(glyph_bmp.left, 0, 0);
            GL.PushMatrix();
            GL.Translatef(0, glyph_bmp.top - glyph_bmp.bitmap.rows, 0);
            float x = (float)glyph_bmp.bitmap.width / (float)width;
            float y = (float)glyph_bmp.bitmap.rows / (float)height;

            // Draw the quad
            // 用Quad+纹理绘制字符
            GL.Begin(GL.GL_QUADS);
            GL.TexCoord2d(0, 0); GL.Vertex2f(0, glyph_bmp.bitmap.rows);
            GL.TexCoord2d(0, y); GL.Vertex2f(0, 0);
            GL.TexCoord2d(x, y); GL.Vertex2f(glyph_bmp.bitmap.width, 0);
            GL.TexCoord2d(x, 0); GL.Vertex2f(glyph_bmp.bitmap.width, glyph_bmp.bitmap.rows);
            GL.End();
            GL.PopMatrix();

            // Advance for the next character			
            // 准备绘制下一个字符
            GL.Translatef(glyph_bmp.bitmap.width, 0, 0);
            extent_x[c] = glyph_bmp.left + glyph_bmp.bitmap.width;
            GL.EndList();

        }

        internal int next_po2(int a)
        {
            int rval = 1;
            while (rval < a) rval <<= 1;
            return rval;
        }

        internal void push_scm()
        {
            GL.PushAttrib(GL.GL_TRANSFORM_BIT);
            int[] viewport = new int[4];
            GL.GetIntegerv(GL.GL_VIEWPORT, viewport);
            GL.MatrixMode(GL.GL_PROJECTION);
            GL.PushMatrix();
            GL.LoadIdentity();
            GL.Ortho(viewport[0], viewport[2], viewport[1], viewport[3], 0, 1);
            GL.PopAttrib();
            viewport = null;
        }

        internal void pop_pm()
        {
            GL.PushAttrib(GL.GL_TRANSFORM_BIT);
            GL.MatrixMode(GL.GL_PROJECTION);
            GL.PopMatrix();
            GL.PopAttrib();
        }

        public int extent(string what)
        {
            int ret = 0;
            for (int c = 0; c < what.Length; c++)
                ret += extent_x[what[c]];
            return ret;
        }

        public void print(float x, float y, string what)
        {

            uint font = list_base;

            //Prepare openGL for rendering the font characters
            push_scm();
            GL.PushAttrib(GL.GL_LIST_BIT | GL.GL_CURRENT_BIT | GL.GL_ENABLE_BIT | GL.GL_TRANSFORM_BIT);
            GL.MatrixMode(GL.GL_MODELVIEW);
            GL.Disable(GL.GL_LIGHTING);
            GL.Enable(GL.GL_TEXTURE_2D);
            GL.Disable(GL.GL_DEPTH_TEST);
            GL.Enable(GL.GL_BLEND);
            GL.BlendFunc(GL.GL_SRC_ALPHA, GL.GL_ONE_MINUS_SRC_ALPHA);
            GL.ListBase(font);
            float[] modelview_matrix = new float[16];
            GL.GetFloatv(GL.GL_MODELVIEW_MATRIX, modelview_matrix);
            GL.PushMatrix();
            GL.LoadIdentity();
            GL.Translatef(x, y, 0);
            GL.MultMatrixf(modelview_matrix);

            //Render
            byte[] textbytes = new byte[what.Length];
            for (int i = 0; i < what.Length; i++)
                textbytes[i] = (byte)what[i];
            GL.CallLists(what.Length, GL.GL_UNSIGNED_BYTE, textbytes);
            textbytes = null;

            //Restore openGL state
            GL.PopMatrix();
            GL.PopAttrib();
            pop_pm();

        }


        #region IDisposable Members

        /// <summary>
        /// Internal variable which checks if Dispose has already been called
        /// </summary>
        private Boolean disposed;

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        private void Dispose(Boolean disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                //TODO: Managed cleanup code here, while managed refs still valid
            }
            //TODO: Unmanaged cleanup code here
            GL.DeleteLists(list_base, 128);
            GL.DeleteTextures(128, textures);
            textures = null;
            extent_x = null;

            disposed = true;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            // Call the private Dispose(bool) helper and indicate 
            // that we are explicitly disposing
            this.Dispose(true);

            // Tell the garbage collector that the object doesn't require any
            // cleanup when collected since Dispose was called explicitly.
            GC.SuppressFinalize(this);
        }

        #endregion

    }

}