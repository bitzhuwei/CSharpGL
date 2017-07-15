using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpGL;

namespace ShadowMapping
{
    /// <summary>
    /// render a teapot only with vertex shader.
    /// </summary>
    class DepthTextureRenderer : Renderer, IShadowMapping
    {

        private const string inPosition = "inPosition";
        private const string projectionMatrix = "projectionMatrix";
        private const string viewMatrix = "viewMatrix";
        private const string modelMatrix = "modelMatrix";

        private const string vertexCode =
            @"#version 330 core

in vec3 " + inPosition + @";

uniform mat4 " + projectionMatrix + @";
uniform mat4 " + viewMatrix + @";
uniform mat4 " + modelMatrix + @";

void main(void) {
	gl_Position = projectionMatrix * viewMatrix * modelMatrix * vec4(inPosition, 1.0);
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
        public static DepthTextureRenderer Create()
        {
            var vertexShader = new VertexShader(vertexCode, inPosition);
            //var fragmentShader = new FragmentShader(fragmentCode);
            //var provider = new ShaderArray(vertexShader, fragmentShader);
            var provider = new ShaderArray(vertexShader);
            var map = new AttributeMap();
            map.Add(inPosition, Teapot.strPosition);
            var renderer = new DepthTextureRenderer(new Teapot(), provider, map);
            renderer.Initialize();

            return renderer;
        }

        private DepthTextureRenderer(Teapot model, IShaderProgramProvider shaderProgramProvider,
            AttributeMap attributeMap, params GLState[] switches)
            : base(model, shaderProgramProvider, attributeMap, switches)
        {
            this.ModelSize = model.GetModelSize();
        }

        #region IRenderable 成员

        public float RotateSpeed { get; set; }

        protected override void DoRender(RenderEventArgs arg)
        {
            this.RotationAngle += this.RotateSpeed;

            ICamera camera = arg.CameraStack.Peek();
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();
            this.SetUniform(projectionMatrix, projection);
            this.SetUniform(viewMatrix, view);
            this.SetUniform(modelMatrix, model);

            base.DoRender(arg);
        }

        #endregion


        #region IShadowMapping 成员

        public bool EnableShadowMapping { get { return true; } set { } }

        public void CastShadow(RenderEventArgs arg)
        {
            this.RotationAngle += this.RotateSpeed;

            ICamera camera = arg.CameraStack.Peek();
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();
            this.SetUniform(projectionMatrix, projection);
            this.SetUniform(viewMatrix, view);
            this.SetUniform(modelMatrix, model);

            base.DoRender(arg);
        }

        #endregion
    }
}
