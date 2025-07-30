
using CSharpGL;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using static CSharpGL.GLProgram;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace demos.glSuperBible7code {
    public unsafe partial class Utility {
        public static byte* memcpy(byte* dest, byte* src, int count) {
            for (var i = 0; i < count; i++) {
                dest[i] = src[i];
            }

            return dest;
        }
    }
}
