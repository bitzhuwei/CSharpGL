using System;
using System.ComponentModel;

namespace CSharpGL
{
    public abstract partial class SceneElement
    {

        #region ITreeNode<SceneElement> 成员

        /// <summary>
        /// 
        /// </summary>
        public SceneElement Parent { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TreeNodeChildren<SceneElement> Children { get; private set; }

        #endregion
    }
}