using CSharpGL;
using demos.anything;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TessellatedTriangle {
    internal unsafe class TessellatedTriangle_ : demoCode {
        public TessellatedTriangle_(FormInstance mainForm, WindowsGLCanvas canvas) : base(mainForm, canvas) { }
        private Scene scene;
        private ActionList actionList;
        private TrianglePatchNode mainNode;


        public override void display(GL gl) {
            ActionList list = this.actionList;
            if (list != null) {
                vec4 clearColor = this.scene.clearColor;
                gl.glClearColor(clearColor.x, clearColor.y, clearColor.z, clearColor.w);
                gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);

                Viewport viewport = Viewport.GetCurrent();
                list.Act(new ActionParams(viewport));
            }

            this.mainNode.RotationAxis = new vec3(0, 1, 0);
            this.mainNode.RotationAngle += 0.7f;

        }

        public override void init(GL gl) {

            var position = new vec3(5, 3, 4) * 0.5f;
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspective, this.canvas.Width, this.canvas.Height);
            this.mainNode = TrianglePatchNode.Create();
            var scene = new Scene(camera);
            scene.RootNode = mainNode;
            this.scene = scene;

            var list = new ActionList();
            var transformAction = new TransformAction(scene);
            list.Add(transformAction);
            var renderAction = new RenderAction(scene);
            list.Add(renderAction);
            this.actionList = list;

            // uncomment these lines to enable manipualter of camera!
            var manipulater = new FirstPerspectiveManipulater();
            manipulater.BindingMouseButtons = GLMouseButtons.Left | GLMouseButtons.Right;// System.Windows.Forms.MouseButtons.Right;
            manipulater.Bind(camera, this.canvas);

            this.canvas.GLKeyDown += Canvas_GLKeyDown;

            var builder = new StringBuilder();
            builder.AppendLine($"0: increase outer 0");
            builder.AppendLine($"1: increase outer 1");
            builder.AppendLine($"2: increase outer 2");
            builder.AppendLine($"3: increase inner 0");
            MessageBox.Show(builder.ToString());

        }

        private void Canvas_GLKeyDown(object sender, GLKeyEventArgs e) {
            if (e.KeyData == GLKeys.D0) {
                this.mainNode.Outer0 += 1.0f;

            }
            else if (e.KeyData == GLKeys.D1) {
                this.mainNode.Outer1 += 1.0f;

            }
            else if (e.KeyData == GLKeys.D2) {
                this.mainNode.Outer2 += 1.0f;

            }
            else if (e.KeyData == GLKeys.D3) {
                this.mainNode.Inner0 += 1.0f;

            }
        }

        public override void reshape(GL gl, int width, int height) {
            this.scene.camera.AspectRatio = ((float)this.canvas.Width) / ((float)this.canvas.Height);

        }
    }
}
