using System;
using System.Text;

using System.Windows.Forms;

namespace CSharpGL.Demos
{
    public partial class Form02OrderIndependentTransparency : Form
    {
        private Form03OrderDependentTransparency form03;
        private Scene scene;

        private void Form_Load(object sender, EventArgs e)
        {
            {
                var camera = new Camera(
                    new vec3(0, 0, 5), new vec3(0, 0, 0), new vec3(0, 1, 0),
                    CameraType.Perspecitive, this.glCanvas1.Width, this.glCanvas1.Height);
                var rotator = new SatelliteManipulater();
                rotator.Bind(camera, this.glCanvas1);
                rotator.BindingMouseButtons = System.Windows.Forms.MouseButtons.Left | System.Windows.Forms.MouseButtons.Right;
                this.rotator = rotator;
                this.scene = new Scene(camera, this.glCanvas1);
                this.glCanvas1.Resize += this.scene.Resize;
            }
            {
                Teapot model = new Teapot();
                var renderer = new OrderIndependentTransparencyRenderer(
                    model, model.Lengths, Teapot.strPosition, Teapot.strNormal);
                SceneObject obj = renderer.WrapToSceneObject();
                {
                    BoundingBoxRenderer box = renderer.GetBoundingBoxRenderer();
                    SceneObject boxObj = box.WrapToSceneObject();
                    obj.Children.Add(boxObj);
                }
                this.scene.RootObject.Children.Add(obj);
            }

            this.form03 = new Form03OrderDependentTransparency(this);
            this.form03.Show();

            {
                var builder = new StringBuilder();
                builder.AppendLine("1: Scene's property grid.");
                builder.AppendLine("2: Canvas' property grid.");
                MessageBox.Show(builder.ToString());
            }
        }
    }
}