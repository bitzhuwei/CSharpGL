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
    public partial class Form09TextBoxRenderer : Form
    {
        private FormProperyGrid formPropertyGrid;


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
                var renderer = new DummyTextBoxRenderer(
                     AnchorStyles.Left | AnchorStyles.Top,
                        new Padding(26, 26, 26, 26),
                        new Size(50, 50));
                renderer.Initialize();
                renderer.SetText("CSharpGL2.0");
                this.renderer = renderer;
            }
            {
                var frmPropertyGrid = new FormProperyGrid();
                frmPropertyGrid.DisplayObject(this.renderer);
                frmPropertyGrid.Show();
                this.formPropertyGrid = frmPropertyGrid;
            }
        }
    }
}
