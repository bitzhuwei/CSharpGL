using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Design;

namespace CSharpGL
{
    public abstract partial class BufferPtr
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="internalFormat"></param>
        /// <param name="format"></param>
        /// <param name="type"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool ClearBufferData(bool autoBind, uint internalFormat, uint format, uint type, UnmanagedArrayBase data)
        {
            if (data == null) { throw new ArgumentNullException("data"); }

            return ClearBufferData(autoBind, internalFormat, format, type, data.Header);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="internalFormat"></param>
        /// <param name="format"></param>
        /// <param name="type"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool ClearBufferData(bool autoBind, uint internalFormat, uint format, uint type, IntPtr data)
        {
            bool result = (glClearBufferData != null);

            if (result)
            {
                if (autoBind)
                { glBindBuffer((uint)this.Target, this.BufferId); }
                glClearBufferData((uint)this.Target, internalFormat, format, type, data);
                if (autoBind)
                { glBindBuffer((uint)this.Target, 0); }
            }

            return result;
        }
    }
}