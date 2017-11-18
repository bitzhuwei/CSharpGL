﻿using CSharpGL;
using System;
using System.IO;

namespace ComputeShader.HelloComputeShader
{
    partial class SimpleComputeNode : ModernNode
    {
        private Texture outputTexture;

        private static readonly GLDelegates.void_uint_uint_int_bool_int_uint_uint glBindImageTexture;
        private static readonly GLDelegates.void_uint_uint_uint glDispatchCompute;
        static SimpleComputeNode()
        {
            glBindImageTexture = GL.Instance.GetDelegateFor("glBindImageTexture", GLDelegates.typeof_void_uint_uint_int_bool_int_uint_uint) as GLDelegates.void_uint_uint_int_bool_int_uint_uint;
            glDispatchCompute = GL.Instance.GetDelegateFor("glDispatchCompute", GLDelegates.typeof_void_uint_uint_uint) as GLDelegates.void_uint_uint_uint;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static SimpleComputeNode Create()
        {
            var model = new SimpleCompute();
            RenderMethodBuilder reset, compute, render;
            {
                var cs = new CSharpGL.ComputeShader(resetCompute);
                var map = new AttributeMap();
                var provider = new ShaderArray(cs);
                reset = new RenderMethodBuilder(provider, map);
            }
            {
                var cs = new CSharpGL.ComputeShader(computeShader);
                var map = new AttributeMap();
                var provider = new ShaderArray(cs);
                compute = new RenderMethodBuilder(provider, map);
            }
            {
                var vs = new VertexShader(renderVert, "position");
                var fs = new FragmentShader(renderFrag);
                var provider = new ShaderArray(vs, fs);
                var map = new AttributeMap();
                map.Add("position", SimpleCompute.strPosition);
                render = new RenderMethodBuilder(provider, map);
            }

            var node = new SimpleComputeNode(model, reset, compute, render);
            node.Initialize();

            return node;
        }

        private SimpleComputeNode(IBufferSource model, params RenderMethodBuilder[] builders)
            : base(model, builders)
        { }

        protected override void DoInitialize()
        {
            base.DoInitialize();
            {
                this.GroupX = 1;
                this.GroupY = 1;
                this.GroupZ = 1;
            }
            {
                // This is the texture that the compute program will write into
                var storage = new TexStorage2D(TexStorage2D.Target.Texture2D, GL.GL_RGBA32F, 8, 256, 256);
                var texture = new Texture(storage);
                texture.Initialize();
                this.outputTexture = texture;
            }
            {
                RenderMethod method = this.RenderUnit.Methods[2];
                ShaderProgram program = method.Program;
                program.SetUniform("output_image", this.outputTexture);
            }
        }

        private uint maxX;
        private uint maxY;
        private uint maxZ;
        private uint groupX;

        public uint GroupX
        {
            get { return groupX; }
            set { groupX = value; if (maxX < value) { maxX = value; } }
        }

        private uint groupY;

        public uint GroupY
        {
            get { return groupY; }
            set { groupY = value; if (maxY < value) { maxY = value; } }
        }

        private uint groupZ;

        public uint GroupZ
        {
            get { return groupZ; }
            set { groupZ = value; if (maxZ < value) { maxZ = value; } }
        }

        protected override void DisposeUnmanagedResources()
        {
            this.outputTexture.Dispose();

            base.DisposeUnmanagedResources();
        }

        public override void RenderBeforeChildren(RenderEventArgs arg)
        {
            // reset image
            {
                RenderMethod method = this.RenderUnit.Methods[0];
                ShaderProgram program = method.Program;
                program.Bind();
                glBindImageTexture(0, outputTexture.Id, 0, false, 0, GL.GL_WRITE_ONLY, GL.GL_RGBA32F);
                glDispatchCompute(maxX, maxY, maxZ);
                program.Unbind();
            }

            {
                // Activate the compute program and bind the output texture image
                RenderMethod method = this.RenderUnit.Methods[1];
                ShaderProgram program = method.Program;
                program.Bind();
                glBindImageTexture(0, outputTexture.Id, 0, false, 0, GL.GL_WRITE_ONLY, GL.GL_RGBA32F);
                glDispatchCompute(GroupX, GroupY, GroupZ);
                program.Unbind();
            }
            {
                ICamera camera = arg.CameraStack.Peek();
                mat4 projection = camera.GetProjectionMatrix();
                mat4 view = camera.GetViewMatrix();
                mat4 model = mat4.identity();

                RenderMethod method = this.RenderUnit.Methods[2];
                ShaderProgram program = method.Program;
                program.SetUniform("projectionMatrix", projection);
                program.SetUniform("viewMatrix", view);
                program.SetUniform("modelMatrix", model);

                method.Render();
            }
        }

        public override void RenderAfterChildren(RenderEventArgs arg)
        {
        }
    }
}