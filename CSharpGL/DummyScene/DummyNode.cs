

using System.Diagnostics;

namespace CSharpGL {
    public class DummyNode {
        private readonly int nodeId;
        /// <summary>
        /// this node is applyed from which scene?
        /// </summary>
        private readonly DummyScene dummyScene;
        /// <summary>
        /// transform this node relative to parent node.
        /// </summary>
        private mat4 transform;
        private bool transformUpdated = true;
        ///// <summary>
        ///// transform this node relative to (0, 0, 0) in world space.
        ///// </summary>
        //private mat4 globalTransform;
        /// <summary>
        /// root node(has no parent) has level = 0.
        /// <para>children of root node has level = 1.</para>
        /// <para>children of children node has level = 2.</para>
        /// </summary>
        internal int level;

        /// <summary>
        /// parent node.
        /// </summary>
        public DummyNode? parent;
        /// <summary>
        /// children nodes.
        /// </summary>
        public readonly List<DummyNode> children = new();

        private readonly int meshId = -1;
        private GLProgram? program;
        public readonly List<int> switchIds = new();
        private Dictionary<string, string> attr2buffer;
        private VertexArrayObject? vao;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodeId"></param>
        /// <param name="dummyScene"></param>
        /// <param name="program"></param>
        /// <param name="attr2buffer">inVar -> bufferName in mesh</param>
        /// <param name="meshId"></param>
        internal DummyNode(int nodeId, DummyScene dummyScene, GLProgram program, Dictionary<string, string> attr2buffer, int meshId) {
            ArgumentNullException.ThrowIfNull(dummyScene);
            this.nodeId = nodeId;
            this.dummyScene = dummyScene;
            this.program = program;
            this.attr2buffer = attr2buffer;
            this.meshId = meshId;
            if (meshId >= 0) {
                var mesh = dummyScene.meshes[meshId];
                var lstAttr = new List<VertexShaderAttribute>(attr2buffer.Count);
                foreach (var pair in attr2buffer) {
                    var inVar = pair.Key; var bufferName = pair.Value;
                    if (mesh.TryGet(bufferName, out VertexBuffer buffer)) {
                        lstAttr.Add(new VertexShaderAttribute(buffer, inVar));
                    }
                }
                var cmd = mesh.GetCmd();
                var vao = new VertexArrayObject(cmd, program, lstAttr);
                this.vao = vao;
            }
        }

        /// <summary>
        /// set transform relative to parent node.
        /// </summary>
        /// <param name="transform"></param>
        internal void SetTransform(mat4 transform) {
            this.transform = transform;
            this.transformUpdated = true;
            this.dummyScene.transformCache.UpdateCache(this);
        }

        /// <summary>
        /// refresh <see cref="globalTransform"/> of this node and its children.
        /// </summary>
        /// <param name="force"></param>
        internal bool RefreshGlobalTransforms(DummyTransformCache cache, bool force) {
            var refreshed = false;
            var updated = this.transformUpdated;
            if (force || updated) {
                if (parent != null) {
                    //this.globalTransform = parent.globalTransform * this.transform;
                    cache.globalTransforms.data[this.nodeId] = cache.globalTransforms.data[parent.nodeId] * this.transform;
                }
                else {
                    //this.globalTransform = this.transform;
                    cache.globalTransforms.data[this.nodeId] = this.transform;
                }
                this.transformUpdated = false;
                foreach (var child in children) {
                    child.RefreshGlobalTransforms(cache, force: true);
                }
                refreshed = true;
            }
            return refreshed;
        }

        public void Render(TransformFeedbackObject? transformFeedbackObj, params IDrawCommand[] drawCmds) {
            var program = this.program; if (program == null) { return; }
            var vao = this.vao; if (vao == null) { return; }
            var meshId = this.meshId; if (meshId < 0) { return; }

            var scene = this.dummyScene;
            var mesh = scene.meshes[meshId];

            program.Bind(); program.PushUniforms();

            foreach (var id in this.switchIds) {
                var glSwitch = scene.switches[id];
                glSwitch.On();
            }

            if (transformFeedbackObj != null) {
                transformFeedbackObj.Bind();
                transformFeedbackObj.Begin(vao.DrawCommand.Mode);
                vao.Draw(drawCmds);
                transformFeedbackObj.End();
                transformFeedbackObj.Unbind();
            }
            else {
                vao.Draw(drawCmds);
            }

            foreach (var id in this.switchIds) {
                var glSwitch = scene.switches[id];
                glSwitch.Off();
            }
            program.Unbind();
        }
    }
}