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
        private UIAxis glAxis;
        private UIRoot uiRoot;
        private ShaderToyRenderer simplexNoiseRenderer;

        private void Form01Renderer_Load(object sender, EventArgs e)
        {
            {
                var camera = new Camera(
                    new vec3(0, 0, 5), new vec3(), new vec3(0, 1, 0),
                    CameraType.Perspecitive, this.glCanvas1.Width, this.glCanvas1.Height);
                var rotator = new SatelliteRotator(camera);
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

                var glAxis = new UIAxis(AnchorStyles.Right | AnchorStyles.Bottom,
                    new Padding(3, 3, 3, 3), new Size(70, 70), -100, 100);
                glAxis.Initialize();
                this.glAxis = glAxis;

                UIRoot.Children.Add(glAxis);
            }
            {
                var frmPropertyGrid = new FormProperyGrid();
                frmPropertyGrid.DisplayObject(this.simplexNoiseRenderer);
                frmPropertyGrid.Show();
            }
        }

    }
}
