using System;

namespace CSharpGL
{
    /// <summary>
    /// fill texture's content with a buffer.
    /// </summary>
    public class TexBufferImageFiller : ImageFiller, IDisposable
    {
        private uint internalformat;
        private GLBuffer buffer;
        private bool autoDispose;

        /// <summary>
        ///
        /// </summary>
        /// <param name="internalformat"></param>
        /// <param name="buffer"></param>
        /// <param name="autoDispose">Dispose <paramref name="buffer"/> when this filler is disposed.</param>
        public TexBufferImageFiller(uint internalformat, GLBuffer buffer, bool autoDispose)
        {
            this.internalformat = internalformat;
            this.buffer = buffer;
            this.autoDispose = autoDispose;
        }

        /// <summary>
        ///
        /// </summary>
        public override void Fill()
        {
            var function = GL.Instance.GetDelegateFor("glTexBuffer", GLDelegates.typeof_void_uint_uint_uint) as GLDelegates.void_uint_uint_uint;
            function(GL.GL_TEXTURE_BUFFER, internalformat, buffer.BufferId);
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
                    var disp = this.buffer as IDisposable;
                    if (disp != null) { disp.Dispose(); }
                }
            } // end if

            this.disposedValue = true;
        } // end sub
    }
}