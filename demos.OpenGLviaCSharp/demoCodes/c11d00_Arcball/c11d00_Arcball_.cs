using CSharpGL;
using demos.OpenGLviaCSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c11d00_Arcball {
    internal unsafe class c11d00_Arcball_ : demoCode {
        public c11d00_Arcball_(FormInstance mainForm, WindowsGLCanvas canvas) : base(mainForm, canvas) { }
        private Scene scene;
        private ActionList actionList;
        private ArcBallManipulater manipulater;

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
            var position = new vec3(5, 3, 4);
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspective, this.canvas.Width, this.canvas.Height);
            this.scene = new Scene(camera);
            this.scene.RootNode = GetRootNode();

            var list = new ActionList();
            list.Add(new TransformAction(scene));
            list.Add(new RenderAction(scene));
            this.actionList = list;

            //var manipulater = new FirstPerspectiveManipulater();
            //manipulater.Bind(camera, this.canvas);

            var manipulater = new ArcBallManipulater(GLMouseButtons.Left);
            manipulater.Bind(camera, this.canvas);
            manipulater.Rotated += manipulater_Rotated;
            this.manipulater = manipulater;

            //var frmArcball = new FormArcball(camera, manipulater, this.canvas);
            //frmArcball.Show();

            this.canvas.GLKeyDown += Canvas_GLKeyDown;

            MessageBox.Show("Press 'A' to show FormArcball");
        }

        private void Canvas_GLKeyDown(object sender, GLKeyEventArgs e) {
            if (e.KeyData == GLKeys.A) {
                var frmArcball = new FormArcball(this.scene.camera, this.manipulater, this.canvas);
                frmArcball.Show();
            }
        }

        void manipulater_Rotated(object sender, ArcBallManipulater.Rotation e) {
            {
                SceneNodeBase node = this.scene.RootNode;
                if (node != null) {
                    node.RotationAngle = e.angleInDegree;
                    node.RotationAxis = e.axis;
                }
            }
        }

        private SceneNodeBase GetRootNode() {
            TeapotNode node = TeapotNode.Create();
            node.RenderWireframe = false;
            //(new FormNodeProperyGrid(node)).Show();
            return node;
        }


        public override void reshape(GL gl, int width, int height) {
            this.scene.camera.AspectRatio = ((float)this.canvas.Width) / ((float)this.canvas.Height);

        }
    }
}
