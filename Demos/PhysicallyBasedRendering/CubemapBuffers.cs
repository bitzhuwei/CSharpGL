using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;
using System.Runtime.InteropServices;

namespace PhysicallyBasedRendering
{
    class CubemapBuffers
    {
        private static readonly GLDelegates.void_int_uintN glGenVertexArrays;
        private static readonly GLDelegates.void_uint glBindVertexArray;
        private static readonly GLDelegates.void_int_uintN glDeleteVertexArrays;
        private static GLDelegates.void_int_uintN glGenBuffers;
        private static GLDelegates.void_uint_uint glBindBuffer;
        private static GLDelegates.void_uint_int_IntPtr_uint glBufferData;
        private static readonly GLDelegates.void_uint_int_uint_bool_int_IntPtr glVertexAttribPointer;
        internal static readonly GLDelegates.void_uint glEnableVertexAttribArray;

        static CubemapBuffers()
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

        private uint[] cubeVAOs = new uint[1];
        private uint[] cubeVBOs = new uint[1];

        public CubemapBuffers()
        {
            this.Init(CubemapModel.vertices);
        }

        public void Init(float[] vertices)
        {
            GCHandle pinned = GCHandle.Alloc(vertices, GCHandleType.Pinned);
            IntPtr header = Marshal.UnsafeAddrOfPinnedArrayElement(vertices, 0);
            int length = vertices.Length;
            var array = new TempUnmanagedArray<float>(header, length);// It's not necessary to call Dispose() for this unmanaged array.

            glGenVertexArrays(1, cubeVAOs);
            glGenBuffers(1, cubeVBOs);
            // fill buffer
            glBindBuffer(GL.GL_ARRAY_BUFFER, cubeVBOs[0]);
            glBufferData(GL.GL_ARRAY_BUFFER, array.ByteLength, array.Header, GL.GL_STATIC_DRAW);
            // link vertex attributes
            glBindVertexArray(cubeVAOs[0]);
            glEnableVertexAttribArray(0);
            glVertexAttribPointer(0, 3, GL.GL_FLOAT, false, 8 * sizeof(float), IntPtr.Zero);
            glEnableVertexAttribArray(1);
            glVertexAttribPointer(1, 3, GL.GL_FLOAT, false, 8 * sizeof(float), new IntPtr(3 * sizeof(float)));
            glEnableVertexAttribArray(2);
            glVertexAttribPointer(2, 2, GL.GL_FLOAT, false, 8 * sizeof(float), new IntPtr(6 * sizeof(float)));
            glBindBuffer(GL.GL_ARRAY_BUFFER, 0);
            glBindVertexArray(0);
            pinned.Free();
        }

        public void Render()
        {
            // render Cube
            glBindVertexArray(cubeVAOs[0]);
            GL.Instance.DrawArrays(GL.GL_TRIANGLES, 0, 36);
            glBindVertexArray(0);
        }
    }
}
