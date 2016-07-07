using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;


namespace CSharpGL.Demos
{
    /// <summary>
    /// 正方形
    /// </summary>
    internal class GroundRenderer : Renderer
    {

        public Color LineColor { get; set; }

        public float Scale { get; set; }

        public GroundRenderer(IBufferable bufferable, ShaderCode[] shaderCodes,
            PropertyNameMap propertyNameMap, params GLSwitch[] switches)
            : base(bufferable, shaderCodes, propertyNameMap, switches)
        {
            this.LineColor = Color.White;
            this.Scale = 1.0f;
        }

        protected override void DoInitialize()
        {
            base.DoInitialize();
        }

        protected override void DoRender(RenderEventArg arg)
        {
            mat4 projection = arg.Camera.GetProjectionMat4();
            mat4 view = arg.Camera.GetViewMat4();
            mat4 model = glm.scale(mat4.identity(), new vec3(this.Scale, this.Scale, this.Scale));
            this.SetUniform("projectionMatrix", projection);
            this.SetUniform("viewMatrix", view);
            this.SetUniform("modelMatrix", model);
            this.SetUniform("lineColor", this.LineColor.ToVec3());
            base.DoRender(arg);
        }
    }
}

