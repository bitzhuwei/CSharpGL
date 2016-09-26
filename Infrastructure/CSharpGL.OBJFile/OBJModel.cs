using System;

namespace CSharpGL.OBJFile
{
    /// <summary>
    /// An model loaded from *.obj file.
    /// </summary>
    public partial class OBJModel : IBufferable
    {
        /// <summary>
        /// All vertexes(position, texture coordinate and normal) in this *.obj file.
        /// </summary>
        public OBJVertex[] Vertexes { get; private set; }

        /// <summary>
        /// All triangles in this *.obj file.
        /// </summary>
        public Triangle[] Triangles { get; private set; }

        public const string strPosition = "Position";
        public const string strTexCoord = "TexCoord";
        public const string strNormal = "Normal";
        private VertexAttributeBufferPtr positionBufferPtr;
        private VertexAttributeBufferPtr texCoordBufferPtr;
        private VertexAttributeBufferPtr normalBufferPtr;
        private IndexBufferPtr indexBufferPtr;

        public VertexAttributeBufferPtr GetVertexAttributeBufferPtr(string bufferName, string varNameInShader)
        {
            if (bufferName == strPosition)
            {
                if (this.positionBufferPtr == null)
                {
                    using (var buffer = new VertexAttributeBuffer<vec3>(varNameInShader, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw))
                    {
                        buffer.Create(this.Vertexes.Length);
                        unsafe
                        {
                            var array = (vec3*)buffer.Header.ToPointer();
                            for (int i = 0; i < this.Vertexes.Length; i++)
                            {
                                array[i] = this.Vertexes[i].Position;
                            }
                        }
                        this.positionBufferPtr = buffer.GetBufferPtr();
                    }
                }
                return this.positionBufferPtr;
            }
            else if (bufferName == strTexCoord)
            {
                if (this.texCoordBufferPtr == null)
                {
                    using (var buffer = new VertexAttributeBuffer<vec2>(varNameInShader, VertexAttributeConfig.Vec2, BufferUsage.StaticDraw))
                    {
                        buffer.Create(this.Vertexes.Length);
                        unsafe
                        {
                            var array = (vec2*)buffer.Header.ToPointer();
                            for (int i = 0; i < this.Vertexes.Length; i++)
                            {
                                array[i] = this.Vertexes[i].TexCoord;
                            }
                        }
                        this.texCoordBufferPtr = buffer.GetBufferPtr();
                    }
                }
                return this.texCoordBufferPtr;
            }
            else if (bufferName == strNormal)
            {
                if (this.normalBufferPtr == null)
                {
                    using (var buffer = new VertexAttributeBuffer<vec3>(varNameInShader, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw))
                    {
                        buffer.Create(this.Vertexes.Length);
                        unsafe
                        {
                            var array = (vec3*)buffer.Header.ToPointer();
                            for (int i = 0; i < this.Vertexes.Length; i++)
                            {
                                array[i] = this.Vertexes[i].Normal;
                            }
                        }
                        this.normalBufferPtr = buffer.GetBufferPtr();
                    }
                }
                return this.normalBufferPtr;
            }
            else
            {
                throw new Exception(string.Format("No vertex attribte for [{0}]!", bufferName));
            }
        }

        public IndexBufferPtr GetIndexBufferPtr()
        {
            if (this.indexBufferPtr == null)
            {
                using (var buffer = new OneIndexBuffer(IndexElementType.UInt, DrawMode.Triangles, BufferUsage.StaticDraw))
                {
                    buffer.Create(this.Triangles.Length * 3);
                    unsafe
                    {
                        var array = (uint*)buffer.Header.ToPointer();
                        for (int i = 0; i < this.Triangles.Length; i++)
                        {
                            array[i * 3 + 0] = this.Triangles[i].VertexIndex0;
                            array[i * 3 + 1] = this.Triangles[i].VertexIndex1;
                            array[i * 3 + 2] = this.Triangles[i].VertexIndex2;
                        }
                    }
                    this.indexBufferPtr = buffer.GetBufferPtr();
                }
            }
            return this.indexBufferPtr;
        }

        public bool UsesZeroIndexBuffer()
        {
            return false;
        }
    }

    public class OBJVertex
    {
        public vec3 Position { get; set; }
        public vec2 TexCoord { get; set; }
        public vec3 Normal { get; set; }

        public OBJVertex(vec3 position, vec2 texCoord, vec3 normal)
        {
            this.Position = position;
            this.TexCoord = texCoord;
            this.Normal = normal;
        }

        public override string ToString()
        {
            return string.Format("v:[{0}] vt:[{1}] vn:[{2}]", this.Position, this.TexCoord, this.Normal);
        }
    }

    public class Triangle
    {
        public uint VertexIndex0 { get; set; }
        public uint VertexIndex1 { get; set; }
        public uint VertexIndex2 { get; set; }

        public Triangle(uint vertexIndex0, uint vertexIndex1, uint vertexIndex2)
        {
            this.VertexIndex0 = vertexIndex0;
            this.VertexIndex1 = vertexIndex1;
            this.VertexIndex2 = vertexIndex2;
        }

        public override string ToString()
        {
            return string.Format("Triangle Indexes:[{0}, {1}, {2}]", this.VertexIndex0, this.VertexIndex1, this.VertexIndex2);
        }
    }
}