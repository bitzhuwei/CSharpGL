using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;
using System.Drawing;

namespace ImageProcessing.GrayFilter
{
    partial class GrayFilterNode : PickableNode
    {
        public static GrayFilterNode Create()
        {
            var model = new GrayFilterModel();
            var vs = new VertexShader(renderVert);
            var fs = new FragmentShader(renderFrag);
            var provider = new ShaderArray(vs, fs);
            var map = new AttributeMap();
            map.Add("a_vertex", GrayFilterModel.position);
            map.Add("a_texCoord", GrayFilterModel.texCoord);
            var builder = new RenderMethodBuilder(provider, map);

            var node = new GrayFilterNode(model, GrayFilterModel.position, builder);
            node.Initialize();

            return node;
        }

        private GrayFilterNode(IBufferSource model, string positionNameInIBufferSource, params RenderMethodBuilder[] builders)
            : base(model, positionNameInIBufferSource, builders)
        {
        }

        protected override void DoInitialize()
        {
            base.DoInitialize();

            var bitmap = new Bitmap(100, 100);
            using (var g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.Red);
                g.DrawString("CSharpGL", new Font("宋体", 18F), new SolidBrush(Color.Gold), new PointF(0, 40));
            }
            this.UpdateTexture(bitmap);
            bitmap.Dispose();
        }

        public void UpdateTexture(Bitmap bitmap)
        {
            bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);

            TexStorageBase storage = new TexImageBitmap(bitmap);
            var texture = new Texture(storage);
            texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_CLAMP_TO_EDGE));
            texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_CLAMP_TO_EDGE));
            texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_CLAMP_TO_EDGE));
            texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR));
            texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR));

            texture.Initialize();

            RenderMethod method = this.RenderUnit.Methods[0];
            ShaderProgram program = method.Program;
            program.SetUniform("u_texture", texture);
        }
        public override void RenderBeforeChildren(RenderEventArgs arg)
        {
            ICamera camera = arg.CameraStack.Peek();
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();

            RenderMethod method = this.RenderUnit.Methods[0];
            ShaderProgram program = method.Program;
            program.SetUniform("mvpMatrix", projection * view * model);

            method.Render();
        }

        public override void RenderAfterChildren(RenderEventArgs arg)
        {
        }
    }

    class GrayFilterModel : IBufferSource
    {
        public const string position = "positoin";
        private VertexBuffer positionBuffer;
        public const string texCoord = "texCoord";
        private VertexBuffer texCoordBuffer;

        private IDrawCommand drawCmd;

        private static readonly vec3[] positions = new vec3[]
        {
            new vec3(-1,  1, 0), new vec3( 1,  1, 0),
            new vec3(-1, -1, 0), new vec3( 1, -1, 0),
        };

        private static readonly vec2[] texCoords = new vec2[]
        {
            new vec2(0, 1), new vec2(1, 1),
            new vec2(0, 0), new vec2(1, 0),
        };

        #region IBufferSource 成员

        public VertexBuffer GetVertexAttributeBuffer(string bufferName)
        {
            if (bufferName == position)
            {
                if (this.positionBuffer == null)
                {
                    this.positionBuffer = positions.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.StaticDraw);
                }

                return this.positionBuffer;
            }
            else if (bufferName == texCoord)
            {
                if (this.texCoordBuffer == null)
                {
                    this.texCoordBuffer = texCoords.GenVertexBuffer(VBOConfig.Vec2, BufferUsage.StaticDraw);
                }

                return this.texCoordBuffer;
            }
            else
            {
                throw new ArgumentException("bufferName");
            }
        }

        public IDrawCommand GetDrawCommand()
        {
            if (this.drawCmd == null)
            {
                this.drawCmd = new DrawArraysCmd(DrawMode.QuadStrip, 0, positions.Length);
            }

            return this.drawCmd;
        }

        #endregion
    }
}
