using CSharpGL;
using demos.OpenGLviaCSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c14d02_DoubleTransformFeedbakObjects {
    internal unsafe class c14d02_DoubleTransformFeedbakObjects_ : demoCode {
        public c14d02_DoubleTransformFeedbakObjects_(FormInstance mainForm, WindowsGLCanvas canvas) : base(mainForm, canvas) { }
        private Scene scene;
        private ActionList actionList;

        public override void display(GL gl) {
            ActionList list = this.actionList;
            if (list != null) {
                vec4 clearColor = this.scene.clearColor;
                gl.glClearColor(clearColor.x, clearColor.y, clearColor.z, clearColor.w);
                gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);

                var p = new ActionParams(Viewport.GetCurrent());
                list.Act(p);
            }

        }

        public override void init(GL gl) {
            var position = new vec3(5, 3, 4) * 0.2f;
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspective, this.canvas.Width, this.canvas.Height);

            this.scene = new Scene(camera);
            this.scene.clearColor = Color.Black.ToVec4();
            {
                var node = DemoNode.Create();
                //node.EnableRendering = ThreeFlags.None;
                var ground = GroundNode.Create();
                ground.RenderUnit.Methods[0].SwitchList.Add(new PolygonModeSwitch(PolygonMode.Line));
                //ground.EnableRendering = ThreeFlags.None;
                var group = new GroupNode(node, ground);
                //var group = new GroupNode(ground);
                this.scene.RootNode = group;
            }

            var list = new ActionList();
            var transformAction = new TransformAction(scene);
            list.Add(transformAction);
            var renderAction = new RenderAction(scene);
            list.Add(renderAction);
            this.actionList = list;

            var manipulater = new FirstPerspectiveManipulater();
            manipulater.Bind(camera, this.canvas);

        }

        public override void reshape(GL gl, int width, int height) {
            this.scene.camera.AspectRatio = ((float)this.canvas.Width) / ((float)this.canvas.Height);

        }
    }
}
