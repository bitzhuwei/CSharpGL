using System;
using System.Runtime.InteropServices;

namespace CSharpGL {
    public static unsafe partial class Data2Buffer {
        /// <summary>
        /// 生成一个用于存储索引的IBO。索引指定了<see cref="VertexBuffer"/>里各个顶点的渲染顺序。
        /// Generates a Index Buffer Object storing vertexes' indexes, which indicate the rendering order of each vertex.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="type"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static IndexBuffer GenIndexBuffer(/*this UnmanagedArrayBase array*/IntPtr header, int byteLength, IndexBuffer.ElementType type, GLBuffer.Usage usage) {
            const GLenum target = GL.GL_ELEMENT_ARRAY_BUFFER;
            var bufferId = GLBuffer.CallGL(target, byteLength, header, usage);

            var buffer = new IndexBuffer(bufferId, type, byteLength);

            return buffer;
        }

    }
}
