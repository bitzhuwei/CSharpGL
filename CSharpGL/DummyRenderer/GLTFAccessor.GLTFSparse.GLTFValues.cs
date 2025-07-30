using bitzhuwei.GLTF2;
using static CSharpGL.GLTFAccessor.GLTFSparse;

namespace CSharpGL {
    public partial class GLTFAccessor {
        public partial class GLTFSparse {
            public class GLTFValues {
                public readonly GLTFBufferView bufferView;
                public readonly glTFaccessor.glTFsparse.glTFvalues values;

                public GLTFValues(GLTFBufferView bufferView, glTFaccessor.glTFsparse.glTFvalues values) {
                    this.bufferView = bufferView;
                    this.values = values;
                }

                internal static GLTFValues Read(glTFaccessor.glTFsparse.glTFvalues values, GLTFBufferView[] glBufferViews) {
                    var bufferView = glBufferViews[values.bufferView];
                    return new GLTFValues(bufferView, values);
                }

                internal void InitGLObjects(GLTFSparse gLSparse, GLTFAccessor accessor) {
                    this.bufferView.InitGLObjects(0x90D2/*GL_SHADER_STORAGE_BUFFER*/);
                }
            }
        }
    }
}