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
        public const string strVelocity = "velocity";
        private PropertyBufferPtr positionBufferPtr = null;
        private PropertyBufferPtr velocityBufferPtr = null;
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
                                    (float)(random.NextDouble() - 0.5) * 20,
                                    (float)(random.NextDouble() - 0.5) * 20,
                                    (float)(random.NextDouble() - 0.5) * 20,
                                    (float)(random.NextDouble())
                                    );
                            }
                        }

                        positionBufferPtr = buffer.GetBufferPtr() as PropertyBufferPtr;
                    }
                }

                return positionBufferPtr;
            }
            else if (bufferName == strVelocity)
            {
                if (velocityBufferPtr == null)
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
                                    (float)(random.NextDouble() - 0.5) * 0.2f,
                                    (float)(random.NextDouble() - 0.5) * 0.2f,
                                    (float)(random.NextDouble() - 0.5) * 0.2f,
                                    0
                                    );
                            }
                        }

                        velocityBufferPtr = buffer.GetBufferPtr() as PropertyBufferPtr;
                    }
                }

                return velocityBufferPtr;
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