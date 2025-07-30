using CSharpGL;
using demos.anything;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenderToTexture {
    internal unsafe class RenderToTexture_ : demoCode {
        public RenderToTexture_(FormInstance mainForm, WindowsGLCanvas canvas) : base(mainForm, canvas) { }
        private Scene scene;
        private ActionList actionList;
        //private LegacyRectangleRenderer rectangle;//LegacyRectangleRenderer dosen't work in rendering-to-texture.
        private MultiTargetTeapotNode teapot;
        //private RenderToTextureNode rtt;
        private MultiTargetFramebufferProvider framebufferProvider;
        private RectangleNode rectangle;

        private const int width = 400, height = 200;

        private bool rotateRect = true;
        private bool rotateTeapot = true;

        public override void display(GL gl) {
            ActionList list = this.actionList;
            if (list != null) {
                vec4 clearColor = this.scene.clearColor;
                gl.glClearColor(clearColor.x, clearColor.y, clearColor.z, clearColor.w);
                gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);

                list.Act(new ActionParams(Viewport.GetCurrent()));
            }

            if (this.rotateRect) {
                IWorldSpace node = this.rectangle;
                if (node != null) {
                    node.RotationAngle += 1;
                }
            }

            if (this.rotateTeapot) {
                IWorldSpace node = this.teapot;
                if (node != null) {
                    node.RotationAngle += 10;
                }
            }

        }

        public override void init(GL gl) {
            var teapot = MultiTargetTeapotNode.Create();
            this.teapot = teapot;

            var framebufferProvider = new MultiTargetFramebufferProvider();
            this.framebufferProvider = framebufferProvider;
            var rtt = new RenderToTextureNode(width, height, new Camera(new vec3(0, 0, 5), new vec3(0, 0, 0), new vec3(0, 1, 0), CameraType.Perspective, width, height), framebufferProvider);
            rtt.Children.Add(teapot);// rendered to framebuffer, then to texture.
            //this.rtt = rtt;

            var rectangle = RectangleNode.Create();
            //var rectangle = new LegacyRectangleRenderer();//LegacyRectangleRenderer dosen't work in rendering-to-texture.
            rectangle.TextureSource = rtt;
            rectangle.Scale = new vec3(7, 7, 7);
            this.rectangle = rectangle;

            var group = new GroupNode();
            group.Children.Add(rtt);
            group.Children.Add(rectangle);

            var position = new vec3(5, 1, 4);
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspective, this.canvas.Width, this.canvas.Height);
            this.scene = new Scene(camera) {
                clearColor = Color.SkyBlue.ToVec4(),
                RootNode = group,
            };

            var list = new ActionList();
            var transformAction = new TransformAction(scene);
            list.Add(transformAction);
            var renderAction = new RenderAction(scene);
            list.Add(renderAction);
            this.actionList = list;

            this.canvas.GLKeyDown += Canvas_GLKeyDown;
        }

        private void Canvas_GLKeyDown(object sender, GLKeyEventArgs e) {
            if (e.KeyData == GLKeys.R) {
                this.rotateRect = !this.rotateRect;
            }
            else if (e.KeyData == GLKeys.T) {
                this.rotateTeapot = !this.rotateTeapot;
            }
            else if (e.KeyData == GLKeys.B) {
                this.rectangle.TransparentBackground = !this.rectangle.TransparentBackground;
            }
            else if (e.KeyData == GLKeys.X) {
                var textures = this.framebufferProvider.OutTextures;
                for (int i = 0; i < textures.Length; i++) {
                    var glBmp = textures[i].GetImage(width, height);
                    var bitmap = new Bitmap(width, height, width * glBmp.PixelBytes,
                        System.Drawing.Imaging.PixelFormat.Format32bppArgb, glBmp.Scan0);
                    bitmap.Save(string.Format("rtt[{0}].png", i));
                }
            }
        }

        public override void reshape(GL gl, int width, int height) {
            this.scene.camera.AspectRatio = ((float)this.canvas.Width) / ((float)this.canvas.Height);

        }
    }
}
