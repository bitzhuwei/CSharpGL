using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public partial class Texture
    {

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
        ~Texture()
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
                {
                    OpenGL.DeleteTextures(this.id.Length, this.id);
                    this.id[0] = 0;
                }
                {
                    var disp = this.ImageFiller as IDisposable;
                    if (disp != null) { disp.Dispose(); }
                }
                // A sampler builder can be used in multiple textures.
                // Thus we shouldn't dispose it here.
                //{
                //    var disp = this.SamplerBuilder as IDisposable;
                //    if (disp != null) { disp.Dispose(); }
                //}
            } // end if

            this.disposedValue = true;
        } // end sub

        #endregion

    }
}
