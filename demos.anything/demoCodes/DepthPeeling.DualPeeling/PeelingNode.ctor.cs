using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace DepthPeeling.DualPeeling {
    partial class PeelingNode {
        public PeelingNode(params SceneNodeBase[] children) {
            this.Children.AddRange(children);

            this.query = new Query();
            this.fullscreenQuad = QuadNode.Create();
        }
    }
}
