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
    class DepthTeapotNode : ModernNode, ISupportShadow
    {
        private const string inPosition = "inPosition";
        private const string mvpMatrix = "mvpMatrix";

        private const string vertexCode =
            @"#version 330

uniform mat4 " + mvpMatrix + @";

in vec4 " + inPosition + @";

void main(void)
{
	gl_Position = mvpMatrix * inPosition;
}
";
        // this fragment shader is not needed.
        //        private const string fragmentCode =
        //            @"#version 330 core
        //
        //out float fragmentdepth;
        //
        //void main(void) {
        //    fragmentdepth = gl_FragCoord.z;
        //}
        //";

        /// <summary>
        /// Render teapot to framebuffer in modern opengl.
        /// </summary>
        /// <returns></returns>
        public static DepthTeapotNode Create()
        {
            RenderMethodBuilder shadowmapBuilder;
            {
                var vs = new VertexShader(vertexCode);
                var provider = new ShaderArray(vs);
                var map = new AttributeMap();
                map.Add(inPosition, Teapot.strPosition);
                shadowmapBuilder = new RenderMethodBuilder(provider, map);
            }
            var model = new Teapot();
            var node = new DepthTeapotNode(model, shadowmapBuilder);
            node.Initialize();

            return node;
        }

        private DepthTeapotNode(Teapot model, params RenderMethodBuilder[] builder)
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

            var method = this.RenderUnit.Methods[0]; // shadowmapBuilder.
            ShaderProgram program = method.Program;
            program.SetUniform(mvpMatrix, projection * view * model);

            method.Render();
        }

        #endregion

    }
}
