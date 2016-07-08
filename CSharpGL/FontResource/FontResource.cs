using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Xml.Linq;

namespace CSharpGL
{
    /// <summary>
    /// 字形贴图及其UV。
    /// </summary>
    public sealed partial class FontResource : IDisposable
    {

        /// <summary>
        /// 
        /// </summary>
        public samplerValue GetSamplerValue()
        {
            return new samplerValue(
                BindTextureTarget.Texture2D,
                this.FontTextureId,
                OpenGL.GL_TEXTURE0);
        }

        //public const string strTTFTexture = "TTFTexture";
        //public const string strFontResource = "FontResource";
        //public const string strFontHeight = "FontHeight";
        //public const string strFirstChar = "FirstChar";
        //public const string strLastChar = "LastChar";

        /// <summary>
        /// 字形高度
        /// </summary>
        public int FontHeight { get; set; }

        ///// <summary>
        ///// 第一个字符
        ///// </summary>
        //public char FirstChar { get; set; }

        ///// <summary>
        ///// 最后一个字符
        ///// </summary>
        //public char LastChar { get; set; }

        ///// <summary>
        ///// 含有各个字形的贴图。
        ///// </summary>
        //private System.Drawing.Bitmap FontBitmap;
        /// <summary>
        /// 
        /// </summary>
        public Size TextureSize { get; set; }

        /// <summary>
        /// 含有各个字形的贴图的Id。
        /// </summary>
        public uint FontTextureId { get; set; }

        /// <summary>
        /// 记录每个字符在<see cref="FontResource"/>里的偏移量及其字形的宽高。
        /// </summary>
        public FullDictionary<char, GlyphInfo> CharInfoDict { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        ~FontResource()
        {
            this.Dispose();
        }

        #region IDisposable Members

        /// <summary>
        /// Internal variable which checks if Dispose has already been called
        /// </summary>
        Boolean disposed;

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        void Dispose(Boolean disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                //Managed cleanup code here, while managed refs still valid
            }
            //Unmanaged cleanup code here
            var ids = new uint[] { FontTextureId, };
            OpenGL.DeleteTextures(ids.Length, ids);

            IntPtr renderContext = Win32.wglGetCurrentContext();
            if (renderContext != IntPtr.Zero)
            {
                dict.Remove(renderContext);
            }

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
