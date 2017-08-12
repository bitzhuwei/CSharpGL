using CSharpGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ComputeShader.EdgeDetection
{
    public partial class FormMain : Form
    {
        private Scene scene;
        private ActionList actionList;
        private EdgeDetectNode edgeDetectNode;
        public FormMain()
        {
            InitializeComponent();

            this.Load += FormMain_Load;
            this.winGLCanvas1.OpenGLDraw += winGLCanvas1_OpenGLDraw;
            this.winGLCanvas1.Resize += winGLCanvas1_Resize;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            var position = new vec3(0, 0, 0.9f);
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspecitive, this.winGLCanvas1.Width, this.winGLCanvas1.Height);
            this.scene = new Scene(camera, this.winGLCanvas1);
            {
                this.edgeDetectNode = new EdgeDetectNode();
                var rectangleNode = RectangleNode.Create();
                rectangleNode.TextureSource = this.edgeDetectNode;
                var group = new GroupNode(this.edgeDetectNode, rectangleNode);
                this.scene.RootElement = group;
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
            this.actionList.Act();
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
                    var node = this.edgeDetectNode;
                    if (node != null)
                    {
                        node.UpdateTexture(bitmap);
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
