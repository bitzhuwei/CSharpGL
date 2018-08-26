using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CSharpGL;
using System.IO;

namespace c12d00_StaticSlices
{
    public partial class Form1 : Form
    {

        private Scene scene;
        private ActionList actionList;

        public Form1()
        {
            InitializeComponent();

            this.Load += FormMain_Load;
            this.winGLCanvas1.OpenGLDraw += winGLCanvas1_OpenGLDraw;
            this.winGLCanvas1.Resize += winGLCanvas1_Resize;
            this.winGLCanvas1.MouseWheel += winGLCanvas1_MouseWheel;
        }

        void winGLCanvas1_MouseWheel(object sender, MouseEventArgs e)
        {
            this.scene.Camera.MouseWheel(e.Delta);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            var position = new vec3(5, 3, 4) * 0.2f;
            var center = new vec3(0, -0.1f, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspective, this.winGLCanvas1.Width, this.winGLCanvas1.Height);
            this.scene = new Scene(camera);
            this.scene.RootNode = GetRootNode();

            var list = new ActionList();
            list.Add(new TransformAction(scene));
            list.Add(new RenderAction(scene));
            this.actionList = list;

            //var manipulater = new FirstPerspectiveManipulater();
            //manipulater.Bind(camera, this.winGLCanvas1);

            var manipulater = new ArcBallManipulater(GLMouseButtons.Left);
            manipulater.Bind(camera, this.winGLCanvas1);
            {
                float angle = this.scene.RootNode.RotationAngle;
                vec3 axis = this.scene.RootNode.RotationAxis;
                manipulater.SetRotationMatrix(glm.rotate(angle, axis));
            }
            manipulater.Rotated += manipulater_Rotated;

        }

        void manipulater_Rotated(object sender, ArcBallManipulater.Rotation e)
        {
            {
                SceneNodeBase node = this.scene.RootNode;
                if (node != null)
                {
                    node.RotationAngle = e.angleInDegree;
                    node.RotationAxis = e.axis;
                }
            }
        }

        private SceneNodeBase GetRootNode()
        {
            var group = new GroupNode();
            group.RotationAxis = new vec3(-0.8343f, -0.0144f, -0.5512f);
            group.RotationAngle = 179.260315f;
            {
                Texture texTransferFunc = InitTransferFuncTexture("tff.png");
                int width = 128, height = 128, depth = 128;
                byte[] volumeData = VolumeDataGenerator.GetData(width, height, depth);
                Texture texVolume = InitVolumeTexture(volumeData, width, height, depth);

                int sliceCount = 512;
                StaticSlicesNode node = StaticSlicesNode.Create(sliceCount, texTransferFunc, texVolume);
                node.Scale = new vec3(1, 1, 225.0f / 256.0f);
                (new FormProperyGrid(node)).Show();
                group.Children.Add(node);
            }
            {
                var node = AxisNode.Create();
                node.Scale = new vec3(1, 1, 1) * 3;
                group.Children.Add(node);
            }
            return group;
        }

        private byte[] GetVolumeData(string filename)
        {
            byte[] data;
            using (var fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
            using (var br = new BinaryReader(fs))
            {
                int unReadCount = (int)fs.Length;
                data = new byte[unReadCount];
                br.Read(data, 0, unReadCount);
            }

            return data;
        }

        private Texture InitVolumeTexture(byte[] data, int width, int height, int depth)
        {
            var storage = new TexImage3D(TexImage3D.Target.Texture3D, GL.GL_RED, width, height, depth, GL.GL_RED, GL.GL_UNSIGNED_BYTE, new ArrayDataProvider<byte>(data));
            var texture = new Texture(storage, new MipmapBuilder(),
                new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_CLAMP),
                new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_CLAMP),
                new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_CLAMP),
                new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR_MIPMAP_LINEAR),
                new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR),
                new TexParameteri(TexParameter.PropertyName.TextrueBaseLevel, 0),
                new TexParameteri(TexParameter.PropertyName.TextureMaxLevel, 4));
            texture.Initialize();
            texture.TextureUnitIndex = 2;

            return texture;
        }

        private Texture InitTransferFuncTexture(string filename)
        {
            var bitmap = new System.Drawing.Bitmap(filename);
            const int width = 256;
            var storage = new TexImage1D(GL.GL_RGBA8, width, GL.GL_RGBA, GL.GL_UNSIGNED_BYTE, new ImageDataProvider(bitmap));
            var texture = new Texture(storage,
                new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_REPEAT),
                new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_REPEAT),
                new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_REPEAT),
                new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_NEAREST),
                new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_NEAREST));
            texture.Initialize();
            texture.TextureUnitIndex = 0;
            bitmap.Dispose();

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

                list.Act(new ActionParams(Viewport.GetCurrent()));
            }
        }

        void winGLCanvas1_Resize(object sender, EventArgs e)
        {
            this.scene.Camera.AspectRatio = ((float)this.winGLCanvas1.Width) / ((float)this.winGLCanvas1.Height);
        }

    }
}
