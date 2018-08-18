using CSharpGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace c10d00_UserInterface
{
    public partial class FormMain : Form
    {
        private Scene scene;
        private ActionList actionList;
        private List<LightBase> lights;
        private ShadowMappingAction shadowMappingAction;

        public FormMain(List<LightBase> lights, string text)
        {
            InitializeComponent();

            this.lights = lights;
            this.Text = text;

            this.Load += FormMain_Load;
            this.winGLCanvas1.OpenGLDraw += winGLCanvas1_OpenGLDraw;
            this.winGLCanvas1.Resize += winGLCanvas1_Resize;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            var position = new vec3(1, 0.6f, 1) * 16;
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspective, this.winGLCanvas1.Width, this.winGLCanvas1.Height);

            this.scene = new Scene(camera);
            this.scene.RootNode = GetRootNode();
            WinCtrlRoot rootControl = GetRootControl();
            rootControl.Bind(this.winGLCanvas1);
            this.scene.RootControl = rootControl;

            // add lights.
            {
                var lightList = this.lights;
                float angle = 0;
                foreach (var light in lightList)
                {
                    this.scene.Lights.Add(light);
                    var node = LightPositionNode.Create(light, angle);
                    angle += 360.0f / lightList.Count;
                    this.scene.RootNode.Children.Add(node);
                }
            }
            {
                var list = new ActionList();
                list.Add(new TransformAction(scene));
                var shadowMappingAction = new ShadowMappingAction(scene);
                list.Add(shadowMappingAction);
                this.shadowMappingAction = shadowMappingAction;
                list.Add(new RenderAction(scene));

                //var guiLayoutAction = new GUILayoutAction(scene.RootControl);
                //list.Add(guiLayoutAction);
                var guiRenderAction = new GUIRenderAction(scene.RootControl);
                list.Add(guiRenderAction);

                this.actionList = list;
            }
            {
                var node = DepthRectNode.Create();
                node.TextureSource = this.shadowMappingAction.LightEquipment;
                this.scene.RootNode.Children.Add(node);
            }

            Match(this.trvSceneObject, scene.RootNode);
            this.trvSceneObject.ExpandAll();

            Match(this.trvSceneGUI, scene.RootControl);
            this.trvSceneGUI.ExpandAll();

            var manipulater = new FirstPerspectiveManipulater();
            manipulater.Bind(camera, this.winGLCanvas1);

        }

        private void Match(TreeView treeView, GLControl nodeBase)
        {
            treeView.Nodes.Clear();
            var node = new TreeNode(nodeBase.ToString()) { Tag = nodeBase };
            treeView.Nodes.Add(node);
            Match(node, nodeBase);
        }

        private void Match(TreeNode node, GLControl nodeBase)
        {
            foreach (var item in nodeBase.Children)
            {
                var child = new TreeNode(item.ToString()) { Tag = item };
                node.Nodes.Add(child);
                Match(child, item);
            }
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

        private SceneNodeBase GetRootNode()
        {
            var group = new GroupNode();
            var filenames = new string[] { "floor.obj_", };
            var colors = new Color[] { Color.Green, };
            for (int i = 0; i < filenames.Length; i++)
            {
                string folder = System.Windows.Forms.Application.StartupPath;
                string filename = System.IO.Path.Combine(folder + @"\..\..\..\..\Infrastructure\CSharpGL.Models", filenames[i]);
                var parser = new ObjVNFParser(true);
                ObjVNFResult result = parser.Parse(filename);
                if (result.Error != null)
                {
                    MessageBox.Show(result.Error.ToString());
                }
                else
                {
                    ObjVNFMesh mesh = result.Mesh;
                    var model = new ObjVNF(mesh);
                    var node = ShadowMappingNode.Create(model, ObjVNF.strPosition, ObjVNF.strNormal, model.GetSize());
                    node.WorldPosition = new vec3(0, i * 5, 0);
                    node.Scale = new vec3(1, 1, 1) * 4;
                    node.Color = colors[i].ToVec3();
                    node.Name = filename;
                    group.Children.Add(node);
                }
            }
            {
                var parser = new ObjVNFParser(false);
                var hanoiTower = new GroupNode();
                ObjItem[] items = HanoiTower.GetDataSource();
                foreach (var item in items)
                {
                    var objFormat = item.model;
                    var filename = item.GetType().Name;
                    objFormat.DumpObjFile(filename, filename);
                    ObjVNFResult result = parser.Parse(filename);
                    if (result.Error != null)
                    {
                        Console.WriteLine("Error: {0}", result.Error);
                    }
                    else
                    {
                        ObjVNFMesh mesh = result.Mesh;
                        var model = new ObjVNF(mesh);
                        var node = ShadowMappingNode.Create(model, ObjVNF.strPosition, ObjVNF.strNormal, model.GetSize());
                        node.WorldPosition = item.position;
                        node.Color = item.color;
                        node.Name = filename;
                        hanoiTower.Children.Add(node);
                    }
                }
                group.Children.Add(hanoiTower);
            }

            return group;
        }

        private WinCtrlRoot GetRootControl()
        {
            var root = new WinCtrlRoot(this.winGLCanvas1.Width, this.winGLCanvas1.Height);

            {
                var control = new CtrlLabel(100) { Anchor = GUIAnchorStyles.Left | GUIAnchorStyles.Top };
                control.Width = 100; control.Height = 30;
                control.Text = "Hello CSharpGL!";
                control.RenderBackground = true;
                control.BackgroundColor = new vec4(1, 0, 0, 1);
                control.MouseUp += control_MouseUp;
                root.Children.Add(control);
                control.Location = new GUIPoint(10, root.Height - control.Height - 10);
            }
            {
                var control = new CtrlButton() { Anchor = GUIAnchorStyles.Left | GUIAnchorStyles.Top };
                control.Width = 100; control.Height = 50;
                control.Focused = true;
                control.MouseUp += control_MouseUp;
                root.Children.Add(control);
                control.Location = new GUIPoint(10, root.Height - control.Height - 50);
            }
            {
                string folder = System.Windows.Forms.Application.StartupPath;
                var bitmap = new Bitmap(System.IO.Path.Combine(folder, @"image.png"));
                var control = new CtrlImage(bitmap, false) { Anchor = GUIAnchorStyles.Left | GUIAnchorStyles.Top };
                control.Width = 100; control.Height = 50;
                bitmap.Dispose();
                control.MouseUp += control_MouseUp;
                root.Children.Add(control);
                control.Location = new GUIPoint(10, root.Height - control.Height - 110);
            }

            return root;
        }

        void control_MouseUp(object sender, GLMouseEventArgs e)
        {
            MessageBox.Show(string.Format("This is a message from {0}!", sender));
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
        }
    }
}
