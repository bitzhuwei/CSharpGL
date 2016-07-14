using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Records when is a property is updated and uploaded.
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
        /// Mark a property as updated(thus needs to be uploaded to OpenGL).
        /// </summary>
        public void Update()
        {
            this.updateTicks = DateTime.Now.Ticks;
        }

        /// <summary>
        /// Mark a property as uploaded(thus not need to upload it to OpenGL again).
        /// </summary>
        public void Uploaded()
        {
            this.uploadTicks = this.updateTicks;
        }

        /// <summary>
        /// Indicates whether a property is needed to be uploaded to OpenGL.
        /// </summary>
        /// <returns></returns>
        public bool Need2Upload()
        {
            return this.updateTicks != this.uploadTicks;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0}({1} {2} {3}",
                this.updateTicks != this.uploadTicks ? "Needs Uploading" : "Not Needs Uploading",
                this.updateTicks,
                (this.updateTicks < this.uploadTicks) ? "<" : (this.updateTicks == this.uploadTicks ? "==" : ">"),
                this.uploadTicks);
        }
    }
}
