using CSharpGL;
using demos.OpenGLviaCSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace c13d01_QueryObject {
    internal unsafe class c13d01_QueryObject_ : demoCode {
        public c13d01_QueryObject_(FormInstance mainForm, WindowsGLCanvas canvas) : base(mainForm, canvas) { }
        private Scene scene;
        private DrawModesNode drawModeNode;
        private ActionList actionList;
        private Picking pickingAction;
        private Query query;
        private FormBoard frmBoard;


        public override void display(GL gl) {
            ActionList list = this.actionList;
            if (list != null) {
                //vec4 clearColor = this.scene.ClearColor;
                //GL.Instance.ClearColor(clearColor.x, clearColor.y, clearColor.z, clearColor.w);
                gl.glClearColor(0, 0, 0, 0);
                gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);

                query.BeginQuery(QueryTarget.SamplesPassed);
                {
                    list.Act(new ActionParams(Viewport.GetCurrent()));
                }
                query.EndQuery(QueryTarget.SamplesPassed);
                int sampleCount = this.query.SampleCount();
                this.mainForm.SetInfo($"Sample Passed: {sampleCount}");
            }

        }

        public override void init(GL gl) {
            var position = new vec3(0, 0, 1) * 6;
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspective, this.canvas.Width, this.canvas.Height);
            this.scene = new Scene(camera);
            this.scene.RootNode = GetRootNode();

            //this.triangleTip = new LegacyTriangleNode();
            //this.triangleTip.LineWidth = 10;

            var list = new ActionList();
            list.Add(new TransformAction(scene));
            list.Add(new RenderAction(scene));
            this.actionList = list;

            this.pickingAction = new Picking(scene);

            {
                this.query = new Query();
            }

            var manipulater = new FirstPerspectiveManipulater();
            manipulater.Bind(camera, this.canvas);

            this.canvas.GLMouseMove += Canvas_GLMouseMove;

            this.frmBoard = new FormBoard();
            this.frmBoard.Show();

            this.canvas.GLKeyDown += Canvas_GLKeyDown;

            MessageBox.Show("M: change draw mode");
        }

        private void Canvas_GLKeyDown(object sender, GLKeyEventArgs e) {
            switch (e.KeyData) {
            case GLKeys.M:
            var mode = (uint)this.drawModeNode.DrawMode;
            mode++; if (mode >= (uint)CSharpGL.DrawMode.Patches) { mode = 0; }
            this.drawModeNode.DrawMode = (CSharpGL.DrawMode)mode;
            break;
            default: break;
            }
        }

        private SceneNodeBase GetRootNode() {
            var group = new GroupNode();
            {
                var model = new DrawModesModel();
                var node = DrawModesNode.Create(model, DrawModesModel.strPosition, DrawModesModel.strColor, model.GetSize());
                group.Children.Add(node);

                this.drawModeNode = node;
                (new FormNodePropertyGrid(node)).Show();
            }

            return group;
        }

        public override void reshape(GL gl, int width, int height) {
            this.scene.camera.AspectRatio = ((float)this.canvas.Width) / ((float)this.canvas.Height);

        }

        private void Canvas_GLMouseMove(object sender, GLMouseEventArgs e) {
            int x = e.X;
            int y = this.canvas.Height - e.Y - 1;
            var builder = new StringBuilder();
            {
                var gl = GL.Current; Debug.Assert(gl != null);
                var array = new Pixel[1];
                GCHandle pinned = GCHandle.Alloc(array, GCHandleType.Pinned);
                IntPtr header = pinned.AddrOfPinnedObject();
                // same result with: IntPtr header = Marshal.UnsafeAddrOfPinnedArrayElement(array, 0);
                // get coded color.
                gl.glReadPixels(x, y, 1, 1, GL.GL_RGBA, GL.GL_UNSIGNED_BYTE, header);
                pinned.Free();
                builder.AppendFormat("Color at Mouse: vec4({0})", array[0]);
                builder.AppendLine();
            }
            {
                PickedGeometry pickedGeometry = this.pickingAction.Pick(x, y, GeometryType.Point, this.canvas.Width, this.canvas.Height);

                if (pickedGeometry != null) {
                    builder.AppendFormat("CSharpGL - picked: {0}", pickedGeometry);
                    builder.AppendLine();
                }
                else {
                    builder.AppendFormat("Picked: nothing.");
                    builder.AppendLine();
                }

                this.UpdateHightlight(pickedGeometry);
            }

            this.frmBoard.SetText(builder.ToString());
        }

        private void UpdateHightlight(PickedGeometry pickedGeometry) {
            //if (pickedGeometry != null)
            //{
            //    triangleTip.Vertex0 = pickedGeometry.Positions[0];
            //    triangleTip.Vertex1 = pickedGeometry.Positions[1];
            //    triangleTip.Vertex2 = pickedGeometry.Positions[2];
            //    triangleTip.Parent = pickedGeometry.FromObject as SceneNodeBase;
            //}
            //else
            //{
            //    triangleTip.Parent = null;
            //}
        }

    }
}
