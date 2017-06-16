using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    class DesignModeAssist
    {
        private Scene scene;
        private readonly string fullname;

        public DesignModeAssist(IGLCanvas canvas)
        {
            var camera = new Camera(new vec3(0, 0, 4), new vec3(0, 0, 0), new vec3(0, 1, 0), CameraType.Perspecitive, canvas.Width, canvas.Height);
            RendererGroup group;
            {
                //var box = new PropellerRenderer() { WorldPosition = new vec3(0, -1f, 0) };
                var clock = new ClockRenderer();
                group = new RendererGroup(clock);
            }
            var scene = new Scene(camera, canvas)
            {
                ClearColor = Color.Black,
                RootElement = group,
            };
            this.scene = scene;
            this.fullname = canvas.GetType().FullName;
        }

        public void Render(bool drawText, int height, double fps)
        {
            this.scene.Render();

            FontBitmaps.DrawText(10,
                10, Color.White, "Courier New",// "Courier New",
                25.0f, this.fullname);
            if (drawText)
            {
                FontBitmaps.DrawText(10,
                    height - 20 - 1, Color.Red, "Courier New",// "Courier New",
                    20.0f, string.Format("FPS: {0}", fps.ToShortString()));
            }
        }

        public void Resize(float width, float height)
        {
            this.scene.Camera.AspectRatio = width / height;
        }
    }
}
