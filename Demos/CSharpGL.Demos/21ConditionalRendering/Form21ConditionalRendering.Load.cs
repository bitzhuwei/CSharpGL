using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace CSharpGL.Demos
{
    public partial class Form21ConditionalRendering
    {
        private Scene scene;
        private ConditionalRenderer conditionalRenderer;

        private void Form_Load(object sender, EventArgs e)
        {
            {
                var camera = new Camera(
                    new vec3(5, 4, 3) * 4, new vec3(0, 0, 0), new vec3(0, 1, 0),
                    CameraType.Perspecitive, this.glCanvas1.Width, this.glCanvas1.Height);
                var rotator = new SatelliteManipulater();
                rotator.Bind(camera, this.glCanvas1);
                this.camera = camera;
                this.rotator = rotator;
                this.scene = new Scene(camera, this.glCanvas1);
                this.glCanvas1.Resize += this.scene.Resize;
            }
            {
                var renderer = ConditionalRenderer.Create();
                renderer.Initialize();
                SceneObject obj = renderer.WrapToSceneObject("Conditional Renderer Demo");
                //{
                //    BoundingBoxRenderer boxRenderer = renderer.GetBoundingBoxRenderer();
                //    SceneObject boxObj = boxRenderer.WrapToSceneObject("Conditional Renderer Demo box");
                //    obj.Children.Add(boxObj);
                //}
                this.scene.RootObject.Children.Add(obj);

                this.conditionalRenderer = renderer;
            }
            //{
            //    var uiAxis = new UIAxis(AnchorStyles.Left | AnchorStyles.Bottom,
            //        new Padding(3, 3, 3, 3), new Size(128, 128));
            //    uiAxis.Initialize();
            //    this.scene.UIRoot.Children.Add(uiAxis);
            //}
            {
                var builder = new StringBuilder();
                builder.AppendLine("O: to select image.");
                builder.AppendLine("S: Scene's property grid.");
                builder.AppendLine("C: Canvas' property grid.");
                MessageBox.Show(builder.ToString());
            }
        }
    }
}