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
    public partial class Form14ShaderToy : Form
    {
        private UIAxis uiAxis;
        private UIRoot uiRoot;
        private ShaderToyRenderer simplexNoiseRenderer;

        private void Form_Load(object sender, EventArgs e)
        {
            {
                var camera = new Camera(
                    new vec3(0, 0, 5), new vec3(), new vec3(0, 1, 0),
                    CameraType.Perspecitive, this.glCanvas1.Width, this.glCanvas1.Height);
                var rotator = new SatelliteManipulater();
                rotator.Bind(camera, this.glCanvas1);
                this.camera = camera;
                this.rotator = rotator;
            }
            {
                var simplexNoiseRenderer = new ShaderToyRenderer();
                simplexNoiseRenderer.Name = string.Format("ShaderToy: [{0}]", "Sphere");
                simplexNoiseRenderer.Initialize();
                this.simplexNoiseRenderer = simplexNoiseRenderer;
            }
            {
                var UIRoot = new UIRoot();
                UIRoot.Initialize();
                this.uiRoot = UIRoot;

                var uiAxis = new UIAxis(AnchorStyles.Left | AnchorStyles.Bottom,
                    new Padding(3, 3, 3, 3), new Size(128, 128), -100, 100);
                uiAxis.Initialize();
                this.uiAxis = uiAxis;

                UIRoot.Children.Add(uiAxis);
            }
            {
                var frmPropertyGrid = new FormProperyGrid(this.simplexNoiseRenderer);
                frmPropertyGrid.Show();
            }
        }

    }
}
