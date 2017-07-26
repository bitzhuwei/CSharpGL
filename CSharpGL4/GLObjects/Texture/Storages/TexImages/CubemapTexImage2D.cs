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
        //private int level;
        private int internalFormat;
        private int width;
        private int height;
        private int border;
        private uint format;
        private uint type;
        private CubemapDataProvider dataProvider;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="internalformat"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="border"></param>
        /// <param name="format"></param>
        /// <param name="type"></param>
        /// <param name="dataProvider"></param>
        public CubemapTexImage2D(int internalformat, int width, int height, int border, uint format, uint type, CubemapDataProvider dataProvider)
        {
            if (dataProvider == null) { throw new ArgumentNullException("dataProvider"); }

            this.internalFormat = internalformat;
            this.width = width; this.height = height;
            this.border = border;
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

                GL.Instance.TexImage2D(target, 0, internalFormat, width, height, border, format, type, pixels);

                item.FreeData();
            }
        }

    }
}
