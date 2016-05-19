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
    public partial class Form09TextBoxRenderer : Form
    {
        private FormProperyGrid formPropertyGrid;
        private UIRenderer uiRenderer;


        private void Form02OrderIndependentTransparency_Load(object sender, EventArgs e)
        {
            {
                var camera = new Camera(CameraType.Perspecitive, this.glCanvas1.Width, this.glCanvas1.Height);
                camera.Position = new vec3(0, 0, 1);
                camera.Target = new vec3(0, 0, 0);
                camera.UpVector = new vec3(0, 1, 0);
                var rotator = new SatelliteRotator(camera);
                this.camera = camera;
                this.rotator = rotator;
            }
            {
                var renderer = new DummyTextBoxRenderer(
                     AnchorStyles.Left | AnchorStyles.Top,
                        new Padding(26, 26, 26, 26),
                        new Size(50, 50));
                renderer.Initialize();
                renderer.SetText("CSharpGL2.0");
                this.renderer = renderer;
            }
            {
                // build the axis
                ShaderCode[] shaders = new ShaderCode[2];
                shaders[0] = new ShaderCode(File.ReadAllText(@"01Renderer\Simple.vert"), ShaderType.VertexShader);
                shaders[1] = new ShaderCode(File.ReadAllText(@"01Renderer\Simple.frag"), ShaderType.FragmentShader);
                var propertyNameMap = new PropertyNameMap();
                propertyNameMap.Add("in_Position", "position");
                propertyNameMap.Add("in_Color", "color");
                var pickableRenderer = PickableRendererFactory.GetRenderer(
                    new Axis(), shaders, propertyNameMap, "position");
                pickableRenderer.Name = string.Format("Pickable: [{0}]", "Axis");
                pickableRenderer.Initialize();
                {
                    GLSwitch lineWidthSwitch = new LineWidthSwitch(5);
                    pickableRenderer.SwitchList.Add(lineWidthSwitch);
                    GLSwitch pointSizeSwitch = new PointSizeSwitch(10);
                    pickableRenderer.SwitchList.Add(pointSizeSwitch);
                    GLSwitch polygonModeSwitch = new PolygonModeSwitch(PolygonModes.Filled);
                    pickableRenderer.SwitchList.Add(polygonModeSwitch);
                    if (pickableRenderer is OneIndexRenderer)
                    {
                        GLSwitch primitiveRestartSwitch = new PrimitiveRestartSwitch((pickableRenderer as OneIndexRenderer).IndexBufferPtr);
                        pickableRenderer.SwitchList.Add(primitiveRestartSwitch);
                    }
                }
                var uiRenderer = new UIRenderer(
                    pickableRenderer,
                    AnchorStyles.Left | AnchorStyles.Bottom,
                    new Padding(26, 26, 26, 26),
                    new Size(50, 50));
                uiRenderer.Initialize();
                this.uiRenderer = uiRenderer;
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
