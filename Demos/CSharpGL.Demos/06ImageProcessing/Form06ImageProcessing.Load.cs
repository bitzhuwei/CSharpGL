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
    public partial class Form06ImageProcessing : Form
    {
        private Scene scene;

        private void Form_Load(object sender, EventArgs e)
        {
            {
                var camera = new Camera(
                    new vec3(0, 0, -1), new vec3(0, 0, 0), new vec3(0, 1, 0),
                    CameraType.Perspecitive, this.glCanvas1.Width, this.glCanvas1.Height);
                var rotator = new SatelliteManipulater();
                rotator.Bind(camera, this.glCanvas1);
                this.rotator = rotator;
                this.scene = new Scene(camera);
                this.glCanvas1.Resize += this.scene.Resize;
            }
            {
                var renderer = new ImageProcessingRenderer();
                renderer.Initialize();
                var obj = new SceneObject();
                obj.RendererComponent = new RendererBaseComponent(renderer);
                obj.ScriptList.Add(new UpdateImageScript(this.glCanvas1));
                this.scene.ObjectList.Add(obj);
            }
            {
                var frmPropertyGrid = new FormProperyGrid(this.scene);
                frmPropertyGrid.Show();
            }
        }
    }
}
