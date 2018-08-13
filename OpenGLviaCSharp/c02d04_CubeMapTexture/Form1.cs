using CSharpGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace c02d04_CubeMapTexture
{
    public partial class Form1 : Form
    {
        private Scene scene;
        private ActionList actionList;

        public Form1()
        {
            InitializeComponent();

            // init resources.
            this.Load += FormMain_Load;
            // render event.
            this.winGLCanvas1.OpenGLDraw += winGLCanvas1_OpenGLDraw;
            // resize event.
            this.winGLCanvas1.Resize += winGLCanvas1_Resize;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            var position = new vec3(5, 3, 4) * 0.5f;
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspecitive, this.winGLCanvas1.Width, this.winGLCanvas1.Height);
            var scene = new Scene(camera);
            scene.RootNode = GetTree();
            this.scene = scene;

            var list = new ActionList();
            var transformAction = new TransformAction(scene);
            list.Add(transformAction);
            var renderAction = new RenderAction(scene);
            list.Add(renderAction);
            this.actionList = list;

            //// uncomment these lines to enable manipualter of camera!
            //var manipulater = new FirstPerspectiveManipulater();
            //manipulater.BindingMouseButtons = System.Windows.Forms.MouseButtons.Right;
            //manipulater.Bind(camera, this.winGLCanvas1);
        }

        private SceneNodeBase GetTree()
        {
            var children = new List<SceneNodeBase>();
            {
                var bitmap = new Bitmap(@"cubemaps_skybox.png");
                Texture cubemapTexture = GetCubemapTexture(bitmap);
                bitmap.Dispose();
                var cubeMapNode = CubeMapNode.Create(new CubeModel(), CubeModel.strPosition, cubemapTexture);
                children.Add(cubeMapNode);
            }
            //{
            //    var bitmap = new Bitmap(@"cubemaps_skybox2.png");
            //    Texture cubemapTexture = GetCubemapTexture(bitmap);
            //    bitmap.Dispose();
            //    var cubeMapNode = CubeMapNode.Create(new CubeModel(), CubeModel.strPosition, cubemapTexture);
            //    cubeMapNode.Scale = new vec3(1, 1, 1) * 0.999f;
            //    children.Add(cubeMapNode);
            //}
            {
                var bitmap = new Bitmap(@"cube_skybox.png");
                Texture cubemapTexture = GetCubemapTexture(bitmap);
                bitmap.Dispose();
                var cubeMapNode = CubeMapNode.Create(new CubeModel(), CubeModel.strPosition, cubemapTexture);
                var polygonModeSwitch = new PolygonModeSwitch(PolygonMode.Line);
                var lineWidthSwitch = new LineWidthSwitch(1);
                cubeMapNode.RenderUnit.Methods[0].SwitchList.Add(polygonModeSwitch);
                cubeMapNode.RenderUnit.Methods[0].SwitchList.Add(lineWidthSwitch);
                cubeMapNode.RenderUnit.Methods[1].SwitchList.Add(polygonModeSwitch);
                cubeMapNode.RenderUnit.Methods[1].SwitchList.Add(lineWidthSwitch);
                children.Add(cubeMapNode);
            }
            {
                var bitmap = new Bitmap(@"cube_skybox.png");
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

        private Texture GetCubemapTexture(Bitmap totalBmp)
        {
            var dataProvider = GetCubemapDataProvider(totalBmp);
            TexStorageBase storage = new CubemapTexImage2D(GL.GL_RGBA, totalBmp.Width / 4, totalBmp.Height / 3, GL.GL_BGRA, GL.GL_UNSIGNED_BYTE, dataProvider);
            var texture = new Texture(storage,
                new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR),
                new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR),
                new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_CLAMP_TO_EDGE),
                new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_CLAMP_TO_EDGE),
                new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_CLAMP_TO_EDGE));
            texture.Initialize();

            return texture;
        }

        private CubemapDataProvider GetCubemapDataProvider(Bitmap totalBmp)
        {
            int width = totalBmp.Width / 4, height = totalBmp.Height / 3;
            var top = new Bitmap(width, height);
            using (var g = Graphics.FromImage(top))
            {
                g.DrawImage(totalBmp, new Rectangle(0, 0, width, height), new Rectangle(width, 0, width, height), GraphicsUnit.Pixel);
            }
            var left = new Bitmap(width, height);
            using (var g = Graphics.FromImage(left))
            {
                g.DrawImage(totalBmp, new Rectangle(0, 0, width, height), new Rectangle(0, height, width, height), GraphicsUnit.Pixel);
            }
            var front = new Bitmap(width, height);
            using (var g = Graphics.FromImage(front))
            {
                g.DrawImage(totalBmp, new Rectangle(0, 0, width, height), new Rectangle(width, height, width, height), GraphicsUnit.Pixel);
            }
            var right = new Bitmap(width, height);
            using (var g = Graphics.FromImage(right))
            {
                g.DrawImage(totalBmp, new Rectangle(0, 0, width, height), new Rectangle(width * 2, height, width, height), GraphicsUnit.Pixel);
            }
            var back = new Bitmap(width, height);
            using (var g = Graphics.FromImage(back))
            {
                g.DrawImage(totalBmp, new Rectangle(0, 0, width, height), new Rectangle(width * 3, height, width, height), GraphicsUnit.Pixel);
            }
            var bottom = new Bitmap(width, height);
            using (var g = Graphics.FromImage(bottom))
            {
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
            var result = new CubemapDataProvider(right, left, top, bottom, back, front);
            return result;
        }

        private Texture GetTexture()
        {
            string folder = System.Windows.Forms.Application.StartupPath;
            var bmp = new Bitmap(System.IO.Path.Combine(folder, @"Crate.bmp"));
            TexStorageBase storage = new TexImageBitmap(bmp);
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

        private void winGLCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            ActionList list = this.actionList;
            if (list != null)
            {
                vec4 clearColor = this.scene.ClearColor;
                GL.Instance.ClearColor(clearColor.x, clearColor.y, clearColor.z, clearColor.w);
                GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);

                Viewport viewport = Viewport.GetCurrent();
                list.Act(new ActionParams(viewport));
            }
        }

        void winGLCanvas1_Resize(object sender, EventArgs e)
        {
            this.scene.Camera.AspectRatio = ((float)this.winGLCanvas1.Width) / ((float)this.winGLCanvas1.Height);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Scene scene = this.scene;
            if (scene != null)
            {
                var node = scene.RootNode;
                if (node != null)
                {
                    node.RotationAxis = new vec3(0, 1, 0);
                    node.RotationAngle += 1.3f;
                }
            }
        }
    }
}
