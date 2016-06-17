using System;
using System.ComponentModel;
using System.Drawing.Design;

namespace CSharpGL
{
    /// <summary>
    /// Description of TransformComponent.
    /// </summary>
    [Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
    public abstract partial class ScriptComponent : Component
    {
        public ScriptComponent() : base(null) { }

        public ScriptComponent(SceneObject bindingObject) : base(bindingObject) { }

        public virtual void Awake() { }

        public virtual void Start() { }

        public virtual void Update(double elapsedTime) { }

        public virtual void Destroy() { }
    }
}
