using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL.GLTree;

namespace CSharpGL
{
    public interface IGLTreeNode : ITreeNode<IGLTreeNode>
    {
        void Visit(IVisitor visitor);
    }
}
