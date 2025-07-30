using CSharpGL;
using demos.anything;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicOperation {
    internal unsafe class LogicOperation_ : demoCode {
        public LogicOperation_(FormInstance mainForm, WindowsGLCanvas canvas) : base(mainForm, canvas) { }
        Scene scene;
        private ActionList actionList;
        private Picking pickingAction;

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

            var position = new vec3(4, 3, 5) * 0.5f;
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspective, this.canvas.Width, this.canvas.Height);
            this.scene = new Scene(camera) {
                RootNode = rootElement,
                clearColor = Color.SkyBlue.ToVec4(),
            };

            var tansformAction = new TransformAction(scene);
            var renderAction = new RenderAction(scene);
            var actionList = new ActionList();
            actionList.Add(tansformAction); actionList.Add(renderAction);
            this.actionList = actionList;

            this.pickingAction = new Picking(scene);

            var manipulater = new FirstPerspectiveManipulater();
            manipulater.Bind(camera, this.canvas);

            var values = Enum.GetValues(typeof(LogicOperationCode));
            this.logicOperations = new LogicOperationCode[values.Length];
            int index = 0;
            foreach (var value in values) {
                this.logicOperations[index++] = (LogicOperationCode)value;
            }

            this.canvas.GLKeyDown += Canvas_GLKeyDown;
            this.canvas.GLMouseMove += Canvas_GLMouseMove;
        }

        int currentCode = 0;
        LogicOperationCode[] logicOperations;
        private void Canvas_GLKeyDown(object sender, GLKeyEventArgs e) {
            if (e.KeyData == GLKeys.L) {
                this.currentCode++;
                if (this.currentCode >= this.logicOperations.Length) {
                    this.currentCode = 0;
                }
                if (this.scene != null) {
                    var op = this.logicOperations[this.currentCode];
                    TraverseNodes(this.scene.RootNode, op);
                }
            }
        }

        private void TraverseNodes(SceneNodeBase sceneNodeBase, LogicOperationCode op) {
            var node = sceneNodeBase as LogicOperationNode;
            if (node != null) {
                node.SetOperation(op);
            }

            foreach (var item in sceneNodeBase.Children) {
                TraverseNodes(item, op);
            }
        }

        IPickable? lastPickedNode;
        private void Canvas_GLMouseMove(object sender, GLMouseEventArgs e) {
            int x = e.X;
            int y = this.canvas.Height - e.Y - 1;
            if (x < 0 || this.canvas.Width <= x) { return; }
            if (y < 0 || this.canvas.Height <= y) { return; }

            var pickedGeometry = this.pickingAction.Pick(x, y, PickingGeometryTypes.Triangle | PickingGeometryTypes.Quad, this.canvas.Width, this.canvas.Height);

            var lastNode = this.lastPickedNode as LogicOperationNode;

            this.lastPickedNode = null;// we will pick again.

            LogicOperationNode? currentNode = null;
            if (pickedGeometry != null) {
                currentNode = pickedGeometry.FromObject as LogicOperationNode;
            }

            if (lastNode != currentNode) {
                if (lastNode != null) { lastNode.LogicOp = false; }

                if (currentNode != null) { currentNode.LogicOp = true; }
            }

            this.lastPickedNode = currentNode;
            this.mainForm.SetInfo($"picked: {this.lastPickedNode}");

        }

        private SceneNodeBase GetRootElement() {
            //string folder = System.Windows.Forms.Application.StartupPath;
            //var bitmap = new Bitmap(System.IO.Path.Combine(folder, @"flower.png"));
            var bitmap = new Bitmap("media/textures/flower.png");
            bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);
            var winGLBitmap = new WinGLBitmap(bitmap);
            var texture = new Texture(new TexImageBitmap(winGLBitmap));
            texture.builtInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_REPEAT));
            texture.builtInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_REPEAT));
            texture.builtInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_REPEAT));
            texture.builtInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR));
            texture.builtInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR));
            texture.Initialize();
            bitmap.Dispose();

            var group = new GroupNode();
            for (int x = 0; x < 3; x++) {
                for (int z = 0; z < 3; z++) {
                    var outlineCubeNode = LogicOperationNode.Create(texture);
                    outlineCubeNode.Scale = new vec3(1, 1, 1) * 0.6f;
                    outlineCubeNode.WorldPosition = new vec3(x - 1, 0, z - 1);
                    group.Children.Add(outlineCubeNode);
                }
            }
            return group;
        }

        public override void reshape(GL gl, int width, int height) {
            this.scene.camera.AspectRatio = ((float)this.canvas.Width) / ((float)this.canvas.Height);

        }
    }
}
