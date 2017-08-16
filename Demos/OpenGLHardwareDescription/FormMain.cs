using CSharpGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OpenGLHardwareDescription
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            this.Load += FormMain_Load;
        }

        void FormMain_Load(object sender, EventArgs e)
        {
            this.textBox1.Text = GetOpenGLInfo();
        }

        private string GetOpenGLInfo()
        {
            var builder = new StringBuilder();
            int[] maxTextureSize = new int[1];
            GL.Instance.GetIntegerv((uint)GetTarget.MaxTextureSize, maxTextureSize);
            builder.AppendLine(string.Format("Max Texture Width: {0}", maxTextureSize[0]));
            builder.AppendLine(string.Format("Max Color Attachments: {0}", Framebuffer.MaxColorAttachments()));
            builder.AppendLine(string.Format("Max Framebuffer Width: {0}", Framebuffer.MaxFramebufferWidth()));
            builder.AppendLine(string.Format("Max Framebuffer Height: {0}", Framebuffer.MaxFramebufferHeight()));
            builder.AppendLine(string.Format("Max Framebuffer Layers: {0}", Framebuffer.MaxFramebufferLayers()));
            builder.AppendLine(string.Format("Max Framebuffer Samples: {0}", Framebuffer.MaxFramebufferSamples()));
            var values = new int[1];
            GL.Instance.GetIntegerv(GL.GL_MAX_VERTEX_IMAGE_UNIFORMS, values);
            builder.AppendLine(string.Format("Max Vertex Image Uniforms: {0}", values[0]));
            GL.Instance.GetIntegerv(GL.GL_MAX_TESS_CONTROL_IMAGE_UNIFORMS, values);
            builder.AppendLine(string.Format("Max TESS CONTROL Image Uniforms: {0}", values[0]));
            GL.Instance.GetIntegerv(GL.GL_MAX_TESS_EVALUATION_IMAGE_UNIFORMS, values);
            builder.AppendLine(string.Format("Max TESS EVALUATION Image Uniforms: {0}", values[0]));
            GL.Instance.GetIntegerv(GL.GL_MAX_GEOMETRY_IMAGE_UNIFORMS, values);
            builder.AppendLine(string.Format("Max Geometry Image Uniforms: {0}", values[0]));
            GL.Instance.GetIntegerv(GL.GL_MAX_FRAGMENT_IMAGE_UNIFORMS, values);
            builder.AppendLine(string.Format("Max Fragment Image Uniforms: {0}", values[0]));
            GL.Instance.GetIntegerv(GL.GL_MAX_COMBINED_IMAGE_UNIFORMS, values);
            builder.AppendLine(string.Format("Max Combined Image Uniforms: {0}", values[0]));
            GL.Instance.GetIntegerv(GL.GL_MAX_PATCH_VERTICES, values);
            builder.AppendLine(string.Format("Max Supported Patch Vertexes: {0}", values[0]));

            //builder.AppendLine(string.Format("Framebuffer Default Width: {0}", Framebuffer.DefaultWidth()));
            //builder.AppendLine(string.Format("Framebuffer Default Height: {0}", Framebuffer.DefaultHeight()));
            //builder.AppendLine(string.Format("Framebuffer Default Layers: {0}", Framebuffer.DefaultLayers()));
            //builder.AppendLine(string.Format("Framebuffer Default Samples: {0}", Framebuffer.DefaultSamples()));
            //builder.AppendLine(string.Format("Framebuffer Default Fixed Sample Locations: {0}", Framebuffer.DefaultFixedSampleLocations()));
            var maxUniformBufferBindings = new int[1];
            GL.Instance.GetIntegerv(GL.GL_MAX_UNIFORM_BUFFER_BINDINGS, maxUniformBufferBindings);
            builder.AppendLine(string.Format("Max Uniform Buffer Bindings: {0}", maxUniformBufferBindings[0]));
            return builder.ToString();
        }
    }
}
