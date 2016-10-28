using CSharpGL;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DrvSimu
{
    public partial class DrvSimuControl
    {
        private PointsRenderer pointsRenderer;
        private CrossRenderer crossRenderer;

        private void ScientificCanvas_Load(object sender, EventArgs e)
        {
            var camera = new Camera(new vec3(4, 1.6f, 3), new vec3(0, 0, 0), new vec3(0, 1, 0),
                 CameraType.Ortho, this.Width, this.Height);
            var cameraManipulater = new SatelliteManipulater();
            cameraManipulater.Bind(camera, this);
            this.cameraManipulater = cameraManipulater;

            this.Scene = new Scene(camera, this);
            {
                var pointsRenderer = PointsRenderer.Create(3000000);
                SceneObject obj = pointsRenderer.WrapToSceneObject(false);
                this.Scene.RootObject.Children.Add(obj);
                this.pointsRenderer = pointsRenderer;
            }
            {
                CrossRenderer crossRenderer = CrossRenderer.Create();
                SceneObject obj = crossRenderer.WrapToSceneObject(false);
                this.Scene.RootObject.Children.Add(obj);
                this.crossRenderer = crossRenderer;
            }
            {
                var uiAxis = new UIAxis(AnchorStyles.Left | AnchorStyles.Bottom,
                    new Padding(10, 10, 10, 10), new Size(128, 128));
                uiAxis.Initialize();
                //// display this UI control's area.
                //uiAxis.SwitchList.Add(new ClearColorSwitch());
                this.Scene.RootUI.Children.Add(uiAxis);
            }
            this.Resize += this.Scene.Resize;
            this.OpenGLDraw += ScientificCanvas_OpenGLDraw;
        }
    }
}