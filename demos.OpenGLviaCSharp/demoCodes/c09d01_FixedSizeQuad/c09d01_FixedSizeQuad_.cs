using CSharpGL;
using demos.OpenGLviaCSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c09d01_FixedSizeQuad {
    internal unsafe class c09d01_FixedSizeQuad_ : demoCode {
        public c09d01_FixedSizeQuad_(FormInstance mainForm, WindowsGLCanvas canvas) : base(mainForm, canvas) { }
        private Scene scene;
        private ActionList actionList;
        private Picking pickingAction;

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
            var position = new vec3(1, 0.6f, 0.7f) * 4;
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspective, this.canvas.Width, this.canvas.Height);
            this.scene = new Scene(camera);
            this.scene.RootNode = GetTree();

            var list = new ActionList();
            list.Add(new TransformAction(scene));
            list.Add(new RenderAction(scene));
            this.actionList = list;

            this.pickingAction = new Picking(scene);

            var manipulater = new FirstPerspectiveManipulater();
            manipulater.Bind(camera, this.canvas);

        }

        private Texture GetTexture() {
            string folder = System.Windows.Forms.Application.StartupPath;
            var bmp = new Bitmap("media/textures/base.png");
            var winGLBitmap = new WinGLBitmap(bmp);
            TexStorageBase storage = new TexImageBitmap(winGLBitmap);
            var texture = new Texture(storage,
                new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_CLAMP_TO_EDGE),
                new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_CLAMP_TO_EDGE),
                new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_CLAMP_TO_EDGE),
                new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR),
                new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR));
            texture.Initialize();
            bmp.Dispose();

            return texture;
        }

        //private SceneNodeBase GetRootNode()
        //{
        //    var group = new GroupNode();
        //    {
        //        Texture texture = this.GetTexture();
        //        var node = FixedSizeQuadNode.Create(200, 100, texture);
        //        group.Children.Add(node);

        //        this.triangleNode = node;
        //    }
        //    return group;
        //}

        private SceneNodeBase GetTree() {
            const float length = 6;
            var group = new GroupNode();
            {
                var floor = CubeNode.Create();
                floor.Scale = new vec3(length, 0.1f, length);
                floor.Color = Color.Brown.ToVec4();
                group.Children.Add(floor);
            }

            Texture texture = this.GetTexture();
            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 3; j++) {
                    float x = -length / 2 + length / 2 * i;
                    float y = 0.25f;
                    float z = -length / 2 + length / 2 * j;
                    var stick = CubeNode.Create();
                    stick.Scale = new vec3(0.1f, y * 2, 0.1f);
                    stick.WorldPosition = new vec3(x, y, z);
                    stick.Color = Color.Green.ToVec4();
                    group.Children.Add(stick);
                    {
                        var node = FixedSizeQuadNode.Create(200, 70, texture);
                        node.WorldPosition = new vec3(0, y * 4, 0);
                        stick.Children.Add(node);
                    }
                }
            }

            return group;
        }

        public override void reshape(GL gl, int width, int height) {
            this.scene.camera.AspectRatio = ((float)this.canvas.Width) / ((float)this.canvas.Height);

        }
    }
}
