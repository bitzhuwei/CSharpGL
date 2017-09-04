using System;
using System.Runtime.InteropServices;

namespace CSharpGL
{
    public abstract partial class GLBuffer
    {
        private static GLDelegates.void_uint_uint_uint_uint_IntPtr glClearBufferData;
        private static GLDelegates.void_uint_uint_IntPtr_uint_uint_uint_IntPtr glClearBufferSubData;

        /// <summary>
        /// Fill a buffer object's data store with a fixed value.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="autoBind">Automatically call glBindBuffer() inside this method.</param>
        /// <returns></returns>
        public bool ClearBufferData(vec3 data, bool autoBind = true)
        {
            //buffer.ClearBufferData(GL.GL_RGB32F, GL.GL_RGB, GL.GL_FLOAT, array);
            var array = new vec3[] { data };
            GCHandle pinned = GCHandle.Alloc(array, GCHandleType.Pinned);
            IntPtr header = pinned.AddrOfPinnedObject();
            // same result with: IntPtr header = Marshal.UnsafeAddrOfPinnedArrayElement(array, 0);
            UnmanagedArrayBase unmanagedArray = new TempUnmanagedArray<vec3>(header, 1);
            bool result = ClearBufferData(GL.GL_RGB32F, GL.GL_RGB, GL.GL_FLOAT, unmanagedArray, autoBind);
            pinned.Free();

            return result;
        }

        /// <summary>
        /// Fill a buffer object's data store with a fixed value.
        /// </summary>
        /// <param name="internalFormat">The sized internal format with which the data will be stored in the buffer object.</param>
        /// <param name="format">Specifies the format of the pixel data. For transfers of depth, stencil, or depth/stencil data, you must use GL_DEPTH_COMPONENT​, GL_STENCIL_INDEX​, or GL_DEPTH_STENCIL​, where appropriate. For transfers of normalized integer or floating-point color image data, you must use one of the following: GL_RED​, GL_GREEN​, GL_BLUE​, GL_RG​, GL_RGB​, GL_BGR​, GL_RGBA​, and GL_BGRA​. For transfers of non-normalized integer data, you must use one of the following: GL_RED_INTEGER​, GL_GREEN_INTEGER​, GL_BLUE_INTEGER​, GL_RG_INTEGER​, GL_RGB_INTEGER​, GL_BGR_INTEGER​, GL_RGBA_INTEGER​, and GL_BGRA_INTEGER​.</param>
        /// <param name="type">Specifies the data type of the pixel data. The following symbolic values are accepted: GL_UNSIGNED_BYTE​, GL_BYTE​, GL_UNSIGNED_SHORT​, GL_SHORT​, GL_UNSIGNED_INT​, GL_INT​, GL_FLOAT​, GL_UNSIGNED_BYTE_3_3_2​, GL_UNSIGNED_BYTE_2_3_3_REV​, GL_UNSIGNED_SHORT_5_6_5​, GL_UNSIGNED_SHORT_5_6_5_REV​, GL_UNSIGNED_SHORT_4_4_4_4​, GL_UNSIGNED_SHORT_4_4_4_4_REV​, GL_UNSIGNED_SHORT_5_5_5_1​, GL_UNSIGNED_SHORT_1_5_5_5_REV​, GL_UNSIGNED_INT_8_8_8_8​, GL_UNSIGNED_INT_8_8_8_8_REV​, GL_UNSIGNED_INT_10_10_10_2​, and GL_UNSIGNED_INT_2_10_10_10_REV​.</param>
        /// <param name="data">Specifies a pointer to a single pixel of data to upload. This parameter may not be null.</param>
        /// <param name="autoBind">Automatically call glBindBuffer() inside this method.</param>
        /// <returns></returns>
        public bool ClearBufferData(uint internalFormat, uint format, uint type, UnmanagedArrayBase data, bool autoBind = true)
        {
            if (data == null || data.Header == IntPtr.Zero) { throw new ArgumentNullException("data"); }

            return ClearBufferData(internalFormat, format, type, data.Header, autoBind);
        }

