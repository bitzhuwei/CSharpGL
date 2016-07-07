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
    public partial class Form16ArcBallManipulater : Form
    {
        private UIRoot uiRoot;
        private UIAxis glAxis;
        private Renderer teapotRenderer;
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
                var shaderCodes = new ShaderCode[2];
                shaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\Teapot.vert"), ShaderType.VertexShader);
                shaderCodes[1] = new ShaderCode(File.ReadAllText(@"shaders\Teapot.frag"), ShaderType.FragmentShader);
                var map = new PropertyNameMap();
                map.Add("in_Position", "position");
                map.Add("in_Color", "color");
                var teapotRenderer = new Renderer(new Teapot(), shaderCodes, map);
                teapotRenderer.Initialize();
                this.teapotRenderer = teapotRenderer;
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
                var frmPropertyGrid = new FormProperyGrid(this.teapotRenderer);
                frmPropertyGrid.Show();
            }
            {
                var frmPropertyGrid = new FormProperyGrid(this.glCanvas1);
                frmPropertyGrid.Show();
            }
        }

    }
}
