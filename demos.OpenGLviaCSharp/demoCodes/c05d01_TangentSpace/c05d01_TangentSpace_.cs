using CSharpGL;
using demos.OpenGLviaCSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c05d01_TangentSpace {
    internal unsafe class c05d01_TangentSpace_ : demoCode {
        public c05d01_TangentSpace_(FormInstance mainForm, WindowsGLCanvas canvas) : base(mainForm, canvas) { }
        private Scene scene;
        private ActionList actionList;

        public override void display(GL gl) {
            ActionList list = this.actionList;
            if (list != null) {
                vec4 clearColor = this.scene.clearColor;
                gl.glClearColor(clearColor.x, clearColor.y, clearColor.z, clearColor.w);
                gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);

                Viewport viewport = Viewport.GetCurrent();
                list.Act(new ActionParams(viewport));
            }

        }

        public override void init(GL gl) {
            var position = new vec3(5, 3, 4) * 0.5f;
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspective, this.canvas.Width, this.canvas.Height);
            var scene = new Scene(camera);
            scene.RootNode = GetRootNode();
            this.scene = scene;

            var list = new ActionList();
            var transformAction = new TransformAction(scene);
            list.Add(transformAction);
            var renderAction = new RenderAction(scene);
            list.Add(renderAction);
            this.actionList = list;

            // uncomment these lines to enable manipualter of camera!
            var manipulater = new FirstPerspectiveManipulater();
            manipulater.BindingMouseButtons = GLMouseButtons.Left | GLMouseButtons.Right;
            manipulater.Bind(camera, this.canvas);
            manipulater.StepLength = 0.1f;

        }
        private SceneNodeBase GetRootNode() {
            var group = new GroupNode();

            var sphere = new Sphere(1, 40, 80);
            var filename = "sphere.obj_";
            sphere.DumpObjFile(filename, "sphere");
            var parser = new ObjVNFParser(false);
            ObjVNFResult result = parser.Parse(filename);
            if (result.Error != null) {
                Console.WriteLine("Error: {0}", result.Error);
            }
            else {
                ObjVNFMesh mesh = result.Mesh;
                var model = new ObjVNF(mesh);
                model.DumpObjFile("vnf" + filename, "sphere");
                var sphereNode = ObjVNFNode.Create(mesh);
                (new FormNodePropertyGrid(sphereNode)).Show();
                group.Children.Add(sphereNode);
                {
                    var planeNode = PlaneNode.Create();
                    planeNode.Color = new vec4(1, 1, 1, 1);
                    planeNode.WorldPosition = new vec3(0, 1, 0);
                    planeNode.Scale = new vec3(1, 1, 1) * 0.5f;
                    sphereNode.Children.Add(planeNode);
                }
                {
                    var axisNode = AxisNode.Create();
                    axisNode.WorldPosition = new vec3(0, 1, 0);
                    axisNode.Scale = new vec3(1, 1, 1) * 0.5f;
                    sphereNode.Children.Add(axisNode);
                }
            }

            return group;
        }

        public override void reshape(GL gl, int width, int height) {
            this.scene.camera.AspectRatio = ((float)this.canvas.Width) / ((float)this.canvas.Height);

        }
    }
}
