using CSharpGL;
using CSharpGL.Windows;
using demos.anything;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorCodedPicking {
    internal unsafe class ColorCodedPicking_ : demoCode {
        public ColorCodedPicking_(FormInstance mainForm, WindowsGLCanvas canvas) : base(mainForm, canvas) { }

        private Scene scene;
        private TeapotNode teapot;
        private DirectTextNode textNode;
        private ActionList actionList;

        private OperationState operationState = OperationState.PickingDraging;
        private Picking pickingAction;
        private LegacyTriangleNode triangleTip;
        private LegacyQuadNode quadTip;

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

                DirectTextNode node = this.textNode;
                if (node != null) {
                    FontBitmaps.DrawText(node.Position.X, node.Position.Y, node.TextColor, node.FontName, node.FontSize, node.Text);
                }
            }

            if (this.operationState == OperationState.Rotating) {
                IWorldSpace node = this.scene.RootNode;
                if (node != null) {
                    node.RotationAngle += 1;
                }
            }
        }

        public override void init(GL gl) {
            var position = new vec3(5, 3, 4);
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspective, this.canvas.Width, this.canvas.Height);
            this.teapot = TeapotNode.Create(false);
            teapot.Children.Add(new LegacyBoundingBoxNode(teapot.ModelSize));
            var ground = GroundNode.Create(); ground.Color = Color.Gray.ToVec4(); ground.Scale *= 10; ground.WorldPosition = new vec3(0, -3, 0);
            this.textNode = new DirectTextNode() { Text = "Color Coded Picking" };
            var group = new GroupNode(this.teapot, ground, this.textNode);

            this.scene = new Scene(camera) {
                RootNode = group,
            };

            var list = new ActionList();
            var transformAction = new TransformAction(scene);
            list.Add(transformAction);
            var renderAction = new RenderAction(scene);
            list.Add(renderAction);
            this.actionList = list;

            this.pickingAction = new Picking(scene);

            this.triangleTip = new LegacyTriangleNode();
            this.quadTip = new LegacyQuadNode();
            //this.chkRenderWireframe_CheckedChanged(this.chkRenderWireframe, EventArgs.Empty);
            //this.chkRenderBody_CheckedChanged(this.chkRenderBody, EventArgs.Empty);

            this.canvas.GLMouseDown += Canvas_GLMouseDown;
            this.canvas.GLMouseMove += Canvas_GLMouseMove;
            this.canvas.GLMouseUp += Canvas_GLMouseUp;

            this.canvas.GLKeyDown += Canvas_GLKeyDown;

            //// uncomment these lines to enable manipualter of camera!
            //var manipulater = new FirstPerspectiveManipulater();
            //manipulater.BindingMouseButtons = GLMouseButtons.Right;// System.Windows.Forms.MouseButtons.Right;
            //manipulater.Bind(camera, this.canvas);

            var builder = new StringBuilder();
            builder.AppendLine($"R: render wireframe");
            builder.AppendLine($"B: render body");
            builder.AppendLine($"O: Rotating/Draging");
            MessageBox.Show(builder.ToString());
        }

        private void Canvas_GLKeyDown(object sender, GLKeyEventArgs e) {
            if (e.KeyData == GLKeys.R) {
                this.teapot.RenderWireframe = !this.teapot.RenderWireframe;
            }
            else if (e.KeyData == GLKeys.B) {
                this.teapot.RenderBody = !this.teapot.RenderBody;
            }
            else if (e.KeyData == GLKeys.O) {
                if (this.operationState == OperationState.PickingDraging) {
                    this.operationState = OperationState.Rotating;
                }
                else {
                    this.operationState = OperationState.PickingDraging;
                }
            }
        }

        private void Canvas_GLMouseUp(object sender, GLMouseEventArgs e) {
            if (e.Button == GLMouseButtons.Right) {
                //// operate camera
                //rotator.MouseUp(e.X, e.Y);
            }
            else if (e.Button == GLMouseButtons.Left) {
                // move vertex
                if (this.operationState == OperationState.PickingDraging) {
                    this.dragParam = null;
                }
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
                if (this.operationState == OperationState.PickingDraging) {
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
            }
            else {
                int x = e.X;
                int y = this.canvas.Height - e.Y - 1;
                this.pickedGeometry = this.pickingAction.Pick(x, y, PickingGeometryTypes.Triangle | PickingGeometryTypes.Quad, this.canvas.Width, this.canvas.Height);

                if (this.pickedGeometry != null) {
                    var text = string.Format("picked: {0}", this.pickedGeometry.FromObject);
                    this.mainForm.SetInfo(text);
                    this.textNode.Text = text;
                }
                else {
                    var text = string.Format("picked: nothing");
                    this.mainForm.SetInfo(text);
                    this.textNode.Text = text;
                }

                this.UpdateHightlight();
            }

            this.lastMousePosition = e.Location;
        }

        private void Canvas_GLMouseDown(object sender, GLMouseEventArgs e) {
            this.lastMousePosition = e.Location;

            if (this.operationState == OperationState.PickingDraging) {
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
                            viewport);
                        dragParam.pickedVertexIds.AddRange(pickedGeometry.VertexIds);
                        this.dragParam = dragParam;
                    }
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

        private void UpdateHightlight() {
            PickedGeometry picked = this.pickedGeometry;
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

        public override void reshape(GL gl, int width, int height) {
            this.scene.camera.AspectRatio = ((float)this.canvas.Width) / ((float)this.canvas.Height);

        }


        enum OperationState {
            /// <summary>
            /// 
            /// </summary>
            PickingDraging,

            /// <summary>
            /// 
            /// </summary>
            Rotating,
        }
    }

}
