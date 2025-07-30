using CSharpGL;
using demos.anything;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolumeRendering.Slicing {
    internal unsafe class VolumeRendering_Slicing_ : demoCode {
        public VolumeRendering_Slicing_(FormInstance mainForm, WindowsGLCanvas canvas) : base(mainForm, canvas) { }
        private Scene scene;
        private ActionList actionList;

        public override void display(GL gl) {
            ActionList list = this.actionList;
            if (list != null) {
                vec4 clearColor = this.scene.clearColor;
                gl.glClearColor(clearColor.x, clearColor.y, clearColor.z, clearColor.w);
                gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);

                list.Act(new ActionParams(Viewport.GetCurrent()));
            }

            IWorldSpace node = this.scene.RootNode;
            if (node != null) {
                node.RotationAngle += 1.3f;
            }

        }

        public override void init(GL gl) {
            var rootElement = GetTree();

            var position = new vec3(5, 3, 4) * 0.2f;
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

            //Match(this.trvScene, scene.RootNode);
            //this.trvScene.ExpandAll();
            (new FormNodePropertyGrid(scene.RootNode)).Show();

            var manipulater = new FirstPerspectiveManipulater();
            manipulater.StepLength = 0.1f;
            manipulater.Bind(camera, this.canvas);

        }
        private SceneNodeBase GetTree() {
            var node = SlicesNode.Create();
            return node;
            //var group = new GroupNode();

            //return group;
        }

        public override void reshape(GL gl, int width, int height) {
            this.scene.camera.AspectRatio = ((float)this.canvas.Width) / ((float)this.canvas.Height);

        }
    }
}
