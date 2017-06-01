using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    /// <summary>
    /// A node in scene that maintains some <see cref="GLState"/>s.
    /// </summary>
    public abstract class SceneNode : ITreeNode
    {

        public SceneNode()
        {
            this.Children = new TreeNodeChildren(this);
        }

        #region ITreeNode 成员

        /// <summary>
        /// 
        /// </summary>
        public ITreeNode Parent { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TreeNodeChildren Children { get; private set; }

        #endregion
    }

}
