using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public class TexImage1D : TexStorageBase
    {
        private int level;
        private int internalFormat;
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
        public TexImage1D(int level, int internalformat, int width, int border, uint format, uint type, TexImageDataProvider dataProvider = null)
        {
            this.level = level; this.internalFormat = internalformat;
            this.width = width;
            this.border = border;
            this.format = format;
            this.type = type;
            if (dataProvider == null)
            {
                this.dataProvider = new TexImageDataProvider();
            }
            else
            {
                this.dataProvider = dataProvider;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Apply()
        {
            IntPtr pixels = dataProvider.LockData();

            GL.Instance.TexImage1D(GL.GL_TEXTURE_1D, level, internalFormat, width, border, format, type, pixels);

            if (pixels != IntPtr.Zero)
            {
                dataProvider.FreeData();
            }
        }
    }
}
