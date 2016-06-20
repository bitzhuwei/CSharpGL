using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;

namespace CSharpGL
{
    public partial class SceneObject
    {

        #region ITreeNode

        private const string strTreeNode = "TreeNode";

        [Category(strTreeNode)]
        [Description("Self")]
        public SceneObject Self { get { return this; } }

        [Category(strTreeNode)]
        [Description("Parent")]
        public SceneObject Parent { get; set; }

        [Category(strTreeNode)]
        [Description("Children")]
        [Editor(typeof(SceneObjectListEditor), typeof(UITypeEditor))]
        public IList<SceneObject> Children { get; private set; }

        #endregion ITreeNode

    }
}
