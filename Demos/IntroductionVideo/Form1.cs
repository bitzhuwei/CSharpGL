using CSharpGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IntroductionVideo {
    public partial class Form1 : Form {
        private Scene scene;
        private ActionList actionList;
        private CubeNode cubeNode;

        public Form1() {
            InitializeComponent();

            // init resources.
            this.Load += FormMain_Load;
            // render event.
            this.winGLCanvas1.OpenGLDraw += winGLCanvas1_OpenGLDraw;
            // resize event.
            this.winGLCanvas1.Resize += winGLCanvas1_Resize;
        }

        private void FormMain_Load(object sender, EventArgs e) {
            var position = new vec3(5, 3, 4) * 0.5f;
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspective, this.winGLCanvas1.Width, this.winGLCanvas1.Height);
            this.cubeNode = CubeNode.Create();
            var scene = new Scene(camera);
            scene.RootNode = cubeNode;
            this.scene = scene;

            var list = new ActionList();
            var transformAction = new TransformAction(scene);
            list.Add(transformAction);
            var renderAction = new RenderAction(scene);
            list.Add(renderAction);
            this.actionList = list;

            //// uncomment these lines to enable manipualter of camera!
            //var manipulater = new FirstPerspectiveManipulater();
            //manipulater.BindingMouseButtons = System.Windows.Forms.MouseButtons.Right;
            //manipulater.Bind(camera, this.winGLCanvas1);
        }

        private void winGLCanvas1_OpenGLDraw(object sender, PaintEventArgs e) {
            ActionList list = this.actionList;
            if (list != null) {
                vec4 clearColor = this.scene.ClearColor;
                GL.Instance.ClearColor(clearColor.x, clearColor.y, clearColor.z, clearColor.w);
                GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);

                Viewport viewport = Viewport.GetCurrent();
                list.Act(new ActionParams(viewport));
            }
        }

        void winGLCanvas1_Resize(object sender, EventArgs e) {
            this.scene.Camera.AspectRatio = ((float)this.winGLCanvas1.Width) / ((float)this.winGLCanvas1.Height);
        }

        private List<VideoScript> scriptList = new List<VideoScript>();
        private bool allScriptsDone = true;
        private List<VideoScript>.Enumerator enumerator;
        private VideoScript currentScript;

        private void timer1_Tick(object sender, EventArgs e) {
            this.cubeNode.RotationAxis = new vec3(0, 1, 0);
            this.cubeNode.RotationAngle += 7f;

            // how script executes.
            if (allScriptsDone) { return; }
            if (currentScript == null) {
                if (enumerator.MoveNext()) {
                    currentScript = enumerator.Current;
                }
                else {
                    allScriptsDone = true;
                }
            }

            if (currentScript != null) {
                if (!currentScript.Execute()) {
                    currentScript = null;
                }
            }
        }
    }
}
