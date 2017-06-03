using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CSharpGL.Demos
{
    public partial class Form06ImageProcessing : Form
    {
        private Scene scene;

        private void Form_Load(object sender, EventArgs e)
        {
            {
                var camera = new Camera(
                    new vec3(0, 0, -1), new vec3(0, 0, 0), new vec3(0, 1, 0),
                    CameraType.Perspecitive, this.glCanvas1.Width, this.glCanvas1.Height);
                var rotator = new SatelliteManipulater();
                rotator.Bind(camera, this.glCanvas1);
                this.rotator = rotator;
                this.scene = new Scene(camera, this.glCanvas1);
                this.scene.ClearColor = Color.SkyBlue;
                this.glCanvas1.Resize += this.scene.Resize;
            }
            {
                var renderer = new ImageProcessingRenderer();
                renderer.Initialize();
                SceneObject obj = renderer.WrapToSceneObject(new UpdateImageScript(this.glCanvas1));
                this.scene.RootObject.Children.Add(obj);
            }
            {
                var builder = new StringBuilder();
                builder.AppendLine("1: Scene's property grid.");
                builder.AppendLine("2: Canvas' property grid.");
                MessageBox.Show(builder.ToString());
            }
        }
    }
}