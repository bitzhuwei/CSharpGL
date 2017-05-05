using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// glDrawElements*()
    /// </summary>
    public sealed class GLOneIndexNode : GLNode
    {
        private OneIndexBuffer buffer;
        private Array data;

        private static readonly Type type = typeof(GLOneIndexNode);
        internal override Type SelfTypeCache { get { return type; } }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="mode"></param>
        /// <param name="usage"></param>
        /// <param name="primCount"></param>
        /// <returns></returns>
        public static GLOneIndexNode Create<T>(T[] array, DrawMode mode, BufferUsage usage, int primCount = 1) where T : struct
        {
            var node = new GLOneIndexNode();

            if (typeof(T) == typeof(uint)) { node.ElementType = IndexBufferElementType.UInt; }
            else if (typeof(T) == typeof(ushort)) { node.ElementType = IndexBufferElementType.UShort; }
            else if (typeof(T) == typeof(byte)) { node.ElementType = IndexBufferElementType.UByte; }
            else { throw new ArgumentException(string.Format("Only uint/ushort/byte are allowed!")); }

            node.Mode = mode;
            node.Usage = usage;
            node.data = array;
            node.PrimCount = primCount;

            return node;
        }

        private GLOneIndexNode() { }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public OneIndexBuffer GetIndexBuffer()
        {
            if (this.buffer == null)
            {
                //this.buffer = OneIndexBuffer.Create(this.ElementType, this.Length, this.Mode, this.Usage);
                switch (this.ElementType)
                {
                    case IndexBufferElementType.UByte:
                        {
                            var array = this.data as byte[];
                            this.buffer = array.GenIndexBuffer(this.Mode, this.Usage, this.PrimCount);
                        }
                        break;
                    case IndexBufferElementType.UShort:
                        {
                            var array = this.data as ushort[];
                            this.buffer = array.GenIndexBuffer(this.Mode, this.Usage, this.PrimCount);
                        }
                        break;
                    case IndexBufferElementType.UInt:
                        {
                            var array = this.data as uint[];
                            this.buffer = array.GenIndexBuffer(this.Mode, this.Usage, this.PrimCount);
                        }
                        break;
                    default:
                        throw new Exception();
                }
            }

            return this.buffer;
        }

        /// <summary>
        /// 
        /// </summary>
        public DrawMode Mode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IndexBufferElementType ElementType { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public BufferUsage Usage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int PrimCount { get; set; }
    }
}
