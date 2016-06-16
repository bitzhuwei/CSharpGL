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
            this.Transform = new TransformComponent(this);
        }

        public void Render(RenderEventArgs arg)
        {
            this.Renderer.Render(arg);
        }

        #region ITreeNode

        public SceneObject Self { get { return this; } }

        public SceneObject Parent { get; set; }

        private SceneObjectList children = new SceneObjectList();
        public IList<SceneObject> Children { get { return this.children; } }

        #endregion ITreeNode

        #region IEnumerable<SceneObject>

        public IEnumerator<SceneObject> GetEnumerator()
        {
            var enumerable = ITreeNodeHelper.EnumerateRecursively(this);
            foreach (var item in enumerable)
            {
                yield return item;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #endregion IEnumerable<SceneObject>


    }
}
