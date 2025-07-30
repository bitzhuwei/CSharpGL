using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using CSharpGL;

namespace DepthPeeling.FrontToBackPeeling {
    class QuadNode : ModernNode, IRenderable {
        public enum RenderMode { Blend = 0, Final = 1 };

        /// <summary>
        /// 
        /// </summary>
        public RenderMode Mode { get; set; }


        private bool useBackground = true;

        public bool UseBackground {
            get { return useBackground; }
            set {
                useBackground = value;
                {
                    RenderMethod method = this.RenderUnit.Methods[(int)RenderMode.Final];
                    GLProgram program = method.Program;
                    program.SetUniform("useBackground", value);
                }
            }
        }

        private Texture tempTexture;
        /// <summary>
        /// 
        /// </summary>
        public Texture TempTexture {
            get { return this.tempTexture; }
            set {
                this.tempTexture = value;
                {
                    RenderMethod method = this.RenderUnit.Methods[(int)RenderMode.Blend];
                    GLProgram program = method.Program;
                    program.SetUniform("tempTexture", value);
                }
                {
                    RenderMethod method = this.RenderUnit.Methods[(int)RenderMode.Final];
                    GLProgram program = method.Program;
                    program.SetUniform("colorTexture", value);
                }
            }
        }

        public static QuadNode Create() {
            RenderMethodBuilder blendBuilder, finalBuilder;
            {
                var program = GLProgram.Create(Shaders.blendVert, Shaders.blendFrag); Debug.Assert(program != null);
                var map = new AttributeMap();
                map.Add("inPosition", QuadModel.positions);
                blendBuilder = new RenderMethodBuilder(program, map);
            }
            {
                // reuse blend vertex shader.
                var program = GLProgram.Create(Shaders.finalVert, Shaders.finalFrag); Debug.Assert(program != null);
                var map = new AttributeMap();
                map.Add("inPosition", QuadModel.positions);
                finalBuilder = new RenderMethodBuilder(program, map);
            }

            var model = new QuadModel();
            var node = new QuadNode(model, blendBuilder, finalBuilder);
            node.Initialize();

            return node;
        }

        private QuadNode(IBufferSource model, params RenderMethodBuilder[] builders)
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

        public unsafe void RenderBeforeChildren(RenderEventArgs arg) {
            //ICamera camera = arg.CameraStack;
            //mat4 projection = camera.GetProjectionMatrix();
            //mat4 view = camera.GetViewMatrix();
            //mat4 model = this.GetModelMatrix();

            RenderMethod method = this.RenderUnit.Methods[(int)this.Mode];
            if (this.Mode == RenderMode.Final) {
                GLProgram program = method.Program;
                var gl = GL.Current; Debug.Assert(gl != null);
                var clearColor = stackalloc float[4];
                gl.glGetFloatv((uint)GetTarget.ColorClearValue, clearColor);
                var value = new vec4(clearColor[0], clearColor[1], clearColor[2], clearColor[3]);
                program.SetUniform("backgroundColor", value);
            }

            method.Render();
        }

        public void RenderAfterChildren(RenderEventArgs arg) {
        }

    }
}
