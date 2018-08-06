using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Set up texture's content with 'glTexImage3D()'.
    /// </summary>
    public class TexImage3D : TexStorageBase
    {
        internal static readonly GLDelegates.void_uint_int_uint_int_int_int_int_uint_uint_IntPtr glTexImage3D;
        static TexImage3D()
        {
            glTexImage3D = GL.Instance.GetDelegateFor("glTexImage3D", GLDelegates.typeof_void_uint_int_uint_int_int_int_int_uint_uint_IntPtr) as GLDelegates.void_uint_int_uint_int_int_int_int_uint_uint_IntPtr;
        }

        private int width;
        private int height;
        private int depth;
        private uint format;
        private uint type;
        private TexImageDataProvider<LeveledData> dataProvider;

        /// <summary>
        /// Set up texture's content with 'glTexImage3D()'.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="internalFormat"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="depth"></param>
        /// <param name="format"></param>
        /// <param name="type"></param>
        /// <param name="dataProvider"></param>
        /// <param name="mipmapLevelCount"></param>
        /// <param name="border"></param>
        public TexImage3D(Target target, uint internalFormat, int width, int height, int depth, uint format, uint type, LeveledDataProvider dataProvider = null, int mipmapLevelCount = 1, bool border = false)
            : base((TextureTarget)target, internalFormat, mipmapLevelCount, border)
        {
            this.width = width; this.height = height; this.depth = depth;
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

                glTexImage3D((uint)target, level, internalFormat, width, height, depth, border ? 1 : 0, format, type, pixels);

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
            Texture2DArray = GL.GL_TEXTURE_2D_ARRAY,

            /// <summary>
            /// 
            /// </summary>
            Texture3D = GL.GL_TEXTURE_3D,
        }
    }
}
