using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Design;

namespace CSharpGL
{
    public partial class TransformFeedbackObject
    {
        private bool disposedValue = false;

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
        ~TransformFeedbackObject()
        {
            this.Dispose(false);
        }

        private void Dispose(bool disposing)
        {
            if (this.disposedValue == false)
            {
                if (disposing)
                {
                    // Dispose managed resources.
                }

                // Dispose unmanaged resources.
                IntPtr context = GL.Instance.GetCurrentContext();
                if (context != IntPtr.Zero)
                {
                    glDeleteTransformFeedbacks(1, this.ids);
                }

                this.ids[0] = 0;
            }

            this.disposedValue = true;
        }
    }
}
