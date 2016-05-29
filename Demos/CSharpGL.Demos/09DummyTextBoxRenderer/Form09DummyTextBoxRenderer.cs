using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpGL.Demos
{
    public partial class Form09DummyTextBoxRenderer : Form
    {

        private Camera camera;
        private SatelliteRotator rotator;
        private DummyTextBoxRenderer renderer;


        public Form09DummyTextBoxRenderer()
        {
            InitializeComponent();

            this.glCanvas1.OpenGLDraw += glCanvas1_OpenGLDraw;
            this.glCanvas1.MouseDown += glCanvas1_MouseDown;
            this.glCanvas1.MouseMove += glCanvas1_MouseMove;
            this.glCanvas1.MouseUp += glCanvas1_MouseUp;
            this.glCanvas1.MouseWheel += glCanvas1_MouseWheel;
            this.glCanvas1.Resize += glCanvas1_Resize;

            OpenGL.ClearColor(0x87 / 255.0f, 0xce / 255.0f, 0xeb / 255.0f, 0xff / 255.0f);
        }

        private void glCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            OpenGL.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT | OpenGL.GL_STENCIL_BUFFER_BIT);

            RenderEventArgs arg = new RenderEventArgs(RenderModes.Render, this.glCanvas1.ClientRectangle, this.camera);
            IRenderable renderer = this.renderer;
            if (renderer != null)
            {
                mat4 projection, view, model;
                {
                    this.uiRenderer.GetMatrix(out projection, out view, out model, arg.Camera);
                    this.uiRenderer.Renderer.SetUniform("projectionMatrix", projection);
                    this.uiRenderer.Renderer.SetUniform("viewMatrix", view);
                    this.uiRenderer.Renderer.SetUniform("modelMatrix", model);
                    this.uiRenderer.Render(arg);
                }

                switch (this.layoutType)
                {
                    case LayoutType.UILayout:
                        this.renderer.GetMatrix(out projection, out view, out model);
                        this.renderer.SetUniform("mvp", projection * view * model);
                        break;
                    case LayoutType.CameraUILayout:
                        this.renderer.GetMatrix(out projection, out view, out model, arg.Camera);
                        this.renderer.SetUniform("mvp", projection * view * model);
                        break;
                    case LayoutType.MVPLayout:
                        projection = arg.Camera.GetProjectionMat4();
                        view = arg.Camera.GetViewMat4();
                        model = mat4.identity();
                        this.renderer.SetUniform("mvp", projection * view * model);
                        break;
                    default:
                        throw new NotImplementedException();
                }

                renderer.Render(arg);
            }

            // Cross cursor shows where the mouse is.
            OpenGL.DrawText(this.lastMousePosition.X - offset.X,
                this.glCanvas1.Height - (this.lastMousePosition.Y + offset.Y) - 1,
                Color.Red, "Courier New", crossCursorSize, "o");
        }


        private const float crossCursorSize = 40.0f;

        private Point offset = new Point(13, 11);
        private LayoutType layoutType;

        void glCanvas1_MouseWheel(object sender, MouseEventArgs e)
        {
            ICamera camera = this.camera;
            if (camera != null)
            {
                camera.MouseWheel(e.Delta);
            }
        }

        private void glCanvas1_Resize(object sender, EventArgs e)
        {
            if (camera != null)
            {
                camera.Resize(this.glCanvas1.Width, this.glCanvas1.Height);
            }
        }

        private void glCanvas1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'c')
            {
                switch (this.layoutType)
                {
                    case LayoutType.UILayout:
                        this.layoutType = LayoutType.CameraUILayout;
                        break;
                    case LayoutType.CameraUILayout:
                        this.layoutType = LayoutType.MVPLayout;
                        break;
                    case LayoutType.MVPLayout:
                        this.layoutType = LayoutType.UILayout;
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

    }

    enum LayoutType
    {
        UILayout,
        CameraUILayout,
        MVPLayout,
    }
}
