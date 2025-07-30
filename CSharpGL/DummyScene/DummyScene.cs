using System;
using System.IO;
using System.Text;

namespace CSharpGL {
    /// <summary>
    /// 
    /// </summary>
    public partial class DummyScene {
        private readonly int maxNode;
        private int nextNodeId = 0;

        /// <summary>
        /// how many nodes to support
        /// </summary>
        /// <param name="maxNode"></param>
        public DummyScene(int maxNode) {
            this.maxNode = maxNode;
            this.transformCache = new DummyTransformCache(maxNode);
            var vpMat = new mat4[] { mat4.identity() };
            this.cameraBuffer = new Managed2Buffer<mat4>(vpMat);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="program"></param>
        /// <param name="attr2buffer">inVar -> bufferName in mesh</param>
        /// <param name="meshId"></param>
        /// <returns></returns>
        public DummyNode? ApplyNode(GLProgram program, Dictionary<string, string> attr2buffer, int meshId) {
            var t = Interlocked.Increment(ref nextNodeId);

            if (t > maxNode) { return null; }

            var node = new DummyNode(t - 1, this, program, attr2buffer, meshId);
            return node;
        }

        public readonly IReadOnlyList<DummyNode> nodes = new List<DummyNode>();

        public readonly List<DummyMesh> meshes = new();

        public readonly List<DummyMaterial> materials = new();

        public readonly List<DummyTexture> textures = new();

        public readonly List<DummyCamera> cameras = new();

        public readonly List<GLSwitch> switches = new();

        internal DummyTransformCache transformCache;

        internal int cameraId;
        internal Managed2Buffer<mat4> cameraBuffer;

        public void UploadCamera() {
            var camera = this.cameras[cameraId];
            if (camera != null) {
                this.cameraBuffer.data[0] = camera.GetProjectionView();
                this.cameraBuffer.Upload();
            }
        }

        /// <summary>
        /// records all nodes' full-transforms in this scene.
        /// </summary>
        public void Render() {
            if (this.transformCache.RefreshGlobalTransforms()) {
                this.transformCache.Upload();
            }

            TransformFeedbackObject? transformFeedbackObject = null;
            foreach (var node in nodes) {
                node.Render(transformFeedbackObject);
            }
        }
    }
}
