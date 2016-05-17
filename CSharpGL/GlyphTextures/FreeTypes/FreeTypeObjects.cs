using System;
using System.Runtime.InteropServices;

namespace CSharpGL.GlyphTextures.FreeTypes
{
    /// <summary>
    /// FreeType对象的基类型。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    abstract class FreeTypeObjectBase<T> : IDisposable where T : class
    {
        /// <summary>
        /// 指针
        /// </summary>
        public IntPtr pointer;

        /// <summary>
        /// 对象
        /// </summary>
        public T obj;

        public override string ToString()
        {
            return string.Format("{0}: [{1}]", this.pointer, this.obj);
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
            ReleaseResource();
            this.pointer = IntPtr.Zero;
            this.obj = null;

            disposed = true;
        }

        /// <summary>
        /// Unmanaged cleanup code here
        /// </summary>
        protected abstract void ReleaseResource();

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

    /// <summary>
    /// FreeType库
    /// </summary>
    class FreeTypeLibrary : FreeTypeObjectBase<FT_Library>
    {
        /// <summary>
        /// 初始化FreeType库
        /// </summary>
        public FreeTypeLibrary()
        {
            int ret = FreeTypeAPI.FT_Init_FreeType(out this.pointer);
            if (ret != 0) { throw new Exception("Could not init freetype library!"); }

            this.obj = (FT_Library)Marshal.PtrToStructure(this.pointer, typeof(FT_Library));
        }

        protected override void ReleaseResource()
        {
            IntPtr ptr = this.pointer;
            if (ptr != IntPtr.Zero)
            {
                FreeTypeAPI.FT_Done_FreeType(ptr);
                this.pointer = IntPtr.Zero;
            }
        }

    }

    /// <summary>
    /// 初始化字体库
    /// </summary>
    class FreeTypeFace : FreeTypeObjectBase<FT_Face>
    {

        /// <summary>
        /// 初始化字体库
        /// </summary>
        /// <param name="library"></param>
        /// <param name="fontFullname"></param>
        /// <param name="size"></param>
        public FreeTypeFace(FreeTypeLibrary library, string fontFullname)//, int size)
        {
            int ret = FreeTypeAPI.FT_New_Face(library.pointer, fontFullname, 0, out pointer);
            if (ret != 0) { throw new Exception("Could not open font"); }

            this.obj = (FT_Face)Marshal.PtrToStructure(pointer, typeof(FT_Face));

        }

        /// <summary>
        /// Unmanaged cleanup code here
        /// </summary>
        protected override void ReleaseResource()
        {
            IntPtr ptr = this.pointer;
            if (ptr != IntPtr.Zero)
            {
                FreeTypeAPI.FT_Done_Face(this.pointer);
                this.pointer = IntPtr.Zero;
            }
        }

    }

    /// <summary>
    /// 把字形转换为纹理
    /// </summary>
    class FreeTypeBitmapGlyph : FreeTypeObjectBase<FT_BitmapGlyph>
    {
        /// <summary>
        /// char
        /// </summary>
        public char glyphChar;
        public FT_GlyphRec glyphRec;

        /// <summary>
        /// 把字形转换为纹理
        /// </summary>
        /// <param name="face"></param>
        /// <param name="c"></param>
        public FreeTypeBitmapGlyph(FreeTypeFace face, char c, int size)
        {
            // Freetype measures the font size in 1/64th of pixels for accuracy
            // so we need to request characters in size*64
            // 设置字符大小？
            FreeTypeAPI.FT_Set_Char_Size(face.pointer, size << 6, size << 6, 96, 96);

            // Provide a reasonably accurate estimate for expected pixel sizes
            // when we later on create the bitmaps for the font
            // 设置像素大小？
            FreeTypeAPI.FT_Set_Pixel_Sizes(face.pointer, size, size);

            // We first convert the number index to a character index
            // 根据字符获取其编号
            //int index = FreeTypeAPI.FT_Get_Char_Index(face.pointer, Convert.ToChar(c));
            int index = FreeTypeAPI.FT_Get_Char_Index(face.pointer, c);

            // Here we load the actual glyph for the character
            // 加载此字符的字形
            {
                int ret = FreeTypeAPI.FT_Load_Glyph(face.pointer, index, FT_LOAD_TYPES.FT_LOAD_DEFAULT);
                if (ret != 0) { throw new Exception(string.Format("Could not load character '{0}'", Convert.ToChar(c))); }
            }
            {
                int ret = FreeTypeAPI.FT_Get_Glyph(face.obj.glyphrec, out this.pointer);
                if (ret != 0) return;
                this.glyphRec = (FT_GlyphRec)Marshal.PtrToStructure(face.obj.glyphrec, typeof(FT_GlyphRec));
            }

            FreeTypeAPI.FT_Glyph_To_Bitmap(out this.pointer, FT_RENDER_MODES.FT_RENDER_MODE_NORMAL, 0, 1);
            this.obj = (FT_BitmapGlyph)Marshal.PtrToStructure(this.pointer, typeof(FT_BitmapGlyph));
        }

        protected override void ReleaseResource()
        {
            //throw new NotImplementedException();
        }
    }

}
