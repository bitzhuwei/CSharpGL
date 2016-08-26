using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL.TestHelpers;
using System.ComponentModel;
using System.Drawing.Design;

namespace CSharpGL
{
    public class BuildInRenderer : Renderer
    {

        public BuildInRenderer(vec3 lengths, IBufferable bufferable, ShaderCode[] shaderCodes,
            PropertyNameMap propertyNameMap, params GLSwitch[] switches)
            : base(bufferable, shaderCodes, propertyNameMap, switches)
        {
            this.Name = bufferable.GetType().Name;
            this.Lengths = lengths;
        }

        protected override void DoRender(RenderEventArgs arg)
        {
            this.SetUniform("projection", arg.Camera.GetProjectionMat4());
            this.SetUniform("view", arg.Camera.GetViewMat4());
            this.SetUniform("model", this.ModelMatrix);

            base.DoRender(arg);
        }
    }
}
