using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Setup texture's storage information with a <see cref="GLBuffer"/>.
    /// </summary>
    public class TexBufferStorage : TexStorageBase, IDisposable
    {
        private GLBuffer buffer;
        private bool autoDispose;

        internal static readonly GLDelegates.void_uint_uint_uint glTexBuffer;
        static TexBufferStorage()
        {
            glTexBuffer = GL.Instance.GetDelegateFor("glTexBuffer", GLDelegates.typeof_void_uint_uint_uint) as GLDelegates.void_uint_uint_uint;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="internalFormat"></param>
        /// <param name="buffer"></param>
        /// <param name="autoDispose">Dispose <paramref name="buffer"/> when this <see cref="TexBufferStorage"/> object is disposed?</param>
        public TexBufferStorage(uint internalFormat, GLBuffer buffer, bool autoDispose)
            : base(TextureTarget.TextureBuffer, internalFormat)
        {
            this.buffer = buffer;
            this.autoDispose = autoDispose;
        }

        public override void Apply()
        {
            glTexBuffer(GL.GL_TEXTURE_BUFFER, internalFormat, buffer.BufferId);
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
        ~TexBufferStorage()
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
