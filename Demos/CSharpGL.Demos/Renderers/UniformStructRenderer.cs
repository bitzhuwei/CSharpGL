using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;

namespace CSharpGL.Demos
{
    /// <summary>
    /// Demo of how to use uniform block and uniform buffer object.
    /// </summary>
    [DemoRenderer]
    internal class UniformStructRenderer : Renderer
    {
        public static UniformStructRenderer Create()
        {
            var model = new Teapot();
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\UniformStructRenderer\UniformStruct.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(File.ReadAllText(@"shaders\UniformStructRenderer\UniformStruct.frag"), ShaderType.FragmentShader);
            var map = new AttributeMap();
            map.Add("vPos", Teapot.strPosition);
            map.Add("vColor", Teapot.strColor);
            var renderer = new UniformStructRenderer(model, shaderCodes, map);
            renderer.ModelSize = model.Lengths;

            return renderer;
        }

        private GroundRenderer groundRenderer;

        private UniformStructRenderer(IBufferable model, ShaderCode[] shaderCodes,
            AttributeMap attributeMap, params GLSwitch[] switches)
            : base(model, shaderCodes, attributeMap, switches)
        {
            var groundRenderer = GroundRenderer.Create(new GroundModel(20));
            groundRenderer.Scale = new vec3(10, 10, 10);
            this.groundRenderer = groundRenderer;
        }

        protected override void DoInitialize()
        {
            base.DoInitialize();

            this.groundRenderer.Initialize();
        }

        private long modelTicks;

        protected override void DoRender(RenderEventArgs arg)
        {
            mat4 projection = arg.Camera.GetProjectionMatrix();
            mat4 view = arg.Camera.GetViewMatrix();
            this.SetUniform("transformMatrix.projection", projection);
            this.SetUniform("transformMatrix.view", view);
            MarkableStruct<mat4> model = this.GetModelMatrix();
            if (this.modelTicks != model.UpdateTicks)
            {
                this.SetUniform("transformMatrix.model", model.Value);
                this.modelTicks = model.UpdateTicks;
            }

            base.DoRender(arg);

            this.groundRenderer.Render(arg);
        }

        private static Random random = new Random();

        private int testClearBufferDataOrder = 0;
        /// <summary>
        /// Set this property's value to anyhting else to check if the model's color turns into a random pure color.
        /// </summary>
        [Category("Test")]
        [Description("Set this property's value to anyhting else to check if the model's color turns into white.")]
        public int TestClearBufferData
        {
            get { return this.testClearBufferDataOrder; }
            set
            {
                var bufferPtr = this.Model.GetVertexAttributeBufferPtr(Teapot.strColor, string.Empty);
                var array = new UnmanagedArray<vec3>(1);
                // this works slow.
                array[0] = new vec3(
                    (float)random.NextDouble(),
                    (float)random.NextDouble(),
                    (float)random.NextDouble()
                    );
                bufferPtr.ClearBufferData(OpenGL.GL_RGB32F, OpenGL.GL_RGB, OpenGL.GL_FLOAT, array);
                this.testClearBufferDataOrder++;
            }
        }


        private int testClearBufferSubDataOrder = 0;
        /// <summary>
        /// Set this property's value to anyhting else to check if the model's color turns into a random pure color.
        /// </summary>
        [Category("Test")]
        [Description("Set this property's value to anyhting else to check if the model's color turns into white.")]
        public int TestClearBufferSubData
        {
            get { return this.testClearBufferSubDataOrder; }
            set
            {
                var bufferPtr = this.Model.GetVertexAttributeBufferPtr(Teapot.strColor, string.Empty);
                int offset = bufferPtr.ByteLength / 3;
                int size = bufferPtr.ByteLength * 2 / 3;
                var array = new UnmanagedArray<vec3>(1);
                // this works slow.
                array[0] = new vec3(
                    (float)random.NextDouble(),
                    (float)random.NextDouble(),
                    (float)random.NextDouble()
                    );
                bufferPtr.ClearBufferSubData(OpenGL.GL_RGB32F, new IntPtr(offset), (uint)size, OpenGL.GL_RGB, OpenGL.GL_FLOAT, array);
                this.testClearBufferSubDataOrder++;
            }
        }
    }
}