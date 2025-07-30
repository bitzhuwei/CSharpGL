using System.Reflection.Emit;

namespace SoftGLImpl {
    public unsafe partial class SoftGL {
        public static IntPtr GetDC(IntPtr windowHandle) { return windowHandle; }

        public static void ReleaseDC(IntPtr windowHandle, IntPtr hDC) {
            // nothing to do for now.
        }
    }
}
