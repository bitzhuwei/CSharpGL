using CSharpGL.ModelAdapters;
using CSharpGL.Models;
using GLM;
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
    public partial class Form02EmitNormalLine : Form
    {

        private void Form01ModernRenderer_Load(object sender, EventArgs e)
        {
            {
                var camera = new Camera(CameraType.Perspecitive, this.glCanvas1.Width, this.glCanvas1.Height);
                camera.Position = new vec3(0, 0, 5);
                var rotator = new SatelliteRotator(camera);
                this.camera = camera;
                this.rotator = rotator;
            }
            {
                var bufferables = new IBufferable[]{
                    new TetrahedronModelAdapter(new TetrahedronModel(1.0f)),
                    new CubeModelAdapter(new CubeModel(1.0f)),
                    new SphereModelAdapter(new SphereModel(1.0f)),
                    new TeapotModelAdapter(TeapotModel.GetModel(1.0f)),
                };
                var keys = new GeometryModel[] { GeometryModel.Tetrahedron, GeometryModel.Cube, GeometryModel.Sphere, GeometryModel.Teapot };
                for (int i = 0; i < bufferables.Length; i++)
                {
                    IBufferable bufferable = bufferables[i];
                    GeometryModel key = keys[i];
                    ShaderCode[] shaders = new ShaderCode[3];
                    shaders[0] = new ShaderCode(File.ReadAllText(@"Shaders\EmitNormalLine.vert"), ShaderType.VertexShader);
                    shaders[1] = new ShaderCode(File.ReadAllText(@"Shaders\EmitNormalLine.geom"), ShaderType.GeometryShader);
                    shaders[2] = new ShaderCode(File.ReadAllText(@"Shaders\EmitNormalLine.frag"), ShaderType.FragmentShader);
                    var propertyNameMap = new PropertyNameMap();
                    propertyNameMap.Add("in_Position", "position");
                    propertyNameMap.Add("in_Normal", "normal");
                    string positionNameInIBufferable = "position";
                    var renderer = ModernRendererFactory.GetModernRenderer(bufferable, shaders, propertyNameMap, positionNameInIBufferable);
                    renderer.Initialize();
                    renderer.SetUniformValue("normalLength", 0.5f);
                    renderer.SetUniformValue("showModel", true);
                    renderer.SetUniformValue("showNormal", true);

                    GLSwitch lineWidthSwitch = new LineWidthSwitch(10.0f);
                    renderer.SwitchList.Add(lineWidthSwitch);
                    GLSwitch pointSizeSwitch = new PointSizeSwitch(10.0f);
                    renderer.SwitchList.Add(pointSizeSwitch);
                    GLSwitch polygonModeSwitch = new PolygonModeSwitch(PolygonModes.Filled);
                    renderer.SwitchList.Add(polygonModeSwitch);
                    GLSwitch primitiveRestartSwitch = new PrimitiveRestartSwitch(uint.MaxValue);
                    renderer.SwitchList.Add(primitiveRestartSwitch);

                    this.rendererDict.Add(key, renderer);
                }
                this.SelectedModel = GeometryModel.Tetrahedron;
            }
            {
                var frmBulletinBoard = new FormBulletinBoard();
                frmBulletinBoard.Dump = true;
                frmBulletinBoard.Show();
                this.RunPickingBoard = frmBulletinBoard;
            }
            {
                var frmPropertyGrid = new FormProperyGrid();
                frmPropertyGrid.DisplayObject(this.rendererDict[this.SelectedModel]);
                frmPropertyGrid.Show();
                this.rendererPropertyGrid = frmPropertyGrid;
            }
            {
                var frmPropertyGrid = new FormProperyGrid();
                frmPropertyGrid.DisplayObject(this.camera);
                frmPropertyGrid.Show();
                this.cameraPropertyGrid = frmPropertyGrid;
            }
            {
                var frmPropertyGrid = new FormProperyGrid();
                frmPropertyGrid.DisplayObject(this);
                frmPropertyGrid.Show();
                this.formPropertyGrid = frmPropertyGrid;
            }

        }

    }
}
