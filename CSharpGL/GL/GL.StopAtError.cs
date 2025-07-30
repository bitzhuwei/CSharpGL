using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL {
    /// <summary>
    /// collection of openGL function pointers.
    /// <para>each operating system should has its own openGL implementation(ie. an class that implements this <see cref="GL"/> class).</para>
    /// <para><see cref="GLRenderContext"/> objects with the same initial parameters share function pointers in <see cref="GL"/>.</para>
    /// </summary>
    unsafe partial class GL {
        public static ErrorCode StopAtError() {
            var gl = GL.current;
            if (gl == null) { throw new NullReferenceException("openGL context not ready!"); }

            var error = (ErrorCode)gl.glGetError();
            if (error != 0) {
                //throw new Exception($"{error}");
                Console.WriteLine(error);
            }

            return error;
        }
    }
}
