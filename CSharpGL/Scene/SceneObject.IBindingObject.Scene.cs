using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;

namespace CSharpGL
{
    public partial class SceneObject
    {

        #region IBindingObject<Scene>

        /// <summary>
        /// Which scene is this object in?
        /// </summary>
        public Scene BindingObject { get; set; }

        #endregion IBindingObject<Scene>
    }
}
