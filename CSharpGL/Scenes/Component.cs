using System;
using System.ComponentModel;
using System.Drawing.Design;

namespace CSharpGL
{
    /// <summary>
    /// Description of Component.
    /// </summary>
    [Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
    public partial class Component
    {
        public SceneObject BindingObject { get; set; }

        public Component(SceneObject bindingObject = null)
        {
            this.BindingObject = bindingObject;
        }
    }
}
