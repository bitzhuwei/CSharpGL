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
        private Picking pickingAction;

        public Form1HowStencilWorks()
        {
            InitializeComponent();

            this.Load += FormMain_Load;
            this.winGLCanvas1.OpenGLDraw += winGLCanvas1_OpenGLDraw;
            this.winGLCanvas1.Resize += winGLCanvas1_Resize;
            this.winGLCanvas1.MouseMove += winGLCanvas1_MouseMove;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            var rootElement = GetRootElement();

            var position = new vec3(4, 3, 5) * 0.5f;
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspecitive, this.winGLCanvas1.Width, this.winGLCanvas1.Height);
            this.scene = new Scene(camera)

            {
                RootNode = rootElement,
                ClearColor = Color.SkyBlue.ToVec4(),
            };

            Match(this.trvScene, scene.RootNode);
            this.trvScene.ExpandAll();

            var tansformAction = new TransformAction(scene.RootNode);
            var renderAction = new RenderAction(scene);
            var actionList = new ActionList();
            actionList.Add(tansformAction); actionList.Add(renderAction);
            this.actionList = actionList;

            this.pickingAction = new Picking(scene);

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
            // demo 1:
            //return StencilTestNode.Create();

            // demo 2:
            //var quaterNode = QuaterNode.Create();
            //var bottleNode = KleinBottleNode.Create(new KleinBottleModel());
            //bottleNode.Scale = new vec3(1, 1, 1) * 0.1f;
            //var group = new HowStencilTestWorkNode();
            //group.Children.Add(quaterNode);
            //group.Children.Add(bottleNode);
            //return group;

            // demo 3:
            var clearStencilNode = ClearStencilNode.Create(); // this helps clear stencil buffer because `glClear(GL_STENCIL_BUFFER_BIT);` doesn't work on my laptop.
            string folder = System.Windows.Forms.Application.StartupPath;
            var bitmap = new Bitmap(System.IO.Path.Combine(folder, @"flower.png"));
            bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);
            var texture = new Texture(new TexImageBitmap(bitmap));
            texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_REPEAT));
            texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_REPEAT));
            texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_REPEAT));
            texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR));
            texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR));
            texture.Initialize();
            bitmap.Dispose();

            var group = new GroupNode(clearStencilNode);
            for (int x = 0; x < 3; x++)
            {
                for (int z = 0; z < 3; z++)
                {
                    var outlineCubeNode = OutlineCubeNode.Create(texture);
                    outlineCubeNode.Scale = new vec3(1, 1, 1) * 0.6f;
                    outlineCubeNode.WorldPosition = new vec3(x - 1, 0, z - 1);
                    group.Children.Add(outlineCubeNode);
                }
            }
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
