using System;
using System.Runtime.InteropServices;

namespace CSharpGL
{
    public abstract partial class UnmanagedArrayBase
    {
        #region IDisposable Members

        /// <summary>
        /// How many <see cref="UnmanagedArrayBase"/> allocated?
        /// <para>Only used for debugging.</para>
        /// </summary>
        public static int allocatedCount = 0;

        /// <summary>
        /// How many <see cref="UnmanagedArrayBase"/> released?
        /// <para>Only used for debugging.</para>
        /// </summary>
        public static int disposedCount = 0;

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
        ~UnmanagedArrayBase()
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
                    //DisposeManagedResources();
                } // end if

                // Dispose unmanaged resources.
                DisposeUnmanagedResources();

                UnmanagedArrayBase.disposedCount++;
            } // end if

            this.disposedValue = true;
        } // end sub

        /// <summary>
        /// Dispose unmanaged resources
        /// </summary>
        protected abstract void DisposeUnmanagedResources();

        #endregion IDisposable Members
    }
}