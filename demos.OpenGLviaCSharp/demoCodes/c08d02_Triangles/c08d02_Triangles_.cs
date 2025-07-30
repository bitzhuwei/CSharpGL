using CSharpGL;
using demos.OpenGLviaCSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c08d02_Triangles {
    internal unsafe class c08d02_Triangles_ : demoCode {
        public c08d02_Triangles_(FormInstance mainForm, WindowsGLCanvas canvas) : base(mainForm, canvas) { }
        private Scene scene;
        private TrianglesNode triangleNode;
        private ActionList actionList;
        private Picking pickingAction;
        private FormBoard pickingBoard;

        public override void display(GL gl) {
            ActionList list = this.actionList;
            if (list != null) {
                vec4 clearColor = this.scene.clearColor;
                gl.glClearColor(clearColor.x, clearColor.y, clearColor.z, clearColor.w);
                gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);

                list.Act(new ActionParams(Viewport.GetCurrent()));
            }

        }

        public override void init(GL gl) {
            var position = new vec3(1, 0.6f, 1) * 4;
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspective, this.canvas.Width, this.canvas.Height);
            this.scene = new Scene(camera);
            this.scene.RootNode = GetRootNode();

            this.triangleTip = new LegacyTriangleNode();
            this.triangleTip.LineWidth = 10;

            var list = new ActionList();
            list.Add(new TransformAction(scene));
            list.Add(new RenderAction(scene));
            this.actionList = list;

            this.pickingAction = new Picking(scene);
            this.pickingBoard = new FormBoard();
            this.pickingBoard.Show();

            var manipulater = new FirstPerspectiveManipulater();
            manipulater.Bind(camera, this.canvas);

            this.canvas.GLMouseMove += Canvas_GLMouseMove;
            this.canvas.GLKeyDown += Canvas_GLKeyDown;
        }

        private void Canvas_GLKeyDown(object sender, GLKeyEventArgs e) {
            if (e.KeyData == GLKeys.M) {
                switch (this.triangleNode.Method) {
                case TrianglesNode.EMethod.Random:
                this.triangleNode.Method = TrianglesNode.EMethod.gl_VertexID;
                break;
                case TrianglesNode.EMethod.gl_VertexID:
                this.triangleNode.Method = TrianglesNode.EMethod.Random;
                break;
                default: throw new NotImplementedException();
                }
            }
        }

        private LegacyTriangleNode triangleTip;
        private void Canvas_GLMouseMove(object sender, GLMouseEventArgs e) {
            var gl = GL.Current; Debug.Assert(gl != null);
            int x = e.X;
            int y = this.canvas.Height - e.Y - 1;
            var builder = new StringBuilder();
            {
                //var array = new Pixel[1];
                //GCHandle pinned = GCHandle.Alloc(array, GCHandleType.Pinned);
                //IntPtr header = pinned.AddrOfPinnedObject();
                // same result with: IntPtr header = Marshal.UnsafeAddrOfPinnedArrayElement(array, 0);
                // get coded color.
                //gl.glReadPixels(x, y, 1, 1, GL.GL_RGBA, GL.GL_UNSIGNED_BYTE, header);
                //pinned.Free();
                var array = stackalloc byte[4];
                gl.glReadPixels(x, y, 1, 1, GL.GL_RGBA, GL.GL_UNSIGNED_BYTE, (IntPtr)array);
                builder.AppendFormat($"Color at Mouse: vec4({array[0]}, {array[1]}, {array[2]}, {array[3]})");
                builder.AppendLine();
            }
            {
                var pickedGeometry = this.pickingAction.Pick(x, y, PickingGeometryTypes.Triangle, this.canvas.Width, this.canvas.Height);

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

            this.pickingBoard.SetText(builder.ToString());

        }
        private void UpdateHightlight(PickedGeometry? pickedGeometry) {
            if (pickedGeometry != null) {
                triangleTip.Vertex0 = pickedGeometry.Positions[0];
                triangleTip.Vertex1 = pickedGeometry.Positions[1];
                triangleTip.Vertex2 = pickedGeometry.Positions[2];
                triangleTip.Parent = pickedGeometry.FromObject as SceneNodeBase;
            }
            else {
                triangleTip.Parent = null;
            }
        }

        private SceneNodeBase GetRootNode() {
            var group = new GroupNode();
            {
                const int length = 5;
                var model = new TrianglesModel(length, length, length);
                var node = TrianglesNode.Create(model, TrianglesModel.strPosition, TrianglesModel.strColor, model.GetSize());
                group.Children.Add(node);

                this.triangleNode = node;
            }
            return group;
        }
        //private SceneNodeBase GetRootNode()
        //{
        //    var group = new GroupNode();
        //    var filenames = new string[] { "floor.obj_", "cube.obj_", };
        //    var colors = new Color[] { Color.Green, Color.White, };
        //    for (int i = 0; i < filenames.Length; i++)
        //    {
        //        string folder = System.Windows.Forms.Application.StartupPath;
        //        string filename = System.IO.Path.Combine(folder + @"\..\..\..\..\Infrastructure\CSharpGL.Models", filenames[i]);
        //        var parser = new ObjVNFParser(true);
        //        ObjVNFResult result = parser.Parse(filename);
        //        if (result.Error != null)
        //        {
        //            MessageBox.Show(result.Error.ToString());
        //        }
        //        else
        //        {
        //            ObjVNFMesh mesh = result.Mesh;
        //            var model = new AdjacentTriangleModel(mesh);
        //            var node = PointsNode.Create(model, ObjVNF.strPosition, ObjVNF.strNormal, model.GetSize());
        //            node.Color = colors[i].ToVec3();
        //            node.WorldPosition = new vec3(0, i * 5, 0);
        //            node.Name = filename;
        //            group.Children.Add(node);
        //        }
        //    }

        //    return group;
        //}

        public override void reshape(GL gl, int width, int height) {
            this.scene.camera.AspectRatio = ((float)this.canvas.Width) / ((float)this.canvas.Height);

        }
    }
}
