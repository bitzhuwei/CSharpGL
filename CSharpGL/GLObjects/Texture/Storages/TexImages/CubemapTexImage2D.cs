using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL {
    /// <summary>
    /// 
    /// </summary>
    public unsafe class CubemapTexImage2D : TexStorageBase {
        private int width;
        private int height;
        private uint format;
        private uint type;
        private CubemapDataProvider dataProvider;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="internalFormat"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="format"></param>
        /// <param name="type"></param>
        /// <param name="dataProvider"></param>
        /// <param name="mipmapLevelCount"></param>
        /// <param name="border"></param>
        public CubemapTexImage2D(uint internalFormat, int width, int height, uint format, uint type, CubemapDataProvider dataProvider, int mipmapLevelCount = 1, bool border = false)
            : base(TextureTarget.TextureCubeMap, internalFormat, mipmapLevelCount, border) {
            if (dataProvider == null) { throw new ArgumentNullException("dataProvider"); }

            this.width = width; this.height = height;
            this.format = format;
            this.type = type;
            this.dataProvider = dataProvider;
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Apply() {
            var gl = GL.current; if (gl == null) { return; }
            foreach (var item in dataProvider) {
                //IntPtr pixels = item.LockData();
                IntPtr pixels;
                if (item.bitmap != null) {
                    pixels = item.bitmap.Scan0;
                }
                else { pixels = IntPtr.Zero; }
                gl.glTexImage2D((GLenum)item.target,
                    0, (GLint)internalFormat, width, height,
                    border ? 1 : 0, format, type, pixels);

                //item.FreeData();
            }
        }

    }
}
