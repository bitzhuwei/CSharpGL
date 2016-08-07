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
    public partial class Form08AnalyzedPointSprite : Form
    {
        private FormProperyGrid formPropertyGrid;
        private UIRoot uiRoot;
        private UIAxis uiAxis;
        private UICursor uiCursor;

        private void Form_Load(object sender, EventArgs e)
        {
            {
                var camera = new Camera(
                    new vec3(0, 0, 1), new vec3(0, 0, 0), new vec3(0, 1, 0),
                    CameraType.Perspecitive, this.glCanvas1.Width, this.glCanvas1.Height);
                var rotator = new SatelliteManipulater();
                rotator.Bind(camera, this.glCanvas1);
                this.camera = camera;
                this.rotator = rotator;
            }
            {
                var renderer = new AnalyzedPointSpriteRenderer(10000);
                renderer.Initialize();
                this.renderer = renderer;
            }
            {
                var uiRoot = new UIRoot();
                uiRoot.Initialize();
                this.uiRoot = uiRoot;
            }
            {
                var uiAxis = new UIAxis(AnchorStyles.Left | AnchorStyles.Bottom,
                    new Padding(3, 3, 3, 3), new Size(128, 128), -100, 100);
                uiAxis.Initialize();
                this.uiAxis = uiAxis;
                uiRoot.Children.Add(uiAxis);
            }
            {
                var uiCursor = UICursor.CreateDefault();
                uiCursor.Initialize();
                //uiCursor.SwitchList.Add(new ClearColorSwitch());
                uiRoot.Children.Add(uiCursor);
                this.uiCursor = uiCursor;
                var frmPropertyGrid = new FormProperyGrid(uiCursor);
                frmPropertyGrid.Show();
            }
            {
                var frmPropertyGrid = new FormProperyGrid(this.renderer);
                frmPropertyGrid.Show();
                this.formPropertyGrid = frmPropertyGrid;
            }
        }
    }
}
