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
        private ActionList actionList;
        private TeapotRenderer teapot;
        private LegacyTriangleRenderer triangleTip;
        private LegacyQuadRenderer quadTip;
        private GroundRenderer ground;
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
            LegacyQuadRenderer quadTip = this.quadTip;
            if (quadTip == null) { return; }

            int x = e.X;
            int y = this.winGLCanvas1.Height - e.Y - 1;
            PickedGeometry pickedGeometry = this.scene.Pick(x, y, true, true, false);
            if (pickedGeometry != null)
            {
                switch (pickedGeometry.Type)
                {
                    case GeometryType.Point:
                        throw new NotImplementedException();
                        break;
                    case GeometryType.Line:
                        throw new NotImplementedException();
                        break;
                    case GeometryType.Triangle:
                        triangleTip.Vertex0 = pickedGeometry.Positions[0];
                        triangleTip.Vertex1 = pickedGeometry.Positions[1];
                        triangleTip.Vertex2 = pickedGeometry.Positions[2];
                        triangleTip.Parent = pickedGeometry.FromRenderer as SceneNodeBase;
                        quadTip.Parent = null;
                        break;
                    case GeometryType.Quad:
                        quadTip.Vertex0 = pickedGeometry.Positions[0];
                        quadTip.Vertex1 = pickedGeometry.Positions[1];
                        quadTip.Vertex2 = pickedGeometry.Positions[2];
                        quadTip.Vertex3 = pickedGeometry.Positions[3];
                        quadTip.Parent = pickedGeometry.FromRenderer as SceneNodeBase;
                        triangleTip.Parent = null;
                        break;
                    case GeometryType.Polygon:
                        throw new NotImplementedException();
                        break;
                    default:
                        break;
                }

            }
            else
            {
                triangleTip.Parent = null;
                quadTip.Parent = null;
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            var position = new vec3(5, 3, 4);
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspecitive, this.winGLCanvas1.Width, this.winGLCanvas1.Height);
            this.teapot = TeapotRenderer.Create();
            teapot.Children.Add(new LegacyBoundingBoxRenderer(teapot.ModelSize));
            this.ground = GroundRenderer.Create(); this.ground.Color = Color.Gray.ToVec4(); this.ground.Scale *= 10; this.ground.WorldPosition = new vec3(0, -3, 0);
            var group = new GroupRenderer(this.teapot, this.ground);

            this.scene = new Scene(camera, this.winGLCanvas1)
            {
                RootElement = group,
            };

            var list = new ActionList();
            var transformAction = new TransformAction(group);
            list.Add(transformAction);
            var renderAction = new RenderAction(group, camera);
            list.Add(renderAction);
            this.actionList = list;

            this.triangleTip = new LegacyTriangleRenderer();
            this.quadTip = new LegacyQuadRenderer();
            this.chkRenderWireframe_CheckedChanged(this.chkRenderWireframe, EventArgs.Empty);
            this.chkRenderBody_CheckedChanged(this.chkRenderBody, EventArgs.Empty);
        }

        private void winGLCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            this.actionList.Render();
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

        private void chkRenderWireframe_CheckedChanged(object sender, EventArgs e)
        {
            this.teapot.RenderWireframe = this.chkRenderWireframe.Checked;
        }

        private void chkRenderBody_CheckedChanged(object sender, EventArgs e)
        {
            this.teapot.RenderBody = this.chkRenderBody.Checked;
        }

    }
}
