using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL.Texture2
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class TexImage3D : TexStorageBase
    {
        private static readonly GLDelegates.void_uint_int_int_int_int_int_int_uint_uint_IntPtr glTexImage3D;
        static TexImage3D()
        {
            glTexImage3D = GL.Instance.GetDelegateFor("glTexImage3D", GLDelegates.typeof_void_uint_int_int_int_int_int_int_uint_uint_IntPtr) as GLDelegates.void_uint_int_int_int_int_int_int_uint_uint_IntPtr;
        }

        private Target target;
        private int level;
        private int internalFormat;
        private int width;
        private int height;
        private int depth;
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
        /// <param name="depth"></param>
        /// <param name="border"></param>
        /// <param name="format"></param>
        /// <param name="type"></param>
        /// <param name="dataProvider"></param>
        public TexImage3D(Target target, int level, int internalformat, int width, int height, int depth, int border, uint format, uint type, TexImageDataProvider dataProvider = null)
        {
            this.target = target;
            this.level = level; this.internalFormat = internalformat;
            this.width = width; this.height = height; this.depth = depth;
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

            glTexImage3D((uint)target, level, internalFormat, width, height, depth, border, format, type, pixels);

            dataProvider.FreeData();
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
