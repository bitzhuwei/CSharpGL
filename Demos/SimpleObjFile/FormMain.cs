using CSharpGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SimpleObjFile
{
    public partial class FormMain : Form
    {
        private Scene scene;
        private ActionList actionList;
        private LegacyTriangleNode triangleTip;
        private LegacyQuadNode quadTip;
        private PickingAction pickingAction;

        public FormMain()
        {
            InitializeComponent();

            this.Load += FormMain_Load;
            this.winGLCanvas1.OpenGLDraw += winGLCanvas1_OpenGLDraw;
            this.winGLCanvas1.Resize += winGLCanvas1_Resize;
            this.winGLCanvas1.MouseMove += winGLCanvas1_MouseMove;
        }

        /// <summary>
        /// Color coded picking.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void winGLCanvas1_MouseMove(object sender, MouseEventArgs e)
        {
            LegacyTriangleNode triangleTip = this.triangleTip;
            if (triangleTip == null) { return; }
            LegacyQuadNode quadTip = this.quadTip;
            if (quadTip == null) { return; }

            int x = e.X;
            int y = this.winGLCanvas1.Height - e.Y - 1;
            PickedGeometry pickedGeometry = null;
            try
            {
                pickedGeometry = this.pickingAction.Pick(x, y, true, true, false);
            }
            catch (Exception)
            { }
            if (pickedGeometry != null)
            {
                switch (pickedGeometry.Type)
                {
                    case GeometryType.Point:
                        throw new NotImplementedException();
                    case GeometryType.Line:
                        throw new NotImplementedException();
                    case GeometryType.Triangle:
                        triangleTip.Vertex0 = pickedGeometry.Positions[0];
                        triangleTip.Vertex1 = pickedGeometry.Positions[1];
                        triangleTip.Vertex2 = pickedGeometry.Positions[2];
                        triangleTip.Parent = pickedGeometry.FromRenderer as SceneNodeBase;
                        quadTip.Parent = null;
                        break;
                    case GeometryType.Quad:
                        quadTip.Vertex0 = pickedGeometry.Positions[0];
                        quadTip.Vertex1 = pickedGeometry.Positions[1];
                        quadTip.Vertex2 = pickedGeometry.Positions[2];
                        quadTip.Vertex3 = pickedGeometry.Positions[3];
                        quadTip.Parent = pickedGeometry.FromRenderer as SceneNodeBase;
                        triangleTip.Parent = null;
                        break;
                    case GeometryType.Polygon:
                        throw new NotImplementedException();
                    default:
                        throw new NotDealWithNewEnumItemException(typeof(GeometryType));
                }

            }
            else
            {
                triangleTip.Parent = null;
                quadTip.Parent = null;
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            var position = new vec3(5, 3, 4);
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspecitive, this.winGLCanvas1.Width, this.winGLCanvas1.Height);

            this.scene = new Scene(camera, this.winGLCanvas1);

            var list = new ActionList();
            var transformAction = new TransformAction(scene);
            list.Add(transformAction);
            var renderAction = new RenderAction(scene);
            list.Add(renderAction);
            this.actionList = list;

            this.pickingAction = new PickingAction(scene);

            this.triangleTip = new LegacyTriangleNode();
            this.quadTip = new LegacyQuadNode();

            var manipulater = new FirstPerspectiveManipulater();
            manipulater.Bind(camera, this.winGLCanvas1);

            string filename = "nanosuit.obj_";
            var parser = new ObjVNFParser(false);
            ObjVNFResult result = parser.Parse(filename);
            if (result.Error != null)
            {
                MessageBox.Show(result.Error.ToString());
            }
            else
            {
                var node = ObjVNFNode.Create(result.Mesh);
                node.Children.Add(new LegacyBoundingBoxNode(node.ModelSize));
                float max = node.ModelSize.max();
                node.Scale *= 7.0f / max;
                node.WorldPosition = new vec3(0, 0, 0);
                var rootElement = this.scene.RootElement;
                this.scene.RootElement = node;
                if (rootElement != null) { rootElement.Dispose(); }
            }
        }

        private void winGLCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            this.actionList.Act();
        }

        void winGLCanvas1_Resize(object sender, EventArgs e)
        {
            this.scene.Camera.AspectRatio = ((float)this.winGLCanvas1.Width) / ((float)this.winGLCanvas1.Height);
        }


        private void 打开OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string filename = this.openFileDialog1.FileName;
                var parser = new ObjVNFParser(false);
                ObjVNFResult result = parser.Parse(filename);
                if (result.Error != null)
                {
                    MessageBox.Show(result.Error.ToString());
                }
                else
                {
                    var node = ObjVNFNode.Create(result.Mesh);
                    float max = node.ModelSize.max();
                    node.Scale *= 16.0f / max;
                    node.WorldPosition = new vec3(0, 0, 0);
                    var rootElement = this.scene.RootElement;
                    this.scene.RootElement = node;
                    if (rootElement != null) { rootElement.Dispose(); }
                }
            }
        }

        private void 退出XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 选项OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new FormProperyGrid(this.scene)).Show();
        }

        private void 旋转RToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.timer1.Enabled = !this.timer1.Enabled;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            IWorldSpace node = this.scene.RootElement;
            if (node != null)
            {
                node.RotationAngle += 1;
            }
        }
    }
}
