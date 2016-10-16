using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CSharpGL.Demos
{
    public partial class Form18PickingInScene
    {
        private Scene scene;
        private UIText uiText;
        private FormBulletinBoard bulletinBoard;

        private void Form_Load(object sender, EventArgs e)
        {
            foreach (var item in Enum.GetValues(typeof(PickingGeometryType)))
            {
                this.cmbPickingGeometryType.Items.Add(item);
            }
            this.cmbPickingGeometryType.SelectedIndex = 1;

            {
                var frmBulletinBoard = new FormBulletinBoard();
                //frmBulletinBoard.Dump = true;
                frmBulletinBoard.Show();
                this.bulletinBoard = frmBulletinBoard;
            }
            {
                //this.glCanvas1.ShowSystemCursor = false;
            }
            {
                // default(perspective)
                var camera = new Camera(
                    new vec3(15, 5, 0), new vec3(0, 0, 0), new vec3(0, 1, 0),
                    CameraType.Perspecitive, this.glCanvas1.Width, this.glCanvas1.Height);
                var rotator = new FirstPerspectiveManipulater();
                rotator.StepLength = 0.5f;
                rotator.Bind(camera, this.glCanvas1);
                var scene = new Scene(camera, this.glCanvas1);
                //scene.Cursor.Enabled = false;
                this.scene = scene;
                ViewPort viewPort = scene.RootViewPort.Children[0];
                viewPort.BeforeLayout += viewPort_BeforeLayout;
                viewPort.AfterLayout += perspectiveViewPort_AfterLayout;
                this.glCanvas1.Resize += scene.Resize;
            }
            {
                // top
                var camera = new Camera(
                new vec3(0, 0, 25), new vec3(0, 0, 0), new vec3(0, 1, 0),
                CameraType.Perspecitive, this.glCanvas1.Width, this.glCanvas1.Height);
                ViewPort viewPort = new ViewPort(camera, AnchorStyles.None, new Padding(), new Size());
                viewPort.BeforeLayout += viewPort_BeforeLayout;
                viewPort.AfterLayout += topViewPort_AfterLayout;
                this.scene.RootViewPort.Children.Add(viewPort);
            }
            {
                // front
                var camera = new Camera(
                new vec3(0, 25, 0), new vec3(0, 0, 0), new vec3(0, 0, -1),
                CameraType.Perspecitive, this.glCanvas1.Width, this.glCanvas1.Height);
                ViewPort viewPort = new ViewPort(camera, AnchorStyles.None, new Padding(), new Size());
                viewPort.BeforeLayout += viewPort_BeforeLayout;
                viewPort.AfterLayout += frontViewPort_AfterLayout;
                this.scene.RootViewPort.Children.Add(viewPort);
            }
            {
                // left
                var camera = new Camera(
                new vec3(-25, 0, 0), new vec3(0, 0, 0), new vec3(0, 0, -1),
                CameraType.Perspecitive, this.glCanvas1.Width, this.glCanvas1.Height);
                ViewPort viewPort = new ViewPort(camera, AnchorStyles.None, new Padding(), new Size());
                viewPort.BeforeLayout += viewPort_BeforeLayout;
                viewPort.AfterLayout += leftViewPort_AfterLayout;
                this.scene.RootViewPort.Children.Add(viewPort);
            }
            //{
            //    var uiAxis = new UIAxis(AnchorStyles.Left | AnchorStyles.Bottom,
            //  new Padding(3, 3, 3, 3), new Size(128, 128));
            //    uiAxis.Initialize();
            //    this.scene.RootUI.Children.Add(uiAxis);
            //}
            {
                var font = new Font("Courier New", 32);
                var uiText = new UIText(AnchorStyles.Left | AnchorStyles.Bottom,
                    new Padding(0, 0, 0, 0), new Size(250, 20), -100, 100,
                   font.GetFontBitmap("[index: 0123456789]").GetFontTexture());
                uiText.Text = "";
                this.uiText = uiText;
                this.scene.RootUI.Children.Add(uiText);
            }
            {
                GroundRenderer ground = GroundRenderer.Create(new GroundModel(20));
                ground.Initialize();
                ground.Scale = new vec3(20, 20, 20);
                ground.WorldPosition = new vec3(0, 0, 0);
                SceneObject obj = ground.WrapToSceneObject(name: "Ground", generateBoundingBox: true);
                this.scene.RootObject.Children.Add(obj);
            }
            {
                bool useHighlightedPickingEffect = false;
                if (MessageBox.Show("Use highlighted picking effect?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    useHighlightedPickingEffect = true;
                }
                List<PickableRenderer> list = GetPickableRenderers();
                const float distance = 10;
                float sideCount = (float)Math.Sqrt(list.Count);
                int sideCounti = (int)sideCount;
                float x = -sideCount * distance / 2;
                float z = -sideCount * distance / 2;
                //float x = 0, z = 0;
                for (int i = 0; i < list.Count; i++)
                {
                    PickableRenderer item = list[i];
                    SceneObject obj;
                    if (useHighlightedPickingEffect)
                    {
                        var model = item.Model;
                        var highlightRenderer = new HighlightRenderer(model, item.PositionNameInIBufferable);
                        var renderer = new HighlightedPickableRenderer(
                            highlightRenderer, item);
                        renderer.WorldPosition = new vec3(x, 2, z);
                        renderer.Initialize();
                        obj = renderer.WrapToSceneObject(generateBoundingBox: true);
                    }
                    else
                    {
                        item.WorldPosition = new vec3(x, 2, z);
                        obj = item.WrapToSceneObject(generateBoundingBox: true);
                    }
                    this.scene.RootObject.Children.Add(obj);

                    x += distance;
                    if (i % sideCounti == sideCounti - 1)
                    { z += distance; x = -sideCount * distance / 2; }
                }
            }
            {
                this.glCanvas1.MouseDown += glCanvas1_MouseDown;
                this.glCanvas1.MouseMove += glCanvas1_MouseMove;
                this.glCanvas1.MouseUp += glCanvas1_MouseUp;
            }
            {
                var builder = new StringBuilder();
                builder.AppendLine("1: Scene's property grid.");
                builder.AppendLine("2: Canvas' property grid.");
                builder.AppendLine("3: Form's property grid.");
                builder.AppendLine("4: Save to bitmap file.");
                builder.AppendLine("Ctrl+Mouse: Picking.");
                MessageBox.Show(builder.ToString());
            }
        }

        private void viewPort_BeforeLayout(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // cancel layout ILayout's action for this view port.
            e.Cancel = true;
        }

        private void leftViewPort_AfterLayout(object sender, EventArgs e)
        {
            var viewPort = sender as ViewPort;
            Size parentSize = viewPort.Parent.Size;
            viewPort.Location = new Point(0 + 1, 0 + 1);
            viewPort.Size = new Size(parentSize.Width / 2 - 2, parentSize.Height / 2 - 2);
        }

        private void frontViewPort_AfterLayout(object sender, EventArgs e)
        {
            var viewPort = sender as ViewPort;
            Size parentSize = viewPort.Parent.Size;
            viewPort.Location = new Point(parentSize.Width / 2 + 1, parentSize.Height / 2 + 1);
            viewPort.Size = new Size(parentSize.Width / 2 - 2, parentSize.Height / 2 - 2);
        }

        private void topViewPort_AfterLayout(object sender, EventArgs e)
        {
            var viewPort = sender as ViewPort;
            Size parentSize = viewPort.Parent.Size;
            viewPort.Location = new Point(0 + 1, parentSize.Height / 2 + 1);
            viewPort.Size = new Size(parentSize.Width / 2 - 2, parentSize.Height / 2 - 2);
        }

        private void perspectiveViewPort_AfterLayout(object sender, EventArgs e)
        {
            var viewPort = sender as ViewPort;
            Size parentSize = viewPort.Parent.Size;
            viewPort.Location = new Point(parentSize.Width / 2 + 1, 0 + 1);
            viewPort.Size = new Size(parentSize.Width / 2 - 2, parentSize.Height / 2 - 2);
        }

        private List<PickableRenderer> GetPickableRenderers()
        {
            List<PickableRenderer> list = new List<PickableRenderer>();
            {
                SimpleRenderer pickableRenderer = SimpleRenderer.Create(new Tetrahedron());
                pickableRenderer.Initialize();
                list.Add(pickableRenderer);
            }
            {
                SimpleRenderer pickableRenderer = SimpleRenderer.Create(new Teapot());
                pickableRenderer.Initialize();
                list.Add(pickableRenderer);
            }
            {
                SimpleRenderer pickableRenderer = SimpleRenderer.Create(new Sphere());
                pickableRenderer.Initialize();
                list.Add(pickableRenderer);
            }
            {
                SimpleRenderer pickableRenderer = SimpleRenderer.Create(new Chain());
                pickableRenderer.SwitchList.Add(new LineWidthSwitch(5));
                pickableRenderer.Initialize();
                list.Add(pickableRenderer);
            }
            {
                SimpleRenderer pickableRenderer = SimpleRenderer.Create(new BigDipper());
                pickableRenderer.SwitchList.Add(new LineWidthSwitch(5));
                pickableRenderer.Initialize();
                list.Add(pickableRenderer);
            }
            {
                SimpleRenderer pickableRenderer = SimpleRenderer.Create(new Axis(partCount: 6, radius: 1.0f));
                pickableRenderer.Initialize();
                list.Add(pickableRenderer);
            }
            {
                SimpleRenderer pickableRenderer = SimpleRenderer.Create(new Cube(new vec3(5, 4, 3)));
                pickableRenderer.Initialize();
                list.Add(pickableRenderer);
            }
            {
                var points = new List<vec3>(){
                        new vec3(-4.0f, 0.0f, 0.0f),
                        new vec3(-6.0f, 4.0f, 0.0f),
                        new vec3(6.0f, -4.0f, 0.0f),
                        new vec3(4.0f, 0.0f, 0.0f),
                    };
                BezierRenderer pickableRenderer = BezierRenderer.Create(points, BezierType.Curve);
                pickableRenderer.Initialize();
                list.Add(pickableRenderer);
            }
            {
                // note: the points are not centered at (0, 0, 0). Thus the renderer will not be placed at (0, 0, 0).
                var points = new List<vec3>(){
                        new vec3(-4.0f, 0.0f,  4.0f),
                        new vec3(-2.0f, 4.0f,  4.0f),
                        new vec3( 4.0f, 0.0f,  4.0f),
                        new vec3(-4.0f, 0.0f,  0.0f),
                        new vec3(-2.0f, 4.0f,  0.0f),
                        new vec3( 4.0f, 0.0f,  0.0f),
                        new vec3(-4.0f, 0.0f, -4.0f),
                        new vec3(-2.0f, 4.0f, -4.0f),
                        new vec3( 4.0f, 0.0f, -4.0f)
                    };
                BezierRenderer pickableRenderer = BezierRenderer.Create(points, BezierType.Surface);
                pickableRenderer.Initialize();
                list.Add(pickableRenderer);
            }
            {
                SimplexNoiseRenderer pickableRenderer = SimplexNoiseRenderer.Create();
                pickableRenderer.Initialize();
                list.Add(pickableRenderer);
            }
            {
                KleinBottleRenderer pickableRenderer = KleinBottleRenderer.Create(new KleinBottleModel());
                pickableRenderer.Scale = new vec3(0.1f, 0.1f, 0.1f);
                pickableRenderer.Initialize();
                list.Add(pickableRenderer);
            }
            return list;
        }
    }
}