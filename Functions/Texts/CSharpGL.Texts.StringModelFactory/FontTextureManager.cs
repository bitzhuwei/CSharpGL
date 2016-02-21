using CSharpGL.Objects.Textures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Texts.StringModelFactory
{
    public sealed class FontTextureManager : IDisposable
    {

        private static readonly FontTextureManager instance = new FontTextureManager();

        public static FontTextureManager Instance { get { return instance; } }

        private FontTextureManager() { }

        Dictionary<Bitmap, sampler2D> dict = new Dictionary<Bitmap, sampler2D>();

        public sampler2D GetTexture2D(Bitmap bitmap)
        {
            sampler2D result;
            if (!this.dict.TryGetValue(bitmap, out result))
            {
                result = new sampler2D();
                result.Initialize(bitmap);
                this.dict.Add(bitmap, result);
            }

            return result;
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
        ~FontTextureManager()
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
        protected void Dispose(bool disposing)
        {

            if (this.disposedValue == false)
            {
                if (disposing)
                {
                    // TODO: Dispose managed resources.
                } // end if

                var list = this.dict.Values;
                this.dict.Clear();
                foreach (var item in list)
                {
                    item.Dispose();
                }

            } // end if

            this.disposedValue = true;
        } // end sub

    }
}
