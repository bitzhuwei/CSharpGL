using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CSharpGL.Demos
{
    public partial class Form18PickingInScene
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
                var uiAxis = new UIAxis(AnchorStyles.Left | AnchorStyles.Bottom,
              new Padding(3, 3, 3, 3), new Size(128, 128), -100, 100);
                uiAxis.Initialize();
                this.scene.UIRoot.Children.Add(uiAxis);
            }
            {
                GroundRenderer ground = GroundRenderer.Create(new GroundModel(20));
                ground.Initialize();
                ground.Scale = new vec3(20, 20, 20);
                ground.WorldPosition = new vec3(0, 0, 0);
                SceneObject obj = ground.WrapToSceneObject("Ground");
                {
                    BoundingBoxRenderer boxRenderer = ground.GetBoundingBoxRenderer();
                    SceneObject boxObj = boxRenderer.WrapToSceneObject("Ground box");
                    obj.Children.Add(boxObj);
                }
                this.scene.RootObject.Children.Add(obj);
            }
            {
                SimpleRenderer tetrahedron = SimpleRenderer.Create(SimpleRenderer.ModelTypes.Tetrahedron);
                tetrahedron.Initialize();
                tetrahedron.WorldPosition = new vec3(5, 2, 5);
                SceneObject obj = tetrahedron.WrapToSceneObject("Tetrahedron");
                {
                    BoundingBoxRenderer boxRenderer = tetrahedron.GetBoundingBoxRenderer();
                    SceneObject boxObj = boxRenderer.WrapToSceneObject("Tetrahedron box");
                    obj.Children.Add(boxObj);
                }
                this.scene.RootObject.Children.Add(obj);
            }
            {
                SimpleRenderer teapot = SimpleRenderer.Create(SimpleRenderer.ModelTypes.Teapot);
                teapot.Initialize();
                teapot.WorldPosition = new vec3(-5, 2, 5);
                SceneObject obj = teapot.WrapToSceneObject("Teapot");
                {
                    BoundingBoxRenderer boxRenderer = teapot.GetBoundingBoxRenderer();
                    SceneObject boxObj = boxRenderer.WrapToSceneObject("Teapot box");
                    obj.Children.Add(boxObj);
                }
                this.scene.RootObject.Children.Add(obj);
            }
        }

    }
}