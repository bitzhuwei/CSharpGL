using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace CSharpGL.Demos
{
    public partial class Form15LabelRenderer : Form
    {

        private Scene scene;

        private FormProperyGrid formPropertyGrid;
        private UIText glText;
        private BlendFactorHelper blendFactorHelper = new BlendFactorHelper();

        private void Form_Load(object sender, EventArgs e)
        {
            {
                this.glCanvas1.ShowSystemCursor = false;
            }
            {
                var camera = new Camera(
                    new vec3(0, 0, 1), new vec3(0, 0, 0), new vec3(0, 1, 0),
                    CameraType.Perspecitive, this.glCanvas1.Width, this.glCanvas1.Height);
                var rotator = new SatelliteManipulater();
                rotator.Bind(camera, this.glCanvas1);
                this.rotator = rotator;
                this.scene = new Scene(camera);
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

                var uiAxis = new UIAxis(AnchorStyles.Left | AnchorStyles.Bottom,
                    new Padding(3, 3, 3, 3), new Size(128, 128), -100, 100);
                uiAxis.Initialize();
                this.scene.UIRoot.Children.Add(uiAxis);

                this.UpdateLabel();
            }
            {
                var frmPropertyGrid = new FormProperyGrid(this.glText);
                frmPropertyGrid.Show();
                this.formPropertyGrid = frmPropertyGrid;
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
