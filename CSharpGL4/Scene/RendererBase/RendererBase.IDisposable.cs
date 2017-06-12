using System;

namespace CSharpGL
{
    public abstract partial class RendererBase
    {
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        } // end sub

        /// <summary>
        /// Destruct instance of the class.
        /// </summary>
        ~RendererBase()
        {
            this.Dispose(false);
        }

        /// <summary>
        /// Backing field to track whether Dispose has been called.
        /// </summary>
        private bool disposedValue = false;

        /// <summary>
        /// Dispose managed and unmanaged resources of this instance.
        /// </summary>
        /// <param name="disposing">If disposing equals true, managed and unmanaged resources can be disposed. If disposing equals false, only unmanaged resources can be disposed. </param>
        private void Dispose(bool disposing)
        {
            if (this.disposedValue == false)
            {
                if (disposing)
                {
                    // Dispose managed resources.
                    DisposeManagedResources();
                } // end if

                // Dispose unmanaged resources.
                DisposeUnmanagedResources();
            } // end if

            this.disposedValue = true;
        } // end sub

        /// <summary>
        /// 释放.net托管资源。
        /// <para>Dispose reources managed by .NET.</para>
        /// </summary>
        protected virtual void DisposeManagedResources() { }

        /// <summary>
        /// 释放.net非托管资源，例如释放OpenGL相关的资源（Buffer、纹理等）。
        /// <para>Dispose resources not managed by .NET(OpenGL buffers, textures, etc.).</para>
        /// </summary>
        protected virtual void DisposeUnmanagedResources() { }
    }
}