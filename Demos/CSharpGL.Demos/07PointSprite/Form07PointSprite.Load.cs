using System;
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
                    new vec3(5, 4, 3) * 0.5f, new vec3(0, 0, 0), new vec3(0, 1, 0),
                    CameraType.Perspecitive, this.glCanvas1.Width, this.glCanvas1.Height);
                var rotator = new SatelliteManipulater();
                rotator.Bind(camera, this.glCanvas1);
                this.camera = camera;
                this.rotator = rotator;
                this.scene = new Scene(camera, this.glCanvas1);
                this.glCanvas1.Resize += this.scene.Resize;
            }
            {
                const int particleCount = 10000;
                PointSpriteRenderer renderer = PointSpriteRenderer.Create(particleCount);
                this.renderer = renderer;
                SceneObject obj = renderer.WrapToSceneObject(generateBoundingBox: true);
                this.scene.RootObject.Children.Add(obj);
            }
            {
                var uiAxis = new UIAxis(AnchorStyles.Left | AnchorStyles.Bottom,
                    new Padding(3, 3, 3, 3), new Size(128, 128));
                this.scene.RootUI.Children.Add(uiAxis);
            }
            {
                var builder = new StringBuilder();
                builder.AppendLine("O: to select image.");
                builder.AppendLine("1: Scene's property grid.");
                builder.AppendLine("2: Canvas' property grid.");
                MessageBox.Show(builder.ToString());
            }
        }
    }
}