using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpGL.Demos
{
    public partial class Form09UIRenderer : Form
    {
        private FormProperyGrid formPropertyGrid;
        private GLControl uiRoot;
        private GLAxis glAxis;
        private GLText glText;

        private void Form02OrderIndependentTransparency_Load(object sender, EventArgs e)
        {
            {
                var camera = new Camera(CameraType.Perspecitive, this.glCanvas1.Width, this.glCanvas1.Height);
                camera.Position = new vec3(0, 0, 1);
                camera.Target = new vec3(0, 0, 0);
                camera.UpVector = new vec3(0, 1, 0);
                var rotator = new SatelliteRotator(camera);
                this.camera = camera;
                this.rotator = rotator;
            }
            {
                var UIRoot = new GLControl(this.glCanvas1.Size, -100, 100);
                UIRoot.Initialize();
                this.uiRoot = UIRoot;

                var glAxis = new GLAxis(AnchorStyles.Right | AnchorStyles.Bottom,
                    new Padding(3, 3, 3, 3), new Size(70, 70), -100, 100);
                glAxis.Initialize();
                this.glAxis = glAxis;

                UIRoot.Controls.Add(glAxis);

                var glText = new GLText(AnchorStyles.Left | AnchorStyles.Top,
                    new Padding(3, 3, 3, 3), new Size(750, 50), -100, 100);
                glText.Initialize();
                glText.SetText("The quick brown fox jumps over the lazy dog!");
                this.glText = glText;

                uiRoot.Controls.Add(glText);
            }
            {
                var frmPropertyGrid = new FormProperyGrid();
                frmPropertyGrid.DisplayObject(this.glText);
                frmPropertyGrid.Show();
                this.formPropertyGrid = frmPropertyGrid;
            }
        }
    }
}
