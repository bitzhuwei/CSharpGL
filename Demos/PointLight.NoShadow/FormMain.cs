using CSharpGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PointLight.NoShadow
{
    public partial class FormMain : Form
    {
        private Scene scene;
        private ActionList actionList;

        public FormMain()
        {
            InitializeComponent();

            this.Load += FormMain_Load;
            this.winGLCanvas1.OpenGLDraw += winGLCanvas1_OpenGLDraw;
            this.winGLCanvas1.Resize += winGLCanvas1_Resize;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            var position = new vec3(1, 0.6f, 1) * 16;
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspecitive, this.winGLCanvas1.Width, this.winGLCanvas1.Height);
            this.scene = new Scene(camera);
            this.scene.RootNode = GetRootNode();
            {
                var light = new CSharpGL.PointLight(new vec3(3, 3, 3));
                this.scene.Lights.Add(light);
                var node = LightPositionNode.Create();
                node.SetLight(light);
                this.scene.RootNode.Children.Add(node);
            }

            var list = new ActionList();
            var transformAction = new TransformAction(scene.RootNode);
            list.Add(transformAction);
            var blinnPhongAction = new BlinnPhongAction(scene);
            list.Add(blinnPhongAction);
            var renderAction = new RenderAction(scene);
            list.Add(renderAction);
            this.actionList = list;

            Match(this.trvScene, scene.RootNode);
            this.trvScene.ExpandAll();

            var manipulater = new FirstPerspectiveManipulater();
            manipulater.Bind(camera, this.winGLCanvas1);
        }

        private void Match(TreeView treeView, SceneNodeBase nodeBase)
        {
            treeView.Nodes.Clear();
            var node = new TreeNode(nodeBase.ToString()) { Tag = nodeBase };
            treeView.Nodes.Add(node);
            Match(node, nodeBase);
        }

        private void Match(TreeNode node, SceneNodeBase nodeBase)
        {
            foreach (var item in nodeBase.Children)
            {
                var child = new TreeNode(item.ToString()) { Tag = item };
                node.Nodes.Add(child);
                Match(child, item);
            }
        }

        private SceneNodeBase GetRootNode()
        {
            var group = new GroupNode();
            var filenames = new string[] { "floor.obj", "bunny.obj", };
            for (int i = 0; i < filenames.Length; i++)
            {
                string filename = filenames[i];
                var parser = new ObjVNFParser(true);
                ObjVNFResult result = parser.Parse(filename);
                if (result.Error != null)
                {
                    MessageBox.Show(result.Error.ToString());
                }
                else
                {
                    ObjVNFMesh mesh = result.Mesh;
                    var model = new ObjVNF(mesh);
                    var node = PointLightNoShadowNode.Create(model, ObjVNF.strPosition, ObjVNF.strNormal, model.GetSize());
                    node.WorldPosition = new vec3(0, i * 3, 0);
                    group.Children.Add(node);
                }
            }

            return group;
        }

        private void winGLCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            ActionList list = this.actionList;
            if (list != null)
            {
                vec4 clearColor = this.scene.ClearColor;
                GL.Instance.ClearColor(clearColor.x, clearColor.y, clearColor.z, clearColor.w);
                GL.Instance.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT | GL.GL_STENCIL_BUFFER_BIT);

                list.Act(new ActionParams(Viewport.GetCurrent()));
            }
        }

        void winGLCanvas1_Resize(object sender, EventArgs e)
        {
            this.scene.Camera.AspectRatio = ((float)this.winGLCanvas1.Width) / ((float)this.winGLCanvas1.Height);
        }


        private void trvScene_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.propGrid.SelectedObject = e.Node.Tag;
        }
    }
}
