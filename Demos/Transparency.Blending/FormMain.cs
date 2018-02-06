using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CSharpGL;

namespace Transparency.Blending
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
            var rootElement = GetTree();

            var position = new vec3(1, 1, 4);
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspecitive, this.winGLCanvas1.Width, this.winGLCanvas1.Height);
            this.scene = new Scene(camera)
            {
                RootNode = rootElement,
                ClearColor = Color.SkyBlue.ToVec4(),
            };

            var list = new ActionList();
            var transformAction = new TransformAction(scene.RootNode);
            list.Add(transformAction);
            var renderAction = new RenderAction(scene);
            list.Add(renderAction);
            this.actionList = list;

            Match(this.trvScene, scene.RootNode);
            this.trvScene.ExpandAll();
            var m = new FirstPerspectiveManipulater();
            m.Bind(camera, this.winGLCanvas1);

            BlendingSourceFactor sf; BlendingDestinationFactor df;
            helper.GetNext(out sf, out df);
            initialSF = sf; initialDF = df;
            this.winGLCanvas1.KeyPress += winGLCanvas1_KeyPress;
        }

        private BlendingSourceFactor initialSF;
        private BlendingDestinationFactor initialDF;
        private BlendFactorHelper helper = new BlendFactorHelper();
        void winGLCanvas1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'b')
            {
                BlendingSourceFactor sf; BlendingDestinationFactor df;
                helper.GetNext(out sf, out df);
                if (initialSF == sf && initialDF == df) { MessageBox.Show("Round up"); }

                SetupBlending(this.scene.RootNode, sf, df);
                this.lblState.Text = string.Format("sf:{0}, df:{1}", sf, df);
            }
        }

        private void SetupBlending(SceneNodeBase sceneNodeBase, BlendingSourceFactor sf, BlendingDestinationFactor df)
        {
            var node = sceneNodeBase as RectGlassNode;
            if (node != null)
            {
                node.Blend.SourceFactor = sf;
                node.Blend.DestFactor = df;
            }

            foreach (var item in sceneNodeBase.Children)
            {
                SetupBlending(item, sf, df);
            }
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
                glass.Name = "Green Glass";
                group.Children.Add(glass);
            }
            {
                var glass = RectGlassNode.Create(4, 3);
                glass.WorldPosition = new vec3(1, 0, 1);
                glass.Color = new vec4(1, 0, 0, alpha);
                glass.Name = "Red Glass";
                group.Children.Add(glass);
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

            this.lblState.Text = string.Format("{0} objects selected.", 1);
        }

        private void lblState_Click(object sender, EventArgs e)
        {
            var frm = new FormBlendFunc();
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var sf = frm.SelectedSourceFactor;
                var df = frm.SelectedDestinationFactor;
                SetupBlending(this.scene.RootNode, sf, df);
                this.lblState.Text = string.Format("sf:{0}, df:{1}", sf, df);
            }
        }
    }
}
