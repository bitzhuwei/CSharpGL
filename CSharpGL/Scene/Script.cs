using System;
using System.ComponentModel;
using System.Drawing.Design;

namespace CSharpGL
{
    /// <summary>
    /// Base type of all scripts.
    /// </summary>
    [Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
    public abstract partial class Script : IBindingObject<SceneObject>
    {
        /// <summary>
        /// 
        /// </summary>
        public SceneObject BindingObject { get; set; }
        /// <summary>
        /// Base type of all scripts.
        /// </summary>
        /// <param name="bindingObject"></param>
        public Script(SceneObject bindingObject = null)
        {
            this.BindingObject = bindingObject;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="elapsedTime"></param>
        protected virtual void DoUpdate(double elapsedTime) { }

        internal void Update(double elapsedTime)
        {
            this.DoUpdate(elapsedTime);
        }
    }
}
