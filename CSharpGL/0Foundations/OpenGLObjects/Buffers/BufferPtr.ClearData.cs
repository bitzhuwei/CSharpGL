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
        public bool ClearBufferData(uint internalFormat, uint format, uint type, UnmanagedArrayBase data)
        {
            if (data == null) { throw new ArgumentNullException("data"); }

            return ClearBufferData(internalFormat, format, type, data.Header);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="internalFormat"></param>
        /// <param name="format"></param>
        /// <param name="type"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool ClearBufferData(uint internalFormat, uint format, uint type, IntPtr data)
        {
            bool result = (glClearBufferData != null);

            if (result)
            {
                glClearBufferData((uint)this.Target, internalFormat, format, type, data);
            }

            return result;
        }
    }
}