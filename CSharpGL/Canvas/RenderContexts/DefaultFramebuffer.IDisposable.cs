using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    partial class DefaultFramebuffer 
    {
        
        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 
        /// </summary>
        ~DefaultFramebuffer()
        {
            this.Dispose(false);
        }

        private bool disposedValue = false;

        private void Dispose(bool disposing)
        {
            if (this.disposedValue == false)
            {
                if (disposing)
                {
                    // Dispose managed resources.
                }

                // Dispose unmanaged resources.
                // Delete the render buffers.
                glDeleteRenderbuffersEXT(2, new uint[] { this.colorRenderBufferId[0], this.depthRenderBufferId[0] });
                // Delete the framebuffer.
                glDeleteFramebuffersEXT(1, this.framebufferId);
                // Reset the IDs.
                colorRenderBufferId[0] = 0;
                depthRenderBufferId[0] = 0;
                framebufferId[0] = 0;
            }

            this.disposedValue = true;
        }

    }
}
