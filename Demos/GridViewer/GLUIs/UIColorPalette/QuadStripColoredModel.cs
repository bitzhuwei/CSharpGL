using CSharpGL;
using System;
using System.Drawing;

namespace GridViewer
{
    /// <summary>
    ///  /|\ y
    ///   |
    ///   |
    ///   |
    ///   ---------------&gt; x
    /// (0, 0)
    /// 0    2    4    6    8    10
    /// --------------------------
    /// |    |    |    |    |    |
    /// |    |    |    |    |    |
    /// |    |    |    |    |    |
    /// |    |    |    |    |    |
    /// |    |    |    |    |    |
    /// |    |    |    |    |    |
    /// |    |    |    |    |    |
    /// --------------------------
    /// 1    3    5    7    9    11
    /// side length is 1.
    /// </summary>
    internal class QuadStripColoredModel : IBufferable
    {
        /// <summary>
        ///
        /// </summary>
        public const string position = "position";

        /// <summary>
        ///
        /// </summary>
        public const string color = "color";

        private PropertyBufferPtr positionBufferPtr;
        private PropertyBufferPtr colorBufferPtr;

        public QuadStripColoredModel(int quadCount, Bitmap bitmap)
        {
            this.quadCount = quadCount;
            this.bitmap = bitmap;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="bufferName"></param>
        /// <param name="varNameInShader"></param>
        /// <returns></returns>
        public PropertyBufferPtr GetProperty(string bufferName, string varNameInShader)
        {
            if (bufferName == position)
            {
                if (positionBufferPtr == null)
                {
                    using (var buffer = new PropertyBuffer<vec3>(
                        varNameInShader, 3, OpenGL.GL_FLOAT, BufferUsage.StaticDraw))
                    {
                        buffer.Create((this.quadCount + 1) * 2);
                        unsafe
                        {
                            var array = (vec3*)buffer.Header.ToPointer();
                            for (int i = 0; i < (this.quadCount + 1); i++)
                            {
                                array[i * 2 + 0] = new vec3(-0.5f + (float)i / (float)(this.quadCount), 0.5f, 0);
                                array[i * 2 + 1] = new vec3(-0.5f + (float)i / (float)(this.quadCount), -0.5f, 0);
                            }
                        }

                        positionBufferPtr = buffer.GetBufferPtr() as PropertyBufferPtr;
                    }
                }
                return positionBufferPtr;
            }
            else if (bufferName == color)
            {
                if (colorBufferPtr == null)
                {
                    using (var buffer = new PropertyBuffer<vec3>(
                        varNameInShader, 3, OpenGL.GL_FLOAT, BufferUsage.StaticDraw))
                    {
                        buffer.Create((this.quadCount + 1) * 2);
                        unsafe
                        {
                            var array = (vec3*)buffer.Header.ToPointer();
                            for (int i = 0; i < (this.quadCount + 1); i++)
                            {
                                int x = this.bitmap.Width * i / this.quadCount;
                                if (x == this.bitmap.Width) { x = this.bitmap.Width - 1; }
                                vec3 value = this.bitmap.GetPixel(x, 0).ToVec3();
                                array[i * 2 + 0] = value;
                                array[i * 2 + 1] = value;
                            }
                        }

                        colorBufferPtr = buffer.GetBufferPtr() as PropertyBufferPtr;
                    }
                }
                return colorBufferPtr;
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public IndexBufferPtr GetIndex()
        {
            if (indexBufferPtr == null)
            {
                using (var buffer = new ZeroIndexBuffer(
                    DrawMode.QuadStrip, 0, (this.quadCount + 1) * 2))
                {
                    indexBufferPtr = buffer.GetBufferPtr() as IndexBufferPtr;
                }
            }

            return indexBufferPtr;
        }

        private IndexBufferPtr indexBufferPtr = null;
        internal int quadCount;
        private Bitmap bitmap;
    }
}