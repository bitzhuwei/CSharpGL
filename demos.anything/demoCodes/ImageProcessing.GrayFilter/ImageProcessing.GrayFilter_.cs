using CSharpGL;
using demos.anything;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessing.GrayFilter {
    internal unsafe class z_demoCode : demoCode {
        public z_demoCode(FormInstance mainForm, WindowsGLCanvas canvas) : base(mainForm, canvas) { }
        private Scene scene;
        private ActionList actionList;
        private System.Windows.Forms.OpenFileDialog openImageDlg = new System.Windows.Forms.OpenFileDialog();

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
            var position = new vec3(0, 0, 3);
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspective, this.canvas.Width, this.canvas.Height);
            this.scene = new Scene(camera)
;
            {
                var node = GrayFilterNode.Create();
                this.scene.RootNode = node;
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

            MessageBox.Show("I: change image");
        }

        private void Canvas_GLKeyDown(object sender, GLKeyEventArgs e) {
            if (e.KeyCode == GLKeys.I) {
                if (this.openImageDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                    try {
                        string filename = this.openImageDlg.FileName;
                        var bitmap = new Bitmap(filename);
                        var node = this.scene.RootNode as GrayFilterNode;
                        if (node != null) {
                            node.UpdateTexture(bitmap);
                        }
                        bitmap.Dispose();
                    }
                    catch (Exception ex) {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }

        public override void reshape(GL gl, int width, int height) {
            this.scene.camera.AspectRatio = ((float)this.canvas.Width) / ((float)this.canvas.Height);

        }
    }
}
