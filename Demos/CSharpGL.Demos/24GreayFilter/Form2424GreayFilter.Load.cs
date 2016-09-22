using System;
using System.Drawing;
using System.Text;

using System.Windows.Forms;

namespace CSharpGL.Demos
{
    public partial class Form2424GreayFilter : Form
    {
        private UIRoot uiRoot;
        private UIAxis uiAxis;
        private GreyFilterRenderer renderer;
        private ArcBallManipulater arcballManipulater;

        private void Form_Load(object sender, EventArgs e)
        {
            {
                var camera = new Camera(
                    new vec3(-3, -2, -5) * 0.5f, new vec3(0, 0, 0), new vec3(0, -1, 0),
                    CameraType.Perspecitive, this.glCanvas1.Width, this.glCanvas1.Height);
                this.camera = camera;
                var cameraManipulater = new SatelliteManipulater();
                cameraManipulater.Bind(camera, this.glCanvas1);
                this.cameraManipulater = cameraManipulater;
                var arcballManipulater = new ArcBallManipulater();
                arcballManipulater.Bind(camera, this.glCanvas1);
                this.arcballManipulater = arcballManipulater;
            }
            {
                GreyFilterRenderer renderer = GreyFilterRenderer.Create();
                renderer.Initialize();
                this.renderer = renderer;
            }
            {
                var UIRoot = new UIRoot();
                UIRoot.Initialize();
                this.uiRoot = UIRoot;

                var uiAxis = new UIAxis(AnchorStyles.Left | AnchorStyles.Bottom,
                    new Padding(3, 3, 3, 3), new Size(128, 128));
                uiAxis.Initialize();
                this.uiAxis = uiAxis;

                UIRoot.Children.Add(uiAxis);
            }
            {
                var builder = new StringBuilder();
                builder.AppendLine("2: Canvas' property grid.");
                MessageBox.Show(builder.ToString());
            }
        }
    }
}