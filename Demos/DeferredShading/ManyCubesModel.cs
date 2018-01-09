using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace DeferredShading
{
    class ManyCubesModel : IBufferSource
    {
        private readonly int blockSize;
        public ManyCubesModel(int lengthX, int lengthY, int lengthZ, int blockSize = 1024*4)
        {
            this.lengthX = lengthX;
            this.lengthY = lengthY;
            this.lengthZ = lengthZ;

            this.blockSize = blockSize;// (lengthX * lengthY * lengthZ) / 2;
        }

        public const string strPosition = "position";
        private VertexBuffer[] positionBuffers;

        public const string strColor = "color";
        private VertexBuffer[] colorBuffers;

        private IDrawCommand[] drawCmds;

        private int lengthX;
        private int lengthY;
        private int lengthZ;

        #region IBufferSource 成员

        public IEnumerable<VertexBuffer> GetVertexAttributeBuffer(string bufferName)
        {
            if (bufferName == strPosition)
            {
                if (this.positionBuffers == null)
                {
                    SingleCubePosition[] positions = GetPositions(lengthX, lengthY, lengthZ);
                    this.positionBuffers = positions.GenVertexBuffers(VBOConfig.Vec3, BufferUsage.StaticDraw, this.blockSize);
                }

                foreach (var item in this.positionBuffers)
                {
                    yield return item;
                }
            }
            else if (bufferName == strColor)
            {
                if (this.colorBuffers == null)
                {
                    SingleCubeColor[] colors = GetColors(lengthX, lengthY, lengthZ);
                    this.colorBuffers = colors.GenVertexBuffers(VBOConfig.Vec3, BufferUsage.StaticDraw, this.blockSize);
                }

                foreach (var item in this.colorBuffers)
                {
                    yield return item;
                }
            }
            else
            {
                throw new ArgumentException();
            }
        }

        private SingleCubeColor[] GetColors(int lengthX, int lengthY, int lengthZ)
        {
            var random = new Random();
            var result = new SingleCubeColor[lengthX * lengthY * lengthZ];
            uint index = 0;
            for (int x = 0; x < lengthX; x++)
            {
                for (int y = 0; y < lengthY; y++)
                {
                    for (int z = 0; z < lengthZ; z++)
                    {
                        result[index] = new SingleCubeColor(new vec3(
                            (float)random.NextDouble(),
                            (float)random.NextDouble(),
                            (float)random.NextDouble()
                            ));
                        index++;
                    }
                }
            }

            return result;
        }

        private SingleCubePosition[] GetPositions(int lengthX, int lengthY, int lengthZ)
        {
            var result = new SingleCubePosition[lengthX * lengthY * lengthZ];
            uint index = 0;
            for (int x = 0; x < lengthX; x++)
            {
                for (int y = 0; y < lengthY; y++)
                {
                    for (int z = 0; z < lengthZ; z++)
                    {
                        result[index] = new SingleCubePosition(new vec3(
                            x + 1 - (float)lengthX / 2.0f,
                            y + 1 - (float)lengthY / 2.0f,
                            z + 1 - (float)lengthZ / 2.0f
                            ));
                        index++;
                    }
                }
            }

            return result;
        }

        public IEnumerable<IDrawCommand> GetDrawCommand()
        {
            if (this.drawCmds == null)
            {
                SingleCubeIndex[] indexes = GetIndexes(lengthX, lengthY, lengthZ, this.blockSize);
                IndexBuffer[] buffers = indexes.GenIndexBuffers(IndexBufferElementType.UInt, BufferUsage.StaticDraw, this.blockSize);
                var cmds = new IDrawCommand[buffers.Length];
                for (int i = 0; i < buffers.Length; i++)
                {
                    cmds[i] = new DrawElementsCmd(buffers[i], DrawMode.QuadStrip);
                }
                this.drawCmds = cmds;
            }

            foreach (var item in this.drawCmds)
            {
                yield return item;
            }
        }

        private SingleCubeIndex[] GetIndexes(int lengthX, int lengthY, int lengthZ, int blockSize)
        {
            var result = new SingleCubeIndex[lengthX * lengthY * lengthZ];
            for (uint i = 0; i < result.Length; i++)
            {
                var index = (uint)(i % blockSize);
                result[i] = new SingleCubeIndex(index);
            }

            return result;
        }

        #endregion
    }

    struct SingleCubeIndex
    {
        public uint v0;
        public uint v1;
        public uint v2;
        public uint v3;
        public uint v4;
        public uint v5;
        public uint v6;
        public uint v7;
        public uint restart0;

        public uint v8;
        public uint v9;
        public uint v10;
        public uint v11;
        public uint v12;
        public uint v13;
        public uint v14;
        public uint v15;
        public uint restart1;

        public SingleCubeIndex(uint cubeIndex)
        {
            this.v0 = npp + cubeIndex * 8;
            this.v1 = nnp + cubeIndex * 8;
            this.v2 = ppp + cubeIndex * 8;
            this.v3 = pnp + cubeIndex * 8;
            this.v4 = ppn + cubeIndex * 8;
            this.v5 = pnn + cubeIndex * 8;
            this.v6 = npn + cubeIndex * 8;
            this.v7 = nnn + cubeIndex * 8;
            this.restart0 = uint.MaxValue;

            this.v8 = ppp + cubeIndex * 8;
            this.v9 = ppn + cubeIndex * 8;
            this.v10 = npp + cubeIndex * 8;
            this.v11 = npn + cubeIndex * 8;
            this.v12 = nnp + cubeIndex * 8;
            this.v13 = nnn + cubeIndex * 8;
            this.v14 = pnp + cubeIndex * 8;
            this.v15 = pnn + cubeIndex * 8;
            this.restart1 = uint.MaxValue;
        }

        private const uint nnn = 0;
        private const uint nnp = 1;
        private const uint npn = 2;
        private const uint npp = 3;
        private const uint pnn = 4;
        private const uint pnp = 5;
        private const uint ppn = 6;
        private const uint ppp = 7;
    }

    struct SingleCubeColor
    {
        public vec3 c0;
        public vec3 c1;
        public vec3 c2;
        public vec3 c3;
        public vec3 c4;
        public vec3 c5;
        public vec3 c6;
        public vec3 c7;

        public SingleCubeColor(vec3 color)
        {
            this.c0 = color;
            this.c1 = color;
            this.c2 = color;
            this.c3 = color;
            this.c4 = color;
            this.c5 = color;
            this.c6 = color;
            this.c7 = color;
        }
    }

    struct SingleCubePosition
    {
        public vec3 v0;
        public vec3 v1;
        public vec3 v2;
        public vec3 v3;
        public vec3 v4;
        public vec3 v5;
        public vec3 v6;
        public vec3 v7;

        public SingleCubePosition(vec3 center)
        {
            this.v0 = new vec3(-xLength, -yLength, -zLength) + center;
            this.v1 = new vec3(-xLength, -yLength, +zLength) + center;
            this.v2 = new vec3(-xLength, +yLength, -zLength) + center;
            this.v3 = new vec3(-xLength, +yLength, +zLength) + center;
            this.v4 = new vec3(+xLength, -yLength, -zLength) + center;
            this.v5 = new vec3(+xLength, -yLength, +zLength) + center;
            this.v6 = new vec3(+xLength, +yLength, -zLength) + center;
            this.v7 = new vec3(+xLength, +yLength, +zLength) + center;
        }

        private const float xLength = 0.5f;
        private const float yLength = 0.5f;
        private const float zLength = 0.5f;
    }
}
