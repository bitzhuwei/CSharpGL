using System;
using System.ComponentModel;

namespace CSharpGL
{
    public abstract partial class SceneElementBase
    {

        #region ITreeNode<SceneElement> 成员

        /// <summary>
        /// 
        /// </summary>
        public SceneElementBase Parent { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TreeNodeChildren<SceneElementBase> Children { get; private set; }

        #endregion
    }
}