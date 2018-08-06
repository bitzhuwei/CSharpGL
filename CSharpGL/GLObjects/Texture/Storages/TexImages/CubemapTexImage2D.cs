using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public class CubemapTexImage2D : TexStorageBase
    {
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
            : base(TextureTarget.TextureCubeMap, internalFormat, mipmapLevelCount, border)
        {
            if (dataProvider == null) { throw new ArgumentNullException("dataProvider"); }

            this.width = width; this.height = height;
            this.format = format;
            this.type = type;
            this.dataProvider = dataProvider;
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Apply()
        {
            foreach (var item in dataProvider)
            {
                uint target = (uint)item.target;
                IntPtr pixels = item.LockData();

                GL.Instance.TexImage2D(target, 0, internalFormat, width, height, border ? 1 : 0, format, type, pixels);

                item.FreeData();
            }
        }

    }
}
