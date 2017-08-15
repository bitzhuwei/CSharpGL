using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;
using System.Drawing;

namespace ComputeShader.EdgeDetection
{
    partial class EdgeDetectNode : PickableNode
    {
        private static readonly GLDelegates.void_uint glMemoryBarrier;
        private static readonly GLDelegates.void_uint_uint_int_bool_int_uint_uint glBindImageTexture;
        private static readonly GLDelegates.void_uint_uint_uint glDispatchCompute;
        static EdgeDetectNode()
        {
            glMemoryBarrier = GL.Instance.GetDelegateFor("glMemoryBarrier", GLDelegates.typeof_void_uint) as GLDelegates.void_uint;
            glBindImageTexture = GL.Instance.GetDelegateFor("glBindImageTexture", GLDelegates.typeof_void_uint_uint_int_bool_int_uint_uint) as GLDelegates.void_uint_uint_int_bool_int_uint_uint;
            glDispatchCompute = GL.Instance.GetDelegateFor("glDispatchCompute", GLDelegates.typeof_void_uint_uint_uint) as GLDelegates.void_uint_uint_uint;
        }

        private const int width = 512;
        private const int height = 512;
        private Texture texture;
        private Texture intermediateTexture;
        private Texture finalTexture;

        public static EdgeDetectNode Create()
        {
            RenderUnitBuilder compute, render;
            {
                var cs = new CSharpGL.ComputeShader(computeShader);
                var provider = new ShaderArray(cs);
                var map = new AttributeMap();
                compute = new RenderUnitBuilder(provider, map);
            }
            {
                var vs = new VertexShader(vertexCode, inPosition, inUV);
                var fs = new FragmentShader(fragmentCode);
                var provider = new ShaderArray(vs, fs);
                var map = new AttributeMap();
                map.Add(inPosition, RectangleModel.strPosition);
                map.Add(inUV, RectangleModel.strUV);
                render = new RenderUnitBuilder(provider, map);
            }

            var node = new EdgeDetectNode(new RectangleModel(), RectangleModel.strPosition, compute, render);
            node.Initialize();

            return node;
        }

        private EdgeDetectNode(IBufferSource model, string positionNameInIBufferSource, params RenderUnitBuilder[] builders)
            : base(model, positionNameInIBufferSource, builders)
        {
        }

        protected override void DoInitialize()
        {
            base.DoInitialize();

            {
                var bitmap = new Bitmap(width, height);
                using (var g = Graphics.FromImage(bitmap))
                {
                    g.Clear(Color.Red);
                    g.DrawString("CSharpGL", new Font("宋体", 88F), new SolidBrush(Color.Gold), new PointF(0, height / 2));
                }
                this.texture = this.GetTexture(bitmap);
                this.InitIntermediateTexture();
                this.InitFinalTexture();

                bitmap.Dispose();
            }

            {
                var renderUnit = this.RenderUnits[1]; // the only render unit in this node.
                ShaderProgram program = renderUnit.Program;
                program.SetUniform(tex, this.finalTexture);
            }
        }

        private void InitFinalTexture()
        {
            var storage = new TexStorage2D(TexStorage2D.Target.Texture2D, 8, GL.GL_RGBA32F, width, height);
            var texture = new Texture(TextureTarget.Texture2D, storage);
            texture.Initialize();

            this.finalTexture = texture;
        }

        private void InitIntermediateTexture()
        {
            var storage = new TexStorage2D(TexStorage2D.Target.Texture2D, 8, GL.GL_RGBA32F, width, height);
            var texture = new Texture(TextureTarget.Texture2D, storage);
            texture.Initialize();

            this.intermediateTexture = texture;
        }

        private Texture GetTexture(Bitmap bitmap)
        {
            bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);

            var texture = new Texture(TextureTarget.Texture2D,
                new TexImage2D(TexImage2D.Target.Texture2D, 0, GL.GL_RGBA32F, bitmap.Width, bitmap.Height, 0, GL.GL_BGRA, GL.GL_UNSIGNED_BYTE, new ImageDataProvider(bitmap)));
            texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_CLAMP_TO_EDGE));
            texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_CLAMP_TO_EDGE));
            texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_CLAMP_TO_EDGE));
            texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR));
            texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR));

            texture.Initialize();

            return texture;
        }

        #region IRenderable 成员

        public override void RenderBeforeChildren(RenderEventArgs arg)
        {
            {
                RenderUnit unit = this.RenderUnits[0];
                ShaderProgram computeProgram = unit.Program;
                // Activate the compute program and bind the output texture image
                computeProgram.Bind();
                glBindImageTexture((uint)computeProgram.GetUniformLocation("input_image"), this.texture.Id, 0, false, 0, GL.GL_READ_WRITE, GL.GL_RGBA32F);
                glBindImageTexture((uint)computeProgram.GetUniformLocation("output_image"), this.intermediateTexture.Id, 0, false, 0, GL.GL_READ_WRITE, GL.GL_RGBA32F);
                // Dispatch
                glDispatchCompute(1, width, 1);
                glMemoryBarrier(GL.GL_SHADER_IMAGE_ACCESS_BARRIER_BIT);
                computeProgram.Unbind();

                computeProgram.Bind();
                glBindImageTexture((uint)computeProgram.GetUniformLocation("input_image"), this.intermediateTexture.Id, 0, false, 0, GL.GL_READ_WRITE, GL.GL_RGBA32F);
                glBindImageTexture((uint)computeProgram.GetUniformLocation("output_image"), this.finalTexture.Id, 0, false, 0, GL.GL_READ_WRITE, GL.GL_RGBA32F);
                // Dispatch
                glDispatchCompute(1, height, 1);
                glMemoryBarrier(GL.GL_SHADER_IMAGE_ACCESS_BARRIER_BIT);
                computeProgram.Unbind();
            }
            {
                ICamera camera = arg.CameraStack.Peek();
                mat4 projection = camera.GetProjectionMatrix();
                mat4 view = camera.GetViewMatrix();
                mat4 model = this.GetModelMatrix();

                var renderUnit = this.RenderUnits[1]; // the only render unit in this node.
                ShaderProgram program = renderUnit.Program;
                program.SetUniform(tex, this.finalTexture);
                program.SetUniform(projectionMatrix, projection);
                program.SetUniform(viewMatrix, view);
                program.SetUniform(modelMatrix, model);

                renderUnit.Render();
            }
        }

        public override void RenderAfterChildren(RenderEventArgs arg)
        {
        }

        #endregion

        public void SetTexture(Bitmap bitmap)
        {
            var bmp = new Bitmap(bitmap, width, height);
            this.texture = GetTexture(bmp);
        }

    }
}
