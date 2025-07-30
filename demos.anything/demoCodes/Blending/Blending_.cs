using CSharpGL;
using demos.anything;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blending {
    internal unsafe class Blending_ : demoCode {
        public Blending_(FormInstance mainForm, WindowsGLCanvas canvas) : base(mainForm, canvas) { }
        private Scene scene;
        private ActionList actionList;

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

            var position = new vec3(5, 3, 4);
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

            //Match(this.trvScene, scene.RootNode);
            //this.trvScene.ExpandAll();
            (new FormNodePropertyGrid(scene.RootNode)).Show();

        }
        private SceneNodeBase GetTree() {
            var group = new GroupNode();
            {
                //string folder = System.Windows.Forms.Application.StartupPath;
                //var bmp = new Bitmap(System.IO.Path.Combine(folder, @"Crate.bmp"));
                var bmp = new Bitmap("media/textures/Crate.bmp");
                var winGLBitmap = new WinGLBitmap(bmp, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                TexStorageBase storage = new TexImageBitmap(winGLBitmap);
                var texture = new Texture(storage);
                texture.builtInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_CLAMP_TO_EDGE));
                texture.builtInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_CLAMP_TO_EDGE));
                texture.builtInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_CLAMP_TO_EDGE));
                texture.builtInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR));
                texture.builtInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR));
                texture.Initialize();
                bmp.Dispose();
                var solidCube = TexturedCubeNode.Create(texture);

                group.Children.Add(solidCube);
            }
            {
                var blendingGroup = new BlendingGroupNode(BlendSrcFactor.SrcAlpha, BlendDestFactor.OneMinusSrcAlpha);

                group.Children.Add(blendingGroup);
                var list = new List<BlendingConfig>();
                list.Add(new BlendingConfig(Color.Red, new vec3(1, 0, 1), 0.5f));
                list.Add(new BlendingConfig(Color.Green, new vec3(0.6f, 0, 0.1f), 0.5f));
                list.Add(new BlendingConfig(Color.Blue, new vec3(-0.1f, 0, -0.2f), 0.5f));
                list.Add(new BlendingConfig(Color.Purple, new vec3(0.4f, 0, -0.7f), 0.5f));
                list.Add(new BlendingConfig(Color.Orange, new vec3(0.8f, 0, 0.1f), 0.5f));
                list.Add(new BlendingConfig(Color.Yellow, new vec3(0.8f, 0, 0.1f), 0.5f));
                for (int i = 0; i < list.Count; i++) {
                    const float distance = 2.0f;
                    list[i].position = new vec3(
                        distance * (float)Math.Cos((double)i / (double)list.Count * Math.PI * 2),
                        0,
                        distance * (float)Math.Sin((double)i / (double)list.Count * Math.PI * 2)
                        );
                    list[i].alpha = 0.3f;
                }
                foreach (var item in list) {
                    var bmp = new Bitmap(1, 1, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                    using (var g = Graphics.FromImage(bmp)) { g.Clear(item.color); }
                    var winGLBitmap = new WinGLBitmap(bmp);
                    var texture = new Texture(new TexImageBitmap(winGLBitmap));
                    texture.builtInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_CLAMP_TO_EDGE));
                    texture.builtInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_CLAMP_TO_EDGE));
                    texture.builtInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_CLAMP_TO_EDGE));
                    texture.builtInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR));
                    texture.builtInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR));

                    texture.Initialize();
                    bmp.Dispose();
                    var transparentCube = TexturedCubeNode.Create(texture);
                    transparentCube.WorldPosition = item.position;
                    transparentCube.Alpha = item.alpha;

                    blendingGroup.Children.Add(transparentCube);
                }
            }

            return group;
        }


        public override void reshape(GL gl, int width, int height) {
            this.scene.camera.AspectRatio = ((float)this.canvas.Width) / ((float)this.canvas.Height);

        }
    }

}
