using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public abstract class GLNode
    {
        internal abstract Type ThisTypeCache { get; }

        private List<GLNode> children = new List<GLNode>();
        public List<GLNode> Children { get { return this.children; } }
    }
}
