using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;

namespace CSharpGL
{
    /// <summary>
    /// Description of SceneObject.
    /// </summary>
    [Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
    public partial class SceneObject : 
        IRenderable, // take part in rendering an object.
        ITreeNode<SceneObject>, // contains sub-scene-objects and is contained by parent.
        IEnumerable<SceneObject> // enumerates self and all children recursively.
    {
        public string Name { get; set; }

        public TransformComponent Transform { get; private set; }

        private SceneObjectRenderer renderer;
        public SceneObjectRenderer Renderer
        {
            get { return this.renderer; }
            set
            {
                {
                    SceneObjectRenderer renderer = this.renderer;
                    if (renderer != null) { renderer.BindingObject = null; }

                    if (value != null) { value.BindingObject = this; }
                }
                {
                    this.renderer = value;
                }
            }
        }

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
            this.Children = new SceneObjectList(this);
        }

        public override string ToString()
        {
            return string.Format("{0}", this.Name);
        }
    }
}
