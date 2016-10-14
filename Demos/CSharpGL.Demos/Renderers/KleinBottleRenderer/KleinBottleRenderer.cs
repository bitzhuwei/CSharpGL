using System.Drawing;
using System.IO;

namespace CSharpGL.Demos
{
    /// <summary>
    /// Klein bottle.
    /// </summary>
    [DemoRenderer]
    internal class KleinBottleRenderer : PickableRenderer
    {
        public static KleinBottleRenderer Create(KleinBottleModel model)
        {
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\KleinBottleRenderer\KleinBottle.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(File.ReadAllText(@"shaders\KleinBottleRenderer\KleinBottle.frag"), ShaderType.FragmentShader);
            var map = new AttributeMap();
            map.Add("in_Position", KleinBottleModel.strPosition);
            map.Add("in_TexCoord", KleinBottleModel.strTexCoord);
            var renderer = new KleinBottleRenderer(model, shaderCodes, map, KleinBottleModel.strPosition);
            renderer.ModelSize = model.Lengths;

            return renderer;
        }

        private KleinBottleRenderer(IBufferable model, ShaderCode[] shaderCodes,
            AttributeMap attributeMap, string positionNameInIBufferable, params GLSwitch[] switches)
            : base(model, shaderCodes, attributeMap, positionNameInIBufferable, switches)
        {
            this.switchList.Add(new LineWidthSwitch(3));
        }

        protected override void DoInitialize()
        {
            base.DoInitialize();

            var bitmap = new Bitmap(@"Resources\data\KleinBottle.png");
            var texture = new Texture(TextureTarget.Texture1D,
                bitmap, new SamplerParameters());
            texture.Initialize();
            bitmap.Dispose();
            this.SetUniform("tex", texture);
        }

        //private vec3 uniformColor = new vec3(1, 1, 1);

        //public Color UniformColor
        //{
        //    get { return uniformColor.ToColor(); }
        //    set { uniformColor = value.ToVec3(); }
        //}
        protected override void DoRender(RenderEventArgs arg)
        {
            mat4 projection = arg.Camera.GetProjectionMatrix();
            mat4 view = arg.Camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();
            this.SetUniform("projectionMatrix", projection);
            this.SetUniform("viewMatrix", view);
            this.SetUniform("modelMatrix", model);
            //this.SetUniform("uniformColor", this.uniformColor);

            base.DoRender(arg);
        }
    }
}