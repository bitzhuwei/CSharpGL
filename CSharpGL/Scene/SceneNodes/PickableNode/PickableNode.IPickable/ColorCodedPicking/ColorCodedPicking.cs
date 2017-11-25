using System;
using System.Runtime.InteropServices;
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
            var array = new Pixel[1];
            GCHandle pinned = GCHandle.Alloc(array, GCHandleType.Pinned);
            IntPtr header = pinned.AddrOfPinnedObject();
            // same result with: IntPtr header = Marshal.UnsafeAddrOfPinnedArrayElement(array, 0);
            // get coded color.
            GL.Instance.ReadPixels(x, y, 1, 1, GL.GL_RGBA, GL.GL_UNSIGNED_BYTE, header);
            pinned.Free();

            // If nothing is picked, stageVertexId will be uint.MaxValue.
            uint stageVertexId = array[0].ToStageVertexId();

            return stageVertexId;
        }
    }
}