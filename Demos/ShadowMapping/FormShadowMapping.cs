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
            this.scene = new Scene(camera, this.winGLCanvas1)
            {
                RootElement = rootElement,
                ClearColor = Color.SkyBlue.ToVec4(),
            };

            Match(this.trvScene, scene.RootElement);
            this.trvScene.ExpandAll();

            var tansformAction = new TransformAction(scene);
            var shadowMappingAction = new ShadowMappingAction(scene);
            var renderAction = new RenderAction(scene, camera);
            var actionList = new ActionList();
            actionList.Add(tansformAction); actionList.Add(shadowMappingAction); actionList.Add(renderAction);
            this.actionList = actionList;

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
            var lightPosition = new vec3(0, 3, 5) * 2;
            var localLight = new SpotLight(lightPosition, new vec3(0, 0, 0), 60, 1, 500) { Color = new vec3(1, 1, 1), };
            {
                //int width = 600, height = 400;
                //var innerCamera = new Camera(new vec3(5, 5, 5), new vec3(0, 0, 0), new vec3(0, 1, 0), CameraType.Perspecitive, width, height);
                //(innerCamera as IPerspectiveViewCamera).Far = 50;
                //innerCamera.GetProjectionMatrix();
                //innerCamera.GetViewMatrix();
                var lightContainer = new LightContainerNode(localLight);
                {
                    var teapot = ShadowTeapotNode.Create();
                    teapot.RotateSpeed = 1;
                    lightContainer.Children.Add(teapot);
                }
                {
                    var ground = ShadowGroundNode.Create();
                    ground.Scale *= 30;
                    ground.WorldPosition = new vec3(0, -3, 0);
                    lightContainer.Children.Add(ground);
                }
                group.Children.Add(lightContainer);
            }
            {
                var rectangle = RectangleNode.Create();
                rectangle.TextureSource = localLight;
                rectangle.RotationAngle = 45;
                rectangle.WorldPosition = new vec3(5, 1, 5) * 3;
                rectangle.Scale *= 4;

                group.Children.Add(rectangle);
            }
            {
                var cube = LightPostionNode.Create();
                cube.WorldPosition = lightPosition;
                cube.SetLight(localLight);
                group.Children.Add(cube);
            }
            return group;
        }

        //private SceneNodeBase GetRootElement()
        //{
        //    int width = 600, height = 400;
        //    var innerCamera = new Camera(new vec3(0, 2, 5), new vec3(0, 0, 0), new vec3(0, 1, 0), CameraType.Perspecitive, width, height);
        //    (innerCamera as IPerspectiveViewCamera).Far = 50;
        //    IFramebufferProvider source = new DepthFramebufferProvider();
        //    var rtt = new RTTRenderer(width, height, innerCamera, source);
        //    {
        //        var teapot = DepthTextureRenderer.Create();
        //        rtt.Children.Add(teapot);
        //        var ground = GroundRenderer.Create(); ground.Color = Color.Gray.ToVec4(); ground.Scale *= 10; ground.WorldPosition = new vec3(0, -3, 0);
        //        rtt.Children.Add(ground);
        //    }

        //    var rectangle = RectangleRenderer.Create();
        //    rectangle.TextureSource = rtt;

        //    var group = new GroupRenderer();
        //    group.Children.Add(rtt);// rtt must be before rectangle.
        //    group.Children.Add(rectangle);
        //    //group.WorldPosition = new vec3(3, 0.5f, 0);// this looks nice.

        //    return group;
        //}

        private void winGLCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            //this.scene.Render();
            this.actionList.Render();
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
