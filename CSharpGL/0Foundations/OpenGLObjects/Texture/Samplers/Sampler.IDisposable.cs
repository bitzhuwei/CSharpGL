using System;

namespace CSharpGL
{
    public partial class Sampler
    {
        private static OpenGL.glDeleteSamplers glDeleteSamplers;

        #region IDisposable Members

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
        ~Sampler()
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
        protected virtual void Dispose(bool disposing)
        {
            if (this.disposedValue == false)
            {
                if (disposing)
                {
                    // Dispose managed resources.
                } // end if

                // Dispose unmanaged resources.
                IntPtr ptr = Win32.wglGetCurrentContext();
                if (ptr != IntPtr.Zero)
                {
                    if (glDeleteSamplers == null)
                    { glDeleteSamplers = OpenGL.GetDelegateFor<OpenGL.glDeleteSamplers>(); }
                    glDeleteSamplers(1, new uint[] { this.Id });
                    this.Id = 0;
                }
            } // end if

            this.disposedValue = true;
        } // end sub

        #endregion IDisposable Members
    }
}