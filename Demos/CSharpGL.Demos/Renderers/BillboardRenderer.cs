using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;


namespace CSharpGL.Demos
{

    class BillboardRenderer : Renderer
    {

        public static BillboardRenderer GetRenderer(IBufferable model)
        {
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\billboard.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(File.ReadAllText(@"shaders\billboard.frag"), ShaderType.FragmentShader);
            var map = new PropertyNameMap();
            map.Add("in_Positions", BillboardModel.strPosition);
            var billboardRenderer = new BillboardRenderer(model, shaderCodes, map);
            return billboardRenderer;
        }
        private double currentTime;

        public MovableRenderer TargetRenderer { get; set; }

        public vec3 Offset { get; set; }

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
            set { percentageRecord.Set(ref percentage, value); }
        }

        private UpdatingRecord pixelSizeRecord = new UpdatingRecord();
        private vec2 pixelSize;
        /// <summary>
        /// 
        /// </summary>
        public vec2 PixelSize
        {
            get { return pixelSize; }
            set { pixelSizeRecord.Set(ref  pixelSize, value); }
        }

        public BillboardType Type { get; set; }

        public BillboardRenderer(IBufferable bufferable, ShaderCode[] shaderCodes,
            PropertyNameMap propertyNameMap, params GLSwitch[] switches)
            : base(bufferable, shaderCodes, propertyNameMap, switches)
        {
            this.Offset = new vec3(0, 0.4f, 0);
            this.Width = 1.0f; this.Height = 0.125f;
            this.Percentage = new vec2(0.2f, 0.05f);
            this.PixelSize = new vec2(100, 10);
        }

        protected override void DoInitialize()
        {
            base.DoInitialize();

            var texture = new sampler2D();
            var bitmap = new Bitmap(@"Textures\ExampleBillboard.png");
            texture.Initialize(bitmap);
            bitmap.Dispose();
            this.SetUniform("myTextureSampler", new samplerValue(BindTextureTarget.Texture2D, texture.Id, OpenGL.GL_TEXTURE0));
        }

        protected override void DoRender(RenderEventArg arg)
        {
            if (this.TargetRenderer == null) { return; }

            mat4 projection = arg.Camera.GetProjectionMat4();
            mat4 view = arg.Camera.GetViewMat4();
            this.SetUniform("CameraRight_worldspace", new vec3(
                view[0][0], view[1][0], view[2][0]));
            this.SetUniform("CameraUp_worldspace", new vec3(
                view[0][1], view[1][1], view[2][1]));
            this.SetUniform("billboardCenter_worldspace",
                this.TargetRenderer.Position + this.Offset);
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

    enum BillboardType
    {
        Pixel = 0,
        Physical = 1,
        Percentage = 2,
    }
}