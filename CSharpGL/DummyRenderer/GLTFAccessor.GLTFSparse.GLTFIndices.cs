using bitzhuwei.GLTF2;
using bitzhuwei.GLTFJsonFormat;

namespace CSharpGL {
    public partial class GLTFAccessor {
        public partial class GLTFSparse {
            public class GLTFIndices {
                //public readonly GLBufferView bufferView;
                //public readonly glTFaccessor.glTFsparse.glTFindices indices;
                /// <summary>
                /// The index of the buffer view with sparse indices. The referenced buffer view MUST NOT have its target or byteStride properties defined. The buffer view and the optional byteOffset MUST be aligned to the componentType byte length.
                /// </summary>
                public required GLTFBufferView bufferView;
                //public required int bufferView;
                /// <summary>
                /// The offset relative to the start of the buffer view in bytes.
                /// </summary>
                public int byteOffset = 0;
                /// <summary>
                /// The indices data type.
                /// <para>Allowed values:
                /// 5121 UNSIGNED_BYTE
                /// 5123 UNSIGNED_SHORT
                /// 5125 UNSIGNED_INT</para>
                /// </summary>
                public required int componentType;
                /// <summary>
                /// JSON object with extension-specific objects.
                /// </summary>
                public glTFextension? extensions;
                /// <summary>
                /// Application-specific data.
                /// </summary>
                public glTFextras? extras;
                public readonly Dictionary<string, GLTFJsonValue> additionalProperties;

                public GLTFIndices(Dictionary<string, GLTFJsonValue> additionalProperties) {
                    this.additionalProperties = additionalProperties;
                }

                internal static GLTFIndices Read(glTFaccessor.glTFsparse.glTFindices indices, GLTFBufferView[] glBufferViews) {
                    return new GLTFIndices(indices.additionalProperties) {
                        bufferView = glBufferViews[indices.bufferView],
                        byteOffset = indices.byteOffset,
                        componentType = indices.componentType,
                        extensions = indices.extensions,
                        extras = indices.extras,
                    };
                }

                internal void InitGLObjects(GLTFSparse sparse, GLTFAccessor accessor) {
                    //this.bufferView.InitGLObjects(this.bufferView.target ?? 0);
                    this.bufferView.InitGLObjects(0x90D2/*GL_SHADER_STORAGE_BUFFER*/);
                }
            }
        }
    }
}