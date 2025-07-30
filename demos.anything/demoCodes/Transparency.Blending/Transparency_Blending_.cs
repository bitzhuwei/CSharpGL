using CSharpGL;
using demos.anything;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transparency.Blending {
    internal unsafe class Transparency_Blending_ : demoCode {
        public Transparency_Blending_(FormInstance mainForm, WindowsGLCanvas canvas) : base(mainForm, canvas) { }
        private Scene scene;
        private ActionList actionList;

        private BlendSrcFactor initialSF;
        private BlendDestFactor initialDF;
        private BlendFactorHelper helper = new BlendFactorHelper();


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
            var rootElement = GetTree();

            var position = new vec3(1, 1, 4);
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

            var m = new FirstPerspectiveManipulater();
            m.Bind(camera, this.canvas);

            BlendSrcFactor sf; BlendDestFactor df;
            helper.GetNext(out sf, out df);
            initialSF = sf; initialDF = df;
            this.canvas.GLKeyDown += Canvas_GLKeyDown;

            MessageBox.Show("B: enumerate blend factors");

        }
        private SceneNodeBase GetTree() {
            var group = new GroupNode();
            //{
            //    var cube = CubeNode.Create();
            //    cube.Color = new vec4(0, 1, 0, 0.3f);
            //    group.Children.Add(cube);
            //}
            const float alpha = 0.5f;
            {
                var glass = RectGlassNode.Create(4, 3);
                glass.WorldPosition = new vec3(-1, 0, 0);
                glass.Color = new vec4(0, 1, 0, alpha);
                glass.name = "Green Glass";
                group.Children.Add(glass);
            }
            {
                var glass = RectGlassNode.Create(4, 3);
                glass.WorldPosition = new vec3(1, 0, 1);
                glass.Color = new vec4(1, 0, 0, alpha);
                glass.name = "Red Glass";
                group.Children.Add(glass);
            }

            return group;
        }

        private void Canvas_GLKeyDown(object sender, GLKeyEventArgs e) {
            if (e.KeyData == GLKeys.B) {
                BlendSrcFactor sf; BlendDestFactor df;
                helper.GetNext(out sf, out df);
                if (initialSF == sf && initialDF == df) { MessageBox.Show("Round up"); }

                SetupBlending(this.scene.RootNode, sf, df);
                this.mainForm.SetInfo(string.Format("sf:{0}, df:{1}", sf, df));
            }
        }

        private void SetupBlending(SceneNodeBase sceneNodeBase, BlendSrcFactor sf, BlendDestFactor df) {
            var node = sceneNodeBase as RectGlassNode;
            if (node != null) {
                node.Blend.SourceFactor = sf;
                node.Blend.DestFactor = df;
            }

            foreach (var item in sceneNodeBase.Children) {
                SetupBlending(item, sf, df);
            }
        }


        public override void reshape(GL gl, int width, int height) {
            this.scene.camera.AspectRatio = ((float)this.canvas.Width) / ((float)this.canvas.Height);

        }
    }
}
