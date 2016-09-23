using System;
using System.Drawing;
using System.IO;
using System.Text;

using System.Windows.Forms;

namespace CSharpGL.Demos
{
    public partial class Form16ArcBallManipulater : Form
    {
        private Scene scene;

        private void Form_Load(object sender, EventArgs e)
        {
            {
                var camera = new Camera(
                    new vec3(5, 3, 4), new vec3(0, 0, 0), new vec3(0, 1, 0),
                    CameraType.Perspecitive, this.glCanvas1.Width, this.glCanvas1.Height);
                var scene = new Scene(camera, this.glCanvas1);
                scene.ClearColor = Color.SkyBlue;
                this.glCanvas1.Resize += scene.Resize;
                this.scene = scene;
                var cameraManipulater = new SatelliteManipulater();
                cameraManipulater.Bind(camera, this.glCanvas1);
                this.cameraManipulater = cameraManipulater;

            }
            {
                const int gridsPer2Unit = 20;
                const int scale = 2;
                GroundRenderer renderer = GroundRenderer.Create(new GroundModel(gridsPer2Unit * scale));
                renderer.Scale = new vec3(scale, scale, scale);
                SceneObject obj = renderer.WrapToSceneObject(generateBoundingBox: true);
                this.scene.RootObject.Children.Add(obj);
            }
            {
                var arcballManipulater = new ArcBallManipulater();
                arcballManipulater.Bind(this.scene.Camera, this.glCanvas1);
                SimpleRenderer renderer = SimpleRenderer.Create(new Teapot());
                SceneObject obj = renderer.WrapToSceneObject();
                obj.Scripts.Add(new ArcballScript(arcballManipulater));
                {
                    BoundingBoxRenderer box = renderer.GetBoundingBoxRenderer();
                    var boxObj = box.WrapToSceneObject();
                    boxObj.Scripts.Add(new ArcballScript(arcballManipulater));
                    obj.Children.Add(boxObj);
                }
                this.scene.RootObject.Children.Add(obj);
            }
            {
                var uiAxis = new UIAxis(AnchorStyles.Left | AnchorStyles.Bottom,
                    new Padding(3, 3, 3, 3), new Size(128, 128));
                uiAxis.Initialize();

                this.scene.UIRoot.Children.Add(uiAxis);
            }
            {
                var builder = new StringBuilder();
                builder.AppendLine("2: Canvas' property grid.");
                MessageBox.Show(builder.ToString());
            }
            {
                this.scene.Start();
            }
        }
    }
}