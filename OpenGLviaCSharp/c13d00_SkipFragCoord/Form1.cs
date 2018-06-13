using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CSharpGL;

namespace c13d00_SkipFragCoord
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
            var position = new vec3(5, 3, 4) * 1f;
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspecitive, this.winGLCanvas1.Width, this.winGLCanvas1.Height);
            int width = this.winGLCanvas1.Width, height = this.winGLCanvas1.Height;
            var scene = new Scene(camera);
            scene.RootNode = GetRootNode();
            this.scene = scene;

            var list = new ActionList();
            var transformAction = new TransformAction(scene.RootNode);
            list.Add(transformAction);
            var renderAction = new RenderAction(scene);
            list.Add(renderAction);
            this.actionList = list;

            var manipulater = new FirstPerspectiveManipulater();
            manipulater.Bind(camera, this.winGLCanvas1);
        }

        private SceneNodeBase GetRootNode()
        {
            var groupNode = new GroupNode();
            {
                var node = CubeNode.Create();
                node.Scale = new vec3(1, 1, 1) * 4;
                groupNode.Children.Add(node);
            }
            {
                var node = TeapotNode.Create();
                node.RenderWireframe = false;
                groupNode.Children.Add(node);
            }

            return groupNode;
        }

        private void winGLCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            ActionList list = this.actionList;
            if (list != null)
            {
                vec4 clearColor = this.scene.ClearColor;
                GL.Instance.ClearColor(clearColor.x, clearColor.y, clearColor.z, clearColor.w);
                GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);

                int width = this.winGLCanvas1.Width, height = this.winGLCanvas1.Height;
                //    var scissor = new int[4];
                //    var viewport = new int[4];
                //    GL.Instance.GetIntegerv((uint)GetTarget.ScissorBox, scissor);
                //    GL.Instance.GetIntegerv((uint)GetTarget.Viewport, viewport);

                Viewport viewport = Viewport.GetCurrent();
                list.Act(new ActionParams(viewport));

                // Reset viewport.
                GL.Instance.Scissor(0, 0, width, height);
                GL.Instance.Viewport(0, 0, width, height);

            }
        }

        void winGLCanvas1_Resize(object sender, EventArgs e)
        {
            this.scene.Camera.AspectRatio = ((float)this.winGLCanvas1.Width) / ((float)this.winGLCanvas1.Height);
        }
    }
}