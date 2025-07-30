using bitzhuwei.GLTF2;
using bitzhuwei.GLTFJsonFormat;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;

namespace CSharpGL {
    public partial class GLTFBufferView : IDisposable {
        /// <summary>
        /// The index of the buffer.
        /// </summary>
        public required GLTFBuffer buffer;
        //public required int buffer;
        /// <summary>
        /// The offset into the buffer in bytes.
        /// <para>The offset of an accessor into a bufferView (i.e., accessor.byteOffset) and the offset of an accessor into a buffer (i.e., accessor.byteOffset + bufferView.byteOffset) MUST be a multiple of the size of the accessor’s component type.</para>
        /// </summary>
        public int byteOffset = 0;
        /// <summary>
        /// The length of the bufferView in bytes.
        /// <para>Each accessor MUST fit its bufferView, i.e.,</para>
        /// <para>accessor.byteOffset + EFFECTIVE_BYTE_STRIDE * (accessor.count - 1) + SIZE_OF_COMPONENT * NUMBER_OF_COMPONENTS</para>
        /// <para>MUST be less than or equal to bufferView.length.</para>
        /// <para>Minimum: >= 1</para>
        /// </summary>
        public required int byteLength;
        /// <summary>
        /// The stride, in bytes.
        /// <para>Minimum: >= 4</para>
        /// <para>Maximum: <= 252</para>
        /// <para>Related WebGL functions: vertexAttribPointer() stride parameter</para>
        /// <para>When a buffer view is used for vertex attribute data, it MAY have a byteStride property. This property defines the stride in bytes between each vertex. Buffer views with other types of data MUST NOT not define byteStride (unless such layout is explicitly enabled by an extension).</para>
        /// <para>When byteStride of the referenced bufferView is not defined, it means that accessor elements are tightly packed, i.e., effective stride equals the size of the element. When byteStride is defined, it MUST be a multiple of the size of the accessor’s component type.</para>
        /// <para>When two or more vertex attribute accessors use the same bufferView, its byteStride MUST be defined.</para>
        /// <para>For performance and compatibility reasons, each element of a vertex attribute MUST be aligned to 4-byte boundaries inside a bufferView (i.e., accessor.byteOffset and bufferView.byteStride MUST be multiples of 4).</para>
        /// <para>When accessor values are not tightly-packed (i.e., bufferView.byteStride is greater than element’s byte length), iteration over the created data view would need to take interleaved values into account (i.e., skip them).</para>
        /// </summary>
        public int? byteStride;
        /// <summary>
        /// The hint representing the intended GPU buffer type to use with this buffer view.
        /// <para>When a buffer view is used by vertex indices or attribute accessors it SHOULD specify bufferView.target with a value of element array buffer or array buffer respectively.</para>
        /// <para>Allowed values:
        /// ARRAY_BUFFER = 34962,
        /// ELEMENT_ARRAY_BUFFER = 34963</para>
        /// </summary>
        /*
        Implementation Note
This allows client implementations to early designate each buffer view to a proper processing step, e.g, buffer views with vertex indices and attributes would be copied to the appropriate GPU buffers, while buffer views with image data would be passed to format-specific image decoders. 
         */
        public GLenum? target; // GLenum is uint
        //public int? target;
        //public const int ARRAY_BUFFER = 34962;
        //public const int ELEMENT_ARRAY_BUFFER = 34963;

        /// <summary>
        /// The user-defined name of this object.
        /// </summary>
        public string? name;

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

        private bool initialized = false;
        public readonly GLuint bufferId;


        public GLTFBufferView(GLuint bufferId, Dictionary<string, GLTFJsonValue> additionalProperties) {
            this.bufferId = bufferId;
            this.additionalProperties = additionalProperties;
        }

        internal unsafe static GLTFBufferView Read(glTFbufferView source, GLTFBuffer[] glBuffers) {
            var gl = GL.current; Debug.Assert(gl != null);
            var bufferIds = stackalloc GLuint[1];
            gl.glGenBuffers(1, bufferIds);
            var glBuffer = glBuffers[source.buffer];
            if (source.target != null) {
                var target = source.target.Value;
                gl.glBindBuffer(target, bufferIds[0]);
                // var vbo = GLContext.current.buffers[bufferIds[0]];
                // GLContext.current.bindBuffers[target] = vbo;
                var data = IntPtr.Zero;
                var pBytes = glBuffer.pBytes;
                if (pBytes != IntPtr.Zero) {
                    //data = pBytes + this.byteOffset;
                    var p = (byte*)pBytes;
                    data = new IntPtr(p + source.byteOffset);
                }
                gl.glBufferData(target, source.byteLength, data, 0x88E4/*GL.GL_STATIC_DRAW*/);
                // var gpuData = new byte[byteLength];
                // GPU.Copy(data, gpuData);
                // GLContext.current.bindBuffers[target].data = gpuData;

                //gl.glBindBuffer(target, 0);
                // GLContext.current.bindBuffers[target] = null;
            }
            else { /* somewhere else will deal with it */ }
            var bufferView = new GLTFBufferView(bufferIds[0], source.additionalProperties) {
                buffer = glBuffer,
                byteOffset = source.byteOffset,
                byteLength = source.byteLength,
                byteStride = source.byteStride,
                target = source.target,
                name = source.name,
                extensions = source.extensions,
                extras = source.extras,
            };
            bufferView.initialized = source.target != null;

            return bufferView;
        }

        public unsafe void InitGLObjects(GLenum target) {
            if (this.initialized) return;

            var gl = GL.current; Debug.Assert(gl != null);
            //var bufferIds = new GLuint[1];
            //gl.glGenBuffers(1, bufferIds);

            //var target = this.target ?? 0;
            gl.glBindBuffer(target, this.bufferId);
            // var vbo = GLContext.current.buffers[bufferIds[0]];
            // GLContext.current.bindBuffers[target] = vbo;
            IntPtr data;
            var pBytes = this.buffer.pBytes;
            if (pBytes != IntPtr.Zero) {
                //data = pBytes + this.byteOffset;
                var p = (byte*)pBytes;
                data = new IntPtr(p + this.byteOffset);
            }
            else { data = IntPtr.Zero; }
            gl.glBufferData(target, this.byteLength, data, 0x88E4/*GL.GL_STATIC_DRAW*/);
            // var gpuData = new byte[byteLength];
            // GPU.Copy(data, gpuData);
            // GLContext.current.bindBuffers[target].data = gpuData;

            //gl.glBindBuffer(target, 0);
            // GLContext.current.bindBuffers[target] = null;

            this.initialized = true;
        }
    }
}