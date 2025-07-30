using bitzhuwei.GLTF2;

namespace CSharpGL {
    public class GLTFNode {

        private mat4 transform;
        private bool transformUpdated = true;
        private mat4 totalTransform;

        public GLTFNode? parent;
        public readonly List<GLTFNode> children = new();
        /// <summary>
        /// root node(has no parent) has level = 0.
        /// <para>children of root node has level = 1.</para>
        /// </summary>
        internal int level;

        public GLTFMesh? mesh;

        internal static GLTFNode Read(glTFnode glTFnode, DummyRenderer renderer) {
            var node = new GLTFNode();
            if (false) { }
            else if (glTFnode.matrix != null) {
                node.transform = new mat4(glTFnode.matrix);
            }
            else if (glTFnode.translation != null || glTFnode.rotation != null || glTFnode.scale != null) {
                mat4 result = mat4.identity();
                if (glTFnode.translation != null) { result = glm.translate(result, new vec3(glTFnode.translation)); }
                if (glTFnode.rotation != null) {
                    var q = new Quaternion(glTFnode.rotation);
                    result = result * q.ToMat4();
                }
                if (glTFnode.scale != null) { result = glm.scale(result, new vec3(glTFnode.scale)); }
                node.transform = result;
            }
            else { node.transform = mat4.identity(); }

            if (glTFnode.mesh != null) { node.mesh = renderer.glMeshes[glTFnode.mesh.Value]; }

            return node;
        }


        public void SetTransform(mat4 transform) {
            this.transform = transform;
            this.transformUpdated = true;
        }

        /// <summary>
        /// update <see cref="GLTFNode.totalTransform"/> and children's <see cref="GLTFNode.totalTransform"/>
        /// </summary>
        /// <param name="glSceneContext"></param>
        /// <param name="force">true: parent call, false: stack call</param>
        public void RefreshTotoalTransforms(GLTFTransformCache glSceneContext, bool force) {
            var updated = this.transformUpdated;
            if (force || updated) {
                if (parent != null) {
                    this.totalTransform = parent.totalTransform * this.transform;
                }
                else {
                    this.totalTransform = this.transform;
                }
                this.transformUpdated = false;
                foreach (var child in children) {
                    child.RefreshTotoalTransforms(glSceneContext, force: true);
                }
            }
        }

    }
}