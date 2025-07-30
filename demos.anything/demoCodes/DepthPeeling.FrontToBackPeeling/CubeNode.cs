using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using CSharpGL;

namespace DepthPeeling.FrontToBackPeeling {
    class CubeNode : ModernNode, IRenderable {
        public enum RenderMode { Init = 0, Peel = 1 };

        /// <summary>
        /// 
        /// </summary>
        public RenderMode Mode { get; set; }

        private vec4 vColor;
        /// <summary>
        /// 
        /// </summary>
        public vec4 Color {
            get { return vColor; }
            set {
                this.vColor = value;

                for (int i = 0; i < this.RenderUnit.Methods.Length; i++) {
                    RenderMethod method = this.RenderUnit.Methods[i];
                    GLProgram program = method.Program;
                    program.SetUniform("vColor", value);
                }
            }
        }

        private Texture depthTexture;
        /// <summary>
        /// 
        /// </summary>
        public Texture DepthTexture {
            get { return this.depthTexture; }
            set {
                this.depthTexture = value;

                RenderMethod method = this.RenderUnit.Methods[(int)RenderMode.Peel];
                GLProgram program = method.Program;
                program.SetUniform("depthTexture", value);
            }
        }

        public static CubeNode Create(IBufferSource model, string positionNameInIBufferSource) {
            RenderMethodBuilder initBuilder, peelBuilder;
            {
                var program = GLProgram.Create(Shaders.initVert, Shaders.initFrag); Debug.Assert(program != null);
                var map = new AttributeMap();
                map.Add("inPosition", positionNameInIBufferSource);
                initBuilder = new RenderMethodBuilder(program, map);
            }
            {
                // reuse blend vertex shader.
                var program = GLProgram.Create(Shaders.peelVert, Shaders.peelFrag); Debug.Assert(program != null);
                var map = new AttributeMap();
                map.Add("inPosition", positionNameInIBufferSource);
                peelBuilder = new RenderMethodBuilder(program, map);
            }

            var node = new CubeNode(model, initBuilder, peelBuilder);
            node.Initialize();

            return node;
        }

        private CubeNode(IBufferSource model, params RenderMethodBuilder[] builders)
            : base(model, builders) {
        }

        private ThreeFlags enableRendering = ThreeFlags.BeforeChildren | ThreeFlags.Children | ThreeFlags.AfterChildren;
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

            RenderMethod method = this.RenderUnit.Methods[(int)this.Mode];
            GLProgram program = method.Program;
            program.SetUniform("mvpMat", projection * view * model);

            method.Render();
        }

        public void RenderAfterChildren(RenderEventArgs arg) {
        }
    }
}
