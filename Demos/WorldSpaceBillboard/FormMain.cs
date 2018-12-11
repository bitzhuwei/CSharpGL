﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CSharpGL;

namespace WorldSpaceBillboard
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

            Application.Idle += Application_Idle;
        }

        void Application_Idle(object sender, EventArgs e)
        {
            this.UpdateText(this.trvScene.Nodes[0]);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            var rootElement = GetTree();

            var position = new vec3(5, 3, 4);
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspective, this.winGLCanvas1.Width, this.winGLCanvas1.Height);
            this.scene = new Scene(camera)
            {
                RootNode = rootElement,
                ClearColor = Color.SkyBlue.ToVec4(),
            };

            var list = new ActionList();
            var transformAction = new TransformAction(scene);
            list.Add(transformAction);
            var billboardSortAction = new BillboardSortAction(scene.RootNode, scene.Camera);
            (new FormPropertyGrid(billboardSortAction)).Show();
            list.Add(billboardSortAction);
            var renderAction = new RenderAction(scene);
            list.Add(renderAction);
            var billboardRenderAction = new BillboardRenderAction(this.scene.Camera, billboardSortAction);
            list.Add(billboardRenderAction);
            this.actionList = list;

            Match(this.trvScene, scene.RootNode);
            this.trvScene.ExpandAll();

            var manipulater = new FirstPerspectiveManipulater();
            manipulater.StepLength = 0.1f;
            manipulater.Bind(camera, this.winGLCanvas1);

            BlendSrcFactor s; BlendDestFactor d;
            helper.GetNext(out s, out d);
            ss = s; dd = d;
            this.winGLCanvas1.KeyPress += winGLCanvas1_KeyPress;
        }

        private BlendSrcFactor ss;
        private BlendDestFactor dd;
        private BlendFactorHelper helper = new BlendFactorHelper();
        void winGLCanvas1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'b')
            {
                BlendSrcFactor s; BlendDestFactor d;
                helper.GetNext(out s, out d);
                if (ss == s && dd == d) { MessageBox.Show("Round up"); }

                SetupBlending(this.scene.RootNode, s, d);
                this.lblState.Text = string.Format("s:{0}, d:{1}", s, d);
            }
        }

        private void SetupBlending(SceneNodeBase sceneNodeBase, BlendSrcFactor s, BlendDestFactor d)
        {
            var node = sceneNodeBase as TextBillboardNode;
            if (node != null)
            {
                node.Blend.SourceFactor = s;
                node.Blend.DestFactor = d;
            }

            foreach (var item in sceneNodeBase.Children)
            {
                SetupBlending(item, s, d);
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

        private SceneNodeBase GetTree()
        {
            const float length = 6;
            var group = new GroupNode();
            {
                var floor = CubeNode.Create();
                floor.Scale = new vec3(length, 0.1f, length);
                floor.Color = Color.Brown.ToVec4();
                group.Children.Add(floor);
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    float x = -length / 2 + length / 2 * i;
                    float y = 0.25f;
                    float z = -length / 2 + length / 2 * j;
                    var stick = CubeNode.Create();
                    stick.Scale = new vec3(0.1f, y * 2, 0.1f);
                    stick.WorldPosition = new vec3(x, y, z);
                    stick.Color = Color.Green.ToVec4();
                    group.Children.Add(stick);
                    {
                        //var billboard = TextBillboardNodeBackup.Create(textureSource, 200, 40);
                        var billboard = TextBillboardNode.Create(200, 40, 100);
                        billboard.Text = string.Format("Hello Billboard[{0}]!", i * 3 + j);
                        billboard.Color = Color.White.ToVec3();
                        billboard.EnableRendering = ThreeFlags.None;// we don't render it in RenderAction. we render it in BillboardRenderAction.
                        billboard.WorldPosition = new vec3(0, y * 4, 0);
                        stick.Children.Add(billboard);
                    }
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            IWorldSpace node = this.scene.RootNode;
            if (node != null)
            {
                node.RotationAngle += 1.3f;
            }

            UpdateText(this.trvScene.Nodes[0]);
        }

        private void UpdateText(TreeNode treeNode)
        {
            var node = treeNode.Tag as TextBillboardNode;
            if (node != null)
            {
                if (node.Text != treeNode.Text)
                {
                    treeNode.Text = node.Text;
                }
            }

            foreach (var item in treeNode.Nodes)
            {
                UpdateText(item as TreeNode);
            }
        }

    }

}
