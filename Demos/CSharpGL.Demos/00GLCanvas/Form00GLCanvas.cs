using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

using System.Windows.Forms;

namespace CSharpGL.Demos
{
    public partial class Form00GLCanvas : Form
    {
        public Form00GLCanvas()
        {
            InitializeComponent();

            this.glCanvas1.KeyPress += glCanvas1_KeyPress;

            Application.Idle += Application_Idle;
        }

        private void glCanvas1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void Application_Idle(object sender, EventArgs e)
        {
            this.Text = string.Format("{0} - FPS: {1}", this.GetType().Name, this.glCanvas1.FPS.ToShortString());
        }

        private List<string> UpdateContent()
        {
            var content = new List<string>();
            var builder = new StringBuilder();
            int[] maxTextureSize = new int[1];
            OpenGL.GetInteger(GetTarget.MaxTextureSize, maxTextureSize);
            content.Add(string.Format("FPS: {0}", this.glCanvas1.FPS.ToShortString()));
            content.Add(string.Format("Max Texture Width: {0}", maxTextureSize[0]));
            content.Add(string.Format("Max Color Attachments: {0}", Framebuffer.MaxColorAttachments()));
            content.Add(string.Format("Max Framebuffer Width: {0}", Framebuffer.MaxFramebufferWidth()));
            content.Add(string.Format("Max Framebuffer Height: {0}", Framebuffer.MaxFramebufferHeight()));
            content.Add(string.Format("Max Framebuffer Layers: {0}", Framebuffer.MaxFramebufferLayers()));
            content.Add(string.Format("Max Framebuffer Samples: {0}", Framebuffer.MaxFramebufferSamples()));
            //content.Add(string.Format("Framebuffer Default Width: {0}", Framebuffer.DefaultWidth()));
            //content.Add(string.Format("Framebuffer Default Height: {0}", Framebuffer.DefaultHeight()));
            //content.Add(string.Format("Framebuffer Default Layers: {0}", Framebuffer.DefaultLayers()));
            //content.Add(string.Format("Framebuffer Default Samples: {0}", Framebuffer.DefaultSamples()));
            //content.Add(string.Format("Framebuffer Default Fixed Sample Locations: {0}", Framebuffer.DefaultFixedSampleLocations()));
            return content;
        }

        private void glCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            // 天蓝色背景
            //OpenGL.ClearColor(0x87 / 255.0f, 0xce / 255.0f, 0xeb / 255.0f, 0xff / 255.0f);
            OpenGL.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT | OpenGL.GL_STENCIL_BUFFER_BIT);

            var result = new int[1];
            OpenGL.GetInteger(GetTarget.StencilWritemask, result);
            OpenGL.GetInteger(GetTarget.StencilBackWritemask, result);
            OpenGL.GetInteger(GetTarget.StencilWritemask, result);
            //OpenGL.StencilMask()
            List<string> content = UpdateContent();

            for (int i = 0; i < content.Count; i++)
            {
                OpenGL.DrawText(1, this.glCanvas1.Height - 1 - 14 * (i + 1),
                    Color.Red, "Courier New", 14.0f, content[i]);
            }

            Point mousePosition = this.glCanvas1.PointToClient(Control.MousePosition);
            OpenGL.DrawText(mousePosition.X,
                this.glCanvas1.Height - mousePosition.Y - 1, Color.Red, "Courier New",
                14.0f, string.Format("Mouse Position: {0}", mousePosition));
        }
    }
}