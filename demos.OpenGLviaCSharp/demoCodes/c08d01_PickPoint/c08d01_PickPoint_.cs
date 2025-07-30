using CSharpGL;
using demos.OpenGLviaCSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c08d01_PickPoint {
    internal unsafe class c08d01_PickPoint_ : demoCode {
        public c08d01_PickPoint_(FormInstance mainForm, WindowsGLCanvas canvas) : base(mainForm, canvas) { }
        private Scene scene;
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
            var position = new vec3(1, 0.6f, 1) * 16;
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspective, this.canvas.Width, this.canvas.Height);
            this.scene = new Scene(camera);
            this.scene.RootNode = GetRootNode();

            var list = new ActionList();
            list.Add(new TransformAction(scene));
            list.Add(new RenderAction(scene));
            this.actionList = list;

            this.pickingAction = new Picking(scene);
            this.pickingBoard = new FormBoard();
            this.pickingBoard.Show();

            (new FormNodePropertyGrid(scene.RootNode)).Show();

            var manipulater = new FirstPerspectiveManipulater();
            manipulater.Bind(camera, this.canvas);

            this.canvas.GLMouseMove += Canvas_GLMouseMove;
        }
        private PointsNode pickedNode;

        private void Canvas_GLMouseMove(object sender, GLMouseEventArgs e) {
            var pickingAction = this.pickingAction; Debug.Assert(pickingAction != null);
            int x = e.X;
            int y = this.canvas.Height - e.Y - 1;
            var pickedGeometry = pickingAction.Pick(
                x, y, PickingGeometryTypes.Point, this.canvas.Width, this.canvas.Height);

            if (pickedGeometry != null) {
                this.pickingBoard.SetText(string.Format("CSharpGL - picked: {0}", pickedGeometry));
                var node = pickedGeometry.FromObject as PointsNode;
                if (node != null) {
                    node.HighlightIndex = (int)pickedGeometry.StageVertexId;
                    this.pickedNode = node;
                }
            }
            else {
                this.pickingBoard.SetText("Picked: nothing.");
                if (this.pickedNode != null) {
                    this.pickedNode.HighlightIndex = -1;
                }
            }

        }

        private SceneNodeBase GetRootNode() {
            var group = new GroupNode();
            {
                const int length = 10;
                var model = new PointsModel(length, length, length);
                var node = PointsNode.Create(model, PointsModel.strPosition, PointsModel.strColor, model.GetSize());
                group.Children.Add(node);
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
