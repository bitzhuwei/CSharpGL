using System;

namespace CSharpGL
{
    /// <summary>
    /// Description of Component.
    /// </summary>
    public partial class Component
    {
        public SceneObject BindingObject { get; set; }

        public Component(SceneObject bindingObject = null)
        {
            this.BindingObject = bindingObject;
        }
    }
}
