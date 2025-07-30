using CSharpGL;
using demos.OpenGLviaCSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c12d02_SlicingSituations {
    internal unsafe class c12d02_SlicingSituations_ : demoCode {
        public c12d02_SlicingSituations_(FormInstance mainForm, WindowsGLCanvas canvas) : base(mainForm, canvas) { }
        private Scene scene;
        private ActionList actionList;
        private SceneNodeBase rootNode;
        private SliceNode sliceNode;

        const float precision = 0.1f;
        private IntersectionNode intersectionNode;

        public override void display(GL gl) {
            ActionList list = this.actionList;
            if (list != null) {
                vec4 clearColor = this.scene.clearColor;
                gl.glClearColor(clearColor.x, clearColor.y, clearColor.z, clearColor.w);
                gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);

                Viewport viewport = Viewport.GetCurrent();
                list.Act(new ActionParams(viewport));
            }
        }

        public override void init(GL gl) {
            var position = new vec3(5, 3, 4) * 0.6f;
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Ortho, this.canvas.Width, this.canvas.Height);
            var scene = new Scene(camera);
            var rootNode = GetRootNode();
            scene.RootNode = rootNode;
            this.scene = scene;
            this.rootNode = rootNode;

            var list = new ActionList();
            var transformAction = new TransformAction(scene);
            list.Add(transformAction);
            var renderAction = new RenderAction(scene);
            list.Add(renderAction);
            this.actionList = list;

            // Enable manipualter of camera!
            var manipulater = new FirstPerspectiveManipulater();
            manipulater.StepLength *= 0.1f;
            manipulater.BindingMouseButtons = GLMouseButtons.Left | GLMouseButtons.Right;
            manipulater.Bind(camera, this.canvas);

            {
                this.intersectionNode.SetSlicePlane(this.currentX, this.currentY, this.currentZ);
                this.sliceNode.SetX(this.currentX);
                this.sliceNode.SetY(this.currentY);
                this.sliceNode.SetZ(this.currentZ);
            }
            this.canvas.KeyDown += Canvas_KeyDown;

            var builder = new StringBuilder();
            builder.AppendLine("Z/X: +/- in Z axis");
            builder.AppendLine("C/V: +/- in Y axis");
            builder.AppendLine("B/N: +/- in X axis");
            MessageBox.Show(builder.ToString());
        }


        private float currentX = 2.5f;
        private float currentY = 2.5f;
        private float currentZ = 2.5f;

        private void Canvas_KeyDown(object? sender, KeyEventArgs e) {
            var updated = false;
            switch (e.KeyData) {
            case Keys.Z:
            this.currentZ += precision; updated = true;
            break;
            case Keys.X:
            this.currentZ -= precision; updated = true;
            break;
            case Keys.C:
            this.currentY += precision; updated = true;
            break;
            case Keys.V:
            this.currentY -= precision; updated = true;
            break;
            case Keys.B:
            this.currentX += precision; updated = true;
            break;
            case Keys.N:
            this.currentX -= precision; updated = true;
            break;
            default: break;
            }

            if (updated) {
                this.intersectionNode.SetSlicePlane(this.currentX, this.currentY, this.currentZ);
                this.sliceNode.SetX(this.currentX);
                this.sliceNode.SetY(this.currentY);
                this.sliceNode.SetZ(this.currentZ);
            }
        }

        private SceneNodeBase GetRootNode() {
            var rootNode = new GroupNode();
            {
                var node = CubeNode.Create();
                node.WorldPosition = new vec3(1, 1, 1) * 0.5f;
                node.Scale = new vec3(1, 1, 1) * 0.5f;
                rootNode.Children.Add(node);
            }
            {
                var node = SliceNode.Create();
                //node.Scale = new vec3(1, 1, 1) * 5;
                //rootNode.Children.Add(node);
                this.sliceNode = node;
            }
            {
                var node = IntersectionNode.Create();
                //node.Scale = new vec3(1, 1, 1) * 5;
                rootNode.Children.Add(node);
                this.intersectionNode = node;
            }
            //{
            //    var node = GroundNode.Create();
            //    node.Scale = new vec3(1, 1, 1) * 5;
            //    node.Color = Color.Yellow.ToVec4();
            //    rootNode.Children.Add(node);
            //}

            return rootNode;
        }

        public override void reshape(GL gl, int width, int height) {
            this.scene.camera.AspectRatio = ((float)this.canvas.Width) / ((float)this.canvas.Height);

        }
    }
}
