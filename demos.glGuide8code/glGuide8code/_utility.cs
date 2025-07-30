
using CSharpGL;
using System.Diagnostics;
using System.Xml.Linq;
using static CSharpGL.GLProgram;

namespace demos.glGuide8code {
    public unsafe class Utility {

        public static GLProgram? LoadShaders(string vsCodeFile, string tcCodeFile, string teCodeFile, string fsCodeFile) {
            var vsCode = File.ReadAllText(vsCodeFile);
            var tcCode = File.ReadAllText(tcCodeFile);
            var teCode = File.ReadAllText(teCodeFile);
            var fsCode = File.ReadAllText(fsCodeFile);
            var vs = Shader.Create(Shader.Kind.vert, vsCode, out var _);
            var tc = Shader.Create(Shader.Kind.tesc, tcCode, out var _);
            var te = Shader.Create(Shader.Kind.tese, teCode, out var _);
            var fs = Shader.Create(Shader.Kind.frag, fsCode, out var _);
            Debug.Assert(vs != null && tc != null && te != null && fs != null);
            var (program, log) = GLProgram.Create(vs, tc, te, fs);
            return program;
        }
        public static GLProgram? LoadShaders(string vsCodeFile, string gsCodeFile, string fsCodeFile) {
            var vsCode = File.ReadAllText(vsCodeFile);
            var gsCode = File.ReadAllText(gsCodeFile);
            var fsCode = File.ReadAllText(fsCodeFile);
            var vs = Shader.Create(Shader.Kind.vert, vsCode, out var _);
            var gs = Shader.Create(Shader.Kind.geom, gsCode, out var _);
            var fs = Shader.Create(Shader.Kind.frag, fsCode, out var _);
            Debug.Assert(vs != null && gs != null && fs != null);
            var (program, log) = GLProgram.Create(vs, gs, fs);
            return program;
        }
        public static GLProgram? LoadShaders(string vsCodeFile, string fsCodeFile) {
            var vsCode = File.ReadAllText(vsCodeFile);
            var fsCode = File.ReadAllText(fsCodeFile);
            var vs = Shader.Create(Shader.Kind.vert, vsCode, out var _);
            var fs = Shader.Create(Shader.Kind.frag, fsCode, out var _);
            Debug.Assert(vs != null && fs != null);
            var (program, log) = GLProgram.Create(vs, fs);
            return program;
        }

        public static GLProgram? LoadShaders(string[] feedbackVaryings, BufferMode mode, string vsCodeFile, string fsCodeFile) {
            var vsCode = File.ReadAllText(vsCodeFile);
            var fsCode = File.ReadAllText(fsCodeFile);
            var vs = Shader.Create(Shader.Kind.vert, vsCode, out var _);
            var fs = Shader.Create(Shader.Kind.frag, fsCode, out var _);
            Debug.Assert(vs != null && fs != null);
            var (program, log) = GLProgram.Create(feedbackVaryings, mode, vs, fs);
            return program;
        }

        public static GLProgram? LoadShaders(
            params (string codeFile, Shader.Kind kind)[] codeFiles) {
            var shaders = new Shader[codeFiles.Length];
            for (int i = 0; i < shaders.Length; i++) {
                var code = File.ReadAllText(codeFiles[i].codeFile);
                var shader = Shader.Create(codeFiles[i].kind, code, out var _);
                Debug.Assert(shader != null);
                shaders[i] = shader;
            }
            var (program, log) = GLProgram.Create(shaders);
            return program;
        }
        public static GLProgram? LoadShaders(string[] feedbackVaryings, BufferMode mode,
            params (string codeFile, Shader.Kind kind)[] codeFiles) {
            var shaders = new Shader[codeFiles.Length];
            for (int i = 0; i < shaders.Length; i++) {
                var code = File.ReadAllText(codeFiles[i].codeFile);
                var shader = Shader.Create(codeFiles[i].kind, code, out var _);
                Debug.Assert(shader != null);
                shaders[i] = shader;
            }
            var (program, log) = GLProgram.Create(feedbackVaryings, mode, shaders);
            return program;
        }
    }

}