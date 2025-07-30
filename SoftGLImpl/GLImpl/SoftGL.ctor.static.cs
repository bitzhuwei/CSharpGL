using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;

namespace SoftGLImpl {
    public unsafe partial class SoftGL {
        private static readonly Dictionary<string, IntPtr> procName2Address = new();
        static SoftGL() {
            // way #1
            Type type = typeof(SoftGL);
            var methodInfos = type.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            foreach (var methodInfo in methodInfos) {
                var procName = methodInfo.Name;
                if (procName.StartsWith("gl")) {
                    var pointer = methodInfo.MethodHandle.GetFunctionPointer();
                    procName2Address.Add(procName, pointer);
                }
            }
            // way #2
            //var pglGenBuffers = (delegate* managed<GLsizei, GLuint[], void>)(&glGenBuffers);
            //procName2Address.Add("glGenBuffers", (IntPtr)pglGenBuffers);
        }
    }
}
