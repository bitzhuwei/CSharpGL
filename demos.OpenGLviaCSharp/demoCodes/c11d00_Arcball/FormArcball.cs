using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CSharpGL;

namespace c11d00_Arcball {
    public partial class FormArcball : Form {
        private Scene scene;
        private ActionList actionList;
        private ICamera modelCamera;
        private ArcBallManipulater modelManipulater;
        private IGLCanvas modelCanvas;
        private RenderToTextureNode rtt;
        private GroupNode groupNode;
        private LinesNode linesNode;
        private FanNode fanNode;

        public FormArcball(ICamera camera, ArcBallManipulater manipulater, IGLCanvas canvas) {
            InitializeComponent();

            this.modelCamera = camera;
            this.modelManipulater = manipulater;
            this.modelCanvas = canvas;

            this.Load += FormMain_Load;
            this.canvas.OpenGLDraw += winGLCanvas1_OpenGLDraw;
            this.canvas.Resize += winGLCanvas1_Resize;
            this.canvas.MouseWheel += winGLCanvas1_MouseWheel;
        }

        void winGLCanvas1_MouseWheel(object sender, MouseEventArgs e) {
            this.scene.camera.MouseWheel(e.Delta);
        }

        private void FormMain_Load(object? sender, EventArgs e) {
            var position = new vec3(0, 5, 4);
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspective, this.canvas.Width, this.canvas.Height);
            this.scene = new Scene(camera);
            this.scene.clearColor = new vec4(0, 0, 0, 1);
            var light = new DirectionalLight(new vec3(4, 5, 3));
            light.Specular = new vec3(0);
            this.scene.lights.Add(light);
            this.scene.RootNode = GetRootNode(this.modelCamera);

            var list = new ActionList();
            list.Add(new TransformAction(scene));
            list.Add(new RenderAction(scene));
            list.Add(new BlinnPhongAction(scene));
            this.actionList = list;

            //var manipulater = new FirstPerspectiveManipulater();
            //manipulater.Bind(camera, this.canvas);

            // rotate this scene.
            {
                var manipulater = new ArcBallManipulater(GLMouseButtons.Left);
                manipulater.Bind(camera, this.canvas);
                manipulater.Rotated += thisManipulater_Rotated;
            }
            // model manipulater also affects teapot in this scene's rtt node.
            {
                var manipulater = this.modelManipulater;
                manipulater.Rotated += manipulater_Rotated;
                manipulater.MouseDown += manipulater_MouseDown;
                manipulater.Rotated += manipulater_MouseMove;
                manipulater.MouseUp += manipulater_MouseUp;

                this.modelCanvas.GLMouseMove += modelCanvas_MouseMove;
            }
        }

        void modelCanvas_MouseMove(object sender, GLMouseEventArgs e) {
            if (!this.linesNode.IsMouseDown) {
                this.linesNode.MouseMove(e.X, e.Y, this.modelCanvas.Width, this.modelCanvas.Height);
            }
        }


        void manipulater_MouseUp(object sender, GLMouseEventArgs e) {
            this.linesNode.MouseUp(e.X, e.Y, this.modelCanvas.Width, this.modelCanvas.Height);
            this.fanNode.MouseUp(e.X, e.Y, this.modelCanvas.Width, this.modelCanvas.Height);
        }

        void manipulater_MouseMove(object sender, ArcBallManipulater.Rotation e) {
            this.linesNode.MouseMove(e.X, e.Y, this.modelCanvas.Width, this.modelCanvas.Height);
            this.fanNode.MouseMove(e.X, e.Y, this.modelCanvas.Width, this.modelCanvas.Height);
        }

        void manipulater_MouseDown(object sender, GLMouseEventArgs e) {
            this.linesNode.MouseDown(e.X, e.Y, this.modelCanvas.Width, this.modelCanvas.Height);
            this.fanNode.MouseDown(e.X, e.Y, this.modelCanvas.Width, this.modelCanvas.Height);
        }

        void manipulater_Rotated(object sender, ArcBallManipulater.Rotation e) {
            {
                SceneNodeBase node = this.rtt;
                if (node != null) {
                    node.RotationAngle = e.angleInDegree;
                    node.RotationAxis = e.axis;
                }
            }
        }

        void thisManipulater_Rotated(object sender, ArcBallManipulater.Rotation e) {
            {
                SceneNodeBase node = this.groupNode;
                if (node != null) {
                    node.RotationAngle = e.angleInDegree;
                    node.RotationAxis = e.axis;
                }
            }
        }

        private SceneNodeBase GetRootNode(ICamera modelCamera) {
            var root = new GroupNode();
            // render 'scene' to franebuffer.
            {
                int width = this.canvas.Width, height = this.canvas.Height;
                var rtt = new RenderToTextureNode(width, height, modelCamera, new ColoredFramebufferProvider());
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
                    cmd.vertexCount = cmd.vertexCount / 2; // render only half a sphere.
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
                // form border.
                {
                    var node = RectangleNode.Create();
                    node.TextureSource = new FormBorderTextureSource();
                    node.Scale = new vec3(6.27f, 1.0f, 6.56f);
                    node.RotationAxis = new vec3(1, 0, 0);
                    node.RotationAngle = 90;
                    node.WorldPosition = new vec3(0.0f, -0.1f, -0.21f);
                    //(new FormProperyGrid(node)).Show();
                    group.Children.Add(node);
                }

                root.Children.Add(group);
                this.groupNode = group;
            }
            return root;
        }

        private unsafe void winGLCanvas1_OpenGLDraw(object sender, PaintEventArgs e) {
            ActionList list = this.actionList;
            if (list != null) {
                var gl = GL.Current; Debug.Assert(gl != null);
                vec4 clearColor = this.scene.clearColor;
                gl.glClearColor(clearColor.x, clearColor.y, clearColor.z, clearColor.w);
                gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);

                var p = new ActionParams(Viewport.GetCurrent());
                list.Act(p);
            }
        }

        void winGLCanvas1_Resize(object sender, EventArgs e) {
            this.scene.camera.AspectRatio = ((float)this.canvas.Width) / ((float)this.canvas.Height);
        }


    }
}
