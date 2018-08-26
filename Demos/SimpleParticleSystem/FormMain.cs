using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CSharpGL;

namespace SimpleParticleSystem
{
    public partial class FormMain : Form
    {
        private Scene scene;
        private ActionList actionList;
        private ParticleNode particleNode;

        public FormMain()
        {
            InitializeComponent();

            this.Load += FormMain_Load;
            this.winGLCanvas1.OpenGLDraw += winGLCanvas1_OpenGLDraw;
            this.winGLCanvas1.Resize += winGLCanvas1_Resize;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            var rootElement = GetTree();

            var position = new vec3(5, 3, 4) * 0.2f;
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspective, this.winGLCanvas1.Width, this.winGLCanvas1.Height);
            this.scene = new Scene(camera)

            {
                RootNode = rootElement,
                ClearColor = Color.SkyBlue.ToVec4(),
            };

            var list = new ActionList();
            var transformAction = new TransformAction(scene);
            list.Add(transformAction);
            var renderAction = new RenderAction(scene);
            list.Add(renderAction);
            this.actionList = list;

            var manipulater = new FirstPerspectiveManipulater();
            manipulater.StepLength = 0.1f;
            manipulater.Bind(camera, this.winGLCanvas1);
        }

        private SceneNodeBase GetTree()
        {
            var node = ParticleNode.Create();
            var ground = GroundNode.Create();
            var group = new GroupNode(ground, node);

            this.particleNode = node;

            return group;
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            //IWorldSpace node = this.scene.RootElement;
            //if (node != null)
            //{
            //    node.RotationAngle += 1.3f;
            //}
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (openDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string filename = openDlg.FileName;
                Bitmap bmp = new Bitmap(filename);
                this.particleNode.UpdateTexture(bmp);
            }
        }

        private void rdoDefaultMode_CheckedChanged(object sender, EventArgs e)
        {
            this.particleNode.Mode = this.rdoDefaultMode.Checked ? ParticleNode.RenderMode.Default : ParticleNode.RenderMode.Textured;
        }

        private void rdoTexturedMode_CheckedChanged(object sender, EventArgs e)
        {
            this.particleNode.Mode = this.rdoTexturedMode.Checked ? ParticleNode.RenderMode.Textured : ParticleNode.RenderMode.Default;
        }
    }

}
