using CSharpGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SimpleObjFile {
    public partial class FormMain : Form {
        private Scene scene;
        private ActionList actionList;
        //private LegacyTriangleNode triangleTip;
        //private LegacyQuadNode quadTip;
        private HighlightGeometryNode tipNode;
        private Picking pickingAction;
        private TexturedNode targetNode;

        public FormMain() {
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
        void winGLCanvas1_MouseMove(object sender, MouseEventArgs e) {
            //LegacyTriangleNode triangleTip = this.triangleTip;
            //if (triangleTip == null) { return; }
            //LegacyQuadNode quadTip = this.quadTip;
            //if (quadTip == null) { return; }
            HighlightGeometryNode tipNode = this.tipNode;

            int x = e.X;
            int y = this.winGLCanvas1.Height - e.Y - 1;
            PickedGeometry pickedGeometry = null;
            try {
                pickedGeometry = this.pickingAction.Pick(x, y, PickingGeometryTypes.Triangle | PickingGeometryTypes.Quad, this.winGLCanvas1.Width, this.winGLCanvas1.Height);
            }
            catch (Exception) { }

            if (pickedGeometry != null) {
                switch (pickedGeometry.Type) {
                    case GeometryType.Point:
                        tipNode.Vertex0 = pickedGeometry.Positions[0];
                        tipNode.CurrentMode = CSharpGL.DrawMode.Points;
                        tipNode.Parent = pickedGeometry.FromObject as SceneNodeBase;
                        //tipNode.Parent = this.scene.RootNode;
                        break;
                    case GeometryType.Line:
                        tipNode.Vertex0 = pickedGeometry.Positions[0];
                        tipNode.Vertex1 = pickedGeometry.Positions[1];
                        tipNode.CurrentMode = CSharpGL.DrawMode.Lines;
                        tipNode.Parent = pickedGeometry.FromObject as SceneNodeBase;
                        //tipNode.Parent = this.scene.RootNode;
                        break;
                    case GeometryType.Triangle:
                        //triangleTip.Vertex0 = pickedGeometry.Positions[0];
                        //triangleTip.Vertex1 = pickedGeometry.Positions[1];
                        //triangleTip.Vertex2 = pickedGeometry.Positions[2];
                        //triangleTip.Parent = pickedGeometry.FromObject as SceneNodeBase;
                        //quadTip.Parent = null;
                        tipNode.Vertex0 = pickedGeometry.Positions[0];
                        tipNode.Vertex1 = pickedGeometry.Positions[1];
                        tipNode.Vertex2 = pickedGeometry.Positions[2];
                        tipNode.CurrentMode = CSharpGL.DrawMode.Triangles;
                        tipNode.Parent = pickedGeometry.FromObject as SceneNodeBase;
                        //tipNode.Parent = this.scene.RootNode;
                        break;
                    case GeometryType.Quad:
                        //quadTip.Vertex0 = pickedGeometry.Positions[0];
                        //quadTip.Vertex1 = pickedGeometry.Positions[1];
                        //quadTip.Vertex2 = pickedGeometry.Positions[2];
                        //quadTip.Vertex3 = pickedGeometry.Positions[3];
                        //quadTip.Parent = pickedGeometry.FromObject as SceneNodeBase;
                        //triangleTip.Parent = null;
                        tipNode.Vertex0 = pickedGeometry.Positions[0];
                        tipNode.Vertex1 = pickedGeometry.Positions[1];
                        tipNode.Vertex2 = pickedGeometry.Positions[2];
                        tipNode.Vertex3 = pickedGeometry.Positions[3];
                        tipNode.CurrentMode = CSharpGL.DrawMode.Quads;
                        tipNode.Parent = pickedGeometry.FromObject as SceneNodeBase;
                        //tipNode.Parent = this.scene.RootNode;
                        break;
                    case GeometryType.Polygon:
                        throw new NotImplementedException();
                    default:
                        throw new NotDealWithNewEnumItemException(typeof(GeometryType));
                }

            }
            else {
                //triangleTip.Parent = null;
                //quadTip.Parent = null;
                tipNode.Parent = null;
            }
        }

        private void FormMain_Load(object sender, EventArgs e) {
            var position = new vec3(5, 6, 4) * 3;
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspective, this.winGLCanvas1.Width, this.winGLCanvas1.Height);

            this.scene = new Scene(camera);

            //(new FormTree(scene)).Show();

            this.scene.RootNode = new GroupNode();
            {
                var axisNode = AxisNode.Create();
                axisNode.Scale = new vec3(1, 1, 1) * 30;
                this.scene.RootNode.Children.Add(axisNode);
            }

            var list = new ActionList();
            var transformAction = new TransformAction(scene);
            list.Add(transformAction);
            var renderAction = new RenderAction(scene);
            list.Add(renderAction);
            this.actionList = list;

            this.pickingAction = new Picking(scene);

            //this.triangleTip = new LegacyTriangleNode();
            //this.quadTip = new LegacyQuadNode();
            this.tipNode = HighlightGeometryNode.Create();

            var manipulater = new FirstPerspectiveManipulater();
            manipulater.Bind(camera, this.winGLCanvas1);
            {
                ObjItem[] items = HanoiTower.GetDataSource();
                for (int i = 0; i < items.Length; i++) {
                    var item = items[i];
                    var filename = "item" + (i) + ".obj";
                    item.model.DumpObjFile(filename, "item" + (i));
                    var parser = new ObjVNFParser(false);
                    ObjVNFResult result = parser.Parse(filename);
                    if (result.Error != null) {
                        //Console.WriteLine("Error: {0}", result.Error);
                    }
                    else {
                        ObjVNFMesh mesh = result.Mesh;
                        var node = TexturedNode.Create(mesh);
                        node.Children.Add(new LegacyBoundingBoxNode(node.ModelSize));
                        //float max = node.ModelSize.max();
                        //node.Scale *= 7.0f / max;
                        node.WorldPosition = item.position;
                        var rootElement = this.scene.RootNode;
                        this.scene.RootNode.Children.Add(node);
                        this.targetNode = node;
                        //if (rootElement != null) { rootElement.Dispose(); }
                    }
                }
            }
        }

        private void winGLCanvas1_OpenGLDraw(object sender, PaintEventArgs e) {
            ActionList list = this.actionList;
            if (list != null) {
                vec4 clearColor = this.scene.ClearColor;
                GL.Instance.ClearColor(clearColor.x, clearColor.y, clearColor.z, clearColor.w);
                GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);

                list.Act(new ActionParams(Viewport.GetCurrent()));
            }
        }

        void winGLCanvas1_Resize(object sender, EventArgs e) {
            this.scene.Camera.AspectRatio = ((float)this.winGLCanvas1.Width) / ((float)this.winGLCanvas1.Height);
        }


        private void 打开OToolStripMenuItem_Click(object sender, EventArgs e) {
            if (this.openModelDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                string filename = this.openModelDlg.FileName;
                var parser = new ObjVNFParser(false);
                ObjVNFResult result = parser.Parse(filename);
                if (result.Error != null) {
                    MessageBox.Show(result.Error.ToString());
                }
                else {
                    var node = TexturedNode.Create(result.Mesh);
                    float max = node.ModelSize.max();
                    node.Scale *= 16.0f / max;
                    node.WorldPosition = new vec3(0, 0, 0);
                    var rootElement = this.scene.RootNode;
                    this.scene.RootNode = node;
                    if (rootElement != null) { rootElement.Dispose(); }
                    this.targetNode = node;
                }
            }
        }

        private void 退出XToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void 选项OToolStripMenuItem_Click(object sender, EventArgs e) {
            (new FormPropertyGrid(this.scene)).Show();
        }

        private void 旋转RToolStripMenuItem_Click(object sender, EventArgs e) {
            this.timer1.Enabled = !this.timer1.Enabled;
        }

        private void timer1_Tick(object sender, EventArgs e) {
            IWorldSpace node = this.scene.RootNode;
            if (node != null) {
                node.RotationAngle += 1;
            }
        }

        private void 纹理TToolStripMenuItem_Click(object sender, EventArgs e) {
            TexturedNode node = this.targetNode;
            if (node == null) {
                MessageBox.Show("Please open a model first!");
                return;
            }

            if (this.openTextureDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                try {
                    var filename = this.openTextureDlg.FileName;
                    var bitmap = new Bitmap(filename);
                    bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);
                    var storage = new TexImageBitmap(bitmap);
                    var texture = new Texture(storage,
                        new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_CLAMP_TO_EDGE),
                        new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_CLAMP_TO_EDGE),
                        new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR),
                        new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR));
                    texture.Initialize();
                    bitmap.Dispose();
                    node.Texture = texture;
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.ToString());
                    return;
                }
            }
        }
    }
}
