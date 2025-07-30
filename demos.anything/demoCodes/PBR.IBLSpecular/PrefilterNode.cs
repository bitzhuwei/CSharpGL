using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;
using System.Drawing;
using System.Diagnostics;

namespace PBR.IBLSpecular {
    partial class PrefilterNode : ModernNode, IRenderable {
        public static PrefilterNode Create(Texture prefilterMap, Texture envCubemap) {
            var model = new CubeModel();
            var program = GLProgram.Create(vertexCode, fragmentCode); Debug.Assert(program != null);
            var map = new AttributeMap();
            map.Add("aPos", CubeModel.strPosition);
            var builder = new RenderMethodBuilder(program, map);
            var node = new PrefilterNode(model, builder);
            node.ModelSize = new vec3(2, 2, 2);
            node.prefilterMap = prefilterMap;
            node.envCubemap = envCubemap;
            node.Initialize();

            return node;
        }

        private PrefilterNode(IBufferSource model, params RenderMethodBuilder[] builders)
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
            // pbr: run a quasi monte-carlo simulation on the environment lighting to create a prefilter (cube)map.
            const uint maxMipLevels = 5;
            var viewport = new ViewportSwitch();
            for (uint mip = 0; mip < maxMipLevels; ++mip) {
                // reisze framebuffer according to mip-level size.
                int mipWidth = (int)(128 * Math.Pow(0.5, mip));
                int mipHeight = (int)(128 * Math.Pow(0.5, mip));
                var captureFBO = new Framebuffer(mipWidth, mipHeight);
                captureFBO.Bind();
                var captureRBO = new Renderbuffer(mipWidth, mipHeight, GL.GL_DEPTH_COMPONENT24);
                captureFBO.Attach(Framebuffer.Target.Framebuffer, captureRBO, AttachmentLocation.Depth);
                captureFBO.CheckCompleteness();
                captureFBO.Unbind();
                viewport.width = mipWidth; viewport.height = mipHeight;
                viewport.On();
                float roughness = (float)mip / (float)(maxMipLevels - 1);
                RenderMethod method = this.RenderUnit.Methods[0];
                GLProgram program = method.Program;
                program.SetUniform("roughness", roughness);
                program.SetUniform("projection", captureProjection);
                program.SetUniform("environmentMap", this.envCubemap);
                var gl = GL.Current; Debug.Assert(gl != null);
                for (uint i = 0; i < 6; ++i) {
                    program.SetUniform("view", captureViews[i]);
                    CubemapFace face = (CubemapFace)(GL.GL_TEXTURE_CUBE_MAP_POSITIVE_X + i);
                    uint location = 0;
                    int level = 0;
                    captureFBO.Bind();
                    captureFBO.Attach(Framebuffer.Target.Framebuffer, location, face, this.prefilterMap, level);
                    captureFBO.CheckCompleteness();
                    captureFBO.Unbind();

                    captureFBO.Bind();
                    gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
                    method.Render();
                    captureFBO.Unbind();
                }

                viewport.Off();
                captureFBO.Dispose();
            }
        }

        private Texture prefilterMap;
        private Texture envCubemap;

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
            GLProgram program = method.Program;
            program.SetUniform("projection", projection);
            program.SetUniform("view", view * model);
            program.SetUniform("environmentMap", this.envCubemap);

            method.Render();
        }

        public void RenderAfterChildren(RenderEventArgs arg) {
            // nothing to do.
        }
    }
}
