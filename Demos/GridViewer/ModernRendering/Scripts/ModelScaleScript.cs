using CSharpGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GridViewer
{
    /// <summary>
    /// scale model and its children models recursively.
    /// </summary>
    public class ModelScaleScript : Script
    {
        /// <summary>
        /// scale model and its children models recursively.
        /// </summary>
        [Category("Desc")]
        [Description("scale model and its children models recursively.")]
        public string Desc { get { return "scale model and its children models recursively."; } }

        private vec3 scale = new vec3(1, 1, 1);
        /// <summary>
        /// Invoke SetScale(vec3 factor) by modifing this property.
        /// 
        /// </summary>
        [Browsable(true)]
        [Description("Invoke SetScale(vec3 factor) by modifing this property.")]
        public vec3 Scale
        {
            get { return scale; }
            set
            {
                scale = value;
                this.SetScale(value);
            }
        }
        public bool SetScale(vec3 factor)
        {
            bool updated = false;

            var stack = new Stack<SceneObject>();
            vec3 rootPosition;
            {
                SceneObject obj = this.BindingObject;
                if (obj == null) { throw new Exception(); }
                var transform = obj.Renderer as IModelSpace;
                if (transform == null) { throw new Exception(); }
                rootPosition = transform.WorldPosition;
                stack.Push(obj);
            }

            while (stack.Count > 0)
            {
                SceneObject obj = stack.Pop();
                var transform = obj.Renderer as IModelSpace;
                if (transform != null)
                {
                    vec3 distance = transform.WorldPosition - rootPosition;
                    mat4 model = glm.translate(mat4.identity(), rootPosition);
                    model = glm.scale(model, factor);
                    model = glm.translate(model, distance);
                    transform.WorldPosition = model.GetTranslate();
                    transform.Scale = model.GetScale();

                    updated = true;
                }

                foreach (var item in obj.Children) { stack.Push(item); }
            }

            return updated;
        }
    }
}
