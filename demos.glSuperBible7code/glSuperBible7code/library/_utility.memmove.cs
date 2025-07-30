
using CSharpGL;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using static CSharpGL.GLProgram;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace demos.glSuperBible7code {
    public unsafe partial class Utility {
        public static byte* memmove(byte* dest, byte* src, int count) {
            // 检测重叠情况
            if (src < dest && src + count > dest) {
                // 源在目标前方，存在重叠，从后向前复制
                for (var i = count - 1; i >= 0; i--) {
                    dest[i] = src[i];
                }
            }
            else {
                // 无重叠或源在目标后方，从前向后复制
                for (var i = 0; i < count; i++) {
                    dest[i] = src[i];
                }
            }

            return dest;
        }
    }
}
