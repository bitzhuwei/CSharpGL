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
        private ICamera modelCamera;
        private ArcBallManipulater modelManipulater;
        private IGLCanvas modelCanvas;
        private RenderToTexttureNode rtt;
        private GroupNode groupNode;
        private LinesNode linesNode;
        private FanNode fanNode;

        public FormArcball(ICamera camera, ArcBallManipulater manipulater, IGLCanvas canvas)
        {
            InitializeComponent();

            this.modelCamera = camera;
            this.modelManipulater = manipulater;
            this.modelCanvas = canvas;

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
            var position = new vec3(0, 5, 4);
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspecitive, this.winGLCanvas1.Width, this.winGLCanvas1.Height);
            this.scene = new Scene(camera);
            this.scene.ClearColor = new vec4(0, 0, 0, 1);
            var light = new DirectionalLight(new vec3(4, 5, 3));
            light.Specular = new vec3(0);
            this.scene.Lights.Add(light);
            this.scene.RootNode = GetRootNode(this.modelCamera);

            var list = new ActionList();
            list.Add(new TransformAction(scene.RootNode));
            list.Add(new RenderAction(scene));
            list.Add(new BlinnPhongAction(scene));
            this.actionList = list;

            //var manipulater = new FirstPerspectiveManipulater();
            //manipulater.Bind(camera, this.winGLCanvas1);

            // rotate this scene.
            {
                var manipulater = new ArcBallManipulater(GLMouseButtons.Left);
                manipulater.Bind(camera, this.winGLCanvas1);
                manipulater.Rotated += thisManipulater_Rotated;
            }
            // model manipulater also affects teapot in this scene's rtt node.
            {
                var manipulater = this.modelManipulater;
                manipulater.Rotated += manipulater_Rotated;
                manipulater.MouseDown += manipulater_MouseDown;
                manipulater.Rotated += manipulater_MouseMove;
                manipulater.MouseUp += manipulater_MouseUp;

                this.modelCanvas.MouseMove += modelCanvas_MouseMove;
            }
        }

        void modelCanvas_MouseMove(object sender, GLMouseEventArgs e)
        {
            if (!this.linesNode.IsMouseDown)
            {
                this.linesNode.MouseMove(e.X, e.Y, this.modelCanvas.Width, this.modelCanvas.Height);
            }
        }


        void manipulater_MouseUp(object sender, GLMouseEventArgs e)
        {
            this.linesNode.MouseUp(e.X, e.Y, this.modelCanvas.Width, this.modelCanvas.Height);
            this.fanNode.MouseUp(e.X, e.Y, this.modelCanvas.Width, this.modelCanvas.Height);
        }

        void manipulater_MouseMove(object sender, ArcBallManipulater.Rotation e)
        {
            this.linesNode.MouseMove(e.X, e.Y, this.modelCanvas.Width, this.modelCanvas.Height);
            this.fanNode.MouseMove(e.X, e.Y, this.modelCanvas.Width, this.modelCanvas.Height);
        }

        void manipulater_MouseDown(object sender, GLMouseEventArgs e)
        {
            this.linesNode.MouseDown(e.X, e.Y, this.modelCanvas.Width, this.modelCanvas.Height);
            this.fanNode.MouseDown(e.X, e.Y, this.modelCanvas.Width, this.modelCanvas.Height);
        }

        void manipulater_Rotated(object sender, ArcBallManipulater.Rotation e)
        {
            {
                SceneNodeBase node = this.rtt;
                if (node != null)
                {
                    node.RotationAngle = e.angleInDegree;
                    node.RotationAxis = e.axis;
                }
            }
        }

        void thisManipulater_Rotated(object sender, ArcBallManipulater.Rotation e)
        {
            {
                SceneNodeBase node = this.groupNode;
                if (node != null)
                {
                    node.RotationAngle = e.angleInDegree;
                    node.RotationAxis = e.axis;
                }
            }
        }

        private SceneNodeBase GetRootNode(ICamera modelCamera)
        {
            var root = new GroupNode();
            // render 'scene' to franebuffer.
            {
                int width = this.winGLCanvas1.Width, height = this.winGLCanvas1.Height;
                var rtt = new RenderToTexttureNode(width, height, modelCamera, new ColoredFramebufferProvider());
                rtt.BackgroundColor = Color.SkyBlue;
                {
                    var teapot = TeapotNode.Create();
                    teapot.RenderWireframe = false;
                    rtt.Children.Add(teapot);// rendered to framebuffer, then to texture.
                }
                root.Children.Add(rtt);
                this.rtt = rtt;
            }
            {
                var group = new GroupNode();
                // display 'scene' in rectangle.
                {
                    var node = RectangleNode.Create();
                    node.TextureSource = this.rtt;
                    node.Scale = new vec3(1, 1, 1) * 6;
                    node.RotationAxis = new vec3(-1, 0, 0);
                    node.RotationAngle = 90;
                    group.Children.Add(node);
                }
                const float radius = 3;
                // arcball.
                {
                    var model = new HalfSphere(radius, 40, 40);
                    var node = NoShadowNode.Create(model, HalfSphere.strPosition, HalfSphere.strNormal, model.Size);
                    var list = node.RenderUnit.Methods[0].SwitchList;
                    var list1 = node.RenderUnit.Methods[1].SwitchList;
                    var polygonModeSwitch = new PolygonModeSwitch(PolygonMode.Line);
                    var offsetSwitch = new PolygonOffsetFillSwitch();
                    list.Add(polygonModeSwitch);
                    list1.Add(polygonModeSwitch);
                    var cmd = node.RenderUnit.Methods[0].VertexArrayObjects[0].DrawCommand as DrawElementsCmd;
                    cmd.VertexCount = cmd.VertexCount / 2; // render only half a sphere.
                    group.Children.Add(node);
                }
                // lines.
                {
                    var node = LinesNode.Create(radius);
                    group.Children.Add(node);
                    this.linesNode = node;
                }
                // fan
                {
                    var node = FanNode.Create(radius);
                    group.Children.Add(node);
                    this.fanNode = node;
                }
                root.Children.Add(group);
                this.groupNode = group;
            }
            return root;
        }

        //private Texture GetTexture()
        //{
        //    string folder = System.Windows.Forms.Application.StartupPath;
        //    var bmp = new Bitmap(System.IO.Path.Combine(folder, @"Canvas.png"));
        //    TexStorageBase storage = new TexImageBitmap(bmp);
        //    var texture = new Texture(storage,
        //        new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_CLAMP_TO_EDGE),
        //        new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_CLAMP_TO_EDGE),
        //        new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_CLAMP_TO_EDGE),
        //        new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR),
        //        new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR));
        //    texture.Initialize();
        //    bmp.Dispose();

        //    return texture;
        //}

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
