using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
                this.glSceneCanvas1.Scene.UIRoot.Children.Add(uiAxis);
            }
            {
                var ground = GroundRenderer.Create(new GroundModel(20));
                ground.Scale = new vec3(10, 10, 10);
                SceneObject obj = ground.WrapToSceneObject("ground");
                BoundingBoxRenderer box = ground.GetBoundingBoxRenderer();
                SceneObject boxObj = box.WrapToSceneObject("box");
                obj.Children.Add(boxObj);
                this.glSceneCanvas1.Scene.RootObject.Children.Add(obj);
            }
            {
                var axis = DemoRenderer.Create(DemoRenderer.ModelTypes.Axis);
                SceneObject obj = axis.WrapToSceneObject("Axis");
                BoundingBoxRenderer box = axis.GetBoundingBoxRenderer();
                SceneObject boxObj = box.WrapToSceneObject("box");
                obj.Children.Add(boxObj);
                this.glSceneCanvas1.Scene.RootObject.Children.Add(obj);
            }
        }
    }
}
