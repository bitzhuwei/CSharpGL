﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace FrontToBackPeeling
{
    class QuadNode : ModernNode
    {
        public enum RenderMode { Blend = 0, Final = 1 };

        /// <summary>
        /// 
        /// </summary>
        public RenderMode Mode { get; set; }


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

                RenderMethod method = this.RenderUnit.Methods[(int)RenderMode.Blend];
                ShaderProgram program = method.Program;
                program.SetUniform("tempTexture", value);
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
                map.Add("vVertex", QuadModel.positions);
                blendBuilder = new RenderMethodBuilder(provider, map);
            }
            {
                var vs = new VertexShader(Shaders.blendVert);// reuse blend vertex shader.
                var fs = new FragmentShader(Shaders.finalFrag);
                var provider = new ShaderArray(vs, fs);
                var map = new AttributeMap();
                map.Add("vVertex", QuadModel.positions);
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

        public override void RenderBeforeChildren(RenderEventArgs arg)
        {
            //ICamera camera = arg.CameraStack.Peek();
            //mat4 projection = camera.GetProjectionMatrix();
            //mat4 view = camera.GetViewMatrix();
            //mat4 model = this.GetModelMatrix();

            RenderMethod method = this.RenderUnit.Methods[(int)this.Mode];
            //ShaderProgram program = method.Program;

            method.Render();
        }

        public override void RenderAfterChildren(RenderEventArgs arg)
        {
            throw new NotImplementedException();
        }
    }
}
