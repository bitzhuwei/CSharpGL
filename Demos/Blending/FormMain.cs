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
            this.winGLCanvas1.MouseClick += winGLCanvas1_MouseClick;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            var rootElement = GetTree();

            var position = new vec3(5, 3, 4);
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspecitive, this.winGLCanvas1.Width, this.winGLCanvas1.Height);
            this.scene = new Scene(camera, this.winGLCanvas1)
            {
                RootElement = rootElement,
                ClearColor = Color.SkyBlue.ToVec4(),
            };

            var list = new ActionList();
            var transformAction = new TransformAction(rootElement);
            list.Add(transformAction);
            var renderAction = new RenderAction(rootElement, camera);
            list.Add(renderAction);
            this.actionList = list;

            Match(this.trvScene, scene.RootElement);
            this.trvScene.ExpandAll();
        }

        private void Match(TreeView treeView, SceneNodeBase rendererBase)
        {
            treeView.Nodes.Clear();
            var node = new TreeNode(rendererBase.ToString()) { Tag = rendererBase };
            treeView.Nodes.Add(node);
            Match(node, rendererBase);
        }

        private void Match(TreeNode node, SceneNodeBase rendererBase)
        {
            foreach (var item in rendererBase.Children)
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
                var bmp = new Bitmap(@"Crate.bmp");
                var texture = new Texture(TextureTarget.Texture2D,
                    new TexImage2D(TexImage2D.Target.Texture2D, 0, (int)GL.GL_RGBA, bmp.Width, bmp.Height, 0, GL.GL_BGRA, GL.GL_UNSIGNED_BYTE, new ImageDataProvider(bmp)));
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
                var blendingGroup = new BlendingGroupNode(BlendingSourceFactor.SourceAlpha, BlendingDestinationFactor.OneMinusSourceAlpha);

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
                    var texture = new Texture(TextureTarget.Texture2D,
                          new TexImage2D(TexImage2D.Target.Texture2D, 0, (int)GL.GL_RGBA, bmp.Width, bmp.Height, 0, GL.GL_BGRA, GL.GL_UNSIGNED_BYTE, new ImageDataProvider(bmp)));
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
            this.actionList.Render();
        }

        void winGLCanvas1_Resize(object sender, EventArgs e)
        {
            this.scene.Camera.AspectRatio = ((float)this.winGLCanvas1.Width) / ((float)this.winGLCanvas1.Height);
        }

        /// <summary>
        /// click to pick and toggle the render wireframe state.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void winGLCanvas1_MouseClick(object sender, MouseEventArgs e)
        {
            int x = e.X;
            int y = this.winGLCanvas1.Height - e.Y - 1;
            List<HitTarget> list = this.scene.Pick(x, y);
            //foreach (var item in list)
            //{
            //    var parent = item.renderer.Parent;
            //    if (parent != null)
            //    {
            //        var renderer = parent as IRenderable;
            //        if (renderer != null)
            //        {
            //            renderer.RenderingEnabled = !renderer.RenderingEnabled;
            //        }
            //    }
            //}

            if (list.Count == 0)
            {
                this.propGrid.SelectedObject = null;
            }
            else if (list.Count == 1)
            {
                this.propGrid.SelectedObject = list[0].renderer;
            }
            else
            {
                this.propGrid.SelectedObjects = (from item in list select item.renderer).ToArray();
            }

            this.lblState.Text = string.Format("{0} objects selected.", list.Count);
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
            // TODO: Complete member initialization
            this.color = color;
            this.position = position;
            this.alpha = alpha;
        }

    }
}
