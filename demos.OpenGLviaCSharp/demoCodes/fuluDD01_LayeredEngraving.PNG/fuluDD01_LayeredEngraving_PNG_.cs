using CSharpGL;
using demos.OpenGLviaCSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fuluDD01_LayeredEngraving.PNG {
    internal unsafe class fuluDD01_LayeredEngraving_PNG_ : demoCode {
        public fuluDD01_LayeredEngraving_PNG_(FormInstance mainForm, WindowsGLCanvas canvas) : base(mainForm, canvas) { }
        private Scene scene;
        private ActionList actionList;
        private PeelingNode peelingNode;
        private RaycastNode raycastNode;

        public override void display(GL gl) {
            ActionList list = this.actionList;
            if (list != null) {
                vec4 clearColor = this.scene.clearColor;
                gl.glClearColor(clearColor.x, clearColor.y, clearColor.z, clearColor.w);
                gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);

                list.Act(new ActionParams(Viewport.GetCurrent()));
            }

            var node = this.raycastNode;
            if (node != null) {
                node.RotationAxis = new vec3(0, 1, 0);
                node.RotationAngle += 1;
            }

        }

        public override void init(GL gl) {
            var position = new vec3(5, 4, 3) * 0.3f;
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspective, this.canvas.Width, this.canvas.Height);
            var scene = new Scene(camera);
            var rootElement = GetTree(scene);
            scene.RootNode = rootElement;
            scene.clearColor = Color.SkyBlue.ToVec4();
            this.scene = scene;

            var list = new ActionList();
            var transformAction = new TransformAction(scene);
            list.Add(transformAction);
            var renderAction = new RenderAction(scene);
            list.Add(renderAction);
            this.actionList = list;

            // Note: uncomment this to enable camera movement.
            var manipulater = new FirstPerspectiveManipulater();
            manipulater.StepLength = 0.1f;
            manipulater.Bind(camera, this.canvas);

        }

        private SceneNodeBase GetTree(Scene scene) {
            var groupNode = new GroupNode();
            {
                var children = new List<SceneNodeBase>();
                const float alpha = 0.2f;
                var colors = new vec4[] {
                    new vec4(1, 0, 0, alpha), new vec4(0, 1, 0, alpha), new vec4(0, 0, 1, alpha),
                    new vec4(1, 1, 0, alpha), new vec4(0.5f, 0.5f, 0.5f, alpha), new vec4(1, 0, 1, alpha),
                    new vec4(1, 0, 0, alpha), new vec4(0, 1, 0, alpha), new vec4(0, 0, 1, alpha),

                    new vec4(1, 1, 0, alpha), new vec4(0.5f, 0.5f, 0.5f, alpha), new vec4(1, 0, 1, alpha),
                    new vec4(1, 0, 0, alpha), new vec4(0, 1, 0, alpha), new vec4(0, 0, 1, alpha),
                    new vec4(1, 0, 0, alpha), new vec4(0, 1, 0, alpha), new vec4(0, 0, 1, alpha),

                    new vec4(1, 0, 0, alpha), new vec4(1, 0, 0, alpha), new vec4(1, 0, 0, alpha),
                    new vec4(1, 1, 0, alpha), new vec4(1, 1, 0, alpha), new vec4(1, 1, 0, alpha),
                    new vec4(1, 0, 0, alpha), new vec4(1, 0, 0, alpha), new vec4(1, 0, 0, alpha),

                };

                int index = 0;
                var size = new vec3(5, 5, 5);
                for (int j = -1; j < 2; j++) {
                    for (int i = -1; i < 2; i++) {
                        vec3 worldSpacePosition = new vec3(i * 2, j * 2, -2);// +new vec3(-2.375f, -1.75f, 0);
                        //var cubeNode = CubeNode.Create(new CubeModel(), CubeModel.positions);
                        //var cubeNode = CubeNode.Create(new RectangleModel(), RectangleModel.strPosition);
                        var cubeNode = CubeNode.Create(new Sphere(0.5f), Sphere.strPosition);
                        cubeNode.WorldPosition = worldSpacePosition;
                        cubeNode.Color = colors[index++];

                        children.Add(cubeNode);
                    }
                }
                {
                    var positionList = new List<vec3>();
                    positionList.Add(new vec3(0, 0, 0));
                    positionList.Add(new vec3(2, 0, 0));
                    positionList.Add(new vec3(0, 2, 2));
                    positionList.Add(new vec3(2, 2, 2));
                    for (int i = 0; i < positionList.Count; i++) {
                        //var cubeNode = CubeNode.Create(new CubeModel(), CubeModel.positions);
                        //var cubeNode = CubeNode.Create(new RectangleModel(), RectangleModel.strPosition);
                        var cubeNode = i > 1 ? CubeNode.Create(new Sphere(0.5f), Sphere.strPosition) : CubeNode.Create(new RectangleModel(), RectangleModel.strPosition); cubeNode.WorldPosition = positionList[i];
                        cubeNode.Color = colors[index++];

                        children.Add(cubeNode);
                    }
                }
                //{
                //    string folder = System.Windows.Forms.Application.StartupPath;
                //    string objFilename = System.IO.Path.Combine(folder + @"\..\..\..\..\Infrastructure\CSharpGL.Models", "vnfHanoiTower.obj_");
                //    var parser = new ObjVNFParser(true);
                //    ObjVNFResult result = parser.Parse(objFilename);
                //    if (result.Error != null)
                //    {
                //        MessageBox.Show(result.Error.ToString());
                //    }
                //    else
                //    {
                //        var model = new ObjVNF(result.Mesh);
                //        var cubeNode = CubeNode.Create(model, ObjVNF.strPosition);
                //        cubeNode.Color = Color.Red.ToVec4();
                //        size = model.GetSize();
                //        float max = size.max();
                //        size = new vec3(max, max, max);
                //        children.Add(cubeNode);
                //    }
                //}
                this.peelingNode = new PeelingNode(size, children.ToArray());
                groupNode.Children.Add(this.peelingNode);
            }
            {
                this.raycastNode = RaycastNode.Create(this.peelingNode);
                groupNode.Children.Add(this.raycastNode);
            }

            return groupNode;
        }

        public override void reshape(GL gl, int width, int height) {
            this.scene.camera.AspectRatio = ((float)this.canvas.Width) / ((float)this.canvas.Height);

        }
    }
}
