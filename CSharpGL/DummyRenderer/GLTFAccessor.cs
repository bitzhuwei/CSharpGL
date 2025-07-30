using bitzhuwei.GLTF2;
using bitzhuwei.GLTFJsonFormat;
using System.Diagnostics;
using System.Drawing;

namespace CSharpGL {
    public partial class GLTFAccessor {
        //public readonly glTFaccessor raw;
        //public readonly GLBufferView bufferView;
        //public readonly GLSparse? sparse;
        /// <summary>
        /// The index of the bufferView. When undefined, the accessor MUST be initialized with zeros; sparse property or extensions MAY override zeros with actual values.
        /// </summary>
        public GLTFBufferView bufferView;
        //public int? bufferView;
        /// <summary>
        /// The offset relative to the start of the buffer view in bytes. This MUST be a multiple of the size of the component datatype. This property MUST NOT be defined when bufferView is undefined.
        /// <para>Related WebGL functions: vertexAttribPointer() offset parameter</para>
        /// <para>The byteOffset property specifies the location of the first data element within the referenced buffer view. If the accessor is used for vertex attributes (i.e., it is referenced by a mesh primitive or its morph targets), the locations of the subsequent data elements are controlled by the bufferView.byteStride property. If the accessor is used for any other kind of data (vertex indices, animation keyframes, etc.), its data elements are tightly packed.</para>
        /// <para>The offset of an accessor into a bufferView (i.e., accessor.byteOffset) and the offset of an accessor into a buffer (i.e., accessor.byteOffset + bufferView.byteOffset) MUST be a multiple of the size of the accessor’s component type.</para>
        /// <para>Each accessor MUST fit its bufferView, i.e.,</para>
        /// <para>accessor.byteOffset + EFFECTIVE_BYTE_STRIDE * (accessor.count - 1) + SIZE_OF_COMPONENT * NUMBER_OF_COMPONENTS</para>
        /// <para>MUST be less than or equal to bufferView.length.</para>
        /// <para>For performance and compatibility reasons, each element of a vertex attribute MUST be aligned to 4-byte boundaries inside a bufferView (i.e., accessor.byteOffset and bufferView.byteStride MUST be multiples of 4).</para>
        /// <para>Accessors of matrix type have data stored in column-major order; start of each column MUST be aligned to 4-byte boundaries. Specifically, when ROWS * SIZE_OF_COMPONENT (where ROWS is the number of rows of the matrix) is not a multiple of 4, then (ROWS * SIZE_OF_COMPONENT) % 4 padding bytes MUST be inserted at the end of each column.</para>
        /// <para>Only the following three accessor configurations require padding.</para>
        /// <para>Figure 3. Matrix 2x2, 1-byte Components</para>
        /// <para>Figure 4. Matrix 3x3, 1-byte Components</para>
        /// <para>Figure 5. Matrix 3x3, 2-byte Components</para>
        /// <para>Alignment requirements apply only to the start of each column, so trailing bytes MAY be omitted if there’s no further data.</para>
        /// </summary>
        /*
        Implementation Note
Alignment requirements allow client implementations to more efficiently process binary buffers because creating aligned data views usually does not require extra copying.
         */
        public int byteOffset = 0;
        /// <summary>
        /// The datatype of the accessor’s components. UNSIGNED_INT type MUST NOT be used for any accessor that is not referenced by mesh.primitive.indices.
        /// <para>Related WebGL functions: type parameter of vertexAttribPointer(). The corresponding typed arrays are Int8Array, Uint8Array, Int16Array, Uint16Array, Uint32Array, and Float32Array.</para>
        /// <para>allowed values: BYTE = 5120, 8bits;
        /// UNSIGNED_BYTE = 5121, 8bits;
        /// SHORT = 5122, 16bits;
        /// UNSIGNED_SHORT = 5123, 16bits;
        /// UNSIGNED_INT = 5125, 32bits;
        /// FLOAT = 5126, 32bits</para>
        /// <para>Signed 32-bit integer components are not supported.</para>
        /// <para>Floating-point data MUST use IEEE-754(https://registry.khronos.org/glTF/specs/2.0/glTF-2.0.html#ieee-754) single precision format.</para>
        /// <para>Values of NaN, +Infinity, and -Infinity MUST NOT be present.</para>
        /// <para>Element size, in bytes, is (size in bytes of the 'componentType') * (number of components defined by 'type').</para>
        /// </summary>
        public required uint componentType; // GLenum is uint
        //public required int componentType;
        /// <summary>
        /// how many bytes is a component?
        /// </summary>
        /// <returns></returns>
        public int GetComponentBytes() {
            var result = 0;
            switch (this.componentType) {
            case 5120/*BYTE*/: result = 1; break;
            case 5121/*UNSIGNED_BYTE*/: result = 1; break;
            case 5122/*SHORT*/: result = 2; break;
            case 5123/*UNSIGNED_SHORT*/: result = 2; break;
            case 5125/*UNSIGNED_INT*/: result = 4; break;
            case 5126/*BYTE*/: result = 4; break;
            default: throw new NotImplementedException();
            }
            return result;
        }
        /// <summary>
        /// Specifies whether integer data values are normalized (true) to [0, 1] (for unsigned types) or to [-1, 1] (for signed types) when they are accessed. This property MUST NOT be set to true for accessors with FLOAT or UNSIGNED_INT component type.
        /// <para>Related WebGL functions: normalized parameter of vertexAttribPointer()</para>
        /// <para>Values stored in glTF JSON MUST match actual minimum and maximum binary values stored in buffers. The accessor.normalized flag has no effect on these properties.</para>
        /// </summary>
        public bool normalized = false;
        /// <summary>
        /// The number of elements referenced by this accessor, not to be confused with the number of bytes or number of components.
        /// <para>Elements could be, e.g., vertex indices, vertex attributes, animation keyframes, etc.</para>
        /// <para>Minimum: >= 1</para>
        /// </summary>
        public required int count;
        /// <summary>
        /// Specifies if the accessor’s elements are scalars, vectors, or matrices.
        /// <para>"SCALAR" has 1,
        /// "VEC2" has 2,
        /// "VEC3" has 3,
        /// "VEC4" has 4,
        /// "MAT2" has 4,
        /// "MAT3" has 9,
        /// "MAT4" has 16 components
        /// </para>
        /// <para>Element size, in bytes, is (size in bytes of the 'componentType') * (number of components defined by 'type').</para>
        /// </summary>
        public required string type;
        //public const string VEC2 = "VEC2";
        //public const string VEC3 = "VEC3";
        //public const string VEC4 = "VEC4";
        //public const string MAT2 = "MAT2";
        //public const string MAT3 = "MAT3";
        //public const string MAT4 = "MAT4";
        /// <summary>
        /// get number of components defined by <see cref="type"/>
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int GetComponentCount() {
            var size = 0;
            switch (this.type) {
            case "\"SCALAR\"": size = 1; break;
            case "\"VEC2\"": size = 2; break;
            case "\"VEC3\"": size = 3; break;
            case "\"VEC4\"": size = 4; break;
            case "\"MAT2\"": size = 4; break;
            case "\"MAT3\"": size = 9; break;
            case "\"MAT4\"": size = 16; break;
            default: throw new NotImplementedException();
            }
            return size;
        }

