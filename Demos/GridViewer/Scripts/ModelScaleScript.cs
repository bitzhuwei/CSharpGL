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
    public class ModelScaleScript : ScriptComponent
    {
        private vec3 scale;

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
                var transform = obj.Renderer as IModelTransform;
                if (transform == null) { throw new Exception(); }
                rootPosition = transform.ModelMatrix.GetTranslate();
                stack.Push(obj);
            }

            while (stack.Count > 0)
            {
                SceneObject obj = stack.Pop();
                var transform = obj.Renderer as IModelTransform;
                if (transform != null)
                {
                    vec3 position = transform.ModelMatrix.GetTranslate();
                    vec3 distance = position - rootPosition;
                    //mat4 model = glm.translate(mat4.identity(), distance);
                    mat4 model = glm.translate(mat4.identity(), rootPosition);
                    model = glm.scale(model, factor);
                    model = glm.translate(model, distance);
                    transform.ModelMatrix = model;
                    updated = true;
                }

                foreach (var item in obj.Children) { stack.Push(item); }
            }

            return updated;
        }
    }
}
