using CSharpGL;
using demos.OpenGLviaCSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c08d00_gl_VertexID {
    internal unsafe class c08d00_gl_VertexID_ : demoCode {
        public c08d00_gl_VertexID_(FormInstance mainForm, WindowsGLCanvas canvas) : base(mainForm, canvas) { }
        private Scene scene;
        private ActionList actionList;

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

            (new FormNodePropertyGrid(scene.RootNode)).Show();

            var manipulater = new FirstPerspectiveManipulater();
            manipulater.Bind(camera, this.canvas);

        }

        private SceneNodeBase GetRootNode() {
            var group = new GroupNode();
            {
                const int length = 10;
                var model = new PointsModel(length, length, length);
                var node = PointsNode.Create(model, PointsModel.strPosition, PointsModel.strColor, model.GetSize());
                group.Children.Add(node);
            }
            {
                var axisNode = AxisNode.Create();
                axisNode.Scale = new vec3(1, 1, 1) * 10;
                group.Children.Add(axisNode);
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
