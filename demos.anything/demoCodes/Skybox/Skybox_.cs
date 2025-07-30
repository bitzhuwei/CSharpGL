using CSharpGL;
using demos.anything;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skybox {
    internal unsafe class Skybox_ : demoCode {
        public Skybox_(FormInstance mainForm, WindowsGLCanvas canvas) : base(mainForm, canvas) { }
        private Scene scene;
        private ActionList actionList;
        private TeapotNode teapot;
        private SkyboxNode skybox;
        private LegacyTriangleNode triangleTip;
        private LegacyQuadNode quadTip;
        private Picking pickingAction;


        public override void display(GL gl) {
            ActionList list = this.actionList;
            if (list != null) {
                vec4 clearColor = this.scene.clearColor;
                gl.glClearColor(clearColor.x, clearColor.y, clearColor.z, clearColor.w);
                gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);

                list.Act(new ActionParams(Viewport.GetCurrent()));
            }

            IWorldSpace node = this.scene.RootNode;
            if (node != null) {
                node.RotationAngle += 0.1f;
            }

        }

        public override void init(GL gl) {
            var position = new vec3(8, 6, 4) * 4;
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspective, this.canvas.Width, this.canvas.Height);
            this.teapot = TeapotNode.Create(); this.teapot.Scale *= 3;
            teapot.Children.Add(new LegacyBoundingBoxNode(teapot.ModelSize));
            //string folder = System.Windows.Forms.Application.StartupPath;
            //var totalBmp = new Bitmap(System.IO.Path.Combine(folder, @"cubemaps_skybox-on-water.png"));
            var totalBmp = new Bitmap("media/textures/cubemaps_skybox-on-water.png");
            this.skybox = SkyboxNode.Create(totalBmp); this.skybox.Scale *= 60;
            var group = new GroupNode(this.teapot, this.skybox);

            this.scene = new Scene(camera) {
                RootNode = group,
            };

            var list = new ActionList();
            var transformAction = new TransformAction(scene);
            list.Add(transformAction);
            var renderAction = new RenderAction(scene);
            list.Add(renderAction);
            this.actionList = list;

            var manipulater = new FirstPerspectiveManipulater();
            manipulater.Bind(camera, this.canvas);

            this.pickingAction = new Picking(scene);

            this.triangleTip = new LegacyTriangleNode();
            this.quadTip = new LegacyQuadNode();
            //this.chkRenderWireframe_CheckedChanged(this.chkRenderWireframe, EventArgs.Empty);
            //this.chkRenderBody_CheckedChanged(this.chkRenderBody, EventArgs.Empty);

            this.canvas.GLMouseMove += Canvas_GLMouseMove;
            this.canvas.GLKeyDown += Canvas_GLKeyDown;
        }

        private void Canvas_GLKeyDown(object sender, GLKeyEventArgs e) {
            if (e.KeyData == GLKeys.F) {
                this.teapot.RenderWireframe = !this.teapot.RenderWireframe;

            }
            else if (e.KeyData == GLKeys.B) {
                this.teapot.RenderBody = !this.teapot.RenderBody;
            }
        }

        private void Canvas_GLMouseMove(object sender, GLMouseEventArgs e) {
            LegacyTriangleNode triangleTip = this.triangleTip;
            if (triangleTip == null) { return; }
            LegacyQuadNode quadTip = this.quadTip;
            if (quadTip == null) { return; }

            int x = e.X;
            int y = this.canvas.Height - e.Y - 1;
            PickedGeometry pickedGeometry = this.pickingAction.Pick(x, y, PickingGeometryTypes.Triangle | PickingGeometryTypes.Quad, this.canvas.Width, this.canvas.Height);
            if (pickedGeometry != null) {
                switch (pickedGeometry.Type) {
                case GeometryType.Point:
                throw new NotImplementedException();
                case GeometryType.Line:
                throw new NotImplementedException();
                case GeometryType.Triangle:
                triangleTip.Vertex0 = pickedGeometry.Positions[0];
                triangleTip.Vertex1 = pickedGeometry.Positions[1];
                triangleTip.Vertex2 = pickedGeometry.Positions[2];
                triangleTip.Parent = pickedGeometry.FromObject as SceneNodeBase;
                quadTip.Parent = null;
                break;
                case GeometryType.Quad:
                quadTip.Vertex0 = pickedGeometry.Positions[0];
                quadTip.Vertex1 = pickedGeometry.Positions[1];
                quadTip.Vertex2 = pickedGeometry.Positions[2];
                quadTip.Vertex3 = pickedGeometry.Positions[3];
                quadTip.Parent = pickedGeometry.FromObject as SceneNodeBase;
                triangleTip.Parent = null;
                break;
                case GeometryType.Polygon:
                throw new NotImplementedException();
                default:
                throw new NotDealWithNewEnumItemException(typeof(GeometryType));
                }

            }
            else {
                triangleTip.Parent = null;
                quadTip.Parent = null;
            }

        }

        public override void reshape(GL gl, int width, int height) {
            this.scene.camera.AspectRatio = ((float)this.canvas.Width) / ((float)this.canvas.Height);

        }
    }
}
