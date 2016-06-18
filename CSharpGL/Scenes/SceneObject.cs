using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;

namespace CSharpGL
{
    /// <summary>
    /// an object to be rendered in a scene.
    /// </summary>
    [Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
    public partial class SceneObject :
        IRenderable, // take part in rendering an object.
        ITreeNode<SceneObject>, // contains children objects and is contained by parent.
        IEnumerable<SceneObject> // enumerates self and all children objects recursively.
    {
        private TransformComponent transform = new TransformComponent();
        private RendererComponent renderer;
        private ScriptComponent script;
        /// <summary>
        /// name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// translate, rotate and scale this object and its children.
        /// </summary>
        public TransformComponent GetTransform() { return this.transform; }

        /// <summary>
        /// render this object.
        /// </summary>
        public RendererComponent Renderer
        {
            get { return this.renderer; }
            set
            {
                {
                    RendererComponent renderer = this.renderer;
                    if (renderer != null) { renderer.BindingObject = null; }

                    if (value != null) { value.BindingObject = this; }
                }
                {
                    this.renderer = value;
                }
            }
        }

        /// <summary>
        /// update state of this object.
        /// </summary>
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

        /// <summary>
        /// an object to be rendered in a scene.
        /// </summary>
        public SceneObject()
        {
            this.Name = this.GetType().Name;
            this.Children = new SceneObjectList(this);
        }

        public override string ToString()
        {
            return string.Format("{0}", this.Name);
        }
    }
}
