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
    public partial class Form13SimplexNoise : Form
    {
        private GLAxis glAxis;
        private GLControl uiRoot;
        private PickableRenderer targetRenderer;

        private void Form01Renderer_Load(object sender, EventArgs e)
        {
            {
                var camera = new Camera(CameraType.Perspecitive, this.glCanvas1.Width, this.glCanvas1.Height);
                camera.Position = new vec3(0, 0, 5);
                var rotator = new SatelliteRotator(camera);
                this.camera = camera;
                this.rotator = rotator;
            }
            {
                // build several models
                var bufferable = new Sphere();
                var shaders = new ShaderCode[2];
                shaders[0] = new ShaderCode(File.ReadAllText(@"01Renderer\Simple.vert"), ShaderType.VertexShader);
                shaders[1] = new ShaderCode(File.ReadAllText(@"01Renderer\Simple.frag"), ShaderType.FragmentShader);
                var propertyNameMap = new PropertyNameMap();
                propertyNameMap.Add("in_Position", "position");
                propertyNameMap.Add("in_Color", "color");
                var positionNameInIBufferable = "position";
                var pickableRenderer = new PickableRenderer(
                    bufferable, shaders, propertyNameMap, positionNameInIBufferable);
                pickableRenderer.Name = string.Format("Pickable: [{0}]", "Sphere");
                pickableRenderer.Initialize();
                this.targetRenderer = pickableRenderer;
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
                frmPropertyGrid.DisplayObject(this);
                frmPropertyGrid.Show();
            }
        }

    }
}
