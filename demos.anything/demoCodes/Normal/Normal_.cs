using CSharpGL;
using demos.anything;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Normal {
    internal unsafe class Normal_ : demoCode {
        public Normal_(FormInstance mainForm, WindowsGLCanvas canvas) : base(mainForm, canvas) { }
        private Scene scene;
        private ActionList actionList;
        //private NormalNode node;
        private System.Windows.Forms.ColorDialog colorDialog1 = new ColorDialog();
        private System.Windows.Forms.OpenFileDialog openFileDialog1 = new OpenFileDialog();

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
                node.RotationAngle += 0.1f;
            }

        }

        public override void init(GL gl) {
            this.openFileDialog1.Filter = "*.obj;*.obj_|*.obj;*.obj_";

            var position = new vec3(1, 0.6f, 1) * 14;
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspective, this.canvas.Width, this.canvas.Height);
            this.scene = new Scene(camera)
;

            //string folder = System.Windows.Forms.Application.StartupPath;
            //string objFilename = System.IO.Path.Combine(folder + @"\..\..\..\..\Infrastructure\CSharpGL.Models", "vnfHanoiTower.obj_");
            //string objFilename = "vnfHanoiTower.obj_";
            string objFilename = "vnfannulus.obj_";
            var parser = new ObjVNFParser(true);
            ObjVNFResult result = parser.Parse(objFilename);
            if (result.Error != null) {
                MessageBox.Show(result.Error.ToString());
            }
            else {
                var model = new ObjVNF(result.Mesh);
                var node = NormalNode.Create(model, ObjVNF.strPosition, ObjVNF.strNormal, model.GetSize());
                float max = node.ModelSize.max();
                node.Scale *= 16.0f / max;
                this.scene.RootNode = node;
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

            var builder = new StringBuilder();
            builder.AppendLine($"M: diffuse color");
            builder.AppendLine($"V: vertex  color");
            builder.AppendLine($"P: point   color");
            builder.AppendLine($"Z: render model");
            builder.AppendLine($"N: render normal");
            builder.AppendLine($"F: open file");
            MessageBox.Show(builder.ToString());

        }

        private void Canvas_GLKeyDown(object sender, GLKeyEventArgs e) {
            if (e.KeyData == GLKeys.M) {
                if (this.colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                    Color color = this.colorDialog1.Color;
                    var node = this.scene.RootNode as NormalNode;
                    if (node != null) {
                        node.DiffuseColor = color.ToVec3();
                        //this.lblModelColor.BackColor = color;
                    }
                }
            }
            else if (e.KeyData == GLKeys.V) {
                if (this.colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                    Color color = this.colorDialog1.Color;
                    var node = this.scene.RootNode as NormalNode;
                    if (node != null) {
                        node.VertexColor = color.ToVec3();
                        //this.lblVertexColor.BackColor = color;
                    }
                }
            }
            else if (e.KeyData == GLKeys.P) {
                if (this.colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                    Color color = this.colorDialog1.Color;
                    var node = this.scene.RootNode as NormalNode;
                    if (node != null) {
                        node.PointerColor = color.ToVec3();
                        //this.lblPointerColor.BackColor = color;
                    }
                }
            }
            else if (e.KeyData == GLKeys.Z) {
                var node = this.scene.RootNode as NormalNode;
                if (node != null) {
                    node.RenderModel = !node.RenderModel;
                }
            }
            else if (e.KeyData == GLKeys.N) {
                var node = this.scene.RootNode as NormalNode;
                if (node != null) {
                    node.RenderNormal = !node.RenderNormal;
                }
            }
            else if (e.KeyData == GLKeys.F) {
                if (this.openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                    string filename = this.openFileDialog1.FileName;
                    //
                    var parser = new ObjVNFParser(true);
                    ObjVNFResult result = parser.Parse(filename);
                    if (result.Error != null) {
                        MessageBox.Show(result.Error.ToString());
                    }
                    else {
                        var model = new ObjVNF(result.Mesh);
                        var node = NormalNode.Create(model, ObjVNF.strPosition, ObjVNF.strNormal, model.GetSize());
                        float max = node.ModelSize.max();
                        node.Scale *= 16.0f / max;
                        node.WorldPosition = new vec3(0, 0, 0);

                        var rootElement = this.scene.RootNode;
                        this.scene.RootNode = node;
                        if (rootElement != null) { rootElement.Dispose(); }
                    }
                }

            }
        }

        public override void reshape(GL gl, int width, int height) {
            this.scene.camera.AspectRatio = ((float)this.canvas.Width) / ((float)this.canvas.Height);

        }
    }
}
