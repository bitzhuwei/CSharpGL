using CSharpGL;
using System;
using System.Drawing;

namespace ArmadaTank
{
    public partial class FormMain
    {
        private Scene scene;

        private void FormMain_Load(object sender, EventArgs e)
        {
            {
                var camera = new Camera(new vec3(5, 3, 4), new vec3(0, 0, 0), new vec3(0, 1, 0), CameraType.Perspecitive, this.glCanvas1.Width, this.glCanvas1.Height);
                var scene = new Scene(camera, this.glCanvas1);
                scene.ClearColor = Color.SkyBlue;
                this.scene = scene;
            }
            {
                GroundRenderer groundRenderer = GroundRenderer.Create(new GroundModel(20));
                SceneObject obj = groundRenderer.WrapToSceneObject("ground", true);
                this.scene.RootObject.Children.Add(obj);
            }
        }
    }
}