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
        [Description("Value")]
        public SceneObject Content { get { return this; } }

        /// <summary>
        ///
        /// </summary>
        [Category(strTreeNode)]
        [Description("Parent")]
        public ITreeNode<SceneObject> Parent { get; set; }

        /// <summary>
        ///
        /// </summary>
        [Category(strTreeNode)]
        [Description("Children")]
        [Editor(typeof(IListEditor<SceneObject>), typeof(UITypeEditor))]
        public ChildList<SceneObject> Children { get; private set; }

        #endregion ITreeNode
    }
}