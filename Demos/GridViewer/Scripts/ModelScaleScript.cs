using CSharpGL;
using System;
using System.Collections.Generic;
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
        public bool Scale(vec3 factor)
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
                foreach (var item in obj.Children) { stack.Push(item); }
            }

            while (stack.Count > 0)
            {
                SceneObject obj = stack.Pop();
                var transform = obj.Renderer as IModelTransform;
                if (transform != null)
                {
                    vec3 position = transform.ModelMatrix.GetTranslate();
                    vec3 distance = position - rootPosition;
                    mat4 model = glm.translate(mat4.identity(), distance);
                    model = glm.scale(model, factor);
                    transform.ModelMatrix = model;
                    updated = true;
                }

                foreach (var item in obj.Children) { stack.Push(item); }
            }

            return updated;
        }
    }
}
