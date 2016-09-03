using System;

using System.Windows.Forms;

namespace CSharpGL.Demos
{
    public partial class Form18PickingInScene : Form
    {
        private Scene scene;

        private void Form_Load(object sender, EventArgs e)
        {
            {
                this.glCanvas1.ShowSystemCursor = false;
            }
            {
                var camera = new Camera(
                    new vec3(0, 0, 1), new vec3(0, 0, 0), new vec3(0, 1, 0),
                    CameraType.Perspecitive, this.glCanvas1.Width, this.glCanvas1.Height);
                var rotator = new FirstPerspectiveManipulater();
                rotator.Bind(camera, this.glCanvas1);
                this.scene = new Scene(camera, this.glCanvas1);
                this.glCanvas1.Resize += this.scene.Resize;
            }
            {
                var labelRenderer = new LabelRenderer(1000, 640);
                labelRenderer.Text = "LABEL 2";
                labelRenderer.Initialize();
                labelRenderer.WorldPosition = new vec3(-1, 0, 0);
                SceneObject obj = labelRenderer.WrapToSceneObject("label 2");
                this.scene.RootObject.Children.Add(obj);
            }
        }

    }
}