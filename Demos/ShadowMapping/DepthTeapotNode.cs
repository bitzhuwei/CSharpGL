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
    class DepthTeapotNode : ModernNode, ISupportShadowMapping
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

        public float RotateSpeed { get; set; }

        #region IShadowMapping 成员

        private TwoFlags enableShadowMapping = TwoFlags.BeforeChildren | TwoFlags.Children;
        public TwoFlags EnableShadowMapping
        {
            get { return enableShadowMapping; }
            set { enableShadowMapping = value; }
        }

        private TwoFlags enableCastShadow = TwoFlags.BeforeChildren | TwoFlags.Children;
        public TwoFlags EnableCastShadow
        {
            get { return enableCastShadow; }
            set { enableCastShadow = value; }
        }

        public void CastShadow(ShadowMappingCastShadowEventArgs arg)
        {
            if (!this.IsInitialized) { this.Initialize(); }

            this.RotationAngle += this.RotateSpeed;

            LightBase light = arg.Light;
            mat4 projection = light.GetProjectionMatrix();
            mat4 view = light.GetViewMatrix();
            mat4 model = this.GetModelMatrix();

            var method = this.RenderUnit.Methods[0]; // shadowmapBuilder.
            ShaderProgram program = method.Program;
            program.SetUniform(mvpMatrix, projection * view * model);

            method.Render();
        }

        private TwoFlags enableRenderUnderLight = TwoFlags.BeforeChildren | TwoFlags.Children;
        /// <summary>
        /// Is extruding shadow enabled for this object and its children?
        /// </summary>
        public TwoFlags EnableRenderUnderLight { get { return this.enableRenderUnderLight; } set { this.enableRenderUnderLight = value; } }

        /// <summary>
        /// Render the node under the specified light.
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="light"></param>
        public void RenderUnderLight(RenderEventArgs arg, LightBase light)
        {

        }

        #endregion

    }
}
