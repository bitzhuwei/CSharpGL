using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Objects.VertexBuffers
{
    /// <summary>
    /// 为给定VBO执行渲染时所需的操作。
    /// </summary>
    public abstract class BufferRenderer : IDisposable
    {
        private bool disposedValue = false;

        /// <summary>
        /// 用GL.GenBuffers()得到的VBO的ID。
        /// </summary>
        public uint BufferID { get; private set; }

        /// <summary>
        /// 为给定VBO执行渲染时所需的操作。
        /// </summary>
        /// <param name="bufferID">用GL.GenBuffers()得到的VBO的ID。</param>
        public BufferRenderer(uint bufferID)
        {
            this.BufferID = bufferID;
        }

        /// <summary>
        /// 执行此VBO的渲染操作。
        /// </summary>
        /// <param name="e"></param>
        /// <param name="shaderProgram">此VBO使用的shader program。</param>
        public abstract void Render(RenderEventArgs e, Shaders.ShaderProgram shaderProgram);

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~BufferRenderer()
        {
            this.Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {

            if (this.disposedValue == false)
            {
                if (disposing)
                {
                    // Dispose managed resources.

                }

                // Dispose unmanaged resources.
                GL.DeleteBuffers(1, new uint[] { this.BufferID });
            }

            this.disposedValue = true;
        }
    }
}
