using System;
using System.ComponentModel;
using System.Drawing.Design;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    [Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
    public partial class Component : IBindingObject<SceneObject>
    {
        /// <summary>
        /// 
        /// </summary>
        public SceneObject BindingObject { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bindingObject"></param>
        public Component(SceneObject bindingObject = null)
        {
            this.BindingObject = bindingObject;
        }
    }
}
