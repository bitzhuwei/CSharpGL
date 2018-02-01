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
    public partial class Form2ShadowVolume : Form
    {
        private Scene scene;
        private ActionList actionList;
        private ModelInfo modelInfo;

        public Form2ShadowVolume(ModelInfo modelInfo)
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

            var position = new vec3(5, 3, 4) * 3.3f;
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspecitive, this.winGLCanvas1.Width, this.winGLCanvas1.Height);
            this.scene = new Scene(camera)
            {
                RootNode = rootElement,
                ClearColor = Color.SkyBlue.ToVec4(),
            };
            {
                // add lights.
                var lights = new PointLight[] { 
                    new PointLight(new vec3()) { Diffuse = new vec3(1, 0, 0), Specular = new vec3(1, 0, 0) }, 
                    new PointLight(new vec3()) { Diffuse = new vec3(0, 1, 0), Specular = new vec3(0, 1, 0) }, 
                    new PointLight(new vec3()) { Diffuse = new vec3(0, 0, 1), Specular = new vec3(0, 0, 1) }, 
                };
                for (int i = 0; i < lights.Length; i++)
                {
                    this.scene.Lights.Add(lights[i]);
                    var node = LightPositionNode.Create(i * 360 / 3);
                    node.SetLight(lights[i]);
                    this.scene.RootNode.Children.Add(node);
                }
            }

            var list = new ActionList();
            var transformAction = new TransformAction(scene.RootNode);
            list.Add(transformAction);
            var shadowVolumeAction = new ShadowVolumeAction(scene);
            list.Add(shadowVolumeAction);
            var renderAction = new RenderAction(scene);
            list.Add(renderAction);
            this.actionList = list;

            (new FormProperyGrid(shadowVolumeAction)).Show();

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

            {
                //
                var model = this.modelInfo.modelProvider.Model;
                var node1 = ShadowVolumeNode.Create(model,
                    this.modelInfo.position,
                    this.modelInfo.normal,
                    this.modelInfo.size);
                node1.WorldPosition = new vec3(0, this.modelInfo.size.y / 2 + 0.2f, 0);
                node1.DiffuseColor = new vec3(1, 1, 1);
                group.Children.Add(node1);

                //var node2 = ShadowVolumeNode.Create(model,
                //    this.modelInfo.position,
                //    this.modelInfo.color,
                //    this.modelInfo.size);
                //node2.WorldPosition = new vec3(1, -1, 0) * 3;

                //var node3 = ShadowVolumeNode.Create(model,
                //    this.modelInfo.position,
                //    this.modelInfo.color,
                //    this.modelInfo.size);
                //node3.WorldPosition = new vec3(-1, -1, 0) * 3;
            }

            {
                var model = new AdjacentCubeModel(new vec3(100, 1, 100));
                var floor = ShadowVolumeNode.Create(model, AdjacentCubeModel.strPosition, AdjacentCubeModel.strNormal, model.GetSize());
                floor.WorldPosition = new vec3(0, -0.5f, 0);
                floor.DiffuseColor = new vec3(1, 1, 1) * 0.1f;
                group.Children.Add(floor);
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
