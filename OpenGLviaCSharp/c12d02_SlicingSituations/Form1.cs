using CSharpGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace c12d02_SlicingSituations
{
    public partial class Form1 : Form
    {

        private Scene scene;
        private ActionList actionList;
        private SceneNodeBase rootNode;
        private SliceNode sliceNode;

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
            var position = new vec3(5, 3, 4) * 0.6f;
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Ortho, this.winGLCanvas1.Width, this.winGLCanvas1.Height);
            var scene = new Scene(camera);
            var rootNode = GetRootNode();
            scene.RootNode = rootNode;
            this.scene = scene;
            this.rootNode = rootNode;

            var list = new ActionList();
            var transformAction = new TransformAction(scene.RootNode);
            list.Add(transformAction);
            var renderAction = new RenderAction(scene);
            list.Add(renderAction);
            this.actionList = list;

            // Enable manipualter of camera!
            var manipulater = new FirstPerspectiveManipulater();
            manipulater.StepLength *= 0.1f;
            manipulater.BindingMouseButtons = GLMouseButtons.Right;
            manipulater.Bind(camera, this.winGLCanvas1);

            {
                this.trackX.Value = (int)(precision * 2.5f);
                this.trackY.Value = (int)(precision * 2.5f);
                this.trackZ.Value = (int)(precision * 2.5f);
                float x = (float)this.trackX.Value / precision;
                float y = (float)this.trackY.Value / precision;
                float z = (float)this.trackZ.Value / precision;
                this.intersectionNode.SetSlicePlane(x, y, z);
                this.sliceNode.SetX(x);
                this.sliceNode.SetY(x);
                this.sliceNode.SetZ(x);
            }
        }

        private SceneNodeBase GetRootNode()
        {
            var rootNode = new GroupNode();
            {
                var node = CubeNode.Create();
                node.WorldPosition = new vec3(1, 1, 1) * 0.5f;
                node.Scale = new vec3(1, 1, 1) * 0.5f;
                rootNode.Children.Add(node);
            }
            {
                var node = SliceNode.Create();
                //node.Scale = new vec3(1, 1, 1) * 5;
                //rootNode.Children.Add(node);
                this.sliceNode = node;
            }
            {
                var node = IntersectionNode.Create();
                //node.Scale = new vec3(1, 1, 1) * 5;
                rootNode.Children.Add(node);
                this.intersectionNode = node;
            }
            //{
            //    var node = GroundNode.Create();
            //    node.Scale = new vec3(1, 1, 1) * 5;
            //    node.Color = Color.Yellow.ToVec4();
            //    rootNode.Children.Add(node);
            //}

            return rootNode;
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

        const float precision = 100.0f / 3.0f;
        private IntersectionNode intersectionNode;
        private void trackX_Scroll(object sender, EventArgs e)
        {
            float x = (float)this.trackX.Value / precision;
            float y = (float)this.trackY.Value / precision;
            float z = (float)this.trackZ.Value / precision;
            this.intersectionNode.SetSlicePlane(x, y, z);
            this.sliceNode.SetX(x);
        }

        private void trackY_Scroll(object sender, EventArgs e)
        {
            float x = (float)this.trackX.Value / precision;
            float y = (float)this.trackY.Value / precision;
            float z = (float)this.trackZ.Value / precision;
            this.intersectionNode.SetSlicePlane(x, y, z);
            this.sliceNode.SetY(y);
        }

        private void trackZ_Scroll(object sender, EventArgs e)
        {
            float x = (float)this.trackX.Value / precision;
            float y = (float)this.trackY.Value / precision;
            float z = (float)this.trackZ.Value / precision;
            this.intersectionNode.SetSlicePlane(x, y, z);
            this.sliceNode.SetZ(z);
        }
    }
}
