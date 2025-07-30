using CSharpGL;
using demos.anything;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicTessellationShader {
    internal unsafe class BasicTessellationShader_ : demoCode {
        public BasicTessellationShader_(FormInstance mainForm, WindowsGLCanvas canvas) : base(mainForm, canvas) { }
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
            var position = new vec3(5, 3, 4) * 0.5f;
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspective, this.canvas.Width, this.canvas.Height);
            this.scene = new Scene(camera)
;
            {
                //string folder = System.Windows.Forms.Application.StartupPath;
                //string objFilename = System.IO.Path.Combine(folder + @"\..\..\..\..\Infrastructure\CSharpGL.Models", "quad2.obj_");
                var objFilename = "quad2.obj_";
                var parser = new ObjVNFParser(true);
                ObjVNFResult result = parser.Parse(objFilename);
                if (result.Error != null) {
                    MessageBox.Show(result.Error.ToString());
                }
                else {
                    var model = new ObjVNF(result.Mesh);
                    var node = BasicTessellationNode.Create(model);
                    float max = node.ModelSize.max();
                    node.Scale *= 16.0f / max;
                    node.WorldPosition = new vec3(0, 0, 0);
                    this.scene.RootNode = node;
                    //this.propGrid.SelectedObject = node;
                    (new FormNodePropertyGrid(node)).Show();
                }
            }
            var list = new ActionList();
            var transformAction = new TransformAction(scene);
            list.Add(transformAction);
            var renderAction = new RenderAction(scene);
            list.Add(renderAction);
            this.actionList = list;

            var manipulater = new FirstPerspectiveManipulater();
            manipulater.Bind(camera, this.canvas);

            this.canvas.GLKeyDown += Canvas_GLKeyDown;
            MessageBox.Show("M: change polygon mode");
        }

        private void Canvas_GLKeyDown(object sender, GLKeyEventArgs e) {
            if (e.KeyData == GLKeys.M) {
                if (this.scene.RootNode is BasicTessellationNode node) {
                    switch (node.PolygonMode.mode) {
                    case PolygonMode.Point:
                    node.PolygonMode.mode = PolygonMode.Line;
                    break;
                    case PolygonMode.Line:
                    node.PolygonMode.mode = PolygonMode.Fill;
                    break;
                    case PolygonMode.Fill:
                    node.PolygonMode.mode = PolygonMode.Point;
                    break;
                    default:
                    throw new NotImplementedException();
                    }
                }
            }
        }

        public override void reshape(GL gl, int width, int height) {
            this.scene.camera.AspectRatio = ((float)this.canvas.Width) / ((float)this.canvas.Height);

        }
    }
}
