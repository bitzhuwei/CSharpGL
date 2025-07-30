using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Runtime.InteropServices;

namespace CSharpGL {
    /// <summary>
    /// Render something using 'glMultiDrawElements'.
    /// </summary>
    [Browsable(true)]

    public unsafe class MultiDrawElementsBaseVertexCmd : IDrawCommand, IDisposable {
        /// <summary>
        /// 用哪种方式渲染各个顶点？（GL.GL_TRIANGLES etc.）
        /// </summary>
        public DrawMode Mode { get; set; }

        public readonly int[] count;
        public readonly Array allIndices;
        public readonly GCHandle pinAll;
        public readonly IntPtr[] indices;
        public readonly GCHandle pinIndices;
        public readonly IntPtr headerIndices;
        public readonly IndexBuffer.ElementType type;
        public readonly int[] baseVertex;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="count"></param>
        /// <param name="allIndices"></param>
        /// <param name="baseVertex"></param>
        public MultiDrawElementsBaseVertexCmd(DrawMode mode, int[] count, uint[] allIndices, int[] baseVertex)
            : this(mode, count, (Array)allIndices, baseVertex) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="count"></param>
        /// <param name="allIndices"></param>
        /// <param name="baseVertex"></param>
        public MultiDrawElementsBaseVertexCmd(DrawMode mode, int[] count, ushort[] allIndices, int[] baseVertex)
            : this(mode, count, (Array)allIndices, baseVertex) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="count"></param>
        /// <param name="allIndices"></param>
        /// <param name="baseVertex"></param>
        public MultiDrawElementsBaseVertexCmd(DrawMode mode, int[] count, byte[] allIndices, int[] baseVertex)
            : this(mode, count, (Array)allIndices, baseVertex) { }

        private MultiDrawElementsBaseVertexCmd(DrawMode mode, int[] count, Array allIndices, int[] baseVertex) {
            if (count == null || allIndices == null || baseVertex == null) { throw new System.ArgumentNullException(); }

            this.Mode = mode;
            this.count = count;
            this.type = IndexBuffer.ElementType.UByte;
            this.baseVertex = baseVertex;
            {
                this.allIndices = allIndices;
                GCHandle pinAll = GCHandle.Alloc(this.allIndices, GCHandleType.Pinned);
                var indices = new IntPtr[count.Length];
                int current = 0;
                for (int i = 0; i < indices.Length; i++) {
                    indices[i] = Marshal.UnsafeAddrOfPinnedArrayElement(allIndices, current);
                    current += count[i];
                }
                GCHandle pinIndices = GCHandle.Alloc(indices, GCHandleType.Pinned);
                IntPtr header = pinIndices.AddrOfPinnedObject();

                this.pinAll = pinAll;
                this.indices = indices;
                this.pinIndices = pinIndices;
                this.headerIndices = header;
            }
        }

        public void Draw() {
            var gl = GL.current; if (gl == null) { return; }
            gl.glMultiDrawElementsBaseVertex((GLenum)this.Mode, this.count, (GLenum)this.type, this.headerIndices, this.count.Length, this.baseVertex);
        }

        #region IDisposable

        private bool disposedValue;
        protected virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                if (disposing) {
                    // TODO: 释放托管状态(托管对象)
                }

                // TODO: 释放未托管的资源(未托管的对象)并重写终结器
                this.pinAll.Free();
                this.pinIndices.Free();
                // TODO: 将大型字段设置为 null
                disposedValue = true;
            }
        }

        // // TODO: 仅当“Dispose(bool disposing)”拥有用于释放未托管资源的代码时才替代终结器
        // ~MultiDrawElementsBaseVertexCmd()
        // {
        //     // 不要更改此代码。请将清理代码放入“Dispose(bool disposing)”方法中
        //     Dispose(disposing: false);
        // }

        public void Dispose() {
            // 不要更改此代码。请将清理代码放入“Dispose(bool disposing)”方法中
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable

        ///// <summary>
        ///// void glMultiDrawElementsBaseVertex(uint mode​, int[] count​, uint type​, uint[][] indices​, int drawcount​, int[] basevertex​);
        ///// </summary>
        ////private static readonly GLDelegates.void_uint_intN_uint_IntPtr_int_intN glMultiDrawElementsBaseVertex;
        //static MultiDrawElementsBaseVertexCmd()
        //{
        //    glMultiDrawElementsBaseVertex = gl.glGetDelegateFor("glMultiDrawElementsBaseVertex", GLDelegates.typeof_void_uint_intN_uint_IntPtr_int_intN) as GLDelegates.void_uint_intN_uint_IntPtr_int_intN;
        //}

    }
}
