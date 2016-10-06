namespace CSharpGL
{
    /// <summary>
    ///
    /// </summary>
    public static class ColorCodedPicking
    {
        /// <summary>
        /// Gets stage vertex id by color coded picking machanism.
        /// Note: left bottom is(0, 0). This is different from Winform's left top being (0, 0).
        /// </summary>
        /// <param name="x">left bottom is(0, 0)</param>
        /// <param name="y">left bottom is(0, 0)</param>
        /// <returns></returns>
        internal static unsafe uint ReadPixel(int x, int y)
        {
            uint stageVertexId = uint.MaxValue;
            using (var codedColor = new UnmanagedArray<Pixel>(1))
            {
                // get coded color.
                OpenGL.ReadPixels(x, y, 1, 1, OpenGL.GL_RGBA, OpenGL.GL_UNSIGNED_BYTE, codedColor.Header);
                var array = (Pixel*)codedColor.Header.ToPointer();
                Pixel pixel = array[0];
                // This is when (x, y) is not on background and some primitive is picked.
                if (pixel.a != byte.MaxValue || pixel.b != byte.MaxValue
                    || pixel.g != byte.MaxValue || pixel.r != byte.MaxValue)
                {
                    /* // This is how is vertexID coded into color in vertex shader.
                     * 	int objectID = gl_VertexID;
                        codedColor = vec4(
                            float(objectID & 0xFF),
                            float((objectID >> 8) & 0xFF),
                            float((objectID >> 16) & 0xFF),
                            float((objectID >> 24) & 0xFF));
                     */
                    // get vertexID from coded color.
                    // the vertexID is the last vertex that constructs the primitive.
                    // see http://www.cnblogs.com/bitzhuwei/p/modern-opengl-picking-primitive-in-VBO-2.html
                    uint shiftedR = (uint)pixel.r;
                    uint shiftedG = (uint)pixel.g << 8;
                    uint shiftedB = (uint)pixel.b << 16;
                    uint shiftedA = (uint)pixel.a << 24;
                    stageVertexId = shiftedR + shiftedG + shiftedB + shiftedA;
                }
            }

            return stageVertexId;
        }
    }
}