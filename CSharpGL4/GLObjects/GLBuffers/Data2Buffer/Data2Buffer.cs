namespace CSharpGL
{
    /// <summary>
    ///
    /// </summary>
    public static partial class Data2Buffer
    {
        /// <summary>
        ///
        /// </summary>
        private static GLDelegates.void_int_uintN glGenBuffers;

        /// <summary>
        ///
        /// </summary>
        private static GLDelegates.void_uint_uint glBindBuffer;

        /// <summary>
        ///
        /// </summary>
        private static GLDelegates.void_uint_int_IntPtr_uint glBufferData;

        static Data2Buffer()
        {
            glGenBuffers = GL.Instance.GetDelegateFor("glGenBuffers", GLDelegates.typeof_void_int_uintN) as GLDelegates.void_int_uintN;
            glBindBuffer = GL.Instance.GetDelegateFor("glBindBuffer", GLDelegates.typeof_void_uint_uint) as GLDelegates.void_uint_uint;
            glBufferData = GL.Instance.GetDelegateFor("glBufferData", GLDelegates.typeof_void_uint_int_IntPtr_uint) as GLDelegates.void_uint_int_IntPtr_uint;
        }
    }
}