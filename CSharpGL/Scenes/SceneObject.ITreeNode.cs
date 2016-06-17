using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;

namespace CSharpGL
{
    public partial class SceneObject
    {

        #region ITreeNode

        public SceneObject Self { get { return this; } }

        public SceneObject Parent { get; set; }

        [Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
        public IList<SceneObject> Children { get; private set; }

        #endregion ITreeNode

    }
}
