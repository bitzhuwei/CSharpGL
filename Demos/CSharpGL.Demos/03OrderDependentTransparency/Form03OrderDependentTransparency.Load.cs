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
    public partial class Form03OrderDependentTransparency : Form
    {
        private FormProperyGrid formPropertyGrid;
        private UIRoot uiRoot;
        private UIText uiCursor;


        private void Form_Load(object sender, EventArgs e)
        {
            {
                var camera = new Camera(
                    new vec3(0, 0, 5), new vec3(0, 0, 0), new vec3(0, 1, 0),
                    CameraType.Perspecitive, this.glCanvas1.Width, this.glCanvas1.Height);
                var rotator = new SatelliteManipulater();
                rotator.Bind(camera, this.glCanvas1);
                rotator.BindingMouseButtons = System.Windows.Forms.MouseButtons.Left | System.Windows.Forms.MouseButtons.Right;
                this.camera = camera;
                this.rotator = rotator;
            }
            {
                IBufferable bufferable = new Teapot();
                var shaderCodes = new ShaderCode[2];
                shaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\Transparent.vert"), ShaderType.VertexShader);
                shaderCodes[1] = new ShaderCode(File.ReadAllText(@"shaders\Transparent.frag"), ShaderType.FragmentShader);
                var map = new PropertyNameMap();
                map.Add("in_Position", "position");
                map.Add("in_Color", "color");
                var renderer = new PickableRenderer(bufferable, shaderCodes, map, "position");
                renderer.Name = "Order-Dependent Transparent Renderer";
                renderer.Initialize();
                {
                    GLSwitch blendSwitch = new BlendSwitch(BlendingSourceFactor.SourceAlpha, BlendingDestinationFactor.OneMinusSourceAlpha);
                    renderer.SwitchList.Add(blendSwitch);
                }
                this.renderer = renderer;
            }
            {
                var UIRoot = new UIRoot();
                UIRoot.Initialize();
                this.uiRoot = UIRoot;

                var font = new Font("Arial", 32);
                var uiCursor = new UIText(AnchorStyles.Left | AnchorStyles.Bottom,
                    new Padding(0, 0, 0, 0), new Size(50, 50), -100, 100,
                   font.GetFontBitmap("o↖＋〇┼╋╬╳╁╂╫✧☼⊕○").GetFontTexture());
                uiCursor.Initialize();
                //uiCursor.SwitchList.Add(new ClearColorSwitch());
                uiCursor.Text = "〇";
                uiCursor.TextColor = Color.Red;
                uiRoot.Children.Add(uiCursor);
                this.uiCursor = uiCursor;
                (new FormProperyGrid(this.uiCursor)).Show();
            }
            {
                var frmPropertyGrid = new FormProperyGrid(this.renderer);
                frmPropertyGrid.Show();
                this.formPropertyGrid = frmPropertyGrid;
            }
        }
    }
}
