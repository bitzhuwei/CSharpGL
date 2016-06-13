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
    public partial class Form12Billboard : Form
    {

        private Camera camera;
        private SatelliteRotator rotator;


        public Form12Billboard()
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

            {
                mat4 projection = arg.Camera.GetProjectionMat4();
                mat4 view = arg.Camera.GetViewMat4();
                vec4 translationColumn = view[3];
                translationColumn.x += this.position.x;
                translationColumn.y += this.position.y;
                translationColumn.z += this.position.z;
                view[3] = translationColumn;
                mat4 model = glm.scale(mat4.identity(), new vec3(0.3f, 0.3f, 0.3f));
                this.cubeRenderer.SetUniform("projectionMatrix", projection);
                this.cubeRenderer.SetUniform("viewMatrix", view);
                this.cubeRenderer.SetUniform("modelMatrix", model);
                this.cubeRenderer.Render(arg);
            }
            {
  
                this.ground.Render(arg);
            }
            {
                mat4 projection = arg.Camera.GetProjectionMat4();
                mat4 view = arg.Camera.GetViewMat4();
                mat4 model = mat4.identity();
                this.billboardRenderer.SetUniform("CameraRight_worldspace", new vec3(
                    view[0][0], view[1][0], view[2][0]));
                this.billboardRenderer.SetUniform("CameraUp_worldspace", new vec3(
                    view[0][1], view[1][1], view[2][1]));
                this.billboardRenderer.SetUniform("particleCenter_wordspace", new vec3(
                    (float)Math.Cos(currentTime), 1f, (float)Math.Sin(currentTime)));
                this.billboardRenderer.SetUniform("BillboardSize", new vec2(1.0f, 0.125f));
                float lifeLevel = (float)(Math.Sin(currentTime) * 0.4 + 0.5); currentTime += 0.1f;
                this.billboardRenderer.SetUniform("LifeLevel", lifeLevel);
                this.billboardRenderer.SetUniform("VP", projection * view);
                this.billboardRenderer.Render(arg);
            }
            UIRenderersDraw(arg);

            // Cross cursor shows where the mouse is.
            OpenGL.DrawText(this.lastMousePosition.X - offset.X,
                this.glCanvas1.Height - (this.lastMousePosition.Y + offset.Y) - 1,
                Color.Red, "Courier New", crossCursorSize, "o");
        }

        float currentTime = 0;
        vec3 position = new vec3(0, 0, 0);


        private const float crossCursorSize = 40.0f;

        private Point offset = new Point(13, 11);
        private void UIRenderersDraw(RenderEventArgs arg)
        {
            GLControl uiRoot = this.uiRoot;
            if (uiRoot != null)
            {
                uiRoot.Layout();
                mat4 projection, view, model;
                {
                    projection = glAxis.GetOrthoProjection();
                    vec3 position = (this.camera.Position - this.camera.Target).normalize();
                    view = glm.lookAt(position, new vec3(0, 0, 0), camera.UpVector);
                    float length = Math.Max(glAxis.Size.Width, glAxis.Size.Height) / 2;
                    model = glm.scale(mat4.identity(),
                        new vec3(length, length, length));
                    glAxis.Renderer.SetUniform("projectionMatrix", projection);
                    glAxis.Renderer.SetUniform("viewMatrix", view);
                    glAxis.Renderer.SetUniform("modelMatrix", model);

                    glAxis.Render(arg);
                }
            }
        }
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

            this.uiRoot.Size = this.glCanvas1.Size;
        }


        private void glCanvas1_KeyPress(object sender, KeyPressEventArgs e)
        {
            const float deltaDistance = 0.1f;

            if (e.KeyChar == 'w')
            {
                this.position.z += deltaDistance;
            }
            else if (e.KeyChar == 's')
            {
                this.position.z -= deltaDistance;
            }
            else if (e.KeyChar == 'a')
            {
                this.position.x -= deltaDistance;
            }
            else if (e.KeyChar == 'd')
            {
                this.position.x += deltaDistance;
            }
            else if(e.KeyChar=='r')
            {
                this.position = new vec3(0, 0, 0);
            }

            this.lblCubePosition.Text = string.Format("Cube Pos: {0}", this.position);
        }

    }

}
