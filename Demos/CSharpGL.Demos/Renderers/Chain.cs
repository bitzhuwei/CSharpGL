using System;
using System.Collections.Generic;

namespace CSharpGL
{
    /// <summary>
    /// 北斗七星
    /// <para>使用<see cref="ZeroIndexBuffer"/></para>
    /// </summary>
    internal class Chain : IBufferable
    {
        private ChainModel model;

        public Chain(ChainModel model)
        {
            this.model = model;
        }

        public const string position = "position";
        public const string color = "color";
        private Dictionary<string, VertexAttributeBufferPtr> propertyBufferPtrDict = new Dictionary<string, VertexAttributeBufferPtr>();

        public VertexAttributeBufferPtr GetProperty(string bufferName, string varNameInShader)
        {
            if (bufferName == position)
            {
                if (!propertyBufferPtrDict.ContainsKey(bufferName))
                {
                    using (var buffer = new VertexAttributeBuffer<vec3>(
                        varNameInShader, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw))
                    {
                        buffer.Create(model.Positions.Length);
                        unsafe
                        {
                            var array = (vec3*)buffer.Header.ToPointer();
                            for (int i = 0; i < model.Positions.Length; i++)
                            {
                                array[i] = model.Positions[i];
                            }
                        }

                        propertyBufferPtrDict.Add(bufferName, buffer.GetBufferPtr() as VertexAttributeBufferPtr);
                    }
                }
                return propertyBufferPtrDict[bufferName];
            }
            else if (bufferName == color)
            {
                if (!propertyBufferPtrDict.ContainsKey(bufferName))
                {
                    using (var buffer = new VertexAttributeBuffer<vec3>(
                        varNameInShader, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw))
                    {
                        buffer.Create(model.Colors.Length);
                        unsafe
                        {
                            var array = (vec3*)buffer.Header.ToPointer();
                            for (int i = 0; i < model.Colors.Length; i++)
                            {
                                array[i] = model.Colors[i];
                            }
                        }

                        propertyBufferPtrDict.Add(bufferName, buffer.GetBufferPtr() as VertexAttributeBufferPtr);
                    }
                }
                return propertyBufferPtrDict[bufferName];
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public IndexBufferPtr GetIndex()
        {
            if (indexBufferPtr == null)
            {
                using (var buffer = new ZeroIndexBuffer(
                    DrawMode.LineStrip, 0, this.model.Positions.Length))
                {
                    indexBufferPtr = buffer.GetBufferPtr() as IndexBufferPtr;
                }
            }

            return indexBufferPtr;
        }

        private IndexBufferPtr indexBufferPtr = null;
        /// <summary>
        /// Uses <see cref="ZeroIndexBuffer"/> or <see cref="OneIndexBuffer"/>.
        /// </summary>
        /// <returns></returns>
        public bool UsesZeroIndexBuffer() { return true; }

    }
}