using CSharpGL;
using demos.anything;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaderDefineClipPlane {
    internal unsafe class ShaderDefineClipPlane_ : demoCode {
        public ShaderDefineClipPlane_(FormInstance mainForm, WindowsGLCanvas canvas) : base(mainForm, canvas) { }
        private Scene scene;
        private ActionList actionList;
        private ClippedCubeNode clippedCube;
        private TransparentPlaneNode transparentPlane;

        private Picking pickingAction;
        private LegacyTriangleNode triangleTip;
        private LegacyQuadNode quadTip;
        private List<SceneNodeBase> tipList = new List<SceneNodeBase>();

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
            var rootElement = GetRootElement();

            var position = new vec3(-3, 3, 4) * 0.5f;
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspective, this.canvas.Width, this.canvas.Height);
            this.scene = new Scene(camera) {
                RootNode = rootElement,
                clearColor = Color.SkyBlue.ToVec4(),
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
            this.tipList.Add(this.triangleTip);
            this.tipList.Add(this.quadTip);

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
                // move vertex
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
                    this.UpdateClipPlane(newPositions[0], newPositions[1], newPositions[2]);
                }
            }
            else {
                int x = e.X;
                int y = this.canvas.Height - e.Y - 1;
                this.pickedGeometry = this.pickingAction.Pick(x, y, GeometryType.Triangle, this.canvas.Width, this.canvas.Height);

                if (this.pickedGeometry != null) {
                    var text = string.Format("picked: {0}", this.pickedGeometry.FromObject);
                }
                else {
                    var text = string.Format("picked: nothing");
                }

                this.UpdateHightlight();
            }

            this.lastMousePosition = e.Location;

        }
        private void UpdateClipPlane(vec3 a, vec3 b, vec3 c) {
            vec3 ab = b - a, ac = c - a;
            vec3 normal = ac.cross(ab);
            float A = normal.x, B = normal.y, C = normal.z;
            float D1 = -normal.dot(a);
            float D2 = -normal.dot(b);
            float D3 = -normal.dot(c);
            float D = (D1 + D2 + D3) / 3.0f;

            this.clippedCube.ClipPlane = new vec4(A, B, C, D);
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
        private Color GetColorAtMouse(int x, int y) {
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

        private SceneNodeBase GetRootElement() {
            //string folder = System.Windows.Forms.Application.StartupPath;
            //var bmp = new Bitmap(System.IO.Path.Combine(folder, @"Crate.bmp"));
            var bmp = new Bitmap("media/textures/Crate.bmp");
            var winGLBitmap = new WinGLBitmap(bmp, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            TexStorageBase storage = new TexImageBitmap(winGLBitmap);
            var texture = new Texture(storage);
            texture.builtInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_CLAMP_TO_EDGE));
            texture.builtInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_CLAMP_TO_EDGE));
            texture.builtInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_CLAMP_TO_EDGE));
            texture.builtInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR));
            texture.builtInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR));
            texture.Initialize();
            texture.textureUnitIndex = 0;
            bmp.Dispose();

            this.clippedCube = ClippedCubeNode.Create(texture);
            this.transparentPlane = TransparentPlaneNode.Create();
            transparentPlane.Scale = new vec3(1, 1, 1);
            transparentPlane.WorldPosition = new vec3(0, -0.1f, 0);
            var group = new GroupNode(clippedCube, transparentPlane);

            return group;
        }

        public override void reshape(GL gl, int width, int height) {
            if (this.scene != null) {
                this.scene.camera.AspectRatio = ((float)this.canvas.Width) / ((float)this.canvas.Height);
            }
        }
    }
}
