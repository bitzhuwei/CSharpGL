using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CSharpGL;

namespace StencilShadowVolume
{
    public partial class Form2ShadowVolume : Form
    {
        private Scene scene;
        private ActionList actionList;

        public Form2ShadowVolume()
        {
            InitializeComponent();

            this.Load += FormMain_Load;
            this.winGLCanvas1.OpenGLDraw += winGLCanvas1_OpenGLDraw;
            this.winGLCanvas1.Resize += winGLCanvas1_Resize;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            var rootElement = GetTree();

            var position = new vec3(5, 3, 4);
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspecitive, this.winGLCanvas1.Width, this.winGLCanvas1.Height);
            this.scene = new Scene(camera)
            {
                RootElement = rootElement,
                ClearColor = Color.SkyBlue.ToVec4(),
            };
            this.scene.Lights.Add(new PointLight(new vec3(0, 10, 0)));

            var list = new ActionList();
            var transformAction = new TransformAction(scene);
            list.Add(transformAction);
            var shadowVolumeAction = new ShadowVolumeAction(scene);
            list.Add(shadowVolumeAction);
            this.actionList = list;

            Match(this.trvScene, scene.RootElement);
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

        private SceneNodeBase GetTree()
        {
            var node1 = ShadowVolumeNode.Create();

            var node2 = ShadowVolumeNode.Create();
            node2.WorldPosition = new vec3(1, -1, 0) * 3;

            var node3 = ShadowVolumeNode.Create();
            node3.WorldPosition = new vec3(-1, -1, 0) * 3;

            var group = new GroupNode(node1, node2, node3);

            return group;
        }

        private void winGLCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            ActionList list = this.actionList;
            if (list != null)
            {
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

            this.lblState.Text = string.Format("{0} objects selected.", 1);
        }
    }

}
