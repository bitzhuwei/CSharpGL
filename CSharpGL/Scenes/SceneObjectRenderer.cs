using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public class SceneObjectRenderer : Component, IRenderable
    {
        const string projection = "projection";
        const string view = "view";
        const string model = "model";
        //uint projectionLocation;
        //uint viewLocation;
        //uint modelLocation;

        public Renderer Renderer { get; private set; }

        public SceneObjectRenderer(
            IBufferable bufferable, ShaderCode[] shaderCodes,
            PropertyNameMap propertyNameMap, params GLSwitch[] switches)
            : base(null)
        {
            this.Renderer = new Renderer(bufferable, shaderCodes, propertyNameMap, switches);
            this.Renderer.Initialize();
        }
        public SceneObjectRenderer(SceneObject bindingObject,
           IBufferable bufferable, ShaderCode[] shaderCodes,
           PropertyNameMap propertyNameMap, params GLSwitch[] switches)
            : base(bindingObject)
        {
            this.Renderer = new Renderer(bufferable, shaderCodes, propertyNameMap, switches);
            this.Renderer.Initialize();
        }

        //protected override void DoInitialize()
        //{
        //    base.DoInitialize();

        //    int location;
        //    location = this.shaderProgram.GetUniformLocation(projection);
        //    if (location < 0)
        //    { throw new Exception(string.Format("No uniform found for the name [{0}]", projection)); }
        //    else
        //    { this.projectionLocation = (uint)location; }
        //    location = this.shaderProgram.GetUniformLocation(view);
        //    if (location < 0)
        //    { throw new Exception(string.Format("No uniform found for the name [{0}]", view)); }
        //    else
        //    { this.viewLocation = (uint)location; }
        //    location = this.shaderProgram.GetUniformLocation(model);
        //    if (location < 0)
        //    { throw new Exception(string.Format("No uniform found for the name [{0}]", model)); }
        //    else
        //    { this.modelLocation = (uint)location; }

        //}

        public void Render(RenderEventArgs arg)
        {
            SceneObject bindingObject = this.BindingObject;
            Renderer renderer = this.Renderer;
            if (bindingObject != null && renderer != null)
            {
                mat4 projectionMatrix = arg.Camera.GetProjectionMat4();
                mat4 viewMatrix = arg.Camera.GetViewMat4();
                mat4 modelMatrix;

                SceneObject parent = bindingObject.Parent;
                if (parent != null)
                {
                    modelMatrix = bindingObject.Transform.GetMatrix() * parent.Transform.GetMatrix();
                }
                else
                {
                    modelMatrix = bindingObject.Transform.GetMatrix();
                }

                {
                    renderer.SetUniform(projection, projectionMatrix);
                    renderer.SetUniform(view, viewMatrix);
                    renderer.SetUniform(model, modelMatrix);
                }

                renderer.Render(arg);
            }
        }
    }
}
