using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Demos
{
    class SunshineParticleModel : IBufferable
    {
        public static readonly float[] attractor_masses = new float[maxAttractor];

        public const int particleGroupSize = 128;
        public const int particleGroupCount = 8000;
        public const int particleCount = (particleGroupSize * particleGroupCount);
        public const int maxAttractor = 64;

        public const string strPosition = "position";
        private PropertyBufferPtr positionBufferPtr = null;
        private IndexBufferPtr indexBufferPtr;
        Random random = new Random();

        static SunshineParticleModel()
        {
            Random random = new Random();
            for (int i = 0; i < maxAttractor; i++)
            {
                attractor_masses[i] = 0.5f + (float)random.NextDouble() * 0.5f;
            }
        }

        const double minRadius = 1.0;
        const double maxRadius = 1.2;

        public PropertyBufferPtr GetProperty(string bufferName, string varNameInShader)
        {
            if (bufferName == strPosition)
            {
                if (positionBufferPtr == null)
                {
                    using (var buffer = new PropertyBuffer<vec4>(
                        varNameInShader, 4, OpenGL.GL_FLOAT, BufferUsage.DynamicCopy))
                    {
                        buffer.Alloc(particleCount);
                        unsafe
                        {
                            var array = (vec4*)buffer.Header.ToPointer();
                            for (int i = 0; i < particleCount; i++)
                            {
                                array[i] = new vec4(
                                    (float)(
                                    (random.NextDouble() - 0.5) * 2 
                                        * ((random.NextDouble() * (maxRadius - minRadius) + minRadius))
                                    ),
                                   (float)(
                                    (random.NextDouble() - 0.5) * 2
                                        * ((random.NextDouble() * (maxRadius - minRadius) + minRadius))
                                    ),
                                   (float)(
                                    (random.NextDouble() - 0.5) * 2
                                        * ((random.NextDouble() * (maxRadius - minRadius) + minRadius))
                                    ),
                                   (float)(random.NextDouble())
                                    );
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
            if (indexBufferPtr == null)
            {
                using (var buffer = new ZeroIndexBuffer(DrawMode.Points, 0, particleCount))
                {
                    indexBufferPtr = buffer.GetBufferPtr() as IndexBufferPtr;
                }
            }

            return indexBufferPtr;
        }
    }
}