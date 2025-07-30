using bitzhuwei.GLTF2;

namespace CSharpGL {
    public class GLTFScene {
        public readonly GLTFNode[] nodes;

        public GLTFScene(GLTFNode[] nodes) {
            this.nodes = nodes;
        }

        internal static GLTFScene Read(glTFscene glTFscene, GLTFNode[] glNodes) {
            GLTFNode[] nodes;
            if (glTFscene.nodes != null) {
                nodes = new GLTFNode[glTFscene.nodes.Length];
                for (int i = 0; i < nodes.Length; i++) {
                    var index = glTFscene.nodes[i];
                    nodes[i] = glNodes[index];
                }
            }
            else { nodes = new GLTFNode[0]; }

            return new GLTFScene(nodes);
        }
    }
}