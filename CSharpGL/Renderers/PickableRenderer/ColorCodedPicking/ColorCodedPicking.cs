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
        /// <param name="x">target pixel position(Left Down is (0, 0)).</param>
        /// <param name="y">target pixel position(Left Down is (0, 0)).</param>
        /// <returns></returns>
        internal static unsafe uint ReadStageVertexId(int x, int y)
        {
            uint stageVertexId = uint.MaxValue;
            using (var codedColor = new UnmanagedArray<Pixel>(1))
            {
                // get coded color.
                OpenGL.ReadPixels(x, y, 1, 1, OpenGL.GL_RGBA, OpenGL.GL_UNSIGNED_BYTE, codedColor.Header);
                var array = (Pixel*)codedColor.Header.ToPointer();
                Pixel pixel = array[0];
                // This is when (x, y) is not on background and some primitive is picked.
                if (!pixel.IsWhite())
                {
                    stageVertexId = pixel.ToStageVertexId();
                }
            }

            return stageVertexId;
        }
    }
}