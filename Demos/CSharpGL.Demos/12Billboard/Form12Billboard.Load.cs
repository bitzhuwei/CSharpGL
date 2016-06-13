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
    public partial class Form12Billboard : Form
    {
        private FormProperyGrid formPropertyGrid;
        private GLControl uiRoot;
        private GLAxis glAxis;
        private MovableRenderer movableRenderer;
        private Renderer billboardRenderer;
        private Renderer ground;

        private void Form02OrderIndependentTransparency_Load(object sender, EventArgs e)
        {
            {
                var camera = new Camera(
                    new vec3(0, 0, 5), new vec3(0, 0, 0), new vec3(0, 1, 0),
                    CameraType.Perspecitive, this.glCanvas1.Width, this.glCanvas1.Height);
                var rotator = new SatelliteRotator(camera);
                this.camera = camera;
                this.rotator = rotator;
            }
            {
                var shaderCodes = new ShaderCode[2];
                shaderCodes[0] = new ShaderCode(File.ReadAllText(@"12Billboard\Ground.vert"), ShaderType.VertexShader);
                shaderCodes[1] = new ShaderCode(File.ReadAllText(@"12Billboard\Ground.frag"), ShaderType.FragmentShader);
                var map = new PropertyNameMap();
                map.Add("in_Position", GroundModel.strPosition);
                const int gridsPer2Unit = 20;
                const int scale = 1;
                var ground = new GroundRenderer(new GroundModel(gridsPer2Unit * scale), shaderCodes, map);
                ground.Initialize();
                ground.Scale = scale;
                this.ground = ground;
            }
            {
                var shaderCodes = new ShaderCode[2];
                shaderCodes[0] = new ShaderCode(File.ReadAllText(@"12Billboard\Cube.vert"), ShaderType.VertexShader);
                shaderCodes[1] = new ShaderCode(File.ReadAllText(@"12Billboard\Cube.frag"), ShaderType.FragmentShader);
                var map = new PropertyNameMap();
                map.Add("in_Position", "position");
                map.Add("in_Color", "color");
                var movableRenderer = new MovableRenderer(new Cube(), shaderCodes, map, "position");
                movableRenderer.Initialize();
                this.movableRenderer = movableRenderer;
            }
            {
                var shaderCodes = new ShaderCode[2];
                shaderCodes[0] = new ShaderCode(File.ReadAllText(@"12Billboard\billboard.vert"), ShaderType.VertexShader);
                shaderCodes[1] = new ShaderCode(File.ReadAllText(@"12Billboard\billboard.frag"), ShaderType.FragmentShader);
                var map = new PropertyNameMap();
                map.Add("squareVertices", "position");
                var billboardRenderer = new Renderer(new BillboardModel(), shaderCodes, map);
                billboardRenderer.Initialize();
                var texture = new sampler2D();
                var bitmap = new Bitmap(@"12Billboard\ExampleBillboard.png");
                texture.Initialize(bitmap);
                bitmap.Dispose();
                billboardRenderer.SetUniform("myTextureSampler", new samplerValue(BindTextureTarget.Texture2D, texture.Id, OpenGL.GL_TEXTURE0));

                this.billboardRenderer = billboardRenderer;
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
            }
            {
                var frmPropertyGrid = new FormProperyGrid();
                frmPropertyGrid.DisplayObject(this.movableRenderer);
                frmPropertyGrid.Show();
                this.formPropertyGrid = frmPropertyGrid;
            }
        }

    }
}
