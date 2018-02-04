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

        public FormMain()
        {
            InitializeComponent();

            // How to use GlyphServer:
            var server = GlyphServer.DefaultServer;
            var keys = "Hello CSharpGL!";
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
            this.scene = new Scene(camera)

            {
                RootNode = rootElement,
                RootControl = rootControl,
                ClearColor = Color.SkyBlue.ToVec4(),
            };
            rootControl.Bind(this.winGLCanvas1);

            var list = new ActionList();

            var transformAction = new TransformAction(scene.RootNode);
            list.Add(transformAction);
            var renderAction = new RenderAction(scene);
            list.Add(renderAction);

            var guiLayoutAction = new GUILayoutAction(scene.RootControl);
            list.Add(guiLayoutAction);
            var guiRenderAction = new GUIRenderAction(scene.RootControl);
            list.Add(guiRenderAction);

            this.actionList = list;

            Match(this.trvSceneObject, scene.RootNode);
            this.trvSceneObject.ExpandAll();

            //Match(this.trvSceneGUI, scene.RootControl);
            this.trvSceneGUI.ExpandAll();
        }

        private WinCtrlRoot GetRootControl()
        {
            var root = new WinCtrlRoot(this.winGLCanvas1.Width, this.winGLCanvas1.Height);

            string folder = System.Windows.Forms.Application.StartupPath;
            var bitmap = new Bitmap(System.IO.Path.Combine(folder, @"particle.png"));
            {
                var control = new CtrlImage(bitmap, false) { Anchor = GUIAnchorStyles.Left | GUIAnchorStyles.Bottom };
                control.Location = new GUIPoint(10, 10);
                control.Width = 100; control.Height = 50;
                bitmap.Dispose();
                control.MouseUp += control_MouseUp;
                root.Children.Add(control);
            }
            {
                var control = new CtrlButton() { Anchor = GUIAnchorStyles.Left | GUIAnchorStyles.Bottom };
                control.Location = new GUIPoint(10, 70);
                control.Width = 100; control.Height = 50;
                control.Focused = true;
                control.MouseUp += control_MouseUp;
                root.Children.Add(control);
            }
            {
                var control = new CtrlLabel(100) { Anchor = GUIAnchorStyles.Left | GUIAnchorStyles.Bottom };
                control.Location = new GUIPoint(10, 130);
                control.Width = 100; control.Height = 30;
                control.Text = "Hello CSharpGL!";
                control.RenderBackground = true;
                control.BackgroundColor = new vec4(1, 0, 0, 1);
                control.MouseUp += control_MouseUp;

                root.Children.Add(control);
            }

            return root;
        }

        void control_MouseUp(object sender, GLMouseEventArgs e)
        {
            MessageBox.Show(string.Format("This is a message from {0}!", sender));
        }

        private SceneNodeBase GetRootElement()
        {
            var rectangle = RectangleNode.Create();
            rectangle.Scale *= 3;
            string folder = System.Windows.Forms.Application.StartupPath;
            rectangle.TextureSource = new TextureSource(System.IO.Path.Combine(folder, @"Lenna.png"));

            //var blend = RectangleNode.Create();
            //blend.Scale *= 1.5f;
            //blend.WorldPosition = new vec3(-0.5f, 0, 0.1f);
            //blend.RenderUnit.Methods[0].StateList.Add(new BlendState(BlendingSourceFactor.SourceAlpha, BlendingDestinationFactor.OneMinusSourceAlpha));
            //blend.TextureSource = new TextureSource(@"particle.png");

            //var blend2 = RectangleNode.Create();
            //blend2.Scale *= 1.5f;
            //blend2.WorldPosition = new vec3(0.5f, 0, 0.2f);
            //blend2.RenderUnit.Methods[0].StateList.Add(new BlendState(BlendingSourceFactor.SourceAlpha, BlendingDestinationFactor.OneMinusSourceAlpha));
            //blend2.TextureSource = new TextureSource(@"particle.png");

            // note: this tells us that the right way is to render the nearest transparenct object at last.
            var group = new GroupNode(rectangle);//, blend, blend2);

            return group;
        }

        //private void Match(TreeView treeView, GLControl nodeBase)
        //{
        //    treeView.Nodes.Clear();
        //    var node = new TreeNode(nodeBase.ToString()) { Tag = nodeBase };
        //    treeView.Nodes.Add(node);
        //    Match(node, nodeBase);
        //}

        //private void Match(TreeNode node, GLControl nodeBase)
        //{
        //    foreach (var item in nodeBase.Children)
        //    {
        //        var child = new TreeNode(item.ToString()) { Tag = item };
        //        node.Nodes.Add(child);
        //        Match(child, item);
        //    }
        //}

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

            this.lblState.Text = string.Format("{0} objects selected.", 1);
        }
    }
}
