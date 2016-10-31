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
        /// <param name="autoBind">Automatically call glBindBuffer() inside this method.</param>
        /// <returns></returns>
        public bool ClearBufferData(uint internalFormat, uint format, uint type, UnmanagedArrayBase data, bool autoBind = true)
        {
            if (data == null) { throw new ArgumentNullException("data"); }

            return ClearBufferData(internalFormat, format, type, data.Header, autoBind);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="internalFormat"></param>
        /// <param name="format"></param>
        /// <param name="type"></param>
        /// <param name="data"></param>
        /// <param name="autoBind">Automatically call glBindBuffer() inside this method.</param>
        /// <returns></returns>
        public bool ClearBufferData(uint internalFormat, uint format, uint type, IntPtr data, bool autoBind = true)
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