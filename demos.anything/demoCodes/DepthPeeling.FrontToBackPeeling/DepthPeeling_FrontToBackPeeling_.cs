using CSharpGL;
using demos.anything;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepthPeeling.FrontToBackPeeling {
    internal unsafe class DepthPeeling_FrontToBackPeeling_ : demoCode {
        public DepthPeeling_FrontToBackPeeling_(FormInstance mainForm, WindowsGLCanvas canvas) : base(mainForm, canvas) { }
        private Scene scene;
        private ActionList actionList;
        private PeelingNode peelingNode;

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
            var position = new vec3(5, 3, 4) * 1f;
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspective, this.canvas.Width, this.canvas.Height);
            var scene = new Scene(camera);
            var rootElement = GetTree(scene);
            scene.RootNode = rootElement;
            scene.clearColor = Color.SkyBlue.ToVec4();
            this.scene = scene;

            var list = new ActionList();
            var transformAction = new TransformAction(scene);
            list.Add(transformAction);
            var renderAction = new RenderAction(scene);
            list.Add(renderAction);
            this.actionList = list;

            //Match(this.trvScene, scene.RootNode);
            //this.trvScene.ExpandAll();
            (new FormNodePropertyGrid(scene.RootNode)).Show();

            // Note: uncomment this to enable camera movement.
            //var manipulater = new FirstPerspectiveManipulater();
            //manipulater.StepLength = 0.1f;
            //manipulater.Bind(camera, this.canvas);

        }

        private SceneNodeBase GetTree(Scene scene) {
            var children = new List<SceneNodeBase>();
            {
                const float alpha = 0.2f;
                var colors = new vec4[] { new vec4(1, 0, 0, alpha), new vec4(0, 1, 0, alpha), new vec4(0, 0, 1, alpha) };

                for (int k = -1; k < 2; k++) {
                    for (int j = -1; j < 2; j++) {
                        int index = 0;
                        for (int i = -1; i < 2; i++) {
                            vec3 worldSpacePosition = new vec3(i * 2, j * 2, k * 2);
                            var cubeNode = CubeNode.Create(new CubeModel(), CubeModel.positions);
                            cubeNode.WorldPosition = worldSpacePosition;
                            cubeNode.Color = colors[index++];
                            //cubeNode.Name = string.Format("{0},{1},{2}:{3}", k, j, i, cubeNode.Color);

                            children.Add(cubeNode);
                        }
                    }
                }
            }
            this.peelingNode = new PeelingNode(children.ToArray());

            return this.peelingNode;
        }

        public override void reshape(GL gl, int width, int height) {
            this.scene.camera.AspectRatio = ((float)this.canvas.Width) / ((float)this.canvas.Height);

        }

        private CubeNode lastSelected;

        private void trvScene_AfterSelect(object sender, TreeViewEventArgs e) {
            if (lastSelected != null) {
                vec4 color = lastSelected.Color;
                float alpha = color.w;
                lastSelected.Color = new vec4(color.x, color.y, color.z, alpha / 3.0f);
                lastSelected = null;
            }

            var cube = e.Node.Tag as CubeNode;
            if (cube != null) {
                vec4 color = cube.Color;
                float alpha = color.w;
                cube.Color = new vec4(color.x, color.y, color.z, alpha * 3.0f);
                this.lastSelected = cube;
            }

            //this.propGrid.SelectedObject = e.Node.Tag;

            //this.lblState.Text = string.Format("{0} objects selected.", 1);
        }


    }
}
