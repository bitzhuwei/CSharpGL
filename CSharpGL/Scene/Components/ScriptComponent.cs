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
        public ScriptComponent() : base(null) { }

        public ScriptComponent(SceneObject bindingObject) : base(bindingObject) { }

        protected abstract void DoInitialize();

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
