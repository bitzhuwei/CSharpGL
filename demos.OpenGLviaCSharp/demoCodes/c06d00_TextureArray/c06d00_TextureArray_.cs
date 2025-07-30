using CSharpGL;
using demos.OpenGLviaCSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c06d00_TextureArray {
    internal unsafe class c06d00_TextureArray_ : demoCode {
        public c06d00_TextureArray_(FormInstance mainForm, WindowsGLCanvas canvas) : base(mainForm, canvas) { }
        private Scene scene;
        private ActionList actionList;
        private SceneNodeBase rootNode;

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
            var position = new vec3(5, 3, 4);
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Ortho, this.canvas.Width, this.canvas.Height);
            var scene = new Scene(camera);
            var rootNode = GetRootNode();
            scene.RootNode = rootNode;
            this.scene = scene;
            this.rootNode = rootNode;

            var list = new ActionList();
            var transformAction = new TransformAction(scene);
            list.Add(transformAction);
            var renderAction = new RenderAction(scene);
            list.Add(renderAction);
            this.actionList = list;

            // Enable manipualter of camera!
            var manipulater = new FirstPerspectiveManipulater();
            manipulater.BindingMouseButtons = GLMouseButtons.Left | GLMouseButtons.Right;
            manipulater.Bind(camera, this.canvas);

        }
        private SceneNodeBase GetRootNode() {
            var rootNode = new GroupNode();
            var filenames = new string[] {
                "media/textures/index2.png",
                "media/textures/index1.png",
                "media/textures/index0.png",
            };
            for (int i = 0; i < filenames.Length; i++) {
                var bmp = new Bitmap(filenames[i]);
                bmp.RotateFlip(RotateFlipType.Rotate180FlipX);
                //var glBmp = Utility.LockConvert(bmp, GL.GL_RGBA);
                var winGLBitmap = new WinGLBitmap(bmp);
                var texture = new Texture(new TexImageBitmap(winGLBitmap, GL.GL_RGBA),
                    new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_CLAMP_TO_EDGE),
                    new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_CLAMP_TO_EDGE),
                    new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_CLAMP_TO_EDGE),
                    new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR),
                    new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR));
                texture.Initialize();
                //texture.textureUnitIndex = (uint)i;
                float scale = (float)bmp.Width / (float)bmp.Height;
                //bmp.UnlockBits(glBmp.bmpData);
                //bmp.Dispose();
                winGLBitmap.Dispose();
                var node = RectangleNode.Create(texture);
                node.WorldPosition = new vec3(0, 0, i - -filenames.Length / 2.0f);
                node.Scale = new vec3(scale, 1, 1);
                rootNode.Children.Add(node);
            }

            return rootNode;
        }


        public override void reshape(GL gl, int width, int height) {
            this.scene.camera.AspectRatio = ((float)this.canvas.Width) / ((float)this.canvas.Height);

        }
    }
}
