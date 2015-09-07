using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBook.Common
{
    public static class ShaderHelper
    {
        public static void vglAttachShaderSource(uint program, ShaderType shaderType, string source)
        {
            uint sh;

            sh = GL.CreateShader((uint)shaderType);
            GL.ShaderSource(sh, source);
            GL.CompileShader(sh);
            StringBuilder builder = new StringBuilder(4096);
            GL.GetShaderInfoLog(sh, 4096, IntPtr.Zero, builder);
            GL.AttachShader(program, sh);
            GL.DeleteShader(sh);

        }
    }
}
