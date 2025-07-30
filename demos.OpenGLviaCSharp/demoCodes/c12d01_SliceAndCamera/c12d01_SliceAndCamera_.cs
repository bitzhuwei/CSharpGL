using CSharpGL;
using demos.OpenGLviaCSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c12d01_SliceAndCamera {
    internal unsafe class c12d01_SliceAndCamera_ : demoCode {
        public c12d01_SliceAndCamera_(FormInstance mainForm, WindowsGLCanvas canvas) : base(mainForm, canvas) { }
        private Scene scene;
        private ActionList actionList;
        private SceneNodeBase rootNode;

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
            var position = new vec3(5, 3, 4);
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspective, this.canvas.Width, this.canvas.Height);
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
        }

        private SceneNodeBase GetRootNode() {
            var rootNode = new GroupNode();
            {
                var axisNode = AxisNode.Create();
                axisNode.Scale = new vec3(1, 1, 1) * 0.2f;
                rootNode.Children.Add(axisNode);
            }
            {
                var cameraNode = CameraNode.Create();
                cameraNode.Scale = new vec3(1, 1, 1) * 0.2f;
                rootNode.Children.Add(cameraNode);
            }
            {
                //var cameraOutlineNode = CameraOutlineNode.Create();
                //rootNode.Children.Add(cameraOutlineNode);
            }
            {
                var cubeNode = CubeNode.Create();
                cubeNode.WorldPosition = new vec3(0, 0, -5);
                cubeNode.RotationAxis = new vec3(1, 1, 1);
                cubeNode.RotationAngle = 17;

                rootNode.Children.Add(cubeNode);
            }
            {
                //var miniGroup = new SwitchListGroupNode();
                {
                    var rectNode = RectNode.Create();
                    rectNode.WorldPosition = new vec3(0, 0, -5);
                    rectNode.Scale = new vec3(1, 1, 1) * 3;

                    rootNode.Children.Add(rectNode);
                }
                {
                    var perspectiveNode = PerspectiveNode.Create();
                    rootNode.Children.Add(perspectiveNode);
                }
                //miniGroup.SwitchList.Add(new BlendSwitch(BlendEquationMode.Add, BlendSrcFactor.SrcAlpha, BlendDestFactor.OneMinusSrcAlpha));
                //rootNode.Children.Add(miniGroup);
            }
            {
                var groundNode = GroundNode.Create();
                //rootNode.Children.Add(groundNode);
            }

            return rootNode;
        }
        public override void reshape(GL gl, int width, int height) {
            this.scene.camera.AspectRatio = ((float)this.canvas.Width) / ((float)this.canvas.Height);

        }
    }
}
