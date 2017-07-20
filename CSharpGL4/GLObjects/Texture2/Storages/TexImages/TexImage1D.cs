using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL.Texture2
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class TexImage1D : TexStorageBase
    {
        private int level;
        private uint internalFormat;
        private int width;
        private int border;
        private uint format;
        private uint type;
        private TexImageDataProvider dataProvider;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="level"></param>
        /// <param name="internalformat"></param>
        /// <param name="width"></param>
        /// <param name="border"></param>
        /// <param name="format"></param>
        /// <param name="type"></param>
        /// <param name="dataProvider"></param>
        public TexImage1D(int level, uint internalformat, int width, int border, uint format, uint type, TexImageDataProvider dataProvider)
        {
            this.level = level; this.internalFormat = internalformat;
            this.width = width; this.border = border;
            this.format = format;
            this.type = type;
            this.dataProvider = dataProvider;
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Apply()
        {
            IntPtr pixels = dataProvider.GetData();
            GL.Instance.TexImage1D(GL.GL_TEXTURE_1D, level, internalFormat, width, border, format, type, pixels);
        }
    }
}
