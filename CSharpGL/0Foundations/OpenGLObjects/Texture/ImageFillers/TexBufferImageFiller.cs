using System;

namespace CSharpGL
{
    /// <summary>
    /// fill texture's content with a buffer.
    /// </summary>
    public class TexBufferImageFiller : ImageFiller, IDisposable
    {
        private uint internalformat;
        private BufferPtr bufferPtr;
        private bool autoDispose;

        /// <summary>
        ///
        /// </summary>
        /// <param name="internalformat"></param>
        /// <param name="bufferPtr"></param>
        /// <param name="autoDispose">Dispose <paramref name="bufferPtr"/> when this filler is disposed.</param>
        public TexBufferImageFiller(uint internalformat, BufferPtr bufferPtr, bool autoDispose)
        {
            this.internalformat = internalformat;
            this.bufferPtr = bufferPtr;
            this.autoDispose = autoDispose;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="target"></param>
        public override void Fill(BindTextureTarget target)
        {
            OpenGL.GetDelegateFor<OpenGL.glTexBuffer>()(OpenGL.GL_TEXTURE_BUFFER, internalformat, bufferPtr.BufferId);
        }

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
        ~TexBufferImageFiller()
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
                } // end if

                // Dispose unmanaged resources.
                if (this.autoDispose)
                {
                    var disp = this.bufferPtr as IDisposable;
                    if (disp != null) { disp.Dispose(); }
                }
            } // end if

            this.disposedValue = true;
        } // end sub
    }
}