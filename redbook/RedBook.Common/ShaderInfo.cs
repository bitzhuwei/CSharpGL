using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBook.Common
{
    public class ShaderInfo
    {
        public ShaderType type;
        public string shaderSource;
        public uint shader;

    }

    public static class ShaderProgramHelper
    {
        /// <summary>
        /// 加载、编译shader，返回shader program名。
        /// </summary>
        /// <param name="shaders"></param>
        /// <returns></returns>
        public static uint LoadShaders(this ShaderInfo[] shaders)
        {
            if (shaders == null) { return 0; }

            uint program = GL.CreateProgram();

            foreach (var entry in shaders)
            {

                uint shader = GL.CreateShader((uint)entry.type);

                entry.shader = shader;
                var source = entry.shaderSource;

                GL.ShaderSource(shader, entry.shaderSource);

                GL.CompileShader(shader);

                int[] compiled = new int[1];
                GL.GetShader(shader, GL.GL_COMPILE_STATUS, compiled);
                if (compiled[0] == 0)
                {
                    //  Get the info log length.
                    int[] infoLength = new int[] { 0 };
                    GL.GetShader(shader, GL.GL_INFO_LOG_LENGTH, infoLength);
                    int bufSize = infoLength[0];

                    //  Get the compile info.
                    StringBuilder il = new StringBuilder(bufSize);
                    GL.GetShaderInfoLog(shader, bufSize, IntPtr.Zero, il);

                    string log = il.ToString();
                    throw new Exception(log);
                }

                GL.AttachShader(program, shader);
            }

            GL.LinkProgram(program);

            int[] linked = new int[1];
            GL.GetProgram(program, GL.GL_LINK_STATUS, linked);
            if (linked[0] == 0)
            {
                //  Get the info log length.
                int[] infoLength = new int[] { 0 };
                GL.GetProgram(program, GL.GL_INFO_LOG_LENGTH, infoLength);
                int bufSize = infoLength[0];

                //  Get the compile info.
                StringBuilder il = new StringBuilder(bufSize);
                GL.GetProgramInfoLog(program, bufSize, IntPtr.Zero, il);

                string log = il.ToString();
                foreach (var entry in shaders)
                {
                    GL.DeleteShader(entry.shader);
                    entry.shader = 0;
                }

                throw new Exception(log);
            }

            return program;
        }
    }

    public enum ShaderType : uint
    {
        VertexShader = GL.GL_VERTEX_SHADER,
        TessellationControlShader = GL.GL_TESS_CONTROL_SHADER,
        TessellationEvaluationShader = GL.GL_TESS_EVALUATION_SHADER,
        FragmentShader = GL.GL_FRAGMENT_SHADER,
    }
}
