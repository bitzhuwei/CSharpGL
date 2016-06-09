using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpGL.EarthMoonSystem
{
    public partial class FormMain : Form
    {

        private Camera camera;
        private SatelliteRotator rotator;

        private BackgroundStarsRenderer backgroundStars;

        private PickableRenderer earthRenderer;
        private sampler2D earthColorTexture;

        private PickableRenderer sunRenderer;
        private sampler2D sunColorTexture;

        private Renderer eclipticRenderer;

        private GLAxis glAxis;
        private GLControl uiRoot;

        public Color ClearColor { get; set; }

        private float celestialBodyScale = 100f;
        public float CelestialBodyScale
        {
            get { return celestialBodyScale; }
            set { celestialBodyScale = value; }
        }

        List<ITimeElapse> thingList = new List<ITimeElapse>();
        private Earth earth;
        private Sun sun;

        /// <summary>
        /// 时间流逝的速度。1为物理世界的流逝速度。
        /// </summary>
        public double TimeSpeed { get; set; }


        public FormMain()
        {
            InitializeComponent();

            this.TimeSpeed = 1;

            this.Load += FormMain_Load;
            this.glCanvas1.OpenGLDraw += glCanvas1_OpenGLDraw;
            this.glCanvas1.MouseDown += glCanvas1_MouseDown;
            this.glCanvas1.MouseMove += glCanvas1_MouseMove;
            this.glCanvas1.MouseUp += glCanvas1_MouseUp;
            this.glCanvas1.MouseWheel += glCanvas1_MouseWheel;
            this.glCanvas1.Resize += glCanvas1_Resize;

            Application.Idle += Application_Idle;
        }

        Random random = new Random();
        //float randomTime = 0.0f;

        void glCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            // set background color.
            OpenGL.ClearColor(ClearColor.R / 255.0f, ClearColor.G / 255.0f, ClearColor.B / 255.0f, ClearColor.A / 255.0f);

            OpenGL.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT | OpenGL.GL_STENCIL_BUFFER_BIT);

            this.earth.ScaleFactor = this.CelestialBodyScale;
            this.sun.ScaleFactor = this.celestialBodyScale;

            var arg = new RenderEventArgs(RenderModes.Render, this.glCanvas1.ClientRectangle, this.camera);

            {
                this.backgroundStars.Render(arg);
            }
            {
                mat4 projection = this.camera.GetProjectionMat4();
                //mat4 view = this.camera.GetViewMat4();
                mat4 view = this.earth.GetViewMatrix(this.camera);
                mat4 model = this.earth.GetModelRotationMatrix();
                this.earthRenderer.SetUniform("projectionMatrix", projection);
                this.earthRenderer.SetUniform("viewMatrix", view);
                this.earthRenderer.SetUniform("modelMatrix", model);
                this.earthRenderer.Render(arg);
            }
            {
                mat4 projection = this.camera.GetProjectionMat4();
                mat4 view = this.camera.GetViewMat4();
                mat4 model = this.sun.GetModelRotationMatrix();
                this.sunRenderer.SetUniform("projectionMatrix", projection);
                this.sunRenderer.SetUniform("viewMatrix", view);
                this.sunRenderer.SetUniform("modelMatrix", model);
                //randomTime += (float)random.NextDouble() / 1000.0f;
                //this.sunRenderer.SetUniform("time",randomTime);
                //this.sunRenderer.ShaderProgram.Bind();
                //this.sunRenderer.ShaderProgram.SetUniform("time", new float[] { randomTime, randomTime });
                //this.sunRenderer.ShaderProgram.Unbind();
                //this.sunRenderer.SetUniform("time", new float[] { randomTime, randomTime });
                //this.sunRenderer.SetUniform("colorTexture", new samplerValue(BindTextureTarget.Texture2D, this.sunColorTexture.Id, OpenGL.GL_TEXTURE0));
                this.sunRenderer.Render(arg);
            }
            {
                mat4 projection = this.camera.GetProjectionMat4();
                mat4 view = this.camera.GetViewMat4();
                mat4 model = mat4.identity();
                this.eclipticRenderer.SetUniform("projectionMatrix", projection);
                this.eclipticRenderer.SetUniform("viewMatrix", view);
                this.eclipticRenderer.SetUniform("modelMatrix", model);
                this.eclipticRenderer.Render(arg);
            }

            {
                this.uiRoot.Layout();
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


    }
}
