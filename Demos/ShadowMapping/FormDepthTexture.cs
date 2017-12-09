using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CSharpGL;

namespace ShadowMapping
{
    public partial class FormDepthTexture : Form
    {
        Scene scene;
        private ActionList actionList;

        public FormDepthTexture()
        {
            InitializeComponent();

            this.Load += FormMain_Load;
            this.winGLCanvas1.OpenGLDraw += winGLCanvas1_OpenGLDraw;
            this.winGLCanvas1.Resize += winGLCanvas1_Resize;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            var rootElement = GetRootElement();

            var position = new vec3(0, 0, 1);
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspecitive, this.winGLCanvas1.Width, this.winGLCanvas1.Height);
            this.scene = new Scene(camera, this.winGLCanvas1)
            {
                RootElement = rootElement,
                ClearColor = Color.SkyBlue.ToVec4(),
            };

            Match(this.trvScene, scene.RootElement);
            this.trvScene.ExpandAll();

            var tansformAction = new TransformAction(scene);
            var shadowMappingAction = new ShadowMappingAction(scene);
            var renderAction = new RenderAction(scene);
            var actionList = new ActionList();
            actionList.Add(tansformAction); actionList.Add(shadowMappingAction); actionList.Add(renderAction);
            this.actionList = actionList;
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

        private SceneNodeBase GetRootElement()
        {
            var lightPosition = new vec3(0, 3, 5) * 2;
            var localLight = new SpotLight(lightPosition, new vec3(0, 0, 0), 60, 1, 500) { Color = new vec3(1, 1, 1), };
            var lightContainer = new LightContainerNode(localLight);
            {
                {
                    var teapot = DepthTeapotNode.Create();
                    teapot.RotateSpeed = 1;
                    lightContainer.Children.Add(teapot);
                }
                {
                    var ground = DepthGroundNode.Create();
                    ground.Color = Color.Gray.ToVec4();
                    ground.Scale *= 30;
                    ground.WorldPosition = new vec3(0, -3, 0);
                    lightContainer.Children.Add(ground);
                }
            }

            var rectangle = RectangleNode.Create();
            rectangle.TextureSource = localLight;

            var group = new GroupNode();
            group.Children.Add(lightContainer);
            group.Children.Add(rectangle);

            return group;
        }

        private void winGLCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            this.actionList.Act();
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
