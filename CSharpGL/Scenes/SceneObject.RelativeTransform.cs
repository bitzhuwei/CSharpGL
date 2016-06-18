using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;

namespace CSharpGL
{
    public partial class SceneObject
    {
        ///// <summary>
        ///// transform information relative to parent.
        ///// </summary>
        //private TransformComponent relativeTransform;

        private vec3 position;
        private vec3 scale = new vec3(1, 1, 1);
        private vec3 rotation;

        private const string strTransform = "Transform";
        /// <summary>
        /// position relative to parent.
        /// </summary>
        [Category(strTransform)]
        [Description("position relative to parent.")]
        public vec3 Position
        {
            get { return position; }
            set
            {
                SceneObject parent = this.Parent;
                //if (parent != null || position != value)
                //{
                position = value;
                if (parent == null)
                {
                    this.transform.Position = value;
                }
                else
                {
                    this.transform.Position = parent.transform.Position + value;
                }
                foreach (var item in this.Children)
                {
                    item.Position = item.position;
                }
                //}
            }
        }

        /// <summary>
        /// scale relative to parent.
        /// </summary>
        [Category(strTransform)]
        [Description("scale relative to parent.")]
        public vec3 Scale
        {
            get { return scale; }
            set
            {
                SceneObject parent = this.Parent;
                //if (parent != null || scale != value)
                //{
                scale = value;
                if (parent == null)
                {
                    this.transform.Scale = value;
                }
                else
                {
                    this.transform.Scale = parent.transform.Scale * value;
                }
                foreach (var item in this.Children)
                {
                    item.Scale = item.scale;
                }
                //}
            }
        }

        /// <summary>
        /// rotation relative to parent
        /// </summary>
        [Category(strTransform)]
        [Description("rotation relative to parent.")]
        public vec3 Rotation
        {
            get { return rotation; }
            set
            {
                SceneObject parent = this.Parent;
                //if (parent != null || rotation != value)
                //{
                rotation = value;
                if (parent == null)
                {
                    this.transform.Rotation = value;
                }
                else
                {
                    this.transform.Rotation = parent.transform.Rotation + value;
                }
                foreach (var item in this.Children)
                {
                    item.Rotation = item.rotation;
                }
                //}
            }
        }

        ///// <summary>
        ///// Transform relative to its parent.
        ///// </summary>
        //public TransformComponent Transform
        //{
        //    get { return this.relativeTransform; }
        //    set
        //    {
        //        this.relativeTransform = value;
        //        SceneObject parent = this.Parent;
        //        if (parent == null)
        //        { this.transform = value; }
        //        else
        //        { this.transform = parent.transform* value; }
        //    }
        //}
    }
}
