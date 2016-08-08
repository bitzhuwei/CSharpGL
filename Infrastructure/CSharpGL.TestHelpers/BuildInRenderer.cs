using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public class BuildInRenderer : Renderer
    {
        public BuildInRenderer(IBufferable bufferable, ShaderCode[] shaderCodes,
            PropertyNameMap propertyNameMap, params GLSwitch[] switches)
            : base(bufferable, shaderCodes, propertyNameMap, switches)
        { }

        protected override void DoRender(RenderEventArg arg)
        {
            this.SetUniform("projection", arg.Camera.GetProjectionMat4());
            this.SetUniform("view", arg.Camera.GetViewMat4());
            this.SetUniform("model", mat4.identity());

            base.DoRender(arg);
        }
    }
}
