using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using CSharpGL;

namespace GridViewer
{
    public partial class ScientificCanvas
    {

        void ScientificCanvas_Load(object sender, EventArgs e)
        {
            var camera = new Camera(new vec3(3, 1, 2), new vec3(), new vec3(0, 1, 0),
                 CameraType.Perspecitive, this.Width, this.Height);
            var cameraManipulater = new SatelliteManipulater();
            cameraManipulater.Bind(camera, this);
            this.cameraManipulater = cameraManipulater;

            this.Scene = new Scene(camera);
            this.Scene.Cursor.Enabled = false;
            {
                var uiAxis = new UIAxis(AnchorStyles.Left | AnchorStyles.Bottom,
                    new Padding(10, 10, 10, 10), new Size(128, 128), -100, 100);
                uiAxis.Initialize();
                //// display this UI control's area.
                //uiAxis.SwitchList.Add(new ClearColorSwitch());
                this.Axis = uiAxis;
                this.Scene.UIRoot.Children.Add(uiAxis);
            }
            {
                var uiColorPalette = new UIColorPaletteRenderer(100,
                    CodedColor.GetDefault(),
                    AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right,
                    new Padding(148, 10, 60, 10 + 40), new Size(400, 40), -100, 100);
                uiColorPalette.Initialize();
                this.ColorPalette = uiColorPalette;
                this.Scene.UIRoot.Children.Add(uiColorPalette);
            }
            this.Resize += this.Scene.Resize;
            this.OpenGLDraw += ScientificCanvas_OpenGLDraw;
            //this.MouseDown += ScientificCanvas_MouseDown;
            //this.MouseMove += ScientificCanvas_MouseMove;
            //this.MouseUp += ScientificCanvas_MouseUp;
            //this.MouseWheel += ScientificCanvas_MouseWheel;

        }


    }
}
