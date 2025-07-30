using bitzhuwei.GLTF2;
using bitzhuwei.GLTFJsonFormat;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics;
using System.Formats.Asn1;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

namespace CSharpGL {
    public unsafe partial class GLTFPrimitive : IDisposable {
        public readonly Dictionary<string, GLTFAccessor> attributes;
        public readonly GLTFAccessor? indices;
        public readonly GLenum mode;
        public readonly uint vaoId;
        public readonly GLTFProgram program;

        private static readonly string[] shaderFiles = new string[] { @"shaders\position.vs", @"shaders\position.fs" };
        private static readonly GLenum[] shaderTypes = new GLenum[] { 0x8B31/*GL_VERTEX_SHADER*/  , 0x8B30/*GL_FRAGMENT_SHADER*/ };
        class ShadersProgramInfo {
            public readonly string[] shaderFiles;
            public readonly GLenum[] shaderTypes;
            public GLTFProgram? program;
            public ShadersProgramInfo(string[] shaderFiles, GLenum[] shaderTypes) {
                this.shaderFiles = shaderFiles;
                this.shaderTypes = shaderTypes;
            }
        }
        private static readonly Dictionary<int, ShadersProgramInfo> id2Info = new();

        const string attrPosition = "POSITION";
        const string attrNORMAL = "NORMAL";
        const string attrTANGENT = "TANGENT";
        const string attrTEXCOORD_n = "TEXCOORD_n";// TODO: n => 0 -> n-1
        const string attrCOLOR_n = "COLOR_n";
        const string attrJOINTS_n = "JOINTS_n";
        const string attrWEIGHTS_n = "WEIGHTS_n";
        private static readonly Dictionary<string, uint> name2loc = new();
        static GLTFPrimitive() {
            id2Info.Add(0, new ShadersProgramInfo(shaderFiles, shaderTypes));

            name2loc.Add(attrPosition, 0);
            name2loc.Add(attrNORMAL, 1);
            name2loc.Add(attrTANGENT, 2);
            name2loc.Add(attrTEXCOORD_n, 3);
            name2loc.Add(attrCOLOR_n, 4);
            name2loc.Add(attrJOINTS_n, 5);
            name2loc.Add(attrWEIGHTS_n, 6);
        }

        public GLTFPrimitive(Dictionary<string, GLTFAccessor> attributes, GLTFAccessor? indices, GLenum mode, GLTFProgram program, uint vaoId) {
            this.attributes = attributes;
            this.indices = indices;
            this.mode = mode;
            this.program = program;
            this.vaoId = vaoId;
        }

        internal static GLTFPrimitive Read(glTFmesh.glTFprimitive glTFprimitive, DummyRenderer renderer) {
            var gl = GL.Current; Debug.Assert(gl != null);
            var vao = stackalloc GLuint[1];
            gl.glGenVertexArrays(1, vao);

            var attributes = new Dictionary<string, GLTFAccessor>();
            foreach (var item in glTFprimitive.attributes) {
                var attributeName = item.Key;
                var index = int.Parse(item.Value.u.value);
                var accessor = renderer.accessors[index];
                attributes.Add(attributeName, accessor);
            }
            GLTFAccessor? indices = null;
            if (glTFprimitive.indices != null) {
                indices = renderer.accessors[glTFprimitive.indices.Value];
            }
            if (glTFprimitive.material != null) {
                //TODO: primitive.material = renderer.materials[glTFprimitive.material.Value];
            }
            //primitive.mode = glTFprimitive.mode;

            GLTFProgram program = SelectProgram(attributes);

            return new GLTFPrimitive(attributes, indices, glTFprimitive.mode, program, vao[0]);
        }

        private void InitVertexArrayObject(Dictionary<string, GLTFAccessor> attributes) {
            var gl = GL.Current; Debug.Assert(gl != null);

            gl.glBindVertexArray(this.vaoId);
            foreach (var item in attributes) {
                var loc = name2loc[item.Key]; var accessor = item.Value;
                if (accessor.sparse == null) {
                    var componentCount = accessor.GetComponentCount();
                    gl.glBindBuffer(0x8892/*GL_ARRAY_BUFFER*/, accessor.bufferView.bufferId);
                    //accessor.glTFaccessor.type
                    //accessor.glTFaccessor.componentType
                    //accessor.glTFaccessor.count
                    //accessor.glTFaccessor.byteOffset
                    //accessor.bufferView.glTFbufferView.byteLength
                    //accessor.bufferView.glTFbufferView.byteStride
                    //accessor.bufferView.glTFbufferView.target
                    //accessor.bufferView.glTFbufferView.byteOffset
                    int byteStride = accessor.bufferView.byteStride ?? 0;
                    //pointer = new IntPtr(accessor.byteOffset + bufferView.byteOffset);
                    //var pointer = new IntPtr(accessor.byteOffset);
                    //gl.glVertexAttribPointer(loc, componentCount, accessor.componentType, false, byteStride, pointer);
                    gl.glVertexAttribPointer(loc, componentCount, accessor.componentType, false, byteStride, accessor.byteOffset);
                    gl.glEnableVertexAttribArray(loc);
                }
                else {
                    accessor.sparse.InitGLObjects(accessor);
                }
            }
            gl.glBindVertexArray(0);
        }


