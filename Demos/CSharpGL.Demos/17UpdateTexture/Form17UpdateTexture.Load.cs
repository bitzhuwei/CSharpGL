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
    public partial class Form17UpdateTexture : Form
    {
        private UIRoot uiRoot;
        private UIAxis uiAxis;
        private UpdatingTextureRenderer renderer;
        private Renderer ground;
        private ArcBallManipulater arcballManipulater;

        private void Form_Load(object sender, EventArgs e)
        {
            {
                var camera = new Camera(
                    new vec3(0, 0, 5), new vec3(0, 0, 0), new vec3(0, 1, 0),
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
                const int gridsPer2Unit = 20;
                const int scale = 2;
                GroundRenderer ground = GroundRenderer.Create(new GroundModel(gridsPer2Unit * scale));
                ground.Initialize();
                ground.Scale = new vec3(scale, scale, scale);
                this.ground = ground;
            }
            {
                UpdatingTextureRenderer renderer = UpdatingTextureRenderer.Create(new TexturedRectangleModel());
                renderer.Initialize();
                this.renderer = renderer;
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
                var frmPropertyGrid = new FormProperyGrid(this.renderer);
                frmPropertyGrid.Show();
            }
            {
                var frmPropertyGrid = new FormProperyGrid(this.glCanvas1);
                frmPropertyGrid.Show();
            }
        }

    }
}
