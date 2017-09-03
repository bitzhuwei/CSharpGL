using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Set up texture's content with 'glTexImage1D()'.
    /// </summary>
    public class TexImage1D : TexStorageBase
    {
        private int level;
        private uint internalFormat;
        private int width;
        private int border;
        private uint format;
        private uint type;
        private TexImageDataProvider<LeveledData> dataProvider;

        /// <summary>
        /// Set up texture's content with 'glTexImage1D()'.
        /// </summary>
        /// <param name="level"></param>
        /// <param name="internalformat"></param>
        /// <param name="width"></param>
        /// <param name="border"></param>
        /// <param name="format"></param>
        /// <param name="type"></param>
        /// <param name="dataProvider"></param>
        public TexImage1D(int level, uint internalformat, int width, int border, uint format, uint type, LeveledDataProvider dataProvider = null)
        {
            this.level = level; this.internalFormat = internalformat;
            this.width = width;
            this.border = border;
            this.format = format;
            this.type = type;
            if (dataProvider == null)
            {
                this.dataProvider = new LeveledDataProvider();
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
            foreach (var item in dataProvider)
            {
                int level = item.level;
                IntPtr pixels = item.LockData();

                GL.Instance.TexImage1D(GL.GL_TEXTURE_1D, level, internalFormat, width, border, format, type, pixels);

                item.FreeData();
            }
        }
    }
}
