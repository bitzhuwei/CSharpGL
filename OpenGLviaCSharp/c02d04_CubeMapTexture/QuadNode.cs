using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c02d04_CubeMapTexture
{
    class QuadNode : ModernNode, IRenderable
    {
        public enum RenderMode { Blend = 0, Final = 1 };

        /// <summary>
        /// 
        /// </summary>
        public RenderMode Mode { get; set; }


        private bool useBackground = true;

        public bool UseBackground
        {
            get { return useBackground; }
            set
            {
                useBackground = value;
                {
                    RenderMethod method = this.RenderUnit.Methods[(int)RenderMode.Final];
                    ShaderProgram program = method.Program;
                    program.SetUniform("useBackground", value);
                }
            }
        }

        private Texture tempTexture;
        /// <summary>
        /// 
        /// </summary>
        public Texture TempTexture
        {
            get { return this.tempTexture; }
            set
            {
                this.tempTexture = value;
                {
                    RenderMethod method = this.RenderUnit.Methods[(int)RenderMode.Blend];
                    ShaderProgram program = method.Program;
                    program.SetUniform("tempTexture", value);
                }
                {
                    RenderMethod method = this.RenderUnit.Methods[(int)RenderMode.Final];
                    ShaderProgram program = method.Program;
                    program.SetUniform("colorTexture", value);
                }
            }
        }

        public static QuadNode Create()
        {
            RenderMethodBuilder blendBuilder, finalBuilder;
            {
                var vs = new VertexShader(Shaders.blendVert);
                var fs = new FragmentShader(Shaders.blendFrag);
                var provider = new ShaderArray(vs, fs);
                var map = new AttributeMap();
                map.Add("inPosition", QuadModel.positions);
                blendBuilder = new RenderMethodBuilder(provider, map);
            }
            {
                var vs = new VertexShader(Shaders.finalVert);// reuse blend vertex shader.
                var fs = new FragmentShader(Shaders.finalFrag);
                var provider = new ShaderArray(vs, fs);
                var map = new AttributeMap();
                map.Add("inPosition", QuadModel.positions);
                finalBuilder = new RenderMethodBuilder(provider, map);
            }

            var model = new QuadModel();
            var node = new QuadNode(model, blendBuilder, finalBuilder);
            node.Initialize();

            return node;
        }

        private QuadNode(IBufferSource model, params RenderMethodBuilder[] builders)
            : base(model, builders)
        {

        }

        private ThreeFlags enableRendering = ThreeFlags.BeforeChildren | ThreeFlags.Children | ThreeFlags.AfterChildren;
        /// <summary>
        /// Render before/after children? Render children? 
        /// RenderAction cares about this property. Other actions, maybe, maybe not, your choice.
        /// </summary>
        public ThreeFlags EnableRendering
        {
            get { return this.enableRendering; }
            set { this.enableRendering = value; }
        }

        public void RenderBeforeChildren(RenderEventArgs arg)
        {
            //ICamera camera = arg.CameraStack;
            //mat4 projection = camera.GetProjectionMatrix();
            //mat4 view = camera.GetViewMatrix();
            //mat4 model = this.GetModelMatrix();

            RenderMethod method = this.RenderUnit.Methods[(int)this.Mode];
            if (this.Mode == RenderMode.Final)
            {
                ShaderProgram program = method.Program;
                var clearColor = new float[4];
                GL.Instance.GetFloatv((uint)GetTarget.ColorClearValue, clearColor);
                var value = new vec4(clearColor[0], clearColor[1], clearColor[2], clearColor[3]);
                program.SetUniform("backgroundColor", value);
            }

            method.Render();
        }

        public void RenderAfterChildren(RenderEventArgs arg)
        {
        }

    }
}
