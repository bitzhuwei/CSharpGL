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
    public partial class FormShadowMapping : Form
    {
        Scene scene;
        private ActionList actionList;

        public FormShadowMapping()
        {
            InitializeComponent();

            this.Load += FormMain_Load;
            this.winGLCanvas1.OpenGLDraw += winGLCanvas1_OpenGLDraw;
            this.winGLCanvas1.Resize += winGLCanvas1_Resize;
            this.winGLCanvas1.KeyPress += winGLCanvas1_KeyPress;
        }

        BlendFactorHelper helper = new BlendFactorHelper();
        private ShadowMappingAction shadowMappingAction;
        void winGLCanvas1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'b')
            {
                BlendingSourceFactor source;
                BlendingDestinationFactor dest;
                helper.GetNext(out source, out dest);
                this.shadowMappingAction.Blend.SourceFactor = source;
                this.shadowMappingAction.Blend.DestFactor = dest;
                this.lblState.Text = string.Format("s:{0}, d:{1}", source, dest);
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            var rootElement = GetRootElement();
            //var teapot = ShadowMappingRenderer.Create();
            //var rootElement = teapot;

            var position = new vec3(5, 3, 5) * 3;
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
                var list = new List<LightBase>();
                double radian = 120.0 / 180.0 * Math.PI;
                {
                    var light = new CSharpGL.SpotLight(new vec3(3, 3, 3), new vec3(), (float)Math.Cos(radian), new Attenuation(2, 0, 0));
                    light.Diffuse = new vec3(1, 0, 0);
                    light.Specular = new vec3(1, 0, 0);
                    list.Add(light);
                }
                {
                    var light = new CSharpGL.SpotLight(new vec3(3, 3, 3), new vec3(), (float)Math.Cos(radian), new Attenuation(2, 0, 0));
                    light.Diffuse = new vec3(0, 1, 0);
                    light.Specular = new vec3(0, 1, 0);
                    list.Add(light);
                }
                {
                    var light = new CSharpGL.SpotLight(new vec3(3, 3, 3), new vec3(), (float)Math.Cos(radian), new Attenuation(2, 0, 0));
                    light.Diffuse = new vec3(0, 0, 1);
                    light.Specular = new vec3(0, 0, 1);
                    list.Add(light);
                }
                for (int i = 0; i < list.Count; i++)
                {
                    var light = list[i];
                    var node = LightPositionNode.Create(light, i * 360.0f / list.Count);

                    this.scene.Lights.Add(light);
                    this.scene.RootNode.Children.Add(node);
                }
            }

            Match(this.trvScene, scene.RootNode);
            this.trvScene.ExpandAll();

            var tansformAction = new TransformAction(scene);
            this.shadowMappingAction = new ShadowMappingAction(scene);
            var renderAction = new RenderAction(scene);
            var actionList = new ActionList();
            actionList.Add(tansformAction); actionList.Add(shadowMappingAction); actionList.Add(renderAction);
            this.actionList = actionList;
            (new FormProperyGrid(shadowMappingAction)).Show();

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

        private SceneNodeBase GetRootElement()
        {
            var group = new GroupNode();
            {
                var model = new Teapot();
                var node = ShadowMappingNode.Create(model, Teapot.strPosition, Teapot.strNormal, model.GetModelSize());
                node.Color = Color.Gold.ToVec3();
                node.RotateSpeed = 1;
                group.Children.Add(node);
            }
            {
                var model = new GroundModel();
                var node = ShadowMappingNode.Create(model, GroundModel.strPosition, GroundModel.strNormal, model.ModelSize);
                node.Color = Color.White.ToVec3();
                node.Scale *= 100;
                node.WorldPosition = new vec3(0, -3, 0);
                group.Children.Add(node);
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
