using CSharpGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EnvironmentMapping
{
    public partial class FormMain : Form
    {
        private Scene scene;
        private ActionList actionList;
        private SkyboxNode skybox;
        private EnvironmentMappingNode environmentMappingNode;
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
            PickedGeometry pickedGeometry = this.pickingAction.Pick(x, y, true, true, false, this.winGLCanvas1.Width, this.winGLCanvas1.Height);
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
            foreach (var item in Enum.GetNames(typeof(EnvironmentMappingNode.Ratio)))
            {
                this.cmbRatios.Items.Add(item);
            }

            var position = new vec3(8, 0, 4) * 3;
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspecitive, this.winGLCanvas1.Width, this.winGLCanvas1.Height);

            string folder = System.Windows.Forms.Application.StartupPath;
            var totalBmp = new Bitmap(System.IO.Path.Combine(folder, @"cubemaps_skybox.png"));
            Bitmap[] bitmaps = GetBitmaps(totalBmp);
            this.skybox = SkyboxNode.Create(bitmaps); this.skybox.Scale *= 60;
            string objFilename = System.IO.Path.Combine(folder, "nanosuit.obj_");
            var parser = new ObjVNFParser(false);
            ObjVNFResult result = parser.Parse(objFilename);
            if (result.Error != null)
            {
                MessageBox.Show(result.Error.ToString());
            }
            else
            {
                var model = new ObjVNF(result.Mesh);
                var node = EnvironmentMappingNode.Create(
                    this.skybox.SkyboxTexture,
                    model, ObjVNF.strPosition, ObjVNF.strNormal);
                node.ModelSize = model.GetSize();
                float max = node.ModelSize.max();
                node.Scale *= 20.0f / max;
                node.Children.Add(new LegacyBoundingBoxNode(node.ModelSize));
                this.environmentMappingNode = node;

                var group = new GroupNode(this.environmentMappingNode, this.skybox);

                this.scene = new Scene(camera)

                {
                    RootElement = group,
                };

                var list = new ActionList();
                var transformAction = new TransformAction(scene);
                list.Add(transformAction);
                var renderAction = new RenderAction(scene);
                list.Add(renderAction);
                this.actionList = list;

                var manipulater = new FirstPerspectiveManipulater();
                manipulater.Bind(camera, this.winGLCanvas1);

                this.pickingAction = new PickingAction(scene);

                this.triangleTip = new LegacyTriangleNode();
                this.quadTip = new LegacyQuadNode();
            }
        }

        private Bitmap[] GetBitmaps(Bitmap totalBmp)
        {
            int width = totalBmp.Width / 4, height = totalBmp.Height / 3;
            var top = new Bitmap(width, height);
            using (var g = Graphics.FromImage(top))
            {
                g.DrawImage(totalBmp, new Rectangle(0, 0, width, height), new Rectangle(width, 0, width, height), GraphicsUnit.Pixel);
            }
            var left = new Bitmap(width, height);
            using (var g = Graphics.FromImage(left))
            {
                g.DrawImage(totalBmp, new Rectangle(0, 0, width, height), new Rectangle(0, height, width, height), GraphicsUnit.Pixel);
            }
            var front = new Bitmap(width, height);
            using (var g = Graphics.FromImage(front))
            {
                g.DrawImage(totalBmp, new Rectangle(0, 0, width, height), new Rectangle(width, height, width, height), GraphicsUnit.Pixel);
            }
            var right = new Bitmap(width, height);
            using (var g = Graphics.FromImage(right))
            {
                g.DrawImage(totalBmp, new Rectangle(0, 0, width, height), new Rectangle(width * 2, height, width, height), GraphicsUnit.Pixel);
            }
            var back = new Bitmap(width, height);
            using (var g = Graphics.FromImage(back))
            {
                g.DrawImage(totalBmp, new Rectangle(0, 0, width, height), new Rectangle(width * 3, height, width, height), GraphicsUnit.Pixel);
            }
            var bottom = new Bitmap(width, height);
            using (var g = Graphics.FromImage(bottom))
            {
                g.DrawImage(totalBmp, new Rectangle(0, 0, width, height), new Rectangle(width, height * 2, width, height), GraphicsUnit.Pixel);
            }

            var flip = RotateFlipType.Rotate180FlipY;
            right.RotateFlip(flip); left.RotateFlip(flip);
            top.RotateFlip(RotateFlipType.Rotate180FlipX); bottom.RotateFlip(RotateFlipType.Rotate180FlipX);
            back.RotateFlip(flip); front.RotateFlip(flip);

            return new Bitmap[] { right, left, top, bottom, back, front };
        }

        private void winGLCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            ActionList list = this.actionList;
            if (list != null)
            {
                list.Act(new ActionParams(Viewport.GetCurrent()));
            }
        }

        void winGLCanvas1_Resize(object sender, EventArgs e)
        {
            this.scene.Camera.AspectRatio = ((float)this.winGLCanvas1.Width) / ((float)this.winGLCanvas1.Height);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            IWorldSpace node = this.environmentMappingNode;
            if (node != null)
            {
                node.RotationAngle += 1;
            }
        }

        private void rdoReflection_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoReflection.Checked)
            {
                this.environmentMappingNode.Method = EnvironmentMappingNode.RenderMethod.Reflection;
            }
        }

        private void rdoRefraction_CheckedChanged(object sender, EventArgs e)
        {
            bool refraction = this.rdoRefraction.Checked;
            if (refraction)
            {
                this.environmentMappingNode.Method = EnvironmentMappingNode.RenderMethod.Refraction;
            }

            this.cmbRatios.Enabled = refraction;
        }

        private void cmbRatios_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.environmentMappingNode.RefractRatio = (EnvironmentMappingNode.Ratio)Enum.Parse(typeof(EnvironmentMappingNode.Ratio), this.cmbRatios.SelectedItem.ToString());
        }
    }
}
