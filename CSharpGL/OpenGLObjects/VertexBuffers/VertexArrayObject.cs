using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    /// <summary>
    /// 一个vertex array object。（即VAO）
    /// <para>VAO是用来管理VBO的。可以进一步减少DrawCall。</para>
    /// </summary>
    public sealed class VertexArrayObject : IDisposable
    {
        private VertexBufferPtr[] propertyBufferPtrs;
        private IndexBufferPtr indexBufferPtr;

        /// <summary>
        /// 此VAO的ID，由OpenGL给出。
        /// </summary>
        public uint ID { get; private set; }

        /// <summary>
        /// 一个vertex array object。（即VAO）
        /// <para>VAO是用来管理VBO的。可以进一步减少DrawCall。</para>
        /// </summary>
        /// <param name="propertyBufferPtrs">给出此VAO要管理的所有VBO。</param>
        public VertexArrayObject(IndexBufferPtr indexBufferPtr, params VertexBufferPtr[] propertyBufferPtrs)
        {
            if (indexBufferPtr == null)
            {
                throw new ArgumentNullException("indexBufferRenderer");
            }
            if (propertyBufferPtrs == null || propertyBufferPtrs.Length == 0)
            {
                throw new ArgumentNullException("propertyBuffers");
            }

            this.indexBufferPtr = indexBufferPtr;
            this.propertyBufferPtrs = propertyBufferPtrs;
        }

        /// <summary>
        /// 在OpenGL中创建VAO。
        /// 创建的过程就是执行一次渲染的过程。
        /// </summary>
        /// <param name="e"></param>
        /// <param name="shaderProgram"></param>
        public void Create(RenderEventArgs e, ShaderProgram shaderProgram)
        {
            if (this.ID != 0)
            { throw new Exception(string.Format("ID[{0}] is already generated!", this.ID)); }

            uint[] buffers = new uint[1];
            GL.GetDelegateFor<GL.glGenVertexArrays>()(1, buffers);

            this.ID = buffers[0];

            this.Bind();
            VertexBufferPtr[] propertyBufferPtrs = this.propertyBufferPtrs;
            if (propertyBufferPtrs != null)
            {
                foreach (var item in propertyBufferPtrs)
                {
                    item.Render(e, shaderProgram);
                }
            }
            this.Unbind();
        }

        private void Bind()
        {
            GL.GetDelegateFor<GL.glBindVertexArray>()(this.ID);
        }

        private void Unbind()
        {
            GL.GetDelegateFor<GL.glBindVertexArray>()(0);
        }

        /// <summary>
        /// 执行一次渲染的过程。
        /// </summary>
        /// <param name="e"></param>
        /// <param name="shaderProgram"></param>
        public void Render(RenderEventArgs e, ShaderProgram shaderProgram)
        {
            IndexBufferPtr indexBufferPtr = this.indexBufferPtr;
            if (indexBufferPtr != null)
            {
                this.Bind();
                indexBufferPtr.Render(e, shaderProgram);
                this.Unbind();
            }
        }

        public override string ToString()
        {
            return string.Format("VAO ID: {0}", this.ID);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~VertexArrayObject()
        {
            this.Dispose(false);
        }

        private bool disposedValue;

        private void Dispose(bool disposing)
        {
            if (this.disposedValue == false)
            {
                if (disposing)
                {
                    // Dispose managed resources.

                }

                // Dispose unmanaged resources.
                uint[] arrays = new uint[] { this.ID };
                this.ID = 0;
                IntPtr ptr = Win32.wglGetCurrentContext();
                if (ptr != IntPtr.Zero)
                {
                    GL.GetDelegateFor<GL.glDeleteVertexArrays>()(1, new uint[] { this.ID });
                }
                {
                    VertexBufferPtr[] propertyBufferPtrs = this.propertyBufferPtrs;
                    foreach (var item in propertyBufferPtrs)
                    {
                        item.Dispose();
                    }
                    this.propertyBufferPtrs = null;
                }
                {
                    IndexBufferPtr indexBufferPtr = this.indexBufferPtr;
                    indexBufferPtr.Dispose();
                    this.indexBufferPtr = null;
                }
            }

            this.disposedValue = true;
        }

    }
}
