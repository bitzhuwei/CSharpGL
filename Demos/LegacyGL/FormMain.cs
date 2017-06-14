using CSharpGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LegacyGL
{
    public partial class FormMain : Form
    {
        private Scene scene;
        public FormMain()
        {
            InitializeComponent();

            this.Load += FormMain_Load;
            this.winGLCanvas1.OpenGLDraw += winGLCanvas1_OpenGLDraw;
            this.winGLCanvas1.Resize += winGLCanvas1_Resize;
        }

        void FormMain_Load(object sender, EventArgs e)
        {
            // this camera is not actually in use.
            var camera = new Camera(new vec3(5, 3, 4), new vec3(0, 0, 0), new vec3(0, 1, 0), CameraType.Perspecitive, this.winGLCanvas1.Width, this.winGLCanvas1.Height);
            this.scene = new Scene()
            {
                Camera = camera,
                ClearColor = Color.SkyBlue,
                RootElement = new BoundedClockRenderer(),
            };

            winGLCanvas1_Resize(this.winGLCanvas1, EventArgs.Empty);
        }

        void winGLCanvas1_OpenGLDraw(object sender, PaintEventArgs e)
        {
            this.scene.Render();
        }

        void winGLCanvas1_Resize(object sender, EventArgs e)
        {
            //  Set the projection matrix.
            GL.Instance.MatrixMode(GL.GL_PROJECTION);

            //  Load the identity.
            GL.Instance.LoadIdentity();
            ////  Create a perspective transformation.
            //OpenGL.gluPerspective(60.0f, width / height, 0.01, 100.0);
            mat4 projectionMatrix = glm.perspective(glm.radians(60.0f), ((float)this.winGLCanvas1.Width) / ((float)this.winGLCanvas1.Height), 0.01f, 100.0f);
            GL.Instance.MultMatrixf((projectionMatrix * viewMatrix).ToArray());

            //  Set the modelview matrix.
            GL.Instance.MatrixMode(GL.GL_MODELVIEW);
        }

        ////  Use the 'look at' helper function to position and aim the camera.
        //OpenGL.gluLookAt(-2, 2, -2, 0, 0, 0, 0, 1, 0);
        private static readonly mat4 viewMatrix = glm.lookAt(new vec3(0, 0, 2.5f), new vec3(0, 0, 0), new vec3(0, 1, 0));

    }
}
