using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL.Objects.Demos
{
    /// <summary>
    /// 用于更新VBO
    /// </summary>
    public class MappingBuffer : IDisposable
    {
        private BufferTarget bufferTarget;
        private uint bufferObject;

        public MappingBuffer(BufferTarget bufferTarget, uint bufferObject, MapBufferAccess access)
        {
            // TODO: Complete member initialization
            this.bufferTarget = bufferTarget;
            this.bufferObject = bufferObject;

            GL.BindBuffer(bufferTarget, bufferObject);

            this.BufferPointer = GL.MapBuffer(bufferTarget, access);
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
        ~MappingBuffer()
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
                    GL.UnmapBuffer(this.bufferTarget);
                } // end if

                // TODO: Dispose unmanaged resources.
            } // end if

            this.disposedValue = true;
        } // end sub

        #endregion

        public IntPtr BufferPointer { get; set; }
    }
}
