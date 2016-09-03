using System;
using System.IO;
using System.Windows.Forms;

namespace CSharpGL.Demos
{
    public partial class Form18PickingInScene : Form
    {
        private Scene scene;

        private void Form_Load(object sender, EventArgs e)
        {
            {
                //this.glCanvas1.ShowSystemCursor = false;
            }
            {
                var camera = new Camera(
                    new vec3(15, 5, 0), new vec3(0, 0, 0), new vec3(0, 1, 0),
                    CameraType.Perspecitive, this.glCanvas1.Width, this.glCanvas1.Height);
                var rotator = new FirstPerspectiveManipulater();
                rotator.Bind(camera, this.glCanvas1);
                this.scene = new Scene(camera, this.glCanvas1);
                this.glCanvas1.Resize += this.scene.Resize;
            }
            {
                var ground = GroundRenderer.Create(new GroundModel(100));
                ground.Initialize();
                ground.Scale = new vec3(10, 10, 10);
                ground.WorldPosition = new vec3(0, 0, 0);
                SceneObject obj = ground.WrapToSceneObject("ground");
                this.scene.RootObject.Children.Add(obj);
            }
            {
                var tetrahedron = SimpleRenderer.Create(SimpleRenderer.ModelTypes.Tetrahedron);
                tetrahedron.Initialize();
                tetrahedron.WorldPosition = new vec3(5, 1, 5);
                SceneObject obj = tetrahedron.WrapToSceneObject("Tetrahedron");
                this.scene.RootObject.Children.Add(obj);
            }
        }

    }
}