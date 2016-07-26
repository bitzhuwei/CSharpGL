using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public class sampler1D : IDisposable
    {
        private bool initialized;
        private uint[] id = new uint[1];

        /// <summary>
        /// 纹理名（用于标识一个纹理，由OpenGL指定），可在shader中用于指定uniform sampler2D纹理变量。
        /// </summary>
        public uint Id { get { return this.id[0]; } }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bitmap"></param>
        public void Initialize(System.Drawing.Bitmap bitmap)
        {
            if (!this.initialized)
            {
                DoInitialize(bitmap);

                this.initialized = true;
            }
        }

        private void DoInitialize(System.Drawing.Bitmap bitmap)
        {
            // generate texture.
            //  Lock the image bits (so that we can pass them to OGL).
            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            //OpenGL.ActiveTexture(OpenGL.GL_TEXTURE0);
            OpenGL.GetDelegateFor<OpenGL.glActiveTexture>()(OpenGL.GL_TEXTURE0);
            OpenGL.GenTextures(1, id);
            OpenGL.BindTexture(OpenGL.GL_TEXTURE_1D, id[0]);
            /* We require 1 byte alignment when uploading texture data */
            //OpenGL.PixelStorei(OpenGL.GL_UNPACK_ALIGNMENT, 1);
            /* Clamping to edges is important to prevent artifacts when scaling */
            OpenGL.TexParameteri(OpenGL.GL_TEXTURE_1D, OpenGL.GL_TEXTURE_WRAP_S, (int)OpenGL.GL_CLAMP_TO_EDGE);
            OpenGL.TexParameteri(OpenGL.GL_TEXTURE_1D, OpenGL.GL_TEXTURE_WRAP_T, (int)OpenGL.GL_CLAMP_TO_EDGE);
            /* Linear filtering usually looks best for text */
            OpenGL.TexParameteri(OpenGL.GL_TEXTURE_1D, OpenGL.GL_TEXTURE_MIN_FILTER, (int)OpenGL.GL_LINEAR);
            OpenGL.TexParameteri(OpenGL.GL_TEXTURE_1D, OpenGL.GL_TEXTURE_MAG_FILTER, (int)OpenGL.GL_LINEAR);
            OpenGL.TexImage1D(OpenGL.GL_TEXTURE_1D, 0, OpenGL.GL_RGBA,
                bitmap.Width, 0, OpenGL.GL_BGRA, OpenGL.GL_UNSIGNED_BYTE,
                bitmapData.Scan0);
            //  Unlock the image.
            bitmap.UnlockBits(bitmapData);
            OpenGL.BindTexture(OpenGL.GL_TEXTURE_1D, 0);
        }

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
        ~sampler1D()
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
                    // TODO: Dispose managed resources.
                } // end if

                // TODO: Dispose unmanaged resources.
                OpenGL.DeleteTextures(this.id.Length, this.id);
                this.id[0] = 0;

            } // end if

            this.disposedValue = true;
        } // end sub

        #endregion

        /// <summary>
        /// 
        /// </summary>
        public void Bind()
        {
            OpenGL.BindTexture(OpenGL.GL_TEXTURE_1D, this.id[0]);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Unbind()
        {
            OpenGL.BindTexture(OpenGL.GL_TEXTURE_1D, 0);
        }
    }
}
