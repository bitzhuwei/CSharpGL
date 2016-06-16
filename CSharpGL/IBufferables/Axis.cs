using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    /// <summary>
    /// 3D坐标系
    /// <para>使用<see cref="ZeroIndexBuffer"/></para>
    /// </summary>
    public class Axis : IBufferable
    {
        private AxisModel model;

        public Axis(uint partCount = 24, float radius = 1.0f)
        {
            this.model = new AxisModel(partCount, radius);
        }

        public const string strPosition = "position";
        public const string strColor = "color";
        Dictionary<string, PropertyBufferPtr> propertyBufferPtrDict = new Dictionary<string, PropertyBufferPtr>();

        public PropertyBufferPtr GetProperty(string bufferName, string varNameInShader)
        {
            if (bufferName == strPosition)
            {
                if (!propertyBufferPtrDict.ContainsKey(bufferName))
                {
                    using (var buffer = new PropertyBuffer<vec3>(
                        varNameInShader, 3, OpenGL.GL_FLOAT, BufferUsage.StaticDraw))
                    {
                        buffer.Alloc(this.model.positions.Length);
                        unsafe
                        {
                            var array = (vec3*)buffer.Header.ToPointer();
                            for (int i = 0; i < this.model.positions.Length; i++)
                            {
                                array[i] = this.model.positions[i];
                            }
                        }

                        propertyBufferPtrDict.Add(bufferName, buffer.GetBufferPtr() as PropertyBufferPtr);
                    }
                }
                return propertyBufferPtrDict[bufferName];
            }
            else if (bufferName == strColor)
            {
                if (!propertyBufferPtrDict.ContainsKey(bufferName))
                {
                    using (var buffer = new PropertyBuffer<vec3>(
                        varNameInShader, 3, OpenGL.GL_FLOAT, BufferUsage.StaticDraw))
                    {
                        buffer.Alloc(this.model.colors.Length);
                        unsafe
                        {
                            var array = (vec3*)buffer.Header.ToPointer();
                            for (int i = 0; i < this.model.colors.Length; i++)
                            {
                                array[i] = this.model.colors[i];
                            }
                        }

                        propertyBufferPtrDict.Add(bufferName, buffer.GetBufferPtr() as PropertyBufferPtr);
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
                using (var buffer = new OneIndexBuffer<uint>(
                     this.model.mode, BufferUsage.StaticDraw))
                {
                    buffer.Alloc(this.model.indexes.Length);
                    unsafe
                    {
                        var array = (uint*)buffer.Header.ToPointer();
                        for (int i = 0; i < this.model.indexes.Length; i++)
                        {
                            array[i] = this.model.indexes[i];
                        }
                    }
                    indexBufferPtr = buffer.GetBufferPtr() as IndexBufferPtr;
                }
            }

            return indexBufferPtr;
        }

        private IndexBufferPtr indexBufferPtr = null;
    }
}
