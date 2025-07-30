using CSharpGL;
using demos.OpenGLviaCSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c01d00_Cube {
    internal unsafe class c01d00_Cube_ : demoCode {
        public c01d00_Cube_(FormInstance mainForm, WindowsGLCanvas canvas) : base(mainForm, canvas) { }
        private Scene? scene;
        private ActionList? actionList;
        private CubeNode? cubeNode;

        public override void init(GL gl) {
            var position = new vec3(5, 3, 4) * 0.5f;
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspective, this.canvas.Width, this.canvas.Height);
            var positionBuffer = CubeModel.positions.GenShaderStorageBuffer(GLBuffer.Usage.StaticRead);
            var colorBuffer = CubeModel.colors.GenShaderStorageBuffer(GLBuffer.Usage.StaticDraw);
            this.cubeNode = CubeNode.Create(positionBuffer, colorBuffer, CubeNode.vertexCode, CubeNode.fragmentCode);
            var cubeNode2 = CubeNode.Create(positionBuffer, colorBuffer, CubeNode.vertexCode, CubeNode.fragmentCode);
            cubeNode2.WorldPosition = new vec3(1, 0, 0);
            var scene = new Scene(camera);
            var groupNode = new GroupNode();
            groupNode.Children.Add(cubeNode);
            cubeNode.Children.Add(cubeNode2);
            //groupNode.Children.Add(cubeNode2);
            scene.RootNode = groupNode;
            {
                //var axis = GroundNode.Create();
                //this.cubeNode.Children.Add(axis);
                var axisNode = AxisNode.Create();
                axisNode.Scale = new vec3(1, 1, 1) * 20;
                groupNode.Children.Add(axisNode);

            }
            this.scene = scene;

            var list = new ActionList();
            var transformAction = new TransformAction(scene);
            list.Add(transformAction);
            var renderAction = new RenderAction(scene);
            list.Add(renderAction);
            this.actionList = list;

            // uncomment these lines to enable manipualter of camera!
            var manipulater = new FirstPerspectiveManipulater();
            //manipulater.BindingMouseButtons = GLMouseButtons.Left | GLMouseButtons.Right;//System.Windows.Forms.MouseButtons.Right;
            manipulater.Bind(camera, this.canvas);
        }

        public override void display(GL gl) {
            var list = this.actionList; var scene = this.scene;
            if (list != null && scene != null) {
                vec4 clearColor = scene.clearColor;
                gl.glClearColor(clearColor.x, clearColor.y, clearColor.z, clearColor.w);
                gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);

                Viewport viewport = Viewport.GetCurrent();
                list.Act(new ActionParams(viewport));
            }
        }

        public override void reshape(GL gl, int width, int height) {
            if (this.scene != null) {
                this.scene.camera.AspectRatio = ((float)this.canvas.Width) / ((float)this.canvas.Height);
            }
        }
    }
}
