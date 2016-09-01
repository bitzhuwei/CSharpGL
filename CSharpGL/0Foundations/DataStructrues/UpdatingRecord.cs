using System;
using System.Collections.Generic;

namespace CSharpGL
{
    /// <summary>
    /// Records time when is a property is updated and uploaded.
    /// </summary>
    public class UpdatingRecord
    {
        /// <summary>
        /// The last time that a property is updated in client application.
        /// </summary>
        private long updateTicks;

        /// <summary>
        /// The first time that a property is uploaded to OpenGL.
        /// </summary>
        private long uploadTicks;

        /// <summary>
        /// Records time when is a property is updated and uploaded.
        /// </summary>
        /// <param name="marking">mark as initial state.</param>
        public UpdatingRecord(bool marking = false)
        {
            if (marking) { this.Mark(); }
        }

        /// <summary>
        /// Mark a property as updated(thus needs to be uploaded to OpenGL).
        /// </summary>
        public void Mark()
        {
            this.updateTicks = DateTime.Now.Ticks;
        }

        /// <summary>
        /// Mark a property as uploaded(thus not need to upload it to OpenGL again).
        /// </summary>
        public void CancelMark()
        {
            this.uploadTicks = this.updateTicks;
        }

        /// <summary>
        /// Indicates whether a property is needed to be uploaded to OpenGL.
        /// </summary>
        /// <returns></returns>
        public bool IsMarked()
        {
            return this.updateTicks != this.uploadTicks;
        }

        /// <summary>
        /// Sets a new value to specified filed and mark the property.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target"></param>
        /// <param name="value"></param>
        public void Set<T>(ref T target, T value)
        {
            if (!EqualityComparer<T>.Default.Equals(target, value))
            {
                target = value;
                this.Mark();
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0}({1} {2} {3})",
                this.updateTicks != this.uploadTicks ? "Needs Uploading" : "Not Needs Uploading",
                this.updateTicks,
                (this.updateTicks < this.uploadTicks) ? "<" : (this.updateTicks == this.uploadTicks ? "==" : ">"),
                this.uploadTicks);
        }
    }
}