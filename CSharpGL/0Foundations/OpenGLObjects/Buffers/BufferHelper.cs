using System;

namespace CSharpGL
{
    /// <summary>
    /// Vertex Buffer Object.
    /// </summary>
    public static partial class BufferHelper
    {
        /// <summary>
        ///
        /// </summary>
        static OpenGL.glGenBuffers glGenBuffers;

        /// <summary>
        ///
        /// </summary>
        static OpenGL.glBindBuffer glBindBuffer;

        /// <summary>
        ///
        /// </summary>
        static OpenGL.glBufferData glBufferData;

        private static void InitFunctions()
        {
            glGenBuffers = OpenGL.GetDelegateFor<OpenGL.glGenBuffers>();
            glBindBuffer = OpenGL.GetDelegateFor<OpenGL.glBindBuffer>();
            glBufferData = OpenGL.GetDelegateFor<OpenGL.glBufferData>();
        }
    }
}