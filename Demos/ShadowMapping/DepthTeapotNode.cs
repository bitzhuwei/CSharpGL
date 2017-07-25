using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace ShadowMapping
{
    /// <summary>
    /// render a teapot only with vertex shader.
    /// </summary>
    class DepthTeapotNode : ModernNode, IShadowMapping
    {
        private const string inPosition = "inPosition";
        private const string mvpMatrix = "mvpMatrix";

        private const string vertexCode =
            @"#version 330

uniform mat4 " + mvpMatrix + @";

layout (location = 0) in vec4 " + inPosition + @";;

void main(void)
{
	gl_Position = mvpMatrix * inPosition;
}
";
        // this fragment shader is not needed.
        //        private const string fragmentCode =
        //            @"#version 330 core
        //
        //layout(location = 0) out float fragmentdepth;
        ////out vec4 out_Color;
        //
        //void main(void) {
        //    fragmentdepth = gl_FragCoord.z;
        //
        //}
        //";

        /// <summary>
        /// Render teapot to framebuffer in modern opengl.
        /// </summary>
        /// <returns></returns>
        public static DepthTeapotNode Create()
        {
            RenderUnitBuilder shadowmapBuilder;
            {
                var vs = new VertexShader(vertexCode, inPosition);
                var provider = new ShaderArray(vs);
                var map = new AttributeMap();
                map.Add(inPosition, Teapot.strPosition);
                shadowmapBuilder = new RenderUnitBuilder(provider, map);
            }
            var model = new Teapot();
            var renderer = new DepthTeapotNode(model, shadowmapBuilder);
            renderer.Initialize();

            return renderer;
        }

        private DepthTeapotNode(Teapot model, params RenderUnitBuilder[] builder)
            : base(model, builder)
        {
            this.ModelSize = model.GetModelSize();
        }

        #region IRenderable 成员

        public float RotateSpeed { get; set; }

        public override void RenderBeforeChildren(RenderEventArgs arg)
        {
        }

        public override void RenderAfterChildren(RenderEventArgs arg)
        {
        }

        #endregion

        #region IShadowMapping 成员

        private bool enableShadowMapping = true;

        public bool EnableShadowMapping
        {
            get { return enableShadowMapping; }
            set { enableShadowMapping = value; }
        }

        public void CastShadow(ShdowMappingEventArgs arg)
        {
            if (!this.IsInitialized) { this.Initialize(); }

            this.RotationAngle += this.RotateSpeed;

            LightBase light = arg.CurrentLight;
            mat4 projection = light.GetProjectionMatrix();
            mat4 view = light.GetViewMatrix();
            mat4 model = this.GetModelMatrix();

            var renderUnit = this.RenderUnits[0]; // shadowmapBuilder.
            ShaderProgram program = renderUnit.Program;
            program.SetUniform(mvpMatrix, projection * view * model);

            renderUnit.Render();
        }

        #endregion

    }
}
