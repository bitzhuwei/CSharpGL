using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;

namespace CSharpGL
{
    public partial class SceneObject
    {

        private SceneObject parent;
        private SceneObjectList children = new SceneObjectList();

        #region ITreeNode

        private const string strTreeNode = "TreeNode";

        //[Category(strTreeNode)]
        //[Description("Self")]
        //public SceneObject Self { get { return this; } }
        SceneObject ITreeNode<SceneObject>.Self { get { return this; } }

        SceneObject ITreeNode<SceneObject>.Parent { get { return parent; } set { parent = value; } }

        [Editor(typeof(IListEditor<SceneObject>), typeof(UITypeEditor))]
        IList<SceneObject> ITreeNode<SceneObject>.Children
        { get { return this.children; } }

        #endregion ITreeNode

        [Category(strTreeNode)]
        [Description("Parent")]
        public SceneObject Parent { get { return parent; } set { parent = value; } }

        [Category(strTreeNode)]
        [Description("Children")]
        public SceneObjectList Children { get { return children; } }

    }
}
