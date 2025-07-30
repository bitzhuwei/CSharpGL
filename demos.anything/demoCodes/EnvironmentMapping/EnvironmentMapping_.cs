using CSharpGL;
using demos.anything;
using demos.anything.demoCodes.DistanceFieldFont;
using DistanceFieldFont;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentMapping {
    internal unsafe class EnvironmentMapping_ : demoCode {
        public EnvironmentMapping_(FormInstance mainForm, WindowsGLCanvas canvas) : base(mainForm, canvas) { }
        private Scene scene;
        private ActionList actionList;
        private SkyboxNode skybox;
        private EnvironmentMappingNode environmentMappingNode;
        private LegacyTriangleNode triangleTip;
        private LegacyQuadNode quadTip;
        private Picking pickingAction;


        public override void display(GL gl) {
            ActionList list = this.actionList;
            if (list != null) {
                vec4 clearColor = this.scene.clearColor;
                gl.glClearColor(clearColor.x, clearColor.y, clearColor.z, clearColor.w);
                gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);

                list.Act(new ActionParams(Viewport.GetCurrent()));
            }

            IWorldSpace node = this.environmentMappingNode;
            if (node != null) {
                node.RotationAngle += 1;
            }

        }

        public override void init(GL gl) {
            var position = new vec3(8, 0, 4) * 3;
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspective, this.canvas.Width, this.canvas.Height);

            string folder = System.Windows.Forms.Application.StartupPath;
            //var totalBmp = new Bitmap(System.IO.Path.Combine(folder, @"cubemaps_skybox-world-map-cartoon.png"));
            var totalBmp = new Bitmap(@"media/textures/cubemaps_skybox-world-map-cartoon.png");
            Bitmap[] bitmaps = GetBitmaps(totalBmp);
            this.skybox = SkyboxNode.Create(bitmaps); this.skybox.Scale *= 60;
            //string objFilename = "vnfprismoid.obj_";
            //string objFilename = "vnfdisk.obj_";
            string objFilename = "vnfannulus.obj_";
            //string objFilename = "cerberus.obj_";
            var parser = new ObjVNFParser(false);
            ObjVNFResult result = parser.Parse(objFilename);
            if (result.Error != null) {
                MessageBox.Show(result.Error.ToString());
            }
            else {
                var model = new ObjVNF(result.Mesh);
                var node = EnvironmentMappingNode.Create(
                    this.skybox.SkyboxTexture,
                    model, ObjVNF.strPosition, ObjVNF.strNormal);
                node.ModelSize = model.GetSize();
                float max = node.ModelSize.max();
                node.Scale *= 20.0f / max;
                node.RotationAxis = new vec3(0, 0, 1);
                node.RotationAngle = 90;
                node.Children.Add(new LegacyBoundingBoxNode(node.ModelSize));
                this.environmentMappingNode = node;

                var group = new GroupNode(this.environmentMappingNode, this.skybox);

                this.scene = new Scene(camera) {
                    RootNode = group,
                };

                var list = new ActionList();
                var transformAction = new TransformAction(scene);
                list.Add(transformAction);
                var renderAction = new RenderAction(scene);
                list.Add(renderAction);
                this.actionList = list;

                var manipulater = new FirstPerspectiveManipulater();
                manipulater.Bind(camera, this.canvas);

                this.pickingAction = new Picking(scene);

                this.triangleTip = new LegacyTriangleNode();
                this.quadTip = new LegacyQuadNode();
            }

            this.canvas.GLMouseMove += Canvas_GLMouseMove;

            this.canvas.GLKeyDown += Canvas_GLKeyDown;
            var builder = new StringBuilder();
            builder.AppendLine($"M: reflection/refraction");
            builder.AppendLine($"R: ice/water/glass/diamond");
            MessageBox.Show(builder.ToString());
        }

        private void Canvas_GLKeyDown(object sender, GLKeyEventArgs e) {
            if (e.KeyData == GLKeys.M) {
                if (this.environmentMappingNode.Method == EnvironmentMappingNode.RenderMethod.Reflection) {
                    this.environmentMappingNode.Method = EnvironmentMappingNode.RenderMethod.Refraction;
                }
                else {
                    this.environmentMappingNode.Method = EnvironmentMappingNode.RenderMethod.Reflection;
                }
            }
            else if (e.KeyData == GLKeys.R) {
                this.currentRatioIndex++;
                if (this.currentRatioIndex >= this.ratios.Length) {
                    this.currentRatioIndex = 0;
                }
                this.environmentMappingNode.RefractRatio = this.ratios[this.currentRatioIndex];
            }
        }

        private int currentRatioIndex = 0;
        EnvironmentMappingNode.Ratio[] ratios = new EnvironmentMappingNode.Ratio[] {
            EnvironmentMappingNode.Ratio.Ice,
            EnvironmentMappingNode.Ratio.Water,
            EnvironmentMappingNode.Ratio.Glass,
            EnvironmentMappingNode.Ratio.Diamond,
        };
        // Color coded picking.
        private void Canvas_GLMouseMove(object sender, GLMouseEventArgs e) {
            LegacyTriangleNode triangleTip = this.triangleTip;
            if (triangleTip == null) { return; }
            LegacyQuadNode quadTip = this.quadTip;
            if (quadTip == null) { return; }

            int x = e.X;
            int y = this.canvas.Height - e.Y - 1;
            PickedGeometry pickedGeometry = this.pickingAction.Pick(x, y, PickingGeometryTypes.Triangle | PickingGeometryTypes.Quad, this.canvas.Width, this.canvas.Height);
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

        private Bitmap[] GetBitmaps(Bitmap totalBmp) {
            int width = totalBmp.Width / 4, height = totalBmp.Height / 3;
            var top = new Bitmap(width, height);
            using (var g = Graphics.FromImage(top)) {
                g.DrawImage(totalBmp, new Rectangle(0, 0, width, height), new Rectangle(width, 0, width, height), GraphicsUnit.Pixel);
            }
            var left = new Bitmap(width, height);
            using (var g = Graphics.FromImage(left)) {
                g.DrawImage(totalBmp, new Rectangle(0, 0, width, height), new Rectangle(0, height, width, height), GraphicsUnit.Pixel);
            }
            var front = new Bitmap(width, height);
            using (var g = Graphics.FromImage(front)) {
                g.DrawImage(totalBmp, new Rectangle(0, 0, width, height), new Rectangle(width, height, width, height), GraphicsUnit.Pixel);
            }
            var right = new Bitmap(width, height);
            using (var g = Graphics.FromImage(right)) {
                g.DrawImage(totalBmp, new Rectangle(0, 0, width, height), new Rectangle(width * 2, height, width, height), GraphicsUnit.Pixel);
            }
            var back = new Bitmap(width, height);
            using (var g = Graphics.FromImage(back)) {
                g.DrawImage(totalBmp, new Rectangle(0, 0, width, height), new Rectangle(width * 3, height, width, height), GraphicsUnit.Pixel);
            }
            var bottom = new Bitmap(width, height);
            using (var g = Graphics.FromImage(bottom)) {
                g.DrawImage(totalBmp, new Rectangle(0, 0, width, height), new Rectangle(width, height * 2, width, height), GraphicsUnit.Pixel);
            }

            var flip = RotateFlipType.Rotate180FlipY;
            right.RotateFlip(flip); left.RotateFlip(flip);
            top.RotateFlip(RotateFlipType.Rotate180FlipX); bottom.RotateFlip(RotateFlipType.Rotate180FlipX);
            back.RotateFlip(flip); front.RotateFlip(flip);

            return new Bitmap[] { right, left, top, bottom, back, front };
        }

        public override void reshape(GL gl, int width, int height) {
            this.scene.camera.AspectRatio = ((float)this.canvas.Width) / ((float)this.canvas.Height);

        }
    }
}
