
using CSharpGL;
using System.Diagnostics;

namespace CSharpGL {
    partial class GLProgram {
        public static GLProgram? Create(
                string vertCode, string tescCode, string teseCode, string geomCode, string fragCode) {
            var vs = Shader.Create(Shader.Kind.vert, vertCode, out var _);
            var tc = Shader.Create(Shader.Kind.tesc, tescCode, out var _);
            var te = Shader.Create(Shader.Kind.tese, teseCode, out var _);
            var gs = Shader.Create(Shader.Kind.geom, geomCode, out var _);
            var fs = Shader.Create(Shader.Kind.frag, fragCode, out var _);
            Debug.Assert(vs != null && tc != null && te != null && gs != null && fs != null);
            var (program, log) = GLProgram.Create(vs, tc, te, gs, fs);
            return program;
        }
        public static GLProgram? Create(
            string vertCode, string tescCode, string teseCode, string fragCode) {
            var vs = Shader.Create(Shader.Kind.vert, vertCode, out var _);
            var tc = Shader.Create(Shader.Kind.tesc, tescCode, out var _);
            var te = Shader.Create(Shader.Kind.tese, teseCode, out var _);
            var fs = Shader.Create(Shader.Kind.frag, fragCode, out var _);
            Debug.Assert(vs != null && tc != null && te != null && fs != null);
            var (program, log) = GLProgram.Create(vs, tc, te, fs);
            return program;
        }
        public static GLProgram? Create(
            string vertCode, string geomCode, string fragCode) {
            var vs = Shader.Create(Shader.Kind.vert, vertCode, out var _);
            var gs = Shader.Create(Shader.Kind.geom, geomCode, out var _);
            var fs = Shader.Create(Shader.Kind.frag, fragCode, out var _);
            Debug.Assert(vs != null && gs != null && fs != null);
            var (program, log) = GLProgram.Create(vs, gs, fs);
            return program;
        }
        public static GLProgram? Create(string vertCode, string fragCode) {
            var vs = Shader.Create(Shader.Kind.vert, vertCode, out var _);
            var fs = Shader.Create(Shader.Kind.frag, fragCode, out var _);
            Debug.Assert(vs != null && fs != null);
            var (program, log) = GLProgram.Create(vs, fs);
            return program;
        }
        public static GLProgram? Create(string vertCode) {
            var vs = Shader.Create(Shader.Kind.vert, vertCode, out var _);
            Debug.Assert(vs != null);
            var (program, log) = GLProgram.Create(vs);
            return program;
        }


        public static GLProgram? Create(string[] feedbackVaryings, BufferMode mode,
            string vertCode, string tescCode, string teseCode, string geomCode, string fragCode) {
            var vs = Shader.Create(Shader.Kind.vert, vertCode, out var _);
            var tc = Shader.Create(Shader.Kind.tesc, tescCode, out var _);
            var te = Shader.Create(Shader.Kind.tese, teseCode, out var _);
            var gs = Shader.Create(Shader.Kind.geom, geomCode, out var _);
            var fs = Shader.Create(Shader.Kind.frag, fragCode, out var _);
            Debug.Assert(vs != null && tc != null && te != null && gs != null && fs != null);
            var (program, log) = GLProgram.Create(feedbackVaryings, mode, vs, tc, te, gs, fs);
            return program;
        }
        public static GLProgram? Create(string[] feedbackVaryings, BufferMode mode,
            string vertCode, string tescCode, string teseCode, string fragCode) {
            var vs = Shader.Create(Shader.Kind.vert, vertCode, out var _);
            var tc = Shader.Create(Shader.Kind.tesc, tescCode, out var _);
            var te = Shader.Create(Shader.Kind.tese, teseCode, out var _);
            var fs = Shader.Create(Shader.Kind.frag, fragCode, out var _);
            Debug.Assert(vs != null && tc != null && te != null && fs != null);
            var (program, log) = GLProgram.Create(feedbackVaryings, mode, vs, tc, te, fs);
            return program;
        }
        public static GLProgram? Create(string[] feedbackVaryings, BufferMode mode,
         string vertCode, string geomCode, string fragCode) {
            var vs = Shader.Create(Shader.Kind.vert, vertCode, out var _);
            var gs = Shader.Create(Shader.Kind.geom, geomCode, out var _);
            var fs = Shader.Create(Shader.Kind.frag, fragCode, out var _);
            Debug.Assert(vs != null && gs != null && fs != null);
            var (program, log) = GLProgram.Create(feedbackVaryings, mode, vs, gs, fs);
            return program;
        }
        public static GLProgram? Create(string[] feedbackVaryings, BufferMode mode,
            string vertCode, string fragCode) {
            var vs = Shader.Create(Shader.Kind.vert, vertCode, out var _);
            var fs = Shader.Create(Shader.Kind.frag, fragCode, out var _);
            Debug.Assert(vs != null && fs != null);
            var (program, log) = GLProgram.Create(feedbackVaryings, mode, vs, fs);
            return program;
        }
        public static GLProgram? Create(string[] feedbackVaryings, BufferMode mode,
            string vertCode) {
            var vs = Shader.Create(Shader.Kind.vert, vertCode, out var _);
            Debug.Assert(vs != null);
            var (program, log) = GLProgram.Create(feedbackVaryings, mode, vs);
            return program;
        }


        public static GLProgram? Create(
            params (string Code, Shader.Kind kind)[] codes) {
            var shaders = new Shader[codes.Length];
            for (int i = 0; i < shaders.Length; i++) {
                var kind = codes[i].kind; var code = codes[i].Code;
                var shader = Shader.Create(kind, code, out var _);
                Debug.Assert(shader != null);
                shaders[i] = shader;
            }
            var (program, log) = GLProgram.Create(shaders);
            return program;
        }
        public static GLProgram? Create(string[] feedbackVaryings, BufferMode mode,
            params (string Code, Shader.Kind kind)[] codes) {
            var shaders = new Shader[codes.Length];
            for (int i = 0; i < shaders.Length; i++) {
                var kind = codes[i].kind; var code = codes[i].Code;
                var shader = Shader.Create(kind, code, out var _);
                Debug.Assert(shader != null);
                shaders[i] = shader;
            }
            var (program, log) = GLProgram.Create(feedbackVaryings, mode, shaders);
            return program;
        }

    }

}