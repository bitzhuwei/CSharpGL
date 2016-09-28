using CSharpGL.OBJFile;
using System;

namespace CSharpGL.OBJFileViewer
{
    /// <summary>
    /// Transform one of the models in a *.obj file to vertex buffers.
    /// </summary>
    internal class OBJModelAdpater : IBufferable
    {
        private OBJModel model;

        public OBJModelAdpater(OBJModel model)
        {
            this.model = model;
        }

        public const string strin_Position = "in_Position";
        private VertexAttributeBufferPtr positionBufferPtr;

        public const string strin_uv = "in_uv";
        private VertexAttributeBufferPtr uvBufferPtr;

        public const string strin_Normal = "in_Normal";
        private VertexAttributeBufferPtr normalBufferPtr;

        private IndexBufferPtr indexBufferPtr;

        public VertexAttributeBufferPtr GetVertexAttributeBufferPtr(string bufferName, string varNameInShader)
        {
            if (bufferName == strin_Position)
            {
                if (this.positionBufferPtr == null)
                {
                    using (var buffer = new VertexAttributeBuffer<vec3>(varNameInShader, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw))
                    {
                        buffer.Create(model.positionList.Count);
                        unsafe
                        {
                            var array = (vec3*)buffer.Header.ToPointer();
                            for (int i = 0; i < model.positionList.Count; i++)
                            {
                                array[i] = model.positionList[i];
                            }
                        }
                        this.positionBufferPtr = buffer.GetBufferPtr();
                    }
                }

                return this.positionBufferPtr;
            }
            else if (bufferName == strin_Normal)
            {
                if (this.normalBufferPtr == null)
                {
                    using (var buffer = new VertexAttributeBuffer<vec3>(varNameInShader, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw))
                    {
                        buffer.Create(model.normalList.Count);
                        unsafe
                        {
                            var array = (vec3*)buffer.Header.ToPointer();
                            for (int i = 0; i < model.normalList.Count; i++)
                            {
                                array[i] = model.normalList[i];
                            }
                        }
                        this.normalBufferPtr = buffer.GetBufferPtr();
                    }
                }

                return this.normalBufferPtr;
            }
            else if (bufferName == strin_uv)
            {
                if (this.uvBufferPtr == null)
                {
                    using (var buffer = new VertexAttributeBuffer<vec2>(varNameInShader, VertexAttributeConfig.Vec2, BufferUsage.StaticDraw))
                    {
                        buffer.Create(model.uvList.Count);
                        unsafe
                        {
                            var array = (vec2*)buffer.Header.ToPointer();
                            for (int i = 0; i < model.uvList.Count; i++)
                            {
                                array[i] = model.uvList[i];
                            }
                        }
                        this.uvBufferPtr = buffer.GetBufferPtr();
                    }
                }

                return this.uvBufferPtr;
            }
            else
            {
                throw new Exception(string.Format("invalid buffer name [{0}].", bufferName));
            }
        }

        public IndexBufferPtr GetIndexBufferPtr()
        {
            if (this.indexBufferPtr == null)
            {
                using (var buffer = new OneIndexBuffer(IndexElementType.UInt, DrawMode.Triangles, BufferUsage.StaticDraw))
                {
                    buffer.Create(model.faceList.Count * 3);
                    unsafe
                    {
                        var array = (uint*)buffer.Header.ToPointer();
                        for (int i = 0; i < model.faceList.Count; i++)
                        {
                            array[i * 3 + 0] = (uint)(model.faceList[i].Item1 - 1);
                            array[i * 3 + 1] = (uint)(model.faceList[i].Item2 - 1);
                            array[i * 3 + 2] = (uint)(model.faceList[i].Item3 - 1);
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
}