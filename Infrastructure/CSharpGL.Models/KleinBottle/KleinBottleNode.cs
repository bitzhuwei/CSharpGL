using System.Drawing;
using System.IO;

namespace CSharpGL
{
    /// <summary>
    /// Klein bottle.
    /// </summary>
    public partial class KleinBottleNode : PickableNode
    {
        public static KleinBottleNode Create(KleinBottleModel model)
        {
            var vs = new VertexShader(vertexShaderCode);
            var fs = new FragmentShader(fragmentShaderCode);
            var provider = new ShaderArray(vs, fs);
            var map = new AttributeMap();
            map.Add("in_Position", KleinBottleModel.strPosition);
            map.Add("in_TexCoord", KleinBottleModel.strTexCoord);
            var builder = new RenderMethodBuilder(provider, map, new LineWidthState(3));
            var node = new KleinBottleNode(model, KleinBottleModel.strPosition, builder);
            node.ModelSize = model.Size;
            node.Initialize();

            return node;
        }

        private KleinBottleNode(IBufferSource model, string positionNameInIBufferSource, params RenderMethodBuilder[] builders)
            : base(model, positionNameInIBufferSource, builders)
        {
        }

        protected override void DoInitialize()
        {
            base.DoInitialize();

            var bmp = new Bitmap(@"KleinBottle\KleinBottle.png");
            var texture = new Texture(new TexImage1D(GL.GL_RGBA, bmp.Width, GL.GL_BGRA, GL.GL_UNSIGNED_BYTE, new ImageDataProvider(bmp)));
            texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_CLAMP_TO_EDGE));
            texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_CLAMP_TO_EDGE));
            texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_CLAMP_TO_EDGE));
            texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR));
            texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR));
            texture.Initialize();
            bmp.Dispose();

            var method = this.RenderUnit.Methods[0];
            ShaderProgram program = method.Program;
            program.SetUniform("tex", texture);
        }

        public override void RenderBeforeChildren(RenderEventArgs arg)
        {
            ICamera camera = arg.CameraStack.Peek();
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();

            var method = this.RenderUnit.Methods[0];
            ShaderProgram program = method.Program;
            program.SetUniform("projectionMatrix", projection);
            program.SetUniform("viewMatrix", view);
            program.SetUniform("modelMatrix", model);

            method.Render();
        }

        public override void RenderAfterChildren(RenderEventArgs arg)
        {
        }
    }
}