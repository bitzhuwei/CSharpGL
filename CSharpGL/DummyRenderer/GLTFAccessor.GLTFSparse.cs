using bitzhuwei.GLTF2;
using bitzhuwei.GLTFJsonFormat;
using static bitzhuwei.GLTF2.glTFaccessor.glTFsparse;

namespace CSharpGL {
    public partial class GLTFAccessor {
        public partial class GLTFSparse {
            //public readonly int sparseCount;
            //public readonly GLIndices glIndices;
            //public readonly GLValues glValues;
            /// <summary>
            /// Number of deviating accessor values stored in the sparse array.
            /// <para>number of displaced elements. This number MUST NOT be greater than the number of the base accessor elements.</para>
            /// <para>Minimum: >= 1</para>
            /// </summary>
            public required int count;
            /// <summary>
            /// An object pointing to a buffer view containing the indices of deviating accessor values. The number of indices is equal to count. Indices MUST strictly increase.
            /// <para>object describing the location and the component type of indices of values to be replaced. The indices MUST form a strictly increasing sequence. The indices MUST NOT be greater than or equal to the number of the base accessor elements.</para>
            /// </summary>
            public required GLTFAccessor.GLTFSparse.GLTFIndices indices;
            /// <summary>
            /// An object pointing to a buffer view containing the deviating accessor values.
            /// <para>object describing the location of displaced elements corresponding to the indices referred from the indices.</para>
            /// </summary>
            public required GLTFAccessor.GLTFSparse.GLTFValues values;
            /// <summary>
            /// JSON object with extension-specific objects.
            /// </summary>
            public glTFextension? extensions;
            /// <summary>
            /// Application-specific data.
            /// </summary>
            public glTFextras? extras;
            public readonly Dictionary<string, GLTFJsonValue> additionalProperties;

            public GLTFSparse(Dictionary<string, GLTFJsonValue> additionalProperties) {
                this.additionalProperties = additionalProperties;
            }

            public static GLTFSparse Read(glTFaccessor.glTFsparse sparse, GLTFBufferView[] glBufferViews) {
                GLTFIndices glIndices = GLTFIndices.Read(sparse.indices, glBufferViews);
                GLTFValues glValues = GLTFValues.Read(sparse.values, glBufferViews);

                return new GLTFSparse(sparse.additionalProperties) {
                    count = sparse.count,
                    indices = glIndices,
                    values = glValues,
                    extensions = sparse.extensions,
                    extras = sparse.extras,
                };
            }

            public unsafe void InitGLObjects(GLTFAccessor accessor) {
                this.indices.InitGLObjects(this, accessor);
                this.values.InitGLObjects(this, accessor);
            }
        }
    }
}