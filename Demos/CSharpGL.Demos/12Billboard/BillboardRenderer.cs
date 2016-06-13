using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Demos
{

    class BillboardRenderer : Renderer
    {
        private double currentTime;

        public MovableRenderer TargetRenderer { get; set; }
        public vec3 Offset { get; set; }

        public float Width { get; set; }
        public float Height { get; set; }

        public float WidthPercentage { get; set; }
        public float HeightPercentage { get; set; }
        public int WidthInPixelSize { get; set; }
        public int HeightInPixelSize { get; set; }
        public BillboardType Type { get; set; }

        public BillboardRenderer(IBufferable bufferable, ShaderCode[] shaderCodes,
            PropertyNameMap propertyNameMap, params GLSwitch[] switches)
            : base(bufferable, shaderCodes, propertyNameMap, switches)
        {
            this.Offset = new vec3(0, 1.2f, 0);
            this.Width = 1.0f; this.Height = 0.125f;
            this.WidthPercentage = 0.2f; this.HeightPercentage = 0.05f;
            this.WidthInPixelSize = 100; this.HeightInPixelSize = 20;
        }

        protected override void DoInitialize()
        {
            base.DoInitialize();
        }

        protected override void DoRender(RenderEventArgs arg)
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
            this.SetUniform("BillboardSizeInPercentage", new vec2(this.WidthPercentage, this.HeightPercentage));
            this.SetUniform("BillboardSizeInPixelSize", new vec2(this.WidthInPixelSize, this.HeightInPixelSize));
            int[] viewport = OpenGL.GetViewport();
            this.SetUniform("ScreenSizeinPixelSize", new vec2(viewport[2], viewport[3]));
            this.SetUniform("billboardType", (float)(this.Type));
            float lifeLevel = (float)(Math.Sin(currentTime) * 0.4 + 0.5); currentTime += 0.1;
            this.SetUniform("LifeLevel", lifeLevel);
            this.SetUniform("projection", projection);
            this.SetUniform("view", view);

            base.DoRender(arg);
        }

        protected override void DisposeUnmanagedResources()
        {
        }

    }

    enum BillboardType
    {
        Physical = 0,
        Percentage = 1,
        Pixel = 2,
    }
}