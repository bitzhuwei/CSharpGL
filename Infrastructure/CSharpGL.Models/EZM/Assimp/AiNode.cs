using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public class AiNode
    {
        public AiNode Parent { get; internal set; }

        public List<AiNode> Children { get; private set; }

        public AiNode()
        {
            this.Children = new List<AiNode>();
        }

        public string Name { get; internal set; }

        public mat4 Transform { get; internal set; }
    }
}
