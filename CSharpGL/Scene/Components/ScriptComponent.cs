using System;
using System.ComponentModel;
using System.Drawing.Design;

namespace CSharpGL
{
    /// <summary>
    /// Description of TransformComponent.
    /// </summary>
    public abstract partial class ScriptComponent : Component
    {
        private bool initialized;
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
        protected abstract void DoInitialize();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="elapsedTime"></param>
        protected abstract void DoUpdate(double elapsedTime);

        internal void Initialize()
        {
            if (!this.initialized)
            {
                this.DoInitialize();
                this.initialized = true;
            }
        }

        internal void Update(double elapsedTime)
        {
            if (!this.initialized)
            { this.Initialize(); }

            this.DoUpdate(elapsedTime);
        }
    }
}
