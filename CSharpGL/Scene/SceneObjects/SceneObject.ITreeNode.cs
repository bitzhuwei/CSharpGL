using System.ComponentModel;
using System.Drawing.Design;

namespace CSharpGL
{
    public partial class SceneObject
    {
        #region ITreeNode

        private const string strTreeNode = "TreeNode";

        /// <summary>
        ///
        /// </summary>
        [Category(strTreeNode)]
        [Description("Parent")]
        public ITreeNode Parent { get; set; }

        /// <summary>
        ///
        /// </summary>
        [Category(strTreeNode)]
        [Description("Children")]
        [Editor(typeof(IListEditor<ITreeNode>), typeof(UITypeEditor))]
        public ChildList<ITreeNode> Children { get; private set; }

        #endregion ITreeNode
    }
}