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
        /// <summary>
        /// translate, rotate and scale this object in world space.
        /// </summary>
        private TransformComponent transform;
        private RendererComponent renderer;
        private ScriptComponentList scriptList = new ScriptComponentList();
        private SceneObject parent;
        private SceneObjectList children = new SceneObjectList();

        private const string strBasic = "Basic";

        /// <summary>
        /// name.
        /// </summary>
        [Category(strBasic)]
        [Description("Name.")]
        public string Name { get; set; }

        /// <summary>
        /// translate, rotate and scale this object in world space.
        /// </summary>
        public TransformComponent Transform { get { return this.transform; } }

        /// <summary>
        /// render this object.
        /// </summary>
        [Category(strBasic)]
        [Description("render this object.")]
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
        [Category(strBasic)]
        [Description("update state of this object.")]
        public ScriptComponentList ScriptList
        {
            get { return this.scriptList; }
        }

        /// <summary>
        /// Enabled or not.
        /// </summary>
        [Category(strBasic)]
        [Description("Enabled or Not.")]
        public bool Enabled { get; set; }

        /// <summary>
        /// binded object.
        /// </summary>
        [Category(strBasic)]
        [Description("binded object.")]
        [Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
        public object Tag { get; set; }

        /// <summary>
        /// an object to be rendered in a scene.
        /// </summary>
        public SceneObject()
        {
            this.Name = typeof(SceneObject).Name;
            this.Enabled = true;
            this.transform = new TransformComponent(this);
            this.children = new SceneObjectList(this);
        }

        public override string ToString()
        {
            return string.Format("{0}", this.Name);
        }

        /// <summary>
        /// Update scene object's state.
        /// </summary>
        /// <param name="elapsedTime">elapsed time (in milliseconds)</param>
        public void Update(double elapsedTime)
        {
            if (this.Enabled)
            {
                ScriptComponentList scriptList = this.scriptList;
                if (scriptList.Count > 0)
                {
                    foreach (var script in scriptList)
                    {
                        script.Update(elapsedTime);
                    }
                    //foreach (var item in this.Children)
                    //{
                    //    item.RefreshRelativeTransform();
                    //}
                }
            }
        }
    }
}
