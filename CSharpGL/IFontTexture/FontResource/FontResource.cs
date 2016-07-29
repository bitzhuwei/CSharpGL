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
    public sealed partial class FontResource : IFontTexture, IDisposable
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
        public float GlyphHeight { get; private set; }

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
        public Size TextureSize { get; private set; }

        /// <summary>
        /// 含有各个字形的贴图的Id。
        /// </summary>
        public uint FontTextureId { get; private set; }

        /// <summary>
        /// 记录每个字符在<see cref="FontResource"/>里的偏移量及其字形的宽高。
        /// </summary>
        public FullDictionary<char, GlyphInfo> GlyphInfoDictionary { get; private set; }

    }
}
