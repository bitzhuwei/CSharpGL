using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;
using System.Runtime.InteropServices;

namespace PhysicallyBasedRendering
{
    class SphereBuffers
    {
        private static readonly GLDelegates.void_int_uintN glGenVertexArrays;
        private static readonly GLDelegates.void_uint glBindVertexArray;
        private static readonly GLDelegates.void_int_uintN glDeleteVertexArrays;
        private static GLDelegates.void_int_uintN glGenBuffers;
        private static GLDelegates.void_uint_uint glBindBuffer;
        private static GLDelegates.void_uint_int_IntPtr_uint glBufferData;
        private static readonly GLDelegates.void_uint_int_uint_bool_int_IntPtr glVertexAttribPointer;
        internal static readonly GLDelegates.void_uint glEnableVertexAttribArray;

        static SphereBuffers()
        {
            glGenVertexArrays = GL.Instance.GetDelegateFor("glGenVertexArrays", GLDelegates.typeof_void_int_uintN) as GLDelegates.void_int_uintN;
            glBindVertexArray = GL.Instance.GetDelegateFor("glBindVertexArray", GLDelegates.typeof_void_uint) as GLDelegates.void_uint;
            glDeleteVertexArrays = GL.Instance.GetDelegateFor("glDeleteVertexArrays", GLDelegates.typeof_void_int_uintN) as GLDelegates.void_int_uintN;
            glGenBuffers = GL.Instance.GetDelegateFor("glGenBuffers", GLDelegates.typeof_void_int_uintN) as GLDelegates.void_int_uintN;
            glBindBuffer = GL.Instance.GetDelegateFor("glBindBuffer", GLDelegates.typeof_void_uint_uint) as GLDelegates.void_uint_uint;
            glBufferData = GL.Instance.GetDelegateFor("glBufferData", GLDelegates.typeof_void_uint_int_IntPtr_uint) as GLDelegates.void_uint_int_IntPtr_uint;
            glVertexAttribPointer = GL.Instance.GetDelegateFor("glVertexAttribPointer", GLDelegates.typeof_void_uint_int_uint_bool_int_IntPtr) as GLDelegates.void_uint_int_uint_bool_int_IntPtr;
            glEnableVertexAttribArray = GL.Instance.GetDelegateFor("glEnableVertexAttribArray", GLDelegates.typeof_void_uint) as GLDelegates.void_uint;
        }

        private uint[] vaos = new uint[1];
        private uint[] vbos = new uint[1];
        private uint[] ibos = new uint[1];
        private int indexCount;

        public SphereBuffers()
        {
            this.Init(SphereModel.bufferData, SphereModel.indices);
        }

        public void Init(float[] bufferData, uint[] indices)
        {
            this.indexCount = indices.Length;

            glGenVertexArrays(1, vaos);
            // fill buffer
            {
                GCHandle pinned = GCHandle.Alloc(bufferData, GCHandleType.Pinned);
                IntPtr header = Marshal.UnsafeAddrOfPinnedArrayElement(bufferData, 0);
                var array = new TempUnmanagedArray<float>(header, bufferData.Length);// It's not necessary to call Dispose() for this unmanaged array.
                glGenBuffers(1, vbos);
                glBindBuffer(GL.GL_ARRAY_BUFFER, vbos[0]);
                glBufferData(GL.GL_ARRAY_BUFFER, array.ByteLength, array.Header, GL.GL_STATIC_DRAW);
                pinned.Free();
            }
            {
                GCHandle pinned = GCHandle.Alloc(indices, GCHandleType.Pinned);
                IntPtr header = Marshal.UnsafeAddrOfPinnedArrayElement(indices, 0);
                var array = new TempUnmanagedArray<uint>(header, indices.Length);// It's not necessary to call Dispose() for this unmanaged array.
                glGenBuffers(1, ibos);
                glBindBuffer(GL.GL_ELEMENT_ARRAY_BUFFER, ibos[0]);
                glBufferData(GL.GL_ELEMENT_ARRAY_BUFFER, array.ByteLength, array.Header, GL.GL_STATIC_DRAW);
                pinned.Free();
            }
            {
                int stride = (3 + 2 + 3) * sizeof(float);
                // link vertex attributes
                glBindVertexArray(vaos[0]);
                glBindBuffer(GL.GL_ARRAY_BUFFER, vbos[0]);
                glEnableVertexAttribArray(0);
                glVertexAttribPointer(0, 3, GL.GL_FLOAT, false, stride, IntPtr.Zero);
                glEnableVertexAttribArray(1);
                glVertexAttribPointer(1, 2, GL.GL_FLOAT, false, stride, new IntPtr(3 * sizeof(float)));
                glEnableVertexAttribArray(1);
                glVertexAttribPointer(2, 3, GL.GL_FLOAT, false, stride, new IntPtr(5 * sizeof(float)));
                glBindBuffer(GL.GL_ARRAY_BUFFER, 0);
                glBindVertexArray(0);
            }
        }

        public void Render()
        {
            glBindVertexArray(vaos[0]);
            glBindBuffer(GL.GL_ELEMENT_ARRAY_BUFFER, this.ibos[0]);
            GL.Instance.DrawElements(GL.GL_TRIANGLE_STRIP, this.indexCount, GL.GL_UNSIGNED_INT, IntPtr.Zero);
            glBindBuffer(GL.GL_ELEMENT_ARRAY_BUFFER, 0);
            glBindVertexArray(0);
        }
    }
}
