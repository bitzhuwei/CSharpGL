using System;
using System.Collections.Generic;

namespace CSharpGL
{
    /// <summary>
    /// Description of SceneObject.
    /// </summary>
    public partial class SceneObject : 
        IRenderable, // take part in rendering an object.
        ITreeNode<SceneObject>, // contains sub-scene-objects and is contained by parent.
        IEnumerable<SceneObject> // enumerates self and all children recursively.
    {
        public string Name { get; set; }

        public TransformComponent Transform { get; private set; }

        public SceneObjectRenderer Renderer { get; set; }

        private ScriptComponent script;
        public ScriptComponent Script
        {
            get { return this.script; }
            set
            {
                {
                    ScriptComponent script = this.script;
                    if (script != null) { script.BindingObject = null; }

                    if (value != null) { value.BindingObject = this; }
                }
                {
                    this.script = value;
                }
            }
        }

        public SceneObject()
        {
            this.Name = this.GetType().Name;
            this.Transform = new TransformComponent(this);
        }

        public override string ToString()
        {
            return string.Format("{0}", this.Name);
        }
    }
}
