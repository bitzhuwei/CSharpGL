using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CSharpGL;

namespace StencilTest
{
    public partial class Form1HowStencilWorks : Form
    {
        Scene scene;
        private ActionList actionList;

        public Form1HowStencilWorks()
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

            var position = new vec3(0, 3, 5);
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
            var renderAction = new RenderAction(scene);
            var actionList = new ActionList();
            actionList.Add(tansformAction); actionList.Add(renderAction);
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
            //var teapotNode = TeapotNode.Create();
            //teapotNode.RenderWireframe = false;
            //{
            //    var stencilFunc = new StencilFuncState(EStencilFunc.Always, 1, 0xFF);
            //    var stencilOp = new StencilOpState(EStencilOp.Keep, EStencilOp.Keep, EStencilOp.Replace);
            //    var stencilMask = new StencilMaskState(0xFF);
            //    var colorMask = new ColorMaskState(false, false, false, false);
            //    var depthMask = new DepthMaskState(false);
            //    var clearBuffer = new UserDefineState();
            //    clearBuffer.On += clearBuffer_On;
            //    var list = teapotNode.RenderUnit.Methods[0].StateList;
            //    list.Add(stencilFunc);
            //    list.Add(stencilOp);
            //    list.Add(stencilMask);
            //    list.Add(colorMask);
            //    list.Add(depthMask);
            //    list.Add(clearBuffer);
            //}
            var quaterNode = QuaterNode.Create();
            /*
            GL.Instance.StencilFunc(GL.GL_ALWAYS, 1, 0xFF);
            GL.Instance.StencilOp(GL.GL_KEEP, GL.GL_KEEP, GL.GL_REPLACE);
            GL.Instance.StencilMask(0xFF);
            GL.Instance.DepthMask(false);
            GL.Instance.Clear(GL.GL_STENCIL_BUFFER_BIT);
             */

            var bottleNode = KleinBottleNode.Create(new KleinBottleModel());
            bottleNode.Scale = new vec3(1, 1, 1) * 0.1f;
            {
                //var stencilFunc = new StencilFuncState(EStencilFunc.Equal, 1, 0xFF);
                //var stencilMask = new StencilMaskState(0x00);
                //var depthMask = new DepthMaskState(true);
                //var list = bottleNode.RenderUnit.Methods[0].StateList;
                //list.Add(stencilFunc);
                //list.Add(stencilMask);
                //list.Add(depthMask);
            }
            /*
            glStencilFunc(GL_EQUAL, 1, 0xFF);
            glStencilMask(0x00);
            glDepthMask(GL_TRUE);
             */

            var group = new HowStencilTestWorkNode();
            group.Children.Add(quaterNode);
            //group.Children.Add(teapotNode);
            group.Children.Add(bottleNode);

            return group;
        }

        void clearBuffer_On(object sender, EventArgs e)
        {
            GL.Instance.Clear(GL.GL_STENCIL_BUFFER_BIT);
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
