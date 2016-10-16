using System.Drawing;
using System.IO;

namespace CSharpGL.Demos
{
    /// <summary>
    /// Klein bottle.
    /// </summary>
    [DemoRenderer]
    internal class TrefoilKnotRenderer : PickableRenderer
    {
        public static TrefoilKnotRenderer Create(TrefoilKnotModel model)
        {
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\TrefoilKnotRenderer\TrefoilKnot.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(File.ReadAllText(@"shaders\TrefoilKnotRenderer\TrefoilKnot.frag"), ShaderType.FragmentShader);
            var map = new AttributeMap();
            map.Add("in_Position", TrefoilKnotModel.strPosition);
            map.Add("in_TexCoord", TrefoilKnotModel.strTexCoord);
            var renderer = new TrefoilKnotRenderer(model, shaderCodes, map, TrefoilKnotModel.strPosition);
            renderer.ModelSize = model.Lengths;

            return renderer;
        }

        private TrefoilKnotRenderer(IBufferable model, ShaderCode[] shaderCodes,
            AttributeMap attributeMap, string positionNameInIBufferable, params GLSwitch[] switches)
            : base(model, shaderCodes, attributeMap, positionNameInIBufferable, switches)
        {
            this.switchList.Add(new LineWidthSwitch(3));
            this.switchList.Add(new PointSizeSwitch(3));
        }

        protected override void DoInitialize()
        {
            base.DoInitialize();

            var bitmap = new Bitmap(@"Resources\data\TrefoilKnot.png");
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

        private long modelTicks;

        protected override void DoRender(RenderEventArgs arg)
        {
            mat4 projection = arg.Camera.GetProjectionMatrix();
            mat4 view = arg.Camera.GetViewMatrix();
            this.SetUniform("projectionMatrix", projection);
            this.SetUniform("viewMatrix", view);
            MarkableStruct<mat4> model = this.GetModelMatrix();
            if (this.modelTicks != model.UpdateTicks)
            {
                this.SetUniform("modelMatrix", model.Value);
                this.modelTicks = model.UpdateTicks;
            }

            //this.SetUniform("uniformColor", this.uniformColor);

            base.DoRender(arg);
        }
    }
}