        /// <summary>
        /// Fill a buffer object's data store with a fixed value.
        /// </summary>
        /// <param name="internalFormat">The sized internal format with which the data will be stored in the buffer object.</param>
        /// <param name="format">Specifies the format of the pixel data. For transfers of depth, stencil, or depth/stencil data, you must use GL_DEPTH_COMPONENT​, GL_STENCIL_INDEX​, or GL_DEPTH_STENCIL​, where appropriate. For transfers of normalized integer or floating-point color image data, you must use one of the following: GL_RED​, GL_GREEN​, GL_BLUE​, GL_RG​, GL_RGB​, GL_BGR​, GL_RGBA​, and GL_BGRA​. For transfers of non-normalized integer data, you must use one of the following: GL_RED_INTEGER​, GL_GREEN_INTEGER​, GL_BLUE_INTEGER​, GL_RG_INTEGER​, GL_RGB_INTEGER​, GL_BGR_INTEGER​, GL_RGBA_INTEGER​, and GL_BGRA_INTEGER​.</param>
        /// <param name="type">Specifies the data type of the pixel data. The following symbolic values are accepted: GL_UNSIGNED_BYTE​, GL_BYTE​, GL_UNSIGNED_SHORT​, GL_SHORT​, GL_UNSIGNED_INT​, GL_INT​, GL_FLOAT​, GL_UNSIGNED_BYTE_3_3_2​, GL_UNSIGNED_BYTE_2_3_3_REV​, GL_UNSIGNED_SHORT_5_6_5​, GL_UNSIGNED_SHORT_5_6_5_REV​, GL_UNSIGNED_SHORT_4_4_4_4​, GL_UNSIGNED_SHORT_4_4_4_4_REV​, GL_UNSIGNED_SHORT_5_5_5_1​, GL_UNSIGNED_SHORT_1_5_5_5_REV​, GL_UNSIGNED_INT_8_8_8_8​, GL_UNSIGNED_INT_8_8_8_8_REV​, GL_UNSIGNED_INT_10_10_10_2​, and GL_UNSIGNED_INT_2_10_10_10_REV​.</param>
        /// <param name="data">Specifies a pointer to a single pixel of data to upload. This parameter may not be IntPtr.Zero.</param>
        /// <param name="autoBind">Automatically call glBindBuffer() inside this method.</param>
        /// <returns></returns>
        public bool ClearBufferData(uint internalFormat, uint format, uint type, IntPtr data, bool autoBind = true)
        {
            if (data == IntPtr.Zero) { throw new ArgumentNullException("data"); }

            if (glClearBufferData == null) { glClearBufferData = GL.Instance.GetDelegateFor("glClearBufferData", GLDelegates.typeof_void_uint_uint_uint_uint_IntPtr) as GLDelegates.void_uint_uint_uint_uint_IntPtr; }

            bool result = (glClearBufferData != null);

            if (result)
            {
                if (autoBind)
                {
                    glBindBuffer((uint)this.Target, this.BufferId);
                }
                glClearBufferData((uint)this.Target, internalFormat, format, type, data);
                if (autoBind)
                {
                    glBindBuffer((uint)this.Target, 0);
                }
            }

            return result;
        }


        /// <summary>
        /// Fill all or part of buffer object's data store with a fixed value.
        /// </summary>
        /// <param name="offset">The offset, in basic machine units into the buffer object's data store at which to start filling.</param>
        /// <param name="size">The size, in basic machine units of the range of the data store to fill.</param>
        /// <param name="data">Specifies a pointer to a single pixel of data to upload. This parameter may not be null.</param>
        /// <param name="autoBind">Automatically call glBindBuffer() inside this method.</param>
        /// <returns></returns>
        public bool ClearBufferSubData(int offset, uint size, vec3 data, bool autoBind = true)
        {
            var array = new vec3[] { data };
            GCHandle pinned = GCHandle.Alloc(array, GCHandleType.Pinned);
            IntPtr header = pinned.AddrOfPinnedObject();
            // same result with: IntPtr header = Marshal.UnsafeAddrOfPinnedArrayElement(array, 0);
            UnmanagedArrayBase unmanagedArray = new TempUnmanagedArray<vec3>(header, 1);
            bool result = ClearBufferSubData(GL.GL_RGB32F, new IntPtr(offset), size, GL.GL_RGB, GL.GL_FLOAT, unmanagedArray, autoBind);
            pinned.Free();

            return result;
        }