        private static GLTFProgram SelectProgram(Dictionary<string, GLTFAccessor> attributes) {
            // TODO: use which shader program ?
            int id = 0;
            if (false) { }
            else if (attributes.Keys.Contains(attrPosition)) {
                id = 0;
            }
            else { throw new NotImplementedException(); }
            var info = id2Info[id];
            if (info.program == null) { info.program = InitProgram(info); }
            Debug.Assert(info.program != null);
            return info.program;
        }

        private static GLTFProgram? InitProgram(ShadersProgramInfo info) {
            var gl = CSharpGL.GL.Current; Debug.Assert(gl != null);

            var programId = gl.glCreateProgram();
            var shaderIds = new uint[info.shaderFiles.Length];

            //var codes = stackalloc IntPtr[1]; //var lengths = stackalloc GLint[1];
            var parameters = stackalloc int[1];
            var infoLength = stackalloc int[1];
            for (int i = 0; i < shaderIds.Length; i++) {
                //  Create the OpenGL shader object.
                uint shaderId = gl.glCreateShader(info.shaderTypes[i]);

                //  Set the shader source.
                var code = File.ReadAllText(info.shaderFiles[i]);
                //codes[0] = Marshal.StringToHGlobalAnsi(code);
                var lengths = code.Length;
                gl.glShaderSource(shaderId, 1, new string[] { code }, &lengths);
                //gl.glShaderSource(shaderId, 1, codes, &lengths);
                //Marshal.FreeHGlobal(codes[0]);
                //  Compile the shader object.
                gl.glCompileShader(shaderId);

                //  Now that we've compiled the shader, check it's compilation status. If it's not compiled properly, we're
                //  going to throw an exception.
                gl.glGetShaderiv(shaderId, 0x8B81/*GL_COMPILE_STATUS*/, parameters);
                if (parameters[0] != 1/*GL_TRUE*/) {
                    //  Get the info log length.
                    gl.glGetShaderiv(shaderId, 0x8B84/*GL_INFO_LOG_LENGTH*/, infoLength);
                    int bufSize = infoLength[0];

                    //  Get the compile info.
                    var il = new StringBuilder(bufSize);
                    //string log = new string(' ', bufSize);
                    var logLength = new GLsizei[1];
                    gl.glGetShaderInfoLog(shaderId, bufSize, logLength, /*log*/il);
                    //var log = il.ToString();
                    Log.Write($"Failed to compile shader with ID {shaderId}: {il.ToString()}");
                }
                shaderIds[i] = shaderId;
            }
            for (int i = 0; i < shaderIds.Length; i++) {
                gl.glAttachShader(programId, shaderIds[i]);
            }
            gl.glLinkProgram(programId);
            {
                gl.glGetProgramiv(programId, GL.GL_LINK_STATUS, parameters);
                if (parameters[0] != 1/*GL_TRUE*/) {
                    //  Get the info log length.
                    gl.glGetProgramiv(programId, GL.GL_INFO_LOG_LENGTH, infoLength);
                    int bufSize = infoLength[0];
                    //  Get the compile info.
                    var il = new StringBuilder(bufSize);
                    //string log = new string(' ', bufSize);
                    var logLength = new GLsizei[1];
                    gl.glGetProgramInfoLog(programId, bufSize, logLength, il);
                    //var log = il.ToString();
                    Log.Write($"Failed to link program with ID {programId}: {il.ToString()}");
                }

            }
            for (int i = 0; i < shaderIds.Length; i++) {
                gl.glDeleteShader(shaderIds[i]);
            }
            return new GLTFProgram(programId);
        }

        internal void Render() {
            var gl = CSharpGL.GL.Current; Debug.Assert(gl != null);
            gl.glUseProgram(this.program.programId);
            gl.glBindVertexArray(this.vaoId);
            if (this.indices != null) {
                var indices = this.indices;
                IntPtr pointer = IntPtr.Zero;
                {
                    var bufferView = indices.bufferView;
                    if (bufferView != null) {
                        pointer = new IntPtr(indices.byteOffset + bufferView.byteOffset);
                    }
                }
                gl.glBindBuffer(0x8893/*GL_ELEMENT_ARRAY_BUFFER*/, indices.bufferView.bufferId);
                gl.glDrawElements(this.mode, indices.count, this.indices.componentType, pointer);
                gl.glBindBuffer(0x8893/*GL_ELEMENT_ARRAY_BUFFER*/, 0);
            }
            else {
                var count = 0;
                foreach (var item in this.attributes) {
                    var accessor = item.Value;
                    count = accessor.count;
                    break;
                }
                gl.glDrawArrays(this.mode, 0, count);
            }
            gl.glBindVertexArray(0);
            gl.glUseProgram(0);
        }
    }
}