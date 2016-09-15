using System;
using System.Drawing;
using System.Text;

using System.Windows.Forms;

namespace CSharpGL.Demos
{
    public partial class Form08AnalyzedPointSprite : Form
    {
        private Scene scene;

        private void Form_Load(object sender, EventArgs e)
        {
            {
                var camera = new Camera(
                    new vec3(3, 4, 5) * 2, new vec3(0, 0, 0), new vec3(0, 1, 0),
                    CameraType.Perspecitive, this.glCanvas1.Width, this.glCanvas1.Height);
                var rotator = new SatelliteManipulater();
                rotator.Bind(camera, this.glCanvas1);
                this.scene = new Scene(camera, this.glCanvas1);
                this.glCanvas1.Resize += this.scene.Resize;
            }
            {
                int particleCount = 10000;
                AnalyzedPointSpriteRenderer renderer = AnalyzedPointSpriteRenderer.Create(particleCount);
                renderer.Initialize();
                SceneObject obj = renderer.WrapToSceneObject();
                {
                    BoundingBoxRenderer boxRenderer = renderer.GetBoundingBoxRenderer();
                    SceneObject boxObj = boxRenderer.WrapToSceneObject("Analyzed PointSprite box");
                    obj.Children.Add(boxObj);
                }
                this.scene.RootObject.Children.Add(obj);
            }
            {
                var uiAxis = new UIAxis(AnchorStyles.Left | AnchorStyles.Bottom,
                    new Padding(3, 3, 3, 3), new Size(128, 128));
                uiAxis.Initialize();
                this.scene.UIRoot.Children.Add(uiAxis);
            }
            {
                var builder = new StringBuilder();
                builder.AppendLine("S: Scene's property grid.");
                builder.AppendLine("C: Canvas' property grid.");
                MessageBox.Show(builder.ToString());
            }
        }
    }
}