        /// <summary>
        /// Fill all or part of buffer object's data store with a fixed value.
        /// </summary>
        /// <param name="internalFormat">The sized internal format with which the data will be stored in the buffer object.</param>
        /// <param name="offset">The offset, in basic machine units into the buffer object's data store at which to start filling.</param>
        /// <param name="size">The size, in basic machine units of the range of the data store to fill.</param>
        /// <param name="format">Specifies the format of the pixel data. For transfers of depth, stencil, or depth/stencil data, you must use GL_DEPTH_COMPONENT​, GL_STENCIL_INDEX​, or GL_DEPTH_STENCIL​, where appropriate. For transfers of normalized integer or floating-point color image data, you must use one of the following: GL_RED​, GL_GREEN​, GL_BLUE​, GL_RG​, GL_RGB​, GL_BGR​, GL_RGBA​, and GL_BGRA​. For transfers of non-normalized integer data, you must use one of the following: GL_RED_INTEGER​, GL_GREEN_INTEGER​, GL_BLUE_INTEGER​, GL_RG_INTEGER​, GL_RGB_INTEGER​, GL_BGR_INTEGER​, GL_RGBA_INTEGER​, and GL_BGRA_INTEGER​.</param>
        /// <param name="type">Specifies the data type of the pixel data. The following symbolic values are accepted: GL_UNSIGNED_BYTE​, GL_BYTE​, GL_UNSIGNED_SHORT​, GL_SHORT​, GL_UNSIGNED_INT​, GL_INT​, GL_FLOAT​, GL_UNSIGNED_BYTE_3_3_2​, GL_UNSIGNED_BYTE_2_3_3_REV​, GL_UNSIGNED_SHORT_5_6_5​, GL_UNSIGNED_SHORT_5_6_5_REV​, GL_UNSIGNED_SHORT_4_4_4_4​, GL_UNSIGNED_SHORT_4_4_4_4_REV​, GL_UNSIGNED_SHORT_5_5_5_1​, GL_UNSIGNED_SHORT_1_5_5_5_REV​, GL_UNSIGNED_INT_8_8_8_8​, GL_UNSIGNED_INT_8_8_8_8_REV​, GL_UNSIGNED_INT_10_10_10_2​, and GL_UNSIGNED_INT_2_10_10_10_REV​.</param>
        /// <param name="data">Specifies a pointer to a single pixel of data to upload. This parameter may not be null.</param>
        /// <param name="autoBind">Automatically call glBindBuffer() inside this method.</param>
        /// <returns></returns>
        public bool ClearBufferSubData(uint internalFormat, IntPtr offset, uint size, uint format, uint type, UnmanagedArrayBase data, bool autoBind = true)
        {
            if (data == null || data.Header == IntPtr.Zero) { throw new ArgumentNullException("data"); }

            return ClearBufferSubData(internalFormat, offset, size, format, type, data.Header, autoBind);
        }

        /// <summary>
        /// Fill all or part of buffer object's data store with a fixed value.
        /// </summary>
        /// <param name="internalFormat">The sized internal format with which the data will be stored in the buffer object.</param>
        /// <param name="offset">The offset, in basic machine units into the buffer object's data store at which to start filling.</param>
        /// <param name="size">The size, in basic machine units of the range of the data store to fill.</param>
        /// <param name="format">Specifies the format of the pixel data. For transfers of depth, stencil, or depth/stencil data, you must use GL_DEPTH_COMPONENT​, GL_STENCIL_INDEX​, or GL_DEPTH_STENCIL​, where appropriate. For transfers of normalized integer or floating-point color image data, you must use one of the following: GL_RED​, GL_GREEN​, GL_BLUE​, GL_RG​, GL_RGB​, GL_BGR​, GL_RGBA​, and GL_BGRA​. For transfers of non-normalized integer data, you must use one of the following: GL_RED_INTEGER​, GL_GREEN_INTEGER​, GL_BLUE_INTEGER​, GL_RG_INTEGER​, GL_RGB_INTEGER​, GL_BGR_INTEGER​, GL_RGBA_INTEGER​, and GL_BGRA_INTEGER​.</param>
        /// <param name="type">Specifies the data type of the pixel data. The following symbolic values are accepted: GL_UNSIGNED_BYTE​, GL_BYTE​, GL_UNSIGNED_SHORT​, GL_SHORT​, GL_UNSIGNED_INT​, GL_INT​, GL_FLOAT​, GL_UNSIGNED_BYTE_3_3_2​, GL_UNSIGNED_BYTE_2_3_3_REV​, GL_UNSIGNED_SHORT_5_6_5​, GL_UNSIGNED_SHORT_5_6_5_REV​, GL_UNSIGNED_SHORT_4_4_4_4​, GL_UNSIGNED_SHORT_4_4_4_4_REV​, GL_UNSIGNED_SHORT_5_5_5_1​, GL_UNSIGNED_SHORT_1_5_5_5_REV​, GL_UNSIGNED_INT_8_8_8_8​, GL_UNSIGNED_INT_8_8_8_8_REV​, GL_UNSIGNED_INT_10_10_10_2​, and GL_UNSIGNED_INT_2_10_10_10_REV​.</param>
        /// <param name="data">Specifies a pointer to a single pixel of data to upload. This parameter may not be IntPtr.Zero.</param>
        /// <param name="autoBind">Automatically call glBindBuffer() inside this method.</param>
        /// <returns></returns>
        public bool ClearBufferSubData(uint internalFormat, IntPtr offset, uint size, uint format, uint type, IntPtr data, bool autoBind = true)
        {
            if (data == IntPtr.Zero) { throw new ArgumentNullException("data"); }

            if (glClearBufferSubData == null) { glClearBufferSubData = GL.Instance.GetDelegateFor("glClearBufferSubData", GLDelegates.typeof_void_uint_uint_IntPtr_uint_uint_uint_IntPtr) as GLDelegates.void_uint_uint_IntPtr_uint_uint_uint_IntPtr; }

            bool result = (glClearBufferSubData != null);

            if (result)
            {
                if (autoBind)
                {
                    glBindBuffer((uint)this.Target, this.BufferId);
                }
                glClearBufferSubData((uint)this.Target, internalFormat, offset, size, format, type, data);
                if (autoBind)
                {
                    glBindBuffer((uint)this.Target, 0);
                }
            }

            return result;
        }
    }
}