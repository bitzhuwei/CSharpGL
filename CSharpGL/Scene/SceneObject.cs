using System;
using System.Collections.Generic;

namespace CSharpGL
{
    /// <summary>
    /// Description of SceneObject.
    /// </summary>
    public partial class SceneObject : IRenderable
    {
        public TransformComponent Transform { get; private set; }
        private ScriptComponent script;
        public ScriptComponent Script
        {
            get { return script; }
            set
            {
                if (script != null) { script.BindingObject = null; }

                if (value != null) { value.BindingObject = this; }

                script = value;
            }
        }
        public SceneObjectRenderer renderer;

        public SceneObject Parent { get; set; }

        public SceneObjectList Children { get; set; }

        public SceneObject(SceneObjectRenderer renderer)
        {
            if (renderer == null) { throw new ArgumentNullException(); }

            this.renderer = renderer;
            this.Transform = new TransformComponent(this);
            this.Children = new SceneObjectList();
        }

        public void Render(RenderEventArgs arg)
        {
            this.renderer.Render(arg);
        }
    }
}
