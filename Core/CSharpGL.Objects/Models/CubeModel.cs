using CSharpGL;
using CSharpGL.Objects.VertexBuffers;
using GLM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Objects.Models
{
    /// <summary>
    /// 一个立方体的模型。
    /// http://images.cnblogs.com/cnblogs_com/bitzhuwei/554293/o_bitzhuwei.cnblogs.com000000061.jpg
    /// http://images.cnblogs.com/cnblogs_com/bitzhuwei/554293/o_bitzhuwei.cnblogs.com000000062.jpg
    /// </summary>
    public class CubeModel : IModel
    {
        static vec3[] eightVertexes = new vec3[] 
        { 
            new vec3(-1, 1, 1), new vec3(1, 1, 1), new vec3(1, 1, -1), new vec3(-1, 1, -1),
            new vec3(-1, -1, 1), new vec3(1, -1, 1), new vec3(1, -1, -1), new vec3(-1, -1, -1), 
        };

        static readonly CubePosition identityPosition = new CubePosition()
        {
            faceX = new SqurePosition() { position0 = eightVertexes[1], position1 = eightVertexes[2], position2 = eightVertexes[6], position3 = eightVertexes[5], },
            faceNX = new SqurePosition() { position0 = eightVertexes[0], position1 = eightVertexes[3], position2 = eightVertexes[7], position3 = eightVertexes[4], },
            faceY = new SqurePosition() { position0 = eightVertexes[0], position1 = eightVertexes[1], position2 = eightVertexes[2], position3 = eightVertexes[3], },
            faceNY = new SqurePosition() { position0 = eightVertexes[4], position1 = eightVertexes[5], position2 = eightVertexes[6], position3 = eightVertexes[7], },
            faceZ = new SqurePosition() { position0 = eightVertexes[0], position1 = eightVertexes[1], position2 = eightVertexes[5], position3 = eightVertexes[4], },
            faceNZ = new SqurePosition() { position0 = eightVertexes[3], position1 = eightVertexes[2], position2 = eightVertexes[6], position3 = eightVertexes[7], },
        };

        static readonly CubeNormal identityNormal = new CubeNormal()
        {
            faceX = new SqureNormal(new vec3(1, 0, 0)),
            faceNX = new SqureNormal(new vec3(-1, 0, 0)),
            faceY = new SqureNormal(new vec3(0, 1, 0)),
            faceNY = new SqureNormal(new vec3(0, -1, 0)),
            faceZ = new SqureNormal(new vec3(0, 0, 1)),
            faceNZ = new SqureNormal(new vec3(0, 0, -1)),
        };

        static readonly CubeColor identityColor = new CubeColor()
        {
            faceX = new SqureColor(new vec3(0, 0, 1)),
            faceNX = new SqureColor(new vec3(0, 1, 0)),
            faceY = new SqureColor(new vec3(0, 1, 1)),
            faceNY = new SqureColor(new vec3(1, 0, 0)),
            faceZ = new SqureColor(new vec3(1, 0, 1)),
            faceNZ = new SqureColor(new vec3(1, 1, 0)),
        };

        static readonly uint[] identityIndex =
            new uint[] { 0, 1, 2, 0, 2, 3, 4, 5, 6, 4, 6, 7, 8, 9, 10, 8, 10, 11, 12, 13, 14, 12, 14, 15, 16, 17, 18, 16, 18, 19, 20, 21, 22, 20, 22, 23 };

        static CubeColor GetRandomColor()
        {
            Random random = new Random();
            CubeColor result = new CubeColor();
            result.faceX = new SqureColor(new vec3((float)random.NextDouble(), (float)random.NextDouble(), (float)random.NextDouble()));
            result.faceNX = new SqureColor(new vec3((float)random.NextDouble(), (float)random.NextDouble(), (float)random.NextDouble()));
            result.faceY = new SqureColor(new vec3((float)random.NextDouble(), (float)random.NextDouble(), (float)random.NextDouble()));
            result.faceNY = new SqureColor(new vec3((float)random.NextDouble(), (float)random.NextDouble(), (float)random.NextDouble()));
            result.faceZ = new SqureColor(new vec3((float)random.NextDouble(), (float)random.NextDouble(), (float)random.NextDouble()));
            result.faceNZ = new SqureColor(new vec3((float)random.NextDouble(), (float)random.NextDouble(), (float)random.NextDouble()));

            return result;
        }

        CubePosition position;
        CubeNormal normal;
        CubeColor color;
        uint[] index;

        public static IModel GetModel(float radius)
        {
            return new CubeModel(radius);
        }

        private CubeModel(float radius)
        {
            this.position = identityPosition;
            this.position.faceX.position0 *= radius;
            this.position.faceX.position1 *= radius;
            this.position.faceX.position2 *= radius;
            this.position.faceX.position3 *= radius;
            this.position.faceNX.position0 *= radius;
            this.position.faceNX.position1 *= radius;
            this.position.faceNX.position2 *= radius;
            this.position.faceNX.position3 *= radius;
            this.position.faceY.position0 *= radius;
            this.position.faceY.position1 *= radius;
            this.position.faceY.position2 *= radius;
            this.position.faceY.position3 *= radius;
            this.position.faceNY.position0 *= radius;
            this.position.faceNY.position1 *= radius;
            this.position.faceNY.position2 *= radius;
            this.position.faceNY.position3 *= radius;
            this.position.faceZ.position0 *= radius;
            this.position.faceZ.position1 *= radius;
            this.position.faceZ.position2 *= radius;
            this.position.faceZ.position3 *= radius;
            this.position.faceNZ.position0 *= radius;
            this.position.faceNZ.position1 *= radius;
            this.position.faceNZ.position2 *= radius;
            this.position.faceNZ.position3 *= radius;
            this.color = identityColor;
            this.normal = identityNormal;
            this.index = identityIndex;
        }

        CSharpGL.Objects.VertexBuffers.BufferRenderer IModel.GetPositionBufferRenderer(string varNameInShader)
        {
            using (var positionBuffer = new CubePositionBuffer(varNameInShader))
            {
                positionBuffer.Alloc(1);
                unsafe
                {
                    CubePosition* positionArray = (CubePosition*)positionBuffer.FirstElement();
                    positionArray[0] = this.position;
                }

                return positionBuffer.GetRenderer();
            }

        }

        CSharpGL.Objects.VertexBuffers.BufferRenderer IModel.GetColorBufferRenderer(string varNameInShader)
        {
            using (var colorBuffer = new CubeColorBuffer(varNameInShader))
            {
                colorBuffer.Alloc(1);
                unsafe
                {
                    CubeColor* colorArray = (CubeColor*)colorBuffer.FirstElement();
                    colorArray[0] = this.color;
                    //colorArray[0] = CubeModel.GetRandomColor();
                }

                return colorBuffer.GetRenderer();
            }

        }

        CSharpGL.Objects.VertexBuffers.BufferRenderer IModel.GetNormalBufferRenderer(string varNameInShader)
        {
            using (var normalBuffer = new CubeNormalBuffer(varNameInShader))
            {
                normalBuffer.Alloc(1);
                unsafe
                {
                    CubeNormal* normalArray = (CubeNormal*)normalBuffer.FirstElement();
                    normalArray[0] = this.normal;
                }

                return normalBuffer.GetRenderer();
            }

        }

        CSharpGL.Objects.VertexBuffers.BufferRenderer IModel.GetIndexes()
        {
            //using (var indexBuffer = new ZeroIndexBuffer(DrawMode.Quads, 0, 4 * 6))
            //{
            //    //indexBuffer.Alloc(0);

            //    return indexBuffer.GetRenderer() as ZeroIndexBufferRenderer;
            //}
            using (var buffer = new IndexBuffer<uint>(DrawMode.Triangles, IndexElementType.UnsignedInt, BufferUsage.StaticDraw))
            {
                buffer.Alloc(this.index.Length);
                unsafe
                {
                    uint* array = (uint*)buffer.FirstElement();
                    for (int i = 0; i < this.index.Length; i++)
                    {
                        array[i] = this.index[i];
                    }
                }

                return buffer.GetRenderer();
            }
        }

        class CubePositionBuffer : PropertyBuffer<CubePosition>
        {
            public CubePositionBuffer(string varNameInShader)
                : base(varNameInShader, 3, GL.GL_FLOAT, BufferUsage.StaticDraw)
            {

            }
        }

        class CubeColorBuffer : PropertyBuffer<CubeColor>
        {
            public CubeColorBuffer(string varNameInShader)
                : base(varNameInShader, 3, GL.GL_FLOAT, BufferUsage.StaticDraw)
            {

            }
        }

        class CubeNormalBuffer : PropertyBuffer<CubeNormal>
        {
            public CubeNormalBuffer(string varNameInShader)
                : base(varNameInShader, 3, GL.GL_FLOAT, BufferUsage.StaticDraw)
            {

            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct CubeColor
        {
            public SqureColor faceX;
            public SqureColor faceNX;
            public SqureColor faceY;
            public SqureColor faceNY;
            public SqureColor faceZ;
            public SqureColor faceNZ;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SqureColor
        {
            public vec3 color0;
            public vec3 color1;
            public vec3 color2;
            public vec3 color3;

            public SqureColor(vec3 color)
            {
                this.color0 = color;
                this.color1 = color;
                this.color2 = color;
                this.color3 = color;
            }

            public override string ToString()
            {
                return string.Format("color: {0}", color0);
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct CubePosition
        {
            public SqurePosition faceX;
            public SqurePosition faceNX;
            public SqurePosition faceY;
            public SqurePosition faceNY;
            public SqurePosition faceZ;
            public SqurePosition faceNZ;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SqurePosition
        {
            public vec3 position0;
            public vec3 position1;
            public vec3 position2;
            public vec3 position3;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct CubeNormal
        {
            public SqureNormal faceX;
            public SqureNormal faceNX;
            public SqureNormal faceY;
            public SqureNormal faceNY;
            public SqureNormal faceZ;
            public SqureNormal faceNZ;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SqureNormal
        {
            public vec3 normal0;
            public vec3 normal1;
            public vec3 normal2;
            public vec3 normal3;

            public SqureNormal(vec3 normal)
            {
                this.normal0 = normal;
                this.normal1 = normal;
                this.normal2 = normal;
                this.normal3 = normal;
            }

            public override string ToString()
            {
                return string.Format("normal: {0}", normal0);
            }
        }
    }
}