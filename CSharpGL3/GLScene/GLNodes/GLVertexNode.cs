using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// map to 'in vec3 inPosition;' in vertex shader.
    /// </summary>
    public sealed class GLVertexNode : GLNode
    {
        private VertexBuffer vertexBuffer;
        private Array array;
        private int length;

        private static readonly Type type = typeof(GLVertexNode);
        private int byteLength;
        private VBOConfig config;
        private string varNameInVertexShader;
        private BufferUsage usage;
        private uint instancedDivisor;
        private int patchVertexes;
        internal override Type ThisTypeCache
        {
            get { return type; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="config"></param>
        /// <param name="varNameInVertexShader"></param>
        /// <param name="usage"></param>
        /// <param name="instancedDivisor"></param>
        /// <param name="patchVertexes"></param>
        /// <returns></returns>
        public static GLVertexNode Create<T>(T[] array, VBOConfig config, string varNameInVertexShader, BufferUsage usage, uint instancedDivisor = 0, int patchVertexes = 0)
        {
            var node = new GLVertexNode();
            node.array = array;
            node.length = array.Length;
            node.byteLength = array.Length * Marshal.SizeOf(typeof(T));
            node.config = config;
            node.varNameInVertexShader = varNameInVertexShader;
            node.usage = usage;
            node.instancedDivisor = instancedDivisor;
            node.patchVertexes = patchVertexes;

            return node;
        }

        private GLVertexNode() { }

        internal VertexBuffer GetVertexAttributeBuffer()
        {
            if (this.vertexBuffer == null)
            {
                GCHandle pinned = GCHandle.Alloc(this.array, GCHandleType.Pinned);
                IntPtr header = Marshal.UnsafeAddrOfPinnedArrayElement(array, 0);
                this.vertexBuffer = Data2Buffer.GenVertexBuffer(header, length, byteLength, config, varNameInVertexShader, usage, instancedDivisor, patchVertexes);
                pinned.Free();
            }

            return this.vertexBuffer;
        }
    }
}
