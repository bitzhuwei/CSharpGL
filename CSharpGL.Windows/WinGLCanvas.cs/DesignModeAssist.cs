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
        private ActionList actionList;
        private readonly string fullname;

        public DesignModeAssist(IGLCanvas canvas)
        {
            var camera = new Camera(new vec3(0, 0, 4), new vec3(0, 0, 0), new vec3(0, 1, 0), CameraType.Perspecitive, canvas.Width, canvas.Height);
            GroupNode group;
            {
                var propeller = new PropellerRenderer() { WorldPosition = new vec3(0, -1.5f, 0) };
                var clock = new ClockRenderer();
                group = new GroupNode(propeller, clock);
            }
            var scene = new Scene(camera, canvas)
            {
                ClearColor = Color.Black.ToVec4(),
                RootElement = group,
            };

            this.scene = scene;

            var list = new ActionList();
            var transformAction = new TransformAction(scene);
            list.Add(transformAction);
            var renderAction = new RenderAction(scene, camera)
            {
                ClearColor = Color.Black.ToVec4(),
            };
            list.Add(renderAction);
            this.actionList = list;

            this.fullname = canvas.GetType().FullName;
        }

        public void Render(bool drawText, int height, double fps)
        {
            this.actionList.Act();

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
