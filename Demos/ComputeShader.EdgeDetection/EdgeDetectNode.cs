using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;
using System.Drawing;

namespace ComputeShader.EdgeDetection
{
    partial class EdgeDetectNode : SceneNodeBase, IRenderable, ITextureSource
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
        private ShaderProgram program;
        private Texture texture;
        private Texture intermediateTexture;
        private Texture finalTexture;

        public EdgeDetectNode()
        {
            var cs = new CSharpGL.ComputeShader(computeShader);
            var shaders = new ShaderArray(cs);
            this.program = shaders.GetShaderProgram();

            var bitmap = new Bitmap(100, 100);
            using (var g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.Red);
                g.DrawString("CSharpGL", new Font("宋体", 18F), new SolidBrush(Color.Gold), new PointF(0, 40));
            }
            this.UpdateTexture(bitmap);
            bitmap.Dispose();

            InitIntermediateTexture();
            InitFinalTexture();
        }

        private void InitFinalTexture()
        {
            var storage = new TexStorage2D(TexStorage2D.Target.Texture2D, 0, GL.GL_RGBA, 512, 512);
            var texture = new Texture(TextureTarget.Texture2D, storage);
            texture.Initialize();

            this.finalTexture = texture;
        }

        private void InitIntermediateTexture()
        {
            var storage = new TexStorage2D(TexStorage2D.Target.Texture2D, 0, GL.GL_RGBA, 512, 512);
            var texture = new Texture(TextureTarget.Texture2D, storage);
            texture.Initialize();

            this.intermediateTexture = texture;
        }

        public void UpdateTexture(Bitmap bitmap)
        {
            bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);

            var texture = new Texture(TextureTarget.Texture2D,
                new TexImage2D(TexImage2D.Target.Texture2D, 0, GL.GL_RGBA, bitmap.Width, bitmap.Height, 0, GL.GL_BGRA, GL.GL_UNSIGNED_BYTE, new ImageDataProvider(bitmap)));
            texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_CLAMP_TO_EDGE));
            texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_CLAMP_TO_EDGE));
            texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_CLAMP_TO_EDGE));
            texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR));
            texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR));

            texture.Initialize();

            this.texture = texture;
        }
        #region IRenderable 成员

        public ThreeFlags EnableRendering { get { return ThreeFlags.BeforeChildren | ThreeFlags.Children; } set { } }

        public void RenderBeforeChildren(RenderEventArgs arg)
        {
            ShaderProgram computeProgram = this.program;
            // Activate the compute program and bind the output texture image
            computeProgram.Bind();
            glBindImageTexture((uint)computeProgram.GetUniformLocation("input_image"), this.texture.Id, 0, false, 0, GL.GL_READ_WRITE, GL.GL_RGBA32F);
            glBindImageTexture((uint)computeProgram.GetUniformLocation("output_image"), this.intermediateTexture.Id, 0, false, 0, GL.GL_READ_WRITE, GL.GL_RGBA32F);
            // Dispatch
            glDispatchCompute(1, 512, 1);
            glMemoryBarrier(GL.GL_SHADER_IMAGE_ACCESS_BARRIER_BIT);
            computeProgram.Unbind();

            computeProgram.Bind();
            glBindImageTexture((uint)computeProgram.GetUniformLocation("input_image"), this.intermediateTexture.Id, 0, false, 0, GL.GL_READ_WRITE, GL.GL_RGBA32F);
            glBindImageTexture((uint)computeProgram.GetUniformLocation("output_image"), this.finalTexture.Id, 0, false, 0, GL.GL_READ_WRITE, GL.GL_RGBA32F);
            // Dispatch
            glDispatchCompute(1, 512, 1);
            glMemoryBarrier(GL.GL_SHADER_IMAGE_ACCESS_BARRIER_BIT);
            computeProgram.Unbind();
        }

        public void RenderAfterChildren(RenderEventArgs arg)
        {
        }

        #endregion

        #region ITextureSource 成员

        public Texture BindingTexture
        {
            //get { return this.finalTexture; }
            get { return this.intermediateTexture; }
            //get { return this.texture; }
        }

        #endregion
    }
}
