using CSharpGL;
using demos.OpenGLviaCSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c15d01_ParticleSystem2 {
    internal unsafe class c15d01_ParticleSystem2_ : demoCode {
        public c15d01_ParticleSystem2_(FormInstance mainForm, WindowsGLCanvas canvas) : base(mainForm, canvas) { }
        private Scene scene;
        private ActionList actionList;

        private bool stopped = false;
        private ParticlesNode particleNode;
        private AttractorsNode attractorsNode;

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
                var particlesNode = ParticlesNode.Create(10000);
                this.particleNode = particlesNode;
                var attractorsNode = AttractorsNode.Create(particlesNode);
                this.attractorsNode = attractorsNode;
                var cubeNode = CubeNode.Create();
                cubeNode.RenderUnit.Methods[0].SwitchList.Add(new PolygonModeSwitch(PolygonMode.Line));
                var groupNode = new GroupNode(particlesNode, attractorsNode);//, cubeNode);
                this.scene.RootNode = groupNode;
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
        }

        private void Canvas_GLKeyDown(object sender, GLKeyEventArgs e) {
            if (e.KeyData == GLKeys.P) {
                if (this.stopped) {
                    this.particleNode.Stopped = stopped;
                    this.stopped = false;
                }
                else {
                    this.particleNode.Stopped = stopped;
                    this.stopped = true;
                }
            }
            else if (e.KeyData == GLKeys.B) {
                if (this.attractorsNode.EnableRendering == ThreeFlags.None) {
                    this.attractorsNode.EnableRendering = ThreeFlags.BeforeChildren | ThreeFlags.Children;
                }
                else {
                    this.attractorsNode.EnableRendering = ThreeFlags.None;
                }
            }

        }

        public override void reshape(GL gl, int width, int height) {
            this.scene.camera.AspectRatio = ((float)this.canvas.Width) / ((float)this.canvas.Height);

        }
    }
}
