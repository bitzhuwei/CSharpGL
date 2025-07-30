using CSharpGL;
using demos.anything;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointLight {
    internal unsafe class PointLight_ : demoCode {
        public PointLight_(FormInstance mainForm, WindowsGLCanvas canvas) : base(mainForm, canvas) { }
        private Scene scene;
        private ActionList actionList;
        private PointLightNode node;
        private LightPositionNode lightNode;
        private System.Windows.Forms.ColorDialog colorDialog1 = new ColorDialog();

        public override void display(GL gl) {
            ActionList list = this.actionList;
            if (list != null) {
                vec4 clearColor = this.scene.clearColor;
                gl.glClearColor(clearColor.x, clearColor.y, clearColor.z, clearColor.w);
                gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);

                list.Act(new ActionParams(Viewport.GetCurrent()));
            }

            IWorldSpace node = this.node;
            if (node != null) {
                node.RotationAngle += 0.1f;
            }

        }

        public override void init(GL gl) {
            var position = new vec3(1, 0.6f, 1) * 14;
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspective, this.canvas.Width, this.canvas.Height);
            this.scene = new Scene(camera)
;

            string folder = System.Windows.Forms.Application.StartupPath;
            string objFilename = "vnfHanoiTower.obj_";
            var parser = new ObjVNFParser(false);
            ObjVNFResult result = parser.Parse(objFilename);
            if (result.Error != null) {
                MessageBox.Show(result.Error.ToString());
            }
            else {
                var light = new CSharpGL.PointLight(new vec3(1, 1, 1));
                var model = new ObjVNF(result.Mesh);
                this.node = PointLightNode.Create(light, model, ObjVNF.strPosition, ObjVNF.strNormal, model.GetSize());
                float max = node.ModelSize.max();
                this.node.Scale *= 16.0f / max;
                this.lightNode = LightPositionNode.Create();
                lightNode.SetLight(light);
                lightNode.WorldPosition = new vec3(1, 1, 1) * 4;
                var groupNode = new GroupNode(node, lightNode);
                this.scene.RootNode = groupNode;
                (new FormNodePropertyGrid(groupNode)).Show();
            }

            var list = new ActionList();
            var transformAction = new TransformAction(scene);
            list.Add(transformAction);
            var renderAction = new RenderAction(scene);
            list.Add(renderAction);
            this.actionList = list;

            var manipulater = new FirstPerspectiveManipulater();
            manipulater.Bind(camera, this.canvas);

            this.canvas.GLKeyDown += Canvas_GLKeyDown;
        }

        private void Canvas_GLKeyDown(object sender, GLKeyEventArgs e) {
            if (e.KeyData == GLKeys.C) {
                if (this.colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                    Color color = this.colorDialog1.Color;
                    var node = this.node as PointLightNode;
                    if (node != null) {
                        node.DiffuseColor = color.ToVec3();
                        this.mainForm.SetInfo($"{color}");
                        //this.lblColorDisply.BackColor = color;
                    }
                }
            }
            else if (e.KeyData == GLKeys.R) {
                var node = this.lightNode;
                if (node != null) {
                    this.lightNode.AutoRotate = !this.lightNode.AutoRotate;
                }
            }
        }

        public override void reshape(GL gl, int width, int height) {
            this.scene.camera.AspectRatio = ((float)this.canvas.Width) / ((float)this.canvas.Height);

        }
    }
}
