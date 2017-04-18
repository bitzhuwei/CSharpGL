using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL.GLTree
{
    public interface IVisitor
    {
        void Visit(IGLTreeNode node);
    }
}
