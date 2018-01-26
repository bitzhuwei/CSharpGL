using CSharpGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Skybox
{
    public partial class FormMain : Form
    {
        private Scene scene;
        private ActionList actionList;
        private TeapotNode teapot;
        private SkyboxNode skybox;
        private LegacyTriangleNode triangleTip;
        private LegacyQuadNode quadTip;
        private PickingAction pickingAction;

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
            LegacyTriangleNode triangleTip = this.triangleTip;
            if (triangleTip == null) { return; }
            LegacyQuadNode quadTip = this.quadTip;
            if (quadTip == null) { return; }

            int x = e.X;
            int y = this.winGLCanvas1.Height - e.Y - 1;
            PickedGeometry pickedGeometry = this.pickingAction.Pick(x, y, PickingGeometryTypes.Triangle | PickingGeometryTypes.Quad, this.winGLCanvas1.Width, this.winGLCanvas1.Height);
            if (pickedGeometry != null)
            {
                switch (pickedGeometry.Type)
                {
                    case GeometryType.Point:
                        throw new NotImplementedException();
                    case GeometryType.Line:
                        throw new NotImplementedException();
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
                    default:
                        throw new NotDealWithNewEnumItemException(typeof(GeometryType));
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
            var position = new vec3(8, 6, 4) * 4;
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspecitive, this.winGLCanvas1.Width, this.winGLCanvas1.Height);
            this.teapot = TeapotNode.Create(); this.teapot.Scale *= 3;
            teapot.Children.Add(new LegacyBoundingBoxNode(teapot.ModelSize));
            string folder = System.Windows.Forms.Application.StartupPath;
            var totalBmp = new Bitmap(System.IO.Path.Combine(folder, @"cubemaps_skybox.png"));
            this.skybox = SkyboxNode.Create(totalBmp); this.skybox.Scale *= 60;
            var group = new GroupNode(this.teapot, this.skybox);

            this.scene = new Scene(camera)

            {
                RootElement = group,
            };

            var list = new ActionList();
            var transformAction = new TransformAction(scene);
            list.Add(transformAction);
            var renderAction = new RenderAction(scene);
            list.Add(renderAction);
            this.actionList = list;

            var manipulater = new FirstPerspectiveManipulater();
            manipulater.Bind(camera, this.winGLCanvas1);

            this.pickingAction = new PickingAction(scene);

            this.triangleTip = new LegacyTriangleNode();
            this.quadTip = new LegacyQuadNode();
            this.chkRenderWireframe_CheckedChanged(this.chkRenderWireframe, EventArgs.Empty);
            this.chkRenderBody_CheckedChanged(this.chkRenderBody, EventArgs.Empty);
        }

        private void winGLCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            ActionList list = this.actionList;
            if (list != null)
            {
                vec4 clearColor = this.scene.ClearColor;
                GL.Instance.ClearColor(clearColor.x, clearColor.y, clearColor.z, clearColor.w);
                GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);

                list.Act(new ActionParams(Viewport.GetCurrent()));
            }
        }

        void winGLCanvas1_Resize(object sender, EventArgs e)
        {
            this.scene.Camera.AspectRatio = ((float)this.winGLCanvas1.Width) / ((float)this.winGLCanvas1.Height);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            IWorldSpace node = this.scene.RootElement;
            if (node != null)
            {
                node.RotationAngle += 1;
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
