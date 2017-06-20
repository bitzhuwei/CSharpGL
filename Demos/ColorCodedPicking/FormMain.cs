using CSharpGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ColorCodedPicking
{
    public partial class FormMain : Form
    {
        private Scene scene;
        private LegacyTriangleRenderer triangleTip;
        public FormMain()
        {
            InitializeComponent();

            this.Load += FormMain_Load;
            this.winGLCanvas1.OpenGLDraw += winGLCanvas1_OpenGLDraw;
            this.winGLCanvas1.Resize += winGLCanvas1_Resize;
            this.winGLCanvas1.MouseMove += winGLCanvas1_MouseMove;
        }

        /// <summary>
        /// Color coded picking.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void winGLCanvas1_MouseMove(object sender, MouseEventArgs e)
        {
            LegacyTriangleRenderer triangleTip = this.triangleTip;
            if (triangleTip == null) { return; }

            int x = e.X;
            int y = this.winGLCanvas1.Height - e.Y - 1;
            PickedGeometry pickedGeometry = this.scene.Pick(x, y, PickingGeometryType.Triangle);
            if (pickedGeometry != null)
            {
                triangleTip.Vertex0 = pickedGeometry.Positions[0];
                triangleTip.Vertex1 = pickedGeometry.Positions[1];
                triangleTip.Vertex2 = pickedGeometry.Positions[2];
                triangleTip.Parent = pickedGeometry.FromRenderer as ITreeNode;
            }
            else
            {
                triangleTip.Parent = null;
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            var position = new vec3(5, 3, 4);
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspecitive, this.winGLCanvas1.Width, this.winGLCanvas1.Height);
            var teapot = TeapotRenderer.Create();
            teapot.Children.Add(new LegacyBoundingBoxRenderer(teapot.ModelSize));

            this.scene = new Scene(camera, this.winGLCanvas1)
            {
                RootElement = teapot,
            };

        }

        private void winGLCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            this.scene.Render();
        }

        void winGLCanvas1_Resize(object sender, EventArgs e)
        {
            this.scene.Camera.AspectRatio = ((float)this.winGLCanvas1.Width) / ((float)this.winGLCanvas1.Height);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            IWorldSpace renderer = this.scene.RootElement;
            if (renderer != null)
            {
                renderer.RotationAngle += 1;
            }
        }

    }
}
