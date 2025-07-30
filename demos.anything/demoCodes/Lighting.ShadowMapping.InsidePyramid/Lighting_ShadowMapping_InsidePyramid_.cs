using CSharpGL;
using demos.anything;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lighting.ShadowMapping.InsidePyramid {
    internal unsafe class Lighting_ShadowMapping_InsidePyramid_ : demoCode {
        public Lighting_ShadowMapping_InsidePyramid_(FormInstance mainForm, WindowsGLCanvas canvas) : base(mainForm, canvas) { }
        private Scene scene;
        private ActionList actionList;
        private Picking pickingAction;
        private LegacyPointNode pointTip;

        private PickedGeometry pickedGeometry;
        private DragParam dragParam;
        private ivec2 lastMousePosition;

        public override void display(GL gl) {
            ActionList list = this.actionList;
            if (list != null) {
                vec4 clearColor = this.scene.clearColor;
                gl.glClearColor(clearColor.x, clearColor.y, clearColor.z, clearColor.w);
                gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);

                list.Act(new ActionParams(Viewport.GetCurrent()));
            }
        }

        public override void init(GL gl) {
            var position = new vec3(0, 0.4f, 1) * 4;
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Ortho, this.canvas.Width, this.canvas.Height);
            this.scene = new Scene(camera);
            this.scene.RootNode = GetRootNode();

            var list = new ActionList();
            list.Add(new TransformAction(scene));
            list.Add(new RenderAction(scene));
            this.actionList = list;

            this.pickingAction = new Picking(scene);
            this.pointTip = new LegacyPointNode();

            //Match(this.trvScene, scene.RootNode);
            //this.trvScene.ExpandAll();
            (new FormNodePropertyGrid(scene.RootNode)).Show();

            var manipulater = new FirstPerspectiveManipulater();
            manipulater.BindingMouseButtons = GLMouseButtons.Right;
            manipulater.Bind(camera, this.canvas);

            this.canvas.GLMouseDown += Canvas_GLMouseDown;
            this.canvas.GLMouseMove += Canvas_GLMouseMove;
            this.canvas.GLMouseUp += Canvas_GLMouseUp;
        }

        private void Canvas_GLMouseUp(object sender, GLMouseEventArgs e) {
            if (e.Button == GLMouseButtons.Right) {
                //// operate camera
                //rotator.MouseUp(e.X, e.Y);
            }
            else if (e.Button == GLMouseButtons.Left) {
                this.dragParam = null;
            }

            this.lastMousePosition = e.Location;
        }

        private void Canvas_GLMouseMove(object sender, GLMouseEventArgs e) {
            if (lastMousePosition == e.Location) { return; }


            if (e.Button == GLMouseButtons.Right) {
                //// operate camera
                //rotator.MouseMove(e.X, e.Y);
            }
            else if (e.Button == GLMouseButtons.Left) {
                // move vertex
                DragParam dragParam = this.dragParam;
                if (dragParam != null && this.pickedGeometry != null) {
                    var node = this.pickedGeometry.FromObject as PickableNode;
                    var currentWindowSpacePos = new vec3(e.X, this.canvas.Height - e.Y - 1, this.pickedGeometry.PickedPosition.z);
                    var currentModelSpacePos = glm.unProject(currentWindowSpacePos, dragParam.viewMat * node.GetModelMatrix(), dragParam.projectionMat, dragParam.viewport);
                    var modelSpacePositionDiff = currentModelSpacePos - dragParam.lastModelSpacePos;
                    dragParam.lastModelSpacePos = currentModelSpacePos;
                    IList<vec3> newPositions = node.MovePositions(
                          modelSpacePositionDiff,
                          dragParam.pickedVertexIds);

                    this.UpdateHightlight(newPositions);
                }
            }
            else {
                int x = e.X;
                int y = this.canvas.Height - e.Y - 1;
                this.pickedGeometry = this.pickingAction.Pick(x, y, PickingGeometryTypes.Point, this.canvas.Width, this.canvas.Height);

                if (this.pickedGeometry != null) {
                    this.pickedGeometry = this.pickingAction.Pick(x, y, PickingGeometryTypes.Point, this.canvas.Width, this.canvas.Height);
                }

                this.UpdateHightlight();
            }

            this.lastMousePosition = e.Location;
        }

        private void Canvas_GLMouseDown(object sender, GLMouseEventArgs e) {
            this.lastMousePosition = e.Location;

            if (e.Button == GLMouseButtons.Right) {
                //// operate camera
                //rotator.SetBounds(this.glCanvas1.Width, this.glCanvas1.Height);
                //rotator.MouseDown(e.X, e.Y);
            }
            else if (e.Button == GLMouseButtons.Left) {
                // move vertex
                if (pickedGeometry != null) {
                    IGLCanvas canvas = this.canvas;
                    var viewport = new vec4(0, 0, canvas.Width, canvas.Height);
                    var lastWindowSpacePos = new vec3(e.X, this.canvas.Height - e.Y - 1, pickedGeometry.PickedPosition.z);
                    mat4 projectionMat = this.scene.camera.GetProjectionMatrix();
                    mat4 viewMat = this.scene.camera.GetViewMatrix();
                    mat4 modelMat = (pickedGeometry.FromObject as PickableNode).GetModelMatrix();
                    var lastModelSpacePos = glm.unProject(lastWindowSpacePos, viewMat * modelMat, projectionMat, viewport);

                    var dragParam = new DragParam(
                        lastModelSpacePos,
                        this.scene.camera.GetProjectionMatrix(),
                        this.scene.camera.GetViewMatrix(),
                        viewport,
                        new ivec2(e.X, this.canvas.Height - e.Y - 1));
                    dragParam.pickedVertexIds.AddRange(pickedGeometry.VertexIds);
                    this.dragParam = dragParam;
                }
            }
        }
        private unsafe Color GetColorAtMouse(int x, int y) {
            var gl = GL.Current; Debug.Assert(gl != null);
            var colors = stackalloc byte[4];
            gl.glReadPixels(x, y, 1, 1, GL.GL_RGBA, GL.GL_UNSIGNED_BYTE, (IntPtr)colors);
            Color c = Color.FromArgb(colors[3], colors[0], colors[1], colors[2]);

            return c;
        }

        private void UpdateHightlight(IList<vec3> newPositions) {
            switch (this.pickedGeometry.Type) {
            case GeometryType.Point:
            pointTip.Vertex = newPositions[0];
            break;
            case GeometryType.Line:
            throw new NotImplementedException();
            case GeometryType.Triangle:
            throw new NotImplementedException();
            case GeometryType.Quad:
            throw new NotImplementedException();
            case GeometryType.Polygon:
            throw new NotImplementedException();
            default:
            throw new NotDealWithNewEnumItemException(typeof(GeometryType));
            }
        }

        private void UpdateHightlight() {
            PickedGeometry picked = this.pickedGeometry;
            if (picked != null) {
                switch (picked.Type) {
                case GeometryType.Point:
                pointTip.Vertex = picked.Positions[0];
                pointTip.Parent = picked.FromObject as SceneNodeBase;
                break;
                case GeometryType.Line:
                throw new NotImplementedException();
                case GeometryType.Triangle:
                throw new NotImplementedException();
                case GeometryType.Quad:
                throw new NotImplementedException();
                case GeometryType.Polygon:
                throw new NotImplementedException();
                default:
                throw new NotDealWithNewEnumItemException(typeof(GeometryType));
                }

            }
            else {
                pointTip.Parent = null;
            }
        }

        private SceneNodeBase GetRootNode() {
            var group = new GroupNode();

            {
                var node = PyramideNode.Create();
                group.Children.Add(node);
            }
            {
                var triangleModel = new TriangleModel();
                var node = TriangleNode.Create();
                group.Children.Add(node);
            }

            return group;
        }

        public override void reshape(GL gl, int width, int height) {
            this.scene.camera.AspectRatio = ((float)this.canvas.Width) / ((float)this.canvas.Height);

        }
    }
}
