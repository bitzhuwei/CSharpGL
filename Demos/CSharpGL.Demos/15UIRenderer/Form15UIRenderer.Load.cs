using System;
using System.Drawing;
using System.Text;

using System.Windows.Forms;

namespace CSharpGL.Demos
{
    public partial class Form15UIRenderer : Form
    {
        private Scene scene;

        private UIText glText;
        private BlendFactorHelper blendFactorHelper = new BlendFactorHelper();

        private void Form_Load(object sender, EventArgs e)
        {
            {
                //this.glCanvas1.ShowSystemCursor = false;
            }
            {
                var camera = new Camera(
                    new vec3(0, 0, 1), new vec3(0, 0, 0), new vec3(0, 1, 0),
                    CameraType.Perspecitive, this.glCanvas1.Width, this.glCanvas1.Height);
                var rotator = new SatelliteManipulater();
                rotator.Bind(camera, this.glCanvas1);
                this.rotator = rotator;
                this.scene = new Scene(camera, this.glCanvas1);
                this.glCanvas1.Resize += this.scene.Resize;
            }
            {
                var glText = new UIText(AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right,
                    new Padding(10, 10, 10, 10), new Size(550, 50), -100, 100);
                glText.Initialize();
                glText.SwitchList.Add(new ClearColorSwitch());// show black back color to indicate glText's area.
                glText.Text = "The quick brown fox jumps over the lazy dog!";
                this.glText = glText;
                this.scene.UIRoot.Children.Add(glText);
            }
            {
                var uiAxis = new UIAxis(AnchorStyles.Left | AnchorStyles.Bottom,
                    new Padding(3, 3, 3, 3), new Size(128, 128));
                uiAxis.Initialize();
                this.scene.UIRoot.Children.Add(uiAxis);

                this.UpdateLabel();
            }
            {
                var builder = new StringBuilder();
                builder.AppendLine("1: Scene's property grid.");
                builder.AppendLine("2: Cavas' property grid.");
                MessageBox.Show(builder.ToString());
            }
        }

        private void UpdateLabel()
        {
            this.lblCurrentBlend.Text = string.Format("glBlend({0}, {1});",
                this.glText.BlendSwitch.SourceFactor,
                this.glText.BlendSwitch.DestFactor);
        }
    }
}