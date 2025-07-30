using bitzhuwei.GLTF2;
using bitzhuwei.GLTFJsonFormat;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CSharpGL {
    public unsafe partial class GLTFBuffer : IDisposable {
        /// <summary>
        /// The URI (or IRI) of the buffer.
        /// <para>Buffer data MAY alternatively be embedded in the glTF file via data: URI with base64 encoding. When data: URI is used for buffer storage, its mediatype field MUST be set to application/octet-stream or application/gltf-buffer.</para>
        /// <para>Format: iri-reference</para>
        /// </summary>
        public string? uri;
        /// <summary>
        /// The length of the buffer in bytes.
        /// <para>The byte length of the referenced resource MUST be greater than or equal to the buffer.byteLength property.</para>
        /// <para>Minimum: >= 1</para>
        /// </summary>
        public required int byteLength;
        /// <summary>
        /// The user-defined name of this object.
        /// </summary>
        private string? name;

        /// <summary>
        /// JSON object with extension-specific objects.
        /// <para>Type of each property: Extension</para>
        /// </summary>
        public glTFextension? extensions;
        /// <summary>
        /// Application-specific data.
        /// </summary>
        public glTFextras? extras;

        public readonly Dictionary<string, GLTFJsonValue> additionalProperties;

        public readonly GCHandle? gcHandle;
        public readonly IntPtr pBytes;


        public GLTFBuffer(byte[]? bytes, Dictionary<string, GLTFJsonValue> additionalProperties) {
            if (bytes != null) {
                var gcHandle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
                var pBytes = gcHandle.AddrOfPinnedObject();
                this.gcHandle = gcHandle;
                this.pBytes = pBytes;
            }

            this.additionalProperties = additionalProperties;
        }

        internal static GLTFBuffer Read(glTFbuffer glTFbuffer/*, uint bufferId*/) {
            byte[]? bytes = null;
            if (glTFbuffer.uri != null) {
                var URI = bitzhuwei.GLTF2.Utility.StripOff(glTFbuffer.uri);
                bytes = bitzhuwei.GLTF2.Utility.LoadUri(URI);
                Debug.Assert(bytes.Length >= glTFbuffer.byteLength);
            }
            return new GLTFBuffer(bytes, glTFbuffer.additionalProperties) {
                uri = glTFbuffer.uri,
                byteLength = glTFbuffer.byteLength,
                name = glTFbuffer.name,
                extensions = glTFbuffer.extensions,
                extras = glTFbuffer.extras,
            };
        }

        //public unsafe void InitGLObjects(GLBufferView bufferView, GLAccessor accessor) {
        //    if (this.onlyTarget == null) { throw new Exception("This buffer is bind to multiple targets."); }

        //    if (this.initialized) { return; }

        //    var pin = GCHandle.Alloc(bytes, GCHandleType.Pinned);
        //    var data = pin.AddrOfPinnedObject();
        //    //TODO: use GLuint* instead of GLuint[] in GL.functions
        //    //var buffers = stackalloc uint[1];
        //    var gl = GL.Current; Debug.Assert(gl != null);
        //    var vbo = new GLuint[1];
        //    gl.glGenBuffers(1, vbo);
        //    //gl.glBindBuffer(bufferView.target ?? 0x8892/*GL.GL_ARRAY_BUFFER*/, vbo[0]);
        //    //gl.glBufferData(bufferView.target ?? 0x8892/*GL.GL_ARRAY_BUFFER*/, this.byteLength, data, 0x88E4/*GL.GL_STATIC_DRAW*/);
        //    gl.glBindBuffer(this.onlyTarget ?? 0, vbo[0]);
        //    gl.glBufferData(this.onlyTarget ?? 0, this.byteLength, data, 0x88E4/*GL.GL_STATIC_DRAW*/);
        //    //gl.glBindBuffer(bufferView.target ?? 0x8892/*GL.GL_ARRAY_BUFFER*/, 0);
        //    pin.Free();

        //    this.initialized = true;
        //}

        //internal void InitGLObjects(GLBufferView bufferView, GLAccessor.GLSparse.GLIndices indices, GLAccessor.GLSparse sparse, GLAccessor accessor) {
        //    if (this.initialized) { return; }

        //    var data = IntPtr.Zero; GCHandle? handle = null;
        //    if (this.uri != null) {
        //        var URI = bitzhuwei.GLTF2.Utility.StripOff(this.uri);
        //        var bytes = bitzhuwei.GLTF2.Utility.LoadUri(URI);
        //        Debug.Assert(bytes.Length >= this.byteLength);
        //        var pin = GCHandle.Alloc(bytes, GCHandleType.Pinned);
        //        data = pin.AddrOfPinnedObject();
        //        handle = pin;
        //    }
        //    //TODO: use GLuint* instead of GLuint[] in GL.functions
        //    //var buffers = stackalloc uint[1];
        //    var vbo = this.bufferId;
        //    var gl = GL.Current; Debug.Assert(gl != null);
        //    //gl.glGenBuffers(1, &vbo);
        //    gl.glBindBuffer(bufferView.target ?? 0x8892/*GL.GL_ARRAY_BUFFER*/, vbo);
        //    gl.glBufferData(bufferView.target ?? 0x8892/*GL.GL_ARRAY_BUFFER*/, this.byteLength, data, 0x88E4/*GL.GL_STATIC_DRAW*/);
        //    //gl.glBindBuffer(bufferView.target ?? 0x8892/*GL.GL_ARRAY_BUFFER*/, 0);
        //    if (handle != null) { handle.Value.Free(); }
        //    this.initialized = true;
        //}
        //internal static GLBuffer Read(glTFbuffer glTFbuffer) {
        //    var data = IntPtr.Zero; GCHandle? handle = null;
        //    if (glTFbuffer.uri != null) {
        //        var URI = bitzhuwei.GLTF2.Utility.StripOff(glTFbuffer.uri);
        //        var bytes = bitzhuwei.GLTF2.Utility.ParseUri(URI);
        //        Debug.Assert(bytes.Length >= glTFbuffer.byteLength);
        //        var pin = GCHandle.Alloc(bytes, GCHandleType.Pinned);
        //        data = pin.AddrOfPinnedObject();
        //        handle = pin;
        //    }
        //    //TODO: use GLuint* instead of GLuint[] in GL.functions
        //    //var buffers = stackalloc uint[1];
        //    var vbo = new uint[1];
        //    var gl = GL.Current;
        //    if (gl != null) {
        //        gl.glGenBuffers(1, vbo);
        //        gl.glBindBuffer(0x8892/*GL.GL_ARRAY_BUFFER*/, vbo[0]);
        //        gl.glBufferData(0x8892/*GL.GL_ARRAY_BUFFER*/, glTFbuffer.byteLength, data, 0x88E4/*GL.GL_STATIC_DRAW*/);
        //        gl.glBindBuffer(0x8892/*GL.GL_ARRAY_BUFFER*/, 0);
        //    }
        //    if (handle != null) { handle.Value.Free(); }

        //    return new GLBuffer(vbo[0]);
        //}

    }
}