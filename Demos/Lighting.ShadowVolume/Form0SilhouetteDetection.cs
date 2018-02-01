using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CSharpGL;

namespace Lighting.ShadowVolume
{
    public partial class Form0SilhouetteDetection : Form
    {
        private Scene scene;
        private ActionList actionList;
        private ModelInfo modelInfo;

        public Form0SilhouetteDetection(ModelInfo modelInfo)
        {
            InitializeComponent();

            this.modelInfo = modelInfo;

            this.Load += FormMain_Load;
            this.winGLCanvas1.OpenGLDraw += winGLCanvas1_OpenGLDraw;
            this.winGLCanvas1.Resize += winGLCanvas1_Resize;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            var rootElement = GetTree();

            var position = new vec3(5, 3, 4) * 3;
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
            var group = new GroupNode();

            var light = new PointLight(new vec3());

            {
                var node = SilhouetteNode.Create(this.modelInfo.modelProvider.Model,
                    this.modelInfo.position,
                    this.modelInfo.normal,
                    this.modelInfo.size);
                node.WorldPosition = new vec3(0, this.modelInfo.size.y / 2 + 0.2f, 0);
                node.SetLight(light);
                group.Children.Add(node);
            }

            {
                var model = new AdjacentCubeModel(new vec3(100, 1, 100));
                var floor = SilhouetteNode.Create(model, AdjacentCubeModel.strPosition, AdjacentCubeModel.strColor, model.GetSize());
                floor.SetLight(light);
                floor.WorldPosition = new vec3(0, -0.5f, 0);
                group.Children.Add(floor);
            }

            {
                var lightPositionNode = LightPositionNode.Create();
                lightPositionNode.SetLight(light);
                group.Children.Add(lightPositionNode);
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
    }

}
