using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CSharpGL.Demos
{
    public partial class Form07PointSprite : Form
    {
        private Scene scene;

        private void Form_Load(object sender, EventArgs e)
        {
            {
                var camera = new Camera(
                    new vec3(0, 0, 1), new vec3(0, 0, 0), new vec3(0, 1, 0),
                    CameraType.Perspecitive, this.glCanvas1.Width, this.glCanvas1.Height);
                var rotator = new SatelliteManipulater();
                rotator.Bind(camera, this.glCanvas1);
                this.camera = camera;
                this.rotator = rotator;
                this.scene = new Scene(camera, this.glCanvas1);
                this.glCanvas1.Resize += this.scene.Resize;
            }
            //{
            //    var renderer = new PointSpriteRenderer(10000);
            //    renderer.Initialize();
            //    this.renderer = renderer;
            //    SceneObject obj = renderer.WrapToSceneObject();
            //    this.scene.RootObject.Children.Add(obj);
            //}
            {
                var list = new List<vec3>();
                list.Add(new vec3(0, 0, 0));
                list.Add(new vec3(0, 0, 1));
                list.Add(new vec3(0, 1, 0));
                list.Add(new vec3(0, 1, 1));
                list.Add(new vec3(1, 0, 0));
                list.Add(new vec3(1, 0, 1));
                list.Add(new vec3(1, 1, 0));
                list.Add(new vec3(1, 1, 1));
                list.Add(new vec3(1, 1, 1) * 0.3f);
                list.Add(new vec3(1, 1, 1) * 0.6f);
                list.Add(new vec3(1, 1, 1) * 0.9f);
                var renderer = PointCloudRenderer.Create(new PointCloudModel(list));
                renderer.Initialize();
                SceneObject obj = renderer.WrapToSceneObject("point cloud");
                this.scene.RootObject.Children.Add(obj);
            }
            {
                var uiAxis = new UIAxis(AnchorStyles.Left | AnchorStyles.Bottom,
                    new Padding(3, 3, 3, 3), new Size(128, 128), -100, 100);
                uiAxis.Initialize();
                this.scene.UIRoot.Children.Add(uiAxis);
            }
            {
                var builder = new StringBuilder();
                builder.AppendLine("O: to select image.");
                builder.AppendLine("S: Scene's property grid.");
                builder.AppendLine("C: Canvas' property grid.");
                MessageBox.Show(builder.ToString());
            }
        }
    }
}