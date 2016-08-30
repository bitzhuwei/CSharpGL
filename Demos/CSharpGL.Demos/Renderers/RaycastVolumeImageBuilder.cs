using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;


namespace CSharpGL.Demos
{
    /// <summary>
    /// 3D texture builder of Raycast Volume Rendering Demo.
    /// </summary>
    class RaycastVolumeImageBuilder : ImageBuilder
    {
        private string filename;
        private int width;
        private int height;
        private int depth;

        /// <summary>
        /// 3D texture builder of Raycast Volume Rendering Demo.
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="depth"></param>
        public RaycastVolumeImageBuilder(string filename, int width, int height, int depth)
        {
            this.filename = filename;
            this.width = width;
            this.height = height;
            this.depth = depth;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        public override void Build(BindTextureTarget target)
        {
            var data = new UnmanagedArray<byte>(width * height * depth);
            unsafe
            {
                int index = 0;
                int readCount = 0;
                byte* array = (byte*)data.Header.ToPointer();
                using (var fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
                using (var br = new BinaryReader(fs))
                {
                    int unReadCount = (int)fs.Length;
                    const int cacheSize = 1024 * 1024;
                    do
                    {
                        int min = Math.Min(cacheSize, unReadCount);
                        var cache = new byte[min];
                        readCount = br.Read(cache, 0, min);
                        if (readCount != min)
                        { throw new Exception(); }

                        for (int i = 0; i < readCount; i++)
                        {
                            array[index++] = cache[i];
                        }
                        unReadCount -= readCount;
                    } while (readCount > 0);
                }
            }

            OpenGL.PixelStorei(OpenGL.GL_UNPACK_ALIGNMENT, 1);
            OpenGL.TexImage3D(OpenGL.GL_TEXTURE_3D, 0, (int)OpenGL.GL_INTENSITY,
                width, height, depth, 0,
                OpenGL.GL_LUMINANCE, OpenGL.GL_UNSIGNED_BYTE, data.Header);
            data.Dispose();
        }
    }
}
