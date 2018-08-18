using CSharpGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace c15d00_InverseColor
{
    public partial class FormMain : Form
    {
        private Scene scene;
        private ActionList actionList;
        private ComputeShaderNode computeShaderNode;
        public FormMain()
        {
            InitializeComponent();

            this.Load += FormMain_Load;
            this.winGLCanvas1.OpenGLDraw += winGLCanvas1_OpenGLDraw;
            this.winGLCanvas1.Resize += winGLCanvas1_Resize;
            this.winGLCanvas1.KeyPress += winGLCanvas1_KeyPress;
        }

        void winGLCanvas1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'n')
            {
                this.computeShaderNode.NextConfig();
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            var position = new vec3(0, 0, 0.9f);
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspective, this.winGLCanvas1.Width, this.winGLCanvas1.Height);
            this.scene = new Scene(camera);
            {
                this.computeShaderNode = ComputeShaderNode.Create();
                this.scene.RootNode = this.computeShaderNode;
            }
            var list = new ActionList();
            var transformAction = new TransformAction(scene);
            list.Add(transformAction);
            var renderAction = new RenderAction(scene);
            list.Add(renderAction);
            this.actionList = list;

            var manipulater = new FirstPerspectiveManipulater();
            manipulater.Bind(camera, this.winGLCanvas1);
            manipulater.StepLength = 0.1f;
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

        private void btnOpenImage_Click(object sender, EventArgs e)
        {
            if (this.openImageDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    string filename = this.openImageDlg.FileName;
                    var bitmap = new Bitmap(filename);
                    var node = this.computeShaderNode;
                    if (node != null)
                    {
                        node.SetTexture(bitmap);
                    }
                    bitmap.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}
