using CSharpGL;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CSharpGL {
    public partial class GLTFTransformCache {
        ///// <summary>
        ///// root nodes in the scene.
        ///// </summary>
        //public readonly List<GLNode> rootNodes = new();
        /// <summary>
        /// list[0] is updated nodes with level = 0.
        /// <para>list[1] is updated nodes with level = 1.</para>
        /// </summary>
        private readonly List<List<GLTFNode>> cache = new();

        public void UpdateTransform(GLTFNode node, mat4 tarnsform) {
            node.SetTransform(tarnsform);
            var max = this.cache.Count;
            for (int i = max; i < node.level + 1; i++) {
                this.cache.Add(new List<GLTFNode>());
            }
            this.cache[node.level].Add(node);
        }

        public void RefreshTotoalTransforms() {
            foreach (var level in this.cache) {
                foreach (var node in level) {
                    node.RefreshTotoalTransforms(this, force: false);
                }
            }
            // reset cache
            for (int i = 0; i < this.cache.Count; i++) {
                this.cache[i].Clear();
            }
        }

    }
}
