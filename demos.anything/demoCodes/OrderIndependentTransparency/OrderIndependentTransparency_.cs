using CSharpGL;
using demos.anything;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderIndependentTransparency {
    internal unsafe class OrderIndependentTransparency_ : demoCode {
        public OrderIndependentTransparency_(FormInstance mainForm, WindowsGLCanvas canvas) : base(mainForm, canvas) { }
        private Scene scene;
        private ActionList actionList;
        private LegacyTriangleNode triangleTip;
        private LegacyQuadNode quadTip;
        private Picking pickingAction;
        private System.Windows.Forms.OpenFileDialog openFileDialog1 = new OpenFileDialog();

        public override void display(GL gl) {
            ActionList list = this.actionList;
            if (list != null) {
                vec4 clearColor = this.scene.clearColor;
                gl.glClearColor(clearColor.x, clearColor.y, clearColor.z, clearColor.w);
                gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);

                list.Act(new ActionParams(Viewport.GetCurrent()));
            }

            IWorldSpace node = this.scene.RootNode;
            if (node != null) {
                node.RotationAngle += 0.1f;
            }

        }

        public override void init(GL gl) {
            this.openFileDialog1.Filter = "*.obj;*.obj_|*.obj;*.obj_";

            var position = new vec3(5, 3, 4);
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspective, this.canvas.Width, this.canvas.Height);

            this.scene = new Scene(camera)
;

            var list = new ActionList();
            var transformAction = new TransformAction(scene);
            list.Add(transformAction);
            var renderAction = new RenderAction(scene);
            list.Add(renderAction);
            this.actionList = list;

            this.pickingAction = new Picking(scene);

            this.triangleTip = new LegacyTriangleNode();
            this.quadTip = new LegacyQuadNode();

            var manipulater = new FirstPerspectiveManipulater();
            manipulater.Bind(camera, this.canvas);

            //string folder = System.Windows.Forms.Application.StartupPath;
            //string filename = System.IO.Path.Combine(folder + @"\..\..\..\..\Infrastructure\CSharpGL.Models", "vnfHanoiTower.obj_");
            //var parser = new ObjVNFParser(false);
            //ObjVNFResult result = parser.Parse(filename);
            //if (result.Error != null)
            //{
            //    MessageBox.Show(result.Error.ToString());
            //}
            //else
            //{
            //    var model = new ObjVNF(result.Mesh);
            //    var node = OITNode.Create(model, ObjVNF.strPosition, ObjVNF.strNormal, model.GetSize());
            //    float max = node.ModelSize.max();
            //    node.Scale *= 7.0f / max;
            //    node.WorldPosition = new vec3(0, 0, 0);
            //    var rootElement = this.scene.RootElement;
            //    this.scene.RootElement = node;
            //    if (rootElement != null) { rootElement.Dispose(); }
            //}
            // use teapot instead.
            var model = new Teapot();
            var node = OITNode.Create(model, Teapot.strPosition, Teapot.strNormal, model.GetModelSize());
            float max = node.ModelSize.max();
            node.Scale *= 7.0F / max;
            node.WorldPosition = new vec3(0, 0, 0);
            this.scene.RootNode = node;

            this.canvas.GLMouseMove += Canvas_GLMouseMove;
            this.canvas.GLKeyDown += Canvas_GLKeyDown;

            MessageBox.Show("F: choose model");
            MessageBox.Show("This demo is invalid on some computers!");
        }

        private void Canvas_GLKeyDown(object sender, GLKeyEventArgs e) {
            if (e.KeyData == GLKeys.F) {
                if (this.openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                    string filename = this.openFileDialog1.FileName;
                    var parser = new ObjVNFParser(false);
                    ObjVNFResult result = parser.Parse(filename);
                    if (result.Error != null) {
                        MessageBox.Show(result.Error.ToString());
                    }
                    else {
                        var model = new ObjVNF(result.Mesh);
                        var node = OITNode.Create(model, ObjVNF.strPosition, ObjVNF.strNormal, model.GetSize());
                        float max = node.ModelSize.max();
                        node.Scale *= 7.0f / max;
                        node.WorldPosition = new vec3(0, 0, 0);
                        var rootElement = this.scene.RootNode;
                        this.scene.RootNode = node;
                        if (rootElement != null) { rootElement.Dispose(); }
                    }
                }

            }
        }

        private void Canvas_GLMouseMove(object sender, GLMouseEventArgs e) {
            LegacyTriangleNode triangleTip = this.triangleTip;
            if (triangleTip == null) { return; }
            LegacyQuadNode quadTip = this.quadTip;
            if (quadTip == null) { return; }

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
                throw new NotImplementedException();
                case GeometryType.Line:
                throw new NotImplementedException();
                case GeometryType.Triangle:
                triangleTip.Vertex0 = pickedGeometry.Positions[0];
                triangleTip.Vertex1 = pickedGeometry.Positions[1];
                triangleTip.Vertex2 = pickedGeometry.Positions[2];
                triangleTip.Parent = pickedGeometry.FromObject as SceneNodeBase;
                quadTip.Parent = null;
                break;
                case GeometryType.Quad:
                quadTip.Vertex0 = pickedGeometry.Positions[0];
                quadTip.Vertex1 = pickedGeometry.Positions[1];
                quadTip.Vertex2 = pickedGeometry.Positions[2];
                quadTip.Vertex3 = pickedGeometry.Positions[3];
                quadTip.Parent = pickedGeometry.FromObject as SceneNodeBase;
                triangleTip.Parent = null;
                break;
                case GeometryType.Polygon:
                throw new NotImplementedException();
                default:
                throw new NotDealWithNewEnumItemException(typeof(GeometryType));
                }

            }
            else {
                triangleTip.Parent = null;
                quadTip.Parent = null;
            }
        }

        public override void reshape(GL gl, int width, int height) {
            this.scene.camera.AspectRatio = ((float)this.canvas.Width) / ((float)this.canvas.Height);

        }
    }
}
