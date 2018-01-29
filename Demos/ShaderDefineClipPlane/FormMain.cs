using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CSharpGL;

namespace ShaderDefineClipPlane
{
    public partial class FormMain : Form
    {
        private Scene scene;
        private ActionList actionList;
        private ClippedCubeNode clippedCube;
        private TransparentPlaneNode transparentPlane;

        public FormMain()
        {
            InitializeComponent();

            this.Load += FormMain_Load;
            this.winGLCanvas1.OpenGLDraw += winGLCanvas1_OpenGLDraw;
            this.winGLCanvas1.Resize += winGLCanvas1_Resize;
            this.winGLCanvas1.MouseDown += winGLCanvas1_MouseDown;
            this.winGLCanvas1.MouseMove += winGLCanvas1_MouseMove;
            this.winGLCanvas1.MouseUp += winGLCanvas1_MouseUp;

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            var rootElement = GetRootElement();

            var position = new vec3(-3, 3, 4) * 0.5f;
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspecitive, this.winGLCanvas1.Width, this.winGLCanvas1.Height);
            this.scene = new Scene(camera)
            {
                RootNode = rootElement,
                ClearColor = Color.SkyBlue.ToVec4(),
            };

            var list = new ActionList();
            var transformAction = new TransformAction(scene);
            list.Add(transformAction);
            var renderAction = new RenderAction(scene);
            list.Add(renderAction);
            this.actionList = list;

            this.pickingAction = new Picking(scene);
            this.triangleTip = new LegacyTriangleNode();
            this.quadTip = new LegacyQuadNode();
            this.tipList.Add(this.triangleTip);
            this.tipList.Add(this.quadTip);

            Match(this.trvScene, scene.RootNode);
            this.trvScene.ExpandAll();

            var manipulater = new FirstPerspectiveManipulater();
            manipulater.BindingMouseButtons = GLMouseButtons.Right;
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
            string folder = System.Windows.Forms.Application.StartupPath;
            var bmp = new Bitmap(System.IO.Path.Combine(folder, @"Crate.bmp"));
            TexStorageBase storage = new TexImageBitmap(bmp);
            var texture = new Texture(storage);
            texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_CLAMP_TO_EDGE));
            texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_CLAMP_TO_EDGE));
            texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_CLAMP_TO_EDGE));
            texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR));
            texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR));
            texture.Initialize();
            texture.TextureUnitIndex = 0;
            bmp.Dispose();

            this.clippedCube = ClippedCubeNode.Create(texture);
            this.transparentPlane = TransparentPlaneNode.Create();
            transparentPlane.Scale = new vec3(1, 1, 1);
            transparentPlane.WorldPosition = new vec3(0, -0.1f, 0);
            var group = new GroupNode(clippedCube, transparentPlane);

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
            if (this.scene != null)
            {
                this.scene.Camera.AspectRatio = ((float)this.winGLCanvas1.Width) / ((float)this.winGLCanvas1.Height);
            }
        }

        private void trvScene_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.propGrid.SelectedObject = e.Node.Tag;
        }
    }
}
