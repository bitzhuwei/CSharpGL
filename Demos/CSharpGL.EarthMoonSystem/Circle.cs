using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.EarthMoonSystem
{
    /// <summary>
    /// 天体（星球）
    /// </summary>
    class Circle : IBufferable
    {

        private CircleModel model;

        public Circle(float radius = 1.0f, int sliceParts = 360)
        {
            this.model = new CircleModel(radius, sliceParts);
        }

        public const string strPosition = "position";
        private PropertyBufferPtr positionBufferPtr;
        private IndexBufferPtr indexBufferPtr;

        public PropertyBufferPtr GetProperty(string bufferName, string varNameInShader)
        {
            if (bufferName == strPosition)
            {
                if (positionBufferPtr == null)
                {
                    using (var buffer = new PropertyBuffer<vec2>(varNameInShader, 2, OpenGL.GL_FLOAT, BufferUsage.StaticDraw))
                    {
                        buffer.Alloc(model.positions.Length);
                        unsafe
                        {
                            var array = (vec2*)buffer.Header.ToPointer();
                            for (int i = 0; i < model.positions.Length; i++)
                            {
                                array[i] = model.positions[i];
                            }
                        }
                        positionBufferPtr = buffer.GetBufferPtr() as PropertyBufferPtr;
                    }
                }
                return positionBufferPtr;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public IndexBufferPtr GetIndex()
        {
            if (this.indexBufferPtr == null)
            {
                using (var buffer = new ZeroIndexBuffer(DrawMode.TriangleFan, 0, this.model.positions.Length))
                {
                    this.indexBufferPtr = buffer.GetBufferPtr() as IndexBufferPtr;
                }

                return this.indexBufferPtr;
            }

            return indexBufferPtr;
        }
    }
}
