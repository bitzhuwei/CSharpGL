using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public class TexImage3D : TexStorageBase
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
        private TexImageDataProvider<LeveledData> dataProvider;

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
        public TexImage3D(Target target, int level, int internalformat, int width, int height, int depth, int border, uint format, uint type, LeveledDataProvider dataProvider = null)
        {
            this.target = target;
            this.level = level; this.internalFormat = internalformat;
            this.width = width; this.height = height; this.depth = depth;
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

                glTexImage3D((uint)target, level, internalFormat, width, height, depth, border, format, type, pixels);

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
