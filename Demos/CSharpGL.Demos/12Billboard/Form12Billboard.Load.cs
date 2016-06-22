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
        private FormProperyGrid formPropertyGrid;
        private UIRoot uiRoot;
        private UIAxis glAxis;
        private MovableRenderer movableRenderer;
        private Renderer billboardRenderer;
        private Renderer ground;
        private LabelRenderer labelRenderer;

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
                const int scale = 2;
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
                var movableRenderer = new MovableRenderer(new Teapot(), shaderCodes, map, "position");
                movableRenderer.Initialize();
                movableRenderer.Scale = 0.1f;
                this.movableRenderer = movableRenderer;
            }
            {
                var shaderCodes = new ShaderCode[2];
                shaderCodes[0] = new ShaderCode(File.ReadAllText(@"12Billboard\billboard.vert"), ShaderType.VertexShader);
                shaderCodes[1] = new ShaderCode(File.ReadAllText(@"12Billboard\billboard.frag"), ShaderType.FragmentShader);
                var map = new PropertyNameMap();
                map.Add("in_Positions", BillboardModel.strPosition);
                var billboardRenderer = new BillboardRenderer(new BillboardModel(), shaderCodes, map);
                billboardRenderer.Initialize();
                var texture = new sampler2D();
                var bitmap = new Bitmap(@"12Billboard\ExampleBillboard.png");
                texture.Initialize(bitmap);
                bitmap.Dispose();
                billboardRenderer.TargetRenderer = this.movableRenderer;
                billboardRenderer.SetUniform("myTextureSampler", new samplerValue(BindTextureTarget.Texture2D, texture.Id, OpenGL.GL_TEXTURE0));

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
                var frmPropertyGrid = new FormProperyGrid();
                frmPropertyGrid.DisplayObject(this.movableRenderer);
                frmPropertyGrid.Show();
                this.formPropertyGrid = frmPropertyGrid;
            }
            {
                var frmPropertyGrid = new FormProperyGrid();
                frmPropertyGrid.DisplayObject(this.billboardRenderer);
                frmPropertyGrid.Show();
                this.formPropertyGrid = frmPropertyGrid;
            }
            {
                var frmPropertyGrid = new FormProperyGrid();
                frmPropertyGrid.DisplayObject(this.glCanvas1);
                frmPropertyGrid.Show();
                this.formPropertyGrid = frmPropertyGrid;
            }
            {
                var frmPropertyGrid = new FormProperyGrid();
                frmPropertyGrid.DisplayObject(this.labelRenderer);
                frmPropertyGrid.Show();
                this.formPropertyGrid = frmPropertyGrid;
            }
        }

    }
}
