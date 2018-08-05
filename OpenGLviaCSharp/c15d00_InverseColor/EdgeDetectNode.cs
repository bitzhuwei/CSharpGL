using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;
using System.Drawing;

namespace c15d00_InverseColor
{
    partial class EdgeDetectNode : PickableNode, IRenderable
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
        private Texture inTexture;
        private Texture outTexture;

        public static EdgeDetectNode Create()
        {
            RenderMethodBuilder compute, render;
            {
                var cs = new CSharpGL.ComputeShader(inverseColorComp);
                var provider = new ShaderArray(cs);
                var map = new AttributeMap();
                compute = new RenderMethodBuilder(provider, map);
            }
            {
                var vs = new VertexShader(vertexCode);
                var fs = new FragmentShader(fragmentCode);
                var provider = new ShaderArray(vs, fs);
                var map = new AttributeMap();
                map.Add(inPosition, RectangleModel.strPosition);
                map.Add(inUV, RectangleModel.strUV);
                render = new RenderMethodBuilder(provider, map);
            }

            var node = new EdgeDetectNode(new RectangleModel(), RectangleModel.strPosition, compute, render);
            node.Initialize();

            return node;
        }

        private EdgeDetectNode(IBufferSource model, string positionNameInIBufferSource, params RenderMethodBuilder[] builders)
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
                this.inTexture = this.GetTexture(bitmap);
                this.InitIntermediateTexture();

                bitmap.Dispose();
            }
        }

        private void InitIntermediateTexture()
        {
            var storage = new TexStorage2D(TexStorage2D.Target.Texture2D, GL.GL_RGBA32F, width, height, 8);
            var texture = new Texture(storage);
            texture.Initialize();

            this.outTexture = texture;
        }

        private Texture GetTexture(Bitmap bitmap)
        {
            bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);

            var texture = new Texture(new TexImageBitmap(bitmap, GL.GL_RGBA32F));
            texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_CLAMP_TO_EDGE));
            texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_CLAMP_TO_EDGE));
            texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_CLAMP_TO_EDGE));
            texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR));
            texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR));

            texture.Initialize();

            return texture;
        }

        #region IRenderable 成员

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
            uint inputUnit = 0, outputUnit = 1;
            {
                RenderMethod method = this.RenderUnit.Methods[0];
                ShaderProgram computeProgram = method.Program;
                // Activate the compute program and bind the output texture image
                computeProgram.Bind();
                glBindImageTexture(inputUnit, this.inTexture.Id, 0, false, 0, GL.GL_READ_WRITE, GL.GL_RGBA32F);
                glBindImageTexture(outputUnit, this.outTexture.Id, 0, false, 0, GL.GL_READ_WRITE, GL.GL_RGBA32F);
                // Dispatch
                glDispatchCompute(1, width, 1);
                glMemoryBarrier(GL.GL_SHADER_IMAGE_ACCESS_BARRIER_BIT);
                computeProgram.Unbind();
            }
            {
                ICamera camera = arg.Camera;
                mat4 projection = camera.GetProjectionMatrix();
                mat4 view = camera.GetViewMatrix();
                mat4 model = this.GetModelMatrix();

                var method = this.RenderUnit.Methods[1]; // the only render unit in this node.
                ShaderProgram program = method.Program;
                program.SetUniform(tex, this.outTexture);
                program.SetUniform(projectionMatrix, projection);
                program.SetUniform(viewMatrix, view);
                program.SetUniform(modelMatrix, model);

                method.Render();
            }
        }

        public void RenderAfterChildren(RenderEventArgs arg)
        {
        }

        #endregion

        public void SetTexture(Bitmap bitmap)
        {
            var bmp = new Bitmap(bitmap, width, height);
            this.inTexture = GetTexture(bmp);
        }

    }
}
