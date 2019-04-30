using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;
using System.Drawing;

namespace PBR.IBLSpecular {
    partial class BRDFNode : ModernNode, IRenderable {
        public static BRDFNode Create(Texture texBRDF) {
            var model = new QuadModel();
            var vs = new VertexShader(vertexCode);
            var fs = new FragmentShader(fragmentCode);
            var array = new ShaderArray(vs, fs);
            var map = new AttributeMap();
            map.Add("aPos", QuadModel.strPosition);
            map.Add("aTexCoords", QuadModel.strTexCoord);
            var builder = new RenderMethodBuilder(array, map);
            var node = new BRDFNode(model, builder);
            node.ModelSize = new vec3(2, 2, 2);
            node.texBRDF = texBRDF;
            node.Initialize();

            return node;
        }

        private BRDFNode(IBufferSource model, params RenderMethodBuilder[] builders)
            : base(model, builders) {
        }

        // pbr: set up projection and view matrices for capturing data onto the 6 cubemap face directions
        mat4 captureProjection = glm.perspective((float)(Math.PI / 2.0), 1.0f, 0.1f, 10.0f);
        mat4[] captureViews =
		{
			glm.lookAt(new vec3(0.0f, 0.0f, 0.0f), new vec3( 1.0f,  0.0f,  0.0f), new vec3(0.0f, -1.0f,  0.0f)),
			glm.lookAt(new vec3(0.0f, 0.0f, 0.0f), new vec3(-1.0f,  0.0f,  0.0f), new vec3(0.0f, -1.0f,  0.0f)),
			glm.lookAt(new vec3(0.0f, 0.0f, 0.0f), new vec3( 0.0f,  1.0f,  0.0f), new vec3(0.0f,  0.0f,  1.0f)),
			glm.lookAt(new vec3(0.0f, 0.0f, 0.0f), new vec3( 0.0f, -1.0f,  0.0f), new vec3(0.0f,  0.0f, -1.0f)),
			glm.lookAt(new vec3(0.0f, 0.0f, 0.0f), new vec3( 0.0f,  0.0f,  1.0f), new vec3(0.0f, -1.0f,  0.0f)),
			glm.lookAt(new vec3(0.0f, 0.0f, 0.0f), new vec3( 0.0f,  0.0f, -1.0f), new vec3(0.0f, -1.0f,  0.0f))
		};
        protected unsafe override void DoInitialize() {
            base.DoInitialize();
            // pbr: generate a 2D LUT from the BRDF equations used.
            // then re-configure capture framebuffer object and render screen-space quad with BRDF shader.
            // pbr: setup framebuffer
            var captureFBO = new Framebuffer(512, 512);
            captureFBO.Bind();
            var captureRBO = new Renderbuffer(512, 512, GL.GL_DEPTH_COMPONENT24);
            captureFBO.Attach(FramebufferTarget.Framebuffer, captureRBO, AttachmentLocation.Depth);
            captureFBO.Attach(FramebufferTarget.Framebuffer, this.texBRDF, 0u);
            captureFBO.CheckCompleteness();
            captureFBO.Unbind();

            RenderMethod method = this.RenderUnit.Methods[0];
            ViewportSwitch viewportSwitch = new ViewportSwitch(0, 0, 512, 512);
            viewportSwitch.On();
            captureFBO.Bind();
            GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            method.Render();
            captureFBO.Unbind();
            viewportSwitch.Off();
            captureFBO.Dispose();
        }

        private Texture texBRDF;

        private ThreeFlags enableRendering = ThreeFlags.None;//  ThreeFlags.BeforeChildren | ThreeFlags.Children | ThreeFlags.AfterChildren;
        /// <summary>
        /// Render before/after children? Render children? 
        /// RenderAction cares about this property. Other actions, maybe, maybe not, your choice.
        /// </summary>
        public ThreeFlags EnableRendering {
            get { return this.enableRendering; }
            set { this.enableRendering = value; }
        }

        public void RenderBeforeChildren(RenderEventArgs arg) {
            ICamera camera = arg.Camera;
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();
            mat4 normal = glm.transpose(glm.inverse(view * model));

            RenderMethod method = this.RenderUnit.Methods[0];
            ShaderProgram program = method.Program;

            method.Render();
        }

        public void RenderAfterChildren(RenderEventArgs arg) {
            // nothing to do.
        }
    }
}
