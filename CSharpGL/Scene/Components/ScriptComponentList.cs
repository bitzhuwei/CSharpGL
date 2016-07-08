using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    [Editor(typeof(IListEditor<ScriptComponent>), typeof(UITypeEditor))]
    public class ScriptComponentList : ComponentList<SceneObject, ScriptComponent>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bindingObject"></param>
        public ScriptComponentList(SceneObject bindingObject = null) : base(bindingObject) { }

    }
}
