using System;
using System.Drawing;
using System.Windows.Forms;

namespace CSharpGL.Demos
{
    public partial class Form20GLSceneCanvas : Form
    {
        public Form20GLSceneCanvas()
        {
            InitializeComponent();
        }

        private void glSceneCanvas1_Load(object sender, EventArgs e)
        {
            {
                this.glSceneCanvas1.Scene.Camera.Position = new vec3(5, 4, 3);
            }
            {
                const int size = 128;
                var uiAxis = new UIAxis(AnchorStyles.Left | AnchorStyles.Bottom,
                    new Padding(10, 10, 10, 10), new Size(size, size));
                this.glSceneCanvas1.Scene.UIRoot.LayoutManager.Children.Add(uiAxis.LayoutManager);
            }
            {
                var ground = GroundRenderer.Create(new GroundModel(20));
                ground.Scale = new vec3(10, 10, 10);
                SceneObject obj = ground.WrapToSceneObject(name: "ground", generateBoundingBox: true);
                this.glSceneCanvas1.Scene.RootObject.Children.Add(obj);
            }
            {
                SimpleRenderer axis = SimpleRenderer.Create(new Axis());
                SceneObject obj = axis.WrapToSceneObject(name: "Axis", generateBoundingBox: true);
                this.glSceneCanvas1.Scene.RootObject.Children.Add(obj);
            }
        }
    }
}