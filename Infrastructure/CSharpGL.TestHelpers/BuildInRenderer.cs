using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL.TestHelpers;

namespace CSharpGL
{
    public class BuildInRenderer : Renderer, IModelTransform
    {
        /// <summary>
        /// IModelTransform.ModelMatrix
        /// </summary>
        public mat4 ModelMatrix { get; set; }

        public BuildInRenderer(IBufferable bufferable, ShaderCode[] shaderCodes,
            PropertyNameMap propertyNameMap, params GLSwitch[] switches)
            : base(bufferable, shaderCodes, propertyNameMap, switches)
        {
            this.ModelMatrix = mat4.identity();
        }

        protected override void DoRender(RenderEventArg arg)
        {
            this.SetUniform("projection", arg.Camera.GetProjectionMat4());
            this.SetUniform("view", arg.Camera.GetViewMat4());
            this.SetUniform("model", this.ModelMatrix);

            base.DoRender(arg);
        }
    }
}
