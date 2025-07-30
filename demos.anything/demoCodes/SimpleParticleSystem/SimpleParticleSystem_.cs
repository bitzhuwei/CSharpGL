using CSharpGL;
using demos.anything;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleParticleSystem {
    internal unsafe class SimpleParticleSystem_ : demoCode {
        public SimpleParticleSystem_(FormInstance mainForm, WindowsGLCanvas canvas) : base(mainForm, canvas) { }
        private Scene scene;
        private ActionList actionList;
        private ParticleNode particleNode;
        private System.Windows.Forms.OpenFileDialog openDlg = new OpenFileDialog();

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
            var rootElement = GetTree();

            var position = new vec3(5, 3, 4) * 0.2f;
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

            var manipulater = new FirstPerspectiveManipulater();
            manipulater.StepLength = 0.1f;
            manipulater.Bind(camera, this.canvas);

            this.canvas.GLKeyDown += Canvas_GLKeyDown;

            var builder = new StringBuilder();
            builder.AppendLine($"T: select a texture file");
            MessageBox.Show(builder.ToString());

        }

        private void Canvas_GLKeyDown(object sender, GLKeyEventArgs e) {
            if (e.KeyData == GLKeys.T) {
                if (this.openDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                    string filename = this.openDlg.FileName;
                    Bitmap bmp = new Bitmap(filename);
                    this.particleNode.UpdateTexture(bmp);
                }
            }
            else if (e.KeyData == GLKeys.M) {
                if (this.particleNode.Mode == ParticleNode.RenderMode.Default) {
                    this.particleNode.Mode = ParticleNode.RenderMode.Textured;
                }
                else {
                    this.particleNode.Mode = ParticleNode.RenderMode.Default;
                }
            }
        }

        private SceneNodeBase GetTree() {
            var node = ParticleNode.Create();
            var ground = GroundNode.Create();
            var group = new GroupNode(ground, node);

            this.particleNode = node;

            return group;
        }


        public override void reshape(GL gl, int width, int height) {
            this.scene.camera.AspectRatio = ((float)this.canvas.Width) / ((float)this.canvas.Height);

        }
    }
}