        /// <summary>
        /// Maximum value of each component in this accessor. Array elements MUST be treated as having the same data type as accessor’s componentType. Both min and max arrays have the same length. The length is determined by the value of the type property; it can be 1, 2, 3, 4, 9, or 16.
        /// <para>normalized property has no effect on array values: they always correspond to the actual values stored in the buffer. When the accessor is sparse, this property MUST contain maximum values of accessor data with sparse substitution applied.</para>
        /// <para>accessor.min and accessor.max properties are arrays that contain per-component minimum and maximum values, respectively. The length of these arrays MUST be equal to the number of accessor’s components.</para>
        /// <para>A sparse accessor min and max properties correspond, respectively, to the minimum and maximum component values once the sparse substitution is applied.</para>
        /// <para>When neither sparse nor bufferView is defined, min and max properties MAY have any values. This is intended for use cases when binary data is supplied by external means (e.g., via extensions).</para>
        /// <para>For floating-point components, JSON-stored minimum and maximum values represent single precision floats and SHOULD be rounded to single precision before usage to avoid any potential boundary mismatches.</para>
        /// <para>Animation input and vertex position attribute accessors MUST have accessor.min and accessor.max defined. For all other accessors, these properties are optional.</para>
        /// </summary>
        /*
        ECMAScript Implementation Note
Math.fround function could be used to achieve that.
         */
        public float[]? max;
        /// <summary>
        /// Minimum value of each component in this accessor. Array elements MUST be treated as having the same data type as accessor’s componentType. Both min and max arrays have the same length. The length is determined by the value of the type property; it can be 1, 2, 3, 4, 9, or 16.
        /// <para>normalized property has no effect on array values: they always correspond to the actual values stored in the buffer. When the accessor is sparse, this property MUST contain minimum values of accessor data with sparse substitution applied.</para>
        /// <para>accessor.min and accessor.max properties are arrays that contain per-component minimum and maximum values, respectively. The length of these arrays MUST be equal to the number of accessor’s components.</para>
        /// <para>A sparse accessor min and max properties correspond, respectively, to the minimum and maximum component values once the sparse substitution is applied.</para>
        /// <para>When neither sparse nor bufferView is defined, min and max properties MAY have any values. This is intended for use cases when binary data is supplied by external means (e.g., via extensions).</para>
        /// <para>For floating-point components, JSON-stored minimum and maximum values represent single precision floats and SHOULD be rounded to single precision before usage to avoid any potential boundary mismatches.</para>
        /// <para>Animation input and vertex position attribute accessors MUST have accessor.min and accessor.max defined. For all other accessors, these properties are optional.</para>
        /// </summary>
        public float[]? min;
        /// <summary>
        /// Sparse storage of elements that deviate from their initialization value.
        /// </summary>
        public GLTFAccessor.GLTFSparse? sparse;
        /// <summary>
        /// The user-defined name of this object. This is not necessarily unique, e.g., an accessor and a buffer could have the same name, or two accessors could even have the same name.
        /// </summary>
        public string? name;
        /// <summary>
        /// JSON object with extension-specific objects.
        /// </summary>
        public glTFextension? extensions;
        /// <summary>
        /// Application-specific data.
        /// </summary>
        public glTFextras? extras;
        public readonly Dictionary<string, GLTFJsonValue> additionalProperties;

