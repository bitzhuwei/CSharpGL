using CSharpGL;
using demos.OpenGLviaCSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fuluDd00_MathExpression {
    internal unsafe class fuluDd00_MathExpression_ : demoCode {
        public fuluDd00_MathExpression_(FormInstance mainForm, WindowsGLCanvas canvas) : base(mainForm, canvas) { }
        private Scene scene;
        private ActionList actionList;

        private Picking pickingAction;
        private LegacyTriangleNode triangleTip;
        private LegacyQuadNode quadTip;

        private PickedGeometry pickedGeometry;
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
            var position = new vec3(5, 3, 4) * 0.2f;
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspective, this.canvas.Width, this.canvas.Height);

            this.scene = new Scene(camera);
            {
                var manipulater = new ArcBallManipulater(GLMouseButtons.Left | GLMouseButtons.Right);
                manipulater.Bind(camera, this.canvas);
                manipulater.Rotated += manipulater_Rotated;
                var node = RaycastNode.Create();
                this.scene.RootNode = node;
                (new FormNodePropertyGrid(node)).Show();
            }

            var list = new ActionList();
            var transformAction = new TransformAction(scene);
            list.Add(transformAction);
            var renderAction = new RenderAction(scene);
            list.Add(renderAction);
            this.actionList = list;

            this.pickingAction = new Picking(scene);

            this.triangleTip = new LegacyTriangleNode();
            this.quadTip = new LegacyQuadNode();

            this.canvas.GLMouseDown += Canvas_GLMouseDown;
            this.canvas.GLMouseMove += Canvas_GLMouseMove;
            this.canvas.GLMouseUp += Canvas_GLMouseUp;
            this.canvas.GLMouseWheel += Canvas_GLMouseWheel;

        }

        private void Canvas_GLMouseWheel(object sender, GLMouseEventArgs e) {
            var scene = this.scene;
            if (scene != null) {
                scene.camera.MouseWheel(e.Delta);
            }

        }

        private void Canvas_GLMouseUp(object sender, GLMouseEventArgs e) {
            if (e.Button == GLMouseButtons.Right) {
                //// operate camera
                //rotator.MouseUp(e.X, e.Y);
            }
            else if (e.Button == GLMouseButtons.Left) {
                // move vertex
            }

            this.lastMousePosition = e.Location;

        }

        private void Canvas_GLMouseMove(object sender, GLMouseEventArgs e) {
            if (lastMousePosition == e.Location) { return; }

            //if (e.Button == System.Windows.Forms.MouseButtons.Right)
            //{
            //    //// operate camera
            //    //rotator.MouseMove(e.X, e.Y);
            //}
            //else if (e.Button == System.Windows.Forms.MouseButtons.Left)
            //{
            //    // move vertex
            //    DragParam dragParam = this.dragParam;
            //    if (dragParam != null && this.pickedGeometry != null)
            //    {
            //        var node = this.pickedGeometry.FromObject as PickableNode;
            //        var currentWindowSpacePos = new vec3(e.X, this.canvas.Height - e.Y - 1, this.pickedGeometry.PickedPosition.z);
            //        var currentModelSpacePos = glm.unProject(currentWindowSpacePos, dragParam.viewMat * node.GetModelMatrix(), dragParam.projectionMat, dragParam.viewport);
            //        var modelSpacePositionDiff = currentModelSpacePos - dragParam.lastModelSpacePos;
            //        dragParam.lastModelSpacePos = currentModelSpacePos;
            //        IList<vec3> newPositions = node.MovePositions(
            //              modelSpacePositionDiff,
            //              dragParam.pickedVertexIds);

            //        this.UpdateHightlight(newPositions);
            //    }
            //}
            //else
            {
                int x = e.X;
                int y = this.canvas.Height - e.Y - 1;
                PickedGeometry pickedGeometry = this.pickingAction.Pick(x, y, PickingGeometryTypes.Triangle | PickingGeometryTypes.Quad, this.canvas.Width, this.canvas.Height);
                this.pickedGeometry = pickedGeometry;
                this.UpdateHightlight(pickedGeometry);

                if (pickedGeometry != null) {
                    this.canvas.Invalidate();
                }
            }

            this.lastMousePosition = e.Location;

            //this.canvas.Invalidate();// redraw the scene.

        }

        private void Canvas_GLMouseDown(object sender, GLMouseEventArgs e) {
            this.lastMousePosition = e.Location;

            if (e.Button == GLMouseButtons.Right) {
                //// operate camera
                //rotator.SetBounds(this.glCanvas1.Width, this.glCanvas1.Height);
                //rotator.MouseDown(e.X, e.Y);
            }
            else if (e.Button == GLMouseButtons.Left) {
                //// move vertex
                //if (pickedGeometry != null)
                //{
                //    IGLCanvas canvas = this.canvas;
                //    var viewport = new vec4(0, 0, canvas.Width, canvas.Height);
                //    var lastWindowSpacePos = new vec3(e.X, this.canvas.Height - e.Y - 1, pickedGeometry.PickedPosition.z);
                //    mat4 projectionMat = this.scene.Camera.GetProjectionMatrix();
                //    mat4 viewMat = this.scene.Camera.GetViewMatrix();
                //    mat4 modelMat = (pickedGeometry.FromObject as PickableNode).GetModelMatrix();
                //    var lastModelSpacePos = glm.unProject(lastWindowSpacePos, viewMat * modelMat, projectionMat, viewport);

                //    var dragParam = new DragParam(
                //        lastModelSpacePos,
                //        this.scene.Camera.GetProjectionMatrix(),
                //        this.scene.Camera.GetViewMatrix(),
                //        viewport,
                //        new ivec2(e.X, this.canvas.Height - e.Y - 1));
                //    dragParam.pickedVertexIds.AddRange(pickedGeometry.VertexIds);
                //    this.dragParam = dragParam;
                //}
            }

        }

        private void UpdateHightlight(IList<vec3> newPositions) {
            switch (this.pickedGeometry.Type) {
            case GeometryType.Point:
            throw new NotImplementedException();
            case GeometryType.Line:
            throw new NotImplementedException();
            case GeometryType.Triangle:
            triangleTip.Vertex0 = newPositions[0];
            triangleTip.Vertex1 = newPositions[1];
            triangleTip.Vertex2 = newPositions[2];
            break;
            case GeometryType.Quad:
            quadTip.Vertex0 = newPositions[0];
            quadTip.Vertex1 = newPositions[1];
            quadTip.Vertex2 = newPositions[2];
            quadTip.Vertex3 = newPositions[3];
            break;
            case GeometryType.Polygon:
            throw new NotImplementedException();
            default:
            throw new NotDealWithNewEnumItemException(typeof(GeometryType));
            }
        }

        private void UpdateHightlight(PickedGeometry picked) {
            if (picked != null) {
                switch (picked.Type) {
                case GeometryType.Point:
                throw new NotImplementedException();
                case GeometryType.Line:
                throw new NotImplementedException();
                case GeometryType.Triangle:
                triangleTip.Vertex0 = picked.Positions[0];
                triangleTip.Vertex1 = picked.Positions[1];
                triangleTip.Vertex2 = picked.Positions[2];
                triangleTip.Parent = picked.FromObject as SceneNodeBase;
                quadTip.Parent = null;
                break;
                case GeometryType.Quad:
                quadTip.Vertex0 = picked.Positions[0];
                quadTip.Vertex1 = picked.Positions[1];
                quadTip.Vertex2 = picked.Positions[2];
                quadTip.Vertex3 = picked.Positions[3];
                quadTip.Parent = picked.FromObject as SceneNodeBase;
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

        void manipulater_Rotated(object sender, ArcBallManipulater.Rotation e) {
            SceneNodeBase node = this.scene.RootNode;
            node.RotationAngle = e.angleInDegree;
            node.RotationAxis = e.axis;
        }

        public override void reshape(GL gl, int width, int height) {
            this.scene.camera.AspectRatio = ((float)this.canvas.Width) / ((float)this.canvas.Height);

        }
    }
}
