using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public class SceneObjectRenderer : Renderer
    {
        const string projection = "projection";
        const string view = "view";
        const string model = "model";
        //uint projectionLocation;
        //uint viewLocation;
        //uint modelLocation;

        public SceneObject Owner { get; set; }

        public SceneObjectRenderer(SceneObject owner,
            IBufferable bufferable, ShaderCode[] shaderCodes,
            PropertyNameMap propertyNameMap, params GLSwitch[] switches)
            : base(bufferable, shaderCodes, propertyNameMap, switches)
        {
            this.Owner = owner;
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

        protected override void DoRender(RenderEventArgs arg)
        {
            SceneObject owner = this.Owner;
            if (owner != null)
            {
                mat4 projectionMatrix = arg.Camera.GetProjectionMat4();
                mat4 viewMatrix = arg.Camera.GetViewMat4();
                mat4 modelMatrix;

                SceneObject parent = owner.Parent;
                if (parent != null)
                {
                    modelMatrix = owner.Transform.GetMatrix() * parent.Transform.GetMatrix();
                }
                else
                {
                    modelMatrix = owner.Transform.GetMatrix();
                }

                {
                    this.SetUniform(projection, projectionMatrix);
                    this.SetUniform(view, viewMatrix);
                    this.SetUniform(model, modelMatrix);
                }

                base.DoRender(arg);
            }
        }
    }
}
