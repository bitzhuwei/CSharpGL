using CSharpGL;
using demos.OpenGLviaCSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c15d00_ParticleSystem {
    internal unsafe class c15d00_ParticleSystem_ : demoCode {
        public c15d00_ParticleSystem_(FormInstance mainForm, WindowsGLCanvas canvas) : base(mainForm, canvas) { }
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
            var position = new vec3(5, 3, 4) * 1.6f;
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspective, this.canvas.Width, this.canvas.Height);

            this.scene = new Scene(camera);
            this.scene.clearColor = Color.Black.ToVec4();
            {
                var groupNode = new GroupNode();//, attractorsNode);//, cubeNode);
                {
                    var node = ParticlesNode.Create(6000 / 128);
                    groupNode.Children.Add(node);
                }
                {
                    //string folder = System.Windows.Forms.Application.StartupPath;
                    //string filename = System.IO.Path.Combine(folder + @"\..\..\..\..\Infrastructure\CSharpGL.Models", "floor.obj_");
                    string filename = "floor.obj_";
                    var parser = new ObjVNFParser(true);
                    ObjVNFResult result = parser.Parse(filename);
                    if (result.Error != null) {
                        MessageBox.Show(result.Error.ToString());
                    }
                    else {
                        ObjVNFMesh mesh = result.Mesh;
                        var model = new ObjVNF(mesh);
                        var node = NoShadowNode.Create(model, ObjVNF.strPosition, ObjVNF.strNormal, model.GetSize());
                        node.WorldPosition = new vec3(0, -3, 0);
                        node.Color = new vec3(0, 1, 0);
                        //node.Name = filename;
                        groupNode.Children.Add(node);
                    }
                }

                //var attractorsNode = AttractorsNode.Create(particlesNode);
                //var cubeNode = CubeNode.Create();
                //cubeNode.RenderUnit.Methods[0].SwitchList.Add(new PolygonModeSwitch(PolygonMode.Line));
                this.scene.RootNode = groupNode;
            }
            {
                var light = new PointLight(new vec3(1, 1, 1) * 30);
                this.scene.lights.Add(light);
            }

            {
                var list = new ActionList();
                var transformAction = new TransformAction(scene);
                list.Add(transformAction);
                var renderAction = new RenderAction(scene);
                list.Add(renderAction);
                var blinnPhongAction = new BlinnPhongAction(scene);
                list.Add(blinnPhongAction);
                this.actionList = list;
            }

            var manipulater = new FirstPerspectiveManipulater();
            manipulater.Bind(camera, this.canvas);

        }

        public override void reshape(GL gl, int width, int height) {
            this.scene.camera.AspectRatio = ((float)this.canvas.Width) / ((float)this.canvas.Height);

        }
    }
}
