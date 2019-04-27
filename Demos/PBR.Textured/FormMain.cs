using CSharpGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PBR.Textured {
    public partial class FormMain : Form {
        private Scene scene;
        private ActionList actionList;
        private SceneNodeBase rootNode;

        public FormMain() {
            InitializeComponent();

            this.Load += FormMain_Load;
            this.winGLCanvas1.OpenGLDraw += winGLCanvas1_OpenGLDraw;
            this.winGLCanvas1.Resize += winGLCanvas1_Resize;
        }

        int nrRows = 7;
        int nrColumns = 7;
        float spacing = 2.5f;

        private void FormMain_Load(object sender, EventArgs e) {
            var position = new vec3(-0.2f, 0, 1) * 14;
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspective, this.winGLCanvas1.Width, this.winGLCanvas1.Height);
            this.scene = new Scene(camera);
            var rootNode = new GroupNode();
            this.scene.RootNode = rootNode;
            {
                var sphere = new Sphere(1, 40, 80);
                var filename = Path.Combine(System.Windows.Forms.Application.StartupPath, "sphere.obj_");
                sphere.DumpObjFile(filename, "sphere");
                var parser = new ObjVNFParser(false);
                ObjVNFResult result = parser.Parse(filename);
                if (result.Error != null) {
                    Console.WriteLine("Error: {0}", result.Error);
                }
                else {
                    ObjVNFMesh mesh = result.Mesh;
                    var model = new ObjVNF(mesh);
                    //var node = NormalMappingNode.Create(model, model.GetSize(),
                    //    ObjVNF.strPosition,
                    //    ObjVNF.strTexCoord,
                    //    ObjVNF.strNormal,
                    //    ObjVNF.strTangent);
                    //float max = node.ModelSize.max();
                    //node.Scale *= 16.0f / max;
                    //this.rootNode = node;
                    //this.scene.RootNode = node;
                    //(new FormPropertyGrid(node)).Show();
                    // render rows*column number of spheres with varying metallic/roughness values scaled by rows and columns respectively
                    for (int row = 0; row < nrRows; ++row) {

                        for (int col = 0; col < nrColumns; ++col) {
                            var node = PBRNode.Create(model, model.GetSize(),
                                ObjVNF.strPosition, ObjVNF.strTexCoord, ObjVNF.strNormal, ObjVNF.strTangent);
                            node.Metallic = (float)row / (float)nrRows;
                            // we clamp the roughness to 0.025 - 1.0 as perfectly smooth surfaces (roughness of 0.0) tend to look a bit off
                            // on direct lighting.
                            node.Roughness = glm.clamp((float)col / (float)nrColumns, 0.05f, 1.0f);
                            node.WorldPosition = new vec3(
                                (col - (nrColumns / 2)) * spacing,
                                (row - (nrRows / 2)) * spacing,
                                0.0f);
                            rootNode.Children.Add(node);
                        }
                    }
                }
            }

            var list = new ActionList();
            var transformAction = new TransformAction(scene);
            list.Add(transformAction);
            var renderAction = new RenderAction(scene);
            list.Add(renderAction);
            this.actionList = list;

            var manipulater = new FirstPerspectiveManipulater();
            manipulater.Bind(camera, this.winGLCanvas1);
        }

        private void winGLCanvas1_OpenGLDraw(object sender, PaintEventArgs e) {
            ActionList list = this.actionList;
            if (list != null) {
                vec4 clearColor = this.scene.ClearColor;
                GL.Instance.ClearColor(clearColor.x, clearColor.y, clearColor.z, clearColor.w);
                GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);

                list.Act(new ActionParams(Viewport.GetCurrent()));
            }
        }

        void winGLCanvas1_Resize(object sender, EventArgs e) {
            this.scene.Camera.AspectRatio = ((float)this.winGLCanvas1.Width) / ((float)this.winGLCanvas1.Height);
        }

        private void rdoNormalMapping_CheckedChanged(object sender, EventArgs e) {
            var node = this.rootNode;
            if (node != null) {
                //node.NormalMapping = this.rdoNormalMapping.Checked;
            }
        }
    }
}
