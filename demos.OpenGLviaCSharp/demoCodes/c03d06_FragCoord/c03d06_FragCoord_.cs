using CSharpGL;
using demos.OpenGLviaCSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c03d06_FragCoord {
    internal unsafe class c03d06_FragCoord_ : demoCode {
        public c03d06_FragCoord_(FormInstance mainForm, WindowsGLCanvas canvas) : base(mainForm, canvas) { }
        private Scene scene;
        private ActionList actionList;
        private RectNode rectNode;

        public override void display(GL gl) {
            ActionList list = this.actionList;
            if (list != null) {
                vec4 clearColor = this.scene.clearColor;
                gl.glClearColor(clearColor.x, clearColor.y, clearColor.z, clearColor.w);
                gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);

                int width = this.canvas.Width, height = this.canvas.Height;
                //    var scissor = new int[4];
                //    var viewport = new int[4];
                //    GL.Instance.GetIntegerv((uint)GetTarget.ScissorBox, scissor);
                //    GL.Instance.GetIntegerv((uint)GetTarget.Viewport, viewport);

                Viewport viewport = Viewport.GetCurrent();
                list.Act(new ActionParams(viewport));

                // Reset viewport.
                gl.glScissor(0, 0, width, height);
                gl.glViewport(0, 0, width, height);

            }

        }

        public override void init(GL gl) {
            var position = new vec3(5, 3, 4) * 0.5f;
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspective, this.canvas.Width, this.canvas.Height);
            int width = this.canvas.Width, height = this.canvas.Height;
            this.rectNode = RectNode.Create(0, 0, width, height);
            var scene = new Scene(camera);
            scene.RootNode = rectNode;
            this.scene = scene;

            var list = new ActionList();
            var transformAction = new TransformAction(scene);
            list.Add(transformAction);
            var renderAction = new RenderAction(scene);
            list.Add(renderAction);
            this.actionList = list;

            this.canvas.GLMouseMove += Canvas_GLMouseMove;
        }

        private void Canvas_GLMouseMove(object sender, GLMouseEventArgs e) {
            int x = e.X, y = this.canvas.Height - e.Y - 1;
            Color color = GetColorAtMouse(x, y);
            this.mainForm.SetInfo($"Color at Mouse: {color}");

        }

        private Color GetColorAtMouse(int x, int y) {
            var gl = GL.Current; Debug.Assert(gl != null);
            var colors = stackalloc byte[4];
            gl.glReadPixels(x, y, 1, 1, GL.GL_RGBA, GL.GL_UNSIGNED_BYTE, (IntPtr)colors);
            Color c = Color.FromArgb(colors[3], colors[0], colors[1], colors[2]);

            return c;
        }

        public override void reshape(GL gl, int width, int height) {
            this.scene.camera.AspectRatio = ((float)this.canvas.Width) / ((float)this.canvas.Height);

        }
    }
}
