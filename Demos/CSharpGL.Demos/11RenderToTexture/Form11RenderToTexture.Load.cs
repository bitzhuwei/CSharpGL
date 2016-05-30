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
    public partial class Form11RenderToTexture : Form
    {
        private FormProperyGrid formPropertyGrid;
        private DummyUIRenderer uiRenderer;
        private GLRoot uiRoot;
        private GLAxis glAxis;


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
                var renderer = new RaycastVolumeRenderer();
                renderer.Initialize();
                this.renderer = renderer;
            }
            {
                var UIRoot = new GLRoot(this.glCanvas1.Size, -100, 100);
                UIRoot.Initialize();
                this.uiRoot = UIRoot;

                var glAxis = new GLAxis(AnchorStyles.Right | AnchorStyles.Bottom,
                    new Padding(3, 3, 3, 3), new Size(70, 70), -100, 100);
                glAxis.Initialize();
                this.glAxis = glAxis;

                UIRoot.Controls.Add(glAxis);
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
                var uiRenderer = new DummyUIRenderer(
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
