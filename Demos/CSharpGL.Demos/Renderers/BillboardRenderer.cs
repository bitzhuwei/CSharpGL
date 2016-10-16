using System;
using System.Drawing;
using System.IO;

namespace CSharpGL.Demos
{
    internal class BillboardRenderer : Renderer
    {
        public static BillboardRenderer Create(IBufferable model)
        {
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\billboard.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(File.ReadAllText(@"shaders\billboard.frag"), ShaderType.FragmentShader);
            var map = new AttributeMap();
            map.Add("in_Positions", BillboardModel.strPosition);
            var billboardRenderer = new BillboardRenderer(model, shaderCodes, map);
            return billboardRenderer;
        }

        private double currentTime;

        public float Width { get; set; }
        public float Height { get; set; }

        private UpdatingRecord percentageRecord = new UpdatingRecord();
        private vec2 percentage;

        /// <summary>
        /// width percentage and height percentage.
        /// </summary>
        public vec2 Percentage
        {
            get { return percentage; }
            set
            {
                if (value != this.percentage)
                {
                    this.percentage = value;
                    this.percentageRecord.Mark();
                }
            }
        }

        private UpdatingRecord pixelSizeRecord = new UpdatingRecord();
        private ivec2 pixelSize;

        /// <summary>
        ///
        /// </summary>
        public ivec2 PixelSize
        {
            get { return pixelSize; }
            set
            {
                if (value != this.pixelSize)
                {
                    this.pixelSize = value;
                    this.pixelSizeRecord.Mark();
                }
            }
        }

        public BillboardType Type { get; set; }

        private BillboardRenderer(IBufferable model, ShaderCode[] shaderCodes,
            AttributeMap attributeMap, params GLSwitch[] switches)
            : base(model, shaderCodes, attributeMap, switches)
        {
            this.Width = 1.0f; this.Height = 0.125f;
            this.Percentage = new vec2(0.2f, 0.05f);
            this.PixelSize = new ivec2(100, 10);
        }

        protected override void DoInitialize()
        {
            base.DoInitialize();

            var bitmap = new Bitmap(@"Textures\ExampleBillboard.png");
            var texture = new Texture(TextureTarget.Texture2D, bitmap, new SamplerParameters());
            texture.Initialize();
            bitmap.Dispose();
            this.SetUniform("myTextureSampler", texture);
        }

        private long modelTicks;

        protected override void DoRender(RenderEventArgs arg)
        {
            mat4 projection = arg.Camera.GetProjectionMatrix();
            mat4 view = arg.Camera.GetViewMatrix();
            this.SetUniform("CameraRight_worldspace", new vec3(
                view[0][0], view[1][0], view[2][0]));
            this.SetUniform("CameraUp_worldspace", new vec3(
                view[0][1], view[1][1], view[2][1]));
            MarkableStruct<mat4> model = this.GetModelMatrix();
            if (this.modelTicks != model.UpdateTicks)
            {
                this.SetUniform("billboardCenter_worldspace", this.WorldPosition);
                this.modelTicks = model.UpdateTicks;
            }
            //this.TargetRenderer.Position + this.Offset);
            this.SetUniform("BillboardSize", new vec2(this.Width, this.Height));
            if (this.percentageRecord.IsMarked())
            {
                this.SetUniform("BillboardSizeInPercentage", this.Percentage);
                this.percentageRecord.CancelMark();
            }
            if (this.pixelSizeRecord.IsMarked())
            {
                this.SetUniform("BillboardSizeInPixelSize", this.PixelSize);
                this.pixelSizeRecord.CancelMark();
            }
            int[] viewport = OpenGL.GetViewport();
            this.SetUniform("ScreenSizeinPixelSize", new vec2(viewport[2], viewport[3]));
            this.SetUniform("billboardType", (float)(this.Type));
            float lifeLevel = (float)(Math.Sin(currentTime) * 0.4 + 0.5); currentTime += 0.1;
            this.SetUniform("LifeLevel", lifeLevel);
            this.SetUniform("projection", projection);
            this.SetUniform("view", view);

            base.DoRender(arg);
        }
    }

    internal enum BillboardType
    {
        Pixel = 0,
        Physical = 1,
        Percentage = 2,
    }
}