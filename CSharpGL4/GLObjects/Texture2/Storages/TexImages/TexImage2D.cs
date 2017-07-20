using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL.Texture2
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class TexImage2D : TexStorageBase
    {
        private Target target;
        private int level;
        private int internalFormat;
        private int width;
        private int height;
        private int border;
        private uint format;
        private uint type;
        private TexImageDataProvider dataProvider;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <param name="level"></param>
        /// <param name="internalformat"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="border"></param>
        /// <param name="format"></param>
        /// <param name="type"></param>
        /// <param name="dataProvider"></param>
        public TexImage2D(Target target, int level, int internalformat, int width, int height, int border, uint format, uint type, TexImageDataProvider dataProvider = null)
        {
            this.target = target;
            this.level = level; this.internalFormat = internalformat;
            this.width = width; this.height = height;
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

            GL.Instance.TexImage2D((uint)target, level, internalFormat, width, height, border, format, type, pixels);

            if (pixels != IntPtr.Zero)
            {
                dataProvider.FreeData();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public enum Target : uint
        {
            /// <summary>
            /// 
            /// </summary>
            Texture1DArray = GL.GL_TEXTURE_1D_ARRAY,

            /// <summary>
            /// 
            /// </summary>
            Texture2D = GL.GL_TEXTURE_2D,
        }
    }
}
