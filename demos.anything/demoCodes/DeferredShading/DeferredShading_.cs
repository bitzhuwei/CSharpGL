using CSharpGL;
using DeferredShading;
using demos.anything;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _______paste_namespace_name_here_________ {
    internal unsafe class DeferredShading_ : demoCode {
        public DeferredShading_(FormInstance mainForm, WindowsGLCanvas canvas) : base(mainForm, canvas) { }
        private Scene scene;
        private ActionList actionList;
        private SceneNodeBase regularNode;
        private SceneNodeBase deferredShadingNode;

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
            var position = new vec3(5, 4, 3) * 20;
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspective, this.canvas.Width, this.canvas.Height);
            this.scene = new Scene(camera)
;
            this.scene.RootNode = GetRootElement();
            var list = new ActionList();
            var transformAction = new TransformAction(scene);
            list.Add(transformAction);
            var renderAction = new RenderAction(scene);
            list.Add(renderAction);
            this.actionList = list;

            var manipulater = new FirstPerspectiveManipulater();
            manipulater.Bind(camera, this.canvas);
            manipulater.StepLength = 1f;

            this.canvas.GLKeyDown += Canvas_GLKeyDown;
            MessageBox.Show("M: deferredShading/regular");
        }

        private void Canvas_GLKeyDown(object sender, GLKeyEventArgs e) {
            if (e.KeyData == GLKeys.M) {
                if (this.scene.RootNode == this.deferredShadingNode) {
                    this.scene.RootNode = this.regularNode;
                }
                else {
                    this.scene.RootNode = this.deferredShadingNode;
                }
            }
        }

        private SceneNodeBase GetRootElement() {
            int lengthX = 50;
            int lengthY = 40;
            int lengthZ = 30;
            float scale = 1.5f;
            var model = new ManyCubesModel((int)(lengthX * scale), (int)(lengthY * scale), (int)(lengthZ * scale));

            var manyCubesNode = ManyCubesNode.Create(model);
            var deferredShadingNode = new DeferredShadingNode();
            deferredShadingNode.Children.Add(manyCubesNode);
            var fullScreenNode = FullScreenNode.Create(deferredShadingNode as ITextureSource);
            var groupNode = new GroupNode(deferredShadingNode, fullScreenNode);

            this.deferredShadingNode = groupNode;

            var manyCubesNode0 = ManyCubesNode0.Create(model);
            this.regularNode = manyCubesNode0;

            return groupNode;
        }

        public override void reshape(GL gl, int width, int height) {
            if (this.scene != null) {
                this.scene.camera.AspectRatio = ((float)this.canvas.Width) / ((float)this.canvas.Height);
            }

        }
    }
}
