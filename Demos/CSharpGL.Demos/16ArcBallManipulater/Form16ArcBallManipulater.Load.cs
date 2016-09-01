using System;
using System.Drawing;
using System.IO;
using System.Text;

using System.Windows.Forms;

namespace CSharpGL.Demos
{
    public partial class Form16ArcBallManipulater : Form
    {
        private UIRoot uiRoot;
        private UIAxis uiAxis;
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
                const int gridsPer2Unit = 20;
                const int scale = 2;
                GroundRenderer ground = GroundRenderer.Create(new GroundModel(gridsPer2Unit * scale));
                ground.Initialize();
                ground.Scale = new vec3(scale, scale, scale);
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

                var uiAxis = new UIAxis(AnchorStyles.Left | AnchorStyles.Bottom,
                    new Padding(3, 3, 3, 3), new Size(128, 128), -100, 100);
                uiAxis.Initialize();
                this.uiAxis = uiAxis;

                UIRoot.Children.Add(uiAxis);
            }
            {
                var builder = new StringBuilder();
                builder.AppendLine("C: Canvas' property grid.");
                MessageBox.Show(builder.ToString());
            }
        }
    }
}