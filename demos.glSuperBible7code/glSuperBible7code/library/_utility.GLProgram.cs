
using CSharpGL;
using System.Diagnostics;
using System.Xml.Linq;
using static CSharpGL.GLProgram;

namespace demos.glSuperBible7code {
    public unsafe partial class Utility {
        public static GLProgram? LoadShaders(
                string vertCodeFile, string tescCodeFile, string teseCodeFile, string geomCodeFile, string fragCodeFile) {
            var vsCode = File.ReadAllText(vertCodeFile);
            var tcCode = File.ReadAllText(tescCodeFile);
            var teCode = File.ReadAllText(teseCodeFile);
            var gsCode = File.ReadAllText(geomCodeFile);
            var fsCode = File.ReadAllText(fragCodeFile);
            var vs = Shader.Create(Shader.Kind.vert, vsCode, out var _);
            var tc = Shader.Create(Shader.Kind.tesc, tcCode, out var _);
            var te = Shader.Create(Shader.Kind.tese, teCode, out var _);
            var gs = Shader.Create(Shader.Kind.geom, gsCode, out var _);
            var fs = Shader.Create(Shader.Kind.frag, fsCode, out var _);
            Debug.Assert(vs != null && tc != null && te != null && gs != null && fs != null);
            var (program, log) = GLProgram.Create(vs, tc, te, gs, fs);
            return program;
        }
        public static GLProgram? LoadShaders(
            string vertCodeFile, string tescCodeFile, string teseCodeFile, string fragCodeFile) {
            var vsCode = File.ReadAllText(vertCodeFile);
            var tcCode = File.ReadAllText(tescCodeFile);
            var teCode = File.ReadAllText(teseCodeFile);
            var fsCode = File.ReadAllText(fragCodeFile);
            var vs = Shader.Create(Shader.Kind.vert, vsCode, out var _);
            var tc = Shader.Create(Shader.Kind.tesc, tcCode, out var _);
            var te = Shader.Create(Shader.Kind.tese, teCode, out var _);
            var fs = Shader.Create(Shader.Kind.frag, fsCode, out var _);
            Debug.Assert(vs != null && tc != null && te != null && fs != null);
            var (program, log) = GLProgram.Create(vs, tc, te, fs);
            return program;
        }
        public static GLProgram? LoadShaders(
            string vertCodeFile, string geomCodeFile, string fragCodeFile) {
            var vsCode = File.ReadAllText(vertCodeFile);
            var gsCode = File.ReadAllText(geomCodeFile);
            var fsCode = File.ReadAllText(fragCodeFile);
            var vs = Shader.Create(Shader.Kind.vert, vsCode, out var _);
            var gs = Shader.Create(Shader.Kind.geom, gsCode, out var _);
            var fs = Shader.Create(Shader.Kind.frag, fsCode, out var _);
            Debug.Assert(vs != null && gs != null && fs != null);
            var (program, log) = GLProgram.Create(vs, gs, fs);
            return program;
        }
        public static GLProgram? LoadShaders(string vertCodeFile, string fragCodeFile) {
            var vsCode = File.ReadAllText(vertCodeFile);
            var fsCode = File.ReadAllText(fragCodeFile);
            var vs = Shader.Create(Shader.Kind.vert, vsCode, out var _);
            var fs = Shader.Create(Shader.Kind.frag, fsCode, out var _);
            Debug.Assert(vs != null && fs != null);
            var (program, log) = GLProgram.Create(vs, fs);
            return program;
        }
        public static GLProgram? LoadShaders(string vertCodeFile) {
            var vsCode = File.ReadAllText(vertCodeFile);
            var vs = Shader.Create(Shader.Kind.vert, vsCode, out var _);
            Debug.Assert(vs != null);
            var (program, log) = GLProgram.Create(vs);
            return program;
        }
        public static GLProgram? LoadShaders(
            string[] feedbackVaryings, BufferMode mode, string vertCodeFile, string fragCodeFile) {
            var vsCode = File.ReadAllText(vertCodeFile);
            var fsCode = File.ReadAllText(fragCodeFile);
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