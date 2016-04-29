using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    /// <summary>
    /// 北斗七星
    /// <para>使用<see cref="ZeroIndexBuffer"/></para>
    /// </summary>
    public class BigDipper : IBufferable
    {

        public const string position = "position";
        public const string color = "color";
        Dictionary<string, PropertyBufferPtr> propertyBufferPtrDict = new Dictionary<string, PropertyBufferPtr>();

        public PropertyBufferPtr GetProperty(string bufferName, string varNameInShader)
        {
            if (bufferName == position)
            {
                if (!propertyBufferPtrDict.ContainsKey(bufferName))
                {
                    using (var buffer = new PropertyBuffer<vec3>(
                        varNameInShader, 3, GL.GL_FLOAT, BufferUsage.StaticDraw))
                    {
                        buffer.Alloc(BigDipperModel.positions.Length);
                        unsafe
                        {
                            var array = (vec3*)buffer.FirstElement();
                            for (int i = 0; i < BigDipperModel.positions.Length; i++)
                            {
                                array[i] = BigDipperModel.positions[i];
                            }
                        }

                        propertyBufferPtrDict.Add(bufferName, buffer.GetBufferPtr() as PropertyBufferPtr);
                    }
                }
                return propertyBufferPtrDict[bufferName];
            }
            else if (bufferName == color)
            {
                if (!propertyBufferPtrDict.ContainsKey(bufferName))
                {
                    using (var buffer = new PropertyBuffer<vec3>(
                        varNameInShader, 3, GL.GL_FLOAT, BufferUsage.StaticDraw))
                    {
                        buffer.Alloc(BigDipperModel.colors.Length);
                        unsafe
                        {
                            var array = (vec3*)buffer.FirstElement();
                            for (int i = 0; i < BigDipperModel.colors.Length; i++)
                            {
                                array[i] = BigDipperModel.colors[i];
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
                using (var buffer = new ZeroIndexBuffer(
                    DrawMode.LineStrip, 0, BigDipperModel.positions.Length))
                {
                    indexBufferPtr = buffer.GetBufferPtr() as IndexBufferPtr;
                }
            }

            return indexBufferPtr;
        }

        private IndexBufferPtr indexBufferPtr = null;
    }
}
