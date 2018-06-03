using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CSharpGL;

namespace c11d00_Arcball
{
    public partial class FormArcball : Form
    {
        private Scene scene;
        private ActionList actionList;

        public FormArcball()
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
            var position = new vec3(3, 5, 4);
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspecitive, this.winGLCanvas1.Width, this.winGLCanvas1.Height);
            this.scene = new Scene(camera);
            this.scene.ClearColor = new vec4(0, 0, 0, 1);
            var light = new DirectionalLight(new vec3(4, 5, 3));
            light.Specular = new vec3(0);
            this.scene.Lights.Add(light);
            this.scene.RootNode = GetRootNode();

            var list = new ActionList();
            list.Add(new TransformAction(scene.RootNode));
            list.Add(new RenderAction(scene));
            list.Add(new BlinnPhongAction(scene));
            this.actionList = list;

            //var manipulater = new FirstPerspectiveManipulater();
            //manipulater.Bind(camera, this.winGLCanvas1);

            var manipulater = new ArcBallManipulater(GLMouseButtons.Left);
            manipulater.Bind(camera, this.winGLCanvas1);
            manipulater.Rotated += manipulater_Rotated;
        }

        void manipulater_Rotated(object sender, ArcBallManipulater.Rotation e)
        {
            SceneNodeBase node = this.scene.RootNode;
            node.RotationAngle = e.angleInDegree;
            node.RotationAxis = e.axis;
        }

        private SceneNodeBase GetRootNode()
        {
            var group = new GroupNode();
            {
                var model = new HalfSphere(3, 40, 40);
                var node = NoShadowNode.Create(model, HalfSphere.strPosition, HalfSphere.strNormal, model.Size);
                var list = node.RenderUnit.Methods[0].SwitchList;
                var list1 = node.RenderUnit.Methods[1].SwitchList;
                var polygonModeSwitch = new PolygonModeSwitch(PolygonMode.Line);
                var offsetSwitch = new PolygonOffsetFillSwitch();
                list.Add(polygonModeSwitch);
                list1.Add(polygonModeSwitch);
                var cmd = node.RenderUnit.Methods[0].VertexArrayObjects[0].DrawCommand as DrawElementsCmd;
                cmd.VertexCount = cmd.VertexCount / 2; group.Children.Add(node);
            }
            //{
            //    var model = new RectangleModel();
            //    Texture texture = GetTexture();
            //    var node = TexturedNode.Create(model, RectangleModel.strPosition, RectangleModel.strNormal, RectangleModel.strUV, texture, model.ModelSize);
            //    node.Scale = new vec3(1, 1, 1) * 6;
            //    node.RotationAxis = new vec3(-1, 0, 0);
            //    node.RotationAngle = 90;

            //    group.Children.Add(node);
            //}
            {
                var node = RectangleNode.Create();
                node.TextureSource = new BitmapTextureSource("Canvas.png");
                node.Scale = new vec3(1, 1, 1) * 6;
                node.RotationAxis = new vec3(-1, 0, 0);
                node.RotationAngle = 90;
                group.Children.Add(node);
            }
            return group;
        }

        private Texture GetTexture()
        {
            string folder = System.Windows.Forms.Application.StartupPath;
            var bmp = new Bitmap(System.IO.Path.Combine(folder, @"Canvas.png"));
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

                list.Act(new ActionParams(Viewport.GetCurrent()));
            }
        }

        void winGLCanvas1_Resize(object sender, EventArgs e)
        {
            this.scene.Camera.AspectRatio = ((float)this.winGLCanvas1.Width) / ((float)this.winGLCanvas1.Height);
        }

    }
}
