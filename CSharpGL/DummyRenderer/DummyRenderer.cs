using bitzhuwei.GLTF2;
using System.Globalization;

namespace CSharpGL {
    public partial class DummyRenderer {
        public GLTFBuffer[] glBuffers = new GLTFBuffer[0];
        public GLTFBufferView[] glBufferViews = new GLTFBufferView[0];
        public GLTFAccessor[] accessors = new GLTFAccessor[0];

        public GLTFMesh[] glMeshes = new GLTFMesh[0];

        public GLTFNode[] glNodes = new GLTFNode[0];
        public GLTFScene[] glScenes = new GLTFScene[0];
        public int? scene;

        private GLTFTransformCache transformCache = new();

    }
}
