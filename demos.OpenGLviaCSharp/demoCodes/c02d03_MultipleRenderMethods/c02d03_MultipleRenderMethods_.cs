using CSharpGL;
using demos.OpenGLviaCSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c02d03_MultipleRenderMethods {
    internal unsafe class c02d03_MultipleRenderMethods_ : demoCode {
        public c02d03_MultipleRenderMethods_(FormInstance mainForm, WindowsGLCanvas canvas) : base(mainForm, canvas) { }
        private Scene scene;
        private ActionList actionList;
        private CubeNode cubeNode;

        public override void display(GL gl) {
            ActionList list = this.actionList;
            if (list != null) {
                vec4 clearColor = this.scene.clearColor;
                gl.glClearColor(clearColor.x, clearColor.y, clearColor.z, clearColor.w);
                gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);

                Viewport viewport = Viewport.GetCurrent();
                list.Act(new ActionParams(viewport));
            }

        }

        public override void init(GL gl) {
            var position = new vec3(5, 3, 4) * 0.3f;
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspective, this.canvas.Width, this.canvas.Height);
            //Texture texture0, texture1;
            //GetTextures(out texture0, out texture1);
            var texture0 = Utility.LoadTexture2D("media/textures/base.png");
            texture0.textureUnitIndex = 0;// glActiveTexture(GL_TEXTURE0 + 0); glBindTexture(GL_TEXTURE_2D, texture0.TextureId);
            var texture1 = Utility.LoadTexture2D("media/textures/fish.png");
            texture1.textureUnitIndex = 1;// glActiveTexture(GL_TEXTURE0 + 1); glBindTexture(GL_TEXTURE_2D, texture2.TextureId);
            this.cubeNode = CubeNode.Create(texture0, texture1);
            var scene = new Scene(camera);
            scene.RootNode = cubeNode;
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

            this.canvas.GLKeyPress += Canvas_GLKeyPress;
            MessageBox.Show("M: single color / multiple texture");
        }

        private void Canvas_GLKeyPress(object sender, GLKeyPressEventArgs e) {
            if (e.KeyChar == 'm') {
                switch (this.cubeNode.CurrentMethod) {
                case CubeNode.MethodType.SingleColor:
                this.cubeNode.CurrentMethod = CubeNode.MethodType.MultiTexture;
                break;
                case CubeNode.MethodType.MultiTexture:
                this.cubeNode.CurrentMethod = CubeNode.MethodType.SingleColor;
                break;
                default: throw new NotImplementedException();
                }
            }
        }


        public override void reshape(GL gl, int width, int height) {
            this.scene.camera.AspectRatio = ((float)this.canvas.Width) / ((float)this.canvas.Height);

        }
    }
}
