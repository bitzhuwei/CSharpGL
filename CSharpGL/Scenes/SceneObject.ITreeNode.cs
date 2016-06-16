using System;
using System.Collections.Generic;

namespace CSharpGL
{
    public partial class SceneObject
    {

        #region ITreeNode

        public SceneObject Self { get { return this; } }

        public SceneObject Parent { get; set; }

        private SceneObjectList children = new SceneObjectList();
        public IList<SceneObject> Children { get { return this.children; } }

        #endregion ITreeNode

    }
}
