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
        Scene scene;

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
            //var rootElement = GetLegacyPropellerLegacyFlabellum();
            //var rootElement = GetLegacyPropellerFlabellum();
            //var rootElement = GetPropellerLegacyFlabellum();
            //var rootElement = GetPropellerFlabellum();
            var rootElement = GetPropellerRTT();

            var position = new vec3(5, 3, 4);
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
        }

        private void Match(TreeView treeView, RendererBase rendererBase)
        {
            treeView.Nodes.Clear();
            var node = new TreeNode(rendererBase.ToString()) { Tag = rendererBase };
            treeView.Nodes.Add(node);
            Match(node, rendererBase);
        }

        private void Match(TreeNode node, RendererBase rendererBase)
        {
            foreach (var item in rendererBase.Children)
            {
                var child = new TreeNode(item.ToString()) { Tag = item };
                node.Nodes.Add(child);
                Match(child, item as RendererBase);
            }
        }

        private RendererBase GetPropellerRTT()
        {
            var teapot = TeapotRenderer.Create();
            teapot.Scale *= 0.5f;

            int width = 600, height = 400;
            var innerCamera = new Camera(new vec3(0, 2, 5), new vec3(0, 0, 0), new vec3(0, 1, 0), CameraType.Ortho, width, height);
            var rtt = new RTTRenderer(width, height, innerCamera, new ColoredFramebufferProvider());
            rtt.Children.Add(teapot);

            var billboard = TextureBillboardRenderer.Create(rtt as ITextureSource, width, height);

            var group = new GroupRenderer();
            group.Children.Add(rtt);// rtt must be before billboard.
            group.Children.Add(billboard);
            group.WorldPosition = new vec3(3, 0.5f, 0);// this looks nice.

            var propeller = GetPropellerFlabellum();
            propeller.Children.Add(group);

            return propeller;
        }

        private RendererBase GetLegacyPropellerLegacyFlabellum()
        {
            var propeller = new LegacyPropellerRenderer();
            propeller.Children.Add(new LegacyBoundingBoxRenderer(propeller.ModelSize));

            var xflabellum = new LegacyFlabellumRenderer() { WorldPosition = new vec3(2, 0, 0) };
            xflabellum.Children.Add(new LegacyBoundingBoxRenderer(xflabellum.ModelSize));

            var nxflabellum = new LegacyFlabellumRenderer() { WorldPosition = new vec3(-2, 0, 0), RotationAngle = 180, };
            nxflabellum.Children.Add(new LegacyBoundingBoxRenderer(nxflabellum.ModelSize));

            var zflabellum = new LegacyFlabellumRenderer() { WorldPosition = new vec3(0, 0, -2), RotationAngle = 90, };
            zflabellum.Children.Add(new LegacyBoundingBoxRenderer(zflabellum.ModelSize));

            var nzflabellum = new LegacyFlabellumRenderer() { WorldPosition = new vec3(0, 0, 2), RotationAngle = 270, };
            nzflabellum.Children.Add(new LegacyBoundingBoxRenderer(nzflabellum.ModelSize));

            propeller.Children.Add(xflabellum);
            propeller.Children.Add(nxflabellum);
            propeller.Children.Add(zflabellum);
            propeller.Children.Add(nzflabellum);

            return propeller;
        }

        private RendererBase GetLegacyPropellerFlabellum()
        {
            var propeller = new LegacyPropellerRenderer();
            propeller.Children.Add(new LegacyBoundingBoxRenderer(propeller.ModelSize));

            var xflabellum = FlabellumRenderer.Create(); xflabellum.WorldPosition = new vec3(2, 0, 0);
            xflabellum.Children.Add(new LegacyBoundingBoxRenderer(xflabellum.ModelSize));

            var nxflabellum = FlabellumRenderer.Create(); nxflabellum.WorldPosition = new vec3(-2, 0, 0); nxflabellum.RotationAngle = 180;
            nxflabellum.Children.Add(new LegacyBoundingBoxRenderer(nxflabellum.ModelSize));

            var zflabellum = FlabellumRenderer.Create(); zflabellum.WorldPosition = new vec3(0, 0, -2); zflabellum.RotationAngle = 90;
            zflabellum.Children.Add(new LegacyBoundingBoxRenderer(zflabellum.ModelSize));

            var nzflabellum = FlabellumRenderer.Create(); nzflabellum.WorldPosition = new vec3(0, 0, 2); nzflabellum.RotationAngle = 270;
            nzflabellum.Children.Add(new LegacyBoundingBoxRenderer(nzflabellum.ModelSize));

            propeller.Children.Add(xflabellum);
            propeller.Children.Add(nxflabellum);
            propeller.Children.Add(zflabellum);
            propeller.Children.Add(nzflabellum);

            return propeller;
        }

        private RendererBase GetPropellerLegacyFlabellum()
        {
            var propeller = PropellerRenderer.Create();
            propeller.Children.Add(new LegacyBoundingBoxRenderer(propeller.ModelSize));

            var xflabellum = new LegacyFlabellumRenderer() { WorldPosition = new vec3(2, 0, 0) };
            xflabellum.Children.Add(new LegacyBoundingBoxRenderer(xflabellum.ModelSize));

            var nxflabellum = new LegacyFlabellumRenderer() { WorldPosition = new vec3(-2, 0, 0), RotationAngle = 180, };
            nxflabellum.Children.Add(new LegacyBoundingBoxRenderer(nxflabellum.ModelSize));

            var zflabellum = new LegacyFlabellumRenderer() { WorldPosition = new vec3(0, 0, -2), RotationAngle = 90, };
            zflabellum.Children.Add(new LegacyBoundingBoxRenderer(zflabellum.ModelSize));

            var nzflabellum = new LegacyFlabellumRenderer() { WorldPosition = new vec3(0, 0, 2), RotationAngle = 270, };
            nzflabellum.Children.Add(new LegacyBoundingBoxRenderer(nzflabellum.ModelSize));

            propeller.Children.Add(xflabellum);
            propeller.Children.Add(nxflabellum);
            propeller.Children.Add(zflabellum);
            propeller.Children.Add(nzflabellum);

            return propeller;
        }

        private RendererBase GetPropellerFlabellum()
        {
            var propeller = PropellerRenderer.Create();
            propeller.Children.Add(new LegacyBoundingBoxRenderer(propeller.ModelSize));

            var xflabellum = FlabellumRenderer.Create(); xflabellum.WorldPosition = new vec3(2, 0, 0);
            xflabellum.Children.Add(new LegacyBoundingBoxRenderer(xflabellum.ModelSize));

            var nxflabellum = FlabellumRenderer.Create(); nxflabellum.WorldPosition = new vec3(-2, 0, 0); nxflabellum.RotationAngle = 180;
            nxflabellum.Children.Add(new LegacyBoundingBoxRenderer(nxflabellum.ModelSize));

            var zflabellum = FlabellumRenderer.Create(); zflabellum.WorldPosition = new vec3(0, 0, -2); zflabellum.RotationAngle = 90;
            zflabellum.Children.Add(new LegacyBoundingBoxRenderer(zflabellum.ModelSize));

            var nzflabellum = FlabellumRenderer.Create(); nzflabellum.WorldPosition = new vec3(0, 0, 2); nzflabellum.RotationAngle = 270;
            nzflabellum.Children.Add(new LegacyBoundingBoxRenderer(nzflabellum.ModelSize));

            propeller.Children.Add(xflabellum);
            propeller.Children.Add(nxflabellum);
            propeller.Children.Add(zflabellum);
            propeller.Children.Add(nzflabellum);

            return propeller;
        }

        private void winGLCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            this.scene.Render();
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
}
