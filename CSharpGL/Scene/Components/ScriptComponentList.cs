using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    [Editor(typeof(IListEditor<ScriptComponent>), typeof(UITypeEditor))]
    public class ScriptComponentList : ComponentList<SceneObject, ScriptComponent>
    {

        public ScriptComponentList(SceneObject bindingObject = null) : base(bindingObject) { }

    }
}
