using bitzhuwei.GLTF2;
using System.Globalization;

namespace CSharpGL {
    unsafe partial class DummyRenderer {
        public void Render() {
            if (this.scene == null) { return; }
            this.transformCache.RefreshTotoalTransforms();
            var currentScene = this.glScenes[this.scene.Value];
            foreach (var node in currentScene.nodes) {
                Render(node);
            }
        }

        private void Render(GLTFNode node) {
            if (node.mesh != null) {
                foreach (var primitive in node.mesh.primitives) {
                    primitive.Render();
                }
            }
            foreach (var child in node.children) {
                Render(child);
            }
        }

    }
}