        public GLTFAccessor(GLTFBufferView bufferView, Dictionary<string, GLTFJsonValue> additionalProperties) {
            this.bufferView = bufferView;
            this.additionalProperties = additionalProperties;
        }

        internal unsafe static GLTFAccessor Read(glTFaccessor glTFaccessor, GLTFBufferView[] glBufferViews) {
            GLTFBufferView bufferView;
            if (glTFaccessor.bufferView != null) {
                bufferView = glBufferViews[glTFaccessor.bufferView.Value];
            }
            else {
                var gl = GL.Current; Debug.Assert(gl != null);

                var vbo = stackalloc uint[1];
                gl.glGenBuffers(1, vbo);
                //gl.glBindBuffer(0x8892/*GL_ARRAY_BUFFER*/, vbo[0]);
                //gl.glBufferData(0x8892/*GL_ARRAY_BUFFER*/, byteLength, IntPtr.Zero, 0x88E4/*GL.GL_STATIC_DRAW*/);
                //gl.glBindBuffer(0x8892/*GL_ARRAY_BUFFER*/, 0);
                var bytes = glTFaccessor.GetComponentBytes();
                var size = glTFaccessor.GetComponentCount();
                var byteLength = bytes * size * glTFaccessor.count;
                bufferView = new GLTFBufferView(vbo[0], new()) {
                    buffer = new GLTFBuffer(bytes: null, new()) { byteLength = byteLength },
                    //byteOffset = 0,
                    byteLength = byteLength,
                    //byteStride = 0,
                    target = 0x8892/*GL_ARRAY_BUFFER*/,
                    //name = glTFbufferView.name,
                    //extensions = glTFbufferView.extensions,
                    //extras = glTFbufferView.extras,
                };
            }
            //var sparseCount = 0; byte[] indices, attributeValues;
            GLTFAccessor.GLTFSparse? sparse = null;
            if (glTFaccessor.sparse != null) {
                sparse = GLTFAccessor.GLTFSparse.Read(glTFaccessor.sparse, glBufferViews);
            }
            var accessor = new GLTFAccessor(bufferView, glTFaccessor.additionalProperties) {
                byteOffset = glTFaccessor.byteOffset,
                componentType = glTFaccessor.componentType,
                normalized = glTFaccessor.normalized,
                count = glTFaccessor.count,
                type = glTFaccessor.type,
                max = glTFaccessor.max,
                min = glTFaccessor.min,
                sparse = sparse,
                name = glTFaccessor.name,
                extensions = glTFaccessor.extensions,
                extras = glTFaccessor.extras,

            };

            return accessor;
        }

        public unsafe void InitGLObjects() {
            this.bufferView.InitGLObjects(this.bufferView.target ?? 0);
            if (this.sparse != null) {
                this.sparse.InitGLObjects(this);
            }
        }
    }
}