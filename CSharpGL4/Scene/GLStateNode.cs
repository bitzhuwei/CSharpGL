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
    class GLStateNode : ITreeNode
    {
        private List<IGLState> stateList = new List<IGLState>();

        /// <summary>
        /// 
        /// </summary>
        public IList<IGLState> StateList { get { return this.stateList; } }

        public GLStateNode()
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
