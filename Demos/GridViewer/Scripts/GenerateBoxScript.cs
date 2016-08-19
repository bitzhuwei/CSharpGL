using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridViewer
{
    public class GenerateBoxScript : ScriptComponent
    {
        private BoundingBoxRenderer boxRenderer;

        public BoundingBoxRenderer BoxRenderer
        {
            get { return boxRenderer; }
        }

        protected override void DoInitialize()
        {
            var boxObj = new SceneObject();
            boxObj.Name = "Box's Object";
            {
                var modelSize = this.BindingObject.Renderer as IModelSize;
                vec3 lengths = new vec3(modelSize.XLength, modelSize.YLength, modelSize.ZLength);
                var boxRenderer = BoundingBoxRenderer.Create(lengths);
                {
                    var transform = this.BindingObject.Renderer as IModelTransform;
                    vec3 position = transform.ModelMatrix.GetTranslate();
                    //boxRenderer.ModelMatrix = glm.translate(mat4.identity(), position);
                    boxRenderer.ModelMatrix = transform.ModelMatrix;
                }
                //boxRenderer.Initialize();
                boxObj.Renderer = boxRenderer;
                this.boxRenderer = boxRenderer;
            }
            {
                this.BindingObject.Children.Add(boxObj);
            }
        }

        protected override void DoUpdate(double elapsedTime)
        {
            // nothing to do.
        }
    }
}
