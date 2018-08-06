using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Set up texture's content with 'glTexImage2D()'.
    /// </summary>
    public class TexImage2D : TexStorageBase
    {
        private int width;
        private int height;
        private uint format;
        private uint type;
        private TexImageDataProvider<LeveledData> dataProvider;

        /// <summary>
        /// Set up texture's content with 'glTexImage2D()'.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="internalFormat"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="format"></param>
        /// <param name="type"></param>
        /// <param name="dataProvider"></param>
        /// <param name="mipmapLevelCount"></param>
        /// <param name="border"></param>
        public TexImage2D(Target target, uint internalFormat, int width, int height, uint format, uint type, LeveledDataProvider dataProvider = null, int mipmapLevelCount = 1, bool border = false)
            : base((TextureTarget)target, internalFormat, mipmapLevelCount, border)
        {
            this.width = width; this.height = height;
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

                GL.Instance.TexImage2D((uint)target, level, internalFormat, width, height, border ? 1 : 0, format, type, pixels);

                item.FreeData();
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

            /// <summary>
            /// GL_TEXTURE_RECTANGLE不支持mipmap, uv范围不是[0,1],而是[0,w]和[0,h]
            /// </summary>
            TextureRectangle = GL.GL_TEXTURE_RECTANGLE,
        }
    }
}
