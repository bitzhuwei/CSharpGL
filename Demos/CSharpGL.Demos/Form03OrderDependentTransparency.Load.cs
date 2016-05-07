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
    public partial class Form03OrderDependentTransparency : Form
    {
        private FormProperyGrid formPropertyGrid;


        private void Form02OrderIndependentTransparency_Load(object sender, EventArgs e)
        {
            {
                var camera = new Camera(CameraType.Perspecitive, this.glCanvas1.Width, this.glCanvas1.Height);
                camera.Position = new vec3(0, 0, 5);
                camera.Target = new vec3(0, 0, 0);
                camera.UpVector = new vec3(0, 1, 0);
                var rotator = new SatelliteRotator(camera);
                this.camera = camera;
                this.rotator = rotator;
            }
            {
                IBufferable bufferable = new Teapot();
                var shaderCodes = new ShaderCode[2];
                shaderCodes[0] = new ShaderCode(File.ReadAllText(@"Shaders\Transparent.vert"), ShaderType.VertexShader);
                shaderCodes[1] = new ShaderCode(File.ReadAllText(@"Shaders\Transparent.frag"), ShaderType.FragmentShader);
                var map = new PropertyNameMap();
                map.Add("in_Position", "position");
                map.Add("in_Color", "color");
                var renderer = PickableRendererFactory.GetRenderer(
                    bufferable, shaderCodes, map, "position");
                renderer.Name = "Order-Dependent Transparent Renderer";
                {
                    GLSwitch lineWidthSwitch = new LineWidthSwitch(5);
                    renderer.SwitchList.Add(lineWidthSwitch);
                    GLSwitch pointSizeSwitch = new PointSizeSwitch(10);
                    renderer.SwitchList.Add(pointSizeSwitch);
                    GLSwitch polygonModeSwitch = new PolygonModeSwitch(PolygonModes.Filled);
                    renderer.SwitchList.Add(polygonModeSwitch);
                    GLSwitch primitiveRestartSwitch = new PrimitiveRestartSwitch(uint.MaxValue);
                    renderer.SwitchList.Add(primitiveRestartSwitch);
                    GLSwitch blendSwitch = new BlendSwitch();
                    renderer.SwitchList.Add(blendSwitch);
                }
                renderer.Initialize();
                this.renderer = renderer;
            }
            {
                var frmPropertyGrid = new FormProperyGrid();
                frmPropertyGrid.DisplayObject(this.renderer);
                frmPropertyGrid.Show();
                this.formPropertyGrid = frmPropertyGrid;
            }
        }
    }
}
