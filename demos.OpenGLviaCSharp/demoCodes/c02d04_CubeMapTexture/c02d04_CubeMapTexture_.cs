using CSharpGL;
using demos.OpenGLviaCSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c02d04_CubeMapTexture {
    internal unsafe class c02d04_CubeMapTexture_ : demoCode {
        public c02d04_CubeMapTexture_(FormInstance mainForm, WindowsGLCanvas canvas) : base(mainForm, canvas) { }
        private Scene scene;
        private ActionList actionList;

        public override void display(GL gl) {
            ActionList list = this.actionList;
            if (list != null) {
                vec4 clearColor = this.scene.clearColor;
                gl.glClearColor(clearColor.x, clearColor.y, clearColor.z, clearColor.w);
                gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);

                Viewport viewport = Viewport.GetCurrent();
                list.Act(new ActionParams(viewport));
            }

            Scene scene = this.scene;
            if (scene != null) {
                var node = scene.RootNode;
                if (node != null) {
                    node.RotationAxis = new vec3(0, 1, 0);
                    node.RotationAngle += 1.3f;
                }
            }

        }

        public override void init(GL gl) {
            var position = new vec3(5, 3, 4) * 0.5f;
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspective, this.canvas.Width, this.canvas.Height);
            var scene = new Scene(camera);
            scene.RootNode = GetTree();
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

        }

        public override void reshape(GL gl, int width, int height) {
            this.scene.camera.AspectRatio = ((float)this.canvas.Width) / ((float)this.canvas.Height);

        }
        private SceneNodeBase GetTree() {
            var children = new List<SceneNodeBase>();
            {
                var bitmap = new Bitmap(@"media/textures/cubemaps_skybox.png");
                Texture cubemapTexture = GetCubemapTexture(bitmap);
                bitmap.Dispose();
                var cubeMapNode = CubeMapNode.Create(new CubeModel(), CubeModel.strPosition, cubemapTexture);
                children.Add(cubeMapNode);
            }
            {
                var bitmap = new Bitmap(@"media/textures/cubemaps_skybox2.png");
                Texture cubemapTexture = GetCubemapTexture(bitmap);
                bitmap.Dispose();
                var cubeMapNode = CubeMapNode.Create(new CubeModel(), CubeModel.strPosition, cubemapTexture);
                cubeMapNode.Scale = new vec3(1, 1, 1) * 0.999f;
                children.Add(cubeMapNode);
            }
            //{
            //    var bitmap = new Bitmap(@"media/textures/cube_skybox.png");
            //    Texture cubemapTexture = GetCubemapTexture(bitmap);
            //    bitmap.Dispose();
            //    var cubeMapNode = CubeMapNode.Create(new CubeModel(), CubeModel.strPosition, cubemapTexture);
            //    var polygonModeSwitch = new PolygonModeSwitch(PolygonMode.Line);
            //    var lineWidthSwitch = new LineWidthSwitch(1);
            //    cubeMapNode.RenderUnit.Methods[0].SwitchList.Add(polygonModeSwitch);
            //    cubeMapNode.RenderUnit.Methods[0].SwitchList.Add(lineWidthSwitch);
            //    cubeMapNode.RenderUnit.Methods[1].SwitchList.Add(polygonModeSwitch);
            //    cubeMapNode.RenderUnit.Methods[1].SwitchList.Add(lineWidthSwitch);
            //    children.Add(cubeMapNode);
            //}
            {
                var bitmap = new Bitmap(@"media/textures/cube_skybox.png");
                Texture cubemapTexture = GetCubemapTexture(bitmap);
                bitmap.Dispose();
                var cubeMapNode = CubeMapNode.Create(new GroundModel(length: 4), CubeModel.strPosition, cubemapTexture);
                var polygonModeSwitch = new PolygonModeSwitch(PolygonMode.Line);
                var lineWidthSwitch = new LineWidthSwitch(1);
                cubeMapNode.RenderUnit.Methods[0].SwitchList.Add(polygonModeSwitch);
                cubeMapNode.RenderUnit.Methods[0].SwitchList.Add(lineWidthSwitch);
                cubeMapNode.RenderUnit.Methods[1].SwitchList.Add(polygonModeSwitch);
                cubeMapNode.RenderUnit.Methods[1].SwitchList.Add(lineWidthSwitch);
                children.Add(cubeMapNode);
            }
            var peelingNode = new PeelingNode(children.ToArray());

            return peelingNode;
        }
        private Texture GetCubemapTexture(Bitmap totalBmp) {
            int width = totalBmp.Width / 4, height = totalBmp.Height / 3;
            var top = new Bitmap(width, height);
            using (var g = Graphics.FromImage(top)) {
                g.DrawImage(totalBmp, new Rectangle(0, 0, width, height), new Rectangle(width, 0, width, height), GraphicsUnit.Pixel);
            }
            var left = new Bitmap(width, height);
            using (var g = Graphics.FromImage(left)) {
                g.DrawImage(totalBmp, new Rectangle(0, 0, width, height), new Rectangle(0, height, width, height), GraphicsUnit.Pixel);
            }
            var front = new Bitmap(width, height);
            using (var g = Graphics.FromImage(front)) {
                g.DrawImage(totalBmp, new Rectangle(0, 0, width, height), new Rectangle(width, height, width, height), GraphicsUnit.Pixel);
            }
            var right = new Bitmap(width, height);
            using (var g = Graphics.FromImage(right)) {
                g.DrawImage(totalBmp, new Rectangle(0, 0, width, height), new Rectangle(width * 2, height, width, height), GraphicsUnit.Pixel);
            }
            var back = new Bitmap(width, height);
            using (var g = Graphics.FromImage(back)) {
                g.DrawImage(totalBmp, new Rectangle(0, 0, width, height), new Rectangle(width * 3, height, width, height), GraphicsUnit.Pixel);
            }
            var bottom = new Bitmap(width, height);
            using (var g = Graphics.FromImage(bottom)) {
                g.DrawImage(totalBmp, new Rectangle(0, 0, width, height), new Rectangle(width, height * 2, width, height), GraphicsUnit.Pixel);
            }

            var flip = RotateFlipType.Rotate180FlipY;
            right.RotateFlip(flip); left.RotateFlip(flip);
            top.RotateFlip(flip); bottom.RotateFlip(RotateFlipType.Rotate180FlipX);
            back.RotateFlip(flip); front.RotateFlip(flip);
#if DEBUG
            right.Save("right.png"); left.Save("left.png");
            top.Save("top.png"); bottom.Save("bottom.png");
            back.Save("back.png"); front.Save("front.png");
#endif

            var glRight = new WinGLBitmap(right);// Utility.LockConvert(right, GL.GL_RGBA);
            var glLeft = new WinGLBitmap(left);// Utility.LockConvert(left, GL.GL_RGBA);
            var glTop = new WinGLBitmap(top);// Utility.LockConvert(top, GL.GL_RGBA);
            var glBottom = new WinGLBitmap(bottom);// Utility.LockConvert(bottom, GL.GL_RGBA);
            var glBack = new WinGLBitmap(back);// Utility.LockConvert(back, GL.GL_RGBA);
            var glFront = new WinGLBitmap(front);// Utility.LockConvert(front, GL.GL_RGBA);
            //var dataProvider = new CubemapDataProvider(glRight.glBMP, glLeft.glBMP, glTop.glBMP, glBottom.glBMP, glBack.glBMP, glFront.glBMP);
            var dataProvider = new CubemapDataProvider(glRight, glLeft, glTop, glBottom, glBack, glFront);
            TexStorageBase storage = new CubemapTexImage2D(GL.GL_RGBA, totalBmp.Width / 4, totalBmp.Height / 3, GL.GL_BGRA, GL.GL_UNSIGNED_BYTE, dataProvider);
            var texture = new Texture(storage,
                new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR),
                new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR),
                new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_CLAMP_TO_EDGE),
                new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_CLAMP_TO_EDGE),
                new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_CLAMP_TO_EDGE));
            texture.Initialize();
            //right.UnlockBits(glRight.bmpData);
            //left.UnlockBits(glLeft.bmpData);
            //top.UnlockBits(glTop.bmpData);
            //bottom.UnlockBits(glBottom.bmpData);
            //back.UnlockBits(glBack.bmpData);
            //front.UnlockBits(glFront.bmpData);
            glRight.Dispose();
            glLeft.Dispose();
            glTop.Dispose();
            glBottom.Dispose();
            glBack.Dispose();
            glFront.Dispose();

            return texture;
        }

    }
}
