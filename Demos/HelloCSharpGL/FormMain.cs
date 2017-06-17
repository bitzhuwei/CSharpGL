using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CSharpGL;
using CSharpGL.Models;

namespace HelloCSharpGL
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
            var position = new vec3(5, 3, 4);
            var center = new vec3(0, 0, 0);
            var up = new vec3(0, 1, 0);
            var camera = new Camera(position, center, up, CameraType.Perspecitive, this.winGLCanvas1.Width, this.winGLCanvas1.Height);
            var propeller = GetLegacyPropellerLegacyFlabellum();
            //var propeller = GetLegacyPropellerFlabellum();
            //var propeller = GetPropellerLegacyFlabellum();
            //var propeller = GetPropellerFlabellum();
            this.scene = new Scene(camera, this.winGLCanvas1)
            {
                RootElement = propeller,
            };
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
            var xflabellum = FlabellumRenderer.Create(); xflabellum.WorldPosition = new vec3(2, 0, 0);
            var nxflabellum = FlabellumRenderer.Create(); nxflabellum.WorldPosition = new vec3(-2, 0, 0); nxflabellum.RotationAngle = 180;
            var zflabellum = FlabellumRenderer.Create(); zflabellum.WorldPosition = new vec3(0, 0, -2); zflabellum.RotationAngle = 90;
            var nzflabellum = FlabellumRenderer.Create(); nzflabellum.WorldPosition = new vec3(0, 0, 2); nzflabellum.RotationAngle = 270;
            propeller.Children.Add(xflabellum);
            propeller.Children.Add(nxflabellum);
            propeller.Children.Add(zflabellum);
            propeller.Children.Add(nzflabellum);
            return propeller;
        }

        private RendererBase GetPropellerLegacyFlabellum()
        {
            var propeller = PropellerRenderer.Create();
            var xflabellum = new LegacyFlabellumRenderer() { WorldPosition = new vec3(2, 0, 0) };
            var nxflabellum = new LegacyFlabellumRenderer() { WorldPosition = new vec3(-2, 0, 0), RotationAngle = 180, };
            var zflabellum = new LegacyFlabellumRenderer() { WorldPosition = new vec3(0, 0, -2), RotationAngle = 90, };
            var nzflabellum = new LegacyFlabellumRenderer() { WorldPosition = new vec3(0, 0, 2), RotationAngle = 270, };
            propeller.Children.Add(xflabellum);
            propeller.Children.Add(nxflabellum);
            propeller.Children.Add(zflabellum);
            propeller.Children.Add(nzflabellum);
            return propeller;
        }

        private RendererBase GetPropellerFlabellum()
        {
            var propeller = PropellerRenderer.Create();
            var xflabellum = FlabellumRenderer.Create(); xflabellum.WorldPosition = new vec3(2, 0, 0);
            var nxflabellum = FlabellumRenderer.Create(); nxflabellum.WorldPosition = new vec3(-2, 0, 0); nxflabellum.RotationAngle = 180;
            var zflabellum = FlabellumRenderer.Create(); zflabellum.WorldPosition = new vec3(0, 0, -2); zflabellum.RotationAngle = 90;
            var nzflabellum = FlabellumRenderer.Create(); nzflabellum.WorldPosition = new vec3(0, 0, 2); nzflabellum.RotationAngle = 270;
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
            List<RendererBase> list = this.scene.Pick(x, y);
            foreach (var item in list)
            {
                var parent = item.Parent;
                if (parent != null)
                {
                    var renderer = parent as IRenderable;
                    if (renderer != null)
                    {
                        renderer.RenderingEnabled = !renderer.RenderingEnabled;
                    }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            IWorldSpace renderer = this.scene.RootElement;
            if (renderer != null)
            {
                renderer.RotationAngle += 1;
            }
        }
    }
}
