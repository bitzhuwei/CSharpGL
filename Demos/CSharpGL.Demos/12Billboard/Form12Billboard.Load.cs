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
    public partial class Form12Billboard : Form
    {
        private UIRoot uiRoot;
        private UIAxis glAxis;
        private MovableRenderer movableRenderer;
        private Renderer billboardRenderer;
        private Renderer ground;
        private LabelRenderer labelRenderer;

        private void Form_Load(object sender, EventArgs e)
        {
            {
                var camera = new Camera(
                    new vec3(0, 0, 5), new vec3(0, 0, 0), new vec3(0, 1, 0),
                    CameraType.Perspecitive, this.glCanvas1.Width, this.glCanvas1.Height);
                var rotator = new SatelliteManipulater();
                rotator.Bind(camera, this.glCanvas1);
                this.camera = camera;
                this.rotator = rotator;
            }
            {
                var shaderCodes = new ShaderCode[2];
                shaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\Ground.vert"), ShaderType.VertexShader);
                shaderCodes[1] = new ShaderCode(File.ReadAllText(@"shaders\Ground.frag"), ShaderType.FragmentShader);
                var map = new PropertyNameMap();
                map.Add("in_Position", GroundModel.strPosition);
                const int gridsPer2Unit = 20;
                const int scale = 2;
                var ground = new GroundRenderer(new GroundModel(gridsPer2Unit * scale), shaderCodes, map);
                ground.Initialize();
                ground.Scale = scale;
                this.ground = ground;
            }
            {
                var movableRenderer = MovableRenderer.GetRenderer(new Teapot());
                movableRenderer.Initialize();
                movableRenderer.Scale = 0.1f;
                this.movableRenderer = movableRenderer;
            }
            {
                var billboardRenderer = BillboardRenderer.GetRenderer(new BillboardModel());
                billboardRenderer.Initialize();
                billboardRenderer.TargetRenderer = this.movableRenderer;

                this.billboardRenderer = billboardRenderer;
            }
            {
                var labelRenderer = new LabelRenderer();
                labelRenderer.Initialize();
                labelRenderer.Text = "Teapot - CSharpGL";
                this.labelRenderer = labelRenderer;
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
                var frmPropertyGrid = new FormProperyGrid(this.movableRenderer);
                frmPropertyGrid.Show();
            }
            {
                var frmPropertyGrid = new FormProperyGrid(this.billboardRenderer);
                frmPropertyGrid.Show();
            }
            {
                var frmPropertyGrid = new FormProperyGrid(this.glCanvas1);
                frmPropertyGrid.Show();
            }
            {
                var frmPropertyGrid = new FormProperyGrid(this.labelRenderer);
                frmPropertyGrid.Show();
            }
        }

    }
}
