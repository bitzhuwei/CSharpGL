using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace CSharpGL.Demos
{
    public partial class Form13SimplexNoise : Form
    {

        /// <summary>
        /// 控制Camera的旋转、进退
        /// </summary>
        SatelliteManipulater rotator;
        /// <summary>
        /// 摄像机
        /// </summary>
        Camera camera;

        public Form13SimplexNoise()
        {
            InitializeComponent();

            this.glCanvas1.OpenGLDraw += glCanvas1_OpenGLDraw;
            //this.glCanvas1.MouseDown += glCanvas1_MouseDown;
            //this.glCanvas1.MouseMove += glCanvas1_MouseMove;
            //this.glCanvas1.MouseUp += glCanvas1_MouseUp;
            //this.glCanvas1.MouseWheel += glCanvas1_MouseWheel;

            // 天蓝色背景
            //OpenGL.ClearColor(0x87 / 255.0f, 0xce / 255.0f, 0xeb / 255.0f, 0xff / 255.0f);
            OpenGL.ClearColor(0, 0, 0, 0);
        }

        private void glCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            OpenGL.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT | OpenGL.GL_STENCIL_BUFFER_BIT);

            var arg = new RenderEventArg(RenderModes.Render, this.glCanvas1.ClientRectangle, this.camera);

            {
                mat4 projectionMatrix = arg.Camera.GetProjectionMat4();
                mat4 viewMatrix = arg.Camera.GetViewMat4();
                mat4 modelMatrix = mat4.identity();
                this.simplexNoiseRenderer.SetUniform("projectionMatrix", projectionMatrix);
                this.simplexNoiseRenderer.SetUniform("viewMatrix", viewMatrix);
                this.simplexNoiseRenderer.SetUniform("modelMatrix", modelMatrix);
                this.simplexNoiseRenderer.Render(arg);
            }
            UIRoot uiRoot = this.uiRoot;
            if (uiRoot != null)
            {
                uiRoot.Render(arg);
            }
        }

        //void glCanvas1_MouseWheel(object sender, MouseEventArgs e)
        //{
        //    if (camera != null)
        //    {
        //        camera.MouseWheel(e.Delta);
        //    }
        //}

        private void glCanvas1_Resize(object sender, EventArgs e)
        {
            if (camera != null)
            {
                camera.Resize(this.glCanvas1.Width, this.glCanvas1.Height);

                this.uiRoot.Size = this.glCanvas1.Size;
            }
        }

    }
}
