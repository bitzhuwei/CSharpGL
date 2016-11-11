namespace CSharpGL
{
    public static partial class BufferHelper
    {
        /// <summary>
        ///
        /// </summary>
        private static OpenGL.glGenBuffers glGenBuffers;

        /// <summary>
        ///
        /// </summary>
        private static OpenGL.glBindBuffer glBindBuffer;

        /// <summary>
        ///
        /// </summary>
        private static OpenGL.glBufferData glBufferData;

        private static void InitFunctions()
        {
            glGenBuffers = OpenGL.GetDelegateFor<OpenGL.glGenBuffers>();
            glBindBuffer = OpenGL.GetDelegateFor<OpenGL.glBindBuffer>();
            glBufferData = OpenGL.GetDelegateFor<OpenGL.glBufferData>();
        }
    }
}