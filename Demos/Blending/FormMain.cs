using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CSharpGL;

namespace Blending
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

            var position = new vec3(5, 3, 4);
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

            Match(this.trvScene, scene.RootNode);
            this.trvScene.ExpandAll();
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
                bmp.Dispose();
                var solidCube = TexturedCubeNode.Create(texture);

                group.Children.Add(solidCube);
            }
            {
                var blendingGroup = new BlendingGroupNode(BlendSrcFactor.SrcAlpha, BlendDestFactor.OneMinusSrcAlpha);

                group.Children.Add(blendingGroup);
                var list = new List<BlendingConfig>();
                list.Add(new BlendingConfig(Color.Red, new vec3(1, 0, 1), 0.5f));
                list.Add(new BlendingConfig(Color.Green, new vec3(0.6f, 0, 0.1f), 0.5f));
                list.Add(new BlendingConfig(Color.Blue, new vec3(-0.1f, 0, -0.2f), 0.5f));
                list.Add(new BlendingConfig(Color.Purple, new vec3(0.4f, 0, -0.7f), 0.5f));
                list.Add(new BlendingConfig(Color.Orange, new vec3(0.8f, 0, 0.1f), 0.5f));
                list.Add(new BlendingConfig(Color.Yellow, new vec3(0.8f, 0, 0.1f), 0.5f));
                for (int i = 0; i < list.Count; i++)
                {
                    const float distance = 2.0f;
                    list[i].position = new vec3(
                        distance * (float)Math.Cos((double)i / (double)list.Count * Math.PI * 2),
                        0,
                        distance * (float)Math.Sin((double)i / (double)list.Count * Math.PI * 2)
                        );
                    list[i].alpha = 0.3f;
                }
                foreach (var item in list)
                {
                    var bmp = new Bitmap(1, 1);
                    using (var g = Graphics.FromImage(bmp)) { g.Clear(item.color); }
                    var texture = new Texture(new TexImageBitmap(bmp));
                    texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_CLAMP_TO_EDGE));
                    texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_CLAMP_TO_EDGE));
                    texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_CLAMP_TO_EDGE));
                    texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR));
                    texture.BuiltInSampler.Add(new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR));

                    texture.Initialize();
                    bmp.Dispose();
                    var transparentCube = TexturedCubeNode.Create(texture);
                    transparentCube.WorldPosition = item.position;
                    transparentCube.Alpha = item.alpha;

                    blendingGroup.Children.Add(transparentCube);
                }
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

    class BlendingConfig
    {
        public Color color;
        public vec3 position;
        public float alpha;

        public BlendingConfig(Color color, vec3 position, float alpha)
        {
            this.color = color;
            this.position = position;
            this.alpha = alpha;
        }

    }
}
