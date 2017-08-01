using CSharpGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Normal
{
    public partial class FormMain : Form
    {
        private Scene scene;
        private ActionList actionList;
        private NormalNode node;

        public FormMain()
        {
            InitializeComponent();

            this.Load += FormMain_Load;
            this.winGLCanvas1.OpenGLDraw += winGLCanvas1_OpenGLDraw;
            this.winGLCanvas1.Resize += winGLCanvas1_Resize;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            var position = new vec3(1, 0.6f, 1) * 14;
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspecitive, this.winGLCanvas1.Width, this.winGLCanvas1.Height);
            this.scene = new Scene(camera, this.winGLCanvas1);

            string objFilename = "triceratops.obj_";
            var parser = new ObjVNFParser(true);
            ObjVNFResult result = parser.Parse(objFilename);
            if (result.Error != null)
            {
                MessageBox.Show(result.Error.ToString());
            }
            else
            {
                var model = new ObjVNF(result.Mesh);
                this.node = NormalNode.Create(model, ObjVNF.strPosition, ObjVNF.strNormal, model.GetSize());
                this.scene.RootElement = node;
            }

            var list = new ActionList();
            var transformAction = new TransformAction(scene);
            list.Add(transformAction);
            var renderAction = new RenderAction(scene);
            list.Add(renderAction);
            this.actionList = list;

            var manipulater = new FirstPerspectiveManipulater();
            manipulater.Bind(camera, this.winGLCanvas1);
        }

        private void winGLCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            this.actionList.Act();
        }

        void winGLCanvas1_Resize(object sender, EventArgs e)
        {
            this.scene.Camera.AspectRatio = ((float)this.winGLCanvas1.Width) / ((float)this.winGLCanvas1.Height);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            IWorldSpace node = this.node;
            if (node != null)
            {
                node.RotationAngle += 1;
            }
        }

        private void chkRotate_CheckedChanged(object sender, EventArgs e)
        {
            this.timer1.Enabled = this.chkRotate.Checked;
        }

        private void lblColorDisply_Click(object sender, EventArgs e)
        {
            if (this.colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Color color = this.colorDialog1.Color;
                var node = this.node as NormalNode;
                if (node != null)
                {
                    node.DiffuseColor = color.ToVec3();
                    this.lblColor.Text = string.Format("{0}", color);
                    this.lblColorDisply.BackColor = color;
                }
            }
        }
    }
}
