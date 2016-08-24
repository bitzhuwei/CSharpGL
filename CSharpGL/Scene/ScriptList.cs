using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// A list of script.
    /// </summary>
    [Editor(typeof(IListEditor<Script>), typeof(UITypeEditor))]
    public class ScriptList : ComponentList<SceneObject, Script>
    {
        /// <summary>
        /// A list of script.
        /// </summary>
        /// <param name="bindingObject"></param>
        public ScriptList(SceneObject bindingObject = null) : base(bindingObject) { }

    }
}
