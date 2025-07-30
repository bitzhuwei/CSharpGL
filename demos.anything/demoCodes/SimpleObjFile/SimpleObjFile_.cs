using CSharpGL;
using demos.anything;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleObjFile {
    internal unsafe class SimpleObjFile_ : demoCode {
        public SimpleObjFile_(FormInstance mainForm, WindowsGLCanvas canvas) : base(mainForm, canvas) { }
        private Scene scene;
        private ActionList actionList;
        //private LegacyTriangleNode triangleTip;
        //private LegacyQuadNode quadTip;
        private HighlightGeometryNode tipNode;
        private Picking pickingAction;
        private TexturedNode targetNode;
        private System.Windows.Forms.OpenFileDialog openModelDlg = new OpenFileDialog();
        private System.Windows.Forms.OpenFileDialog openTextureDlg = new OpenFileDialog();

        private bool rotating = true;

        public override void display(GL gl) {
            ActionList list = this.actionList;
            if (list != null) {
                vec4 clearColor = this.scene.clearColor;
                gl.glClearColor(clearColor.x, clearColor.y, clearColor.z, clearColor.w);
                gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);

                list.Act(new ActionParams(Viewport.GetCurrent()));
            }

            if (rotating) {
                IWorldSpace node = this.scene.RootNode;
                if (node != null) {
                    node.RotationAngle += 1;
                }
            }
        }

        public override void init(GL gl) {
            this.openModelDlg.Filter = "*.obj;*.obj_|*.obj;*.obj_";
            this.openTextureDlg.Filter = "*.*|*.*";
            var position = new vec3(5, 6, 4) * 3;
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspective, this.canvas.Width, this.canvas.Height);

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
            manipulater.Bind(camera, this.canvas);
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

            this.canvas.GLMouseMove += Canvas_GLMouseMove;
            this.canvas.GLKeyDown += Canvas_GLKeyDown;

            var builder = new StringBuilder();
            builder.AppendLine($"F: open a model file");
            builder.AppendLine($"T: select a texture file");
            builder.AppendLine($"R: rotate");
            MessageBox.Show(builder.ToString());

        }

        private void Canvas_GLKeyDown(object sender, GLKeyEventArgs e) {
            if (e.KeyData == GLKeys.F) {
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
            else if (e.KeyData == GLKeys.R) {
                this.rotating = !this.rotating;
            }
            else if (e.KeyData == GLKeys.T) {
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
                        var winGLBitmap = new WinGLBitmap(bitmap, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                        var storage = new TexImageBitmap(winGLBitmap);
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

        private void Canvas_GLMouseMove(object sender, GLMouseEventArgs e) {
            //LegacyTriangleNode triangleTip = this.triangleTip;
            //if (triangleTip == null) { return; }
            //LegacyQuadNode quadTip = this.quadTip;
            //if (quadTip == null) { return; }
            HighlightGeometryNode tipNode = this.tipNode;

            int x = e.X;
            int y = this.canvas.Height - e.Y - 1;
            PickedGeometry pickedGeometry = null;
            try {
                pickedGeometry = this.pickingAction.Pick(x, y, PickingGeometryTypes.Triangle | PickingGeometryTypes.Quad, this.canvas.Width, this.canvas.Height);
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

        public override void reshape(GL gl, int width, int height) {
            this.scene.camera.AspectRatio = ((float)this.canvas.Width) / ((float)this.canvas.Height);

        }
    }
}
