using System;
using System.ComponentModel;
using System.Drawing.Design;

namespace CSharpGL
{
    /// <summary>
    /// Base type of all scripts.
    /// </summary>
    public abstract partial class ScriptComponent : Component
    {
        /// <summary>
        /// 
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ScriptComponent() : base(null) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bindingObject"></param>
        public ScriptComponent(SceneObject bindingObject) : base(bindingObject) { }
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
