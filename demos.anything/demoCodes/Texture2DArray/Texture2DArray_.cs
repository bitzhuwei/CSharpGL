using CSharpGL;
using demos.anything;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Texture2DArray {
    internal unsafe class Texture2DArray_ : demoCode {
        public Texture2DArray_(FormInstance mainForm, WindowsGLCanvas canvas) : base(mainForm, canvas) { }
        private Scene scene;
        private ActionList actionList;
        private LayeredRectangleNode node;

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
            SceneNodeBase rootElement = GetRootElement();

            var position = new vec3(1, 0, 4);
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspective, this.canvas.Width, this.canvas.Height);
            this.scene = new Scene(camera) {
                RootNode = rootElement,
                clearColor = Color.SkyBlue.ToVec4(),
            };

            var list = new ActionList();

            var transformAction = new TransformAction(scene);
            list.Add(transformAction);
            var renderAction = new RenderAction(scene);
            list.Add(renderAction);

            this.actionList = list;

            this.canvas.GLKeyDown += Canvas_GLKeyDown;
            MessageBox.Show("N: switch texture indexes");

        }

        private void Canvas_GLKeyDown(object sender, GLKeyEventArgs e) {
            if (e.KeyData == GLKeys.N) {
                this.node.LayerIndex++;
                if (this.node.LayerIndex >= 5) {
                    this.node.LayerIndex = 0;
                }
            }
        }

        private SceneNodeBase GetRootElement() {
            var bmps = new Bitmap[5];
            //string folder = System.Windows.Forms.Application.StartupPath;
            for (int i = 0; i < bmps.Length; i++) {
                //bmps[i] = new Bitmap(System.IO.Path.Combine(folder, string.Format("{0}.png", i)));
                bmps[i] = new Bitmap($"media/textures/2DArray/{i}.png");
            }

            var node = LayeredRectangleNode.Create(bmps);
            node.Scale = new vec3(3, -3, 3);
            this.node = node;
            return node;
        }

        public override void reshape(GL gl, int width, int height) {
            this.scene.camera.AspectRatio = ((float)this.canvas.Width) / ((float)this.canvas.Height);

        }
    }
}
