using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CSharpGL.OBJFileViewer
{
    public partial class FormMain
    {
        private Scene scene;
        private Camera camera;
        private SatelliteManipulater rotator;

        private void FormMain_Load(object sender, EventArgs e)
        {
            {
                var camera = new Camera(
                    new vec3(3, 4, 5) * 4, new vec3(0, 0, 0), new vec3(0, 1, 0),
                    CameraType.Perspecitive, this.glCanvas1.Width, this.glCanvas1.Height);
                var rotator = new SatelliteManipulater();
                rotator.Bind(camera, this.glCanvas1);
                this.camera = camera;
                this.rotator = rotator;
                var scene = new Scene(camera, this.glCanvas1);
                scene.ClearColor = Color.SkyBlue;
                this.scene = scene;
                this.glCanvas1.Resize += this.scene.Resize;
            }

            {
                var uiAxis = new UIAxis(AnchorStyles.Left | AnchorStyles.Bottom,
                    new Padding(3, 3, 3, 3), new Size(128, 128));
                this.scene.UIRoot.Children.Add(uiAxis);
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