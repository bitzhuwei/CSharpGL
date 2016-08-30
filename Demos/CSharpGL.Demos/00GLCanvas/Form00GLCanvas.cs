using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace CSharpGL.Demos
{
    public partial class Form00GLCanvas : Form
    {

        private Point mousePosition;
        private List<string> content = new List<string>();

        public Form00GLCanvas()
        {
            InitializeComponent();

            this.glCanvas1.MouseMove += glCanvas1_MouseMove;
            this.glCanvas1.KeyPress += glCanvas1_KeyPress;

            Application.Idle += Application_Idle;
        }

        void glCanvas1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 't')
            {
                switch (this.glCanvas1.RenderTrigger)
                {
                    case RenderTrigger.TimerBased:
                        this.glCanvas1.RenderTrigger = RenderTrigger.Manual;
                        break;
                    case RenderTrigger.Manual:
                        this.glCanvas1.RenderTrigger = RenderTrigger.TimerBased;
                        break;
                    default:
                        break;
                }
            }
        }

        void Application_Idle(object sender, EventArgs e)
        {
            this.Text = string.Format("{0} - FPS: {1}", this.GetType().Name, this.glCanvas1.FPS.ToShortString());
        }

        private void UpdateContent()
        {
            this.content.Clear();
            var builder = new StringBuilder();
            int[] maxTextureSize = new int[1];
            OpenGL.GetInteger(GetTarget.MaxTextureSize, maxTextureSize);
            this.content.Add(string.Format("FPS: {0}", this.glCanvas1.FPS));
            this.content.Add(string.Format("Max Texture Width: {0}", maxTextureSize[0]));
            this.content.Add(string.Format("Max Color Attachments: {0}", Framebuffer.MaxColorAttachments()));
            this.content.Add(string.Format("Max Framebuffer Width: {0}", Framebuffer.MaxFramebufferWidth()));
            this.content.Add(string.Format("Max Framebuffer Height: {0}", Framebuffer.MaxFramebufferHeight()));
            this.content.Add(string.Format("Max Framebuffer Layers: {0}", Framebuffer.MaxFramebufferLayers()));
            this.content.Add(string.Format("Max Framebuffer Samples: {0}", Framebuffer.MaxFramebufferSamples()));
            //this.content.Add(string.Format("Framebuffer Default Width: {0}", Framebuffer.DefaultWidth()));
            //this.content.Add(string.Format("Framebuffer Default Height: {0}", Framebuffer.DefaultHeight()));
            //this.content.Add(string.Format("Framebuffer Default Layers: {0}", Framebuffer.DefaultLayers()));
            //this.content.Add(string.Format("Framebuffer Default Samples: {0}", Framebuffer.DefaultSamples()));
            //this.content.Add(string.Format("Framebuffer Default Fixed Sample Locations: {0}", Framebuffer.DefaultFixedSampleLocations()));
        }

        void glCanvas1_MouseMove(object sender, MouseEventArgs e)
        {
            this.mousePosition = e.Location;
        }

        private void glCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            // 天蓝色背景
            OpenGL.ClearColor(0x87 / 255.0f, 0xce / 255.0f, 0xeb / 255.0f, 0xff / 255.0f);
            OpenGL.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT | OpenGL.GL_STENCIL_BUFFER_BIT);

            UpdateContent();

            for (int i = 0; i < this.content.Count; i++)
            {
                OpenGL.DrawText(1, this.glCanvas1.Height - 1 - 14 * (i + 1),
                    Color.Red, "Courier New", 14.0f, content[i]);
            }

            OpenGL.DrawText(this.mousePosition.X,
                this.glCanvas1.Height - this.mousePosition.Y - 1, Color.Red, "Courier New",
                14.0f, string.Format("Mouse Position: {0}", this.mousePosition));
        }

    }
}
