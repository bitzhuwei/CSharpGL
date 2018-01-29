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

        public DesignModeAssist(WinGLCanvas canvas)
            : this(canvas, true, System.ComponentModel.LicenseUsageMode.Designtime)
        {
        }

        public DesignModeAssist(WinGLCanvas canvas, bool designMode, System.ComponentModel.LicenseUsageMode licenseUsageMode)
        {
            var camera = new Camera(new vec3(0, 0, 4), new vec3(0, 0, 0), new vec3(0, 1, 0), CameraType.Perspecitive, canvas.Width, canvas.Height);
            GroupNode group;
            {
                group = new GroupNode();
                if (designMode)
                {
                    var propeller = new PropellerRenderer() { WorldPosition = new vec3(0, -1.5f, 0) };
                    group.Children.Add(propeller);
                }
                if (licenseUsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
                {
                    var clock = new ClockNode();
                    group.Children.Add(clock);
                }
            }
            var scene = new Scene(camera)
            {
                ClearColor = Color.Black.ToVec4(),
                RootNode = group,
            };

            this.scene = scene;

            var list = new ActionList();
            var transformAction = new TransformAction(scene.RootNode);
            list.Add(transformAction);
            var renderAction = new RenderAction(scene);
            list.Add(renderAction);
            this.actionList = list;

            this.fullname = canvas.GetType().FullName;
        }

        public void Render(bool drawText, int height, double fps, IGLCanvas canvas)
        {
            this.actionList.Act(new ActionParams(Viewport.GetCurrent()));

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
