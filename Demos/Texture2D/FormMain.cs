using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CSharpGL;

namespace Texture2D
{
    public partial class FormMain : Form
    {
        private Scene scene;
        private ActionList actionList;

        class CharDumper : IEnumerable<string>
        {
            private string text;

            public CharDumper(string text)
            {
                this.text = text;
            }
            public IEnumerator<string> GetEnumerator()
            {
                foreach (var item in this.text)
                {
                    yield return item.ToString();
                }
            }

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
        }

        public FormMain()
        {
            InitializeComponent();

            // How to use GlyphServer:
            var builder = new StringBuilder();
            for (char c = (char)20; c < (char)127; c++)
            {
                builder.Append(c);
            }
            var charset = new CharDumper(builder.ToString());
            var font = new Font("仿宋", 32, GraphicsUnit.Pixel);
            var server = GlyphServer.Create(font, charset, 60, 60, 21);
            var keys = new CharDumper("Hello CSharpGL!");
            foreach (var item in keys)
            {
                GlyphInfo info;
                if (server.GetGlyphInfo(item, out info))
                {
                    Console.WriteLine(info);
                }
                else
                {
                    Console.WriteLine("Glyph of [{0}] not exists!", item);
                }
            }

            this.Load += FormMain_Load;
            this.winGLCanvas1.OpenGLDraw += winGLCanvas1_OpenGLDraw;
            this.winGLCanvas1.Resize += winGLCanvas1_Resize;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            SceneNodeBase rootElement = GetRootElement();
            WinCtrlRoot rootControl = GetRootControl();

            var position = new vec3(1, 0, 4);
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspecitive, this.winGLCanvas1.Width, this.winGLCanvas1.Height);
            this.scene = new Scene(camera, this.winGLCanvas1)
            {
                RootElement = rootElement,
                RootControl = rootControl,
                ClearColor = Color.SkyBlue.ToVec4(),
            };
            rootControl.Bind(this.winGLCanvas1);

            var list = new ActionList();

            var transformAction = new TransformAction(scene);
            list.Add(transformAction);
            var renderAction = new RenderAction(scene);
            list.Add(renderAction);

            var guiLayoutAction = new GUILayoutAction(scene);
            list.Add(guiLayoutAction);
            var guiRenderAction = new GUIRenderAction(scene);
            list.Add(guiRenderAction);

            this.actionList = list;

            Match(this.trvScene, scene.RootElement);
            this.trvScene.ExpandAll();


        }

        private WinCtrlRoot GetRootControl()
        {
            var root = new WinCtrlRoot(this.winGLCanvas1.Width, this.winGLCanvas1.Height);

            var bitmap = new Bitmap(@"particle.png");
            {
                var control = new CtrlImage(bitmap, false);
                control.Margin = new GUIPadding(10, 10, 10, 10);
                control.Width = 100; control.Height = 50;
                bitmap.Dispose();
                root.Children.Add(control);
            }
            {
                var control = new CtrlButton() { Anchor = GUIAnchorStyles.Left | GUIAnchorStyles.Bottom };
                control.Margin = new GUIPadding(10, 10, 10, 70);
                control.Width = 100; control.Height = 50;
                root.Children.Add(control);
                control.Focused = true;
            }

            return root;
        }

        private SceneNodeBase GetRootElement()
        {
            var rectangle = RectangleNode.Create();
            rectangle.Scale *= 3;
            rectangle.TextureSource = new CrateTextureSource(@"Crate.bmp");

            var blend = RectangleNode.Create();
            blend.Scale *= 1.5f;
            blend.WorldPosition = new vec3(-0.5f, 0, 0.1f);
            blend.RenderUnit.Methods[0].StateList.Add(new BlendState(BlendingSourceFactor.SourceAlpha, BlendingDestinationFactor.OneMinusSourceAlpha));
            blend.TextureSource = new CrateTextureSource(@"particle.png");

            var blend2 = RectangleNode.Create();
            blend2.Scale *= 1.5f;
            blend2.WorldPosition = new vec3(0.5f, 0, 0.2f);
            blend2.RenderUnit.Methods[0].StateList.Add(new BlendState(BlendingSourceFactor.SourceAlpha, BlendingDestinationFactor.OneMinusSourceAlpha));
            blend2.TextureSource = new CrateTextureSource(@"particle.png");

            // note: this tells us that the right way is to render the nearest transparenct object at last.
            var group = new GroupNode(rectangle, blend, blend2);

            return group;
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
