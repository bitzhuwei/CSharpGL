using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL {
    internal class DummyTransformCache : IDisposable {
        ///// <summary>
        ///// root nodes in the scene.
        ///// </summary>
        //public readonly List<GLNode> rootNodes = new();
        /// <summary>
        /// list[0] is updated nodes with level = 0.
        /// <para>list[1] is updated nodes with level = 1.</para>
        /// </summary>
        private readonly List<List<DummyNode>> cache = new();//TODO: use List<ConcurrentBag<DummyNode>> ?
        ///// <summary>
        ///// the array in GPU memory that records all nodes' full-transforms in this scene.
        ///// </summary>
        //internal ShaderStorageBuffer transformBuffer;
        ///// <summary>
        ///// the array that records all nodes' global-transforms in this scene.
        ///// <para><see cref="globalTransforms"/>[i] transforms the node(with nodeId=i) relative to (0, 0, 0) in world space.</para>
        ///// </summary>
        //internal mat4[] globalTransforms;
        //private GCHandle globalTransformsPin;
        //private IntPtr globalTransformsAddr;
        //private int globalTransformsByteLength;
        //
        /// <summary>
        /// the array that records all nodes' global-transforms in this scene.
        /// </summary>
        internal readonly Managed2Buffer<mat4> globalTransforms;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="maxNode">how many mat4(transform) to support?</param>
        public DummyTransformCache(int maxNode) {
            var globalTransforms = new mat4[maxNode];
            for (int i = 0; i < maxNode; i++) { globalTransforms[i] = mat4.identity(); }
            this.globalTransforms = new Managed2Buffer<mat4>(globalTransforms);
        }

        /// <summary>
        /// cache sepcified <paramref name="node"/> for later <see cref="RefreshGlobalTransforms"/>
        /// </summary>
        /// <param name="node"></param>
        public void UpdateCache(DummyNode node) {
            //node.SetTransform(transform);
            // prepare data structure
            var max = this.cache.Count;
            for (int i = max; i < node.level + 1; i++) {
                this.cache.Add(new List<DummyNode>());
            }
            // cache the node
            this.cache[node.level].Add(node);
        }

        public bool RefreshGlobalTransforms() {
            var refreshed = false;
            foreach (var level in this.cache) {
                foreach (var node in level) {
                    var r = node.RefreshGlobalTransforms(this, force: false);
                    if (r) { refreshed = true; }
                }
            }
            // reset cache
            for (int i = 0; i < this.cache.Count; i++) {
                this.cache[i].Clear();
            }
            return refreshed;
        }

        /// <summary>
        /// upload transforms data to GPU memory.
        /// </summary>
        /// <returns></returns>
        public bool Upload() {
            return this.globalTransforms.Upload();
        }

        void IDisposable.Dispose() {
            this.globalTransforms.Dispose();
        }
    }
}

