using CSharpGL;
using demos.OpenGLviaCSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c08d04_DrawModes {
    internal unsafe class c08d04_DrawModes_ : demoCode {
        public c08d04_DrawModes_(FormInstance mainForm, WindowsGLCanvas canvas) : base(mainForm, canvas) { }
        private Scene scene;
        private DrawModesNode drawModeNode;
        private ActionList actionList;
        private Picking pickingAction;
        private FormBoard pickingBoard;

        public override void display(GL gl) {
            ActionList list = this.actionList;
            if (list != null) {
                //vec4 clearColor = this.scene.ClearColor;
                //GL.Instance.ClearColor(clearColor.x, clearColor.y, clearColor.z, clearColor.w);
                gl.glClearColor(0, 0, 0, 0);
                gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);

                list.Act(new ActionParams(Viewport.GetCurrent()));
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
            this.pickingBoard = new FormBoard();
            this.pickingBoard.Show();

            //var manipulater = new FirstPerspectiveManipulater();
            //manipulater.Bind(camera, this.canvas);

            this.canvas.GLKeyDown += Canvas_GLKeyDown;
            MessageBox.Show("S: smooth/flat M: draw mode");
        }

        private void Canvas_GLKeyDown(object sender, GLKeyEventArgs e) {
            switch (e.KeyData) {
            case GLKeys.S:
            if (this.drawModeNode.Method == DrawModesNode.EMethod.Smooth) {
                this.drawModeNode.Method = DrawModesNode.EMethod.Flat;
            }
            else {
                this.drawModeNode.Method = DrawModesNode.EMethod.Smooth;
            }
            break;
            case GLKeys.M:
            var mode = (uint)this.drawModeNode.DrawMode;
            mode++; if (mode >= (uint)CSharpGL.DrawMode.Patches) { mode = 0; }
            this.drawModeNode.DrawMode = (CSharpGL.DrawMode)mode;
            break;
            default: break;
            }
            var builder = new StringBuilder();
            builder.AppendLine($"{this.drawModeNode.Method}");
            builder.AppendLine($"{this.drawModeNode.DrawMode}");
            this.pickingBoard.SetText(builder.ToString());
        }

        private SceneNodeBase GetRootNode() {
            var group = new GroupNode();
            {
                var model = new DrawModesModel();
                var node = DrawModesNode.Create(model, DrawModesModel.strPosition, DrawModesModel.strColor, model.GetSize());
                group.Children.Add(node);

                this.drawModeNode = node;
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
